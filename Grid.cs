using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_2048
{
    public class Grid
    {
        public const int SIZE = 4;

        public Cell[,] Cells;



        public Grid()
        {
            Cells = new Cell[4, 4];
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            for (int row = 0; row < SIZE; row++)
            {
                for (int col = 0; col < SIZE; col++)
                {
                    Cells[row, col] = new Cell();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder gridString = new StringBuilder();
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    gridString.Append(Cells[row, col].ToString());
                }
                gridString.AppendLine();
            }
            return gridString.ToString();
        }

    }
}
