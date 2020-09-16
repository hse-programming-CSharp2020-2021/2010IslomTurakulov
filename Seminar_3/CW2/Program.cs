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
        static void ReversedNumber(int a)
        {
            Console.WriteLine(a.ToString().Reverse().ToArray());
        }
        static void Main(string[] args)
        {
            int numValue;
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
                    Console.Write("Обратное число: ");
                    ReversedNumber(numValue);
                }

                Console.WriteLine("Нажмите на ESC чтобы выйти..");
            } while(Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
