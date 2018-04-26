using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FullCountingSort
{
    class CountingSort
    {
        public static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());

            var inputList = new List<string>();

            for (int i = 0; i < lines; i++)
            {
                inputList.Add(Console.ReadLine());
            }

            var result = SortInput(lines, inputList);

            Console.WriteLine(result);
        }

        public static string SortInput(int lines, List<string> inputList)
        {
            var outputArray = new List<string>[100];

            for (int i = 0; i < inputList.Count; i++)
            {
                var line = inputList[i].Split(' ');

                var indexNumber = int.Parse(line[0]);

                //if list is not initiated
                if (outputArray[indexNumber] == null)
                {
                    outputArray[indexNumber] = new List<string>();
                }

                if (lines / 2 > i)
                {
                    outputArray[indexNumber].Add("-");
                }
                else
                {
                    outputArray[indexNumber].Add(line[1]);
                }
            }

            StringBuilder result = new StringBuilder();

            for (int j = 0; j < outputArray.Length; j++)
            {
                if (outputArray[j] == null)
                {
                    continue;
                }

                foreach (var str in outputArray[j])
                {
                    result.Append(str + ' ');
                }
            }

            result.Length -= 1;

            return result.ToString();
        }
    }
}
