using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftRotation
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] nd = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);

            int d = Convert.ToInt32(nd[1]);

            var a = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
            var newList = Rotation(n, d, a);

            Console.WriteLine(newList);
        }

        public static string Rotation(int n, int d, List<int> a)
        {
            var left = a.GetRange(d % n, a.Count - d % n);
            var right = a.GetRange(0, d % n);

            var newList = new List<int>();
            newList.AddRange(left);
            newList.AddRange(right);
            return string.Join(" ", newList);
        }
    }
}
