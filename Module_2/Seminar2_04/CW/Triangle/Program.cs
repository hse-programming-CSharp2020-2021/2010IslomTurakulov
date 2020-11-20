using System;

namespace Triangle
{
	class Point
	{
		public double X { get; set; }
		public double Y { get; set; }
		public Point() : this(0, 0) { }
		public Point(double x, double y)
		{
			X = x;
			Y = y;
		}
		public double Distance(Point other)
		{
			double dx = X - other.X;
			double dy = Y - other.Y;
			return Math.Sqrt(dx * dx + dy * dy);
		}
		public override string ToString()
		{
			return $"({X:g3};{Y:g3})";
		}
	}
	class Triangle
	{
		public Triangle() : this(0, 0, 0, 0, 0, 0) {}
		public Triangle(Point a, Point b, Point c)
		{
			A = a;
			B = b;
			C = c;
		}
		public Triangle(double ax, double ay, double bx, double by, double cx, double cy)
			: this(new Point(ax, ay), new Point(bx, by), new Point(cx, cy)) { }
		public Point A { get; set; }
		public Point B { get; set; }
		public Point C { get; set; }
		public double AB { get => A.Distance(B); }
		public double BC { get => B.Distance(C); }
		public double AC { get => A.Distance(C); }
		public double Perimeter { get => AB + BC + AC; }
		public double Area
		{
			get
			{
				double p = Perimeter / 2;
				return Math.Sqrt(p * (p - AB) * (p - BC) * (p - AC));
			}
		}
		public override string ToString() => $"{A}, {B}, {C}, Perimeter: {Perimeter:g3}, Area: {Area:g3}";
	}
	class Program
	{
		static void Main()
		{
			while (true)
			{
				Random rnd = new Random();
				int n = rnd.Next(5, 16);
				Triangle[] array = new Triangle[n];
				for (int i = 0; i < n; i++)
					array[i] = new Triangle(rnd.NextDouble() * 20 - 10,
						rnd.NextDouble() * 20 - 10,
						rnd.NextDouble() * 20 - 10,
						rnd.NextDouble() * 20 - 10,
						rnd.NextDouble() * 20 - 10,
						rnd.NextDouble() * 20 - 10);
				Array.Sort(array, (x, y) => -x.Area.CompareTo(y.Area));
				Array.ForEach(array, x => Console.WriteLine(x));

				Console.WriteLine();
				Console.WriteLine("Press Esc to exit or any other key to continue...");
				Console.WriteLine();
				ConsoleKeyInfo key = Console.ReadKey();
				if (key.Key == ConsoleKey.Escape)
					break;
			}
		}
	}
}
