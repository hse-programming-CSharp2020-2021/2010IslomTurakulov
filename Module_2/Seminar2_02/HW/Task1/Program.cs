using System;

namespace Task1
{
	class Birthday
	{
		readonly string name; // закрытое поле - фамилия
		private readonly int year;
		private readonly int month;
		private readonly int day;

		public Birthday() : this("", 1970, 1, 1) { }
		public Birthday(string name, int y, int m, int d)
		{ // Конструктор
			this.name = name;
			year = y; month = m; day = d;
		}
		DateTime Date
		{ // закрытое свойство - дата рождения
			get { return new DateTime(year, month, day); }
		}
		public string Information
		{   // свойство - сведения о человеке
			get
			{
				return name + ", дата рождения " + day + "." + month + "." + year;
			}
		}
		public int HowManyDays
		{ // свойство - сколько дней до дня рождения
			get
			{
				// номер сего дня от начала года:
				int nowDOY = DateTime.Now.DayOfYear;
				//  номер дня рождения от начала года: 
				int myDOY = Date.DayOfYear;
				int period = myDOY >= nowDOY ? myDOY - nowDOY :
											   365 - nowDOY + myDOY;
				return period;
			}

		}
		public override string ToString()
		{
			return Date.ToString("dd-MM-yy");
		}
		public string DateString
		{
			get
			{
				return Date.ToString("dd MMMM yyyy");
			}
		}
	}

	class Program
	{
		static void Main()
		{
			Birthday md = new Birthday("Чапаев", 1887, 2, 9);
			Console.WriteLine(md.Information);
			Console.Write("До следующего дня рождения дней осталось: ");
			Console.WriteLine(md.HowManyDays);

			Birthday km = new Birthday("Маркс Карл", 1818, 5, 4);
			Console.WriteLine(km.Information);
			Console.Write("До следующего дня рождения дней осталось: ");
			Console.WriteLine(km.HowManyDays);

			Console.Write("Введите ваше имя: ");
			string name = Console.ReadLine();
			DateTime day;
			do
				Console.Write("Введите дату рождения в формате ДД.ММ.ГГГГ: ");
			while (!DateTime.TryParse(Console.ReadLine(), out day));
			Birthday myBirthday = new Birthday(name, day.Year, day.Month, day.Day);
			Console.WriteLine(myBirthday.DateString);
			Console.Write("До следующего дня рождения дней осталось: ");
			Console.WriteLine(myBirthday.HowManyDays);
		}
	}
}
