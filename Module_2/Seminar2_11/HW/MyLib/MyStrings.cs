using System;

namespace MyLib
{
    public abstract class MyStrings
    {
        protected String str;
        public static Random rnd = new Random();

        /// <summary>
        /// Свойство, возвращающее информацию о палиндромности
        /// </summary>
        public bool IsPalindrome
        {
            get
            {
                if (str.Length > 0)
                {
                    char[] tmp = str.ToCharArray();
                    Array.Reverse(tmp);
                    string tmpString = new string(tmp);
                    if (str.CompareTo(tmpString) == 0) return true;
                }
                return false;
            }
        }
        /// <summary>
        /// метод подсчитывает количество вхождений символа в строку
        /// </summary>
        /// <param name="letter">буква, которая ищется в строке</param>
        /// <returns></returns>
        public int CountLetter(char letter)
        {
            int start = 0, result = -1, res;
            do
            {
                res = str.IndexOf(letter, start);
                start = res + 1;    // начало следующего поиска 
                result++;           // счетчик вхождений
            } while (res >= 0);
            return result;
        }
        public abstract bool Validate();
    }
}
