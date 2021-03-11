using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace DataQueue
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public override string ToString() => $"FirstName: {FirstName}\nLastName: {LastName}\nAge: {Age}\n";
    }

    class ElectronicQueue<T>
    {
        private Queue<T> queue = new Queue<T>();
        public void Enqueue(T field) => queue.Enqueue(field);
        public T Dequeue() => queue.Dequeue();

    }

    class Program
    {
        private static Random rnd = new Random();

        static void Main(string[] args)
        {
            try
            {
                List<string> names = new List<string>()
                {
                    "John",
                    "Alfred",
                    "Artem",
                    "Igor",
                    "Rafaat",
                    "Batya"
                };

                ElectronicQueue<Person> electronicQueue = new ElectronicQueue<Person>();
                for (int i = 0; i < rnd.Next(5,15); i++)
                {
                    electronicQueue.Enqueue(new Person(names[rnd.Next(1,6)] , names[rnd.Next(1,6)], rnd.Next(16,25) ));
                }

                Console.WriteLine();
                for (int i = 0; i < rnd.Next(5,16); i++)
                {
                    Console.WriteLine(electronicQueue.Dequeue());
                }

                Console.WriteLine();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
        }
    }
}
