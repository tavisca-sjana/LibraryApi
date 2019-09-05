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
        dynamic ResponseObject;

        public BookService()
        {
            BookData = new BookData();
        }
       
        public bool ValidateId(int id)
        {
            foreach(var book in BookData.BookList)
            {
                if (book.Id == id)
                    return true;
                
            }
            return false;
        }

       

        public string GetBookList()
        {
            List<Book> bookList = BookData.GetBookList();
            string serializedBookList = "";
            if(bookList != null)
            {
                serializedBookList = JsonConvert.SerializeObject(bookList);
                ResponseObject = Response.GetSuccessObject(serializedBookList);              
               
            }

            else
            {
               ResponseObject = Response.GetErrorObject(404,"No Records");
            }
                
            return JsonConvert.SerializeObject(ResponseObject);
        }

        public string GetBook(int id)
        {
           
            if (ValidateId(id))
            {
                Book book = BookData.Get(id);
                string serializedBook = JsonConvert.SerializeObject(book);
                ResponseObject = Response.GetSuccessObject(serializedBook);
            }
                
            else
            {
                ResponseObject = Response.GetErrorObject(404, "No Records");
            }

            return JsonConvert.SerializeObject(ResponseObject);

        }

        public string AddBook(Book book)
        {
            if(book.Id < 0 )
            {
                ResponseObject = Response.GetErrorObject(400,"Negative Id");
            }
            else if(!BookValidation.StringContainsOnlyAplhabets(book.AuthorName) && !BookValidation.StringContainsOnlyAplhabets(book.Name) && !BookValidation.StringContainsOnlyAplhabets(book.Category))
            {
                ResponseObject = Response.GetErrorObject(400, "Only Alphabets Allowed");
            }
            else
            {

                List<Book> bookList = BookData.Add(book);
                string serializedBookList = "";
                if (bookList != null)
                {
                    serializedBookList = JsonConvert.SerializeObject(bookList);
                    ResponseObject = Response.GetSuccessObject(serializedBookList);
                }

                else
                {
                    ResponseObject = Response.GetErrorObject(400, "Bad Request");
                }

            }
           
            return JsonConvert.SerializeObject(ResponseObject);
        }

        public string EditBook(int id,Book bookToEdit)
        {
            if (ValidateId(id))
            {
                Book book = BookData.Edit(id, bookToEdit);
                string serializedBook = JsonConvert.SerializeObject(book);
                ResponseObject = Response.GetSuccessObject(serializedBook);
            }

            else if(BookValidation.StringContainsOnlyAplhabets(bookToEdit.AuthorName) && BookValidation.StringContainsOnlyAplhabets(bookToEdit.Name) && BookValidation.StringContainsOnlyAplhabets(bookToEdit.Category))
            {
                ResponseObject = Response.GetErrorObject(400, "Only Alphabets Allowed");
            }

            else
            {
                ResponseObject = Response.GetErrorObject(404, "Record Not Found");
            }

            return JsonConvert.SerializeObject(ResponseObject);
        }

        public string DeleteBook(int id)
        {
            if (ValidateId(id))
            {
                List<Book> bookList = BookData.Delete(id);
                string serializedBookList = JsonConvert.SerializeObject(bookList);
                ResponseObject = Response.GetSuccessObject(serializedBookList);

            }

            else
            {
                ResponseObject = Response.GetErrorObject(404, "Record Not found");
            }

            return JsonConvert.SerializeObject(ResponseObject);

        }
    }
}
