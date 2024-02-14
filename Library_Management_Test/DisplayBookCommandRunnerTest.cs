using System;
using Library_Management.Abstracts;
using Library_Management.Concretes.CommandRunners;
using Moq;

namespace Library_Management_Test
{
	public class DisplayBookCommandRunnerTest
    {
        private Mock<ILibraryService> mockLibraryService;
        private Mock<IConsoleWrapper> mockConsoleWrapper;
        private CommandRunner commandRunner;

        [SetUp]
        public void Setup()
        {
            mockLibraryService = new Mock<ILibraryService>();
            mockConsoleWrapper = new Mock<IConsoleWrapper>();
            commandRunner = new DisplayBookCommandRunner(mockLibraryService.Object, mockConsoleWrapper.Object);
        }

        [Test]
        public void RunCommand_BorrowBook_Passed()
        {

            commandRunner.RunCommand();

            mockLibraryService.Verify(l => l.DisplayBooks(), Times.Once);
        }
    }
}

