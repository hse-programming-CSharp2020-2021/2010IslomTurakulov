using System;
using System.IO;

namespace Task_3
{
    /*•Написать код, перенаправляющий стандартный поток чтения. 
    Вместо клавиатуры – текстовый файл
    (для этого сгенерировать текстовый файл, содержащий 100 случайных вещественных значений из диапазона 100..1000).
    •Прочитать стандартным потоком все строки текстового файла, вычислить среднее значение элементов и вывести его на экран
    •Восстановить стандартный поток ввода.*/
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\..\data.txt";
            Random rnd = new Random();
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < 100; i++)
                    writer.WriteLine(rnd.Next(1,1001) * 0.1);
            }

            using (StreamReader reader = new StreamReader(path))
            {
                Console.SetIn(reader);
                double sum = 0;
                for (int i = 0; i < 100; i++)
                    sum += double.Parse(Console.ReadLine() ?? string.Empty);
                Console.WriteLine(sum / 100);
                Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            }
        }
    }
}
