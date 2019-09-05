using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;
using LibraryApi.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        // GET: api/values
        [HttpGet]
        public string Get()
        {
            BookService bookService = new BookService();
            return bookService.GetBookList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            BookService bookService = new BookService();
            return  bookService.GetBook(id);


        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]Book book)
        {
            BookService bookService = new BookService();
            return bookService.AddBook(book);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Book book)
        {
            BookService bookService = new BookService();
            return bookService.EditBook(id, book);
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
