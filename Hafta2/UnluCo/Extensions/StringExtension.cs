using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.Extensions
{
    public static class StringExtension
    {
        public static string FirstLetterToUpper(this string str)
        {
            return char.ToUpper(str[0])+str.Substring(1);
        }
    }
}
