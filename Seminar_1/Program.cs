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

            // Если сделать по легкому пути , то..

            foreach (var item in ListStr)
            {
                Console.Write(item + "!" );
            }
            // Task11

            Console.WriteLine("\n");

            foreach (var item in ListStr)
            {
                Console.WriteLine("-" + item + "-");
            }

            Console.ReadKey();

        }
    }
}
