using System;

namespace Task8
{
	class Schedule
	{
		readonly string[] daysOfWeek =
		{
			"Понедельник",
			"Вторник",
			"Среда",
			"Четверг",
			"Пятница",
			"Суббота",
			"Воскресенье"
		};
		public string this[int day]
		{
			get
			{
				if (day < 1 || day > 7)
					throw new ArgumentException("day must be between 1 and 7");
				return daysOfWeek[--day];
			}
		}
	}
	class Program
	{
		static void Main()
		{
			Schedule sched = new Schedule();
			for (int i = 1; i <= 7; i++)
				Console.WriteLine(sched[i]);
		}
	}
}
