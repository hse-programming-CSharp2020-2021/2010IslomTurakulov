using System;
using static System.Math;

namespace Task_1
{

    class Coords
    {
        private double _first;
        private double _second;

        public Coords(double first, double second)
        {
            _first = first;
            _second = second;
        }

        public override string ToString() => $"First coord: {_first} Second coord: {_second}";
    }

    class Circle
    {
        private double _radius;

        public Coords Center { get; set; }
        
        public double Radius
        {
            get => _radius;
            set
            {
                if (value < 0)
                    throw new ArgumentException("The radius is less than zero!");
                Radius = value;
            }
        }

        public (double, double) SquareLength() => (2 * PI * _radius, PI * _radius * _radius);

        public Circle(double x, double y, double radius)
        {
            Center = new Coords(x, y);
            Radius = radius;
        }

        public override string ToString()
        {
            (double length, double square) = SquareLength();
            return $"Center: {Center} Radius: {Radius:f3}  {Environment.NewLine}" +
                   $" Length: {length:f3} Square: {square:f3}";
        }
    }

    class Program
    {
        static Random _rnd = new Random();
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Circle circle = new Circle(_rnd.NextDouble() * _rnd.Next(1,5), _rnd.NextDouble() * _rnd.Next(1,5), _rnd.NextDouble() * _rnd.Next(1,5));
                Console.WriteLine(circle);
            }
        }
    }
}
