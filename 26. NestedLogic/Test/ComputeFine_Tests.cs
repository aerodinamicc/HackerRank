using System;
using Xunit;

namespace _26.NestedLogic
{
    public class ComputeFine_Tests
    {
        [Fact]
        public void ComputeFine_Successful()
        {
            var expectedReturn = new DateTime(2015, 6, 6);
            var actualReturn = new DateTime(2015, 6, 9);
            var expectedFine = 45;

            var computedFine = Program.ComputeFine(actualReturn, expectedReturn);

            Assert.Equal(expectedFine, computedFine);
        }
    }
}
