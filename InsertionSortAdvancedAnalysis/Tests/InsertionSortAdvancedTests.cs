using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InsertionSortAdvancedAnalysis.Tests
{
    public class InsertionSortAdvancedTests
    {
        [Fact]
        public void Success_Test()
        {
            var iterations = 2;
            var nums = 5;
            var input = @"1 1 1 2 2 2 1 3 1 2";
            var inputList = input.Split(' ').Select(x => int.Parse(x)).ToList();
            var expectedOutput = @"0
4";
            var actualOutput = new StringBuilder();

            for (int i = 0; i < iterations; i++)
            {
                var inputLine = inputList.Skip(i * nums).Take(nums).ToList();
                var result = InsertionSortAdvanced.CountMoves(inputLine);
                if (i != iterations)
                {
                    actualOutput.AppendLine(result);
                }
                else
                {
                    actualOutput.Append(result);
                }
            }

            actualOutput.Length -= 2;

            Assert.Equal(expectedOutput, actualOutput.ToString());
        }
    }
}
