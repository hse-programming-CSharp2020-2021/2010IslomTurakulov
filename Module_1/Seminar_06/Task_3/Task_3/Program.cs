using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        //static Random rnd = new Random();

        static double SinFinder(double x)
        {
            // Создаём новый List.
            List<double> sinRow = new List<double>();
            // погрешность вычислений.
            const double eps = 1e-15; 
            //double sum = 0;
            //double result = x;
            sinRow.Add(x);
            int digits = 1;
            while (Math.Abs(sinRow[sinRow.Count - 1]) > eps)
            {
                // добавляет к числу +2.
                digits = digits + 2;
                sinRow.Add((-sinRow[sinRow.Count - 1]) * x * x / (digits * (digits - 1)));
            }
            //Вывод результата.
            Console.WriteLine(sinRow.Count);
            // Вывод суммы.
            return sinRow.Sum();
        }
        static void Main()
        {
            //Создаём переменную x.
            double x;
            do
            {
                Console.WriteLine("Enter the digit x: ");
            } while (!double.TryParse(Console.ReadLine(), out x));
            // Проверяем метод и ставим переменные.
            double result = SinFinder(x);
            //Результат вывода.
            Console.WriteLine($"Результат вывода: {result}");
            Console.WriteLine("Сравнение исходного и изменённого: ");

            // Сравнивает результаты.
            if (x.Equals(result))
                Console.Write("Верно");
            else
                Console.Write("Они не похожи");

            Console.ReadLine();
        }
    }
}
