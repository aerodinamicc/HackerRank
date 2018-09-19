using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BusStops.Tests
{
    public class StreetTests
    {
        [Fact]
        public void SuccessTest()
        {
            /*
             * 4
               0 10 40 100
               20 10
               3
               0 0 4
               15 10 1
               40 2 16
             */
            var stops = new Double[] {0, 10, 40, 100};
            var busSpeed = 10;
            var busFreq = 20;
            var people = new List<string>
            {
                "0 0 4",
                "15 10 1",
                "40 2 16"
            };
            var expectedOutput = @"10.0000000000
30.0000000000
5.7500000000";

            var actualOutput = Street.MinimumTimeToEnd(stops, busSpeed, busFreq, people);
            actualOutput.Length -= 2;
            Assert.Equal(expectedOutput, actualOutput.ToString());
        }
    }
}
