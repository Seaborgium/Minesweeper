namespace MinesweeperProject
{
    using System;
    using System.Linq;

    public class MinesweeperCell
    {
        private char val = '?';
        private bool revealed = false;

        public MinesweeperCell(char val, bool revealed)
        {
            this.Value = val;
            this.Revealed = revealed;
        }

        public MinesweeperCell()
        {
            this.Value = ' ';
            this.Revealed = false;
        }

        public char VisibleValue
        {
            get
            {
                char result;

                if (this.revealed == false)
                {
                    result = '?';
                }
                else
                {
                    result = this.val;
                }

                return result;
            }
        }

        public char Value
        { 
            get
            {
                return this.val;
            }

            set
            {
                this.val = value;
            }
        }

        public bool Revealed 
        { 
            get
            {
                return this.revealed;
            }

            set
            {
                this.revealed = value;
            }
        }

        public void Reveal()
        {
            this.Revealed = true;
        }
    }
}