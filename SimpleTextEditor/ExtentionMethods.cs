using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextEditor
{
    public static class ExtentionMethods
    {
        public static string SplitStringAtIndex(this string original, int charsToRemove)
        {
            if (original.Length - charsToRemove == 0)
            {
                return string.Empty;
            }

            return original.Substring(0, original.Length - charsToRemove);
        }
    }
}
