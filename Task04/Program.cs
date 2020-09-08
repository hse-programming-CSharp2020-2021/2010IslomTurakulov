using System;
using System.Threading;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ознакомление информации про консольное приложение

            Console.WriteLine("Программа получает от пользователя значения напряжения U и сопротивления R, вычислить силу тока  I = U/R и потребляемую мощность  P = U2/R электрической цепи.");
            
            Console.Write("Введите значение напряжения ( U ): ");
            double U = double.Parse(Console.ReadLine());

            Console.Write("Введите значение сопротивления ( R ): ");
            double R = double.Parse(Console.ReadLine());


            Console.WriteLine("Вычисляем силу тока формулой I = U/R");
            Thread.Sleep(2000);
            
            // Вычисление силы тока
            Console.WriteLine("Ответ: " + (U / R).ToString("F4") + " А ");

            Console.WriteLine("Вычисляем потребляемую мощность  P = U2/R электрической цепи");
            Thread.Sleep(1000);

            // Вычисление потребляемой мощности
            Console.WriteLine("Ответ: " + (Math.Pow(U, 2) / R).ToString("F4"));

            Console.WriteLine("Нажмите на ENTER , чтобы выйти..");
            Console.ReadKey();
        }
    }
}
