using System;
using System.Collections.Generic;
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
            var fileLogger = new FileLogger();
            if (NoteList.Count == 0)
            {
                fileLogger.LogError("Error. No notes found in current session.");
                
            }
            else
            {
                foreach(var item in NoteList)
                {
                    Console.WriteLine(item);
                }

            }
            
            
           
        }

    }
}