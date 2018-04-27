using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheMedian
{
    class FindTheMedian
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();

            var result = FindMedian(count, numbers);

            Console.WriteLine(result);
        }

        public static string FindMedian(int count, List<int> numbers)
        {
            var median = int.MaxValue;

            if (count>1)
            {
                median = count / 2;
            }
            else
            {
                median = count;
            }

            numbers.Sort();

            return numbers[median].ToString();
        }
    }
}
