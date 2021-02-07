using System;
#pragma warning disable IDE0039 // Использовать локальную функцию
namespace Task1
{
	class Program
	{
		delegate int Cast(double d);
		static void Main()
		{
			Cast cast1 = delegate (double d)
			{
				return (int)(Math.Round(d / 2.0) * 2.0);
			};
			Cast cast2 = delegate (double d)
			{
				return (int)Math.Log10(d) + 1;
			};
			double[] arr = { 3.14, 2.71, 5.82, 2.26, 102.111 };
			foreach (double d in arr)
				Console.WriteLine($"{d} {cast1(d)} {cast2(cast1(d))}");
			Console.WriteLine();

			Cast cast = cast1;
			cast += cast2;
			foreach (double d in arr)
				Console.WriteLine(cast(d));

			Cast cast3 = d => (int)(Math.Round(d / 2.0) * 2.0);
			Cast cast4 = d => (int)Math.Log10(d) + 1;
		}
	}
}
