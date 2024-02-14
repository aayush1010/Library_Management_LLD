namespace Library_Management.Entities
{
    public class Book
    {
        private readonly string title;
        private readonly string author;
        private readonly int quantity;
        private int borrowed;

        public Book(string title, string author, int quantity)
        {
            this.title = title;
            this.author = author;
            this.quantity = quantity;
            this.borrowed = 0;
        }

        public string Title { get { return title; } }
        public string Author { get { return author; } }
        public int Quantity { get { return quantity; } }
        public int Borrowed { get { return borrowed; } }
        public int Available { get { return quantity - borrowed; } }

        public void BorrowBook()
        {
            borrowed += 1;
        }

        public void ReturnBook()
        {
            borrowed -= 1;
        }
    }
}

