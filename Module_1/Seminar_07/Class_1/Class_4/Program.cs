using System;
using System.Security.Cryptography.X509Certificates;

namespace Class_4
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                uint n;
                do
                {
                    Console.WriteLine("Введите высоту: ");
                } while (!uint.TryParse(Console.ReadLine(), out n));

                int[][] b = new int[n][];
                //Output second array.
                for (int i = 0; i < n; i++)
                    b[i] = new string[i + 1];

                for (int i = 0; i < b[i].Length; i++)
                {

                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < b.Length; j++)
                    {
                        if (j == n / 2) b[i][j] = '*';
                        Console.Write($"{(char)b[i][j],3}");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                Console.WriteLine("Нажмите ESC чтобы выйти");

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
