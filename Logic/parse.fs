namespace Logic
  open System
  open System.IO
  open System.Collections.Generic

  exception BadInput of int * int (* includes line number *)
  exception NoEntry
  type Node = Wall | Room | Start | Exit
  type Result = {bef:(int * int) option; len:int}

  type public Parser(path) =
    let startPoint = ref (-1, -1)
    let exitPoint = ref (-1, -1)
    let charToSymbol i j (c: char) =
        match c with
        | '@' -> startPoint := (i, j); Start
        | ' ' -> Room
        | 'X' -> Wall
        | '*' -> exitPoint := (i, j); Exit
        | _ -> raise (BadInput (i, j))
    let conv path =
       let output =
         IO.File.ReadAllLines path
         |> Array.map (fun str -> str.ToCharArray ())
         |> Array.mapi (fun i arr -> 
              Array.mapi (fun j c -> charToSymbol j i c) arr)
       if !startPoint = (-1, -1) || !exitPoint = (-1, -1) then
            raise NoEntry
       else output
    let map = conv path
    let maxY = Array.length map
    let maxX = Array.length map.[0]
    let get x y = 
        if x <= maxX - 1 && x >= 0 && y <= maxY - 1 && y >= 0
        then Some map.[y].[x] 
        else None
    let getOfPair (x,y) = get x y
    let getWithLoc x y =
        if x <= maxX - 1 && x >= 0 && y <= maxY - 1 && y >= 0
        then Some (x, y, map.[y].[x])
        else None
    let access (x, y) =
        [getWithLoc x (y + 1); getWithLoc x (y - 1); 
         getWithLoc (x + 1) y; getWithLoc (x - 1) y]
        |> List.fold (fun s -> 
            function None -> s 
                   | Some (x, y, n) -> if n <> Wall then (x, y) :: s else s) [] 
    let table = 
        let t = Dictionary<int*int, Result> ()
        t.Add(!startPoint, {bef=None; len=0})
        t
    let searchSet =
        let t = Dictionary<int, (int*int) list ref>()
        t.Add(0, ref [!startPoint])
        t
    let searchAdd len pos =
      if searchSet.ContainsKey len
      then
          let l = !searchSet.[len]
          searchSet.Remove len |> ignore
          searchSet.Add (len, ref (pos::l))
      else searchSet.Add (len, ref [pos])
    let rec pop len =
        if searchSet.Count = 0 then failwith "pop"
        if searchSet.ContainsKey(len)
        then 
            match !searchSet.[len] with
            | [] -> pop (len + 1)
            | x::xs ->
              if xs = [] then searchSet.Remove(len) |> ignore; (x, len) 
              else searchSet.[len] := xs; (x, len)
        else pop (len + 1)
    let endFlag = ref false
    let rec solve () =
        let pos, len = pop 0
        let l = access pos
        List.iter (fun p -> 
          if not (table.ContainsKey p) 
          then
              if getOfPair p = Some Exit then endFlag := true
              table.Add (p, {len=len + 1; bef=Some pos})
              searchAdd (len + 1) p) l
        if !endFlag then () else solve ()  
    let makeLine () =
      let rec chain acc pos =
          match table.[pos].bef with
          | None -> pos::acc
          | Some p -> chain (pos::acc) p
      chain [] !exitPoint |> List.rev
    member this.Map =
        map
        |> Array.map (Array.map (function
            | Wall -> 0
            | Room -> 1
            | Start -> 2
            | Exit -> 3))
    member this.Solve () =
      solve ()
      makeLine ()
      |> List.toArray