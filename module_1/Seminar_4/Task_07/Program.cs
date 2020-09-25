using System;

namespace Task_07
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b;
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
                Console.WriteLine("НОД={0}", NOD(a, b));
                Console.WriteLine("НОК={0}", NOK(a, b));
            }
            Console.ReadKey();
        }
        static double NOD(double a, double b)
        {
            if (b < 0) b = -b;
            if (a < 0) a = -a;
            while (b > 0)
            {
                double temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        static double NOK(double a, double b)
        {
            return Math.Abs(a * b) / NOD(a, b);
        }
    }
}
