using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FindTheMedian.Tests
{
    public class FindTheMedianTests
    {
        [Fact]
        public void SuccessTest()
        {
            var count = 7;
            var numbers = @"0 1 2 4 6 5 3";

            var inputList = numbers.Split(' ').Select(x => int.Parse(x)).ToList();

            var expectedOutput = "3";

            var actualOutput = FindTheMedian.FindMedian(count, inputList);

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
