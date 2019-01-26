

using GGJ2019.Core.Models;

namespace GGJ2019.Game.Entities
{
    public class Grid
    {
        private readonly Cell[,] cells;

        public Grid(int width, int height)
        {
            Width = width;
            Height = Height;


            cells = new Cell[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    cells[i, j] = new Cell()
                    {
                        Position = new Vector(i, j),
                        Available = true,
                    };
                }
            }
        }

        public int Width { get; }
        public int Height { get; }

        public bool IsCellAvailable(int x, int y) => cells?[x, y]?.Available ?? false;

        public void PutObjectAt(int x, int y)
        {
            if (IsCellAvailable(x, y))
            {
                cells[x, y].Available = false;
            }
        }

        public void Reset()
        {
            foreach (var cell in cells)
            {
                cell.Available = true;
            }
        }
    }

    public class Cell
    {
        public Vector Position { get; set; }
        public bool Available { get; set; }
    }
}
