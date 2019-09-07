using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;
using LibraryApi.Service;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        
        // GET: api/book
        [HttpGet]
        public ActionResult Get()
        {
            BookService bookService = new BookService();
            Response response = bookService.Get();
            return StatusCode(response.StatusCode, response);
            
        }

        // GET api/book/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            BookService bookService = new BookService();
            Response response = bookService.GetById(id);
            return StatusCode(response.StatusCode, response);
        }

        // POST api/book
        [HttpPost]
        public ActionResult Post([FromBody]Book book)
        {
            BookService bookService = new BookService();
            Response response = bookService.Add(book);
            return StatusCode(response.StatusCode, response);
        }

        // PUT api/book/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Book book)
        {
            BookService bookService = new BookService();
            Response response = bookService.EditById(id, book);
            return StatusCode(response.StatusCode, response);
        }

        // DELETE api/book/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            BookService bookService = new BookService();
            Response response = bookService.DeleteById(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
