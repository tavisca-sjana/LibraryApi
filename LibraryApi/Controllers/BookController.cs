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
        private BookService _bookService;
        private Response _response;

        public BookController()
        {
            _bookService = new BookService();
        }
        
        // GET: api/book
        [HttpGet]
        public ActionResult Get()
        {
            _response = _bookService.Get();
            return StatusCode(_response.StatusCode, _response);
            
        }

        // GET api/book/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            _response = _bookService.GetById(id);
            return StatusCode(_response.StatusCode, _response);
        }

        // POST api/book
        [HttpPost]
        public ActionResult Post([FromBody]Book book)
        {
            _response = _bookService.Add(book);
            return StatusCode(_response.StatusCode, _response);
        }

        // PUT api/book/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Book book)
        {
            _response = _bookService.EditById(id, book);
            return StatusCode(_response.StatusCode, _response);
        }

        // DELETE api/book/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _response = _bookService.DeleteById(id);
            return StatusCode(_response.StatusCode, _response);
        }
    }
}
