using System;
using System.Linq;

namespace CW4
{
    // Написать метод, вычисляющий значение функции G=F(X,Y)
    class Program
    {
        /// <summary>
        /// Метод, вычисляющий значение функции G=F(X,Y)
        /// </summary>
        /// <param name="x">Значение функции X</param>
        /// <param name="y">Значение функции Y</param>
        /// <returns></returns>
        public static double G(double x, double y)
        {
            if (x < y && x > 0)
            {
                return x + Math.Sin(y);
            }
            else if (x > y && x < 0)
            {
                return y - Math.Cos(x);
            }
            else
            {
                return 0.5 * x * y;
            }
        }
        static void ReadNumber(out double num)
        {
            // Валидация данных
            while (!double.TryParse(Console.ReadLine(), out num))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введены некорректные данные!");
                Console.WriteLine("Пожалуйста повторите попытку");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
                Console.Write("Введите значение: ");
            }
        }
        static void Main(string[] args)
        {
            // Параметры значений
            double x, y, g;
            do
            {
                Console.Write("Введите значение: ");
                ReadNumber(out x);
                Console.Write("Введите значение: ");
                ReadNumber(out y);

                g = G(x, y);
                Console.WriteLine(g.ToString("F4"));
                Console.WriteLine("Нажмите ESC , чтобы выйти");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
