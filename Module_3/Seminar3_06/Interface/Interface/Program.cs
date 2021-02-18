using System;

namespace Interface
{
    abstract class Figure
    {
        public int A { get; set; }
    }

    interface ISquare
    {
        double Square();
    }

    interface IVolume
    {
        double Volume();
    }

    class Triangle : Figure, ISquare
    {
        public double Square()
        {
            return A * A * Math.Sqrt(3) / 4;
        }
    }

    class ExSquare : Figure, ISquare
    {
        public double Square()
        {
            return A * A;
        }
    }

    class Cube : Figure, ISquare, IVolume
    {
        public double Square()
        {
            return A * A * 6;
        }

        public double Volume()
        {
            return A * A * A;
        }
    }

    class Program 
    {
        static void Main(string[] args)
        {
            int n = 10;
            Figure[] figures = new Figure[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                int newRndDigit = rnd.Next(0, 4);
                if (newRndDigit == 2)
                    figures[i] = new Cube() {A = rnd.Next(1,11)};
                else if (newRndDigit == 1)
                    figures[i] = new ExSquare() {A = rnd.Next(1, 11)};
                else
                    figures[i] = new Triangle() {A = rnd.Next(1, 11)};

                switch (figures[i])
                {
                    case ISquare _:
                        Console.WriteLine($"Square {((ISquare) figures[i]).Square():f3}");
                        break;
                    case IVolume _:
                        Console.WriteLine($"Volume {((IVolume) figures[i]).Volume():f3}");
                        break;
                }
            }
        }
    }
}
