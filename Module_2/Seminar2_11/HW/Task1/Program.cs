using System;
using MyLib;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix;
            int rank;
            do
            { 
                try
                {
                    rank = Methods.GetIntValue("Введите порядок матрицы: ");
                    matrix = new Matrix().UnitMatr(rank);
                    matrix.MatrPrint();
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
    }
}
