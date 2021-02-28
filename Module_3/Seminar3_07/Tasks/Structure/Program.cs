using System;
using System.Diagnostics;

namespace Structure
{
    /*
    class TestClass : IComparable
    { // тестовый класс
        public int X { get; set; }
        public int CompareTo(object other)
        {
            return X.CompareTo(((TestClass)other).X);
        }
    }
    struct TestStruct : IComparable
    { // тестовая структура
        public int x;
        public int CompareTo(object other)
        {
            return x.CompareTo(((TestStruct)other).x);
        }
    }
    */

        
    class TestClass : IComparable<TestClass>
    { // тестовый класс
        public int X;

        public int CompareTo(TestClass other)
        {
            return X.CompareTo(other.X);
        }
    }
    struct TestStruct : IComparable<TestStruct>
    { // тестовая структура
        public int X;

        public int CompareTo(TestStruct other)
        {
            return X.CompareTo(other.X);
        }
    }
    


    class Program
    {
        public static Random Rnd = new Random();
        private const int N = 1000000;
        public static void PrintTime(TimeSpan timesp)
        { 
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                      timesp.Hours, timesp.Minutes, timesp.Seconds,
                      timesp.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }


        static void Main(string[] args)
        {
            TestClass[] tc = new TestClass[N]; 
            TestStruct[] ts = new TestStruct[N]; 
            for (int i = 0; i < N; i++)
            {
                tc[i] = new TestClass();
                int tmp = Rnd.Next();
                tc[i].X = tmp;
                ts[i].X = tmp;
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Array.Sort(ts); // сортируем массив структур
            sw.Stop();
            Console.WriteLine("Struct time");
            PrintTime(sw.Elapsed);

            sw.Restart();
            Array.Sort(tc); // сортируем массив объектов классов
            sw.Stop();
            Console.WriteLine("Class time");
            PrintTime(sw.Elapsed);
        }

    }
}