using System;

namespace CW2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int numValue;
                Console.WriteLine("Введите трёхзначное число: ");
                numValue = int.Parse(Console.ReadLine());
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
