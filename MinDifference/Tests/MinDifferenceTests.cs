using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace MinDifference.Tests
{
    public class MinDifferenceTests
    {
        [Fact]
        public void SuccessTest()
        {
            var count = 4;
            var input = "2 5 3 1";
            var nums = input.Split(' ').Select(x => int.Parse(x)).ToList();
            var actualOutput = MinDifference.SwapNumbers(nums);

            var expectedOutput = 2;
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void SuccessTestCaseOne()
        {
            var count = 274;
            var input = File.ReadAllText("../../Files/testCase1.txt");
            var nums = input.Split(' ').Select(x => int.Parse(x)).ToList();
            var actualOutput = MinDifference.SwapNumbers(nums);

            var expectedOutput = 268;
            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
