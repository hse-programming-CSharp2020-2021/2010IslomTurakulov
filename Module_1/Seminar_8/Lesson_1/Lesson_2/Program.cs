using System;
using System.IO;
using System.Text;

namespace ConsoleApp23
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string path = @"Data.txt";

            // Создаем файл с данными
            if (File.Exists(path))
            {
                // Сейчас данные для записи вбиты в коде
                // TODO1: сохранить в файл целые случайные значения из диапазона [10;100)
                string createText = rnd.Next(10, 100).ToString();
                File.WriteAllText(path, createText, Encoding.UTF8);
            }

            // Open the file to read from
            if (File.Exists(path))
            {
                string readText = File.ReadAllText(path);
                string[] stringValues = readText.Split(' ');
                int[] arr = StringArrayToIntArray(stringValues);
                foreach (int i in arr)
                {
                    Console.Write(i + " ");
                }

                // обрабатываем элементы массива
                // TODO2: Создать два массива по исходному
                // в первый поместить индексы чётных элементов, во второй - нечётных
                int[] newArr = arr;
                for (int i = 0; i < newArr.Length; i += 2)
                    Console.WriteLine($"arr[{i}] = {newArr[i]}");
                Console.WriteLine(); // Это что-бы разделить при выводе четные элементы от нечетных
                for (int i = 1; i < newArr.Length; i += 2)
                {
                    newArr[i] = 0;
                    Console.WriteLine(newArr[i]);
                }
                // TODO3: Заменяем все нечётные числа исходного массива нулями
            }
        } // end of Main()
        // преобразование массива строк в массив целых чисел
        public static int[] StringArrayToIntArray(string[] str)
        {
            int[] arr = null;
            if (str.Length != 0)
            {
                arr = new int[0];
                foreach (string s in str)
                {
                    int tmp;
                    if (int.TryParse(s, out tmp))
                    {
                        Array.Resize(ref arr, arr.Length + 1);
                        arr[arr.Length - 1] = tmp;
                    }
                } // end of foreach (string s in str)      
            }
            return arr;
        } // end of StringToIntArray()
    } // end of Program
}
