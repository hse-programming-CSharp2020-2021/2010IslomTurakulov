using System;
using System.IO;

namespace Task_1
{
    class Program
    {
        static void Main()
        {
            BinaryWriter fOut = new BinaryWriter(
                new FileStream("../../../t.dat", FileMode.Create));
            for (int i = 0; i <= 10; i += 2)
                fOut.Write(i);
            fOut.Close();

            FileStream f = new FileStream("../../../t.dat", FileMode.Open);
            BinaryReader fIn = new BinaryReader(f);
            long n = f.Length / 4; int a;
            for (int i = 0; i < n; i++)
            {
                a = fIn.ReadInt32();
                Console.Write(a + " ");
            }
            fIn.Close();
            f.Close();

            Console.WriteLine("\nЧисла в обратном порядке:");
            // 1) TODO: Прочитать и напечатать все числа из файла в обратном порядке
            Console.WriteLine("***");
            using (FileStream fStream = new FileStream("../../../t.dat", FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(fStream))
                {
                    for (int offset = 4; offset <= reader.BaseStream.Length; offset += 4)
                    {
                        reader.BaseStream.Seek(-offset, SeekOrigin.End);
                        Console.Write(reader.ReadInt32() + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("***");
            Console.WriteLine("Числа увеличенные в 5 раз:");
            // 2) TODO: увеличить  все числа в файле в 5 раз
            using (FileStream fStream = new FileStream("../../../t.dat", FileMode.Open))
            {
                using (BinaryWriter writer = new BinaryWriter(fStream))
                using (BinaryReader reader = new BinaryReader(fStream))
                {
                    for (int offset = 4; offset <= reader.BaseStream.Length; offset += 4)
                    {
                        reader.BaseStream.Seek(-offset, SeekOrigin.End);
                        var temp = reader.ReadInt32();
                        writer.Write(temp * 5);

                        Console.Write(temp * 5 + " ");
                    }
                }

                Console.WriteLine();
            }
            Console.WriteLine("***");
            Console.WriteLine("Числа из файла в прямом порядке:");
            // 3) TODO: Прочитать и напечатать все числа из файла в прямом порядке
            using (FileStream fStream = new FileStream("../../../t.dat", FileMode.Open))
            {
                using (BinaryReader reader = new BinaryReader(fStream))
                {
                    while (reader.PeekChar() > -1)
                    {
                        Console.Write(reader.ReadInt32() + " ");
                    }
                }
            }
        }
    }
}