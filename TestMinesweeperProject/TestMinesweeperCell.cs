using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinesweeperProject;

namespace TestMinesweeperProject
{
    [TestClass]
    public class TestMinesweeperCell
    {
         MinesweeperCell emptyCell = new MinesweeperCell();

        [TestMethod]
        public void TestCell_Empty_Constructor_IsRevealed()
        {
            Assert.AreEqual(false, emptyCell.IsRevealed);
        }

        [TestMethod]
        public void TestCell_Empty_Constructor_Value()
        {
            Assert.AreEqual(' ', emptyCell.Value);
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
            emptyCell.Value = 'A';

            Assert.AreEqual('A', emptyCell.Value);
        }

        [TestMethod]
        public void TestCellValue_Reveal()
        {
            MinesweeperCell cell = new MinesweeperCell('A', false);
            cell.Reveal();
            Assert.AreEqual(true, cell.IsRevealed);
        }

        [TestMethod]
        public void TestGetCellValue_When_Revealed()
        {
            MinesweeperCell cell = new MinesweeperCell('A', true);
            Assert.AreEqual('A', cell.GetCellValue);
        }

        [TestMethod]
        public void TestGetCellValue_When_Not_Revealed()
        {
            MinesweeperCell cell = new MinesweeperCell('A', false);
            Assert.AreEqual('?', cell.GetCellValue);
        }
    }
}
