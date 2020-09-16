using System;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace CW4
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, g;
            Console.WriteLine("Введите x");
            g = G(x, y);
            Console.WriteLine(g.ToString());
            Console.ReadKey();
        }
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
    }
}
