using System;

namespace Task6
{
	class Plant
	{
		double growth;
		double photosensivity; // [0;100]
		double frostresistance; // [0; 100]

		public Plant(double growth, double photosensivity, double frostresistance)
		{
			this.growth = growth;
			this.photosensivity = photosensivity;
			this.frostresistance = frostresistance;
		}
		public double Growth
		{
			get => growth;
			set => growth = value;
		}
		public double Photosensivity
		{
			get => photosensivity;
			set
			{
				if (value < 0 || value > 100)
					throw new ArgumentException();
				photosensivity = value;
			}
		}
		public double Frostresistance
		{
			get => frostresistance;
			set
			{
				if(value < 0 || value > 100)
					throw new ArgumentException();
				frostresistance = value;
			}
		}
		public override string ToString()
			=> $"Growth: {growth:f2}; photosensivity: {photosensivity:f2}; frostresistance: {frostresistance:f2}";
	}
	class Program
	{
		static int Comp(Plant x, Plant y)
		{
			int x1 = (int)x.Photosensivity;
			int y1 = (int)y.Photosensivity;
			if (x1 % 2 == 1 && y1 % 2 == 0)
				return 1;
			if (x1 % 2 == y1 % 2)
				return 0;
			return -1;
		}
		static void Main(string[] args)
		{
			int n;
			do
				Console.Write("Enter N: ");
			while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
			Random rnd = new Random();
			Plant[] plants = new Plant[n];
			for (int i = 0; i < n; i++)
				plants[i] = new Plant(rnd.NextDouble() * 75 + 25, rnd.NextDouble() * 100, rnd.NextDouble() * 80);
			Array.ForEach(plants, Console.WriteLine);
			Console.WriteLine();

			Array.Sort(plants, delegate (Plant x, Plant y) {
				return y.Growth.CompareTo(x.Growth);
			});
			Array.ForEach(plants, Console.WriteLine);
			Console.WriteLine();

			Array.Sort(plants, (x, y) => x.Frostresistance.CompareTo(y.Frostresistance));
			Array.ForEach(plants, Console.WriteLine);
			Console.WriteLine();

			Array.Sort(plants, Comp);
			Array.ForEach(plants, Console.WriteLine);
			Console.WriteLine();

			Array.ConvertAll(plants, x => (int)x.Frostresistance % 2 == 0 ? x.Frostresistance /= 3 : x.Frostresistance /= 2);
			Array.ForEach(plants, Console.WriteLine);
			Console.WriteLine();
		}
	}
}
