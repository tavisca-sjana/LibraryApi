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
        public void get_all_books_test()
        {
            BookService bookService = new BookService();
            int expectedStatusCode = 200;
            
            var response = bookService.GetBookList();

            Assert.Equal(expectedStatusCode, response.StatusCode);

        }

        [Fact]
        public void get_book_by_correct_id_test()
        {
            BookService bookService = new BookService();
            int id = 1111;
            int expectedStatusCode = 200;

            var response = bookService.GetBook(id);


            Assert.Equal(expectedStatusCode, response.StatusCode);

        }

        [Fact]
        public void get_book_by_wrong_id_test()
        {
            BookService bookService = new BookService();
            int id = 11341;
            int expectedStatusCode = 404;

            var response = bookService.GetBook(id);
            output.WriteLine(response.StatusCode.ToString());
            Assert.Equal(expectedStatusCode,response.StatusCode);

        }

        [Fact]
        public void add_valid_book_test()
        {
            BookService bookService = new BookService();
            Book newBook = new Book { Id = 1114, Name = "DesignPatterns", AuthorName = "DonNorman", Category = "Design", Price = 690 ,  };
            int expectedStatusCode = 200;

            var response = bookService.AddBook(newBook);

            Assert.Equal(expectedStatusCode,response.StatusCode);

        }

        [Fact]
        public void add_book_with_negative_id_test()
        {
            BookService bookService = new BookService();
            Book newBook = new Book { Id = -1114, Name = "DesignPatterns", AuthorName = "DonNorman", Category = "Design", Price = 690, };
            int expectedStatusCode = 400;
            string expectedMessage = "ID field is negative";

            var response = bookService.AddBook(newBook);

            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Equal(expectedMessage, response.ErrorList[0]);

        }

        [Fact]
        public void add_book_with_author_name_containing_number_test()
        {
            BookService bookService = new BookService();
            Book newBook = new Book { Id = 1114, Name = "DesignPatterns", AuthorName = "Don123 Norman", Category = "Design", Price = 690, };
            int expectedStatusCode = 400;
            string expectedMessage = "Author Name field should contain only alphabets";

            var response = bookService.AddBook(newBook);

            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Equal(expectedMessage, response.ErrorList[0]);

        }

        [Fact]
        public void add_book_with_book_name_containing_number_test()
        {
            BookService bookService = new BookService();
            Book newBook = new Book { Id = 1114, Name = "Design 442Patterns", AuthorName = "Don Norman", Category = "Design", Price = 690, };
            int expectedStatusCode = 400;
            string expectedMessage = "Book Name field should contain only alphabets";

            var response = bookService.AddBook(newBook);

            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Equal(expectedMessage, response.ErrorList[0]);

        }

        [Fact]
        public void add_book_with_category_name_containing_number_test()
        {
            BookService bookService = new BookService();
            Book newBook = new Book { Id = 1114, Name = "DesignPatterns", AuthorName = "Don Norman", Category = "Desig13n", Price = 690, };
            int expectedStatusCode = 400;
            string expectedMessage = "Category field should contain only alphabets";

            var response = bookService.AddBook(newBook);

            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Equal(expectedMessage, response.ErrorList[0]);

        }


        [Fact]
        public void add_book_with_category_name_and_author_name_and_book_name_containing_numbers_test()
        {
            BookService bookService = new BookService();
            Book newBook = new Book { Id = 1114, Name = "Design2314 Patterns", AuthorName = "Do242n Norman", Category = "Desig13n", Price = 690, };
            int expectedStatusCode = 400;
            string[] expectedMessage = {
                "Author Name field should contain only alphabets",
                "Category field should contain only alphabets",
                "Book Name field should contain only alphabets"
            };
            var response = bookService.AddBook(newBook);

            Assert.Equal(expectedStatusCode, response.StatusCode);
            for(int i= 0;i<response.ErrorList.Count;i++)
            {
                Assert.Equal(expectedMessage[i], response.ErrorList[i]);
            }

        }

        [Fact]
        public void delete_book_with_correct_id_test()
        {
            BookService bookService = new BookService();
            int id = 1111;
            int expectedStatusCode = 200;

            var response = bookService.DeleteBook(id);
           
            Assert.Equal(expectedStatusCode, response.StatusCode);

        }

        [Fact]
        public void delete_book_with_wrong_id_test()
        {
            BookService bookService = new BookService();
            int id = 1119881;
            int expectedStatusCode = 400;

            var response = bookService.DeleteBook(id);

            Assert.Equal(expectedStatusCode, response.StatusCode);

        }

    

        [Fact]
        public void edit_valid_book_test()
        {
            BookService bookService = new BookService();
            int id = 1111;
            Book newBook = new Book { Id = 1111, Name = "DesignPatterns", AuthorName = "Don K Norman", Category = "Design", Price = 690, };
            int expectedStatusCode = 200;

            var response = bookService.EditBook(id,newBook);

            Assert.Equal(expectedStatusCode, response.StatusCode);

        }

        [Fact]
        public void edit_book_with_negative_id_test()
        {
            BookService bookService = new BookService();
            int id = 1111;
            Book newBook = new Book { Id = -1114, Name = "DesignPatterns", AuthorName = "DonNorman", Category = "Design", Price = 690, };
            int expectedStatusCode = 400;
            string expectedMessage = "ID field is negative";

            var response = bookService.EditBook(id,newBook);

            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Equal(expectedMessage, response.ErrorList[0]);

        }

        [Fact]
        public void edit_book_with_wrong_id_test()
        {
            BookService bookService = new BookService();
            int id = 12311;
            Book newBook = new Book { Id = 1111, Name = "DesignPatterns", AuthorName = "Don K Norman", Category = "Design", Price = 690, };
            int expectedStatusCode = 400;

            var response = bookService.EditBook(id, newBook);

            Assert.Equal(expectedStatusCode, response.StatusCode);

        }

        [Fact]
        public void edit_book_with_book_name_containing_number_test()
        {
            BookService bookService = new BookService();
            int id = 12311;
            Book newBook = new Book { Id = 1111, Name = "Desig123n Patterns", AuthorName = "Don K Norman", Category = "Design", Price = 690, };
            int expectedStatusCode = 400;
            string expectedMessage = "Book Name field should contain only alphabets";

            var response = bookService.EditBook(id, newBook);

            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Equal(expectedMessage, response.ErrorList[0]);

        }

        [Fact]
        public void edit_book_with_author_name_containing_number_test()
        {
            BookService bookService = new BookService();
            int id = 12311;
            Book newBook = new Book { Id = 1111, Name = "Design Patterns", AuthorName = "Don23 K Norman", Category = "Design", Price = 690, };
            int expectedStatusCode = 400;
            string expectedMessage = "Author Name field should contain only alphabets";

            var response = bookService.EditBook(id, newBook);

            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Equal(expectedMessage, response.ErrorList[0]);

        }

        [Fact]
        public void edit_book_with_category__containing_number_test()
        {
            BookService bookService = new BookService();
            int id = 12311;
            Book newBook = new Book { Id = 1111, Name = "Design Patterns", AuthorName = "Don K Norman", Category = "Des324ign", Price = 690, };
            int expectedStatusCode = 400;
            string expectedMessage = "Category field should contain only alphabets";

            var response = bookService.EditBook(id, newBook);

            Assert.Equal(expectedStatusCode, response.StatusCode);
            Assert.Equal(expectedMessage, response.ErrorList[0]);

        }

        [Fact]
        public void edit_book_with_category_name_and_author_name_and_book_name_containing_numbers_test()
        {
            //Arrange
            BookService bookService = new BookService();
            Book newBook = new Book { Id = 1114, Name = "Design2314 Patterns", AuthorName = "Do242n Norman", Category = "Desig13n", Price = 690, };
            int expectedStatusCode = 400;
            int id = 1111;
            string[] expectedMessage = {
                "Author Name field should contain only alphabets",
                "Category field should contain only alphabets",
                "Book Name field should contain only alphabets"
            };

            //Act
            var response = bookService.EditBook(id,newBook);

            //Assert
            Assert.Equal(expectedStatusCode, response.StatusCode);
            for (int i = 0; i < response.ErrorList.Count; i++)
            {
                Assert.Equal(expectedMessage[i], response.ErrorList[i]);
            }

        }



    }
}
