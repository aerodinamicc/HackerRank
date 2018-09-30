using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoisonousPlants
{
    class Program
    {
        public static void Main(string[] args)
        {
            var arraySize = int.Parse(Console.ReadLine());
            var array = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();

            var daysCounter = 0;
            var isArraySorted = false;

            while (!isArraySorted)
            {
                var isIterationSorted = true;

                for (int i = array.Count - 1; i > 0; i--)
                {
                    if (array[i] > array[i - 1])
                    {
                        array.RemoveAt(i);
                        isIterationSorted = false;
                    }
                }

                if (isIterationSorted)
                {
                    isArraySorted = true;
                }
                else
                {
                    daysCounter++;
                }

            }

            Console.WriteLine(daysCounter);
        }
    }
}
