using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static Random rnd = new Random();
        static void Main()
        {
            int n = 10;
            do
            {
                int[] ar = { 1, 2 };
                int[][] arr = new int[n][];

                for (int i = 0; i < arr.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        arr[i] = new int[2];
                        for (int j = 0; j < arr[i].Length; j++)
                        {
                            
                        }
                        continue;
                    }
                    else
                }

                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < arr[i].Length; j++)
                    {
                        Console.Write($"{arr[i][j]}\t");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }

                /*for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        Console.WriteLine(arr[i][j]);
                    }
                }*/

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}