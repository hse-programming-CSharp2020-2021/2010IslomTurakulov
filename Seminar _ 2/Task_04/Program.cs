using System;
using System.Linq;

namespace Task_4
{
    /*
       Метод получает параметр типа uint, в дальнейших операциях преобразует его в тип char, 
       затем делает проверку на принадлежность данного аргумента к коду цифры или буквы кириллицы 
       и выводит необходимые сообщения по условию задачи.
     */
    class Program
    {
        /// <summary>
        /// Метод получает uint и затем делает проверку на принадлежность данного аргумента к коду цифры или буквы кириллицы
        /// </summary>
        /// <param name="numValue"> Параметр типа uint</param>
        /// <returns></returns>
        public static string myMethod(uint numValue)
        {
            string str;

            return str = numValue >= (uint)'А' && numValue <= (uint)'я' ? "Это буква!" :
                         numValue >= (uint)'0' && numValue <= (uint)'9' ? "Это цифра!" :
                         "Это не буква и не цифра!";
        }

        static void Main(string[] args)
        {
            try
            {
                do
                {
                    Console.Clear();

                    uint numValue;
                    Console.Write("Введите ASCII код: ");
                    while (!uint.TryParse(Console.ReadLine(), out numValue))
                    {
                        Console.WriteLine("Произошла ошибка!");
                        Console.WriteLine("Попробуйте снова");
                    }

                    Console.WriteLine($"{myMethod(numValue)}");

                    Console.WriteLine("Нажмите ESC для выхода");
                }
                while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Причина ошибки {ex.Message}");
            }
        }
    }
}