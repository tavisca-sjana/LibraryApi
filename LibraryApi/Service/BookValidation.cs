using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Service
{
    public static class BookValidation
    {
        public static bool StringContainsOnlyAplhabets(string input)
        {
            return input.All(Char.IsLetter);
        }
    }
}
