using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Service
{
    public class Response
    {
        public Object Model { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public List<string> ErrorList;

        public Response()
        {
            ErrorList = new List<string>();
        }
    }
}
