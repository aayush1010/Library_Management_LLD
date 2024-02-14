using System;
using Library_Management.Abstracts;
using Library_Management.Concretes.CommandRunners;
using Library_Management.Constants;
using Library_Management.Entities;
using Library_Management.Exceptions;
using Library_Management.Services;

namespace Library_Management.Factory
{
    public class CommandRunnerFactory
    {
        private readonly ILibraryService libraryService;
        private readonly IConsoleWrapper consoleWrapper;
        public CommandRunnerFactory(ILibraryService libraryService, IConsoleWrapper consoleWrapper)
        {
            this.libraryService = libraryService;
            this.consoleWrapper = consoleWrapper;
        }
        public CommandRunner GetCommandRunner(string choice)
        {
            switch (choice)
            {
                case CommandConstants.AddBook:
                    return new AddBookCommandRunner(libraryService, consoleWrapper);
                case CommandConstants.DisplayAvailableBooks:
                    return new DisplayBookCommandRunner(libraryService, consoleWrapper);
                case CommandConstants.BorrowBook:
                    return new BorrowBookCommandRunner(libraryService, consoleWrapper);
                case CommandConstants.ReturnBook:
                    return new ReturnBookCommandRunner(libraryService, consoleWrapper);
                case CommandConstants.Quit:
                    return new QuitCommandRunner(libraryService, consoleWrapper);
                default:
                    throw new InvalidCommandException();
            }
        }
    }
}

