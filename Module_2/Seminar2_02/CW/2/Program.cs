using System;
using System.Linq;

namespace _2
{
    class Circle
    {
        double _r;
        public double Radius
        {
            get
            {
                return _r;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Radius should be non-negative");
                _r = value;
            }
        }

        public double S
        {
            get
            {
                return Math.PI * _r * _r;
            }
        }
        public double Length
        {
            get
            {
                return 2.0 * Math.PI * _r;
            }
        }

        public Circle()
        {
            Radius = 1;
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override string ToString()
        {
            return $"Circle: radius = {Radius:f3}, Square = {S:f3}";
        }
    }
    class Program
    {
        static void Main()
        {
            double rmin;
            double rmax;
            Random rnd = new Random();
            int n;
            do
                Console.Write("Enter N: ");
            while (!int.TryParse(Console.ReadLine(), out n) || n < 1);
            do
                Console.Write("Enter RMin: ");
            while (!double.TryParse(Console.ReadLine(), out rmin));
            do
                Console.Write("Enter RMax: ");
            while (!double.TryParse(Console.ReadLine(), out rmax) || rmax < rmin);

            Circle[] array = new Circle[n];
            int maxIndex = 0;
            for (int i = 0; i < n; i++)
            {
                array[i] = new Circle(rnd.NextDouble() * (rmax - rmin) + rmin);
                Console.WriteLine($"{i + 1}. {array[i]}");
                if (array[i].S > array[maxIndex].S)
                    maxIndex = i;
            }
            Console.WriteLine($"Maximum area. {array[maxIndex]}");
        }
    }
}