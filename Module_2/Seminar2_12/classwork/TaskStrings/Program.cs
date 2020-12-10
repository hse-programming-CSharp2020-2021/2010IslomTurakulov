using System;

namespace ConsoleApp5
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Введите строку -  ");
                StringBuilder str = new StringBuilder(Console.ReadLine());
                Console.WriteLine($"Строка  {str}");
                Console.WriteLine($"Без лишних пробелов {DeleteSpace(str)}");
                Console.WriteLine($"Больше 4 букв {ValidateStr(str)}");
                Console.WriteLine($"Начинается с гласной {Count(str)}");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        static int ValidateStr(StringBuilder str)
        {
            return DeleteSpace(str).Split().Where(x => x.Length > 4).ToArray().Count();
        }
        static string DeleteSpace(StringBuilder str)
        {
            return string.Join(" ", str.ToString().Split().Where(x => x != ""));
        }

        static int Count(StringBuilder str)
        {
            List<string> vowels = new List<string>() { "у", "е", "ы", "а", "о", "э", "ё", "и", "ю" };
            return DeleteSpace(str).Split().Where(x => vowels.IndexOf(x.First().ToString()) != -1).ToArray().Count();
        }

    }
}