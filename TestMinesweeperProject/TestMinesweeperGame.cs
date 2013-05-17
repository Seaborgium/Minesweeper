using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinesweeperProject;
using System.Text;

namespace TestMinesweeperProject
{
    [TestClass]
    public class TestMinesweeperGame
    {
        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void TestScoreboard_WhenNull_ShouldThrowException()
        {
            MinesweeperGame mineGame = new MinesweeperGame(10, 10, 5);
            mineGame.ScoreBoard = null;
            //string expected = null;
            //StringBuilder sb = new StringBuilder();

            //foreach (var item in mineGame.ScoreBoard)
            //{
            //    sb.Append(item);
            //}
            //string actual = sb.ToString();
        }

        //[TestMethod]
        //public void TestScoreboardIfValid()
        //{
        //    MinesweeperGame mineGame = new MinesweeperGame(10, 10, 5);
        //    mineGame.ScoreBoard = new List<ScoreRecord>( new ScoreRecord()
        //}
    }
}
