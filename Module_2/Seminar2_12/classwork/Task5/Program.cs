using System;

namespace ConsoleApp5
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static string ConvertToHex2Bin(string input)
        {
            return Convert.ToString(Convert.ToInt32(input, 16), 2);
        }

        static string ConvertHex2Bin2(string str, string hex)
        {
            return new StringBuilder().AppendJoin("", Array.ConvertAll(str.ToCharArray(), x => hex.IndexOf(char.ToLower(x)))).ToString();
        }

        static void Main(string[] args)
        {
            do
            {
                string input = "5A1";
                string hex = "0123456789abcdef";
                string n = ConvertToHex2Bin(input);
                string n2 = ConvertHex2Bin2(input, hex);
                Console.WriteLine($"из {input} в 2-ую: {n}");
                Console.WriteLine($"Через SB: {n2}");
                Console.WriteLine("Нажмите Escape чтобы выйти");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}