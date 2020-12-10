using System;
using System.Linq;
using static Figures.Figures;

namespace Task2
{
	class Program
	{
		static Point[] FigArray()
		{
			Random rnd = new Random();
			int circleCount = rnd.Next(0, 11);
			int squareCount = rnd.Next(0, 11);
			Point[] array = new Point[circleCount + squareCount];
			for (int i = 0; i < circleCount; i++)
				array[i] = new Circle(rnd.NextDouble() * 90 + 10, rnd.NextDouble() * 90 + 10, rnd.NextDouble() * 90 + 10);
			for (int i = circleCount; i < array.Length; i++)
				array[i] = new Square(rnd.NextDouble() * 90 + 10, rnd.NextDouble() * 90 + 10, rnd.NextDouble() * 90 + 10);
			return array;
		}
		static void Main()
		{
			Point p = new Point();
			p.Display();
			Console.WriteLine("p.Area для Point = " + p.Area);
			p = new Circle(1, 2, 6);
			p.Display();
			Console.WriteLine("p.Area для Circle = " + p.Area);
			p = new Square(3, 5, 8);
			p.Display();
			Console.WriteLine("p.Area для Square = " + p.Area);
			Console.WriteLine();

			Point[] array = FigArray();
			int circleCount = array.Count(x => x is Circle);
			int squareCount = array.Count(x => x is Square);
			Console.WriteLine($"CIRCLES. Count: {circleCount}; " +
				$"Average area: {array.Sum(x => x is Circle ? x.Area : 0) / circleCount:f3}; " +
				$"Average perimeter: {array.Sum(x => x is Circle y ? y.Len : 0) / circleCount:f3}");
			Console.WriteLine($"SQUARES. Count: {squareCount}; " +
				$"Average area: {array.Sum(x => x is Square ? x.Area : 0) / squareCount:f3}; " +
				$"Average perimeter: {array.Sum(x => x is Square y ? y.Len : 0) / squareCount:f3}");
			Array.Sort(array, (x, y) => x.Area.CompareTo(y.Area));
			Array.ForEach(array, x => x.Display());
		}
	}
}
