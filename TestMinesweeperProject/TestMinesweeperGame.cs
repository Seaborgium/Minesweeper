using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinesweeperProject;
using System.Text;
using System.Collections.Generic;

namespace TestMinesweeperProject
{
    [TestClass]
    public class TestMinesweeperGame
    {
        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void Scoreboard_WhenNull_ShouldThrowException()
        {
            MinesweeperGame mineGame = new MinesweeperGame(10, 10, 5);
            mineGame.ScoreBoard = null;
        }

        [TestMethod]
        public void Scoreboard_WhenValidValue()
        {
            MinesweeperGame mineswGame = new MinesweeperGame(10, 10, 5);
            ScoreRecord record = new ScoreRecord("Ivan", 4);
            mineswGame.ScoreBoard.Add(record);
            int actual = mineswGame.ScoreBoard.Count;
            int expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void Score_WhenLessThan0_ShouldThrowException()
        {
            MinesweeperGame mineswGame = new MinesweeperGame(10, 10, 5);
            mineswGame.Score = -1;
        }
    }
}
