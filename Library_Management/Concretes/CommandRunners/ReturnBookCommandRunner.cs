using System;
using Library_Management.Abstracts;
using Library_Management.Services;

namespace Library_Management.Concretes.CommandRunners
{
    public class ReturnBookCommandRunner : CommandRunner
    {
        public ReturnBookCommandRunner(ILibraryService libraryService, IConsoleWrapper consoleWrapper) : base(libraryService, consoleWrapper)
        {
        }

        public override void RunCommand()
        {
            consoleWrapper.Write("Enter the title of the book you want to return: ");
            var title = consoleWrapper.ReadLine();
            libraryService.ReturnBook(title);
        }
    }
}

