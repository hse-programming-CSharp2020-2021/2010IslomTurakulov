using System;
using System.IO;

namespace Lesson_1
{
    class Program
    {
        static int NumberRev(int x)
        {
            return x < 2 ? x % 2 : (x % 2) + 10 * NumberRev(x / 2);
        }

        static void Main(string[] args)
        {
            int number;
            string[] array;
            string path = @"test.txt";
            do
            {
                Console.Write("Напишите целое неотрицательное число: ");
            } while (!int.TryParse(Console.ReadLine(), out number) || number<0);
             NumberRev(number);
            if (number >= 0)
            {
                array = new string[number];

                File.WriteAllLines("test.txt", array);
                if (!File.Exists(path))
                {
                    Console.WriteLine("Я ничего не нашёл =(");
                }
                else
                    Console.WriteLine(File.ReadAllLines(path));
            }
            else
            {
                Console.WriteLine("Данные не корректны");
            }
        }
    }
}
