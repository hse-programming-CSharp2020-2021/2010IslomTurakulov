using System;

namespace Fourth
{
    class Program
    {
        static void Main(string[] args)
        {
            float old = 1, res = 0;

            for (int i = 0; old - res != 0.0 ; i++) // около нуля ставим decimal
            {
                old = res;// мы хотим сохранить текущее и настоящее
                res += 1 / ((float)i * (i + 1) * (i + 2)); //double , decimal
            }
            Console.WriteLine(old);
            Console.WriteLine(res);
        }
    }
}
