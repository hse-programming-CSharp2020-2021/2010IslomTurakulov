using System;

namespace Task_06
{
    class Program
    {
        static void Main(string[] args)
        {
            const int limit = 100;
            bool ok = true;
            double x = 10;
            double y = x, ch = x;
            for (int n = 1; ch >= 100; n++)
            {
                ch *= x * x / (2 * n + 3) / (2 * n + 4);
                y += ch;
                if (n > limit)
                {
                    Console.WriteLine(y);
                }
                else
                    n++;
            }
        }
    }

    }