namespace MinesweeperProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents the grid in a minesweeper game.
    /// </summary>
    public class MinesweeperGrid
    {
        /// <summary>
        /// Used to generate random numbers when the grid is initialized.
        /// </summary>
        private static readonly Random RandomNumberGenerator = new Random();

        /// <summary>
        /// Represents the grid in the game.
        /// </summary>
        private readonly MinesweeperCell[,] grid;

        /// <summary>
        /// The number of rows in the grid.
        /// </summary>
        private readonly int rowsCount;

        /// <summary>
        /// The number of columns in the grid.
        /// </summary>
        private readonly int columnsCount;

        /// <summary>
        /// The number of mines in the grid.
        /// </summary>
        private readonly int minesCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="MinesweeperGrid"/> class.
        /// The grid will have <paramref name="rowsCount"/> rows
        /// and <paramref name="columnsCount"/> columns. The grid will contain
        /// <paramref name="minesCount"/> mines.
        /// </summary>
        /// <param name="rowsCount">The number of rows in the grid.</param>
        /// <param name="columnsCount">The number of columns in the grid.</param>
        /// <param name="minesCount">The number of mines in the grid.</param>
        public MinesweeperGrid(int rowsCount, int columnsCount, int minesCount)
        {
            this.rowsCount = rowsCount;
            this.columnsCount = columnsCount;
            this.minesCount = minesCount;
            this.grid = new MinesweeperCell[rowsCount, columnsCount];

            this.Clear();
        }

        /// <summary>
        /// Determines weather the provided row and column are in the boundaries of the grid.
        /// </summary>
        /// <param name="row">The row of the cell.</param>
        /// <param name="column">The column of the cell.</param>
        /// <returns>True if the provided  <paramref name="row"/> and  <paramref name="column"/> are in the boundaries of the grid.</returns>
        public bool IsValidCell(int row, int column)
        {
            if ((row >= 0 && row < this.rowsCount) && (column >= 0 && column < this.columnsCount))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the value of a cell in the grid at the given <paramref name="row"/> 
        /// and <paramref name="column"/> to <paramref name="value"/>.
        /// </summary>
        /// <param name="row">The row of the cell.</param>
        /// <param name="column">The column of the cell.</param>
        /// <param name="value">The value which will be set to the cell.</param>
        public void SetCellValue(int row, int column, char value)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidCellException();
            }

            this.grid[row, column].Value = value;
        }

        /// <summary>
        /// Gets the value of the cell with coordinates <paramref name="row"/> 
        /// and <paramref name="column"/>.
        /// </summary>
        /// <param name="row">The row of the cell.</param>
        /// <param name="column">The column of the cell.</param>
        /// <returns>The value of the cell with coordinates <paramref name="row"/> 
        /// and <paramref name="column"/>.</returns>
        public char GetCellValue(int row, int column)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidCellException();
            }

            char result = this.grid[row, column].Value;
            return result;
        }

        /// <summary>
        /// Gets the cell with coordinates <paramref name="row"/>
        /// and <paramref name="column"/>.
        /// </summary>
        /// <param name="row">The row of the cell.</param>
        /// <param name="column">The column of the cell.</param>
        /// <returns>The cell with coordinates <paramref name="row"/>
        /// and <paramref name="column"/>.</returns>
        public MinesweeperCell GetCell(int row, int column)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidCellException();
            }

            return this.grid[row, column];
        }

        /// <summary>
        /// Reveals the cell with coordinate <paramref name="row"/>
        /// and <paramref name="column"/>.
        /// </summary>
        /// <param name="row">The row of the cell.</param>
        /// <param name="column">The column of the cell.</param>
        /// <returns>The revealed value of the cell with coordinates
        /// <paramref name="row"/> and <paramref name="column"/>.</returns>
        public char RevealCell(int row, int column)
        {
            if ((!this.IsValidCell(row, column)) || this.grid[row, column].IsRevealed)
            {
                throw new InvalidCellException();
            }

            this.grid[row, column].Reveal();
            if (this.grid[row, column].Value != '*')
            {
                int neighbourMinesCount = this.NeighbourMinesCount(row, column);
                var cellValue = neighbourMinesCount.ToString()[0];
                this.SetCellValue(row, column, cellValue);
            }

            return this.GetCellValue(row, column);
        }

        /// <summary>
        /// Counts the number of revealed cells in the grid.
        /// </summary>
        /// <returns>The number of revealed cells in the grid.</returns>
        public int RevealedCount()
        {
            int count = 0;
            foreach (var cell in this.grid)
            {
                if (cell.IsRevealed)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Reveals the mines in the grid.
        /// </summary>
        public void RevealMines()
        {
            foreach (var cell in this.grid)
            {
                if (cell.Value == '*')
                {
                    cell.Reveal();
                }
            }
        }

        /// <summary>
        /// Marks all cells in the grid which are not mines and are not revealed with the
        /// symbol <paramref name="marker"/>.
        /// </summary>
        /// <param name="marker">The symbol which will mark the cells.</param>
        public void MarkCell(char marker)
        {
            foreach (var cell in this.grid)
            {
                if ((cell.Value != '*') && (!cell.IsRevealed))
                {
                    cell.Value = marker;
                    cell.Reveal();
                }
            }
        }

        /// <summary>
        /// Transforms the grid into a string.
        /// </summary>
        /// <returns>String representation of the grid.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("   ");

            // Generates column numbers
            for (int i = 0; i < this.columnsCount; i++)
            {
                result.AppendFormat(" {0}", i);
            }

            result.Append(" \n");

            // Generates: '-----------------'
            result.Append("   ");
            result.Append('-', (this.columnsCount * 2) + 1);
            result.Append(" \n");

            for (int i = 0; i < this.rowsCount; i++)
            {
                // Generates row number.
                result.AppendFormat("{0} |", i);

                // Generate values in each row.
                for (int j = 0; j < this.columnsCount; j++)
                {
                    result.AppendFormat(" {0}", this.grid[i, j].GetCellValue);
                }

                result.Append(" |\n");
            }

            // Generates: '-----------------'
            result.Append("   ");
            result.Append('-', (this.columnsCount * 2) + 1);
            result.Append(" \n");

            return result.ToString();
        }

        /// <summary>
        /// Resets the grid.
        /// </summary>
        public void Reset()
        {
            this.Clear();
            this.Initialize();
        }

        /// <summary>
        /// Counts the number of mines which are neighbors of the cell with 
        /// coordinates <paramref name="row"/> and <paramref name="column"/>.
        /// </summary>
        /// <param name="row">The row of the cell.</param>
        /// <param name="column">The column of the cell.</param>
        /// <returns>The number of mines which are neighbors to the cell with
        /// coordinates <paramref name="row"/> and <paramref name="column"/>.</returns>
        private int NeighbourMinesCount(int row, int column)
        {
            if (!this.IsValidCell(row, column))
            {
                throw new InvalidCellException();
            }

            // Restrict the neigbour cell area.
            int minRow = (row - 1) < 0 ? row : row - 1; 
            int maxRow = (row + 1) >= this.rowsCount ? row : row + 1;
            int minColumn = (column - 1) < 0 ? column : column - 1;
            int maxColumn = (column + 1) >= this.columnsCount ? column : column + 1;

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

        /// <summary>
        /// Generates a list of unique random numbers.
        /// </summary>
        /// <param name="numbersCount">The length of the list.</param>
        /// <param name="maximalNumber">The maximal possible number which may occur in the list.</param>
        /// <returns>List of unique random number of length <paramref name="numbersCount"/>,
        /// each of which is less than <paramref name="maximalNumber"/>.</returns>
        private List<int> GenerateRandomNumbers(int numbersCount, int maximalNumber)
        {
            List<int> randomNumbers = new List<int>();
            for (int i = 0; i < numbersCount; i++)
            {
                int newRandomNumber = 0;
                do
                {
                    newRandomNumber = RandomNumberGenerator.Next(maximalNumber);
                }
                while (randomNumbers.Count(n => n == newRandomNumber) > 0);

                randomNumbers.Add(newRandomNumber);
            }

            return randomNumbers;
        }

        /// <summary>
        /// Initializes the grid.
        /// </summary>
        private void Initialize()
        {
            List<int> mineCoordinates = this.GenerateRandomNumbers(this.minesCount, this.rowsCount * this.columnsCount);

            // Fill mines.
            for (int i = 0; i < this.minesCount; i++)
            {
                int row = mineCoordinates[i] / this.columnsCount;
                int column = mineCoordinates[i] % this.columnsCount;
                this.SetCellValue(row, column, '*');
            }
        }

        /// <summary>
        /// Clears the grid.
        /// </summary>
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
    }
}
