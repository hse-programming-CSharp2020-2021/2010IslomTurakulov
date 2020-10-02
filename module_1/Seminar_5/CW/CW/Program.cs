using System;

namespace CW
{
    class Program
    {
        static int[] SortingArray(ref int firstNum)
        {
            int[] result = new int[firstNum];
            //Using loop we start sorting the value from 0 to length of the value
            for (int i = 0; i < firstNum; i++)
            {
                //example: 345
                int a = firstNum % 10;
                result[i] = a;
                firstNum = firstNum / 10;
                //final output [5],[4],[3]
            }
            //Reverse the Array
            Array.Reverse(result);
            //returning result to the first Method
            return result;
        }
        static void SquareArray()
        {
            
        }
        static void Main(string[] args)
        {
            int firstNum;

            Console.WriteLine("Введите целое число: ");
            while (!int.TryParse(Console.ReadLine(), out firstNum) || firstNum < 0)
            {
                Console.WriteLine("Incorrect input");
            }
            SortingArray(ref firstNum);
        }
    }
}
