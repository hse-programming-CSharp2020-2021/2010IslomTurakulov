using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var array = Array.ConvertAll(Console.ReadLine().ToArray(), ch => ch.ToString());
            Array.Sort(array);

            LinkedList<int> list = new LinkedList<int>();
            foreach (var t in array)
                list.AddFirst(int.Parse(t));

            foreach (var item in list)
                Console.Write($"{item}");

            Console.WriteLine();


            Stack<int> stackList = new Stack<int>();
            foreach (var item in array)
                stackList.Push(int.Parse(item));

            foreach (var item in array)
                Console.Write($"{item}");

            Console.WriteLine();
        }
    }
}
