using Library_Management.Abstracts;
using Library_Management.Concretes.CommandRunners;
using Moq;

namespace Library_Management_Test
{
	[TestFixture]
	public class AddBookCommandRunnerTest
	{

        private Mock<ILibraryService> mockLibraryService;
        private Mock<IConsoleWrapper> mockConsoleWrapper;
        private CommandRunner commandRunner;

        [SetUp]
        public void Setup()
        {
            mockLibraryService = new Mock<ILibraryService>();
            mockConsoleWrapper = new Mock<IConsoleWrapper>();
            commandRunner = new AddBookCommandRunner(mockLibraryService.Object, mockConsoleWrapper.Object);
        }

        [Test]
        public void RunCommand_AddsBook_WhenValidInputProvided()
        {
            var userInput = new Queue<string>(new[] { "ABC", "Aayush", "1" });
            mockConsoleWrapper.SetupSequence(c => c.ReadLine()).Returns(userInput.Dequeue()).Returns(userInput.Dequeue()).Returns(userInput.Dequeue());

            commandRunner.RunCommand();

            mockLibraryService.Verify(x => x.AddBook("ABC", "Aayush", 1),Times.Once);
        }


        [Test]
        public void RunCommand_AddBook_WhenInvalidInputProvided()
        {
            var userInput = new Queue<string>(new[] { "ABC", "Aayush", "abc", "0", "1" });
            mockConsoleWrapper.SetupSequence(c => c.ReadLine()).Returns(userInput.Dequeue()).Returns(userInput.Dequeue()).Returns(userInput.Dequeue())
                .Returns(userInput.Dequeue()).Returns(userInput.Dequeue());

            commandRunner.RunCommand();

            mockLibraryService.Verify(x => x.AddBook("ABC", "Aayush", 1), Times.Once);
        }

    }
}

