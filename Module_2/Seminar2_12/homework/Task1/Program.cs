using System;

namespace Task1
{
	class Program
	{
        static void Main()
		{
			int n;
			do
				Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n < 1);
			UserString str = new UserString(n, '0', '9');
			Console.WriteLine(str);
			Console.WriteLine(str.MoveOff("02468"));
		}
	}
}
