using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NotesConsole
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var path = Environment.ExpandEnvironmentVariables(@"%userprofile%\desktop\");
            const string fileName = "Call_Notes.txt";
            
            var notes = new Notes();

            while (true)
            {
                var stats = new Statistics(path, fileName);
                Ui.Clear();
                Ui.MainMenu();
                var selection = Console.ReadKey().KeyChar.ToString();
                Ui.Clear();

                switch (selection)
                {
                    case "1":

                        while (true)
                        {
                            Ui.Clear();
                            notes.ViewNotes();

                            Console.WriteLine(new StringBuilder().AppendLine().Append('=', 30));
                            Console.Write("Caller's Username: ");

                            var username = Console.ReadLine()?.Trim().ToUpper();
                            Console.Write("Notes: ");
                            var otherInfo = Console.ReadLine();
                            notes.AddNote(username,otherInfo);
                            Console.WriteLine(new StringBuilder().AppendLine().Append('=', 30));
                            Console.WriteLine("Another Note [Any Key] | Generate Message [1] | Main Menu [2]");
                            var n = Console.ReadKey().KeyChar.ToString();

                            if (n == "1")
                            {
                                Console.WriteLine(Notes.FormatNote(otherInfo));
                                Ui.Continue();
                            }
                            else if (n == "2" ){break;}
                                


                        }
                        Ui.Clear();
                        var fileLog = new FileLogger();
                        var file = new FileWriter(path, fileName, notes.NoteList);

                        fileLog.LogInfo("Autosaving Notes to file...");
                        file.Write();
                        fileLog.LogInfo("Complete!");
                        notes.RemoveNotes();
                        Ui.Continue();
                        break;

                    case "2":


                        break;

                    case "3":
                        Ui.CustomMenu("Today's Notes","Yesterday's Notes","All Notes", "Specified Date of Notes");
                        var nOption = Console.ReadKey().KeyChar.ToString();
                        Ui.Clear();
                        switch (nOption)
                        {
                            case "1":
                                
                                break;

                            case "2":
                                var subtract = new TimeSpan(1,0,0,0);
                                var yesterday = DateTime.Today.Date - subtract;
                                foreach (var s in stats.NotesFromDate(yesterday.ToString(CultureInfo.InvariantCulture)))
                                {
                                    Console.WriteLine(s);
                                }
                                break;

                            case "3":
                                foreach (var note in stats.GetNotes())
                                {
                                    Console.WriteLine(note);
                                }
                                break;

                            case "4":

                                Console.Write("Enter a date (mm/dd/yyyy): ");
                                var dateOption = Console.ReadLine();
                                var dateNotes = stats.NotesFromDate(dateOption);
                                Ui.Clear();

                                foreach (var dateNote in dateNotes)
                                {
                                    Console.WriteLine(dateNote);
                                }

                                break;

                            default:
                                Ui.IncorrectOption();
                                break;
                               
                        }
                        Ui.Continue();
                        break;

                    case "4":

                        Ui.AdditionalOptions();
                        var aOption = Console.ReadKey().KeyChar.ToString();
                        Ui.Clear();

                        switch (aOption)
                        {
                            case "1":
                                Console.WriteLine(stats.TroublesomeUser() +" required your assistance for a total of: "
                                                 +stats.SearchAndCountUsernames(stats.TroublesomeUser()) + " times!");
                                break;
                            case "2":
                                Console.WriteLine("The day you received the most calls was:\n\n" + stats.BusiestTime() 
                                                 +"\n\nWith a total of " + stats.SearchAndCountDates(stats.BusiestTime()) + " times!");
                                break;
                            case "3":
                                Console.WriteLine("The most common word recorded is:\n\n" + stats.MostCommonWord() 
                                                 +"\n\nWith a total of " + stats.CommonWordCount + " words!");
                                break;

                            case "4":
                                Console.WriteLine("Your longest note is:\n\n" + stats.GetNote(stats.LongestNote()) 
                                                 +"\n\nWith a total of " + stats.GetNote(stats.LongestNote()).Length + " characters!");
                                break;

                            case "5":
                                foreach (var name in stats.GetUsernames())
                                    Console.WriteLine(name);
                                break;

                            default:
                                Ui.IncorrectOption();
                                break;
                        }
                        Ui.Continue();
                        break;
                    case "5":
                        Ui.CustomMenu("Quick Assistance","Export Notes to Excel","Important Links","Personal Notes","Pay Raise","Service Desk Chatroom","Announcements");
                        Ui.Continue();
                        break;
                    default:
                        Ui.IncorrectOption();
                        Ui.Continue();
                        break;

                }
            }
        }

    }
}
