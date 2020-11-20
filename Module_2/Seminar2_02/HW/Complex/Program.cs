using System;

namespace Complex
{
	class Complex
	{
		public Complex(double re, double im)
		{
			Re = re;
			Im = im;
		}
		public Complex(Complex c) : this(c.Re, c.Im) { }
		public double Re { get; }
		public double Im { get; }
		public double Abs
		{
			get
			{
				return Math.Sqrt(Re * Re + Im * Im);
			}
		}
		public double Arg
		{
			get
			{
				if (Re > 0 && Im >= 0)
					return Math.Atan2(Im, Re);
				else if (Re > 0 && Im < 0)
					return Math.Atan2(Im, Re) + Math.PI * 2;
				else if (Re < 0)
					return Math.Atan2(Im, Re) + Math.PI;
				else if (Re == 0 && Im > 0)
					return Math.PI / 2;
				else if (Re == 0 && Im < 0)
					return 3 * Math.PI / 2;
				else
					throw new ArgumentException("Не существует аргумента нулевого комплексного числа");
			}
		}
		public static Complex operator +(Complex a, Complex b)
		{
			return new Complex(a.Re + b.Re, a.Im + b.Im);
		}
		public static Complex operator +(Complex a, double b)
		{
			return new Complex(a.Re + b, a.Im);
		}
		public static Complex operator -(Complex a, Complex b)
		{
			return new Complex(a.Re - b.Re, a.Im - b.Im);
		}
		public static Complex operator -(Complex a, double b)
		{
			return new Complex(a.Re - b, a.Im);
		}
		public static Complex operator *(Complex a, Complex b)
		{
			return new Complex(a.Re * b.Re - a.Im * b.Im, a.Im * b.Re + a.Re * b.Im);
		}
		public static Complex operator *(Complex a, double b)
		{
			return new Complex(a.Re * b, a.Im * b);
		}
		public static Complex operator /(Complex c1, Complex c2)
		{
			double a = c1.Re;
			double b = c1.Im;
			double c = c2.Re;
			double d = c2.Im;
			if (c == 0 && d == 0)
				throw new DivideByZeroException();
			return new Complex((a*c + b*d) / (c*c + d*d), 
								(b*c - a*d) / (c*c + d*d));
		}
		public static Complex operator /(Complex a, double b)
		{
			return new Complex(a.Re / b, a.Im / b);
		}
		public override string ToString()
		{
			if (Im == 0)
				return Re.ToString();
			if (Re == 0)
				return $"{Im}i";
			return $"{Re}{(Im >= 0 ? "+" : "")}{Im}i";
		}
	}
	class Program
	{
		static Complex Read()
		{
			double a, b;
			do
				Console.Write($"\tВведите вещественную часть: ");
			while (!double.TryParse(Console.ReadLine(), out a));
			do
				Console.Write($"\tВведите мнимую часть: ");
			while (!double.TryParse(Console.ReadLine(), out b));
			return new Complex(a, b);
		}
		static void Main()
		{
			Console.WriteLine("Введите первое комплексное число");
			Complex a = Read();
			Console.WriteLine("Введите второе комплексное число");
			Complex b = Read();

			Console.WriteLine($"Первое число: {a.Abs}");
			Console.WriteLine($"Второе число: {b.Abs}");
			Console.WriteLine();
			Console.WriteLine($"Модуль первого числа: {a.Abs}");
			Console.WriteLine($"Модуль второго числа: {b.Abs}");
			Console.WriteLine();
			if (a.Re != 0 || a.Im != 0)
				Console.WriteLine($"Аргумент первого числа: {a.Arg}");
			if (b.Re != 0 || b.Im != 0)
				Console.WriteLine($"Аргумент второго числа: {b.Arg}");
			Console.WriteLine();
			Console.WriteLine($"Сумма чисел: {a + b}");
			Console.WriteLine($"Разность чисел: {a - b}");
			Console.WriteLine($"Произведение чисел: {a * b}");
			if (b.Re != 0 || b.Im != 0)
				Console.WriteLine($"Частное чисел: {a / b}");
		}
	}
}
