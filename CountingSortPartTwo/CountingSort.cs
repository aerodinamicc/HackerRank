using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingSortPartTwo
{
    class CountingSort
    {
        public static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

            var result = Sort(count, numbers);

            Console.WriteLine(result);
        }

        public static string Sort(int count, int[] numbers)
        {
            var sortedArray = new int[100];

            foreach (var n in numbers)
            {
                sortedArray[n] += 1;
            }

            StringBuilder builder = new StringBuilder();

            for (int numberIndex = 0; numberIndex < sortedArray.Length; numberIndex++)
            {
                if (sortedArray[numberIndex] == 0)
                {
                    continue;
                }

                for (int j = 0; j < sortedArray[numberIndex]; j++)
                {
                    if (builder.Length < 1)
                    {
                        builder.Append(numberIndex);
                    }
                    else
                    {
                        builder.Append(" " + numberIndex);
                    }
                }
            }

            return builder.ToString();
        }
    }
}
