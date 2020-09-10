using System;

namespace Task_3
{
    class Program
    {
        public static void SortValue(ref int x, ref int y, ref int z)
        {
            // Вспомогательные переменные

            int minXY = Math.Min(x, y);
            int maxXY = Math.Max(x, y);
            int max = maxXY < z ? z : maxXY;
            int min = minXY > z ? z : minXY;
            int middle = maxXY == max && minXY == min ? z : x == min || x == max ? y : x;

            Console.WriteLine($"Минимальное значение: {min} ");
            Console.WriteLine($"Среднее значение {middle} ");
            Console.WriteLine($"Максимальное значение {max} ");

        }

        static void Main(string[] args)
        {
            try
            {
                int x, y, z;
                do
                {
                    Console.Write("Введите x = " );
                    x = int.Parse(Console.ReadLine());
                    Console.Write("Введите y = ");
                    y = int.Parse(Console.ReadLine());
                    Console.Write("Введите z = ");
                    z = int.Parse(Console.ReadLine());

                    // Через метод вывожу ответ

                    SortValue(ref x, ref y, ref z);

                    Console.WriteLine("Для выхода нажмите на ESC");
                }
                while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
