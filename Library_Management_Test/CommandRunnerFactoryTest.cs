using Library_Management.Abstracts;
using Library_Management.Concretes.CommandRunners;
using Library_Management.Exceptions;
using Library_Management.Factory;
using Library_Management.Services;
using Moq;

namespace Library_Management_Test;

[TestFixture]
public class CommandRunnerFactoryTest
{
    private Mock<ILibraryService> mockLibraryService;
    private Mock<IConsoleWrapper> mockConsoleWrapper;
    private CommandRunnerFactory commandRunner;
        
    [SetUp]
    public void Setup()
    {
        mockLibraryService = new Mock<ILibraryService>();
        mockConsoleWrapper = new Mock<IConsoleWrapper>();
        commandRunner = new CommandRunnerFactory(mockLibraryService.Object, mockConsoleWrapper.Object);
    }


    [TestCase("1")]
    public void AddBookCommandRunnerObjectTest(string input)
    { 

        var createdPlObj = commandRunner.GetCommandRunner(input);

        Assert.That(createdPlObj, Is.TypeOf<AddBookCommandRunner>());
    }

    [TestCase("7")]
    public void InvalidCommandRunnerTest(string input)
    { 

        Assert.That(() => commandRunner.GetCommandRunner(input), Throws.TypeOf<InvalidCommandException>());
    }
}
