using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace NotesConsole
{
    public class Ui
    {
        private static void Title()
        {
            
            Dashes();
            Console.WriteLine();
            TextCenter("Simple Notes - V1.0");
            Console.WriteLine();
            Dashes();
        }
        //stopped here
        public static string ShortenText(string message)
        {
            var newLine = "\n";
            var shortenedMessage = message;
            var length = message.Length;
            var wordList = message.Split(' ');
            


            if (message.Length >= Console.WindowWidth)
            {
                
            }

            return shortenedMessage;
        }

        public static void TextCenter(string message)
        {
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + message.Length / 2) + "}", message);
        }

        public static void Dashes()
        {
            var dashes = new StringBuilder().Append('=', Console.WindowWidth);
            TextCenter(dashes.ToString());
        }

        public static void CustomMenu(params string[] customOptions)
        {
            for (var i = 0; i < customOptions.Length; i++)
            {
                Console.WriteLine(" [" + (i+1) + "]" + " - " + customOptions[i]);
            }
        }

        public static void NoteMenu(string username, string original, string format)
        {
            Console.WriteLine(" Username: " + username);
            Console.WriteLine();
            Console.WriteLine(" Original Note: " + original);
            Console.WriteLine();
            Console.WriteLine(" Formatted Note: " + format);

        }

        public static void MainMenu()
        {
            var builder = new StringBuilder();
            builder
                .Append(" [1] - New Note")
                .AppendLine()
                .Append(" [2] - View Notes")
                .AppendLine()
                .Append(" [3] - Additional Options")
                .AppendLine()
                .Append(" [4] - Upcoming Features")
                .AppendLine();

            Console.WriteLine(builder);
        }

        public static void AdditionalOptions()
        {
            
            var builder = new StringBuilder();
            builder
                .Append(" [1] - Most Troublesome User")
                .AppendLine()
                .Append(" [2] - Most Busiest Day")
                .AppendLine()
                .Append(" [3] - Most Common Word Recorded")
                .AppendLine()
                .Append(" [4] - Longest Information Recorded")
                .AppendLine()
                .Append(" [5] - All Users Entered");

            Console.WriteLine(builder);
                
        }

        public static void Clear()
        {
            Console.Clear();
            Title();
        }

        public static void Continue()
        {
            Dashes();
            Console.WriteLine(" Press any key to go back to the main menu...");
            Console.ReadKey().Key.ToString();
            
        }

        public static void Continue(string instruction)
        {
            Dashes();
            Console.WriteLine(instruction);
            Console.ReadKey().Key.ToString();

        }


        public static void IncorrectOption()
        {
            Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Incorrect Option Selected...");
            Console.ResetColor();
            
        }
    }
        
}