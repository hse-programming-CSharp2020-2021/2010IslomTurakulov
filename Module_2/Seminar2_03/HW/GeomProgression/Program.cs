using System;

namespace GeomProgression
{
	class GeomProgression
	{
		public double B0 { get; set; }
		public double Q { get; set; }
		public GeomProgression(double b0, double q)
		{
			B0 = b0;
			Q = q;
		}
		public double this[int index] => B0 * Math.Pow(Q, index);
		public double Sum(int n)
		{
			if (n < 1)
				throw new ArgumentException("n must be a positive integer");
			return B0 * (Math.Pow(Q, n) - 1) / (Q - 1);
		}
	}
	class Program
	{
		static void Main()
		{
			GeomProgression progression = new GeomProgression(1, 2);
			for (int i = 0; i < 10; i++)
				Console.Write($"{progression[i]} ");
			Console.WriteLine();
			Console.WriteLine($"Sum: {progression.Sum(10)}");
		}
	}
}
