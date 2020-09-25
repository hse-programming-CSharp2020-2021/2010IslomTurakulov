using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        public static void Sums(uint number, out uint sumEven, out uint sumOdd)
        {
            sumEven = 0; sumOdd = 0; int n = 0;
            uint digits; uint number2 = number;
            while (number != 0)
            {
                number = number / 10;
                n++;
            }

            while (number2 != 0)
            {
                digits = number2 % 10;
                if (n % 2 != 0)
                {
                    sumEven = sumEven + digits;
                }
                else
                {
                    sumOdd = sumOdd + digits;
                }
                number2 = number2 / 10;
                n--;
            }
            Console.WriteLine("Сумма нечетных разрядов");
            Console.WriteLine(sumOdd);
            Console.WriteLine("Сумма четных разрядов");
            Console.WriteLine(sumEven);
        }
        static void Main(string[] args)
        {
            uint sumEven;
            uint sumOdd;
            Console.WriteLine("Введите число");
            uint number;
            while (!uint.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Incorrect input");
            }
            Sums(number, out sumEven, out sumOdd);
        }
    }
}