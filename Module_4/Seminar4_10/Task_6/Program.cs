using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task_6
{
    class Program
    {
        static Random random = new ();
        static void Main(string[] args)
        {
            List<string> locations = new List<string>()
            {
                "Велене",
                "Каер Морхене",
                "Туссенте",
                "Новиграде"
            };
            string line = Console.ReadLine();
            MatchCollection linksCollection = Regex.Matches(line,
                @"Code[0-9]*");
            foreach (Match link in linksCollection)
            {
                int price = random.Next(500, 10000);
                Console.WriteLine($@"Зелье {link} был куплен в {locations[(random.Next(1, 4))]} за {price} руб");
            }
        }
    }
}
