using System;
using System.Collections.Generic;
using System.Text;

namespace NotesConsole
{
    public class Ui
    {
        //Main Title
        private static void Title()
        {
            Dashes();
            Console.WriteLine();
            Console.WriteLine(TextCenter("Simple Notes - V1.0"));
            Console.WriteLine();
            Dashes();
        }

        // Causes a linebreak when the text is too long and checks if there is a space 
        // before the line break, if not add a -'
        public static string ShortenText(string message)
        {
            
            var charList = new List<string>();
            if (message.Length >= Console.WindowWidth)
            {
                foreach (var character in message)
                {
                    charList.Add(character.ToString());
                }
                for (var i = 1; i < Math.Ceiling(message.Length/(double) Console.WindowWidth) + 1; i++)
                {
                    var checkLocation = ((Console.WindowWidth - 3)*i) - 1;

                    if (checkLocation%2 == 0)
                        checkLocation ++;

                    if (checkLocation + 1 >= charList.Count)
                        break;

                    if (!string.IsNullOrWhiteSpace(charList[checkLocation]) &&
                        !string.IsNullOrWhiteSpace(charList[checkLocation + 1]) &&
                        !string.IsNullOrWhiteSpace(charList[checkLocation - 1]))
                        charList[checkLocation - 1] = "-╩ " + charList[checkLocation - 1];
                    else if (string.IsNullOrWhiteSpace(charList[checkLocation - 1]))
                        charList[checkLocation - 1] = "╩ ";
                    else if (string.IsNullOrWhiteSpace(charList[checkLocation]))
                        charList[checkLocation] = " ╩ ";
                    else if(string.IsNullOrWhiteSpace(charList[checkLocation + 1]))
                        charList[checkLocation] += "╩";
                    else
                        charList[checkLocation] = "╩" + charList[checkLocation];
                }
            }

            else return message;

            var lineList = string.Join("", charList).Split('╩');

            return string.Join("\n", lineList);
        }

        //Centers the text and adds a space infront of the string incase it doesn't have one
        public static string TextCenter(string message)
        {
            var addSpace = " ";

            if (message.IndexOf(" ", StringComparison.Ordinal) != 0 && message.LastIndexOf(" ", StringComparison.Ordinal) != message.Length - 1)
                addSpace = addSpace + message + addSpace;
            else if (message.IndexOf(" ", StringComparison.Ordinal) != 0)
                addSpace += message;
            else if (message.LastIndexOf(" ", StringComparison.Ordinal) != message.Length - 1)
                addSpace = message + addSpace;


            return string.Format("{0," + ((Console.WindowWidth / 2) + addSpace.Length / 2) + "}", addSpace);
        }

        //appends as many dashes as the width of the console.
        public static void Dashes()
        {
            var dashes = new StringBuilder().Append('=', Console.WindowWidth - 1);
            Console.WriteLine(dashes);
        }

        public static void CustomMenu(params string[] customOptions)
        {
            for (var i = 0; i < customOptions.Length; i++)
            {
                Console.WriteLine(" [" + (i+1) + "]" + " - " + customOptions[i]);
            }
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

        public static void ColorText(string words, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(words);
            Console.ResetColor();
        }
    }
        
}