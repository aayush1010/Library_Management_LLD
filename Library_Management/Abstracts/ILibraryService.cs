namespace Library_Management.Abstracts
{
	public interface ILibraryService
	{
        void AddBook(string title, string author, int quantity);
        void DisplayBooks();
        void BorrowBook(string title);
        void ReturnBook(string title);
    }
}

