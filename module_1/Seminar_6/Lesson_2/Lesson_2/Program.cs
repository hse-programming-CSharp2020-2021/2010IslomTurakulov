using System;

namespace Lesson_2
{
    class Program
    {
        static void GeneratingArray()
        { 
            
        }
        static void Main(string[] args)
        {
            //int[] nums1 = { 1, 2, 4, 5, 5 };
            //int[,] nums2 = { { 2, 3, 5 }, { 3, 5, 5 } };
            // int[,] nums3 = new int[2, 3];
            //Console.WriteLine(nums3.Length);
            //Console.WriteLine(nums3.GetLength(0));
            //Console.WriteLine(nums3.GetLength(1));
            int arrayNum;
            do
            {
                Console.WriteLine("Число:");
            } while (!int.TryParse(Console.ReadLine(), out arrayNum));

            int[][] arraySecond = new int[arrayNum][];
            Random rnd = new Random();

            for (int i = 0; i < arraySecond.Length; i++)
            {
                arraySecond[i] = new int[i + 3];
            }
            for (int i = 0; i < arraySecond.Length; i++)
            {
                for (int j = 0; j < arraySecond[i].Length; j++)
                {
                    arraySecond[i][j] = rnd.Next(3, 8);
                }
            }
            for (int i = 0; i < arraySecond.Length; i++)
            {
                for (int j = 0; j < arraySecond[i].Length; j++)
                {
                    Console.Write(arraySecond[i][j] + " ");
                }
            }
        }
    }
}
