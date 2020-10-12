using System;
using System.IO;
using System.Text;



namespace ConsoleApp23
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Data.txt";



            // Создаем файл с данными
            if (!File.Exists(path))
            {
                int n = 10;
                string createText = "";
                Random random = new Random();
                for (int i = 0; i < n; i++)
                {
                    createText += random.Next(10, 100) + " ";
                    if (i == n / 2 - 1)
                    {
                        createText += Environment.NewLine;
                    }
                }
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

                Console.WriteLine();
                int[] odd = new int[arr.Length];
                int[] even = new int[arr.Length];
                int numodd = 0, numeven = 0;



                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)
                        odd[numodd++] = i;
                    else
                    {
                        even[numeven++] = i;
                        arr[i] = 0;
                    }
                }
                Array.Resize(ref odd, numodd);
                Array.Resize(ref even, numeven);



                Array.ForEach(odd, x => Console.Write(x + " "));
                Console.WriteLine();
                Array.ForEach(even, x => Console.Write(x + " "));
                Console.WriteLine();
                Array.ForEach(arr, x => Console.Write(x + " "));
                Console.WriteLine();



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