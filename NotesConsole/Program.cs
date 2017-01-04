using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NotesConsole
{
    class Program
    {
        private static void Main(string[] args)
        {
            var path = Environment.ExpandEnvironmentVariables(@"%userprofile%\desktop\");
            const string fileName = "Call_Notes.txt";
            
            var notes = new Notes();
            while (true)
            {
                Ui.Clear();
                Ui.MainMenu();
                
                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":

                        while (true)
                        {
                            Ui.Clear();
                            Console.Write("Caller's Username: ");
                            var username = Console.ReadLine();
                            Console.Write("Notes: ");
                            var otherInfo = Console.ReadLine();
                            notes.AddNote(username,otherInfo);
                            if(Ui.Continue("Continue [Y] | Main Menu [N]", "Y"))
                                break;
                            
                        }
                        break;

                    case "2":

                        var fileLog = new FileLogger();
                        var file = new FileWriter(path, fileName ,notes.NoteList);
                        Ui.Clear();
                        
                        fileLog.LogInfo("Writing Notes to file...");
                        Thread.Sleep(3000);
                        file.Write();
                        fileLog.LogInfo("Complete!");
                        Thread.Sleep(3000);

                        break;

                    case "3":
                        Ui.Clear();
                        notes.ViewNotes();
                        Ui.Continue();
                        break;

                    case "4":
                        Ui.Clear();
                        Ui.AdditionalOptions();
                        var aOption = Console.ReadLine();
                        var stats = new Statistics(path, fileName);
                        Ui.Clear();
                        switch (aOption)
                        {
                            case "1":
                                Console.WriteLine(stats.TroublesomeUser());
                                Ui.Continue("Press any key to go back...");
                                break;
                            case "2":

                                break;
                            case "3":

                                break;
                            case "4":

                                break;
                            case "5":

                                break;
                            default:

                                break;
                        }

                        break;

                    default:
                        Ui.IncorrectOption();
                        break;
                }
            }
        }

    }
}
