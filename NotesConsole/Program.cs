using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NotesConsole
{
    public class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            const string windowTitle = "Simple Notes - V1.0 - by Michael Bui";
            Console.Title = windowTitle;
            Console.WindowHeight = 31;
            Console.WindowWidth = 63;
            var fileLog = new FileLogger();
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

                                        
                            Ui.Dashes();
                            Console.WriteLine();

                            Console.Write(" Caller's Username: ");
                            var username = Console.ReadLine()?.Trim().ToUpper();
                            if (string.IsNullOrEmpty(username)) username = "N/A";
                            
                            Console.Write(" Notes: ");
                            var otherInfo = Console.ReadLine()?.Trim();
                            if (string.IsNullOrEmpty(otherInfo)) otherInfo = "N/A";

                            notes.AddNote(username, otherInfo);
                            Console.WriteLine();
                            fileLog.LogInfo(" Copied note to Clipboard!", ConsoleColor.Cyan);
                            Ui.Dashes();
                            Console.WriteLine(" Another Note [Any Key] | Format & Copy Note [1] | Main Menu [2]");
                            var n = Console.ReadKey().KeyChar.ToString();


                            if (n == "1")
                            {
                                var formattedNote = Notes.FormatNote(otherInfo);
                                Ui.Clear();
                                Ui.NoteMenu(username, otherInfo, formattedNote);
                                if (formattedNote != null)
                                    Clipboard.SetText(formattedNote);
                                Console.WriteLine();
                                fileLog.LogInfo(" Copied formatted note to Clipboard!", ConsoleColor.Cyan);
                                Ui.Dashes();
                                Console.Write(" Another Note [Any Key] | Copy Username [1] | Copy Original [2] | Copy Formatted [3] | Main Menu [4]");

                                while (true)
                                {
                                    var x = Console.ReadKey().KeyChar.ToString();

                                    if (x == "1")
                                    {
                                        Clipboard.SetText(username);
                                        Console.WriteLine();
                                        fileLog.LogInfo(" Copied username to Clipboard!", ConsoleColor.Cyan);
                                    }
                                    else if (x == "2")
                                    {
                                        Clipboard.SetText(otherInfo);
                                        Console.WriteLine();
                                        fileLog.LogInfo(" Copied original note to Clipboard!", ConsoleColor.Cyan);
                                    }
                                    else if (x == "3")
                                    {
                                        Clipboard.SetText(formattedNote);
                                        Console.WriteLine();
                                        fileLog.LogInfo(" Copied formatted note to Clipboard!", ConsoleColor.Cyan);
                                    }

                                    else if (x == "4") goto End;

                                    else break;
                                }
                            }
                            else if (n == "2")
                            {
                               break;
                            }
                        }

                        End:
                        Ui.Clear();

                        var file = new FileWriter(path, fileName, notes.NoteList);

                        fileLog.LogInfo("Autosaving Notes to file...");
                        file.Write();
                        fileLog.LogInfo("Complete!");
                        notes.RemoveNotes();
                        Ui.Continue();
                        break;


                    case "2":
                        Ui.CustomMenu("Today's Notes", "Yesterday's Notes", "All Notes", "Specified Date of Notes");
                        var nOption = Console.ReadKey().KeyChar.ToString();
                        Ui.Clear();
                        switch (nOption)
                        {
                            case "1":

                                break;

                            case "2":
                                var subtract = new TimeSpan(1, 0, 0, 0);
                                var yesterday = DateTime.Today.Date - subtract;
                                foreach (var s in stats.NotesFromDate(yesterday.ToString(CultureInfo.InvariantCulture)))
                                    Console.WriteLine(s);
                                break;

                            case "3":
                                foreach (var note in stats.GetNotes())
                                    Console.WriteLine(note);
                                break;

                            case "4":

                                Console.Write(" Enter a date (mm/dd/yyyy): ");
                                var dateOption = Console.ReadLine();
                                var dateNotes = stats.NotesFromDate(dateOption);
                                Ui.Clear();

                                foreach (var dateNote in dateNotes)
                                    Console.WriteLine(dateNote);

                                break;

                            default:
                                Ui.IncorrectOption();
                                break;
                        }
                        Ui.Continue();
                        break;

                    case "3":

                        Ui.AdditionalOptions();
                        var aOption = Console.ReadKey().KeyChar.ToString();
                        Ui.Clear();

                        switch (aOption)
                        {
                            case "1":
                                Ui.TextCenter(stats.TroublesomeUser() + " required your assistance for a total of " +
                                              stats.SearchAndCountUsernames(stats.TroublesomeUser()) + " times!");
                                break;

                            case "2":
                                Ui.TextCenter("The day you received the most calls was: " + stats.BusiestTime());
                                Console.WriteLine();
                                Ui.TextCenter("For a total of " + stats.SearchAndCountDates(stats.BusiestTime()) +
                                              " time(s)!");            
                                break;

                            case "3":
                                Ui.TextCenter("The most common word recorded is:\n\n" + stats.MostCommonWord());
                                Console.WriteLine();
                                Ui.TextCenter("With a total of " + stats.CommonWordCount + " word(s)!");
                                break;

                            case "4":
                                Ui.TextCenter(" Your longest note is from: " + stats.GetUsername(stats.LongestNote()));
                                Console.WriteLine(" Which is: " + stats.GetInfo(stats.LongestNote()));
                                
                                Ui.TextCenter("With a total of " + stats.GetNote(stats.LongestNote()).Length + " characters!");
                                    
                                break;

                            case "5":
                                foreach (var name in stats.GetUsernames())
                                    Ui.TextCenter(name);
                                break;

                            default:
                                Ui.IncorrectOption();
                                break;
                        }
                        Ui.Continue();
                        break;
                    case "4":
                        Ui.CustomMenu("Quick Assistance", "Export Notes to Excel", "Important Links", "Personal Notes",
                            "Pay Raise", "Service Desk Quick Questions", "Announcements");
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
