using System;
using System.Collections.Generic;
using System.IO;

namespace NotesConsole
{
    public class Statistics
    {
       
        private readonly string[] _notes;
        

        public Statistics(string path, string fileName)
        {
            var file = path + fileName;
            _notes = File.ReadAllLines(file);
        }

        public string GetNote(int index)
        {
            return _notes[index];
        }

        public string GetUsername(int index)
        {
            const int startIndex = 32;
            return _notes[index].Substring(startIndex, _notes[index].LastIndexOf(" |", StringComparison.Ordinal) - startIndex);
        }

        public string GetDate(int index)
        {
            return _notes[index].Substring(0, 9);
        }

        
        //Locates duplicate names in the list of notes and returns a list without duplicates.
        public List<string> GetUsernames()
        {
            
            var usernameList = new List<string>();
            for (var i = 0; i < _notes.Length; i++)
            {
                var username = GetUsername(i);
                usernameList.Add(username);
            }

            //Sort algorithm that finds duplicates in a list and removes them
            for (var a = 0; a < 2; a++)
            {
                for (var i = 0; i < usernameList.Count; i++)
                {
                    var count = 0;
                    var name = usernameList[i];

                    for (var j = i; j < usernameList.Count; j++)
                    {
                        if (name != usernameList[j]) continue;
                        count++;
                        if (count > 1)
                            usernameList.RemoveAt(j);
                    }
                }
            }
            
            return usernameList;
        }


        public string TroublesomeUser()
        {
            var highestInstance = 0;
            var mostTroubleUser = "";

            foreach (var username in GetUsernames())
            {
                var count = 0;

                for (var i = 0; i < _notes.Length; i++)
                {
                    if (username == GetUsername(i))
                        count++;
                }

                if (count > highestInstance)
                {
                    highestInstance = count;
                    mostTroubleUser = username;
                }

            }

            return mostTroubleUser;
        }

        public DateTime BusiestTime()
        {
            
        }

        //Returns the index of the Longest Note.
        public int LongestNote()
        {
            var noteIndex = 0;
            var longestNote = 0;
            for (var i = 0; i < _notes.Length; i++)
            {
                if (GetNote(i).Length > longestNote)
                {
                    longestNote = GetNote(i).Length;
                    noteIndex = i;
                }
                    
            }

            return noteIndex;
        }

        //Searches the text file for a specified string
        public int SearchAndCount(string search)
        {
            var count = 0;

            for (var i = 0; i < _notes.Length; i++)
            {
                if (search == GetUsername(i))
                {
                   count += 1;
                } 
            }

            return count;
        }
    }
}