using System;

namespace LinearEquation
{
	class LinearEquation : IComparable<LinearEquation>
	{
		public double A { get; set; }
		public double B { get; set; }
		public double C { get; set; }
		public LinearEquation(double a, double b, double c)
		{
			A = a;
			B = b;
			C = c;
		}
		public double Solve { get => (C - B) / A; }
		public int CompareTo(LinearEquation other) => Solve.CompareTo(other.Solve);
		public override string ToString() => $"A={A:g3}, B={B:g3}, C={C:g3}, Root={Solve:f3}";
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

				LinearEquation[] array = new LinearEquation[n];
				for (int i = 0; i < n; i++)
					array[i] = new LinearEquation(
						rnd.NextDouble() * 20 - 10, rnd.NextDouble() * 20 - 10, rnd.NextDouble() * 20 - 10);
				Array.Sort(array);
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
