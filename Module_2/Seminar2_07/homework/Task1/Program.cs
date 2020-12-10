using System;

namespace Task1
{
	class A
	{
		public virtual void GetA() => Console.Write('A');
	}
	class B : A
	{
		public override void GetA() => Console.Write('B');
	}
	class Program
	{
		static void Main()
		{
			A[] array = new A[10];
			Random rnd = new Random();
			for (int i = 0; i < 10; i++)
				array[i] = rnd.Next(0, 2) == 0 ? new A() : new B();
			foreach (A d in array)
				d.GetA();
			Console.WriteLine();
			Console.Write("Объекты класса B: ");
			foreach (A d in array)
				if (d is B)
					d.GetA();
			Console.WriteLine();
			Console.Write("Объекты класса A: ");
			foreach (A d in array)
				if (!(d is B))
					d.GetA();
		}
	}
}
