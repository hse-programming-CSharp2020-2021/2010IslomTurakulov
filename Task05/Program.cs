using System;

namespace Task05
{
    class Program
    {
        static void MathHypo()
        {
            double cathetus1, cathetus2, hypotenuse;

            Console.Write("Введите первый катет: ");
            cathetus1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите второй катет: ");
            cathetus2 = Convert.ToDouble(Console.ReadLine());

            hypotenuse = Math.Sqrt(Math.Pow(cathetus1, 2) + Math.Pow(cathetus2, 2));

            Console.WriteLine("Значение гипотенузы: " + hypotenuse.ToString("F4"));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Привет! Программа получает от пользователя значения длин двух катетов, вычислить и вывести на экран значение гипотенузы.");
            MathHypo();

            Console.ReadKey();
        }
    }
}
