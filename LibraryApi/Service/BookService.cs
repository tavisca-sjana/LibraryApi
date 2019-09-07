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

        private BookData _bookData;
        private Response _reponse;

        public BookService()
        {
            _bookData = new BookData();
            _reponse = new Response();
        }
       
       

        public Response Get()
        {
            List<Book> bookList = _bookData.GetBookList();
            _reponse.Model = bookList;
            _reponse.StatusCode = 200;
            if (bookList != null)
            {
              _reponse.Message = "Success";
            }
                
            else
            {
                _reponse.Message = "No Records Found";
            }

            return _reponse;
        }

        public Response GetById(int id)
        {
            Book book = _bookData.Get(id);  
            if(book != null)
            {
                _reponse.Model = book;
                _reponse.StatusCode = 200;
                _reponse.Message = "Success";

            }
            else
            {
                _reponse.Model = book;
                _reponse.StatusCode = 404;
                _reponse.Message = "Record Not Found";

            }
           
            return _reponse;
        }

        public Response Add(Book book)
        {
            bool errorFlag = false;
            if (BookValidation.NegativeId(book.Id))
            {
                errorFlag = true;
                _reponse.StatusCode = 400;
                _reponse.Message = "Bad Request";
                _reponse.ErrorList.Add("ID field is negative");
            }
            if (!BookValidation.StringContainsOnlyAlphabets(book.AuthorName))
            {
                errorFlag = true;
                _reponse.StatusCode = 400;
                _reponse.Message = "Bad Request";
                _reponse.ErrorList.Add("Author Name field should contain only alphabets");
            }
            if (!BookValidation.StringContainsOnlyAlphabets(book.Category))
            {
                errorFlag = true;
                _reponse.StatusCode = 400;
                _reponse.Message = "Bad Request";
                _reponse.ErrorList.Add("Category field should contain only alphabets");
            }
            if (!BookValidation.StringContainsOnlyAlphabets(book.Name))
            {
                errorFlag = true;
                _reponse.StatusCode = 400;
                _reponse.Message = "Bad Request";
                _reponse.ErrorList.Add("Book Name field should contain only alphabets");
            }
            if(!errorFlag)
            {

                List<Book> bookList = _bookData.Add(book);
                _reponse.Model = bookList;
                _reponse.StatusCode = 200;
                _reponse.Message = "Success";
            }
            return _reponse;
           
        }

        public Response EditById(int id,Book bookToEdit)
        {
            bool errorFlag = false;

            if (BookValidation.NegativeId(bookToEdit.Id))
            {
                errorFlag = true;
                _reponse.StatusCode = 400;
                _reponse.Message = "Bad Request";
                _reponse.ErrorList.Add("ID field is negative");
            }
            if (!BookValidation.StringContainsOnlyAlphabets(bookToEdit.AuthorName))
            {
                errorFlag = true;
                _reponse.StatusCode = 400;
                _reponse.Message = "Bad Request";
                _reponse.ErrorList.Add("Author Name field should contain only alphabets");
            }
            if (!BookValidation.StringContainsOnlyAlphabets(bookToEdit.Category))
            {
                errorFlag = true;
                _reponse.StatusCode = 400;
                _reponse.Message = "Bad Request";
                _reponse.ErrorList.Add("Category field should contain only alphabets");
            }
            if (!BookValidation.StringContainsOnlyAlphabets(bookToEdit.Name))
            {
                errorFlag = true;
                _reponse.StatusCode = 400;
                _reponse.Message = "Bad Request";
                _reponse.ErrorList.Add("Book Name field should contain only alphabets");
            }
            if (!errorFlag)
            {
                Book book = _bookData.Edit(id, bookToEdit);
                if (book != null)
                {
                    _reponse.Model = book;
                    _reponse.StatusCode = 200;
                    _reponse.Message = "Success";
                }
                else
                {
                    _reponse.Model = book;
                    _reponse.StatusCode = 400;
                    _reponse.Message = "Bad Request";
                }
            }
                
            

            return _reponse;
        }

        public Response DeleteById(int id)
        {
            List<Book> bookList = _bookData.Delete(id);
            if (bookList != null)
            {
                _reponse.Model = bookList;
                _reponse.StatusCode = 200;
                _reponse.Message = "Success";

            }
            else
            {
                _reponse.Model = bookList;
                _reponse.StatusCode = 400;
                _reponse.Message = "Record Not Found";

            }

            return _reponse;

        }

        
    }
}
