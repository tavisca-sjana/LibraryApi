using LibraryApi.Data;
using LibraryApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApi.Service
{
    public class BookService
    {

        BookData BookData;
        Response Response;

        public BookService()
        {
            BookData = new BookData();
            Response = new Response();
        }
       
       

        public Response GetBookList()
        {
            List<Book> bookList = BookData.GetBookList();

            if (bookList != null)
            {
                Response.Model = bookList;
                Response.StatusCode = 200;
                Response.Message = "Success";
            }
                
            else
            {
                Response.Model = bookList;
                Response.StatusCode = 404;
                Response.Message = "No Records Found";
            }

            return Response;
        }

        public Response GetBook(int id)
        {
            Book book = BookData.Get(id);  
            if(book != null)
            {
                Response.Model = book;
                Response.StatusCode = 200;
                Response.Message = "Success";

            }
            else
            {
                Response.Model = book;
                Response.StatusCode = 404;
                Response.Message = "Record Not Found";

            }
           
            return Response;
        }

        public Response AddBook(Book book)
        {
            bool errorFlag = false;
            if (BookValidation.NegativeId(book.Id))
            {
                errorFlag = true;
                Response.StatusCode = 400;
                Response.Message = "Bad Request";
                Response.ErrorList.Add("ID field is negative");
            }
            if (!BookValidation.StringContainsOnlyAlphabets(book.AuthorName))
            {
                errorFlag = true;
                Response.StatusCode = 400;
                Response.Message = "Bad Request";
                Response.ErrorList.Add("Author Name field should contain only alphabets");
            }
            if (!BookValidation.StringContainsOnlyAlphabets(book.Category))
            {
                errorFlag = true;
                Response.StatusCode = 400;
                Response.Message = "Bad Request";
                Response.ErrorList.Add("Category field should contain only alphabets");
            }
            if (!BookValidation.StringContainsOnlyAlphabets(book.Name))
            {
                errorFlag = true;
                Response.StatusCode = 400;
                Response.Message = "Bad Request";
                Response.ErrorList.Add("Book Name field should contain only alphabets");
            }
            if(!errorFlag)
            {

                List<Book> bookList = BookData.Add(book);
                Response.Model = bookList;
                Response.StatusCode = 200;
                Response.Message = "Success";
            }
            return Response;
           
        }

        public Response EditBook(int id,Book bookToEdit)
        {
            bool errorFlag = false;

            if (BookValidation.NegativeId(bookToEdit.Id))
            {
                errorFlag = true;
                Response.StatusCode = 400;
                Response.Message = "Bad Request";
                Response.ErrorList.Add("ID field is negative");
            }
            if (!BookValidation.StringContainsOnlyAlphabets(bookToEdit.AuthorName))
            {
                errorFlag = true;
                Response.StatusCode = 400;
                Response.Message = "Bad Request";
                Response.ErrorList.Add("Author Name field should contain only alphabets");
            }
            if (!BookValidation.StringContainsOnlyAlphabets(bookToEdit.Category))
            {
                errorFlag = true;
                Response.StatusCode = 400;
                Response.Message = "Bad Request";
                Response.ErrorList.Add("Category field should contain only alphabets");
            }
            if (!BookValidation.StringContainsOnlyAlphabets(bookToEdit.Name))
            {
                errorFlag = true;
                Response.StatusCode = 400;
                Response.Message = "Bad Request";
                Response.ErrorList.Add("Book Name field should contain only alphabets");
            }
            if (!errorFlag)
            {
                Book book = BookData.Edit(id, bookToEdit);
                if (book != null)
                {
                    Response.Model = book;
                    Response.StatusCode = 200;
                    Response.Message = "Success";
                }
                else
                {
                    Response.Model = book;
                    Response.StatusCode = 400;
                    Response.Message = "Bad Request";
                }
            }
                
            

            return Response;
        }

        public Response DeleteBook(int id)
        {
            List<Book> bookList = BookData.Delete(id);
            if (bookList != null)
            {
                Response.Model = bookList;
                Response.StatusCode = 200;
                Response.Message = "Success";

            }
            else
            {
                Response.Model = bookList;
                Response.StatusCode = 400;
                Response.Message = "Record Not Found";

            }

            return Response;

        }
    }
}
