using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OderingGmails
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());

            var list = new List<string>();
            for (int NItr = 0; NItr < N; NItr++)
            {
                var firstNameEmailID = Console.ReadLine();
                list.Add(firstNameEmailID);
            }

            List<string> names = SortNames(list);
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

        }

        public static List<string> SortNames(List<string> list)
        {
            var gmailAccounts = list.Where(x => x.EndsWith("@gmail.com")).ToList();
            var names = gmailAccounts.Select(x => x.Split(' ')).Select(y => y[0]).ToList()
                .OrderBy(x => x).ToList();
            return names;
        }
    }
}
