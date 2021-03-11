using System;
using System.Collections;

namespace Attributes
{
    interface IFigure
    {
        double Area { get; }
    }
    class Figure : IFigure
    {
        protected double number;
        public Figure(double info) => this.number = info;
        public virtual double Area { get; }
    }

    class Square : Figure
    {
        public Square(double number) : base(number)
        {

        }

        public double Area => Math.Pow(this.number, 2);

        public override string ToString() => $"Square = {Area}";
    }

    class Circle : Figure
    {
        public Circle(double number) : base(number)
        {
        }

        public double Area => Math.Pow(this.number, 2) * Math.PI;

        public override string ToString() => $"Circle = {Area}";
    }


    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            double bounder = rnd.NextDouble() * rnd.Next(5, 20);
            Figure[] figures = new Figure[6];
            for (int i = 0; i < figures.Length; i++)
            {
                if (rnd.Next(2, 10) % 2 == 0)
                    figures[i] = new Square(rnd.NextDouble() * rnd.Next(2, 16));
                else
                    figures[i] = new Circle(rnd.NextDouble() * rnd.Next(2, 16));
            }

            Console.WriteLine($"Исходные фигуры: {Environment.NewLine}");
            Print(figures, 0);
            Console.WriteLine("Новая:");
            Print(figures, bounder);
        }

        static void Print<T>(T[] array, double lowerBorder) where T : IFigure
        {
            foreach (var item in array)
                if (item.Area > lowerBorder)
                    Console.WriteLine(item);
        }
    }
}
