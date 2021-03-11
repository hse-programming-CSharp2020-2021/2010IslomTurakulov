using System;
using System.IO;

namespace Task_4
{
    /*Написать программу, которая читает файл со своим собственным исходным текстом,
    разыскивает в тексте все корректно записанные идентификаторы 
    (даже из строк и комментариев) 
    и сохраняет их в новом текстовом файле в алфавитном порядке.*/

    class Program
    {
        private static Random rnd = new Random();
        static void Main(string[] args)
        {
            string[] res = new string[10];
            for (int i = 0; i < 10; i++)
            {
                res[i] =
                    $"{(char) rnd.Next(65, 90)}{(char) rnd.Next(65, 90)}{(char) rnd.Next(65, 90)}{(char) rnd.Next(65, 90)}";
            }
            Console.WriteLine("Было: ");
            Array.ForEach(res, Console.WriteLine);

            Array.Sort(res, String.CompareOrdinal);
            Console.WriteLine("Стало: ");
            Array.ForEach(res, Console.WriteLine);

            using (StreamWriter sw = new StreamWriter("result.txt"))
            {
                Array.ForEach(res, s => sw.WriteLine(s));
            }
        }
    }
}
