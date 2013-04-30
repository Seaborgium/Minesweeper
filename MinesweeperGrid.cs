namespace MinesweeperProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MinesweeperGrid
    {
        private static readonly Random randomGenerator = new Random();

        private readonly MinesweeperCell[,] grid;
        private readonly int rowsCount;
        private readonly int columnsCount;
        private readonly int minesCount;

        public MinesweeperGrid(int rowsCount, int columnsCount, int minesCount)
        {
            this.rowsCount = rowsCount;
            this.columnsCount = columnsCount;
            this.minesCount = minesCount;
            this.grid = new MinesweeperCell[rowsCount, columnsCount];

            Clear();
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

        public void SetCellValue(int row, int column, char value)
        {
            if (!IsValidCell(row, column))
            {
                throw new InvalidCellException();
            }

            this.grid[row, column].Value = value;
        }

        public char GetCellValue(int row, int column)
        {
            if (!IsValidCell(row, column))
            {
                throw new InvalidCellException();
            }

            char result = this.grid[row, column].Value;
            return result;
        }

        public MinesweeperCell GetCell(int row, int column)
        {
            if (IsValidCell(row, column))
            {
                throw new InvalidCellException();
            }

            return this.grid[row, column];
        }

        public char RevealCell(int row, int column)
        {
            if ((!IsValidCell(row, column)) || this.grid[row, column].Revealed)
            {
                throw new InvalidCellException();
            }

            this.grid[row, column].Reveal();
            if (this.grid[row, column].Value != '*')
            {
                int neighbourMinesCount = NeighbourMinesCount(row, column);
                var cellValue = neighbourMinesCount.ToString()[0];
                SetCellValue(row, column, cellValue);
            }
            return this.grid[row, column].Value;
        }

        public void Reset()
        {
            Clear();
            Initialize();
        }

        private int NeighbourMinesCount(int row, int column)
        {
            if (!IsValidCell(row, column))
            {
                throw new InvalidCellException();
            }

            //restrict neigbour cell area
            int minRow = (row - 1) < 0 ? row : row - 1;
            int maxRow = (row + 1) >= rowsCount ? row : row + 1;
            int minColumn = (column - 1) < 0 ? column : column - 1;
            int maxColumn = (column + 1) >= columnsCount ? column : column + 1;

            int count = 0;
            for (int i = minRow; i <= maxRow; i++)
            {
                for (int j = minColumn; j <= maxColumn; j++)
                {
                    if (this.grid[i, j].Value == '*')
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

        private void Clear()
        {
            for (int i = 0; i < this.rowsCount; i++)
            {
                for (int j = 0; j < this.columnsCount; j++)
                {
                    this.grid[i, j] = new MinesweeperCell();   
                }
            }
        }

        public int RevealedCount()
        {
            int count = 0;
            foreach (var cell in this.grid)
            {
                if (cell.Revealed)
                {
                    count++;
                }
            }
            return count;
        }

        public void RevealMines()
        {
            foreach(var cell in this.grid)
            {
                if (cell.Value == '*')
                {
                    cell.Reveal();
                }
            }
        }

        public void MarkCell(char marker)
        {
            foreach (var cell in grid)
            {
                if ((cell.Value != '*') && (!cell.Revealed))
                {
                    cell.Value = marker;
                    cell.Reveal();
                }
            }
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("   ");

            //generates column numbers
            for (int i = 0; i < columnsCount; i++)
            {
                result.AppendFormat(" {0}", i);
            }
            result.Append(" \n");

            //generates -----------------
            result.Append("   ");
            result.Append('-', columnsCount * 2 + 1);
            result.Append(" \n");

            for (int i = 0; i < rowsCount; i++)
            {
                //generates row number
                result.AppendFormat("{0} |", i);

                //generate values in each row
                for (int j = 0; j < columnsCount; j++)
                {
                    result.AppendFormat(" {0}", this.grid[i, j].VisibleValue);
                }
                result.Append(" |\n");
            }

            //generates -----------------
            result.Append("   ");
            result.Append('-', columnsCount * 2 + 1);
            result.Append(" \n");

            return result.ToString();
        }
    }
}
