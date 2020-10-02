using System;
using System.Numerics;

namespace Lesson_1
{
    class Program
    {
        /*static int[] GenerateArray(int numSort)
        {
            int index = 0;
            var arrayNum = new int[numSort.ToString().Length];

            do
            {
                arrayNum[index] = (int)numSort % 10;
                numSort /= 10;
                index++;
            } while (numSort != 0);

           Array.Reverse(arrayNum);
           return arrayNum;
        }*/
        static int[] Array(int[] array)
        {
            int m = 0;

            for (int k = 0; k < array.Length; k++)
            {
                if (array[k] % 2 == 0)
                {
                    array[m++] = array[k];
                }
            }
            return array;
        }
        static int[] GeneratingMassiv(int numSort)
        {
            //Создание объекта для генерации чисел
            Random rnd = new Random();

            var array = new int[numSort];
            for (int i = 1; i < numSort; i++)
            {
                array[i] = (rnd.Next(-10, 10));
            }
            return array;
        }
        static void Main(string[] args)
        {
            int numSort;
            do
            {
                Console.WriteLine("Введите длину числа:");
            } while (!int.TryParse(Console.ReadLine(), out numSort) || numSort < 0);

            Array(GeneratingMassiv(numSort));

        }
    }
}
