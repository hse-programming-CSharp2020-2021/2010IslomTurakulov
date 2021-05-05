using System;
using System.Collections;

/*Есть класс RandomCollection, реализующий свою коллекцию из n 
   случайных целых чисел (числа будут разные при каждом обходе). 
   Класс RandomCollection реализует интерфейс IEnumerable. 
   Нам надо предоставить возможность обходить элементы коллекции через foreach.
   Для того, чтобы это было возможно, необходимо определить закрытый 
   класс RandomEnumerator, реализующий доступ к отдельным элементам
   коллекции (реализует интерфейс IEnumerator).
   Создать программу, демонстрирующую работу.*/

namespace Task_1
{
    class RandomCollection : IEnumerable
    {
        private int _n;

        public RandomCollection(int n) => _n = n;

        public IEnumerator GetEnumerator()
        {
            return new RandomCollectionEnumerate(_n);
        }
    }

    class RandomCollectionEnumerate : IEnumerator
    {
        private readonly Random _rnd = new();
        private int _n;
        private int _position;

        public RandomCollectionEnumerate(int n)
        {
            this._n = n;
            _position = 0;
        }


        public bool MoveNext()
        {
            if (_position >= _n)
                return false;
            _position++;
            return true;
        }

        public void Reset()
        {
            _position = 0;
        }

        public object Current
        {
            get => _rnd.Next();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Введите значение n:");
                int n = int.Parse(Console.ReadLine() ?? string.Empty);
                var randomCollection = new RandomCollection(n);
                Console.WriteLine();
                foreach (var x in randomCollection)
                    Console.WriteLine(x);

                Console.WriteLine(Environment.NewLine + "Нажмите ESC чтобы выйти");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
