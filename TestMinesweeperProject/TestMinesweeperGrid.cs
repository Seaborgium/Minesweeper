using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinesweeperProject;

namespace TestMinesweeperProject
{
    [TestClass]
    public class TestMinesweeperGrid
    {
        [TestMethod]
        public void Constructor_TestIfInitializesEmptyCells()
        {
            int gridRows = 10, gridCols = 10, minesCount = 4;
            MinesweeperGrid grid = new MinesweeperGrid(gridRows, gridCols, minesCount);

            bool existsNonEmptyCell = false;
            for (int i = 0; i < gridRows; i++)
            {
                for (int j = 0; j < gridCols; j++)
                {
                    if (grid.GetCellValue(i, j) != MinesweeperCell.EmptyCell)
                    {
                        existsNonEmptyCell = true;
                        break;
                    }
                }

                if (existsNonEmptyCell)
                {
                    break;
                }
            }

            Assert.IsFalse(existsNonEmptyCell);
        }

        [TestMethod]
        public void IsValidCell_TestWithInvalidCellPosition_ShouldReturnFalse()
        {
            int gridRows = 10, gridCols = 10, minesCount = 4;
            MinesweeperGrid grid = new MinesweeperGrid(gridRows, gridCols, minesCount);

            Assert.IsFalse(grid.IsValidCell(10, 4));
        }

        [TestMethod]
        public void IsValidCell_TestWithValidCellPosition_ShouldReturnTrue()
        {
            int gridRows = 10, gridCols = 10, minesCount = 4;
            MinesweeperGrid grid = new MinesweeperGrid(gridRows, gridCols, minesCount);

            Assert.IsTrue(grid.IsValidCell(8, 4));
        }

