using System;
namespace Library_Management.Exceptions
{
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException()
        {
        }

        public string ErrorString => "Invalid choice. Please try again.";
    }
}

