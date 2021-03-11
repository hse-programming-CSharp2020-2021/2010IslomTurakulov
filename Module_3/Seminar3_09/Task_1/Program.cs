using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task_1
{
    class ColorPoint
    {
        public static string[] colors = { "Red", "Green", "DarkRed", "Magenta",
            "DarkSeaGreen", "Lime", "Purple", "DarkGreen", "DarkOrange", "Black",
            "BlueViolet", "Crimson", "Gray", "Brown", "CadetBlue" };
        public double x, y;
        public string color;
        public override string ToString()
        {
            string format = "{0:F3}    {1:F3}    {2}\n";
            return string.Format(format, x, y, color);
        }
    }

    class Program
    {
        static Random gen = new Random();
        public static void Main()
        {
            string path = @"..\..\..\..\MyTest.txt";
            int N = 3; // Количество создаваемых объектов (число строк в файле)
            //  TODO: Определить значение N 
            List<ColorPoint> list = new List<ColorPoint>();
            ColorPoint one;
            for (int i = 0; i < N; i++)
            {
                one = new ColorPoint();
                one.x = gen.NextDouble();
                one.y = gen.NextDouble();
                int j = gen.Next(0, ColorPoint.colors.Length);
                one.color = ColorPoint.colors[j];
                list.Add(one);
            }
            string[] arrData = Array.ConvertAll(list.ToArray(),
                (ColorPoint cp) => cp.ToString());
            // Запись массива стpок в текстовый файл:         
            //File.WriteAllLines(path, arrData);
            using (var fs = new FileStream(path, FileMode.Create))
            {
                foreach (var str in arrData)
                    foreach (var arr in str.Select(BitConverter.GetBytes))
                        fs.Write(arr);
            }

            Console.WriteLine("Записаны {0} строк в текстовый файл: \n{1}",
                N, path);

            using (var fs = File.OpenRead(path))
            {
                var arrBytes = new byte[fs.Length];
                fs.Read(arrBytes, 0, arrBytes.Length);
                Console.WriteLine($"Текст: \n{System.Text.Encoding.Default.GetString(arrBytes)}");
            }
        }
    }
}
