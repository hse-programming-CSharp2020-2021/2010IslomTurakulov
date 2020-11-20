using System;

namespace _1
{
	class LatinChar
	{
		char _char;

		public LatinChar() : this('a') { }
		public LatinChar(char _char)
		{
			this._char = _char;
		}
		public char Char
		{
			set
			{
				if (char.ToLower(value) < 'a' || char.ToLower(value) > 'z')
					throw new ArgumentException("Not a latin letter");
				_char = value;
			}
			get
			{
				return _char;
			}
		}
	}
	class Program
	{
		static void Main()
		{
			LatinChar latin = new LatinChar();
			char min, max;
			do
				Console.Write("Enter min char: ");
			while (!char.TryParse(Console.ReadLine(), out min));
			do
				Console.Write("Enter max char: ");
			while (!char.TryParse(Console.ReadLine(), out max));

			for (char c = min; c <= max; c++)
			{
				latin.Char = c;
				Console.Write($"{latin.Char} ");
			}
		}
	}
}
