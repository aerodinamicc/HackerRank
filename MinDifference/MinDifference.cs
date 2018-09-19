using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinDifference
{
    class MinDifference
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var nums = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();

            var result = SwapNumbers(nums);
            Console.WriteLine(result);
        }

        public static int SwapNumbers(List<int> nums)
        {
            var swap = 0;

            for (int i = 0; i < nums.Count; i++)
            {
                var currElement = nums[i];

                if (i == 0)
                {
                    continue;
                }

                var prevElement = nums[i - 1];

                if (prevElement <= currElement)
                {
                    continue;
                }

                for (int j = i; j > -1; j--)
                {
                    prevElement = j > 0 ? nums[j - 1] : int.MinValue;

                    if (currElement < prevElement)
                    {
                        nums[j] = prevElement;
                    }
                    else
                    {
                        nums[j] = currElement;
                        swap += 1;
                        break;
                    }
                }
            }

            return swap;
        }
    }
}
