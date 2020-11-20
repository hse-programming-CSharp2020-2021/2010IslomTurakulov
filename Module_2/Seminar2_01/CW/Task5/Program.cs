using System;

namespace Task5
{
	class Program
	{
		static int[][] GetTriangle(int n)
		{
			int[][] paskal = new int[n + 1][];
			for (int i = 0; i <= n; i++)
			{
				paskal[i] = new int[i + 1];
				paskal[i][0] = 1;
				paskal[i][i] = 1;
				for (int j = 1; j < i; j++)
					paskal[i][j] = paskal[i - 1][j - 1] + paskal[i - 1][j];
			}
			return paskal;
		}
		static void Main(string[] args)
		{
			int n;
			do
				Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
			int[][] paskal = GetTriangle(n);
			Array.ForEach(paskal, x =>
			{
				Array.ForEach(x, y => Console.Write($"{y} "));
				Console.WriteLine();
			});
		}
	}
}
