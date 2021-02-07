using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FileManager
{
    public delegate void OnKey(ConsoleKeyInfo key);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в Файловый Менеджер! Некоторые функции не будут работать на маке ");
            Console.WriteLine("Я это признаю, но есть несколько скриншотов выполнения действий а так же фукнций программы");
            Console.WriteLine("Нажмите на любую кнопки если Вы ознакомились с информацией");
            Console.ReadKey();
            //Начало входа в процесс 
            MainFileOperation manager = new MainFileOperation();
            manager.MainOperationOfProccess();
        }
    }
}