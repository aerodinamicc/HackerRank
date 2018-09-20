using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OderingGmails.Tests
{
    [TestClass]
    public class SortNames_Tests
    {
        [TestMethod]
        public void SortNames_Successful()
        {
            var list = @"riya riya@gmail.com
julia julia@julia.me
julia sjulia@gmail.com
julia julia@gmail.com
samantha samantha@gmail.com
tanya tanya@gmail.com
riya ariya@gmail.com
julia bjulia@julia.me
julia csjulia@gmail.com
julia djulia@gmail.com
samantha esamantha@gmail.com
tanya ftanya@gmail.com
riya riya@live.com
julia julia@live.com
julia sjulia@live.com
julia julia@live.com
samantha samantha@live.com
tanya tanya@live.com
riya ariya@live.com
julia bjulia@live.com
julia csjulia@live.com
julia djulia@live.com
samantha esamantha @live.com
tanya ftanya@live.com
riya gmail@riya.com
priya priya@gmail.com
preeti preeti@gmail.com
alice alice@alicegmail.com
alice alice@gmail.com
alice gmail.alice@gmail.com".Split(new string[] { "\r\n"}, StringSplitOptions.None).ToList();

            var expectedOrder = @"alice
alice
julia
julia
julia
julia
preeti
priya
riya
riya
samantha
samantha
tanya
tanya".Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();

            var actualOrder = Program.SortNames(list);

            Assert.AreEqual(expectedOrder.Count, actualOrder.Count);

            for (int i = 0; i < expectedOrder.Count; i++)
            {
                Assert.AreEqual(expectedOrder[i], actualOrder[i]);
            }
        }
    }
}
