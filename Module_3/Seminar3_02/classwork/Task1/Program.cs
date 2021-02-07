using System;
using System.Linq;

namespace Task1
{
	delegate string ConvertRule(string str);
	class Converter
	{
		public string Convert(string str, ConvertRule cr) => cr(str);
	}
	class Program
	{
		public static string RemoveDigits(string str) => new string(str.Where(c => !char.IsDigit(c)).ToArray());
		public static string RemoveSpaces(string str) => new string(str.Where(c => c != ' ').ToArray());
		static void Main(string[] args)
		{
			string[] arr = { "Hello world!", "Current time is 17:48", "See u l8r" };
			Converter converter = new Converter();
			ConvertRule cr = RemoveDigits;
			for (int i = 0; i < arr.Length; i++)
				arr[i] = converter.Convert(arr[i], cr);
			cr += RemoveSpaces;
			for (int i = 0; i < arr.Length; i++)
				arr[i] = converter.Convert(arr[i], cr);
			Array.ForEach(arr, Console.WriteLine);
		}
	}
}
