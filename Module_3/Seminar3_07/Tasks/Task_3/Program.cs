using System;

namespace Application

{
    public struct Test

    {

        public int x, y;

        public Test()

        {

            x = 0;

            y = 0;

        }

        public Test(int x, int y)

        {

            this.x = x;

            this.y = y;

        }

        static void Main()

        {

            Test test;

            test.x = 10;

            test.y = 20;

            Console.WriteLine($"{test.x}; {test.y}");

            Console.ReadKey();

        }

    }
}