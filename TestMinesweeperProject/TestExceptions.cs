using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinesweeperProject;

namespace TestMinesweeperProject
{
    [TestClass]
    public class TestMinesweeperGame
    {
        [ExpectedException(typeof(InvalidCellException))]
        [TestMethod]
        public void Throw_InvalidCellException_WhenNoMessage()
        {
            throw new InvalidCellException();
        }

        [ExpectedException(typeof(InvalidCellException))]
        [TestMethod]
        public void Throw_InvalidCellException_WhenMessage()
        {
            throw new InvalidCellException("Error!");
        }

        [ExpectedException(typeof(IllegalMoveException))]
        [TestMethod]
        public void Throw_IllegalMoveException_WhenNoMessage()
        {
            throw new IllegalMoveException();
        }

        [ExpectedException(typeof(IllegalMoveException))]
        [TestMethod]
        public void Throw_IllegalMoveException_WhenMessage()
        {
            throw new IllegalMoveException("Error!");
        }

        [ExpectedException(typeof(CommandUnknownException))]
        [TestMethod]
        public void Throw_CommandUnknownException_WhenNoMessage()
        {
            throw new CommandUnknownException();
        }

        [ExpectedException(typeof(CommandUnknownException))]
        [TestMethod]
        public void Throw_CommandUnknownException_WhenMessage()
        {
            throw new CommandUnknownException("Error!");
        }
    }
}
