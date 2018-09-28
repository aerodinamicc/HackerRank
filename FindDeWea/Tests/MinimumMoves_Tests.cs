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
            char[,] array = new char[3, 3]
            {
                {'.', '.', ',' },
                {'.', 'X', ',' },
                {'.', '.', ',' }
            };

            var startP = new Point(0, 0);
            var endP = new Point(1, 2);

            var expectedMoves = 2;
            var actualMoves = Solution.BFS(array, startP, endP);

            Assert.AreEqual(expectedMoves, actualMoves);
        }
    }
}
