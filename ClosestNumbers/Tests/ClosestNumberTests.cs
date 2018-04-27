using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClosestNumbers.Tests
{
    public class ClosestNumberTests
    {
        /// <summary>
        /// Given a list of unsorted integers, array, find the pair of elements that have the smallest absolute difference between them.
        /// If there are multiple pairs, find them all.
        /// </summary>
        [Fact]
        public void SuccessTest()
        {
            var numbers = 10;
            var input = @"-20 -3916237 -357920 -3620601 7374819 -7330761 30 6246457 -6461594 266854";

            var inputList = input.Split(' ').Select(x => int.Parse(x)).ToList();

            var expectedOutput = @"-20 30";

            var actualOutput = ClosestNumbers.FindClosestNumbers(numbers, inputList);

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
