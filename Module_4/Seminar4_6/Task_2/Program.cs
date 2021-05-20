using System;
using System.Collections.Generic;

namespace Task_2
{
    class Program
    {
        static void Result(IEnumerable<int> numbers, string name)
        {
            Console.Write($"{name}: ");
            foreach (int i in numbers)
                Console.Write($"{i} ");

            Console.WriteLine();
        }

        static void Main()
        {
            int n;
            Console.WriteLine("Введите число");
            n = int.Parse(Console.ReadLine() ?? "1");
            int[] array = new int[n];
            Random rnd = new();
            for (int i = 0; i < n; i++)
                array[i] = rnd.Next(-1000, 1001);
        }
    }
}
