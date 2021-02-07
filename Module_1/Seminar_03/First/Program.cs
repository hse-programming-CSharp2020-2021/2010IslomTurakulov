using System;
using System.Reflection.Metadata.Ecma335;

namespace First
{
    class Program
    {
        static double Bank(double budget , double percentBudget, uint timeBudget)
        {
            double result = budget * timeBudget * (percentBudget / 100) + budget;

            for (int j = 0; j < timeBudget - 1; j++)
            {
                result = result * percentBudget + result;
            }

            return result;
        }
        static void Main(string[] args)
        {
            double budget;
            double percentBudget;
            uint timeBudget;
            do
            {
                Console.WriteLine("Введите ваш начальный капитал: ");
                budget = double.Parse(Console.ReadLine());

                Console.WriteLine("Введите ваш вашу процентную ставку: ");
                percentBudget = double.Parse(Console.ReadLine());


                Console.WriteLine("Сколько лет процентной ставки: ");
                timeBudget = uint.Parse(Console.ReadLine());

                Bank(budget,percentBudget,timeBudget);

                Console.WriteLine("Нажмите ESC для выхода");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
