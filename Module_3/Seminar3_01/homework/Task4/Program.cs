using System;
using System.Collections.Generic;
using System.Threading;

namespace Task4
{
	class Robot
	{
		// класс для представления робота
		int x, y; // положение робота на плоскости
		int mx, my;
		HashSet<(int, int)> previous;

		public Robot(int mx, int my)
		{
			this.mx = mx;
			this.my = my;
			previous = new HashSet<(int, int)>();
		}
		public void Right()
		{
			previous.Add((x, y));
			x++;
			Validate();
		}
		public void Left()
		{
			previous.Add((x, y));
			x--;
			Validate();
		}
		public void Forward()
		{
			previous.Add((x, y));
			y++;
			Validate();
		}
		public void Backward()
		{
			previous.Add((x, y));
			y--;
			Validate();
		}
		public void Validate()
		{
			if (x < 0 || x > mx || y < 0 || y > my)
				throw new InvalidOperationException("Робот вышел за пределы поля!");
		}

		public string Position()
		{  // сообщить координаты
			return String.Format("The Robot position: x={0}, y={1}", x, y);
		}
		public void Paint()
		{
			Console.Clear();
			Console.BackgroundColor = ConsoleColor.White;
			for (int j = 0; j <= my; j++)
			{
				for (int i = 0; i <= mx; i++)
				{
					if (i == x && j == y)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.Write('*');
					}
					else if (previous.Contains((i, j)))
					{
						Console.ForegroundColor = ConsoleColor.Gray;
						Console.Write('+');
					}
					else
						Console.Write(' ');
				}
				Console.CursorTop++;
				Console.CursorLeft = 0;
			}
			Console.ResetColor();
			Thread.Sleep(500);
		}
	}

	class Program
	{
		delegate void Steps(); // делегат-тип
		static void Main()
		{
			int mx, my;
			do
				Console.Write("Введите максимальную координату по горизонтали: ");
			while (!int.TryParse(Console.ReadLine(), out mx) || mx < 0);
			do
				Console.Write("Введите максимальную координату по вертикали: ");
			while (!int.TryParse(Console.ReadLine(), out my) || my < 0);

			Robot rob = new Robot(mx, my);
			Console.Write("Введите программу для робота (команды: R(Right), L(Left), F(Forward), B(Backward)): ");
			string str = Console.ReadLine();
			Steps program = () => { };
			for (int i = 0; i < str.Length; i++)
			{
				switch (str[i])
				{
					case 'R':
						program += rob.Right;
						program += rob.Paint;
						break;
					case 'L':
						program += rob.Left;
						program += rob.Paint;
						break;
					case 'F':
						program += rob.Forward;
						program += rob.Paint;
						break;
					case 'B':
						program += rob.Backward;
						program += rob.Paint;
						break;
					default:
						Console.WriteLine("Неверная программа");
						return;
				}
			}
			try
			{
				program();
			}
			catch (Exception exception)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(exception.Message);
			}
		}
	}
}
