using System;
using System.Collections.Generic;
using System.Text;

namespace MyLib
{
    public class RusString : MyStrings
    {
        public RusString(char start, char finish, int n)
        {
            // проверяем количество символов строки и допустимые границы
            if (n <= 0)
                throw new ArgumentOutOfRangeException();
            char[] letters = new char[n];
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = (char)rnd.Next(start, finish + 1);
            }
            str = new String(letters);
            if (!Validate())
                throw new ArgumentOutOfRangeException();
        }
        public override string ToString()
        {
            return str;
        }
        public override bool Validate()
        {
            foreach (char ch in str)
                if (char.IsLetter(ch) && !(char.ToLower(ch) >= 'а' && char.ToLower(ch) <= 'я'))
                    return false;
            return true;
        }
    }
}
