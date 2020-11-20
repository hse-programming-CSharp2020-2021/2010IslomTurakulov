using System;

namespace Task3
{
	class Program
	{
		static char[][][] GetArray()
		{
			char[][][] a = new char[3][][];
			char val = 'a';
			for (int i = 0; i < 3; i++)
				a[i] = new char[3 - i][];
			for (int i = 0; i < 3; i++)
			{
				a[0][i] = new char[i + 2];
				for (int j = 0; j < i + 2; j++)
					a[0][i][j] = val++;
			}
			for (int i = 0; i < 2; i++)
			{
				a[1][i] = new char[i + 2];
				for (int j = 0; j < i + 2; j++)
					a[1][i][j] = val++;
			}
			a[2][0] = new char[4];
			for (int j = 0; j < 4; j++)
				a[2][0][j] = val++;
			return a;
		}
		static void Main(string[] args)
		{
			char[][][] a = GetArray();
			Console.WriteLine($"Rank: {a.Rank}");
			Console.WriteLine($"Total elements: {a.Length}");
			for (int i = 0; i < a.Rank; i++)
			{
				Console.WriteLine($"Elements in dimension {i}: {a.GetLength(i)}");
				Console.WriteLine($"Upper bound in dimension {i}: {a.GetUpperBound(i)}");
			}
			for (int i = 0; i < a.Length; i++)
			{
				for (int j = 0; j < a[i].Length; j++)
				{
					for (int k = 0; k < a[i][j].Length; k++)
						Console.Write($"{a[i][j][k]} ");
					Console.WriteLine();
				}
				Console.WriteLine();
			}
		}
	}
}
