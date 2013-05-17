using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinesweeperProject;

namespace TestMinesweeperProject
{
    [TestClass]
    public class TestScoreRecord
    {
        public ScoreRecord PlayerScore = new ScoreRecord("Test Name", 20);

        [TestMethod]
        public void TestScore_Playername_Getter()
        {
            Assert.AreEqual("Test Name", PlayerScore.PlayerName);
        }

        [TestMethod]
        public void TestScore_Score_Getter()
        {
            Assert.AreEqual(20, PlayerScore.Score);
        }

        [TestMethod]
        public void TestScore_CompareTo_Equal()
        {
            ScoreRecord otherScore = new ScoreRecord("Other Name", 20);
            
            Assert.AreEqual(0, PlayerScore.CompareTo(otherScore));
        }

        [TestMethod]
        public void TestScore_CompareTo_Less()
        {
            ScoreRecord otherScore = new ScoreRecord("Other Name", 10);

            Assert.AreEqual(-1, PlayerScore.CompareTo(otherScore));
        }

        [TestMethod]
        public void TestScore_CompareTo_More()
        {
            ScoreRecord otherScore = new ScoreRecord("Other Name", 50);

            Assert.AreEqual(1, PlayerScore.CompareTo(otherScore));
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestScore_CompareTo_Exceptions()
        {
            int otherScore = 2;

            Assert.AreEqual(0, PlayerScore.CompareTo(otherScore));
        }
    }
}
