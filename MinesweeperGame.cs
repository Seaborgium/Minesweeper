namespace MinesweeperProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Creates new Minesweeper game.
    /// </summary>
    class MinesweeperGame
    {
        /// <summary>
        /// Represents the grid in Minesweeper game.
        /// </summary>
        private readonly MinesweeperGrid grid;

        /// <summary>
        /// Holds the score of current player.
        /// </summary>
        private int score;

        /// <summary>
        /// Represents the scoreboard in Minesweeper game.
        /// Holds the score of all players in current game.
        /// </summary>
        private List<ScoreRecord> scoreBoard;

        /// <summary>
        /// Initializes a new instance of the <see cref="MinesweeperGame"/> class.
        /// The Minesweeper game will contain grid.
        /// The grid will have <paramref name="rows"/> rows
        /// and <paramref name="columns"/> columns. The grid will contain
        /// <paramref name="minesCount"/> mines.
        /// </summary>
        /// <param name="rows">The number of rows in the grid.</param>
        /// <param name="columns">The number of columns in the grid.</param>
        /// <param name="minesCount">The number of mines in the grid.</param>
        public MinesweeperGame(int rows, int columns, int minesCount)
        {
            this.grid = new MinesweeperGrid(rows, columns, minesCount);
            this.scoreBoard = new List<ScoreRecord>();
        }

        /// <summary>
        /// Gets or sets the ScoreRecords of the players in ScoreBoard. 
        /// </summary>
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

        /// <summary>
        /// Gets or sets the score of current player.
        /// </summary>
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

        /// <summary>
        /// Gets the grid of the Minesweeper game.
        /// </summary>
        public MinesweeperGrid Grid
        {
            get
            {
                return this.grid;
            }
        }

        /// <summary>
        /// Resets the grid and set the score = 0.
        /// </summary>
        public virtual void Start()
        {
            this.Grid.Reset();
            this.Score = 0;
        }
    }
}
