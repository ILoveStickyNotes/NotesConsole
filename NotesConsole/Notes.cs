using System;
using System.Collections.Generic;
using System.Threading;

namespace NotesConsole
{
    public class Notes
    {
        public List<string> NoteList = new List<string>();

        public void AddNote(string username, string notes)
        {
            NoteList.Add(string.Join(" | ", DateTime.Now.ToString("g"),"Username: " + username,"Info: " + notes));
            Console.WriteLine(NoteList[0]);
        }

        public void ViewNotes()
        {
            var fileLogger = new FileLogger();
            if (NoteList.Count == 0)
            {
                fileLogger.LogError("Error. No notes found");
                Thread.Sleep(3000);
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