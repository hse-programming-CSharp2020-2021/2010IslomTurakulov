using System;

namespace Task2
{
	class Program
	{
		delegate int[] MyDel1(int x);
		delegate void MyDel2(int[] array);

		static int[] GetDigits(int x) => Array.ConvertAll(x.ToString().ToCharArray(), x => x - '0');
		static void PrintArray(int[] array)
		{
			Array.ForEach(array, x => Console.Write($"{x} "));
			Console.WriteLine();
		}
		static void Main()
		{
			int a = 29846;
			int[] arr = { 83, 26, 48, 72, 56, 92, 65, 82, 56, 19 };
			MyDel1 d1 = GetDigits;
			MyDel2 d2 = PrintArray;
			d2(d1(a));
			d2(arr);
			Console.WriteLine();
			Console.WriteLine(d1.Method);
			Console.WriteLine(d1.Target);
			Console.WriteLine(d2.Method);
			Console.WriteLine(d2.Target);
		}
	}
}
