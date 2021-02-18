using System;

namespace Task_1
{
    interface ICalculation
    {
        double Perform(double input);
    }

    class Add : ICalculation
    {
        private double n;
        public Add(double n)
        {
            this.n = n;
        }

        public double Perform(double input)
        {
            return n + input;
        }
    }

    class Multiply : ICalculation
    {
        private double n;
        public Multiply(double n)
        {
            this.n = n;
        }

        public double Perform(double input)
        {
            return n * input;
        }
    }

    class Program
    {

        private static double Calculate(double input, ICalculation Add, ICalculation Multiply)
        {
            return Multiply.Perform(Add.Perform(input));
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                var x = Calculate(rnd.Next(1,5), new Add(rnd.Next(1,5)), new Multiply(rnd.Next(1,5)));
                Console.WriteLine(x);
            }
        }
    }
}
