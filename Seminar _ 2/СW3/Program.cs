using System;
using System.Runtime.ExceptionServices;

namespace СW3
{
    class Program
    {
        static string raschet(ref double a, ref double b, ref double c)
        {
            // Задаю доп. переменные
            double D;
            double x1;
            double x2;

            // Формула Дискриминанта
            D = Math.Pow(b, 2) - 4 * a * c;
            x1 = (-b + Math.Sqrt(D)) / (2 * a);
            x2 = (-b - Math.Sqrt(D)) / (2 * a);
            
            return (D > 0) ? $"Ответ: первый корень {x1.ToString("F3")} , второй корень {x2.ToString("F3")}" : "Действительных корней нет";
        }
        static void Main(string[] args)
        {
            // Для обработки Исключений использовал try, catch
            try
            {
                double a;
                double b;
                double c;

                Console.WriteLine("Требования: Вычислить корни квадратного уравнения");
                //ax^2+bx+с
                //D=b^2-4ac
                do
                {
                    Console.Write("Введите значение a: ");
                    a = double.Parse(Console.ReadLine());
                    Console.Write("Введите значение b: ");
                    b = double.Parse(Console.ReadLine());
                    Console.Write("Введите значение c: ");
                    c = double.Parse(Console.ReadLine());

                    Console.WriteLine(raschet(ref a, ref b, ref c));
                    Console.WriteLine("Нажмите ESC чтобы выйти..");
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            }
            catch (Exception ex)
            {
                Console.WriteLine("\nВы ввели неккоректные данные");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
