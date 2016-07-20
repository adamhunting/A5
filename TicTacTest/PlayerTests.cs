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
    public class PlayerTests
    {
        [TestMethod()]
        public void GreetTest()
        {
            Player p = new Player() { Name = "Bob" };
            string expected = "Hello Bob";

            string actual = p.Greet();

            Assert.AreEqual(expected, actual);
            
        }

        public void InitializeTest()
        {
            Player p = new Player();

            //Initialize used to call for user input in the console
            //now it asks the passed IStringGetter instance for a string instead.
            //We hardcode "Bob" here to mimic an end user typing "Bob" in the console.
            p.Initialize(new MockALivePerson() { ToReturn = "Bob" });

            Assert.AreEqual("Bob", p.Name);

        }

        /// <summary>
        /// This class will act as our input mechanism, behaving
        /// just like a user would when the library code asks
        /// for text input.  ToReturn is a property that allows
        /// each test to specify what "text" will be entered 
        /// by our mocked user.
        /// 
        /// This class is included in the test .cs file instead of a 
        /// separate file for convenience, and to avoid polluting other
        /// classes with Mocks that serve a limited purpose
        /// </summary>
        private class MockALivePerson : IStringGetter
        {

            public string ToReturn { get; set; }

            public string GetInput()
            {
                return ToReturn;
            }
        }
    }
}