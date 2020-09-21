using System;
using System.Linq;

namespace CW2
{
    /* Написать метод, преобразующий число переданное в качестве параметра в число, 
     * записанное теми же цифрами, но идущими в обратном порядке. 
     */

    class Program
    {
        /// <summary>
        /// Выводит число в обратном порядке
        /// </summary>
        /// <param name="a">Число</param>
        static int ReversedNumber(int a)
        {
            //Console.WriteLine(a.ToString().Reverse().ToArray());

            string se = string.Empty;

            while (a != 0)
            {
                se += (a % 10).ToString();
                a /= 10;
            }

            return int.Parse(se);
        }
        static void Main(string[] args)
        {
            int numValue;
            try
            {
                do
                {
                    Console.Write("Напишите любое число: ");
                    string inputValue = Console.ReadLine();

                    // Проверка на данные (string,char,float,double)
                    if (!int.TryParse(inputValue, out numValue) || numValue < 0)
                    {
                        Console.WriteLine("Неккоректные данные!");
                    }
                    else
                    {
                        Console.WriteLine(ReversedNumber(numValue));
                    }

                    Console.WriteLine("Нажмите на ESC чтобы выйти..");
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
