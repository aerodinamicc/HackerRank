using System;
using System.Linq;

namespace HackerRank
{
    public class CountingPartOne
    {
        public static void Main(string[] args)
        {
            var count = 100;
            var numbers = Console.ReadLine().ToString().Split(' ').Select(n => int.Parse(n)).ToArray();

            var result = CountOccurences(count, numbers);

            Console.WriteLine(string.Join(" ", result));
        }

        public static int[] CountOccurences(int n, int[] inputArray)
        {
            var occurenceArray = new int[n];

            for (int i = 0; i < inputArray.Length; i++)
            {
                occurenceArray[inputArray[i]] += 1;
            }

            return occurenceArray;
        }
    }
}
