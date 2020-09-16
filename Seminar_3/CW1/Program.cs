using System;

namespace CW1
{
    /*
     * Написать метод, находящий трехзначное десятичное число s, 
     * все цифры которого одинаковы и которое представляет собой сумму первых членов натурального ряда
     */
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                do
                {
                    int a = 1;

                    while (a * (a + 1) % 111 != 0)
                    {
                        a++;
                        int d = (a * (a + 1)) / 2;
                        Console.WriteLine(d);
                    }
                    Console.WriteLine("Нажмите на ESC чтобы выйти");

                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Причина ошибки {ex.Message}");
            }
        }
    }
}
