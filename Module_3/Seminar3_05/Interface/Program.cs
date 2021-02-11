using System;
using System.Collections.Generic;

namespace LinkedList
{
    class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node(int data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return $"{Data} - {Next}";
        }
    }

    class LinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get; set; }

        public void Add(int data)
        {
            Node node = new Node(data);

            if (Head == null)
                Head = node;
            else
                Tail.Next = node;
            Tail = node;

            Count++;
        }

        public void Print()
        {
            Node current = Head;
            while (current != null)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(int data)
        {
            Node current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }

            return false;

        }

        public void AddFirst(int data)
        {
            Node node = new Node(data);

            if (Head == null)
                Head = node;
            else
            {
                node.Next = Head;
                Head = node;
            }

            Count++;

        }

        public Node Max()
        {
            Node current = Head;
            Node maxNode = null;
            while (current != null)
            {
                if (maxNode != null || maxNode.Data < current.Data)
                {
                    maxNode.Data = current.Data;
                }

                current = current.Next;
            }

            return maxNode;
        }


        public Node Min()
        {
            Node current = Head;
            Node maxNode = null;
            while (current != null)
            {
                if (maxNode != null || maxNode.Data > current.Data)
                {
                    maxNode.Data = current.Data;
                }

                current = current.Next;
            }

            return maxNode;
        }

        public void Remove(int data)
        {
            Node previous = null;
            Node current = Head;
            while (current != null)
            {
                if (!Contains(data))
                {
                    previous = current;
                    current = current.Next;
                }
                else
                {
                    if (previous != null) previous.Next = current.Next;
                    if (current.Equals(Head)) current = Head;
                    if (current.Equals(Tail)) Tail = previous;

                    Count--;
                    return;
                }
            }
        }

        
        public Node Middle()
        {
            Node current = Head;
            int mid = (current.Data.ToString().Length - 2) / 2 ;
            for (int i = 0; i < mid; i++)
            {
                current = current.Next;
            }

            return current;
        }

        public void Reverse()
        {
            if (Head == null) return;
            Node previous = null;
            Node current = Head;
            Node next = Head?.Next;
            Tail = current;
            while (current != null)
            {
                current.Next = previous;
                previous = current;
                current = next;
                next = next?.Next;
            }

            Head = previous;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();
            linkedList.Add(10);
            linkedList.Add(5);
            linkedList.Add(20);
            linkedList.Add(13);
            linkedList.AddFirst(2);
            linkedList.Remove(5);
            linkedList.Middle();
            linkedList.Print();
            linkedList.Reverse();
            linkedList.Print();
        }
    }
}