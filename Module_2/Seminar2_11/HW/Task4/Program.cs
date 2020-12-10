using System;
using MyLib;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            QuadraticTrinomial t1 = new QuadraticTrinomial(2, 3, 7);
            QuadraticTrinomial t2 = new QuadraticTrinomial(1, -5, 6);
            double[] points = new double[] { 1, -3, 3, 2, 7, 100, 0 };
            foreach (double x in points)
            {
                try
                {
                    Console.WriteLine(t1.Division(t2, x));
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine($"Значение второго трёхчлена в точке {x} равно 0");
                }
            }
        }
    }
}
