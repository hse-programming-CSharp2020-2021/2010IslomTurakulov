using System;
using System.Collections;

namespace Lesson_1
{
    class Program
    {

        static void Main(string[] args)
        {
            // Массивы

            int n;
           
            do
            {
                Console.Write("Введите кол-во элементов массива: ");

            } while (!int.TryParse(Console.ReadLine(), out n));

            int[] b = new int[n];
            int[] a = new int[n];
            int[] newArray = new int[n * 2]; 

            Random rnd = new Random();

            Console.WriteLine("Массив B:");
            for (int i = 0; i < b.Length; i++)
            {
                a[i] = rnd.Next(10, 50);
                b[i] = rnd.Next(10, 50);
                Console.Write($"{b[i]} | ");
            }
            Console.WriteLine("\n Массив A:");
            for (int i = 0; i < b.Length; i++) 
            {
                Console.Write($"{a[i]} | ");
            }
            //Запись массива а в конечный массив
            
        }
    }
}
