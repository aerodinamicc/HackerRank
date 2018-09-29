using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextEditor.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ProgramTest_Succesful()
        {
            var input = @"1 abc
3 3
2 3
1 xy
3 2
4 
4 
3 1".Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();

            var expectedResult = @"c
y
a";
            var actualResult = Program.CommandHandler(input);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CommandHandler_LongerSuccessful()
        {
            var input = @"1 lchbfcjtfpsmjrqsdgci
3 19
1 cpcvixlm
1 apdjgjydvpbpvyiy
2 29
4
4
3 9
4
4".Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
            var expectedResult = @"c
f";
            var actualResult = Program.CommandHandler(input);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
