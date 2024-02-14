using Library_Management.Abstracts;

namespace Library_Management.Concretes.CommandRunners
{
    public class QuitCommandRunner : CommandRunner
    {
        public QuitCommandRunner(ILibraryService libraryService, IConsoleWrapper consoleWrapper) : base(libraryService, consoleWrapper)
        {
        }

        public override void RunCommand()
        {
            consoleWrapper.WriteLine("Exiting the library system.");
        }
    }
}

