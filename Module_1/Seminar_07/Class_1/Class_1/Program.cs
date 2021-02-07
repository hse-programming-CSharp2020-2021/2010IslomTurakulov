using System;

using System.Linq;

namespace ConsoleApp3

{

    class Program

    {

        static void Main(string[] args)

        {

            int[] a = new int[5];

            int n = 2980;

            Array.ForEach(a, x => Console.Write($"{x} "));

            Console.WriteLine();

            int i = 0;

            while (n > 0)

            {

                if (a.Length == i)

                    Array.Resize(ref a, a.Length * 2);

                a[i] = n % 2;

                n /= 2;

                i++;

            }

            Array.Resize(ref a, i);

            Array.ForEach(a, x => Console.Write($"{x} "));

            Console.WriteLine();

        }

    }

}