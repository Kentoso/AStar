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
        private Node playerNode;
        private Node finishNode;
        private Grid.DrawStates Brush = Grid.DrawStates.Wall;
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
                    switch (Brush)
                    {
                        case Grid.DrawStates.Wall:
                            if (grid.Items[mousePos.X / 20, mousePos.Y / 20].State == Grid.GridItemStates.Empty)
                            {
                                grid.Items[mousePos.X / 20, mousePos.Y / 20].State = Grid.GridItemStates.Wall;
                            }
                            break;
                        case Grid.DrawStates.Player:
                            if (playerNode == null)
                            {
                                grid.Items[mousePos.X / 20, mousePos.Y / 20].State = Grid.GridItemStates.Player;
                                playerNode = grid.Items[mousePos.X / 20, mousePos.Y / 20];
                            }
                            break;
                        case Grid.DrawStates.Finish:
                            if (finishNode == null)
                            {
                                grid.Items[mousePos.X / 20, mousePos.Y / 20].State = Grid.GridItemStates.Finish;
                                finishNode = grid.Items[mousePos.X / 20, mousePos.Y / 20];
                            }
                            break;
                    }
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

                    switch (Brush)
                    {
                        case Grid.DrawStates.Wall:
                            if (grid.Items[mousePos.X / 20, mousePos.Y / 20].State == Grid.GridItemStates.Empty)
                            {
                                grid.Items[mousePos.X / 20, mousePos.Y / 20].State = Grid.GridItemStates.Wall;
                            }
                            break;
                        case Grid.DrawStates.Player:
                            if (playerNode == null)
                            {
                                grid.Items[mousePos.X / 20, mousePos.Y / 20].State = Grid.GridItemStates.Player;
                                playerNode = grid.Items[mousePos.X / 20, mousePos.Y / 20];
                            }
                            break;
                        case Grid.DrawStates.Finish:
                            if (finishNode == null)
                            {
                                grid.Items[mousePos.X / 20, mousePos.Y / 20].State = Grid.GridItemStates.Finish;
                                finishNode = grid.Items[mousePos.X / 20, mousePos.Y / 20];
                            }
                            break;
                    }
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
            switch (e.KeyCode)
            {
                case Keys.R:
                    grid = new Grid(this);
                    graphics.Clear(SystemColors.Control);
                    grid.DrawLines(graphics);
                    grid.DrawItem(graphics);
                    playerNode = null;
                    finishNode = null;
                    break;
                case Keys.Space:
                    if (playerNode != null && finishNode != null)
                    {
                        playerNode.State = Grid.GridItemStates.Player;
                        finishNode.State = Grid.GridItemStates.Finish;
                        Pathfinding.FindPath(grid, playerNode, finishNode);
                        grid.DrawItem(graphics);
                    }
                    break;
                case Keys.D1:
                    Brush = Grid.DrawStates.Wall;
                    break;
                case Keys.D2:
                    Brush = Grid.DrawStates.Finish;
                    break;
                case Keys.D3:
                    Brush = Grid.DrawStates.Player;
                    break;
            }
        }
    }
}
