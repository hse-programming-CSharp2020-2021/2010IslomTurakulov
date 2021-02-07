using System;

namespace CW1
{
    class Program
    {
        static bool IsNumber(ref double a, ref double b, ref double c)
        {
            double result = a + b;
            if (result == c)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            bool numberBool;
            do
            {
                do
                {
                    Random randomNumber = new Random();
                    int rnd = randomNumber.Next(1, 20);

                    double a = Math.Pow(rnd, 2);
                    double b = Math.Pow(rnd, 2);
                    double c = Math.Pow(rnd, 2);

                    numberBool = IsNumber(ref a, ref b, ref c);

                } while (numberBool == true);

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
            
    }
}
