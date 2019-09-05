using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;
using LibraryApi.Service;
using Newtonsoft.Json;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        dynamic ResponseObject;
        // GET: api/values
        [HttpGet]
        public string Get()
        {
            BookService bookService = new BookService();
            List<Book> bookList = bookService.GetBookList();
            if (bookList != null)
            {

                string serializedBookList = JsonConvert.SerializeObject(bookList);
                ResponseObject = LibraryApi.Service.Response.GetSuccessObject(serializedBookList);

            }

            else
            {
               
                ResponseObject = LibraryApi.Service.Response.GetErrorObject(404, "No Records");
            }
            return JsonConvert.SerializeObject(ResponseObject);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            BookService bookService = new BookService();
            Book book = bookService.GetBook(id);
            if(book != null)
            {
                string serializedBook = JsonConvert.SerializeObject(book);
                ResponseObject = LibraryApi.Service.Response.GetSuccessObject(serializedBook);
            }

            else
            {
                ResponseObject = LibraryApi.Service.Response.GetErrorObject(404, "No Records");
            }
            return JsonConvert.SerializeObject(ResponseObject);

        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]Book book)
        {
            BookService bookService = new BookService();
            List<Book> bookList =  bookService.AddBook(book);
            if (bookList != null)
            {
                string serializedBookList = JsonConvert.SerializeObject(bookList);
                ResponseObject = LibraryApi.Service.Response.GetSuccessObject(serializedBookList);
            }
            else
            {
                ResponseObject = LibraryApi.Service.Response.GetErrorObject(400, "Bad Request");
            }
            return JsonConvert.SerializeObject(ResponseObject);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Book book)
        {
            BookService bookService = new BookService();
            Book editedBook =  bookService.EditBook(id, book);
            if(book != null)
            {
                string serializedBook = JsonConvert.SerializeObject(editedBook);
                ResponseObject = LibraryApi.Service.Response.GetSuccessObject(serializedBook);
            }
            else
            {
                ResponseObject = LibraryApi.Service.Response.GetErrorObject(404, "Record Not Found");
            }
            return JsonConvert.SerializeObject(ResponseObject);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            BookService bookService = new BookService();
            return bookService.DeleteBook(id);
        }
    }
}
