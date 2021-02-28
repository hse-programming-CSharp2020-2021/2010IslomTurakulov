using System;

namespace Task_2
{

    struct PointS
    {
        public double X { get; set; }
        public double Y { get; set; }

        public PointS(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Distance(PointS point) => Math.Sqrt((X - point.X) * (X - point.X) + (Y - point.Y) * (Y - point.Y));
    }

    struct CircleS : IComparable<CircleS>
    {
        private double _radius;
        private PointS _center;

        private double Radius
        {
            get => _radius;
            set
            {
                if (value < 0)
                    throw new ArgumentException("The radius is less than zero!");
                _radius = value;
            }
        }
        private PointS Center
        {
            get => _center;
            set => _center = value;
        }

        private double Length
        {
            get => 2 * Math.PI * _radius;
        }

        public CircleS(double x, double y, double radius)
        {
            _radius = radius;
            _center = new PointS(x, y);
        }

        public override string ToString() =>
            $"Center: Point X = {_center.X:f3} Point Y = {_center.Y:f3};\n " +
            $"Radius: {Radius:f3}; Length: {Length:f3}";

        public int CompareTo(CircleS other) => Radius.CompareTo(other.Radius);
    }

    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            var circleSes = new CircleS[rnd.Next(5,10)];
            Console.WriteLine("Before:");
            Console.WriteLine();
            for (var i = 0; i < circleSes.Length; i++)
            {
                circleSes[i] = new CircleS(rnd.NextDouble() * rnd.Next(5,10), 
                                            rnd.NextDouble() * rnd.Next(5,10), 
                                            rnd.NextDouble() * rnd.Next(5,10));
                Console.WriteLine(circleSes[i]);
            }

            Array.Sort(circleSes);
            Console.WriteLine();

            Console.WriteLine("After:");
            foreach (var circle in circleSes)
                Console.WriteLine(circle);
        }
    }
}
