using System;
using System.Linq;
using Library_Management.Abstracts;
using Library_Management.Entities;

namespace Library_Management.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly Library library;
        private readonly IConsoleWrapper consoleWrapper;


        public LibraryService(Library library, IConsoleWrapper consoleWrapper)
        {
            this.library = library;
            this.consoleWrapper = consoleWrapper;
        }

        public void AddBook(string title, string author, int quantity)
        {
            var book = searchBook(title);
            // bugfix : check if book already exits or not
            if (book == null)
            {
                var newBook = new Book(title, author, quantity);
                library.AddBook(newBook);
                consoleWrapper.WriteLine("Book added to the library.");
            }
            else
            {
                consoleWrapper.WriteLine("Book already exists in library.");
            }
        }

        public void DisplayBooks()
        {
            if (library.GetBooks().Count() == 0)
            {
                consoleWrapper.WriteLine("The library is empty.");
            }
            else
            {
                consoleWrapper.WriteLine("Library Catalog:");
                foreach (Book book in library.GetBooks())
                {
                    consoleWrapper.WriteLine($"Title: {book.Title}, Author: {book.Author}, Available: {book.Available}");
                }
            }
        }

        public void BorrowBook(string title)
        {
            var book = searchBook(title);
            if (book == null)
            {
                consoleWrapper.WriteLine("No book with this title is available");
            }
            else
            {
                if (book.Available > 0)
                {
                    book.BorrowBook();
                    consoleWrapper.WriteLine("Book borrowed successfully");
                }
                else
                {
                    consoleWrapper.WriteLine("Oops! No book left to borrow with this title");
                }
            }
        }

        public void ReturnBook(string title)
        {
            var book = searchBook(title);
            if (book == null)
            {
                consoleWrapper.WriteLine("No book with this title is available");
            }
            else
            {
                // bug fix (> instead of >=)
                if (book.Borrowed > 0)
                {
                    book.ReturnBook();
                    consoleWrapper.WriteLine("Book returned successfully.");
                }
                else
                {
                    consoleWrapper.WriteLine("You haven't borrowed this book.");
                }
            }
        }

        private Book searchBook(string title)
        {
            return library.GetBooks().FirstOrDefault(x => x.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
    }
}

