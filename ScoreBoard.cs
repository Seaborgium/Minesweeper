using System;
using System.Linq;

namespace MinesweeperProject
{
    class ScoreRecord : IComparable
    {
        private string playerName;
        private int score;

        public ScoreRecord(string playerName, int score)
        {
            this.playerName = playerName;
            this.score = score;
        }

        public string PlayerName
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

        public int CompareTo(Object obj)
        {
            if (!(obj is ScoreRecord))
            {
                throw
                    new ArgumentException("Compare Object is not ScoreRecord!");
            }

            return -1 * this.score.CompareTo(((ScoreRecord)obj).score);
        }


    }

}
