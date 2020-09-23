using System;

namespace Second
{
    class Program
    {
        static void Main(string[] args)
        {
            int mark;
            do
            {
                Console.Write("Введите вашу оценку: ");
                if (!int.TryParse(Console.ReadLine(), out int grade))
                {
                    Console.WriteLine("Error");
                    return;
                }
                switch (mark) //char,bool,string,int,enum,!null
                {
                    case 1:
                    case 2:
                    case 3:
                        Console.WriteLine("Неудолетворительно");
                        break;
                    case 4:
                    case 5:
                        Console.WriteLine("Удолетворительно");
                        break;
                    case 6:
                    case 7:
                        Console.WriteLine("Хорошо");
                        break;
                    case 8:
                    case 9:
                    case 10:
                        Console.WriteLine("Отлично");
                        break;
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape) ;
            }
        }
    }
}
