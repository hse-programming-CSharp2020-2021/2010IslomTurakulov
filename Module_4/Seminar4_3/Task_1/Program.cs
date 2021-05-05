using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Task_1
{
    /*Объявить класс ConsoleSimbol, описывающий символ, расположенный 
    в определённой позиции консольного окна.  Поля:
    simb – символ
    x – целочисленная координата
    y – целочисленная координата
    Для получения значений полей использовать свойства.
    Инициализация полей выполняется конструктором с параметрами типов char, int, int.

    Создать наследника ColorConsoleSimbol, у которого есть доп. поле - color (можно string, можно Сolor)

    В основной программе создать массив состоящий как из ColorConsoleSimbol, 
    так и ConsoleSimbol, со случайными координатами, символами и цветами.
    Сериализовать и десериализовать массив 2-мя разными типами сериализаций.*/
    [Serializable]
    public class ConsoleSymbol
    {
        [XmlIgnore]
        private char symb;

        public ConsoleSymbol()
        {
        }

        public ConsoleSymbol(char symbol, int x, int y)
        {
            symb = symbol;
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override string ToString()
        {
            return $"X: {X} , Y: {Y}";
        }
    }

    [Serializable]
    public class ColorConsoleSymbol : ConsoleSymbol
    {
        private Color _color;

        public ColorConsoleSymbol()
        { }

        public ColorConsoleSymbol(char symbol, int x, int y, Color color) : base(symbol, x, y) => _color = color;
        public override string ToString() => $"Цвет: {_color}";
    }

    internal class Program
    {
        private static Random rnd = new Random();
        private static void Main(string[] args)
        {
            List<Color> listOfColors = new List<Color>()
            {
                Color.AliceBlue,
                Color.IndianRed,
                Color.AntiqueWhite,
                Color.Aquamarine,
                Color.Black,
                Color.Brown,
                Color.DarkBlue
            };
            ColorConsoleSymbol[] colorConsole = new ColorConsoleSymbol[10];
            List<ConsoleSymbol> listColor = new List<ConsoleSymbol>();
            for (int i = 0; i < 10; i++)
            {
                var temp = new ColorConsoleSymbol(
                    (char) rnd.Next(97, 123), 
                    rnd.Next(1, 100), rnd.Next(1, 50),
                    listOfColors[rnd.Next(1, 7)]);
                colorConsole[i] = temp;
                listColor.Add(temp);
            }
            var xmlSerialize = new XmlSerializer(typeof(List<ConsoleSymbol>), new[] {typeof(ColorConsoleSymbol)});
 
            using (var fileStreamWriter = new FileStream("Data.xml", FileMode.Create, FileAccess.Write))
            {
                using var streamWriter = new StreamWriter(fileStreamWriter);
                xmlSerialize.Serialize(streamWriter, listColor);
            }
            Console.WriteLine(Environment.NewLine + "XML десереализация: ");
            using (var fsReader = new FileStream("Data.xml", FileMode.Open, FileAccess.Read))
            {
                using var sReader = new StreamReader(fsReader);
                var symbolsDeserialize = (List<ConsoleSymbol>)xmlSerialize.Deserialize(sReader);
                foreach (var p in symbolsDeserialize)
                {
                    Console.WriteLine($"X: {p.X}, Y: {p.Y}");
                    Console.WriteLine(p);
                }
            }

            BinaryFormatter formatter = new BinaryFormatter();
 
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, colorConsole);
            }

            Console.WriteLine(Environment.NewLine + "Бинарная десереализация: ");
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                ColorConsoleSymbol[] deserilizePeople = (ColorConsoleSymbol[])formatter.Deserialize(fs);
 
                foreach (var p in deserilizePeople)
                {
                    Console.WriteLine($"X: {p.X}, Y: {p.Y}");
                    Console.WriteLine(p);
                }
            }
        }
    }
}
