using System;

namespace Square
{
	delegate void SquareSizeChanged(double size);
	class Square
	{
		(double, double) point1, point2;
		public event SquareSizeChanged OnSizeChanged;

		public Square((double, double) leftTop, (double, double) rightBottom)
		{
			LeftTop = leftTop;
			RightBottom = rightBottom;
		}

		public (double, double) LeftTop
		{
			get => point1;
			set
			{
				point1 = value;
				OnSizeChanged?.Invoke(point2.Item1 - point1.Item1);
			}
		}
		public (double, double) RightBottom
		{
			get => point2;
			set
			{
				point2 = value;
				OnSizeChanged?.Invoke(point2.Item1 - point1.Item1);
			}
		}
	}
	class Program
	{
		static void SquareConsoleInfo(double a) => Console.WriteLine($"New size: {a:f2}");
		static (double, double) GetPoint()
		{
			while (true)
			{
				string[] array = Console.ReadLine().Split(' ');
				if (array.Length != 2)
					continue;
				double x, y;
				if (!double.TryParse(array[0], out x) || !double.TryParse(array[1], out y))
					continue;
				return (x, y);
			}
		}
		static void Main(string[] args)
		{
			Console.Write("Enter coordinates of left-top and right-bottom angles: ");
			Square square = new Square(GetPoint(), GetPoint());
			square.OnSizeChanged += SquareConsoleInfo;
			do
				square.RightBottom = GetPoint();
			while (Console.ReadKey().Key != ConsoleKey.Escape);
		}
	}
}
