using System;

namespace CW1
{
    class Program
    {
        // Добавим метод который выводит значение полинома
        static double Fx(double x)
        {
            // Минимальное кол-во операций умножения - 5
            double res = (x + 1) * (3 * x * (x * (4 * x - 1) + 2) - 4);
            return res;
        }
        static void Main(string[] args)
        {
            try
            {
                double a;
                string str;

                Console.WriteLine("Самостоятельная работа 1");
                Console.WriteLine("Требования: Ввести значение x и вывести значение полинома");
                // По желанию можно использовать if,else
                do
                {
                    Console.WriteLine("Введите значение x: ");
                    str = Console.ReadLine();
                } while (!double.TryParse(str, out a));

                // Выдал значение a и отправляю в метод Fx()
                Console.WriteLine($"Ответ: {Fx(a)}");
                Main(args);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
