using Microsoft.AspNetCore.Mvc;
using LibraryApi.Models;
using LibraryApi.Service;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private BookService _bookService;
        private Response _response;
        private readonly ILogger _logger;

        public BookController(ILogger<BookController> logger)
        {
            _bookService = new BookService();
            _logger = logger;
        }
        
        // GET: api/book
        [HttpGet]
        public ActionResult Get()
        {
            _response = _bookService.Get();
            _logger.LogInformation($"{nameof(Get)} route hit");
            return StatusCode(_response.StatusCode, _response);
            
        }

        // GET api/book/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            _response = _bookService.GetById(id);
            _logger.LogInformation($"{nameof(Get)} by id route hit");
            return StatusCode(_response.StatusCode, _response);
        }

        // POST api/book
        [HttpPost]
        public ActionResult Post([FromBody]Book book)
        {
            _response = _bookService.Add(book);
            _logger.LogInformation($"{nameof(Post)} route hit");
            return StatusCode(_response.StatusCode, _response);
        }

        // PUT api/book/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Book book)
        {
            _response = _bookService.EditById(id, book);
            _logger.LogInformation($"{nameof(Put)} route hit");
            return StatusCode(_response.StatusCode, _response);
        }

        // DELETE api/book/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _response = _bookService.DeleteById(id);
            _logger.LogInformation($"{nameof(Delete)} route hit");
            return StatusCode(_response.StatusCode, _response);
        }
    }
}
