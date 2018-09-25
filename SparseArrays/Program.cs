using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparseArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int stringsCount = Convert.ToInt32(Console.ReadLine());

            var strings = new List<string>();

            for (int i = 0; i < stringsCount; i++)
            {
                string stringsItem = Console.ReadLine();
                strings.Add(stringsItem);
            }

            int queriesCount = Convert.ToInt32(Console.ReadLine());

            var queries = new List<string>();

            for (int i = 0; i < queriesCount; i++)
            {
                string queriesItem = Console.ReadLine();
                queries.Add(queriesItem);
            }

            string result = FindOccurences(strings, queries);
        }

        public static string FindOccurences(List<string> strings, List<string> queries)
        {
            var occurences = new int[queries.Count];

            for (int i = 0; i < queries.Count; i++)
            {
                if(strings.Any(s => s == queries[i]))
                {
                    occurences[i] += strings.Where(s => s == queries[i]).Count();
                }
            }

            var result = string.Join("\r\n", occurences);
            return result;
        }
    }
}
