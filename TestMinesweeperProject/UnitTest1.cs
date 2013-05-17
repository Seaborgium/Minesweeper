using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinesweeperProject;
using System.Text;

namespace TestMinesweeperProject
{
    [TestClass]
    public class UnitTest1
    {
        [ExpectedException(typeof(NullReferenceException))]
        [TestMethod]
        public void TestScoreboardIfNull()
        {
            MinesweeperGame mineGame = new MinesweeperGame(10, 10, 5);
            mineGame.ScoreBoard = null;
            string expected = null;
            StringBuilder sb = new StringBuilder();

            foreach (var item in mineGame.ScoreBoard)
            {
                sb.Append(item);
            }
            string actual = sb.ToString();

            Assert.IsNull(actual);
        }
    }
}
