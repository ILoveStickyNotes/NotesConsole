using System.Collections.Generic;
using System.IO;

namespace NotesConsole
{
    public class FileWriter
    {
        private static string _file;
        private static IEnumerable<string> _contents;

        public FileWriter(string path, string fileName, IEnumerable<string> contents)
        {
            _file = path + fileName;
            _contents = contents;
        }

        public void Write()
        {
            
            File.AppendAllLines(_file,_contents);
        }
    }
}