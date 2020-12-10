using System;

namespace Figures
{
	public class Figures
	{
		public class Point
		{
			protected double x, y;

			public virtual void Display() { }
			public virtual double Area { get; }
		}
		public class Circle : Point
		{
			double rad;

			public Circle(double x, double y, double rad)
			{
				this.x = x;
				this.y = y;
				Rad = rad;
			}
			public double Rad
			{
				get => rad;
				set
				{
					if (value <= 0)
						throw new ArgumentException("Radius should be positive");
					rad = value;
				}
			}
			public override void Display() => Console.WriteLine($"Circle. X: {x:f3}; Y: {y:f3}; Radius: {Rad:f3}");
			public override double Area { get => Math.PI * Rad * Rad; }
			public double Len { get => 2 * Math.PI * Rad; }
		}
		public class Square : Point
		{
			double side;

			public Square(double x, double y, double side)
			{
				this.x = x;
				this.y = y;
				Side = side;
			}
			public double Side
			{
				get => side;
				set
				{
					if (value <= 0)
						throw new ArgumentException("Length of side should be positive");
					side = value;
				}
			}
			public override void Display() => Console.WriteLine($"Square. X: {x:f3}; Y: {y:f3}; Side: {Side:f3}");
			public override double Area { get => Side * Side; }
			public double Len { get => 4 * Side; }
		}
	}
}
