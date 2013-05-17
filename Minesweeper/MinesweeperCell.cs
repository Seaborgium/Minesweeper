namespace MinesweeperProject
{
    using System;
    using System.Linq;

    public class MinesweeperCell
    {
        public const char EmptyCell = ' ';

        public MinesweeperCell()
        {
            this.Value = MinesweeperCell.EmptyCell;
            this.IsRevealed = false;
        }

        public MinesweeperCell(char val, bool revealed)
        {
            this.Value = val;
            this.IsRevealed = revealed;
        }

        public char Value { get; set; }

        public bool IsRevealed { get; private set; }

        public char GetCellValue
        {
            get
            {
                char result;
                result = this.IsRevealed ? this.Value : '?';
                return result;
            }
        }

        public void Reveal()
        {
            this.IsRevealed = true;
        }
    }
}