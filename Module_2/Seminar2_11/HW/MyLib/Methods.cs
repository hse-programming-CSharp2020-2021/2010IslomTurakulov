using System;

namespace MyLib
{
    public class Methods
    {
        // Получение значения целочисленного параметра
        public static int GetIntValue(string comment)
        {
            Console.Write(comment);
            return int.Parse(Console.ReadLine());
        }
    }
}
