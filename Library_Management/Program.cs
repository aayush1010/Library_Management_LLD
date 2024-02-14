using System;
using Library_Management.Abstracts;
using Library_Management.Concretes;
using Library_Management.Entities;
using Library_Management.Exceptions;
using Library_Management.Factory;
using Library_Management.Services;

class Program
{
    static void Main()
    {
        IConsoleWrapper consoleWrapper = new ConsoleWrapper();
        LibraryService libraryService = new LibraryService(new Library(), consoleWrapper);
       
        var commandRunnerFactory = new CommandRunnerFactory(libraryService, consoleWrapper);

        while (true)
        {
            try
            {
                Console.WriteLine("\nLibrary Management System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Display Available Books");
                Console.WriteLine("3. Borrow Book");
                Console.WriteLine("4. Return Book");
                Console.WriteLine("5. Quit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                commandRunnerFactory.GetCommandRunner(choice).RunCommand();
                if (choice == Library_Management.Constants.CommandConstants.Quit)
                {
                    break;
                }
            }
            catch(InvalidCommandException ie)
            {
                Console.WriteLine(ie.ErrorString);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Occured", ex);
            }
        }
    }
}
