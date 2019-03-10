using WorstGameStudios.Core.Abstractions.Engine.Coordinates;

namespace GGJ2019.Game.Entities
{
    public class Grid
    {
        private readonly Cell[,] cells;

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;


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

        public Cell GetCell(int x, int y)
        {
            if (x >= Width)
            {
                x = Width - 1;
            }
            if (x < 0)
            {
                x = 0;
            }

            if (y >= Height)
            {
                y = Height - 1;
            }
            if (y < 0)
            {
                y = 0;
            }

            return cells[x, y];
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
