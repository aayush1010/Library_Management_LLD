using Library_Management.Abstracts;
using Library_Management.Concretes.CommandRunners;
using Library_Management.Entities;
using Library_Management.Services;
using Moq;

namespace Library_Management_Test
{
    [TestFixture]
	public class LibraryServiceTest
	{
        private Mock<IConsoleWrapper> mockConsoleWrapper;
        private Mock<Library> mockLibrary;
        private ILibraryService libraryService;

        [SetUp]
        public void Setup()
        {
            mockConsoleWrapper = new Mock<IConsoleWrapper>();
            mockLibrary = new Mock<Library>();
            libraryService = new LibraryService(mockLibrary.Object, mockConsoleWrapper.Object);
        }

        [Test]
        public void AddBook_WhenBookDoesNotExist()
        {
            
            mockLibrary.Setup(l => l.GetBooks()).Returns(new List<Book>());

            libraryService.AddBook("ABC", "Aayush", 1);

            mockLibrary.Verify(l => l.AddBook(It.IsAny<Book>()), Times.Once);
            mockConsoleWrapper.Verify(c => c.WriteLine("Book added to the library."), Times.Once);
        }

        [Test]
        public void AddBook_WhenBookExists()
        {
            var existingBook = new Book("ABC", "Aayush", 1);
            mockLibrary.Setup(l => l.GetBooks()).Returns(new List<Book> { existingBook });

            libraryService.AddBook("ABC", "Aayush", 1);

            mockLibrary.Verify(l => l.AddBook(It.IsAny<Book>()), Times.Never);
            mockConsoleWrapper.Verify(c => c.WriteLine("Book already exists in library."), Times.Once);
        }

        [Test]
        public void DisplayBooks_WhenLibraryIsNotEmpty()
        {
            var book1 = new Book("ABC", "Aayush", 1);
            var book2 = new Book("XYZ", "Aayush", 1);
            mockLibrary.Setup(l => l.GetBooks()).Returns(new List<Book>  { book1, book2 });

            libraryService.DisplayBooks();

            mockConsoleWrapper.Verify(c => c.WriteLine("Library Catalog:"), Times.Once);
            mockConsoleWrapper.Verify(c => c.WriteLine($"Title: {book1.Title}, Author: {book1.Author}, Available: {book1.Available}"), Times.Once);
            mockConsoleWrapper.Verify(c => c.WriteLine($"Title: {book2.Title}, Author: {book2.Author}, Available: {book2.Available}"), Times.Once);
        }

        [Test]
        public void DisplayBooks_WhenLibraryIsEmpty()
        {
            mockLibrary.Setup(l => l.GetBooks()).Returns(new List<Book>());

            libraryService.DisplayBooks();

            mockConsoleWrapper.Verify(c => c.WriteLine("The library is empty."), Times.Once);
        }


        [Test]
        public void BorrowBook_WhenBookAvailable()
        {
            var book = new Book("ABC", "Aayush", 1);
            mockLibrary.Setup(l => l.GetBooks()).Returns(new List<Book> { book });

            libraryService.BorrowBook("ABC");

            mockConsoleWrapper.Verify(c => c.WriteLine("Book borrowed successfully"), Times.Once);
        }

        [Test]
        public void BorrowBook_WhenBookNotAvailable()
        {
            var book = new Book("ABC", "Aayush", 0);
            mockLibrary.Setup(l => l.GetBooks()).Returns(new List<Book> { book });

            libraryService.BorrowBook("ABC");

            mockConsoleWrapper.Verify(c => c.WriteLine("Oops! No book left to borrow with this title"), Times.Once);
        }

        [Test]
        public void BorrowBook_WhenBookNotExist()
        {
            mockLibrary.Setup(l => l.GetBooks()).Returns(new List<Book>());

            libraryService.BorrowBook("Non-existent Book Title");

            mockConsoleWrapper.Verify(c => c.WriteLine("No book with this title is available"), Times.Once);
        }


        [Test]
        public void ReturnBook_WhenBookBorrowed()
        {
            var book = new Book("ABC", "Aayush", 1);
            book.BorrowBook(); 
            mockLibrary.Setup(l => l.GetBooks()).Returns(new List<Book> { book });

            libraryService.ReturnBook("ABC");

            mockConsoleWrapper.Verify(c => c.WriteLine("Book returned successfully."), Times.Once);
        }

        [Test]
        public void ReturnBook_WhenBookNotBorrowed()
        {
            var book = new Book("Book Title", "Author Name", 1);

            mockLibrary.Setup(l => l.GetBooks()).Returns(new List<Book>{ book });

            libraryService.ReturnBook("Book Title");

            mockConsoleWrapper.Verify(c => c.WriteLine("You haven't borrowed this book."), Times.Once);
        }

        [Test]
        public void ReturnBook_WhenBookNotExist()
        {
            mockLibrary.Setup(l => l.GetBooks()).Returns(new List<Book>());

            libraryService.ReturnBook("Non-existent Book Title");

            mockConsoleWrapper.Verify(c => c.WriteLine("No book with this title is available"), Times.Once);
        }
    }
}

