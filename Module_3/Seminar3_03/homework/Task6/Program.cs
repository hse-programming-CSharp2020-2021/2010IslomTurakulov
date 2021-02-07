using System;
using System.Linq;

namespace Task6
{
    public delegate void MethodsEvents();
    public delegate void ItemEvents(int[,] ar);

    public class Methods
    {
        public static event MethodsEvents LineComplete; //  строка заполнена
                                                        // новый элемент проинициализирован 
        public static event ItemEvents NewItemFilled;
        // метод заполнения массива
        public static void ArrayFill(int[,] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                {
                    arr[i, j] = rnd.Next(99) + 1;
                    NewItemFilled?.Invoke(arr);
                }
        }
        // обработчик события добавления элемента вычисляет сумму элементов
        public static void ArraySumCount(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                    sum += arr[i, j];
            }
            Console.WriteLine($"Sum: {sum}");
        }
        public static void ArrayPrint(int[,] arr)
        {
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                    Console.Write(arr[i, j] + " ");
                LineComplete(); // событие!!
            }
        }
        public static void ArrayAverage(int[,] arr)
            => Console.WriteLine($"Average: {Math.Round(arr.Cast<int>().Where(x => x > 0).Average(), 2)}");
        public static void ArrayMax(int[,] arr)
            => Console.WriteLine($"Maximum: {arr.Cast<int>().Max()}");
    }
    class Program
	{
		static void Main(string[] args)
		{
            int[,] arr = new int[15, 15];
            Methods.LineComplete += () => { Console.WriteLine(); };
            Methods.NewItemFilled += Methods.ArraySumCount;
            Methods.NewItemFilled += Methods.ArrayAverage;
            Methods.NewItemFilled += Methods.ArrayMax;
            Methods.ArrayFill(arr);
            Methods.ArrayPrint(arr);
        }
    }
}
