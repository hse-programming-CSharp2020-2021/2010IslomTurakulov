using System;
using MyLib;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            GeomProgr geomProgrObj; // ссылка на объект типа GeomProgr
            bool flag;
            int b, q;
            do
            {
                flag = false;
                try
                {
                    Console.Write("Введите начальный член прогрессии: ");
                    b = int.Parse(Console.ReadLine());
                    Console.Write("Введите знаменатель прогрессии: ");
                    q = int.Parse(Console.ReadLine());
                    geomProgrObj = new GeomProgr(b, q); // создаем объект 2
                    do
                    {
                        try
                        {
                            Console.WriteLine("Введите N: ");
                            int n = int.Parse(Console.ReadLine());
                            Console.WriteLine($"N-ый член прогрессии: {geomProgrObj[n]}");
                            Console.WriteLine($"Сумма первых N членов прогрессии: {geomProgrObj.ProgrSum(n)}");
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Для завершения программы нажмите ESC");
                            continue;
                        }
                        catch (ArgumentNullException)
                        {
                            Console.WriteLine("Ввод окончен");
                            return;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Некорректный ввод. Требуется ввести целое число");
                            Console.WriteLine("Для завершения программы нажмите ESC");
                            continue;
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Некорректный ввод. Введено слишком большое целое число");
                            Console.WriteLine("Для завершения программы нажмите ESC");
                            continue;
                        }
                        Console.WriteLine("Для завершения программы нажмите ESC");
                    } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Конец входного файла");
                }
                catch (FormatException)
                {
                    flag = true;
                    Console.WriteLine("Некорректные входные данные! Требуется ввести целые числа");
                }
                catch (OverflowException)
                {
                    flag = true;
                    Console.WriteLine("Некорректные входные данные! Введены слишком большие числа");
                }
                catch (Exception)
                {
                    flag = true;
                    Console.WriteLine("Некорректные входные данные! ");
                }
            } while (flag);
        }
    }
}
