using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinesweeperProject;
using System.Collections.Generic;

namespace TestMinesweeperProject
{
    [TestClass]
    public class TestExceptions
    {
        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void Scoreboard_WhenNull_ShouldThrowException()
        {
            MinesweeperGame mineGame = new MinesweeperGame(10, 10, 5);
            mineGame.ScoreBoard = null;
        }

        [TestMethod]
        public void Scoreboard_WhenValidScoreBoard()
        {
            MinesweeperGame mineswGame = new MinesweeperGame(10, 10, 5);
            ScoreRecord player1 = new ScoreRecord("Ivan", 4);
            ScoreRecord player2 = new ScoreRecord("Ivan", 5);
            List<ScoreRecord> board = new List<ScoreRecord>() { player1, player2 };

            mineswGame.ScoreBoard = board;
            int actual = mineswGame.ScoreBoard.Count;
            int expected = 2;

            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void Score_WhenLessThan0_ShouldThrowException()
        {
            MinesweeperGame mineswGame = new MinesweeperGame(10, 10, 5);
            mineswGame.Score = -1;
        }

        [TestMethod]
        public void Score_WhenValid_5()
        {
            MinesweeperGame mineswGame = new MinesweeperGame(10, 10, 5);
            mineswGame.Score = 5;
            int actual = mineswGame.Score;
            int expected = 5;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Grid_Getter()
        {
            MinesweeperGame mineGame = new MinesweeperGame(10, 10, 5);
            Assert.IsNotNull(mineGame.Grid);
        }
    }
}
