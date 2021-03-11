using System;
using System.Collections.Generic;
using System.IO;

namespace Task_3
{
    /*Сгенерировать 10 случайных чисел и записать их 4 разными способами в 4 файла: 
    с помощью класса File, с помощью FileStream, с помощью StreamWriter, 
    с помощью BinaryWriter. 
    Вывести содержимое каждого файла. 
    Для любого файла, считывая данные побайтово или посимвольно или построчно 
    (главное, не целиком весь файл), вывести сумму четных чисел.*/

    class Program
    {
        private static Random rnd = new Random();
        static void Main(string[] args)
        {
            string[] paths = { "result1.txt", "result2.txt", "result3.txt", "result4.txt" };
            var intArr = new int[10];
            var strArr = new string[10];
            string text = String.Empty;
            for (int i = 0; i < 10; i++)
            {
                int rndNum = rnd.Next(5, 20);
                intArr[i] = rndNum;
                strArr[i] = rndNum.ToString();
                text += rndNum.ToString();
            }
            File.WriteAllText(paths[0], text);
            using (FileStream fs = new FileStream(paths[1], FileMode.OpenOrCreate))
            {
                byte[] arr = System.Text.Encoding.Default.GetBytes(text);
                fs.Write(arr, 0, arr.Length);

            }
            using (StreamWriter sw = new StreamWriter(paths[2]))
            {
                foreach (var integer in intArr)
                {
                    sw.Write(integer);
                }
            }
            using (BinaryWriter bw = new BinaryWriter(File.OpenWrite(paths[3])))
            {
                foreach (var str in strArr)
                {
                    bw.Write(str);
                }
            }

            using (var sr = new StreamReader(paths[0]))
                Console.WriteLine(sr.ReadToEnd());
            using (var sr = new StreamReader(paths[1]))
                Console.WriteLine(sr.ReadToEnd());
            using (var sr = new StreamReader(paths[2]))
                Console.WriteLine(sr.ReadToEnd());
            using (var sr = new StreamReader(paths[3]))
                Console.WriteLine(sr.ReadToEnd());


            int sum = 0;
            using (var bw = new BinaryReader(File.OpenRead(paths[3])))
            {
                while (bw.PeekChar() > -1)
                {
                    if (int.TryParse(bw.ReadString(), out int res) && res % 2 == 0)
                    {
                        sum += res;
                    }
                }

                Console.WriteLine($"Результат: {sum}");
            }
        }
    }
}
