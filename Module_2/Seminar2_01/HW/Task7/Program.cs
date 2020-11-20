using System;

namespace Task7
{
	class Program
	{
		static readonly string[] Filials = { "Западный", "Центральный", "Восточный" };
		static readonly string[] Kvartal = { "I", "II", "III", "IV" };
		static readonly int[,] auto = { { 20, 24, 25 },
                { 21, 20, 18 },
                { 23, 27, 24 },
                { 22, 19, 20 } 
            };

		/// <summary>
		/// Все результаты.
		/// </summary>
		/// <returns>Строка, сформированная по результатам работы методов</returns>
		public static string PrintResults(string mode)
		{
			string st = "";
			int Nstroki;    // номер строки
			int Nstolbca;   // номер столбца
			//int SumFilial;       // продано филиалом
			int NFiliala_MaxAutoYear; // номер лучшего филиала
			int MaxAutoFilialZaGod;  // продано лучшим филиалом за год
			//int SumKvartal;         // продано за квартал
			int NKvartal_MaxAuto;   // номер квартала с максимальной продажей
			int MaxAutoKvartal;     // максимальная продажа в квартал  
			
			switch (mode)
			{
				case "0": st += "Спасибо за работу!\r\n"; break;
				case "1":
					st += "Ответ 1. Общее количество автомобилей = " +
					GrandTotal() + "\r\n"; break;
				case "2":
					GetMax4Kvartal(out Nstroki, out Nstolbca);
					st += "Ответ 2. Mаксимальное количество автомобилей = " +
					   auto[Nstroki, Nstolbca] + ", Квартал = " + Kvartal[Nstroki] + ", Филиал = " + Filials[Nstolbca] + "\r\n"; break;
				case "3":
					Program.MaxAutoFilialZaGod(out NFiliala_MaxAutoYear, out MaxAutoFilialZaGod);
					st += "Ответ 3. Название филиала, который продал максимальное количество автомобилей по результатам года = " +
						   Filials[NFiliala_MaxAutoYear] +
						   ", проданное количество автомобилей = " + MaxAutoFilialZaGod + "\r\n"; break;
				case "4":
					Program.MaxAutoKvartal(out NKvartal_MaxAuto, out MaxAutoKvartal);
					st += "Ответ 4. Наиболее успешный квартал = " + Kvartal[NKvartal_MaxAuto] + ", проданное количество автомобилей = " + MaxAutoKvartal + "\r\n"; break;
				default: st += "Неизвестный режим. Введите число [0..4]\r\n"; break;
			}
			return st;
		}
		/// <summary>
		/// Вывод массива.
		/// </summary>
		/// <returns></returns>
		private static string PrintSrc()
		{
			string st = "Исходные данные:\r\n\\\t";
			foreach (var item in Filials)
			{
				st += item + "\t";
			}
			st += "\r\n";
			for (int i = 0; i < auto.GetLength(0); i++)
			{
				st += Kvartal[i] + "\t";
				for (int j = 0; j < auto.GetLength(1); j++)
					st += auto[i, j] + "\t\t";
				st += "\r\n";
			}
			return st;
		}
		/// <summary>Вывод меню</summary>
		private static string Print()
		{
			return @"Выберите, что вы желаете сделать:
			1. Вычислить общее количество автомобилей;
			 2. Вывести максимальное количество автомобилей, проданных филиалом за квартал (название филиала и номер квартала);
			 3. Найти название филиала, который продал максимальное количество    автомобилей по результатам года (и число проданных);
			 4. Найти наиболее успешный квартал (номер квартала и число проданных);
			 0. Завершить работу.
			 Ваш выбор: ";
		}
		/// <summary>
		/// 1) Подсчитать общее количество автомобилей, проданных всеми филиалами компании за год.
		/// </summary>
		/// <returns>Общее количество автомобилей</returns>
		private static int GrandTotal()
		{
			int sum = 0;
			for (int i = 0; i < auto.GetLength(0); i++)
				for (int j = 0; j < auto.GetLength(1); j++)
					sum += auto[i, j];
			return sum;
		}
		/// <summary>
		/// 2) Вывести максимальное количество автомобилей, проданных филиалом за квартал, а также название филиала и номер квартала.
		/// </summary>
		/// <param name="Nstroki"></param>
		/// <param name="Nstolbca"></param>
		private static void GetMax4Kvartal(out int Nstroki, out int Nstolbca)
		{
			Nstroki = 0;
			Nstolbca = 0;
			for (int i = 0; i < auto.GetLength(0); i++)
				for (int j = 0; j < auto.GetLength(1); j++)
					if (auto[Nstroki, Nstolbca] < auto[i, j])
					{
						Nstroki = i;
						Nstolbca = j;
					}
		}
		/// <summary>
		/// 3) Вывести название филиала, который продал максимальное количество автомобилей по результатам года, а также их количество.
		/// </summary>
		/// <param name="NFiliala_MaxAutoYear"></param>
		/// <param name="MaxAutoFilialZaGod"></param>
		private static void MaxAutoFilialZaGod(out int NFiliala_MaxAutoYear, out int MaxAutoFilialZaGod)
		{
			int[] filials = new int[Filials.Length];
			for (int i = 0; i < auto.GetLength(0); i++)
				for (int j = 0; j < auto.GetLength(1); j++)
					filials[j] += auto[i,j];
			NFiliala_MaxAutoYear = 0;
			MaxAutoFilialZaGod = 0;
			for (int i = 0; i < Filials.Length; i++)
				if (filials[i] > MaxAutoFilialZaGod)
				{
					MaxAutoFilialZaGod = filials[i];
					NFiliala_MaxAutoYear = i;
				}
		}
		/// <summary>
		/// 4) Вывести наиболее успешный квартал, в котором компания показала наилучший результат по продажам(учитываются все филиалы), 
		/// а также количество автомобилей проданное в нем.
		/// </summary>
		/// <param name="NKvartal_MaxAuto"></param>
		/// <param name="MaxAutoKvartal"></param>
		private static void MaxAutoKvartal(out int NKvartal_MaxAuto, out int MaxAutoKvartal)
		{
			int[] kvartals = new int[Kvartal.Length];
			for (int i = 0; i < auto.GetLength(0); i++)
				for (int j = 0; j < auto.GetLength(1); j++)
					kvartals[i] += auto[i, j];
			NKvartal_MaxAuto = 0;
			MaxAutoKvartal = 0;
			for (int i = 0; i < Kvartal.Length; i++)
				if (kvartals[i] > MaxAutoKvartal)
				{
					MaxAutoKvartal = kvartals[i];
					NKvartal_MaxAuto = i;
				}
		}
		static void Main()
		{
			string s, input;
			Console.Write(PrintSrc());
			do
			{
				Console.Write(Print());
				s = PrintResults(input = Console.ReadLine());
				Console.WriteLine(s);
			} while (input != "0");
			Console.ReadLine();
		}
	}
}
