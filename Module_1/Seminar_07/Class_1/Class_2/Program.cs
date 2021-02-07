using System;
using System.Linq;

namespace Class_2
{
    class Program
    {
        static int NegativeCounter(int[] array)
        {
            int negativeCount = 0;
            //int[] negativeArray;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    negativeCount++;
                }
            }
            return negativeCount;
        }
        static void MinNumArray(int[] array)
        {
            int minIndex = int.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (minIndex > array[i])
                {
                    minIndex = array[i];
                }
            }
            Console.Write($"{minIndex}  ");
        }
        static void MaxNumArray(int[] array)
        {
            int maxIndex = array.Max();
            int index;
            for (int i = 0; i < array.Length; i++)
            {
                if (maxIndex <= array[i])
                {
                    maxIndex = array[i];
                    // Запоминаем порядковый номер
                    index = i;
                }
            }
            Console.Write($"{maxIndex} ");
        }
        static void Main(string[] args)
        {
            int[] newArray = new int[10];
            Random rand = new Random();
            for(int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = rand.Next(-10,10);
            }
            NegativeCounter(newArray);
            MinNumArray(newArray);
            MaxNumArray(newArray);
        }
    }
}
