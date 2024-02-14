using System;
using Library_Management.Abstracts;

namespace Library_Management.Concretes
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string value)
        {
            Console.WriteLine(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}

