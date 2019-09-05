using LibraryApi.Data;
using LibraryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Service
{
    public class BookService
    {
        BookData bookData = new BookData();
        public bool ValidateId(int id)
        {
           var bookData = new BookData();
            foreach(var book in bookData.BookList)
            {
                if (book.Id == id)
                    return true;
                
            }
            return false;
        }

        public List<Book> GetBookList()
        {
            return bookData.GetBookList();
        }

        public Book GetBook(int id)
        {
            if (ValidateId(id))
                return bookData.Get(id);
            return null;

        }

        public List<Book> AddBook(Book book)
        {
            return bookData.Add(book);
        }

        public Book EditBook(int id,Book book)
        {
            if (ValidateId(id))
                return bookData.Edit(id, book);
            return null;
        }

        public List<Book> DeleteBook(int id)
        {
            if (ValidateId(id))
                return bookData.Delete(id);
            return null;
        }
    }
}
