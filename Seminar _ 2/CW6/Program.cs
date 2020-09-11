using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CW6
{
    class Program
    {
        /// <summary>
        /// Конвертирует значение в рубли
        /// </summary>
        /// <param name="a">Бюджет пользователя</param>
        /// <param name="b">Процент бюджета пользователя</param>
        static void Rub(ref double a, ref double b)
        {
            Console.OutputEncoding = Encoding.Unicode;
            double result = (a * (b / 100));
            Console.Write("Выделено на компьютерные игры : ");
            Console.WriteLine(string.Format(new CultureInfo("ru-RU"), "{0:c3}", result));
    
        }
        /// <summary>
        /// Конвертирует значение в доллары
        /// </summary>
        /// <param name="a">Бюджет пользователя</param>
        /// <param name="b">Процент бюджета пользователя</param>
        static void Dollar(ref double a, ref double b)
        {
            Console.OutputEncoding = Encoding.Unicode;
            double result = ((a/72.1) * (b / 100));
            Console.Write("Выделено на компьютерные игры : ");
            Console.WriteLine(string.Format(new CultureInfo("en-US"), "{0:c3}", result));
        }
        /// <summary>
        /// Конвертирует значение в евро
        /// </summary>
        /// <param name="a">Бюджет пользователя</param>
        /// <param name="b">Процент бюджета пользователя</param>
        static void Euro(ref double a, ref double b)
        {
            Console.OutputEncoding = Encoding.Unicode;
            double result = ((a / 89.1) * (b / 100));
            Console.Write("Выделено на компьютерные игры : ");
            Console.WriteLine(string.Format(new CultureInfo("fr-FR"), "{0:c3}", result));
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
                    
                    Console.WriteLine("\nВведите ваш бюджет: ");
                    budget = double.Parse(Console.ReadLine());
                    Console.WriteLine("Введите процент от бюджета: ");
                    percentBudget = int.Parse(Console.ReadLine());
                    Console.WriteLine("Какую валюту вы будете использовать?");

                    Console.WriteLine("[0] - рубль, [1]- доллар, [2] - евро");
                    string currency = Console.ReadLine();
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
                            Console.WriteLine("Нет такого значения как {0}", currency);
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
