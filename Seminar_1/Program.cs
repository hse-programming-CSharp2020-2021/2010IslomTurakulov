using System;
using System.Collections.Generic;
using System.Linq;

namespace Seminar_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstStr, secondStr, thirdStr;

            var ListStr = new List<string>();

            Console.WriteLine("Введите ваше слово");
            ListStr.Add(Console.ReadLine());

            Console.WriteLine("Введите ваше второе слово");
            ListStr.Add(Console.ReadLine());

            Console.WriteLine("Введите ваше третье слово");
            ListStr.Add(Console.ReadLine());

            // Используем цикл Foreach для перебора элементов

            foreach (var item in ListStr)
            {
                Console.Write($"{item} !" );
            }

            // Второе задание Task11

            Console.WriteLine("\n");

            // Используем цикл foreach для перебора элементов
            foreach (var item in ListStr)
            {
                Console.WriteLine($"- {item} -");
            }

            Console.ReadKey();
        }
    }
}
