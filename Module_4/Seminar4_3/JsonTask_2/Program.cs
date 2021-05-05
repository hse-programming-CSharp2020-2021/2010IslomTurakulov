using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;
using static System.Drawing.Color;

namespace Task_2
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
    [DataContract]
    public class ConsoleSymbol
    {
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
        [DataMember]
        public int X { get; set; }
        [DataMember]
        public int Y { get; set; }

        public override string ToString()
        {
            return $"X: {X} , Y: {Y}";
        }
    }

    [Serializable]
    [DataContract]
    public class ColorConsoleSymbol : ConsoleSymbol
    {
        [DataMember]
        private Color _color;

        public ColorConsoleSymbol()
        { }

        public ColorConsoleSymbol(char symbol, int x, int y, Color color) : base(symbol, x, y) => _color = color;
        public override string ToString() => $"Цвет: {_color}";
    }

    internal class Program
    {
        static readonly List<Color> listOfColors = new()
        {
            AliceBlue,
            IndianRed,
            AntiqueWhite,
            Aquamarine,
            Black,
            Brown,
            DarkBlue
        };

        private static Random rnd = new Random();

        public static XmlSerializer SerializeXml(List<ConsoleSymbol> listColor)
        {
            var xmlSerialize = new XmlSerializer(typeof(List<ConsoleSymbol>), new[] {typeof(ColorConsoleSymbol)});
            using (var fileStreamWriter = new FileStream("Data.xml", FileMode.Create, FileAccess.Write))
            {
                using var streamWriter = new StreamWriter(fileStreamWriter);
                xmlSerialize.Serialize(streamWriter, listColor);
            }

            return xmlSerialize;
        }

        public static void DeserializeXml(XmlSerializer xmlSerialize)
        {
            using (var fsReader = new FileStream("Data.xml", FileMode.Open, FileAccess.Read))
            {
                using var sReader = new StreamReader(fsReader);
                var symbolsDeserialize = (List<ConsoleSymbol>) xmlSerialize.Deserialize(sReader);
                foreach (var p in symbolsDeserialize)
                {
                    Console.WriteLine($"X: {p.X}, Y: {p.Y}");
                    Console.WriteLine(p);
                }
            }
        }

        public static void BinaryFormat(ColorConsoleSymbol[] colorConsole)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
                formatter.Serialize(fs, colorConsole);

            Console.WriteLine(Environment.NewLine + "Бинарная десереализация: ");
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                ColorConsoleSymbol[] deserilizePeople = (ColorConsoleSymbol[]) formatter.Deserialize(fs);

                foreach (var p in deserilizePeople)
                {
                    Console.WriteLine($"X: {p.X}, Y: {p.Y}");
                    Console.WriteLine(p);
                }
            }
        }

        public static void DataFormat(List<ConsoleSymbol> list)
        {
            DataContractSerializer ds = new DataContractSerializer(typeof(ConsoleSymbol),
                new Type[] {typeof(ColorConsoleSymbol)});

            using (Stream s = File.Create("person.xml"))
                ds.WriteObject(s, list[0]); // Сериализация

            using (Stream s = File.OpenRead("person.xml"))
            {
                ConsoleSymbol tempNew = (ConsoleSymbol) ds.ReadObject(s);
                Console.WriteLine($"X: {tempNew.X}, Y: {tempNew.Y}");
                    Console.WriteLine(tempNew);
            }
        }

        public static async void JsonSerFormat(List<ConsoleSymbol> list)
        {
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<ConsoleSymbol>(fs, list[0]); 
                Console.WriteLine("Data has been saved to file");
            }


            // чтение данных
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                ConsoleSymbol restoredPerson = await JsonSerializer.DeserializeAsync<ConsoleSymbol>(fs);
                Console.WriteLine($"X: {restoredPerson.X}, Y: {restoredPerson.Y}");
                    Console.WriteLine(restoredPerson);
            }
        }

        private static void Main(string[] args)
        {
            ColorConsoleSymbol[] colorConsole = new ColorConsoleSymbol[10];
            List<ConsoleSymbol> listColor = new List<ConsoleSymbol>();
            for (int i = 0; i < 10; i++)
            {
                var temp = new ColorConsoleSymbol(
                    (char)rnd.Next(97, 123),
                    rnd.Next(1, 100), rnd.Next(1, 50),
                    listOfColors[rnd.Next(1, 7)]);
                colorConsole[i] = temp;
                listColor.Add(temp);
            }

            var newXml = SerializeXml(listColor);
            Console.WriteLine(Environment.NewLine + "XML десереализация: ");
            DeserializeXml(newXml);

            BinaryFormat(colorConsole);
            DataFormat(listColor);
            JsonSerFormat(listColor);
        }
    }
}
