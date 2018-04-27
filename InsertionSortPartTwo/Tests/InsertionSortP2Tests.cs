using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InsertionSortPartTwo.Tests
{
    public class InsertionSortP2Tests
    {
        [Fact]
        public void Success_Tests()
        {
            var count = 6;
            var nums = @"1 4 3 5 6 2";

            var inputList = nums.Split(' ').Select(x => int.Parse(x)).ToList();

            var expectedOutput = @"1 4 3 5 6 2
1 3 4 5 6 2
1 3 4 5 6 2
1 3 4 5 6 2
1 2 3 4 5 6";

            var actualOutput = InsertionSortP2.Sort(inputList);

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
