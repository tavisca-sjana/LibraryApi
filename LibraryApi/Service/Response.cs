using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Service
{
    public class Response
    {
        public Object Model { get; set; }
        public int StatusCode { get; set; }

        public List<Tuple<string, string>> ErrorList;

        public Response()
        {
            ErrorList = new List<Tuple<string, string>>();
        }

        public Response CreateObject(int statusCode,Object model = null,List<Tuple<string,string>> errorList=null)
        {
            Response response = new Response();
            response.StatusCode = statusCode;
            response.Model = model;
            response.ErrorList = errorList;

            return response;
        }

    }
}
