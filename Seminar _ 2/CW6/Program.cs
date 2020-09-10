using System;

namespace CW6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double budget;
                int percentBudget;
          
                Console.WriteLine("Требования: Вычислить и вывести бюджет пользователя на экран сумму в рублях\евро или долларах");
                Console.WriteLine("Введите ваш бюджет: ");
                budget = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите процент от бюджета: ");
                percentBudget = int.Parse(Console.ReadLine());




            }
            catch(Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}
