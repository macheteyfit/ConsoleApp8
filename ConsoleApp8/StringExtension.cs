using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public static class StringExtension
    {
        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            foreach (char ch in str)
            {
                if (ch == c) counter++;
            }
            return counter;
        }
    }
}
