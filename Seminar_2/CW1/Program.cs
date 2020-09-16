using System;

namespace CW1
{
    class Program
    {
        // Добавим метод который выводит значение полинома
        static double Fx(double x)
        {
            // Минимальное кол-во операций умножения - 5
            double res = (x * (x * (x * (12 * x + 9) - 3) + 2) - 4);
            return res;
        }
        static void Main(string[] args)
        {
            try
            {
                double a;
                string str;
                string repeat;

                Console.WriteLine("Самостоятельная работа 1");
                Console.Write("\nТребования: Ввести значение x и вывести значение полинома");
                // По желанию можно использовать if,else
                do
                {
                    do
                    {
                        Console.WriteLine("Введите значение x: ");
                        str = Console.ReadLine();
                    } while (!double.TryParse(str, out a));

                    // Выдал значение a и отправляю в метод Fx()
                    Console.WriteLine($"Ответ: {Fx(a)}");

                    Console.WriteLine("Нажмите ESC для повтора программы ");
                }
                while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
