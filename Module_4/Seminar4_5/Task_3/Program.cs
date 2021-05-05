using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Task_3
{
    public class FileLines : IEnumerable<string>
    {
        private string _filePath;
 
        public FileLines(string filePath) => _filePath = filePath;
        
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        public IEnumerator<string> GetEnumerator()
        {
            using var fileStream = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
            using var streamReader = new StreamReader(fileStream);
            while (streamReader.Peek() > -1)
            {
                yield return streamReader.ReadLine();
            }
        }

    }
 
    class Program
    {
        static void Main(string[] args)
        {
            var fileLines = new FileLines("output.txt");
 
            foreach (var line in fileLines)
                Console.WriteLine(line);
        }
    }
}