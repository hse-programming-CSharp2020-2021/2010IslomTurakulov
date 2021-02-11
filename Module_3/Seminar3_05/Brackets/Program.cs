using System;
using System.Collections.Generic;

namespace Brackets
{
    class Program
    {
        static readonly Dictionary<char, char> BracketDictionary = new Dictionary<char, char>{ {'(', ')' }, {'[',']'}, {'{','}'}};

        private static bool Validate(string input)
        {
            var stack = new Stack<char>();
            foreach (char bracket in input)
            {
                switch (bracket)
                {
                    case '(':
                    case '[':
                    case '{':
                        stack.Push(bracket);
                        break;
                    default:
                        if (bracket.Equals(')') || bracket.Equals(']') || bracket.Equals('}') &&
                            (stack.Count == 0 || bracket != BracketDictionary[stack.Peek()]))
                            return false;
                        if (bracket.Equals(')') || bracket.Equals(']') || bracket.Equals('}'))
                            stack.Pop();
                        break;
                }
            }
            return stack.Count.Equals(0);
        }
        static void Main()
        {
            Console.Write(Validate(Console.ReadLine()));
        }
    }
}
