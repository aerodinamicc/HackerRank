using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftRotation.Tests
{
    [TestClass]
    public class Rotation_Tests
    {
        [TestMethod]
        public void Rotation_Successful()
        {
            var input = "1 2 3 4 5".Split(' ').Select(x => int.Parse(x)).ToList();
            var n = 5;
            var d = 4;

            var expectedResult = "5 1 2 3 4";

            var actualResult = Program.Rotation(n, d, input);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
