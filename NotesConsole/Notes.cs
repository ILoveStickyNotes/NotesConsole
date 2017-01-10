using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NotesConsole
{
    public class Notes
        
    {

        private int _counter = 0;
        public readonly List<string> NoteList = new List<string>();

        public string RecentNote => NoteList[_counter - 1];


        public void AddNote(string username, string notes)
        {
            NoteList.Add(string.Join(" | ", DateTime.Now.ToString("g"),"Username: " + username,"Info: " + notes));
            _counter++;
        }

        public void ViewNotes()
        {
            foreach(var item in NoteList)
                {
                    Console.WriteLine(item);
                }
        }

        public void RemoveNotes()
        {
            NoteList.RemoveRange(0, NoteList.Count);
        }

        public static string FormatNote(string note)
        {
            
            var formattedNote = "";
            var keyWords = new List<string>{"13430", "TL44000R90", "TT430000", "AL44000R90", "A0M7300MJ","AY26000MP", @"\\es", @"\\ms", @"\\hs", @"\\s002madprint\"};
            var foundKeywords = new List<List<string>> {new List<string>(), new List<string>(), new List<string>()};
            var words = new List<string>(note.Split(' '));

            foreach (var word in words)
            {
                if (word.Contains("13430"))
                {
                    foundKeywords[(int)ItemType.Asset].Add(word);
                }
                else if (word.Contains("TL44000R90") || word.Contains("TT430000") || word.Contains("AL44000R90") || word.Contains("A0M7300MJ") || word.Contains("AY26000MP"))
                {
                    foundKeywords[(int)ItemType.Computer].Add(word);
                }
                else if (word.Contains(@"\\es") || word.Contains(@"\\ms") || word.Contains(@"\\hs") || word.Contains(@"\\s002madprint\"))
                {
                    foundKeywords[(int)ItemType.Printer].Add(word);
                }
            }

            for (var j = 0; j < 5; j++)
            {
                foreach (var keyWord in keyWords)
                {
                    for (var i = 0; i < words.Count; i++)
                    {
                        if (words[i].Contains(keyWord))
                        {
                            words.Remove(words[i]);
                        }
                    }
                }
            }
            //Problem here
            if (string.IsNullOrWhiteSpace(foundKeywords[0][0]))
            {
                formattedNote =
                 $"{string.Join(" ", words)} " +
                 $"{ItemType.Asset} ID(s): {string.Join(" ", foundKeywords[0])} " +
                 $"{ItemType.Computer} Name(s): {string.Join(" ", foundKeywords[1])} " +
                 $"{ItemType.Printer} Name(s): {string.Join(" ", foundKeywords[2])} ";
            }
            else if (string.IsNullOrWhiteSpace(foundKeywords[1][0]))
            {
                formattedNote =
                $"{string.Join(" ", words)} " +
                $"{ItemType.Asset} ID(s): {string.Join(" ", foundKeywords[0])} " +
                $"{ItemType.Printer} Name(s): {string.Join(" ", foundKeywords[2])} ";
            }
            else if (string.IsNullOrWhiteSpace(foundKeywords[2][0]))
            {
                formattedNote =
                    $"{string.Join(" ", words)} " +
                    $"{ItemType.Asset} ID(s): {string.Join(" ", foundKeywords[0])} " +
                    $"{ItemType.Computer} Name(s): {string.Join(" ", foundKeywords[1])} ";
            }
            else if (string.IsNullOrWhiteSpace(foundKeywords[0][0]) && string.IsNullOrWhiteSpace(foundKeywords[1][0]))
            {
                formattedNote =
                 $"{string.Join(" ", words)} " +
                 $"{ItemType.Printer} Name(s): {string.Join(" ", foundKeywords[2])} ";
            }
            else if (string.IsNullOrWhiteSpace(foundKeywords[0][0]) && string.IsNullOrWhiteSpace(foundKeywords[2][0]))
            {
                formattedNote =
                    $"{string.Join(" ", words)} " +
                    $"{ItemType.Computer} Name(s): {string.Join(" ", foundKeywords[1])} ";
            }
            else if (string.IsNullOrWhiteSpace(foundKeywords[1][0]) && string.IsNullOrWhiteSpace(foundKeywords[2][0]))
            {
                formattedNote =
                    $"{string.Join(" ", words)} " +
                    $"{ItemType.Asset} ID(s): {string.Join(" ", foundKeywords[0])} ";
            }
            else
            {
                formattedNote =
                 $"{string.Join(" ", words)} " +
                 $"{ItemType.Asset} ID(s): {string.Join(" ", foundKeywords[0])} " +
                 $"{ItemType.Computer} Name(s): {string.Join(" ", foundKeywords[1])} " +
                 $"{ItemType.Printer} Name(s): {string.Join(" ", foundKeywords[2])} ";
            }
            
            
            return formattedNote;

        }

        private enum ItemType
        {
            Asset,
            Computer,
            Printer
        }
    }

    
}