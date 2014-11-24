using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace meiro
{
    public partial class top : Form
    {
        public top()
        {
            InitializeComponent(); 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void DrawPanel(int[][] map)
        {
            var lenX = map[0].Length;
            var lenY = map.Length;
            var width = field.Width / lenX;
            var height = field.Height / lenY;
            var g = field.CreateGraphics();
            for (var x = 0; x <= lenX - 1; x++)
            {
                for (var y = 0; y <= lenY - 1; y++)
                {
                    switch (map[y][x])
                    {
                        case 0:
                            g.FillRectangle(System.Drawing.Brushes.Blue, x * width, y * height, width, height);
                            break;
                        case 1:
                            g.FillRectangle(System.Drawing.Brushes.White, x * width, y * height, width, height);
                            break;

                    }
                }
            }
        }

        private void DrawPath(Tuple<int,int> [] path){

        }

        private void testBtn_Click(object sender, EventArgs e)
        {
            var g = field.CreateGraphics();
            var rec = new Rectangle(100, 100, 100, 100);
            g.DrawEllipse(Pens.Black, rec);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
 
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.ShowDialog();
            fileNameBox.Text = dialog.FileName;
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            var p = new Logic.Parser(fileNameBox.Text);
            this.DrawPanel(p.Map);
            this.DrawPath(p.Solve());
        }


    }
}
