using FluentValidation.Results;
using LibraryApi.Data;
using LibraryApi.Models;
using LibraryApi.Validation;
using System;
using System.Collections.Generic;

namespace LibraryApi.Service
{
    public class BookService
    {
        private BookValidator _validator;
        private ValidationResult _validationResult;
        private BookData _bookData;
        private Response _response;

        public BookService()
        {
            _bookData = new BookData();
            _validator = new BookValidator();
            _response = new Response();
        }
       
       
        public Response Get()
        {
            List<Book> bookList = _bookData.GetBookList();
            return _response.CreateObject(200,bookList);
            
        }

        public Response GetById(int id)
        {
            Book book = _bookData.Get(id);  
            return _response.CreateObject(200, book);
        }

        public Response Add(Book book)
        {
            _validationResult = _validator.Validate(book);

            if(_validationResult.IsValid)
            {
                List<Book> bookList = _bookData.Add(book);
                return _response.CreateObject(201, bookList);
            }
            else
            { 
                List<Tuple<string, string>> errorList = new List<Tuple<string, string>>();
                foreach (var error in _validationResult.Errors)
                    errorList.Add(Tuple.Create<string, string>(error.PropertyName,error.ErrorMessage));
                return _response.CreateObject(400, null, errorList);
            }
               
        }

        public Response EditById(int id,Book bookToEdit)
        {
            _validationResult = _validator.Validate(bookToEdit);

            if (_validationResult.IsValid)
                return _response.CreateObject(201, bookToEdit);
            else
            {
                List<Tuple<string, string>> errorList = new List<Tuple<string, string>>();
                foreach (var error in _validationResult.Errors)
                    errorList.Add(Tuple.Create<string, string>(error.PropertyName, error.ErrorMessage));
                return _response.CreateObject(400, null, errorList);
            }
        }

        public Response DeleteById(int id)
        {
            List<Book> bookList = _bookData.Delete(id);
            return _response.CreateObject(200, bookList);
        }

        
    }
}
