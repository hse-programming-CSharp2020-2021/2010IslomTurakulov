using System;

class Program
{
    static void Main(string[] args)
    {
        uint N;

        do
        {
            Console.Write("Введите размер массива N: ");
        }
        while (!uint.TryParse(Console.ReadLine(), out N));

        double[] arr = CreateArray(N);
        Console.WriteLine("До Нормировки");
        PrintArray(arr);
        NormArray(ref arr);

        Console.WriteLine("После Нормировки");
        PrintArray(arr);
        Console.ReadKey();
    }
    /// <summary>
    /// Создаёт массив из n элементов.
    /// </summary>
    /// <param name="N">Длина массива</param>
    /// <returns></returns>
    public static double[] CreateArray(uint N)
    {
        double[] arr = new double[N];
        for (int i = 0; i < N; i++)
        {
            arr[i] = ((i * (i + 1)) / 2.0) % N;
        }
        return arr;
    }
    /// <summary>
    /// Нормировка массива
    /// </summary>
    /// <param name="arr"></param>
    public static void NormArray(ref double[] arr)
    {
        if (arr.Length == 0)
        {
            Console.WriteLine("Массив пустой");
            return;
        }

        double max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
                max = arr[i];
        }

        if (Equals(max, 0)) 
        {
            Console.WriteLine("Происходит деление , невозможное действие!");
            return;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = arr[i] / max;
        }
    }
    /// <summary>
    /// Выведение массива в консоль
    /// </summary>
    /// <param name="arr"></param>
    public static void PrintArray(double[] arr)
    {
        foreach (double i in arr)
        {
            Console.Write($"{i:F3} ");
        }
        Console.WriteLine();
    }
}
