using System;

namespace CW5
{
    class Program
    {
        static void TriangleMath(ref double a, ref double b, ref double c)
        {
            // Если не разрешают if , то будем использовать switch,case
            double caseSwitch = 1;
            switch (caseSwitch)
            {
                case 1:
                    Console.Write("Является ли треугольником: ");
                    Console.WriteLine((a + b > c) && (b + c > a) && (a + c > b));
                    double p = (a + b + c) / 2;
                    Console.WriteLine("Площадь треугольника: " + (Math.Sqrt(p * (p - a) * (p - b) * (p - c))).ToString("F3"));
                    break;
                default:
                    Console.WriteLine("Это не треугольник");
                    break;
            }
        }
        static void Main(string[] args)
        {
            //Обработка исключений
            try
            {
                double ab, bc, ac;
                
                Console.WriteLine("Требования: проверить числа на неравенство треугольника ");
                do
                {
                    Console.WriteLine("\n Введите сторону AB: ");
                    ab = double.Parse(Console.ReadLine());
                    Console.WriteLine("\n Введите второе BC: ");
                    bc = double.Parse(Console.ReadLine());
                    Console.WriteLine("\n Введите третье AC: ");
                    ac = double.Parse(Console.ReadLine());

                    TriangleMath(ref ab, ref bc, ref ac);
                    Console.WriteLine("Нажмите ESC для выхода..");

                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

        }
    }
}
