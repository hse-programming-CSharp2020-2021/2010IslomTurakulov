using System;

namespace Task_3
{
    class Program
    {
        public static void SortValue(ref int x, ref int y, ref int z)
        {
            // Вспомогательные переменные
            int a1, a2 , a3;

            a1 = (x <= y) ? (z < x ? z : x) : (y < z ? y : z);
            a3 = (x >= y) ? (z > x ? z : x) : (y > z ? y : z);
            a2 = (z >= x) ? (x > y ? x : y) : (x < y ? x : y);

            int min = a1;
            int mid = a2;
            int max = a3;

            Console.WriteLine($"Минимальное значение: {min} ");
            Console.WriteLine($"Среднее значение {mid} ");
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
