using System;
using MyLib;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            char start = 'к', finish = 'ю';
            do
            {
                MyStrings testString = new RusString(start, finish, 10);
                MyStrings testString2 = new LatString('k', 'u', 10);
                Console.WriteLine(testString);
                Console.WriteLine(testString.CountLetter('о'));
                Console.WriteLine(testString2);
                Console.WriteLine(testString2.CountLetter('o'));
                // тестируем неверные входные данные
                try
                {
                    testString = new RusString(start, finish, -11);
                    testString2 = new LatString('ю', 'u', 10);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Состояние объекта не изменено");// если объект не сформирован
                }
                Console.WriteLine(testString);
                Console.WriteLine(testString.CountLetter('о'));
                Console.WriteLine(testString2);
                Console.WriteLine(testString2.CountLetter('o'));
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
