using Library_Management.Abstracts;
using Library_Management.Helpers;

namespace Library_Management.Concretes.CommandRunners
{
    public class AddBookCommandRunner : CommandRunner
    {
        public AddBookCommandRunner(ILibraryService libraryService, IConsoleWrapper consoleWrapper) : base(libraryService, consoleWrapper)
        {
        }

        public override void RunCommand()
        {
            consoleWrapper.Write("Enter book title: ");
            string title = consoleWrapper.ReadLine();
            consoleWrapper.Write("Enter author name: ");
            string author = consoleWrapper.ReadLine();
            consoleWrapper.Write("Enter quantity available: ");
            int quantity;
            while (true)
            {
                // bug fix : checking valid int incase of quantity
                var tup = IntegerHelper.CheckAndGetInteger(consoleWrapper.ReadLine());
                if (tup.Item1 && tup.Item2 > 0)
                {
                    quantity = tup.Item2;
                    break;
                }
                else
                {
                    consoleWrapper.WriteLine("Invalid input as quantity : Make sure to enter number more than 0");
                }
            }
            
            libraryService.AddBook(title, author, quantity);
        }
    }
}

