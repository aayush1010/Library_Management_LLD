﻿using System;
using Library_Management.Abstracts;
using Library_Management.Concretes.CommandRunners;
using Moq;

namespace Library_Management_Test
{
	public class BorrowBookCommandRunnerTest
	{
        private Mock<ILibraryService> mockLibraryService;
        private Mock<IConsoleWrapper> mockConsoleWrapper;
        private CommandRunner commandRunner;

        [SetUp]
        public void Setup()
        {
            mockLibraryService = new Mock<ILibraryService>();
            mockConsoleWrapper = new Mock<IConsoleWrapper>();
            commandRunner = new BorrowBookCommandRunner(mockLibraryService.Object, mockConsoleWrapper.Object);
        }

        [Test]
        public void RunCommand_BorrowBook_Passed()
        {
            mockConsoleWrapper.SetupSequence(c => c.ReadLine()).Returns("ABC");

            commandRunner.RunCommand();

            mockConsoleWrapper.Verify(c => c.Write("Enter the title of the book you want to Borrow: "), Times.Once);
            mockConsoleWrapper.Verify(c => c.ReadLine(), Times.Once);
            mockLibraryService.Verify(l => l.BorrowBook("ABC"), Times.Once);
        }
    }
}

