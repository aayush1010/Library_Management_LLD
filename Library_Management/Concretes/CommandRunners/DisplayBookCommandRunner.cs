using Library_Management.Abstracts;
using Library_Management.Services;

namespace Library_Management.Concretes.CommandRunners
{
    public class DisplayBookCommandRunner : CommandRunner
    {
        public DisplayBookCommandRunner(ILibraryService libraryService, IConsoleWrapper consoleWrapper) : base(libraryService, consoleWrapper)
        {
        }

        public override void RunCommand()
        {
            libraryService.DisplayBooks();
        }
    }
}

