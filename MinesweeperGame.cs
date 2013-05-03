namespace MinesweeperProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MinesweeperGame
    {
        private readonly MinesweeperGrid grid;
        private int score;
        private List<ScoreRecord> scoreBoard;        

        public MinesweeperGame(int rows, int columns, int minesCount)
        {
            this.grid = new MinesweeperGrid(rows, columns, minesCount);
            this.scoreBoard = new List<ScoreRecord>();
        }

        public List<ScoreRecord> ScoreBoard
        {
            get
            {
                return this.scoreBoard;
            }

            set
            {
                if (value != null)
                {
                    this.scoreBoard = new List<ScoreRecord>();

                    foreach (ScoreRecord scoreRecord in value)
                    {
                        this.scoreBoard.Add(scoreRecord);
                    }
                }
                else
                {
                    this.scoreBoard = null;
                }
            }
        }

        public int Score 
        { 
            get
            {
                return this.score;
            } 

            set
            {
                if (this.score < 0)
                {
                    throw new ArgumentOutOfRangeException("The score cannot be less than 0!");
                }

                this.score = value;
            } 
        }

        public MinesweeperGrid Grid
        {
            get
            {
                return this.grid;
            }
        } 

        public virtual void Start()
        {
            this.Grid.Reset();
            this.Score = 0;
        }
    }
}