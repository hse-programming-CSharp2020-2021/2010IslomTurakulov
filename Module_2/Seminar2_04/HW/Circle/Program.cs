using System;

namespace Circle
{
	class Circle
	{
		public double X { get; set; }
		public double Y { get; set; }
		public double R { get; set; }
		public Circle(double x, double y, double r)
		{
			X = x;
			Y = y;
			R = r;
		}
		public bool Intersect(Circle other)
		{
			if (other.R > R)
				return other.Intersect(this);
			double dx = X - other.X;
			double dy = Y - other.Y;
			double distance = Math.Sqrt(dx * dx + dy * dy);
			return distance + other.R >= R || distance - other.R >= R;
		}
		public override string ToString() => $"X={X:f3}, Y={Y:f3}, R={R:f3}";
	}
	class Program
	{
		static void Main()
		{
			while (true)
			{
				int n;
				Random rnd = new Random();
				do
					Console.Write("Enter N: ");
				while (!int.TryParse(Console.ReadLine(), out n) || n < 1);

				Circle[] array = new Circle[n];
				Circle additional = new Circle(0, 0, 1);
				for (int i = 0; i < n; i++)
					array[i] = new Circle(
						rnd.NextDouble() * 14 + 1, rnd.NextDouble() * 14 + 1, rnd.NextDouble() * 14 + 1);
				Array.ForEach(array, x => {
					if (additional.Intersect(x))
						Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine(x);
					Console.ResetColor();
				});

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
