using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace NotesConsole
{
    public class Ui
    {
        private static void Title()
        {
            var builder = new StringBuilder();
            builder
                .Append('=', 30)
                .AppendLine()
                .Append("Simple Notes - v1.0")
                .AppendLine()
                .Append('=', 30)
                .AppendLine();

            Console.WriteLine();
            Console.WriteLine(builder);

        }
        public static void MainMenu()
        {
            var builder = new StringBuilder();
            builder
                .Append("1 - New Note")
                .AppendLine()
                .Append("2 - Save Notes")
                .AppendLine()
                .Append("3 - View Notes")
                .AppendLine()
                .Append("4 - Additional Options");

            Console.WriteLine(builder);
        }

        public static void AdditionalOptions()
        {
            
            var builder = new StringBuilder();
            builder
                .Append("1 - Most Troublesome User")
                .AppendLine()
                .Append("2 - Most Busiest Day")
                .AppendLine()
                .Append("3 - Most Common Word Recorded")
                .AppendLine()
                .Append("4 - Longest Information Recorded")
                .AppendLine()
                .Append("5 - Important Links");

            Console.WriteLine(builder);
                
        }

        public static void Clear()
        {
            Console.Clear();
            Title();
        }

        public static void Continue()
        {
            Console.WriteLine(new StringBuilder().Append('=',30));
            Console.WriteLine("Press any key to go back to the main menu...");
            var key = Console.ReadKey().Key.ToString();
            
        }

        public static void Continue(string instruction)
        {
            Console.WriteLine(new StringBuilder().Append('=', 30));
            Console.WriteLine(instruction);
            var key = Console.ReadKey().Key.ToString();

        }

        public static bool Continue(string instruction, string continueKey)
        {

            Console.WriteLine(new StringBuilder().Append('=', 30));
            Console.WriteLine(instruction);
            var key = Console.ReadKey().Key.ToString();
            return (key != continueKey);
        }

        public static void IncorrectOption()
        {
            Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect Option Selected...");
            Console.ResetColor();
            Continue();
        }
    }
        
}