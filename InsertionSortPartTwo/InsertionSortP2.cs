using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

namespace InsertionSortPartTwo
{
    class InsertionSortP2
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());

            var inputList = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();

            var result = Sort(inputList);

            Console.WriteLine(result);
        }

        public static string Sort(List<int> inputList)
        {
            var builder = new StringBuilder();

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
                    LinePrint(inputList, builder);
                    continue;
                }

                for (int j = i; j > -1; j--)
                {
                    prevElement = j > 0 ? inputList[j - 1] : int.MinValue;

                    if (currElement < prevElement)
                    {
                        inputList[j] = prevElement;
                    }
                    else
                    {
                        inputList[j] = currElement;
                        LinePrint(inputList, builder);
                        break;
                    }
                }
            }

            builder.Length -= 2;
            return builder.ToString();
        }

        private static void LinePrint(List<int> inputList, StringBuilder builder)
        {
            for (var index = 0; index < inputList.Count; index++)
            {
                var num = inputList[index];
                builder.Append(num + " ");
            }

            builder.Length -= 1;
            builder.AppendLine();
        }
    }
}
