namespace Library_Management.Abstracts
{
    public interface IConsoleWrapper
    {
        string ReadLine();
        void Write(string value);
        void WriteLine(string value);
    }
}

