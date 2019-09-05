using System;
using Xunit;
using Newtonsoft.Json;
using LibraryApi.Service;
using System.IO;
using Newtonsoft.Json.Linq;
using Xunit.Abstractions;


namespace LibraryApi.Tests
{
    public class BookServiceFixture
    {

        private readonly ITestOutputHelper output;

        public BookServiceFixture(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void GetAllBooksTest()
        {
           

        }
    }
}
