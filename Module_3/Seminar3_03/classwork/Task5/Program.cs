using System;

namespace Task5
{
	class Program
	{
		static event Action OnLineEnd;
		static void Print(int[,] array)
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
					Console.Write($"{array[i, j]} ");
				OnLineEnd?.Invoke();
			}
		}
		static void Main(string[] args)
		{
			int[,] array = new int[,] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } };
			OnLineEnd += Console.WriteLine;
			Print(array);
			Console.WriteLine();
			OnLineEnd += () => Console.WriteLine("***");
			Print(array);
		}
	}
}