        [TestMethod]
        public void SetCellValue_TestWithValidCellPosition()
        {
            int gridRows = 10, gridCols = 10, minesCount = 4;
            MinesweeperGrid grid = new MinesweeperGrid(gridRows, gridCols, minesCount);
            grid.SetCellValue(3, 4, '+');

            Assert.AreEqual('+', grid.GetCellValue(3, 4));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCellException))]
        public void SetCellValue_TestWithInvalidCellPosition_ShouldThrowException()
        {
            int gridRows = 10, gridCols = 10, minesCount = 4;
            MinesweeperGrid grid = new MinesweeperGrid(gridRows, gridCols, minesCount);
            grid.SetCellValue(-1, 5, '+');
        }

        [TestMethod]
        public void GetCellValue_TestWithValidCellPosition()
        {
            int gridRows = 10, gridCols = 10, minesCount = 4;
            MinesweeperGrid grid = new MinesweeperGrid(gridRows, gridCols, minesCount);

            grid.SetCellValue(1, 1, '+');
            Assert.AreEqual('+', grid.GetCellValue(1, 1));

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCellException))]
        public void GetCellValue_TestWithInvalidCellPosition_ShouldThrowException()
        {
            int gridRows = 10, gridCols = 10, minesCount = 4;
            MinesweeperGrid grid = new MinesweeperGrid(gridRows, gridCols, minesCount);

            grid.SetCellValue(10, 2, '+');
        }

        [TestMethod]
        public void GetCell_TestWithValidCellPosition()
        {
            int gridRows = 10, gridCols = 10, minesCount = 4;
            MinesweeperGrid grid = new MinesweeperGrid(gridRows, gridCols, minesCount);
            MinesweeperCell cell = grid.GetCell(1, 1);

            Assert.AreEqual(MinesweeperCell.EmptyCell, cell.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCellException))]
        public void GetCell_TestWithInvalidCellPosition_ShouldThrowException()
        {
            int gridRows = 10, gridCols = 10, minesCount = 4;
            MinesweeperGrid grid = new MinesweeperGrid(gridRows, gridCols, minesCount);
            MinesweeperCell cell = grid.GetCell(10, 1);
        }

        [TestMethod]
        public void RevealCell_WhenTheCellIsNotMine()
        {
            int gridRows = 10, gridCols = 10, minesCount = 4;
            MinesweeperGrid grid = new MinesweeperGrid(gridRows, gridCols, minesCount);

            grid.SetCellValue(0, 0, '*');
            grid.SetCellValue(0, 1, '*');
            grid.SetCellValue(1, 0, '*');
            grid.SetCellValue(1, 2, '*');

            char revealedValue = grid.RevealCell(1, 1);
            Assert.AreEqual('4', revealedValue);
        }

        [TestMethod]
        public void RevealCell_WhenTheCellIsMine()
        {
            int gridRows = 10, gridCols = 10, minesCount = 4;
            MinesweeperGrid grid = new MinesweeperGrid(gridRows, gridCols, minesCount);

            grid.SetCellValue(1, 1, '*');

            char revealedValue = grid.RevealCell(1, 1);
            Assert.AreEqual('*', revealedValue);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCellException))]
        public void RevealCell_WhenTheCellIsAlreadyRevealed_ShouldThrowException()
        {
            int gridRows = 10, gridCols = 10, minesCount = 4;
            MinesweeperGrid grid = new MinesweeperGrid(gridRows, gridCols, minesCount);

            grid.SetCellValue(1, 1, '*');
            grid.RevealCell(1, 1);
            grid.RevealCell(1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCellException))]
        public void RevealCell_WhenTheCellIsInvalid_ShouldThrowException()
        {
            int gridRows = 10, gridCols = 10, minesCount = 4;
            MinesweeperGrid grid = new MinesweeperGrid(gridRows, gridCols, minesCount);

            grid.SetCellValue(1, 1, '*');
            grid.RevealCell(1, 10);
        }

        [TestMethod]
        public void RevealedCount_TestWhenSomeMinesAreRevealed()
        {
            int gridRows = 10, gridCols = 10, minesCount = 4;
            MinesweeperGrid grid = new MinesweeperGrid(gridRows, gridCols, minesCount);

            grid.SetCellValue(0, 0, '*');
            grid.SetCellValue(0, 1, '*');
            grid.SetCellValue(1, 0, '*');
            grid.SetCellValue(1, 2, '*');

            grid.RevealCell(0, 0);
            grid.RevealCell(0, 1);

            Assert.AreEqual(2, grid.RevealedCount());
        }

        [TestMethod]
        public void RevealMines_WhenTheGridContainsMines()
        {
            int gridRows = 10, gridCols = 10, minesCount = 4;
            MinesweeperGrid grid = new MinesweeperGrid(gridRows, gridCols, minesCount);

            grid.SetCellValue(0, 0, '*');
            grid.SetCellValue(0, 1, '*');
            grid.SetCellValue(1, 0, '*');
            grid.SetCellValue(1, 2, '*');

            grid.RevealMines();
            Assert.AreEqual(4, grid.RevealedCount());
        }

        [TestMethod]
        public void MarkCell_WhenThereAreUnrevealedCells()
        {
            int gridRows = 10, gridCols = 10, minesCount = 4;
            MinesweeperGrid grid = new MinesweeperGrid(gridRows, gridCols, minesCount);

            grid.SetCellValue(0, 0, '*');
            grid.SetCellValue(0, 1, '*');
            grid.SetCellValue(1, 0, '*');
            grid.SetCellValue(1, 2, '-');
            grid.MarkCell('+');
            
            Assert.AreEqual('+', grid.GetCellValue(1, 2));
        }

        [TestMethod]
        public void Reset_WhenTheGridHasData()
        {
            int gridRows = 10, gridCols = 10, minesCount = 4;
            MinesweeperGrid grid = new MinesweeperGrid(gridRows, gridCols, minesCount);

            grid.SetCellValue(0, 0, '*');
            grid.SetCellValue(0, 1, '*');
            grid.SetCellValue(1, 0, '*');
            grid.SetCellValue(1, 2, '*');

            grid.Reset();
            grid.RevealMines();

            Assert.AreEqual(4, grid.RevealedCount());
        }
    }
}
