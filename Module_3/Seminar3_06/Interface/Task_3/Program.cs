using System;

namespace Task_3
{
    public delegate double calculate();

    class F
    {
        interface IFunction
        {
           static double Function(double x);
        }
    }

    class G : F
    {
        public G(double first, double second)
        {

        }

        public double GF(double x0)
        {
            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            F fun1 = new F();
            fun1.
        }
    }
}
