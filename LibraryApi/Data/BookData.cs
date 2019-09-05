using LibraryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LibraryApi.Data
{
    public class BookData
    {
        public List<Book> BookList;

        public BookData()
        {
            BookList = new List<Book>();
            BookList.Add(new Book { Id = 1111, Name = "Design Patterns", AuthorName = "Don Norman" });
            BookList.Add(new Book { Id = 1112, Name = "Greatest Cover Up", AuthorName = "Anuj Dhar" });
            BookList.Add(new Book { Id = 1113, Name = "Wings of Fire", AuthorName = "Abdul Kalam" });
        }

        public List<Book> Add(Book book)
        {
            BookList.Add(book);
            return BookList;
        }

        public List<Book> GetBookList()
        {
            return BookList;
        }

        public Book Get(int id)
        {
            foreach(var book in BookList)
            {
                if (book.Id == id)
                    return book;
            }
            return null;
        }

       public Book Edit(int id,Book book)
       {
            for(int i=0;i<BookList.Count;i++)
            {
                if(BookList[i].Id == id)
                {
                    BookList.Insert(i, book);
                    return BookList[i];
                }
            }
            return null;
        }

        public List<Book> Delete(int id)
        {
            for (int i = 0; i < BookList.Count; i++)
            {
                if (BookList[i].Id == id)
                {
                    BookList.RemoveAt(i);
                    return BookList;
                }
            }
            return null;
        }
    }
}
