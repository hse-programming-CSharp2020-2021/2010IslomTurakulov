using System;
using System.Data.Common;
using System.Runtime.InteropServices.ComTypes;

namespace Task_6
{
    /* 
    Задан круг с центром в начале координат и радиусом R=10.   
    Ввести  координаты точки и вывести сообщение:   «Точка внутри круга!» или «Точка вне круга!».

    Предусмотреть проверку входных данных и цикл повторения решений.  
    */

    class Program
    {
        /// <summary>
        /// Проверяет точка внутри круга или нет
        /// </summary>
        /// <param name="x"> первый параметр</param>
        /// <param name="y"> второй параметр</param>
        static void RadiusChecker(double x, double y)
        {
            string report;
            const double R = 10;
            report = x * x + y * y > R * R ? "Точка вне круга!" : "Точка внутри круга!";

            Console.WriteLine(report);
        }
        /// <summary>
        /// Обработка данных от пользователя
        /// </summary>
        /// <param name="num">Переменную проверяет</param>
        static void ReadNumber(out double num)
        {

            while (!double.TryParse(Console.ReadLine(), out num))
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введены некорректные данные!");
                Console.WriteLine("Пожалуйста повторите попытку");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
                Console.Write("Введите число: ");
            }
        }
        static void Main(string[] args)
        {
            double x, y;
            do
            {
                // Пользователь вводит значение
                Console.Write("x = ");
                ReadNumber(out x); 
                Console.Write("y = ");
                ReadNumber(out y); 

                RadiusChecker(x, y);

                Console.WriteLine("Для выхода из программы нажмите ENTER.");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
}
