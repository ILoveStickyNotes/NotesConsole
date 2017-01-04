using System;

namespace NotesConsole
{
    public class FileLogger : ILogger
    {
        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(DateTime.Now + ": " + message);
            Console.ResetColor();

        }

        public void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(DateTime.Now + " - " + message);
            Console.ResetColor();

        }
    }
}