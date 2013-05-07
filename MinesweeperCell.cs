using System;
using System.Linq;

namespace MinesweeperProject
{
    // Testing git
    public class MinesweeperCell
    {
        private char val = '?';
        private bool revealed = false;

        //constructors
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

        //properties
        public char VisibleValue
        {
            get
            {
                char result;

                if (this.revealed == false)// if not revealed then return ? else actual value
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

        //methods
        public void Reveal()
        {
            this.Revealed = true;
        }
    }
}