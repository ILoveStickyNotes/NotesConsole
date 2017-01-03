using System;
using System.Text;

namespace NotesConsole
{
    public class Options
    {
        public static void Menu()
        {
            var builder = new StringBuilder();
            builder
                .Append("Simple Notes - v1.0")
                .AppendLine()
                .Append('-', 30)
                .AppendLine()
                .Append("1 - New Note")
                .AppendLine()
                .Append("2 - Note List")
                .AppendLine()
                .Append("3 - Save Notes to Excel");
            Console.WriteLine(builder);
        }
    }
}