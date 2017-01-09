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
            foreach(var item in NoteList)
                {
                    Console.WriteLine(item);
                }
        }

        
            

    }
}