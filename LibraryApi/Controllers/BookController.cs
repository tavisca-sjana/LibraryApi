using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;
using LibraryApi.Service;
using LibraryApi.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            BookService bookService = new BookService();
            return bookService.GetBookList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            BookService bookService = new BookService();
            return  bookService.GetBook(id);


        }

        // POST api/values
        [HttpPost]
        public IEnumerable<Book> Post([FromBody]Book book)
        {
            BookService bookService = new BookService();
            return bookService.AddBook(book);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Book Put(int id, [FromBody]Book book)
        {
            BookService bookService = new BookService();
            return bookService.EditBook(id, book);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public List<Book> Delete(int id)
        {
            BookService bookService = new BookService();
            return bookService.DeleteBook(id);
        }
    }
}
