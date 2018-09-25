using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TShape
{
    class Program
    {

        // Complete the solve function below.
        public static string Solve(List<int> rows, List<int> cols)
        {
            rows.Sort();
            cols.Sort();

            var oneWay = cols[0] + 1 == cols[1] &&
                cols.Skip(1).Take(3).Distinct().Any() &&
                cols[4] - 1 == cols[1] &&
                ((rows[0] == rows.Min() &&
                rows[3] == rows[0] + 1 &&
                rows[4] == rows[0] + 2 &&
                rows.Take(3).Distinct().Any(o => o != rows[2])) ||
                (rows[4] == rows.Max() &&
                rows[1] == rows[4] - 1 &&
                rows[0] == rows[4] - 2 &&
                rows.Skip(2).Take(3).Distinct().Any()));

            var orAnother = rows[0] + 1 == rows[1] &&
                rows.Skip(1).Take(3).Distinct().Any(o => o != cols[2]) &&
                rows[4] - 1 == rows[1] &&
                ((cols[0] == cols.Min() &&
                cols[3] == cols[0] + 1 &&
                cols[4] == cols[0] + 2 &&
                cols.Take(3).Distinct().Any()) ||
                (cols[4] == cols.Max() &&
                cols[1] == cols[4] - 1 &&
                cols[0] == cols[4] - 2 &&
                cols.Skip(2).Take(3).Any(o => o != cols[2])));

            if (oneWay || orAnother)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }

        static void Main(string[] args)
        {
            StringBuilder builder = new StringBuilder();

            int t = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < t; tItr++)
            {
                var rows = new List<int>();
                var cols = new List<int>();

                for (int i = 0; i < 5; i++)
                {
                    var point = Console.ReadLine().TrimEnd().Split(' ').Select(x => int.Parse(x)).ToList();
                    rows.Add(point[0]);
                    cols.Add(point[1]);
                }

                string result = Solve(rows, cols);

                builder.AppendLine(result);
            }
            Console.WriteLine(builder.ToString());
        }
    }
}
