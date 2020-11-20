using System;

namespace Task7
{
	class Sin
	{
		double xMax;
		public Sin(double xMin, double xMax)
		{
			XMin = xMin;
			XMax = xMax;
		}
		public double XMin { get; set; }
		public double XMax
		{
			get => xMax;
			set
			{
				if (value < XMin)
					throw new ArgumentException("xMax must be greater than or equal to xMin");
				xMax = value;
			}
		}
		public double this[double arg]
		{
			get => (arg >= XMin && arg <= XMax) ? Math.Sin(arg) : 0;
		}
	}
	class Program
	{
		static void Main()
		{
			Sin mySin = new Sin(0, Math.PI);
			for (double d = 0; d <= Math.PI; d += Math.PI / 6)
				Console.Write($"{mySin[d]:f3} ");
		}
	}
}
