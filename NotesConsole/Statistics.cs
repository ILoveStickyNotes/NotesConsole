using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NotesConsole
{
    public class Statistics
    {
        private readonly string[] _notes;
        public int CommonWordCount { get; private set; }


        public Statistics(string path, string fileName)
        {
            var file = path + fileName;
            _notes = File.ReadAllLines(file);
        }

        public string GetNote(int index)
        {
            return _notes[index];
        }

        public string[] GetNotes()
        {
            return _notes;
        }

        public string GetUsername(int index)
        {
            var startIndex = (_notes[index].IndexOf("Username:", StringComparison.Ordinal) + 10);
            return _notes[index].Substring(startIndex , _notes[index].LastIndexOf(" |", StringComparison.Ordinal) - startIndex);
        }

        public string GetDate(int index)
        {
            return _notes[index].Substring(0, 10);
        }

        public string GetInfo(int index)
        {
            return _notes[index].Substring(_notes[index].IndexOf("Info:", StringComparison.Ordinal) + 6);
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

        public string BusiestTime()
        {
            var max = 0;
            var noteIndex = 0;

            for (var i = 0; i > _notes.Length; i++)
            {
                var count = 0;
                foreach (var comparedDate in _notes)
                {
                    if (GetDate(i) == comparedDate)
                        count++;
                }

                if (count > max)
                {
                    max = count;
                    noteIndex = i;

                }
            }
            return GetDate(noteIndex);
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

        public string MostCommonWord()
        {
            var allWords = new List<string>();
            var max = 0;
            var commonWord = "";

            for (var i = 0; i < _notes.Length; i++)
            {
                var info = GetInfo(i);
                var words = info.Split(' ');

                allWords.AddRange(words);

                foreach (var word in words)
                {
                    if (word == "the")
                    {
                        allWords.Remove(word);
                    }
                }
            }
            
            foreach (var word in allWords)
            {
                var count = allWords.Count(item => word == item);

                if (count > max)
                {
                    max = count;
                    commonWord = word;
                }
            }
            CommonWordCount = max;
            return commonWord;
        }

        //Searches the text file for a username and how many times its in there
        public int SearchAndCountUsernames(string search)
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

        //Searches the text file for a date and how many times its in there
        public int SearchAndCountDates(string search)
        {
            var count = 0;
            for (var i = 0; i < _notes.Length; i++)
            {
                if (search == GetDate(i))
                {
                    count++;
                }
            }
            return count;
        }

        public string[] NotesFromDate(string date)
        {
            var notelist = new List<string>();
            for (var i = 0; i < _notes.Length; i++)
            {
                if (date.Contains(GetDate(i)))
                {
                    notelist.Add(_notes[i]);
                }
            }

            return notelist.ToArray();
        }
    }
}