using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;


/*
Задание
Интерфейс IVocal (вокал), содержащий метод:
void DoSound() – метод, который выводит сообщение.
(для всех животных класса Bird анонимный метод, выводящий на экран сообщение 
«я птичка, пип-пип-пип», а для всех животных класса Mammal на анонимный метод,
выводящий на экран сообщение «я млекопитающие, би-би-би»).
Абстрактный класс Animal (животное), реализующий интерфейс IVocal,
содержащий автореализуемые свойства:
• Id – целочисленный идентификационный номер животного 
(должен генерироваться автоматически при создании объекта, начиная с 1 – в конструктор это 
значение передавать не нужно!);
• Name – имя животного (строка);
• IsTakenCare – отметка о наличии опекуна
(переменная логического типа, true – есть опекун, false – иначе).
Необходимо:
• Переопределить метод ToString(), возвращающий информацию об объекте (все его свойства).
Неабстрактный класс Mammal (млекопитающее), являющийся наследником класса Animal и содержащий свойство:
• Paws – количество пар лап (от 1 до 20);
Необходимо:
• Переопределить метод ToString(), возвращающий информацию об объекте (все его свойства).
• Определить конструктор с тремя параметрами (имя животного, отметка о наличии опекуна, число пар лап).
Неабстрактный Класс Bird (птица), являющийся наследником класса Animal и содержащий свойство:
• Speed – целочисленная скорость полета, которая может меняться в течение жизни (от 1 до 100);
Необходимо:
• Переопределить метод ToString(), возвращающий информацию об объекте (все его свойства).
• Определить конструктор с тремя параметрами (имя животного, отметка о наличии опекуна, скорость полета).
Класс Zoo (зоопарк), содержащий автореализуемое свойство:
• Animals – список из объектов класса Animal (животных, живущих в зоопарке).
Необходимо:конструктор, создающий список Animal.
*/


namespace Animals
{
    interface IVocal
    {
        void DoSound();
    }

    abstract class Animal : IVocal
    {
        protected static int Id { get; set; }
        public string Name { get; set; }
        public bool IsTakenCare { get; set; }

        protected Animal(string name, bool isTakenCare)
        {
            Id = 1;
            Name = name;
            IsTakenCare = isTakenCare;
        }

        protected static int GetId() => Id++;

        public void DoSound()
        {

        }

        public override string ToString() => $"ID: {Id}; Name: {Name}; IsTakenCare: {IsTakenCare};";
    }

    class Mammal : Animal, IVocal
    {
        public int Id { get; }

        public int Paws { get; set; }

        public Mammal(string name, bool isTakenCare, int paws) : base(name, isTakenCare)
        {
            Id = GetId();
            Paws = paws;
        }

        public new void DoSound()
        {
            Console.WriteLine("«я млекопитающeе, би-би-би»");
        }

        public override string ToString() => $"Mammal. {base.ToString()}, paws: {Paws}";
    }

    class Bird: Animal,IVocal
    {
        public int Id { get; }

        public int Speed { get; set; }

        public Bird(string name, bool isTakenCare, int speed) : base(name, isTakenCare)
        {
            if (speed <= 0 || speed > 100)
                throw new ArgumentException("Превышен лимит, ты не молния маквин");
            Id = GetId();
            Speed = speed;
        }

        public new void DoSound()
        {
            Console.WriteLine("«я птичка, пип-пип-пип»");
        }

        public override string ToString() => $"Bird. {base.ToString()}, speed: {Speed}";
    }

    class Zoo : IEnumerable<Animal>
    {
        public List<Animal> Animals { get; }

        public Zoo()
        {
            Animals = new List<Animal>();
        }

        public IEnumerator<Animal> GetEnumerator()
        {
            return Animals.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Animals).GetEnumerator();
        }
    }
    class Program
    {
        /*В основной программе получить от пользователя целое число N (количество животных). 
        Создать объект zoo класса Zoo, содержащий N животных, заполненный объектами классов 
            Mammal и Bird случайным образом. Значение всех целочисленных свойств сгенерировать случайным образом. Значение имени сгенерировать случайным образом (для упрощения, просто числа).
        Вывести на экран информацию об объектах zoo с помощью foreach и 
            запустить событие onSound для всех объектов zoo.
            С помощью средств LINQ выделить только птиц (объектов класса Bird), 
        у которых есть опекун. Вывести на экран информацию об объектах из выделенной последовательности.
            С помощью средств LINQ выделить только млекопитающих (объектов класса Mammal), 
        у которых нет опекуна.  Вывести на экран информацию об объектах из выделенной последовательности.*/

        private static Random rnd = new();
        private static string RandomName() =>
            $"{(char) rnd.Next(65, 91)}" +
            $"{(char) rnd.Next(97, 123)}" +
            $"{(char) rnd.Next(97, 123)}" +
            $"{(char) rnd.Next(65, 91)}";

        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            int n = int.Parse(Console.ReadLine() ?? "1");

            for (int i = 0; i < n; i++)
            {
                string name = RandomName();
                bool isTakingCare = rnd.Next(1, 11) > 5;

                if (rnd.Next(1, 11) >= 4)
                    zoo.Animals.Add(new Bird(name, isTakingCare, rnd.Next(1, 101)));
                else
                    zoo.Animals.Add(new Mammal(name, isTakingCare, rnd.Next(1, 21)));
            }

            foreach (Animal animal in zoo)
            {
                Console.WriteLine(animal);
                Console.WriteLine($"{animal.GetType()} Sound:");
                animal.DoSound();
            }

            var q1 = from animal in zoo where animal 
                is Bird && animal.IsTakenCare 
                select (Bird) animal;
            foreach (var bird in q1)
                Console.WriteLine(bird);
            var q2 = from animal in zoo where animal  is Mammal && animal.IsTakenCare==false
                select (Mammal) animal;
            foreach (var mammal in q2)
            {
                Console.WriteLine(mammal);
            }
        }
    }
}
