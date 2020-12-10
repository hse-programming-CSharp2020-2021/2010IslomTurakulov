using System;
using System.Linq;
using System.Text;

namespace Task2
{
	class Methods
	{
        // проверка, что строки состоят только из символов латинского алфавита
        // и пробелом
        public static bool Validate(string str) => 
            str.All(x => (char.ToLower(x) >= 'a' && char.ToLower(x) <= 'z') || x == ' ' || x == ';');
        // получение массива строк
        // каждый элемент проверен на соответствие формату
        public static string[] ValidatedSplit(string str, char ch) => 
            Validate(str) ? str.Split(ch, StringSplitOptions.RemoveEmptyEntries) : null;
        // Обрезка строки по первому гласному
        public static string Shorten(string str) => 
            str.Substring(0, str.IndexOfAny(new char[] { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y' }) + 1);
        // Метод создания аббревиатуры для ПОДстроки (в ней много слов)
        public static string Abbrevation(string str) =>
            new StringBuilder().AppendJoin("", Array.ConvertAll(
                Array.ConvertAll(str.Split(' ', StringSplitOptions.RemoveEmptyEntries), Shorten), FirstUpcase)).ToString();
        // Метод преобразования первого символа к заглавному
        public static string FirstUpcase(string str) => 
            char.ToUpper(str[0]) + str[1..].ToLower();
    }
}
