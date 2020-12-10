using System;

namespace Task1
{
	class UserString
	{
        static readonly Random gen = new Random();
		string str;

        // Создать строку заданных размеров из заданных символов:
        public UserString(int k, char minChar, char maxChar)
        {
            if (k < 0)
                throw new Exception("Аргумент метода должен быть положительным!");
            // minChar, minChar - границы диапазона символов
            if (maxChar < minChar)
            {
                char c = minChar;
                minChar = maxChar;
                maxChar = c;
            }
            // пустая строка, останется пустой, если символов 0
            str = string.Empty;
            for (int i = 0; i < k; i++)
                str += (char)gen.Next(minChar, maxChar + 1);
        }
        // Удалить из строки str все символы другой строки s:
        public UserString MoveOff(string s)
        {
            int index;
            for (int i = 0; i < s.Length; i++)
                while ((index = str.IndexOf(s[i])) >= 0)
                    str = str.Remove(index, 1);
            return this;
        }
        public override string ToString() => str;
	}
}
