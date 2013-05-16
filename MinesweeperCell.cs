namespace MinesweeperProject
{
    using System;
    using System.Linq;

    public class MinesweeperCell
    {
        public MinesweeperCell()
        {
            this.Value = ' ';
            this.IsRevealed = false;
        }

        public MinesweeperCell(char val, bool revealed)
        {
            this.Value = val;
            this.IsRevealed = revealed;
        }

        public char Value { get; set; }

        public bool IsRevealed { get; private set; }

        public char VisibleValue
        {
            get
            {
                char result;

                if (this.IsRevealed == false)
                {
                    result = '?';
                }
                else
                {
                    result = this.Value;
                }

                return result;
            }
        }

        public void Reveal()
        {
            this.IsRevealed = true;
        }
    }
}