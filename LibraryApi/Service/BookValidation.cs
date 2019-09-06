using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryApi.Service
{
    public static class BookValidation
    {
        public static bool StringContainsOnlyAlphabets(string input)
        {
            input = input.Replace(" ", "");
            //Regex.Matches(param).Count returns the number of characters matching the regex string 
            if (Regex.Matches(input, @"[a-zA-Z]").Count == input.Length)
                return true;
            return false;
        }

        public static bool NegativeId(int id)
        {
            return (id < 0) ? true : false;
        }
    }
}
