using LibraryApi.Models;
using System.Collections.Generic;

namespace LibraryApi.Data
{
    public class BookData
    {
        public List<Book> BookList;

        public BookData()
        {
            BookList = new List<Book>();
            BookList.Add(new Book { Id = 1111, Name = "Design Patterns", AuthorName = "Don Norman", Category = "Design", Price = 590 });
            BookList.Add(new Book { Id = 1112, Name = "Greatest Cover Up", AuthorName = "Anuj Dhar", Category = "Non-Fiction", Price = 1235.98 });
            BookList.Add(new Book { Id = 1113, Name = "Wings of Fire", AuthorName = "Abdul Kalam", Category = "Non-Fiction", Price = 1090.78 });
        }

        public List<Book> Add(Book book)
        {
            BookList.Add(book);
            return BookList;
        }

        public List<Book> GetBookList()
        {
            if (BookList.Count != 0)
                return BookList;
            return null;
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
