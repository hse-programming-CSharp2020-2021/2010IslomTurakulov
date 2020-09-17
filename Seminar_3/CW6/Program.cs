using System;

namespace CW6
{
    class Program
    {
        static void SortAuditorium(ref int x,ref int y,ref int z)
        {
            int minXY = Math.Min(x, y);
            int min = minXY > z ? z : minXY;

            int floor = min / 100;
            int auditorium = min % 100;
            Console.WriteLine($" Минимальный номер внутри этажа: {floor} этаж {auditorium} аудитория ");
        }
        static void Main(string[] args)
        {
            int codeNum, codeNum2, codeNum3;
            do
            {
                Console.Clear();

                Console.WriteLine("Введите номер этажа и номер аудитории на этаже");
                Console.WriteLine("Например: 322 (3-этаж 22 аудитория)");
                Console.Write("Введите первый номер этажа и аудитории: ");
                while (!int.TryParse(Console.ReadLine(), out codeNum) || codeNum < 0 || codeNum >= 999)
                {
                    Console.WriteLine("Incorrect input");
                    Console.Write("Введите первый номер этажа и аудитории: ");
                }
                Console.Write("Введите второй номер этажа и аудитории : ");
                while (!int.TryParse(Console.ReadLine(), out codeNum2) || codeNum < 0 || codeNum >= 999)
                {
                    Console.WriteLine("Incorrect input");
                    Console.Write("Введите второй номер этажа и аудитории : ");
                }
                Console.Write("Введите третий номер этажа и аудитории: ");
                while (!int.TryParse(Console.ReadLine(), out codeNum3) || codeNum < 0 || codeNum >= 999)
                {
                    Console.WriteLine("Incorrect input");
                    Console.Write("Введите третий номер этажа и аудитории: ");
                }
                SortAuditorium(ref codeNum, ref codeNum2, ref codeNum3);

                Console.WriteLine("Для выхода нажмите ESC...");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
