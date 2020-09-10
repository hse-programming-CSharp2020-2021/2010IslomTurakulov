using System;
using System.Linq;

namespace CW4
{
    class Program
    {
        static void NumReverse(ref uint a)
        {
            Console.WriteLine("\nВжух.. Обратный порядок появись! ");
            Console.WriteLine(a.ToString().Reverse().ToArray());
        }
        static void Main(string[] args)
        {
            // Для обработки исключений
            try
            {
                //Для натуральных чисел будем использовать uint
                uint numValue;

                Console.WriteLine("Требования: Получить от пользователя четырехзначное натуральное число и напечатать его цифры в обратном порядке");
                do
                {
                    // Можно для проверки исключений использовать TryParse или do while

                    Console.Write("\nВведите четырёхзначное число: ");
                    numValue = uint.Parse(Console.ReadLine());
                    if (numValue >= 1000 & numValue <= 9999)
                    {
                        NumReverse(ref numValue);
                    }
                    else 
                    {
                        Console.WriteLine("Во имя Зевса, введи четырехзначное число! ");
                        continue;
                    }

                    Console.WriteLine("\nНажмите ESC для выхода..");
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка в вводе");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
