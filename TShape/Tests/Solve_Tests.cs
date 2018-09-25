using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TShape.Tests
{
    [TestClass]
    public class Solve_Tests
    {
        [TestMethod]
        public void SolveSuccessful_LongInput()
        {
            var input = @"0 1
1 1
2 1
2 2
2 0
0 2
1 2
3 2
1 1
1 0
0 2
0 1
0 0
1 1
2 2".Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();

            var expectedOutput = @"Yes
No
No";
            var actualOutput = new StringBuilder();

            var iterations = 3;
            var currIndex = 0;

            for (int tItr = 0; tItr < iterations; tItr++)
            {
                var rows = new List<int>();
                var cols = new List<int>();

                for (int i = 0; i < 5; i++, currIndex++)
                {
                    var point = input[currIndex].TrimEnd().Split(' ').Select(x => int.Parse(x)).ToList();
                    rows.Add(point[0]);
                    cols.Add(point[1]);
                }

                string result = Program.Solve(rows, cols);

                actualOutput.AppendLine(result);
            }
            actualOutput.Length -= 2;
            Assert.AreEqual(expectedOutput, actualOutput.ToString());
        }

        [TestMethod]
        public void SolveSuccessful_ShortInput()
        {
            var input = @"7 5
8 5
6 5
7 6
7 7".Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();

            var expectedOutput = @"Yes";
            var actualOutput = new StringBuilder();

            var rows = new List<int>();
            var cols = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                var point = input[i].TrimEnd().Split(' ').Select(x => int.Parse(x)).ToList();
                rows.Add(point[0]);
                cols.Add(point[1]);
            }

            string result = Program.Solve(rows, cols);

            actualOutput.Append(result);

            Assert.AreEqual(expectedOutput, actualOutput.ToString());
        }
    }
}
