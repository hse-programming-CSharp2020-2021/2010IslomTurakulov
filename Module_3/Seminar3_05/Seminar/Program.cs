using System;
using System.Collections.Generic;

namespace Seminar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> newList = new List<int>();
            newList.Add(1);
            newList.AddRange(new int[] { 2, 3, 4 });
            newList.Insert(2, 6);
            newList.RemoveAt(1);
            newList.RemoveRange(1, 2);
            newList.Add(7);
            foreach (var item in newList)
                Console.Write($"{item}");
            Console.WriteLine();


            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);
            LinkedListNode<int> node = new LinkedListNode<int>(3);
            list.AddLast(node);
            list.AddBefore(node, 4);
            LinkedListNode<int> node2 = list.Find(2);
            list.AddBefore(node2, 5);
            list.RemoveFirst();
            foreach (var item in list)
                Console.Write($"{item}");
            Console.WriteLine();


            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();
            Console.WriteLine(stack.Peek());
            stack.Push(4);
            stack.Pop();
            foreach (var item in stack)
                Console.Write($"{item}");
            Console.WriteLine();
            Console.WriteLine("*******************");


            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.Write(queue.Dequeue() + " ");
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Dequeue();
            foreach (var item in queue)
                Console.Write($"{item}");
        }
    }
}
