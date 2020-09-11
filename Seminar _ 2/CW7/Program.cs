using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Schema;

/*
* Написать программу с использованием двух методов. Первый метод возвращает дробную и целую часть числа. 
* Второй метод возвращает квадрат и корень из числа. В основной программе пользователь вводит дробное число. 
* Программа должна вычислить, если это возможно, значение корня, квадрата числа, выделить целую и дробную часть из числа.
*/

namespace CW7
{
    class Program
    {
        /// <summary>
        /// Дробная и целая часть
        /// </summary>
        /// <param name="doubleNumber">Дробное число</param>
        static void DoubleSplit(double doubleNumber)
        {
            Console.WriteLine($"Дробная часть : {doubleNumber}");
            Console.WriteLine($"Целая часть: {(int)Math.Round(doubleNumber)}");
        }
        /// <summary>
        /// Корень и квадрат числа
        /// </summary>
        /// <param name="doubleNumber"> Дробное число</param>
        static void Fract(double doubleNumber)
        {
            Console.WriteLine($"Квадрат числа: {Math.Pow(doubleNumber, 2 ).ToString("F3")}");
            Console.WriteLine($"Корень числа: {Math.Sqrt(doubleNumber).ToString("F3")}");
        }
        /// <summary>
        /// Обрабатывает данные, которую ввёл пользователь
        /// </summary>
        /// <param name="num"></param>
        static void ReadNumber(out double doubleNumber)
        {
            Console.Write("Введите дробное число: ");
            while (!double.TryParse(Console.ReadLine(), out doubleNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введены некорректные данные!");
                Console.WriteLine("Пожалуйста повторите попытку");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
                Console.Write("Введите дробное число: ");
            }
        }

        static void Main(string[] args)
        {
            double doubleNumber;
                do
                {
                    Console.WriteLine("Введите дробное число: ");
                    ReadNumber(out doubleNumber);

                    DoubleSplit(doubleNumber);
                    Fract(doubleNumber);

                    Console.WriteLine("Нажмите ESC , чтобы выйти...");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
