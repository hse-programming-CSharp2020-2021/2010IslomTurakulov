using System;

namespace Class_3
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                uint r;
                do
                {
                    Console.Write("Введите размер квадратной матрицы: ");
                } while (!uint.TryParse(Console.ReadLine(), out r));

                int[,] Matrix = new int[r, r];
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < r; j++)
                    {
                        if (i == j)
                        {
                            Matrix[i, j] = 0;
                        }
                        if (j > i)
                        {
                            Matrix[i, j] = 1;
                        }
                        if (i > j)
                        {
                            Matrix[i, j] = -1;
                        }
                    }
                }

                //Выводим матрицу на экран
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < r; j++)
                    {
                        Console.Write(Matrix[i, j] + "\t");
                    }
                    Console.WriteLine("\n");
                }
                Console.WriteLine("\nНажмите ESC для выхода");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
