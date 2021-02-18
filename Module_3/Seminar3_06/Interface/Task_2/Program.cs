using System;

namespace Task_2
{
    interface ISequence
    {
        double GetElement(int element);
    }

    class ArithmeticProgression : ISequence
    {
        private double first;
        private double second;
        public ArithmeticProgression(double first, double second)
        {
            this.first = first;
            this.second = second;
        }

        public double GetElement(int element) => first + second * (element - 1);
    }

    class GeometricProgression : ISequence
    {
        private double first;
        private double second;
        public GeometricProgression(double first, double second)
        {
            this.first = first;
            this.second = second;
        }

        public double GetElement(int element) => first * Math.Pow(second, element - 1);
    }
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                switch (i % 2)
                {
                    case 0:
                    {
                        var s = Sum(new ArithmeticProgression(1, rnd.Next(1, 5)), rnd.Next(1, 5));
                        Console.WriteLine(s);
                        break;
                    }
                    default:
                    {
                        var s = Sum(new GeometricProgression(1, rnd.Next(1, 5)), rnd.Next(1, 5));
                        Console.WriteLine(s);
                        break;
                    }
                }
            }
        }

        public static double Sum(ISequence sequence, int count)
        {
            double res = 0;
            for (int i = 0; i < count; i++)
            {
                res += sequence.GetElement(i);
            }

            return res;
        }
    }
}
