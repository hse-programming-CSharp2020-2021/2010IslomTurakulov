using System;
using System.Collections.Generic;

namespace Task3
{
    // Класс многоугольников.
    public class Polygon
    {
        // Число сторон.
#pragma warning disable IDE0044 // Добавить модификатор только для чтения
        int numb;
        // Радиус вписанной окружности.
        double radius;
        public Polygon(int n = 3, double r = 1)
        {
            numb = n;
            radius = r;
        }
        // Периметр многоугольника - свойство.
        public double Perimeter
        {
            get
            {   // аксессор свойства
                double term = Math.Tan(Math.PI / numb);
                return 2 * numb * radius * term;
            }
        }
        // Площадь многоугольника - свойство.
        public double Area
        {
            get
            {
                return Perimeter * radius / 2;
            }
        }
        public string PolygonData()
        {
            string res = string.Format("N={0}; R={1}; P={2,2:F3}; S={3,4:F3}",
                numb, radius, Perimeter, Area);
            return res;
        }
        public void PrintPolygonData(ConsoleColor areaColor)
		{
            Console.Write(string.Format("N={0}; R={1}; P={2,2:F3}; ", numb, radius, Perimeter));
            if (areaColor != 0)
                Console.ForegroundColor = areaColor;
            Console.WriteLine(string.Format("S={0,4:F3}", Area));
            Console.ResetColor();
		}
    }   // Polygon 

    class Program
	{
		static void Main()
		{
            Polygon polygon = new Polygon();
            Console.WriteLine("По умолчанию создан многоугольник: ");
            Console.WriteLine(polygon.PolygonData());
            List<Polygon> list = new List<Polygon>();
            double rad;
            int number;
            double minArea = double.MaxValue;
            double maxArea = 0.0;
            for (int i = 0; ; i++)
            {
                Console.WriteLine($"МНОГОУГОЛЬНИК {i + 1}");
                do Console.Write("\tВведите число сторон: ");
                while (!int.TryParse(Console.ReadLine(), out number) | (number < 3 && number != 0));
                do Console.Write("\tВведите радиус: ");
                while (!double.TryParse(Console.ReadLine(), out rad) | rad < 0);
                if (number == 0)
                {
                    Console.WriteLine("\tКонец ввода");
                    break;
                }
                list.Add(new Polygon(number, rad));
                minArea = Math.Min(minArea, list[i].Area);
                maxArea = Math.Max(maxArea, list[i].Area);
                for (int j = 0; j <= i; j++)
                {
                    Console.Write($"►{j + 1}. ");
                    ConsoleColor areaColor = 0;
                    if (list[j].Area == minArea)
                        areaColor = ConsoleColor.Green;
                    else if (list[j].Area == maxArea)
                        areaColor = ConsoleColor.Red;
                    list[j].PrintPolygonData(areaColor);
                };
                Console.WriteLine();
            }
        }
    }
}
