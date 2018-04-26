using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FullCountingSort.Tests
{
    public class CountingSortTests
    {
        /// <summary>
        /// In this challenge you need to print the string that accompanies each integer in a list sorted by the integers. If two strings are associated with the same integer,
        /// they must be printed in their original order so your sorting algorithm should be stable. There is one other twist. The first half of the strings encountered in the
        /// inputs are to be replaced with the character "-".
        /// </summary>
        [Fact]
        public void SuccessTest()
        {
            var lines = 20;
            var input = @"0 ab
6 cd
0 ef
6 gh
4 ij
0 ab
6 cd
0 ef
6 gh
0 ij
4 that
3 be
0 to
1 be
5 question
1 or
2 not
4 is
2 to
4 the";
            var inputArray = input.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();

            var expectedOutput = "- - - - - to be or not to be - that is the question - - - -";

            var actualOutput = CountingSort.SortInput(lines, inputArray);

            Assert.Equal(expectedOutput, actualOutput);
        }
    }
}
