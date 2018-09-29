using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextEditor
{
    public static class Editor
    {
        private static string line = string.Empty;

        private static List<string> records = new List<string>();

        public static void Append(string stringToAppend)
        {
            line += stringToAppend;
            records.Add(line);
        }

        public static void Delete(int charsToRemove)
        {
            line = line.SplitStringAtIndex(charsToRemove);
            records.Add(line);
        }

        public static string Print(int indexToPrint)
        {
            return line[indexToPrint - 1].ToString();
        }

        public static void Undo()
        {
            records.RemoveAt(records.Count - 1);
            if (records.Count != 0)
            {
                line = records.Last();
            }
            else
            {
                line = string.Empty;
            }
            
        }
    }
}
