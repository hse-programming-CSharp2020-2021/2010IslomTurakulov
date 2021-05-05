using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Seminar4_1
{
    [Serializable]
    class Student
    {
        public string name;
        private int year;
        public Student(string n, int y)
        {
            name = n;
            year = y;
        }
        public int getYear()
        {
            return year;
        }
    }

    [Serializable]
    class Group
    {
        public Student[] Students { get; private set; }
        public string Name { get; set; }

        public Group(string name, Student[] students)
        {
            Name = name;
            Students = students;
        }
    }

    class Program
    {
        private static Random rnd = new Random();
        private static string NameGenerator()
        {
            char upper = (char)rnd.Next(65,91);
            string rest = $"{upper}{(char) rnd.Next(97, 123)}{(char) rnd.Next(97, 123)}{(char) rnd.Next(97, 123)}";
            return rest;
        }

        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.Write("Введите количество студентов: ");
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n >= Int32.MaxValue);

            Student[] studentArray = new Student[n];
            for (int i = 0; i < n; i++)
            {
                var student =  new Student(NameGenerator(), rnd.Next(15, 151));
                studentArray[i] = student;
            }

            BinaryFormatter formatter = new BinaryFormatter();
 
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, studentArray);
            }

            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                Student[] deserilizePeople = (Student[])formatter.Deserialize(fs);
 
                foreach (Student p in deserilizePeople)
                {
                    Console.WriteLine($"Name: {p.name} , Age: {p.getYear()}");
                }
            }
        }
    }
}
