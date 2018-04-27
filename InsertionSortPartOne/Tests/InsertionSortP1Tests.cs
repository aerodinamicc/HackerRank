using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InsertionSortPartOne.Tests
{
    public class InsertionSortP1Tests
    {
        [Fact]
        public void SuccessTest()
        {
            var count = 5;
            var nums = @"2 4 6 8 3";

            var inputList = nums.Split(' ').Select(x => int.Parse(x)).ToList();

            var expectedOutput = @"2 4 6 8 8
2 4 6 6 8
2 4 4 6 8
2 3 4 6 8";

            var actualOutput = InsertionSortP1.Sort(inputList);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void SuccessTest_DifferentInput()
        {
            var count = 14;
            var nums = @"1 3 5 9 13 22 27 35 46 51 55 83 87 23";
            var inputList = nums.Split(' ').Select(x => int.Parse(x)).ToList();

            var expectedOutput = @"1 3 5 9 13 22 27 35 46 51 55 83 87 87
1 3 5 9 13 22 27 35 46 51 55 83 83 87
1 3 5 9 13 22 27 35 46 51 55 55 83 87
1 3 5 9 13 22 27 35 46 51 51 55 83 87
1 3 5 9 13 22 27 35 46 46 51 55 83 87
1 3 5 9 13 22 27 35 35 46 51 55 83 87
1 3 5 9 13 22 27 27 35 46 51 55 83 87
1 3 5 9 13 22 23 27 35 46 51 55 83 87";

            var actualOutput = InsertionSortP1.Sort(inputList);

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void SuccessTest_ThirdDifferentInput()
        {
            var count = 14;
            var nums = @"2 3 4 5 6 7 8 9 10 1";
            var inputList = nums.Split(' ').Select(x => int.Parse(x)).ToList();

            var expectedOutput = @"2 3 4 5 6 7 8 9 10 10
2 3 4 5 6 7 8 9 9 10
2 3 4 5 6 7 8 8 9 10
2 3 4 5 6 7 7 8 9 10
2 3 4 5 6 6 7 8 9 10
2 3 4 5 5 6 7 8 9 10
2 3 4 4 5 6 7 8 9 10
2 3 3 4 5 6 7 8 9 10
2 2 3 4 5 6 7 8 9 10
1 2 3 4 5 6 7 8 9 10";

            var actualOutput = InsertionSortP1.Sort(inputList);

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
