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
            return input.All(Char.IsLetter);
        }
    }
}
