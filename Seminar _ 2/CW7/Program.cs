using System;
using System.Runtime.CompilerServices;
/*
* Написать программу с использованием двух методов. Первый метод возвращает дробную и целую часть числа. 
* Второй метод возвращает квадрат и корень из числа. В основной программе пользователь вводит дробное число. 
* Программа должна вычислить, если это возможно, значение корня, квадрата числа, выделить целую и дробную часть из числа.
*/

namespace CW7
{
    class Program
    {

        static void DoubleSplit(double doubleNumber)
        {
            int fractLength = doubleNumber.ToString().Split(',')[1].Length;
            Console.WriteLine();
            (int)Math.Round(doubleNumber)
        }
        public int Fract
        {
            get { return (int)((doubleNumber - Int) * Math.Pow(10, fractLength)); }
        }
        public double Doub
        {
            get { return doubleNumber; }
        }
        static void Main(string[] args)
        {
            try
            {
                do
                {
                    Console.WriteLine("Введите дробное число: ");
                    double doubleNumber = double.Parse(Console.ReadLine());
                    DoubleSplit ds1 = new DoubleSplit(doubleNumber);

                } while (Console.ReadKey().Key != ConsoleKey.Escape);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка {ex.Message}");
            }
        }
    }
}
