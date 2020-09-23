using System;

namespace Task_5
{
    /*
      Выделение отдельных цифр натурального числа
      Задача:
      Ввести трехзначное натуральное число и напечатать его цифры "столбиком".
    */

    class Program
    {
        static void Splitter(int numberValue)
        {
            char[] arr =  numberValue.ToString().ToCharArray();
            foreach (var value in arr)
                Console.WriteLine(value);
        }
        static void Main(string[] args)
        {
            // Обработка Исключений
            try
            {
                
                int numberValue;
                // Можно использовать if else Для проверки
                do
                {
                    Console.WriteLine("Введите трёхзначное число: ");
                } while (!int.TryParse(Console.ReadLine(), out numberValue) | numberValue < 100 | numberValue > 999);
                // Через метод передаю значение
                Splitter(numberValue);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Причина ошибки {ex.Message}");
            }


        }
    }
}
