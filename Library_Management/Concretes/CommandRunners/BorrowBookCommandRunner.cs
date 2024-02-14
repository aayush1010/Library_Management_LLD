using System;
using Library_Management.Abstracts;
using Library_Management.Services;

namespace Library_Management.Concretes.CommandRunners
{
    public class BorrowBookCommandRunner : CommandRunner
    {
        public BorrowBookCommandRunner(ILibraryService libraryService, IConsoleWrapper consoleWrapper) : base(libraryService, consoleWrapper)
        {
        }

        public override void RunCommand()
        {
            consoleWrapper.Write("Enter the title of the book you want to Borrow: ");
            var title = consoleWrapper.ReadLine();
            libraryService.BorrowBook(title);
        }
    }
}

