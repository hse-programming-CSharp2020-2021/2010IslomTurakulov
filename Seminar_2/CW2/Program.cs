using System;
using System.Security.Cryptography;
/*
* Ввести натуральное трехзначное число Р. 
* Найти наибольшее целое число, которое можно получить, переставляя цифры числа Р.
*/
namespace CW2
{
    class Program
    {
        /// <summary>
        ///  метод возвращает наибольшее и наименьшее число
        /// </summary>
        /// <param name="c">Трёхзначное число</param>
        public static void SortValue(ref int c)
        {
            // Вспомогательные переменные
            int x = c / 100;
            int y = (c - (x * 100))/10;
            int z = c - (x * 100) - (y * 10);

            int min = x > y ? (y > z ? z : y) : (x > z ? z : x);
            int max = x > y ? (x > z ? x : y) : (y > z ? y : z);
            int middle = y > z ? (z > x ? z : (x > y ? y : x)) : (y > x ? y : (z > x ? x : z));

            c = max * 100 + middle * 10 + min; 
            Console.WriteLine($"Минимальное значение: {min} ");
            Console.WriteLine($"Среднее значение {middle} ");
            Console.WriteLine($"Максимальное значение {max} ");

        }
        static void Main(string[] args)
        {
            // Обработка исключений
            try
            {
                do
                {
                    Console.WriteLine("Введите трёхзначное число: ");
                    int numValue = int.Parse(Console.ReadLine());
                    
                    SortValue(ref numValue);
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
                
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка {ex.Message}");
            }
        }
    }
}
