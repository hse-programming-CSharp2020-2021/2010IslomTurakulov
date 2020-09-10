using System;
using System.Globalization;

namespace CW6
{
    class Program
    {
        static void Rub(ref double a, ref double b)
        {
            double result = (a * (b / 100));
            Console.Write("Выделено на компьютерные игры : ");
            Console.WriteLine(string.Format(new CultureInfo("ru-RU"), $"{result:c3}"));
    
        }
        static void Dollar(ref double a, ref double b)
        {
            double result = ((a/72.1) * (b / 100));
            Console.Write("Выделено на компьютерные игры : ");
            Console.WriteLine(string.Format(new CultureInfo("en-US"), $"{result:c3}"));
        }
        static void Euro(ref double a, ref double b)
        {
            double result = ((a / 89.1) * (b / 100));
            Console.Write("Выделено на компьютерные игры : ");
            Console.WriteLine(string.Format(new CultureInfo("fr-FR"), $"{result:c3}"));
        }
        static void Main(string[] args)
        {
            try
            {
                double budget;
                double percentBudget;
                do
                {
                    Console.WriteLine("Требования: Вычислить и вывести бюджет пользователя и процент на экран сумму в рублях или евро или долларах");
                    
                    Console.WriteLine("Какую валюту вы будете использовать?");
                    Console.WriteLine("[0] - рубль, [1]- доллар, [2] - евро");
                    string currency = Console.ReadLine();
                    Console.WriteLine("Введите ваш бюджет: ");
                    budget = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите процент от бюджета: ");
                    percentBudget = int.Parse(Console.ReadLine());

                    switch (currency)
                    {
                        case "0":
                            Rub(ref budget, ref percentBudget);
                            continue;
                        case "1":
                            Dollar(ref budget, ref percentBudget);
                            continue;
                        case "2":
                            Euro(ref budget, ref percentBudget);
                            continue;
                        default:
                            Console.WriteLine("Ошибка в поле ввода..");
                            break;
                    }

                    Console.WriteLine("Нажмите на ESC для выхода...");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
                

            }
            catch(Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}
