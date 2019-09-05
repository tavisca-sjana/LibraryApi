using System;
using Xunit;
using Newtonsoft.Json;
using LibraryApi.Service;
using System.IO;
using Newtonsoft.Json.Linq;
using Xunit.Abstractions;
using System.Collections.Generic;
using LibraryApi.Models;

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
            BookService bookService = new BookService();
            List<Book> ExpectedBookList = new List<Book>();
            ExpectedBookList.Add(new Book { Id = 1111, Name = "Design Patterns", AuthorName = "Don Norman", Category = "Design", Price = 590 });
            ExpectedBookList.Add(new Book { Id = 1112, Name = "Greatest Cover Up", AuthorName = "Anuj Dhar", Category = "Non-Fiction", Price = 1235.98 });
            ExpectedBookList.Add(new Book { Id = 1113, Name = "Wings of Fire", AuthorName = "Abdul Kalam", Category = "Non-Fiction", Price = 1090.78 });

            var bookList = bookService.GetBookList();
            
            Assert.Equal(ExpectedBookList.Count,bookList.Count);

        }

        [Fact]
        public void GetBookByCorrectIdTest()
        {
            BookService bookService = new BookService();
            int id = 1111;
            var book = bookService.GetBook(id);

            Assert.Equal(id, book.Id);

        }

        [Fact]
        public void GetBookByWrongIdTest()
        {
            BookService bookService = new BookService();
            int id = 11341;
            var book = bookService.GetBook(id);

            Assert.Null(book);

        }

        [Fact]
        public void AddValidBookTest()
        {
            BookService bookService = new BookService();
            Book newBook = new Book{ Id = 1114, Name = "DesignPatterns", AuthorName = "DonNorman", Category = "Design", Price = 690 };
            var bookList = new List<Book>();
            bookList = bookService.AddBook(newBook);

            Assert.Equal(4,bookList.Count);

        }
    }
}
