using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Task_2
{
    /*Создать бинарный файл Numbers и записать в него 
    средствами класса BinaryWriter 10 целых чисел, случайно выбранных из интервала [1;100].
    Вывести на экран числа из файла Numbers, а затем заменить в  
    этом файле на введенное пользователем целое значение число, 
    ближайшее по значению к тому, которое ввел пользователь,
    и вновь вывести числа из файла на экран.
    Вводимое число, не принадлежащее интервалу [1;100],  игнорировать.*/

    class Program
    {
        private static Random rnd = new Random();
        static void Main(string[] args)
        {
            string path = "../../../t.dat";
            BinaryWriter fOut = new BinaryWriter(
                new FileStream(path, FileMode.Create));
            for (int i = 0; i <= 10; i += 2)
                fOut.Write(rnd.Next(1, 101) + " ");
            fOut.Close();
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                BinaryWriter fEdit = new BinaryWriter(fs);
                BinaryReader fIn = new BinaryReader(fs);
                string[] lineOfData = fIn.ReadInt32().ToString().Split();
                for (int i = 0; i < lineOfData.Length; i++)
                {
                    Console.Write($"Число {lineOfData[i]}, хотите заменить? [Y/N]: ");
                    string choice = Console.ReadLine().ToLower();
                    if (choice.Contains("y"))
                    {
                        Console.WriteLine();
                        Console.Write($"Ваше новое число, которое изменит исходное [{lineOfData[i]}]: ");
                        if (int.TryParse(Console.ReadLine(), out int num) && (num <= 100 && num >= 1))
                        {
                            for (int k = 0, j = 0; j < 1 || k < lineOfData.Length; k++)
                            {
                                if (int.Parse(lineOfData[i]) >= num)
                                {
                                    lineOfData[i] = num + " ";
                                    j++;
                                }

                                if (k == lineOfData.Length - 1 && j < 1)
                                {
                                    k = 0;
                                    num--;
                                }

                                fEdit.Write(lineOfData[i] + " ");
                            }
                        }
                    }
                }
            }

        }
    }
}
