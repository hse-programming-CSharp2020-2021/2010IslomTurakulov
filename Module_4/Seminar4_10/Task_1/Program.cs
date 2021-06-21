using System;
using System.Text.RegularExpressions;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            MatchCollection linksCollection = Regex.Matches(line,
                @"[A-Za-z][0-9]-[A-Za-z][0-9]", RegexOptions.IgnoreCase);
            foreach (Match link in linksCollection)
            {
                Console.WriteLine($@"{link}");
            }
        }
    }
}
