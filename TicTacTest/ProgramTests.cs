using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;

namespace TicTacToe.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void ConvertToArrayLocationTestLow()
        {
            Game.Board b = new Game.Board(new ConsoleWrapper());
            int[] expected = new int[] { 0, 1 };

            int[] actual = b.ConvertToArrayLocation("2");

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertToArrayLocationTestHigh()
        {
            Game.Board b = new Game.Board(new ConsoleWrapper());
            int[] expected = new int[] { 2, 2 };

            int[] actual = b.ConvertToArrayLocation("9");

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertToArrayLocationTestNonInt()
        {
            //This test is here to show you invalid input is not handled
            Game.Board b = new Game.Board(new ConsoleWrapper());
            int[] expected = null;

            int[] actual = b.ConvertToArrayLocation("a");

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertToArrayLocationTestOutOfBounds()
        {
            //What should happen when the user enters an invalid number (out of bounds of the map)?
            Game.Board b = new Game.Board(new ConsoleWrapper());
            int[] expected = null;

            int[] actual = b.ConvertToArrayLocation("15");

           CollectionAssert.AreEqual(expected, actual);
        }
    }
}