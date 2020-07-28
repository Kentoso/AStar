using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Principal;

namespace AStar
{
    public class Grid
    {
        public enum GridItemStates
        {
            Empty = 1,
            Wall = 2,
            Player = 3,
            Path = 4,
            Finish = 5
        }

        public enum DrawStates
        {
            Wall = 1,
            Player = 2,
            Finish = 3
        }

        public Node[,] Items;
        public List<Node> Path;

        public Grid(Form1 form)
        {
            Items = new Node[form.Width/20, form.Height / 20];
            Path = new List<Node>();
            for (int i = 0; i < form.Width / 20; i++)
            {
                for (int j = 0; j < form.Height / 20; j++)
                {
                    Items[i, j] = new Node(GridItemStates.Empty, (i, j));
                }
            }
        }

        public List<Node> GetNodeNeighbours(Node node)
        {
            List<Node> neighbours = new List<Node>();
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                    {
                        continue;
                    }

                    int checkX = node.GridPosition.x + x;
                    int checkY = node.GridPosition.y + y;
                    if (checkX >= 0 && checkX < Items.GetLength(0) && checkY >= 0 && checkY < Items.GetLength(1))
                    {
                         neighbours.Add(Items[checkX, checkY]);
                    }
                }
            }

            return neighbours;
        }
        public void DrawLines(Graphics graphics)
        {
            for (int i = 0; i < Items.GetLength(0) + 1; i++)
            {
                graphics.DrawLine(Pens.Black, 0, i * 20, 815, i * 20);
                graphics.DrawLine(Pens.Black, i * 20, 0, i * 20, 835);
            }
        }
        public void DrawItem(Graphics graphics)
        {
            for (int i = 0; i < Items.GetLength(0); i++)
            {
                for (int j = 0; j < Items.GetLength(1); j++)
                {
                    if (Path.Count > 0)
                    {
                        foreach (var node in Path.Take(Path.Count - 1))
                        {
                            node.State = GridItemStates.Path;
                        }
                    }
                    if (Items[i, j].State == Grid.GridItemStates.Wall)
                    {
                        graphics.FillRectangle(Brushes.Black, 20f * i, 20f * j, 20f, 20f);
                    }
                    if (Items[i, j].State == Grid.GridItemStates.Path)
                    {
                        graphics.FillRectangle(Brushes.Red, 20f * i, 20f * j, 20f, 20f);
                    }
                    if (Items[i, j].State == Grid.GridItemStates.Player)
                    {
                        graphics.FillRectangle(Brushes.Purple, 20f * i, 20f * j, 20f, 20f);
                    }
                    if (Items[i, j].State == Grid.GridItemStates.Finish)
                    {
                        graphics.FillRectangle(Brushes.ForestGreen, 20f * i, 20f * j, 20f, 20f);
                    }
                    
                }
                
            }
        }
    }
}