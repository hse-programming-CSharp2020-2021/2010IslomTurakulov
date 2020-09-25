using System;

namespace CW2
{
    class Program
    {
        static void Main(string[] args)
        {

            int oddNumber, oddSum;
            oddSum = 0;
            
            do
            {
                if (!int.TryParse(Console.ReadLine(), out oddNumber))
                {
                    Console.WriteLine("Incorrect input");
                    return;
                }
                else
                {
                    if (oddNumber % 2 != 0)
                    {
                        oddSum = oddSum + oddNumber;
                    }
                }
            } while (oddNumber != 0);
        }
    }
}
