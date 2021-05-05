using System;

namespace Task_2
{

    class State
    {
        public decimal Population { get; set; }
        public decimal Area { get; set; }

        public static State operator +(State first, State second) =>
            new()
            {
                Area = first.Population + second.Area,
                Population = first.Population + second.Population
            };

        public static bool operator >(State first, State second)
        {
            bool tempArea = first.Area > second.Area;
            bool tempPopulation = first.Population > second.Population;
            return tempArea && tempPopulation;
        }

        public static bool operator <(State first, State second)
        {
            bool tempArea = first.Area < second.Area;
            bool tempPopulation = first.Population < second.Population;
            return tempArea && tempPopulation;
        }
        public static int operator ++(State first)
        {
          
            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            State state1 = new State();
            State state2 = new State();
            State state3 = state1 + state2++;
            bool isGreater = state1 > state2;
        }
    }
}
