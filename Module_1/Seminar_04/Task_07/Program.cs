using System;

namespace Task_07
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            do
            {
                Console.Write("Введите первое число: ");
                string firstInput = Console.ReadLine();
                Console.Write("Введите второе число: ");
                string secondInput = Console.ReadLine();
                if (!int.TryParse(firstInput, out a) || (!int.TryParse(secondInput, out b)))
                {
                    Console.WriteLine("Incorrect input");
                }
                else
                {
                    Console.WriteLine($"НОД={NOD(a, b)}");
                    Console.WriteLine($"НОК={NOK(a, b)}");
                }
                Console.WriteLine("Нажмите ESC для выхода");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            static double NOD(double a, double b)
            {
                if (b < 0) b = -b;
                if (a < 0) a = -a;

                while (b > 0)
                {
                    double firsttemp = b;
                    b = a % b;
                    a = firsttemp;
                }
                return a;
            }
            static double NOK(double a, double b)
            {
                return Math.Abs(a * b) / NOD(a, b);
            }
        }    
    }
}
