using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AStar
{
    public partial class Form1 : Form
    {
        private Grid grid;
        private Graphics graphics;
        private Point mousePos;
        public Form1()
        {
            InitializeComponent();
            grid = new Grid(this);
            graphics = this.CreateGraphics();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            grid.DrawLines(graphics);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                try
                {
                    mousePos = this.PointToClient(MousePosition);
                    grid.Items[mousePos.X / 20, mousePos.Y / 20].State = Grid.GridItemStates.Wall;
                    grid.DrawItem(graphics);
                }
                catch (System.IndexOutOfRangeException)
                {
                    Debug.WriteLine("out of range");
                }
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                try
                {
                    mousePos = this.PointToClient(MousePosition);
                    grid.Items[mousePos.X / 20, mousePos.Y / 20].State = Grid.GridItemStates.Wall;
                    grid.DrawItem(graphics);
                }
                catch (System.IndexOutOfRangeException)
                {
                    Debug.WriteLine("out of range");
                }
            }
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R)
            {
                grid = new Grid(this);
                graphics.Clear(SystemColors.Control);
                grid.DrawLines(graphics);
                grid.DrawItem(graphics);
            }
            if (e.KeyCode == Keys.Space)
            {
                Debug.WriteLine("yes");
                Node playerNode = grid.Items[0, 0];
                playerNode.State = Grid.GridItemStates.Player;
                Node finishNode = grid.Items[20, 20];
                finishNode.State = Grid.GridItemStates.Finish;
                Pathfinding.FindPath(grid, playerNode, finishNode);
                grid.DrawItem(graphics);
            }
        }
    }
}
