using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Task_2
{
    public class Human
    {
        public string Name { get; set; }
        public Human() { }
        public Human(string name) => Name = name;

        public override string ToString() => Name;
    }


    public class Professor : Human
    {
        public Professor(string name) : base(name) { }
    }


    public class Dept
    {
        public string DeptName { get; set; }
        public List<Human> Staff { get; }
        public Dept() { }
        public Dept(string name, Human[] staffList)
        {
            this.DeptName = name;
            Staff = new List<Human>(staffList);
        }

        public override string ToString() => $"{DeptName}: {string.Join(", ", Staff)}";
    }

    public class University
    {
        public string UniversityName { get; set; }
        public List<Dept> Departments { get; set; }
        public override string ToString() => $"Name: {UniversityName}, departments:{Environment.NewLine}" +
                                             $"{string.Join(", ", Departments)}";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dept[] department = new Dept[5];
            department[0] = new Dept("CS", new Human[] {new("N.Chuykin"), new Professor("Fedotov Matesha Kruto")});
            department[1] = new Dept("BSE", new Human[] {new("Vseleon Algebra Smert"), new Professor("Sanya")});
            department[2] = new Dept("CSB", new Human[] {new("Rafaat"), new Professor("Huskar")});
            department[3] = new Dept("UIG", new Human[] {new("Steve"), new Professor("Minecraft"), new Professor("Notch")});
            department[4] = new Dept("DOTA", new Human[] {new("Invoker"), new Professor("Lich"), new Professor("Crystal Maiden")});
            University university = new University()
                {Departments = new List<Dept>(department), UniversityName = "HSE Kontora"};
            University university2;

            XmlSerializer formatter = new(typeof(University), new Type[] { typeof(Dept), typeof(Human), typeof(Professor) });
            using (FileStream stream = File.OpenWrite("HSEKontora.xml"))
                formatter.Serialize(stream, university);
            using (FileStream stream = File.OpenRead("HSEKontora.xml"))
                university2 = (University)formatter.Deserialize(stream);

            Console.WriteLine(university2);
        }
    }
}
