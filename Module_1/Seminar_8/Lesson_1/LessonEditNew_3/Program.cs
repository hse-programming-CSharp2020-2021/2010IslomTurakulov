﻿/* ЗАДАЧА:
















using System;

using System.IO; // Пространство имён System.IO -> File.

using System.Text; // Кодировка.

class Program

{

    static Random rand = new Random();

    static void Main()

    {

        // основные настрйки

        const string fileName = "dialog5.txt";

        Encoding enc = Encoding.Unicode;

        string[] empty = { " " };

        const int linesCount = 6;   // кол-во предложений

        // Создаем файл на диске 


        Console.WriteLine("Переписка до форматирования:");

        string[] message2 = new string[linesCount]; // предложение

        for (int i = 0; i < linesCount; i++)

        {

            string message = "";

            int len = rand.Next(20, 51); // Длина сообщения от 20 до 50 символов (51 - 50 включён в диапазон)

            for (int j = 0; j < len; j++)

            {

                message += (char)rand.Next('А', 'Я'); // Посимвольное добавление букв в сообщение. "Ё" нет в диапазоне от А до Я!

            }

            if (rand.Next(0, 1) == 0)

                message += '.';// Добавляем в сообщение точку и перенос на следующую строку.

            message2[i] = message;

            Console.WriteLine(message);

        }

        File.WriteAllLines(fileName, message2, enc); // Создаём пустой файл.

        // читаем сформированный файл и обрабатываем предложения

        string[] messages = File.ReadAllLines(fileName, enc); // Массив сообщений из переписки.

        Console.WriteLine(Environment.NewLine + "Переписка после форматирования:");

        foreach (string item in messages)

            if (item[item.Length - 1] == '.')

                Console.WriteLine(item); // Выводим сообщения из переписки без точек на экран.

    }

}