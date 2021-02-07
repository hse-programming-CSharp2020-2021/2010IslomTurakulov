using System;

namespace Task3
{
	class TemperatureConverterImp
	{
		public double CelsiusToFahrenheit(double celsius) => celsius * 9 / 5 + 32;
		public double FahrenheitToCelsius(double fahrenheit) => (fahrenheit - 32) * 5 / 9;
	}
	static class StaticTempConverters
	{
		public static double FromCelsiusToKelvin(double celsius) => celsius + 273.15;
		public static double FromCelsiusToRankin(double celsius) => (celsius + 273.15) * 9 / 5;
		public static double FromCelsiusToRéaumur(double celsius) => celsius * 4 / 5;
		public static double FromKelvinToCelsius(double kelvin) => kelvin - 273.15;
		public static double FromRankinToCelsius(double rankin) => rankin * 5 / 9 - 273.15;
		public static double FromRéaumurToCelsius(double réaumur) => réaumur * 5 / 4;
	}
	class Program
	{
		delegate double delegateConvertTemperature(double d);
		static void Main()
		{
			delegateConvertTemperature[] delegates = { new TemperatureConverterImp().CelsiusToFahrenheit,
														StaticTempConverters.FromCelsiusToKelvin,
														StaticTempConverters.FromCelsiusToRankin,
														StaticTempConverters.FromCelsiusToRéaumur };
			while (true)
			{
				double celsius;
				do
					Console.Write("Enter celsius temperature: ");
				while (!double.TryParse(Console.ReadLine(), out celsius) || celsius < -273.15);
				Console.WriteLine($"{delegates[0](celsius):f2} °F");
				Console.WriteLine($"{delegates[1](celsius):f2} K");
				Console.WriteLine($"{delegates[2](celsius):f2} °R");
				Console.WriteLine($"{delegates[3](celsius):f2} °Ré");
				Console.WriteLine("Press Esc to exit or other key to continue...");
				ConsoleKey key = Console.ReadKey().Key;
				if (key == ConsoleKey.Escape)
					break;
			}
		}
	}
}
