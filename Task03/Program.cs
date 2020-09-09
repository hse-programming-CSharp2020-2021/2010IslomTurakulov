using System;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;

            char a1 = 'a';
            Console.WriteLine(a1);

            Console.WriteLine("Введите значения от 32 до 127: ");

            // Проверяет диапазон от 32 до 127

            while (!int.TryParse(Console.ReadLine(), out n) || (n < 32) || (n >= 127))
            {
                Console.WriteLine("Неверные данные");
            }
            Console.WriteLine((char)(n));
        }
    }
}
