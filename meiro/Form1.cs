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
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DrawPanel(int[][] map, int lenX, int lenY, int width, int height)
        {

            var g = field.CreateGraphics();
            for (var x = 0; x <= lenX - 1; x++)
            {
                for (var y = 0; y <= lenY - 1; y++)
                {
                    switch (map[y][x])
                    {
                        case 0:
                            g.FillRectangle(Brushes.Blue, x * width, y * height, width, height);
                            break;
                        case 1:
                            g.FillRectangle(Brushes.White, x * width, y * height, width, height);
                            break;
                        case 2:
                            g.FillRectangle(Brushes.Yellow, x * width, y * height, width, height);
                            break;
                        case 3:
                            g.FillRectangle(Brushes.Tomato, x * width, y * height, width, height);
                            break;

                    }
                    g.DrawRectangle(Pens.Black, x * width, y * height, width, height);

                }
            }
        }

        private void DrawPath(Tuple<int,int> [] path, int width, int height){
            foreach (var t in path)
            {
                var g = field.CreateGraphics();
                var x = t.Item1 * width + width / 4;
                var y = t.Item2 * height + height / 4;
                g.FillEllipse(Brushes.Red, x, y, width / 2, height / 2);
            }
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
            var g = field.CreateGraphics();
            g.FillRectangle(Brushes.White, 0, 0, field.Width, field.Height);
            g.Dispose();

            try
            {
                var p = new Logic.Parser(fileNameBox.Text);
                var map = p.Map;

                var lenX = map[0].Length;
                var lenY = map.Length;
                var width = field.Width / lenX;
                var height = field.Height / lenY;

                this.SuspendLayout();
                this.DrawPanel(p.Map, lenX, lenY, width, height);
                this.DrawPath(p.Solve(), width, height);
                this.ResumeLayout();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Bad input!");
            }
        }

        private void field_Resize(object sender, EventArgs e)
        {

        }

        private void top_Resize(object sender, EventArgs e)
        {
            field.Height = this.Height - 150;
            field.Width = this.Width - 50;
        }


    }
}
