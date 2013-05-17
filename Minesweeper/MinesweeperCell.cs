namespace MinesweeperProject
{
    using System;
    using System.Linq;

    public class MinesweeperCell
    {
        /// <summary>
        /// Set default value for empty cell;
        /// </summary>
        public const char EmptyCell = ' ';

        /// <summary>
        /// Initialize empty instance of a cell.
        /// Its value is set to default empty
        /// and revealed is set to false.
        /// </summary>
        public MinesweeperCell()
        {
            this.Value = MinesweeperCell.EmptyCell;
            this.IsRevealed = false;
        }

        /// <summary>
        /// Initialize instance of a cell with parameters.
        /// </summary>
        public MinesweeperCell(char val, bool revealed)
        {
            this.Value = val;
            this.IsRevealed = revealed;
        }

        /// <summary>
        /// Set and get the value of the current cell
        /// </summary>
        public char Value { get; set; }

        /// <summary>
        /// Check if current cell is revealed
        /// </summary>
        public bool IsRevealed { get; private set; }


        /// <summary>
        /// If current cell is revealed, return its actual value else return '?'
        /// </summary>
        public char GetCellValue
        {
            get
            {
                char result;
                result = this.IsRevealed ? this.Value : '?';
                return result;
            }
        }

        /// <summary>
        /// Reveal the current cell and show its value
        /// </summary>
        public void Reveal()
        {
            this.IsRevealed = true;
        }
    }
}