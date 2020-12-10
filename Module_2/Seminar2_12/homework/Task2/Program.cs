using System;

namespace Task2
{
	class Program
	{
		static void Main()
		{
			while (true)
			{
				Console.WriteLine("Введите строку из латинских символов, пробелов и точек с запятой. Затем нажмите Enter:");
				string[] parts = Methods.ValidatedSplit(Console.ReadLine(), ';');
				if (parts == null)
					Console.WriteLine("Некорректный ввод");
				else
					Array.ForEach(parts, x => Console.WriteLine(Methods.Abbrevation(x)));
				Console.WriteLine("Нажмите Esc, чтобы выйти, или любую другую клавишу, чтобы продолжить...");
				ConsoleKeyInfo key = Console.ReadKey();
				if (key.Key == ConsoleKey.Escape)
					break;
			}
		}
	}
}
