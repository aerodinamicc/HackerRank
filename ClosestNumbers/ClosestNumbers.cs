using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestNumbers
{
    class ClosestNumbers
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var inputList = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();

            var result = FindClosestNumbers(count, inputList);

            Console.WriteLine(result);
        }

        public static string FindClosestNumbers(int numbers, List<int> inputArray)
        {
            inputArray.Sort();
            var minDiff = int.MaxValue;
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < inputArray.Count - 1; i++)
            {
                var diff = Math.Abs(inputArray[i] - inputArray[i + 1]);

                if (diff > minDiff)
                {
                    continue;
                }

                if (diff < minDiff)
                {
                    builder.Clear();
                    builder.Append(inputArray[i] + " " + inputArray[i + 1] + " ");
                    minDiff = diff;
                }
                else if (diff == minDiff)
                {
                    builder.Append(inputArray[i] + " " + inputArray[i + 1] + " ");
                }
            }

            builder.Length -= 1;

            return builder.ToString();
        }
    }
}
