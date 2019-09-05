using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LibraryApi.Service
{
    public static class Response
    {
        public const string BaseUri = "C:/Users/sjana/source/repos/LibraryApi/LibraryApi/response.json";

        public static dynamic GetObject(string baseUri = BaseUri)
        {
            WebClient client = new WebClient();
            string jsonType = File.ReadAllText(baseUri);
            var resultString = client.DownloadString(baseUri);
            dynamic resultObject = JsonConvert.DeserializeObject(jsonType);
            return resultObject;
        }

        public static dynamic GetErrorObject(int code,string message)
        {
            dynamic responseObject = GetObject();
            responseObject.Response.Error.code = code;
            responseObject.Response.Error.message = message;
            responseObject.Response.Model = null;
            return responseObject;

        }

        public static dynamic GetSuccessObject(string model)
        {
            dynamic responseObject = GetObject();
            responseObject.Response.Error = null;
            responseObject.Response.Model = model;
            return responseObject;

        }
    }
}
