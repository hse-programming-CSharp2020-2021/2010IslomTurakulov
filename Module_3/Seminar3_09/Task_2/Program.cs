using System;
using System.IO;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            using var fs = new FileStream(@"..\..\..\..\MyTest.txt", FileMode.OpenOrCreate);
            int t;
            while ((t = fs.ReadByte()) != -1)
                if (t >= '0' && t <= '9')
                    Console.WriteLine("Цифра!: " + (char)t);
        }
    }
}
