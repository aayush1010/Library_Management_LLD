using Library_Management.Abstracts;
using Library_Management.Concretes.CommandRunners;
using Moq;

namespace Library_Management_Test
{
	public class QuitCommandRunnerTest
    {
        private Mock<ILibraryService> mockLibraryService;
        private Mock<IConsoleWrapper> mockConsoleWrapper;
        private CommandRunner commandRunner;

        [SetUp]
        public void Setup()
        {
            mockLibraryService = new Mock<ILibraryService>();
            mockConsoleWrapper = new Mock<IConsoleWrapper>();
            commandRunner = new QuitCommandRunner(mockLibraryService.Object, mockConsoleWrapper.Object);
        }

        [Test]
        public void RunCommand_Quit_Passed()
        {
            commandRunner.RunCommand();

            mockConsoleWrapper.Verify(c => c.WriteLine("Exiting the library system."), Times.Once);

        }
    }
}

