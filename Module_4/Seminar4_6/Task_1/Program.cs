using System;
using System.Collections.Generic;
using System.Linq;


/*В некоторой̆ коллекции хранятся целые числа.
1. Составить LINQ-выражение, формирующее коллекцию их квадратов.
2. Составить LINQ- выражение, выбирающее только положительные двузначные числа.
3. Составить LINQ- выражение, выбирающее только чётные числа и сортирующее их по убыванию.
4. Составить LINQ- выражение, группирующее числа по порядку (сотни, десятки, единицы)
Написать программу, применяющую выражения к коллекции из n (задать с клавиатуры) случайных чисел 
из отрезка [-1000, 1000]. (снабдить выводом исходных чисел и сформированных коллекций). 
Сделать с помощью стандартных операторов и с помощью методов расширения.*/
namespace Task_1
{
    class Program
    {
		static void Result(IEnumerable<int> numbers, string name)
		{
			Console.Write($"{name}: ");
			foreach (int i in numbers)
				Console.Write($"{i} ");

			Console.WriteLine();
		}

		static void Main()
		{
            int n;
            Console.WriteLine("Введите число");
			n = int.Parse(Console.ReadLine() ?? "1");
			int[] array = new int[n];
			Random rnd = new();
			for (int i = 0; i < n; i++)
				array[i] = rnd.Next(-1000, 1001);

			Result(array, "Исходное выражение");
			Result(array
				.Select(x => x * x), "Квадрат");
			Result(array
				.Where(x => x > 0 && Math.Abs(x).ToString().Length == 2), "Положительные 2-х значные числа");
			Result(array
				.Where(x => x % 2 == 0)
				.OrderByDescending(x => x), "Чётные числа по убыванию");
			Console.WriteLine($"Группировка чисел по порядку: " + string.Join(";", array
				.GroupBy(x => Math.Abs(x).ToString().Length)
				.Select(group => $@"{{{string.Join(' ', group)}}}")
				.ToArray()));

			Result(from x in array select x * x, "Квадрат");
				Result(from x in array where x >= 0 select x, "Положительные 2-х значные числа");
			Result(from x in array where x % 2 == 0 orderby x descending select x, "Чётные числа по убыванию");
			Console.WriteLine($"Группировка чисел по порядку: " + string.Join(";", from x in array
                group x by Math.Abs(x).ToString().Length into num
                select new {Order = num.Key, Numbers = num}));
		}
    }
}
