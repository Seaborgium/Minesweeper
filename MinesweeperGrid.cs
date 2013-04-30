using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinesweeperProject
{
    public class MinesweeperGrid
    {
        private static readonly Random randomGenerator = new Random();
        private MinesweeperCell[,] grid;
        private int rowsCount;
        private int columnsCount;
        private int minesCount;

        public MinesweeperGrid(int rowsCount, int columnsCount, int minesCount)
        {
            this.rowsCount = rowsCount;
            this.columnsCount = columnsCount;
            this.minesCount = minesCount;
            this.grid = new MinesweeperCell[rowsCount, columnsCount];
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    grid[i, j] = new MinesweeperCell();
                }
            }


        }

        public bool IsValidCell(int row, int column)
        {
            if ((row >= 0 && row < rowsCount) && (column >= 0 && column < columnsCount))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SetCellValue(int row, int column, char value)
        {
            if (!IsValidCell(row, column))
            {
                throw new InvalidCellException();
            }

            grid[row, column].Value = value;
        }

        private char GetCellValue(int row, int column)
        {
            if (!IsValidCell(row, column))
            {
                throw new InvalidCellException();
            }

            char result = grid[row, column].Value;
            return result;
        }

        public char RevealCell(int row, int column)
        {
            if ((!IsValidCell(row, column)) || grid[row, column].Revealed)
            {
                throw new InvalidCellException();
            }

            grid[row, column].Reveal();
            if (grid[row, column].Value != '*')
            {
                int neighbourMinesCount = NeighbourMinesCount(row, column);
                var cellValue = neighbourMinesCount.ToString()[0];
                SetCellValue(row, column, cellValue);
            }
            return grid[row, column].Value;
        }

        public int NeighbourMinesCount(int row, int column)
        {
            if (!IsValidCell(row, column))
            {
                throw new InvalidCellException();
            }

            //restrict neigbour cell area
            int minRow = (row - 1) < 0 ? row : row - 1;
            int maxRow = (row + 1) >= rowsCount ? row : row + 1;
            int minColumn = (column - 1) < 0 ? column : column - 1;
            int maxColumn = (column + 1) >= columnsCount ? column : column + 1; ;

            int count = 0;
            for (int i = minRow; i <= maxRow; i++)
            {
                for (int j = minColumn; j <= maxColumn; j++)
                {
                    if (grid[i, j].Value == '*')
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private List<int> GenerateRandomNumbers(int numbersCount, int maximalNumber)
        {
            List<int> randomNumbers = new List<int>();
            for (int i = 0; i < numbersCount; i++)
            {
                int newRandomNumber = 0;
                do
                {
                    newRandomNumber = randomGenerator.Next(maximalNumber);
                }
                while ((randomNumbers.Count(n => n == newRandomNumber) > 0));

                randomNumbers.Add(newRandomNumber);
            }
            return randomNumbers;
        }

        private void Initialize()
        {
            List<int> mineCoordinates = GenerateRandomNumbers(this.minesCount, this.rowsCount * this.columnsCount);

            for (int i = 0; i < minesCount; i++)// fill mines
            {   
                int row = mineCoordinates[i] / columnsCount;
                int column = mineCoordinates[i] % columnsCount;
                SetCellValue(row, column, '*');
            }
        }

        private void put()
        {
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    char currentCellValue = GetCellValue(i, j);
                    if (currentCellValue != '*')
                    {
                        int neighbourMinesCount = NeighbourMinesCount(i, j);
                        SetCellValue(i, j, neighbourMinesCount.ToString()[0]);
                    }
                }



            }
        }

        public void Reset()
        {
            Clear();
            Initialize();
        }

        public void Clear()
        {
            for (int i = 0; i < this.rowsCount; i++)
            {
                for (int j = 0; j < this.columnsCount; j++)
                {
                    grid[i, j] = new MinesweeperCell();   
                }
            }

        }

        public int RevealedCount()
        {
            int count = 0;
            for (int i = 0; i < this.rowsCount; ++i)
            {
                for (int j = 0; j < this.columnsCount; ++j)
                {
                    {
                        if (this.grid[i, j].Revealed)
                            count++;
                    }
                }
            }
            return count;
        }

        public void RevealMines()
        {
            for (int i = 0; i < this.rowsCount; i++)
            {
                for (int j = 0; j < this.columnsCount; j++)
                {
                    if (this.grid[i, j].Value == '*')
                    {
                        this.grid[i, j].Reveal();
                    }
                }
            }
        }

        public void mark(char marker)
        {
            foreach (var elem in grid)
            {
                if ((elem.Value != '*') && (!elem.Revealed))
                {
                    elem.Value = marker;
                    elem.Reveal();
                }
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("   ");

            //generates column numbers
            for (int i = 0; i < columnsCount; i++)
            {
                sb.AppendFormat(" {0}", i);
            }
            sb.Append(" \n");

            //generates -----------------
            sb.Append("   ");
            sb.Append('-', columnsCount * 2 + 1);
            sb.Append(" \n");

            for (int i = 0; i < rowsCount; i++)
            {
                //generates row number
                sb.AppendFormat("{0} |", i);

                //generate values in each row
                for (int j = 0; j < columnsCount; j++)
                {
                    sb.AppendFormat(" {0}", grid[i, j].VisibleValue);
                }
                sb.Append(" |\n");
            }

            //generates -----------------
            sb.Append("   ");
            sb.Append('-', columnsCount * 2 + 1);
            sb.Append(" \n");

            return sb.ToString();
        }

        public MinesweeperCell get(int row, int column)
        {
            if (IsValidCell(row, column))
                throw new InvalidCellException();
            return grid[row, column];
        }
    }
}
