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

       

        public List<Book> GetBookList()
        {
            List<Book> bookList = BookData.GetBookList();

            if(bookList != null)
            {
                return bookList;
                
            }

            else
            {
                return null;
            }
                
        }

        public Book GetBook(int id)
        {
           
            if (ValidateId(id))
            {
                return BookData.Get(id);  
            }
                
            else
            {
                return null;
            }

        }

        public List<Book> AddBook(Book book)
        {
            if(book.Id < 0 )
            {
                return null;
            }
            else if (BookValidation.StringContainsOnlyAlphabets(book.AuthorName))
            {
                return null;
            }
            else if (!BookValidation.StringContainsOnlyAlphabets(book.Category))
            {
                return null;
            }
            else if (!BookValidation.StringContainsOnlyAlphabets(book.Name))
            {
                return null;
            }
            else
            {

                List<Book> bookList = BookData.Add(book);
                return bookList;
            }
           
        }

        public Book EditBook(int id,Book bookToEdit)
        {
            if (ValidateId(id))
            {
                Book book = BookData.Edit(id, bookToEdit);
                return book;
            }

            else if(BookValidation.StringContainsOnlyAlphabets(bookToEdit.AuthorName) && BookValidation.StringContainsOnlyAplhabets(bookToEdit.Name) && BookValidation.StringContainsOnlyAplhabets(bookToEdit.Category))
            {
                return null;
            }

            return null;
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
