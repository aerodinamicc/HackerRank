using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseArrays.Tests
{
    [TestClass]
    public class FindOccurences_Tests
    {
        [TestMethod]
        public void FindOccurences_Short()
        {
            var strings = @"aba
baba
aba
xzxb".Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
            var queries = @"aba
xzxb
ab".Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
            var expectedOutput = @"2
1
0";
            var actualOutput = Program.FindOccurences(strings, queries);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void FindOccurences_Long()
        {
            var strings = @"abcde
sdaklfj
asdjf
na
basdn
sdaklfj
asdjf
na
asdjf
na
basdn
sdaklfj
asdjf".Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
            var queries = @"abcde
sdaklfj
asdjf
na
basdn".Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();

            var expectedOutput = @"1
3
4
3
2";
            var actualOutput = Program.FindOccurences(strings, queries);

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
