using System;

namespace Task_04
{
    class Program
    {
        static void GetSumOfOddOrEvenDigits(int value, int remainder)
        {
            int sum = 0;
            value = Math.Abs(value);
            while (value != 0)
            {
                int digit = value % 10;
                sum += digit % 2 == remainder ? value % 10 : 0;
                value /= 10;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            uint naturalNumbers;
            Console.WriteLine("Введите любое натуральное число: ");
            if (!uint.TryParse(Console.ReadLine(),out naturalNumbers))
                Console.WriteLine("Incorrect input");
            else
                GetSumOfOddOrEvenDigits()

        }
    }
}
