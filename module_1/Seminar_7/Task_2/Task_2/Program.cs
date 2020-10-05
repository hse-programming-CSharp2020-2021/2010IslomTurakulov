using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numArray;
            do
            {
                do
                {
                    Console.Write("Введите N: ");

                } while (!int.TryParse(Console.ReadLine(), out numArray) || numArray < 0);

                int[][] array = new int[numArray][];
                    
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = new int[i + 1];
                    for (int j = 0; j < array[i].Length ; j++)
                    {
                        array[i][j] = (int)(34 * array[i - 1] - array[i - 2] + 2);
                    }
                }
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        Console.Write(array[i][j] + "\t");
                    }
                    Console.WriteLine("\n\n");
                }
                Console.WriteLine("\nНажмите ESC для выхода..");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
