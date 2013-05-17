namespace MinesweeperProject
{
    using System;
    using System.Linq;

    /// <summary>
    /// Initialize current player's score
    /// </summary>
    public class ScoreRecord : IComparable
    {
        /// <summary>
        /// Initializes new instance of Score record
        /// </summary>
        /// <param name="playerName">Handles player's name</param>
        /// <param name="score">Handles player's score</param>
        public ScoreRecord(string playerName, int score)
        {
            this.PlayerName = playerName;
            this.Score = score;
        }

        /// <summary>
        /// Holds Player's name. Can be set only through constructor.
        /// </summary>
        public string PlayerName { get; private set; }

        /// <summary>
        /// Holds Player's name. Can be set only through constructor.
        /// </summary>
        public int Score { get; private set; }

        /// <summary>
        /// Functionality to compare different objects of type ScoreRecord
        /// </summary>
        public int CompareTo(object obj)
        {
            if (!(obj is ScoreRecord))
            {
                throw
                new ArgumentException("Compared Object is not ScoreRecord!");
            }

            ScoreRecord comparedScore = (ScoreRecord)obj;
            int compareResult = -1 * this.Score.CompareTo(comparedScore.Score);
            return compareResult;
        }
    }
}