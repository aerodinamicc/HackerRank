using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindDeWea.Tests
{
    [TestClass]
    public class MinimumMoves_Tests
    {
        [TestMethod]
        public void MinimumMoves_Successful()
        {
            string[,] array = new string[3, 3]
            {
                {".", ".", "," },
                {".", "X", "," },
                {".", ".", "," }
            };

            int startX = 0;
            int startY = 0;
            int goalX = 1;
            int goalY = 2;

            var expectedMoves = 2;
            var actualMoves = Program.minimumMoves(array, startX, startY, goalX, goalY);

            Assert.AreEqual(expectedMoves, actualMoves);
        }
    }
}
