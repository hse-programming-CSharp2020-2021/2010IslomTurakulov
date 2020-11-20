using System;

namespace Task2
{
	class Program
	{
		static int[,] GetMatrix(int n)
		{
			int[,] a = new int[n, n];
			for (int i = 0; i < n; i++)
				for (int j = 0; j < n; j++)
					a[i, j] = (i + j) % n + 1;
			return a;
		}
		static void PrintMatrix(int[,] a)
		{
			for (int i = 0; i < a.GetLength(0); i++)
			{
				for (int j = 0; j < a.GetLength(1); j++)
					Console.Write($"{a[i, j]} ");
				Console.WriteLine();
			}
		}
		static void Main()
		{
			int n;
			do
				Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n < 1);
			PrintMatrix(GetMatrix(n));
		}
	}
}
