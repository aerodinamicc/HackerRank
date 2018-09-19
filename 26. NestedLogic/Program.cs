using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26.NestedLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            var actualInput = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
            var expectedInput = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
            var actualReturn = new DateTime(actualInput[2], actualInput[1], actualInput[0]);
            var expectedReturn = new DateTime(expectedInput[2], expectedInput[1], expectedInput[0]);
            var fine = ComputeFine(actualReturn, expectedReturn);
            Console.WriteLine(fine);
        }

        public static int ComputeFine(DateTime actualReturn, DateTime expectedReturn)
        {
            var fine = 0;
            if (expectedReturn.Year < actualReturn.Year)
            {
                fine = 10000;
            }
            else if (expectedReturn.Year == actualReturn.Year && expectedReturn.Month < actualReturn.Month)
            {
                var delay = actualReturn.Month - expectedReturn.Month;
                fine = 500 * delay;
            }
            else if (expectedReturn.Year == actualReturn.Year && expectedReturn.Month == actualReturn.Month && expectedReturn.Day < actualReturn.Day)
            {
                var delay = actualReturn.Day - expectedReturn.Day;
                fine = 15 * delay;
            }

            return fine;
        }
    }
}
