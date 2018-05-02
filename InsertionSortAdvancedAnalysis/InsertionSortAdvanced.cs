using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSortAdvancedAnalysis
{
    class InsertionSortAdvanced
    {
        static void Main(string[] args)
        {
            var iterations = int.Parse(Console.ReadLine());

            var builder = new StringBuilder();
            for (int i = 0; i < iterations; i++)
            {
                var count = int.Parse(Console.ReadLine());
                var numbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();

                var result = CountMoves(numbers);
                if (i != iterations)
                {
                    builder.AppendLine(result);
                }
                else
                {
                    builder.Append(result);
                }
            }

            Console.WriteLine(builder);
        }

        public static string CountMoves(List<int> inputList)
        {
            var moves = 0;
            for (int i = 0; i < inputList.Count; i++)
            {
                var currElement = inputList[i];

                if (i == 0)
                {
                    continue;
                }

                var prevElement = inputList[i - 1];


                if (prevElement <= currElement)
                {
                    continue;
                }

                for (int j = i; j > -1; j--)
                {
                    prevElement = j > 0 ? inputList[j - 1] : int.MinValue;

                    if (currElement < prevElement)
                    {
                        inputList[j] = prevElement;
                        moves += 1;
                    }
                    else
                    {
                        inputList[j] = currElement;
                        break;
                    }
                }
            }

            return moves.ToString();
        }
    }
}
