using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace NotesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            const string path = @"%userprofile%\desktop";

            while (true)
            {
                Options.Menu();
                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        Console.Write("Caller's Username: ");
                        var input = Console.ReadLine();
                        Console.Write("Notes: ");
                        var notes = Console.ReadLine();
                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    default:
                        Console.WriteLine("Try Again");
                        break;
                }
            }
        }
        
    }

    public class Notes
    {
        public Notes()
        {
            
        }
    }

    public class NoteFormat
    {
        
    }

    public class FileWriter
    {
        public FileWriter(string path,string writtenInfo)
        {
            using (var streamWriter = new StreamWriter(path))
            {
                if (File.Exists(path + "Call_Notes.txt"))

                streamWriter.Write(writtenInfo);
            }
        }
    }
}
