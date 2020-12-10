using System;

namespace Task3
{
	class Program
	{
        public class Employee
        {
            public string name;

            // Basepay is defined as protected, so that it may be
            // accessed only by this class and derived classes.
            protected decimal basepay;

            // Constructor to set the name and basepay values.
            public Employee(string name, decimal basepay)
            {
                this.name = name;
                this.basepay = basepay;
            }

            // Declared virtual so it can be overridden.
            public virtual decimal CalculatePay()
            {
                return basepay;
            }
        }

        // Derive a new class from Employee.
        public class SalesEmployee : Employee
        {
            // New field that will affect the base pay.
            private readonly decimal salesbonus;

            // The constructor calls the base-class version, and
            // initializes the salesbonus field.
            public SalesEmployee(string name, decimal basepay,
                      decimal salesbonus) : base(name, basepay)
            {
                this.salesbonus = salesbonus;
            }

            // Override the CalculatePay method
            // to take bonus into account.
            public override decimal CalculatePay()
            {
                return basepay + salesbonus;
            }
        }
		public class PartTimeEmployee : Employee
		{
            readonly int workingDays;

            public PartTimeEmployee(string name, decimal basepay,
                      int workingDays) : base(name, basepay)
            {
                this.workingDays = workingDays;
            }
            public override decimal CalculatePay() => workingDays * basepay / 25;
        }
        static void Main()
		{
            Random rnd = new Random();
            Employee[] array = new Employee[6];
            array[0] = new PartTimeEmployee("Гена", rnd.Next(200000, 400000), 10);
            array[1] = new SalesEmployee("Виктор", rnd.Next(90000, 200000), rnd.Next(30000, 80000));
            array[2] = new SalesEmployee("Ирина", rnd.Next(90000, 200000), rnd.Next(30000, 80000));
            array[3] = new SalesEmployee("Николай", rnd.Next(90000, 200000), rnd.Next(30000, 80000));
            array[4] = new PartTimeEmployee("Нюхач", rnd.Next(400000, 600000), 10);
            array[5] = new SalesEmployee("Максим", rnd.Next(90000, 200000), rnd.Next(30000, 80000));
            Array.Sort(array, (x, y) => -x.CalculatePay().CompareTo(y.CalculatePay()));
            Array.ForEach(array, x => {
                if (x is SalesEmployee)
                    Console.WriteLine($"{x.name}: {x.CalculatePay()}");
            });
            Array.ForEach(array, x => {
                if (x is PartTimeEmployee)
                    Console.WriteLine($"{x.name}: {x.CalculatePay()}");
            });
        }
	}
}
