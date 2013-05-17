using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinesweeperProject;

namespace TestMinesweeperProject
{
    [TestClass]
    public class TestMinesweeperCell
    {
        [TestMethod]
        public void TestCell_Empty_Constructor_IsRevealed()
        {
            MinesweeperCell cell = new MinesweeperCell();

            Assert.AreEqual(false, cell.IsRevealed);
        }

        [TestMethod]
        public void TestCell_Empty_Constructor_Value()
        {
            MinesweeperCell cell = new MinesweeperCell();

            Assert.AreEqual(' ', cell.Value);
        }

        [TestMethod]
        public void TestCell_Constructor_With_Params_Value()
        {
            MinesweeperCell cell = new MinesweeperCell('A', true);

            Assert.AreEqual('A', cell.Value);
        }

        [TestMethod]
        public void TestCell_Constructor_With_Params_IsRevealed()
        {
            MinesweeperCell cell = new MinesweeperCell('A', true);

            Assert.AreEqual(true, cell.IsRevealed);
        }

        [TestMethod]
        public void TestCellValue_Setter_Getter()
        {
            MinesweeperCell cell = new MinesweeperCell();
            cell.Value = 'A';

            Assert.AreEqual('A', cell.Value);
        }

        [TestMethod]
        public void TestIsRevealed_Getter()
        {

        }
    }
}
