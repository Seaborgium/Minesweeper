namespace MinesweeperProject
{
    using System;
    using System.Linq;

    public class ScoreRecord : IComparable
    {
        public ScoreRecord(string playerName, int score)
        {
            this.PlayerName = playerName;
            this.Score = score;
        }

        public string PlayerName { get; private set; }

        public int Score { get; private set; }

        public int CompareTo(Object obj)
        {
            if (!(obj is ScoreRecord))
            {
                throw
                new ArgumentException("Compared Object is not ScoreRecord!");
            }
            ScoreRecord comparedScore = ((ScoreRecord)obj);
            int compareResult = -1 * this.Score.CompareTo(comparedScore.Score);
            return compareResult;
        }
    }
}