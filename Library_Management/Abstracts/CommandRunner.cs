namespace Library_Management.Abstracts
{
    public abstract class CommandRunner
    {
        protected readonly ILibraryService libraryService;
        protected readonly IConsoleWrapper consoleWrapper;

        public CommandRunner(ILibraryService libraryService, IConsoleWrapper consoleWrapper)
        {
            this.libraryService = libraryService;
            this.consoleWrapper = consoleWrapper;
        }

        public abstract void RunCommand();
    }
}

