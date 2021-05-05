using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

/*  Задача 3.
    Определить класс PascalVseleon, реализующий коллекцию из n чисел Люка.
    Класс PascalVseleon реализует интерфейс IEnumerable<int>. 
    Необходимо предоставить возможность обходить элементы коллекции через foreach. 
    Для того, чтобы это было возможно, необходимо определить закрытый класс
    LucasCollectionEnumerator, реализующий доступ к отдельным элементам коллекции 
    (реализует интерфейс IEnumerator<int>). 
    Класс PascalVseleon должен использовать не встроенный перечислитель, 
    а PascalVseleon Enumerator, который реализует IEnumerator<int>.
    Создать программу, которая получает на вход число n – количество чисел Люка
    в последовательности PascalVseleon. С помощью оператора foreach вывести
    последовательность на экран. */
namespace Task_2
{
    public class PascalVseleon : IEnumerable<string>
    {
        private readonly int _cap;

        public PascalVseleon(int cap) => this._cap = cap;

        public IEnumerator<string> GetEnumerator() => GetNMFloyd(0, _cap);

        IEnumerator IEnumerable.GetEnumerator() => GetNMFloyd(0, _cap);

        public IEnumerable<string> GetNMEnumerator(int start, int end) => GetNm(start, end);

        public IEnumerator<string> GetNMFloyd(int start, int end)
        {
            var factorial = string.Empty;
            for (var i = start; i < end; i++)
            {
                for (var c = start; c <= i; c++)
                {
                    factorial += " ";
                    factorial += Factorial(i) / (Factorial(c) * Factorial(i - c));
                }
                yield return factorial;
            }
        }
 
        public IEnumerable<string> GetNm(int start, int end)
        {
            var factorial = string.Empty;
            for (var i = start; i < end; i++)
            {
                for (var c = 0; c <= i; c++)
                {
                    factorial += " ";
                    factorial += Factorial(i) / (Factorial(c) * Factorial(i - c));
 
                }
 
                yield return factorial;
            }
        }

        public static float Factorial(int n)
        {
            var x = 1;
            for (var i = 1; i <= n; i++)
            {
                x *= i;
            }

            return x;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var res = int.Parse(Console.ReadLine() ?? "1");
            PascalVseleon pv = new PascalVseleon(res);
            foreach (var str in pv)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine();
            foreach (var str in pv.GetNMEnumerator(2, 4))
            {
                Console.WriteLine(str);
            }
        }
    }
}
