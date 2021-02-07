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
        static int DoubleSplit(double doubleNumber, out double f)
        {
            int whole = (int)doubleNumber;
            // Дробная часть
            f = doubleNumber - whole;
            // Целая часть
            int num = (int)Math.Round(doubleNumber);
            return num;
        }
        /// <summary>
        /// Корень и квадрат числа
        /// </summary>
        /// <param name="doubleNumber"> Дробное число</param>
        static double Fract(double doubleNumber, out double f)
        {
            // Квадратное число
            f = Math.Pow(doubleNumber, 2 );
            // Корень числа
            doubleNumber = Math.Sqrt(doubleNumber);
            return doubleNumber;
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
            double f;
                do
                {
                    Console.WriteLine("Введите дробное число: ");
                    ReadNumber(out doubleNumber);

                    DoubleSplit(doubleNumber , out f);
                    Console.WriteLine($"Дробная часть : {f} Целая часть: {doubleNumber}");

                    Fract(doubleNumber, out f);
                    Console.WriteLine($"Квадратное число : {f} Корень числа: {doubleNumber}");

                    Console.WriteLine("Нажмите ESC , чтобы выйти...");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
