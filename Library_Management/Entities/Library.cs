using System.Collections.Generic;

namespace Library_Management.Entities
{
   public class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }

        public virtual void AddBook(Book book)
        {
            books.Add(book);
        }

        public virtual List<Book> GetBooks()
        {
            return books;
        }
    }
}

