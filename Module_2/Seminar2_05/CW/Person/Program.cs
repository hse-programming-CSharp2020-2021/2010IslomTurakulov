using System;

namespace Person
{
    class Person
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsMale { get; set; }

        public Person(string f, DateTime d, bool m)
        {
            FullName = f;
            BirthDate = d;
            IsMale = m;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"{FullName} {BirthDate} {IsMale}");
        }
    }

    class Student : Person
    {
        public string Institute { get; set; }
        public string Speciality { get; set; }

        public Student(string f, DateTime d, bool m, string inst, string spec) : base(f, d, m)
        {
            Institute = inst;
            Speciality = spec;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"{FullName} {BirthDate} {IsMale} {Institute} {Speciality}");
        }
    }
    class Employee : Person
	{
        public string CompanyName { get; set; }
        public string Post { get; set; }
        public string Schedule { get; set; }
        public decimal Salary { get; set; }
        public Employee(string f, DateTime d, bool m, string company, string post, string sched, decimal s) : base(f, d, m)
		{
            CompanyName = company;
            Post = post;
            Schedule = sched;
            Salary = s;
		}
        public override void ShowInfo()
        {
            Console.WriteLine($"{FullName} {BirthDate} {IsMale} {CompanyName} {Post} {Schedule}");
        }
    }

    class Program
    {
        static void Main()
        {
            Person[] array = new Person[3];
            array[0] = new Person("ewfewfef", new DateTime(2000, 10, 10), true);
            array[1] = new Student("oieweqvb", new DateTime(2010, 5, 5), false, "3grh4", "r4tgrv");
            array[2] = new Employee("Ricardo Milos", new DateTime(1900, 1, 1), true, "Company", "ghhgh", "free", 100000);
            Array.ForEach(array, x => x.ShowInfo());
        }
    }
}