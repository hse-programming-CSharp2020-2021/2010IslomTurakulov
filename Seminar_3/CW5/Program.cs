using System;
using System.Reflection.Metadata.Ecma335;

namespace CW5
{
    // Написать метод, вычисляющий значение функции G=F(X)
    class Program
    {
        /// <summary>
        /// Вычисляет значение функции G=F(X)
        /// </summary>
        /// <param name="x">Значение функции</param>
        /// <returns></returns>
        public static double FunctionChecker(ref double x)
        {
            if (x <= 0.5)
            {
                return Math.Sin(Math.PI / 2);
            }
            else 
            {
                return Math.Sin(Math.PI*(x - 1) / 2);
            }
        }
        static void ReadNumber(out double num)
        {
            while (!double.TryParse(Console.ReadLine(), out num))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введены некорректные данные!");
                Console.WriteLine("Пожалуйста повторите попытку");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
                Console.Write("Введите значение x: ");
            }
        }
        static void Main(string[] args)
        {
            double x, g;
            do
            {
                Console.Clear();

                Console.WriteLine("Введите значение x: ");
                // Проверка на данные
                ReadNumber(out x);
                // Вызов метода
                g = FunctionChecker(ref x);
                Console.WriteLine(g.ToString("F3"));
                Console.WriteLine("Нажмите ESC , чтобы выйти");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
