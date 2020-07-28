using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AStar
{
    public class Grid
    {
        public enum GridItemStates
        {
            Empty = 1,
            Wall = 2,
            Player = 3,
            Path = 4
        }

        public int[,] Items;

        public Grid(Form1 form)
        {
            Items = new int[form.Width/20, form.Height / 20];
            for (int i = 0; i < form.Width / 20; i++)
            {
                for (int j = 0; j < form.Height / 20; j++)
                {
                    
                }
            }
        }

        public void Draw(Graphics graphics)
        {
            graphics.Clear(SystemColors.Control);
            for (int i = 0; i < Items.GetLength(0); i++)
            {
                for (int j = 0; j < Items.GetLength(1); j++)
                {
                    if (Items[i, j] == 0)
                    {
                        graphics.DrawRectangle(Pens.Black, 20f * i, 20f * j, 20f, 20f);
                    }
                    else if (Items[i, j] == 1)
                    {
                        graphics.FillRectangle(Brushes.Black, 20f * i, 20f * j, 20f, 20f);
                    }
                }
            }
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
                    if (Items[i, j] == (int)Grid.GridItemStates.Wall)
                    {

                        graphics.FillRectangle(Brushes.Black, 20f * i, 20f * j, 20f, 20f);
                    }

                    else if (Items[i, j] == (int)Grid.GridItemStates.Empty)
                    {
                        graphics.DrawRectangle(Pens.Black, 20f * i, 20f * j, 20f, 20f);
                        Items[i, j] = 0;
                    }
                }
                
            }
        }
    }
}