using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NotesConsole
{
    public class Statistics
    {
        private readonly string _file;
        private readonly Dictionary<string,int> _userList = new Dictionary<string, int>();
        private string _username, _note, _storedName;

        public Statistics(string path, string fileName)
        {
            _file = path + fileName;
        }

        public string TroublesomeUser()
        {
            var count = 0;
            const int startIndex = 31;
            for (var i = 0; i < File.ReadAllLines(_file).Length; i++)
            {
                _note = File.ReadAllLines(_file)[i].ToLower();
                _username = _note.Substring(startIndex,_note.LastIndexOf(" |", StringComparison.Ordinal) - startIndex);
                
            }
            

            return _username;
        }

        public int Compare(IEnumerable<string> content)
        {
            for (var i = 0; i < content.Count(); i++)
            {
                
            }


            return
        }
    }
}