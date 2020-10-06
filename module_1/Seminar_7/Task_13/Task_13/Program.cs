using System;

namespace Task_13
{
    class Program
    {
        static void CreateArray(int N, int k)
        {
            string[][] arr = new string[N][];
            for (int i = 0; i < N; i++)
            {
                arr[i] = new string[i];
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = (Math.Pow(N,k-i)).ToString();
                }
            }
            Console.WriteLine("Полученный двумерный массив:");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int N, K;
            do
            {
                Console.WriteLine("Введите число N , затем K:");

                if (!int.TryParse(Console.ReadLine(), out N) || !int.TryParse(Console.ReadLine(), out K) || K >= N || 0 > K)
                {
                    Console.WriteLine("Неккоректный ввод или K больше чем N");
                }
                else
                {
                    CreateArray(N, K);
                }
                Console.WriteLine("Нажмите ESC для выхода");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
