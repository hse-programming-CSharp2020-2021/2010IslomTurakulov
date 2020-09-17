using System;

namespace CW6
{
    class Program
    {
        static void SortAuditorium(ref int x,ref int y,ref int z)
        {
            int minXY = Math.Min(x, y);
            int min = minXY > z ? z : minXY;

            Console.WriteLine($"Минимальный номер внутри этажа: {min} ");
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

                int floor = (codeNum / 100), floor3 = (codeNum / 100), floor2 = (codeNum / 100);
                int auditorium1 = (codeNum % 100), auditorium2 = (codeNum2 % 100), auditorium3 = (codeNum3 % 100);

                SortAuditorium(ref auditorium1, ref auditorium2, ref auditorium3);

                Console.WriteLine("Для выхода нажмите ESC...");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
