using System;
using System.Linq;
using System.IO;

namespace Project
{
    class Program
    {
        /// <summary>
        /// Метод для получения информации о файле по указанному пути в директории
        /// </summary>
        /// <param name="dir">Путь до директории</param>
        static void GetInformationAboutFile(string dir = "")
        {
            string s = "";
            Console.WriteLine("Введите относительный путь до файла внутри директории");
            s = Console.ReadLine();
            if (File.Exists(dir + "\\" + s))  // Проверка на существование файла
            {

                Console.WriteLine($"Файл {dir + "\\" + s} существует:");
                Console.WriteLine($"Атрибуты: {File.GetAttributes(dir + "\\" + s)}");
                Console.WriteLine($"Время создания: {File.GetCreationTime(dir + "\\" + s)}"); // Время создания
                Console.WriteLine($"Время создания UTC: {File.GetCreationTimeUtc(dir + "\\" + s)}"); // Время создания UTC
                Console.WriteLine($"Время последнего обращения: {File.GetLastAccessTime(dir + "\\" + s)}"); // Время последнего обращения
                Console.WriteLine($"Время последнего обращения UTC: {File.GetLastAccessTimeUtc(dir + "\\" + s)}"); // Время последнего обращения UTC
                Console.WriteLine($"Время последнего изменения: {File.GetLastWriteTime(dir + "\\" + s)}"); // Время последнего изменения
                Console.WriteLine($"Время последнего изменения UTC: {File.GetLastWriteTimeUtc(dir + "\\" + s)}"); // Время последнего изменения UTC
            }
        }


        /// <summary>
        /// Рекурсивыный вывод списка подпапок и файлов в них
        /// </summary>
        /// <param name="counter">Счётчик пустых папок</param>
        /// <param name="path">Адрес директории</param>
        /// <param name="depth">Уровень поддиректории</param>
        static void ShowListDirReq(ref int counter, string path, string depth = "-")
        {
            if (depth.Length == 1)
            {
                Console.WriteLine(path.Split(new char[] { '\\' })[path.Split(new char[] { '\\' }).Length - 1]);
            }
            Console.WriteLine($"{depth}Files: {Directory.EnumerateFiles(path).Count()}, Dirs: {Directory.EnumerateDirectories(path).Count()}");
            if (Directory.EnumerateFiles(path).Count() + Directory.EnumerateDirectories(path).Count() == 0)
            {
                counter += 1;
                return;
            }
            foreach (string file in Directory.EnumerateFiles(path))
            {
                Console.WriteLine(depth + file.Substring(path.Length + 1));
            }
            foreach (string dir in Directory.EnumerateDirectories(path))
            {
                Console.WriteLine(depth + dir.Substring(path.Length + 1));
                ShowListDirReq(ref counter, dir, depth + "-");
            }
        }

        /// <summary>
        /// Найти поддиректорию с заданным именем
        /// </summary>
        /// <param name="path">Где искать</param>
        /// <param name="dirname">Что искать</param>
        /// <param name="depth">Уровень</param>
        /// <returns></returns>
        static string FindDirReq(string path, string dirname, int depth = 0)
        {
            if (path.Split(new char[] { '\\' })[path.Split(new char[] { '\\' }).Length - 1] == dirname)
            {
                return path;
            }
            foreach (string dir in Directory.EnumerateDirectories(path))
            {
                string s = FindDirReq(dir, dirname, depth + 1);
                if (s.Length > 0) return s;
            }
            return "";
        }

        static void Task1()
        {
            string dir = "";
            Console.WriteLine("Введите полный путь до целевой директории");
            dir = Console.ReadLine();

            int counter = 0;
            ShowListDirReq(ref counter, dir);
            string s056789 = " пустых папок";
            string s1 = " пустая папка";
            string s234 = " пустые папки";
            string ansver = s056789;
            if (counter == 1) ansver = s1;
            if (counter >= 2 && counter <= 4) ansver = s234;
            Console.WriteLine($"В данной директории {counter}{ansver}");


            string dirname = FindDirReq(dir, "Вариант для подлога");
            if (dirname == "")
            {
                Console.WriteLine("Папка не существует");
            }
            else
            {
                try
                {
                    File.Create(dirname + "\\" + "Ответы").Close();
                    File.SetCreationTime(dirname + "\\" + "Ответы", DateTime.Parse("11/11/2011 11:11:11"));
                    //Directory.CreateDirectory(dirname + "\\" + "Учебный проект Дубина Н. А. 184");
                    Directory.Move(dirname, dirname + "\\..\\" + "Учебный проект Дубина Н. А. 184");
                    Directory.SetCreationTime(dirname + "\\..\\" + "Учебный проект Дубина Н. А. 184", DateTime.Now.AddDays(-1));
                    Directory.Move(dirname + "\\..\\" + "Учебный проект Дубина Н. А. 184", dir + "\\" + "Учебный проект Дубина Н. А. 184");
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void Main(string[] args)
        {
            do
            {

                Console.WriteLine(@"Добро пожаловать в программу для расширенного управления файловой системой вашего компьютера
Для того, чтобы перейти в дргую директорию введите cd <глобальный путь до директории> или cd <локальный путь до директории>
во всех командах <глобальный путь ...> - это глобальный путь, который можно изменить на <локальный путь ...> - локальный путь
Для того, чтобы показать папки и файлы на данном уровне введите ls или ls <путь до интересующей папки>
Для того, чтобы переместить папку используйте команду mv <путь до существующей папки> <путь по которому переместить папку>
Для того, чтобы удалить пустую папку используйте команду rmdir <путь>
Для того, чтобы удалить папку или файл используйте команду rm <путь> [ПАРАМЕТР]
   --- без параметра - удаление файла или пустой папки
   --- -r  - файла или удаление папки и всех вложенных в неё папок и файлов
Для того, чтобы узнать время создания файла используйте команду gic <путь>
Для того, чтобы узнать время последнего доступа к файлу используйте команду giv <путь>
Для того, чтобы узнать время последнего редактирования файла используйте команду gie <путь>
Для того, чтобы изменить время создания файла используйте команду gec <путь> [ПАРАМЕТР] [ЗНАЧЕНИЕ], где параметр:
   --- -y  - изменить на количество лет
   --- -M  - изменить на количество месяцев
   --- -d  - изменить на количество дней
   --- -h  - изменить на количество часов
   --- -m  - изменить на количество минут
   --- -s  - изменить на количество секунд
Для того, чтобы изменить время последнего доступа к файлу используйте команду gev <путь> [ПАРАМЕТР] [ЗНАЧЕНИЕ], где параметр:
   --- -y  - изменить на количество лет
   --- -M  - изменить на количество месяцев
   --- -d  - изменить на количество дней
   --- -h  - изменить на количество часов
   --- -m  - изменить на количество минут
   --- -s  - изменить на количество секунд
Для того, чтобы изменить время последнего редактирования файла используйте команду gee <путь> [ПАРАМЕТР] [ЗНАЧЕНИЕ], где параметр:
   --- -y  - изменить на количество лет
   --- -M  - изменить на количество месяцев
   --- -d  - изменить на количество дней
   --- -h  - изменить на количество часов
   --- -m  - изменить на количество минут
   --- -s  - изменить на количество секунд
Для того, чтобы выйти из программы используйте команду exit");
                string command = "";
                do
                {
                    string dir = Directory.GetCurrentDirectory(); // Получение нынешней начальной директории приложения
                    Console.Write(dir + ": ");
                    command = Console.ReadLine();
                    string[] commandarr = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    switch (commandarr[0])
                    {
                        case "cd":
                            {
                                try
                                {
                                    if (commandarr.Length != 2)
                                    {
                                        Console.WriteLine("Неверный формат команды");
                                    }
                                    else
                                    {
                                        Directory.SetCurrentDirectory(commandarr[1]);
                                    }
                                }
                                catch (IOException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            }
                        case "ls":
                            {
                                try
                                {
                                    if (commandarr.Length < 1 || commandarr.Length > 2)
                                    {
                                        Console.WriteLine("Неверный формат команды");
                                    }
                                    else
                                    {
                                        if (commandarr.Length == 1)
                                        {
                                            foreach (string file in Directory.EnumerateFileSystemEntries(dir))
                                            {
                                                Console.WriteLine(file.Split(new char[] { '\\' })[file.Split(new char[] { '\\' }).Length - 1]);
                                            }
                                        }
                                        else
                                        {
                                            foreach (string file in Directory.EnumerateFileSystemEntries(commandarr[1]))
                                            {
                                                Console.WriteLine(file.Split(new char[] { '\\' })[file.Split(new char[] { '\\' }).Length - 1]);
                                            }
                                        }
                                    }
                                }
                                catch (IOException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            }
                        case "mv":
                            {
                                try
                                {
                                    if (commandarr.Length != 3)
                                    {
                                        Console.WriteLine("Неверный формат команды");
                                    }
                                    else
                                    {
                                        Directory.Move(commandarr[1], commandarr[2]);
                                    }
                                }
                                catch (IOException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            }
                        case "rmdir":
                            {
                                try
                                {
                                    if (commandarr.Length != 2)
                                    {
                                        Console.WriteLine("Неверный формат команды");
                                    }
                                    else
                                    {
                                        if (Directory.EnumerateFileSystemEntries(commandarr[1]).Count() > 0)
                                        {
                                            Console.WriteLine("Папка не пуста, для удаления папки воспользуйтес командой rm <путь> -r");
                                        }
                                        else
                                        {
                                            Directory.Delete(commandarr[1]);
                                        }
                                    }
                                }
                                catch (IOException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            }
                        case "rm":
                            {
                                try
                                {
                                    if (commandarr.Length != 2 && commandarr.Length != 3)
                                    {
                                        Console.WriteLine("Неверный формат команды");
                                    }
                                    else
                                    {
                                        if (commandarr.Length == 2)
                                        {
                                            Directory.Delete(commandarr[1]);
                                        }
                                        else
                                        {
                                            if (commandarr[2] == "-r")
                                            {
                                                Directory.Delete(commandarr[1], true);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Неизвестный параметр");
                                            }
                                        }
                                    }
                                }
                                catch (IOException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            }
                        case "gic":
                            {
                                try
                                {
                                    if (commandarr.Length != 2)
                                    {
                                        Console.WriteLine("Неверный формат команды");
                                    }
                                    else
                                    {
                                        Console.WriteLine(Directory.GetCreationTime(commandarr[1]));

                                    }
                                }
                                catch (IOException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            }
                        case "giv":
                            {
                                try
                                {
                                    if (commandarr.Length != 2)
                                    {
                                        Console.WriteLine("Неверный формат команды");
                                    }
                                    else
                                    {
                                        Console.WriteLine(Directory.GetLastAccessTime(commandarr[1]));

                                    }
                                }
                                catch (IOException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            }
                        case "gie":
                            {
                                try
                                {
                                    if (commandarr.Length != 2)
                                    {
                                        Console.WriteLine("Неверный формат команды");
                                    }
                                    else
                                    {
                                        Console.WriteLine(Directory.GetLastWriteTime(commandarr[1]));

                                    }
                                }
                                catch (IOException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            }
                        case "gec":
                            {
                                try
                                {
                                    if (commandarr.Length != 4)
                                    {
                                        Console.WriteLine("Неверный формат команды");
                                    }
                                    else
                                    {
                                        int deltaval;

                                        if (!int.TryParse(commandarr[3], out deltaval))
                                        {
                                            Console.WriteLine("Неверный формат целочисленного параметра");
                                        }
                                        else
                                        {
                                            DateTime ndt = Directory.GetCreationTime(commandarr[1]);
                                            switch (commandarr[2])
                                            {
                                                case "-y":
                                                    {
                                                        ndt = Directory.GetCreationTime(commandarr[1]).AddYears(deltaval);
                                                        break;
                                                    }
                                                case "-M":
                                                    {
                                                        ndt = Directory.GetCreationTime(commandarr[1]).AddMonths(deltaval);
                                                        break;
                                                    }
                                                case "-d":
                                                    {
                                                        ndt = Directory.GetCreationTime(commandarr[1]).AddDays(deltaval);
                                                        break;
                                                    }
                                                case "-h":
                                                    {
                                                        ndt = Directory.GetCreationTime(commandarr[1]).AddHours(deltaval);
                                                        break;
                                                    }
                                                case "-m":
                                                    {
                                                        ndt = Directory.GetCreationTime(commandarr[1]).AddMinutes(deltaval);
                                                        break;
                                                    }
                                                case "-s":
                                                    {
                                                        ndt = Directory.GetCreationTime(commandarr[1]).AddSeconds(deltaval);
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        Console.WriteLine("Неизвестный параметр");
                                                        break;
                                                    }
                                            }
                                            Directory.SetCreationTime(commandarr[1], ndt);
                                            Console.WriteLine(ndt);
                                        }
                                    }
                                }
                                catch (IOException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            }
                        case "gev":
                            {
                                try
                                {
                                    if (commandarr.Length != 4)
                                    {
                                        Console.WriteLine("Неверный формат команды");
                                    }
                                    else
                                    {
                                        int deltaval;

                                        if (!int.TryParse(commandarr[3], out deltaval))
                                        {
                                            Console.WriteLine("Неверный формат целочисленного параметра");
                                        }
                                        else
                                        {
                                            DateTime ndt = Directory.GetLastAccessTime(commandarr[1]);
                                            switch (commandarr[2])
                                            {
                                                case "-y":
                                                    {
                                                        ndt = Directory.GetLastAccessTime(commandarr[1]).AddYears(deltaval);
                                                        break;
                                                    }
                                                case "-M":
                                                    {
                                                        ndt = Directory.GetLastAccessTime(commandarr[1]).AddMonths(deltaval);
                                                        break;
                                                    }
                                                case "-d":
                                                    {
                                                        ndt = Directory.GetLastAccessTime(commandarr[1]).AddDays(deltaval);
                                                        break;
                                                    }
                                                case "-h":
                                                    {
                                                        ndt = Directory.GetLastAccessTime(commandarr[1]).AddHours(deltaval);
                                                        break;
                                                    }
                                                case "-m":
                                                    {
                                                        ndt = Directory.GetLastAccessTime(commandarr[1]).AddMinutes(deltaval);
                                                        break;
                                                    }
                                                case "-s":
                                                    {
                                                        ndt = Directory.GetLastAccessTime(commandarr[1]).AddSeconds(deltaval);
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        Console.WriteLine("Неизвестный параметр");
                                                        break;
                                                    }
                                            }
                                            Directory.SetLastAccessTime(commandarr[1], ndt);
                                            Console.WriteLine(ndt);
                                        }
                                    }
                                }
                                catch (IOException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            }
                        case "gee":
                            {
                                try
                                {
                                    if (commandarr.Length != 4)
                                    {
                                        Console.WriteLine("Неверный формат команды");
                                    }
                                    else
                                    {
                                        int deltaval;

                                        if (!int.TryParse(commandarr[3], out deltaval))
                                        {
                                            Console.WriteLine("Неверный формат целочисленного параметра");
                                        }
                                        else
                                        {
                                            DateTime ndt = Directory.GetLastWriteTime(commandarr[1]);
                                            switch (commandarr[2])
                                            {
                                                case "-y":
                                                    {
                                                        ndt = Directory.GetLastWriteTime(commandarr[1]).AddYears(deltaval);
                                                        break;
                                                    }
                                                case "-M":
                                                    {
                                                        ndt = Directory.GetLastWriteTime(commandarr[1]).AddMonths(deltaval);
                                                        break;
                                                    }
                                                case "-d":
                                                    {
                                                        ndt = Directory.GetLastWriteTime(commandarr[1]).AddDays(deltaval);
                                                        break;
                                                    }
                                                case "-h":
                                                    {
                                                        ndt = Directory.GetLastWriteTime(commandarr[1]).AddHours(deltaval);
                                                        break;
                                                    }
                                                case "-m":
                                                    {
                                                        ndt = Directory.GetLastWriteTime(commandarr[1]).AddMinutes(deltaval);
                                                        break;
                                                    }
                                                case "-s":
                                                    {
                                                        ndt = Directory.GetLastWriteTime(commandarr[1]).AddSeconds(deltaval);
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        Console.WriteLine("Неизвестный параметр");
                                                        break;
                                                    }
                                            }
                                            Directory.SetLastWriteTime(commandarr[1], ndt);
                                            Console.WriteLine(ndt);
                                        }
                                    }
                                }
                                catch (IOException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            }
                        case "exit":
                            {
                                if (commandarr.Length != 1)
                                {
                                    Console.WriteLine("Неверный формат команды");
                                }
                                else
                                {
                                    command = "exit";
                                }
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Неизвестный формат команды");
                                break;
                            }
                    }
                } while (command != "exit");


                Console.WriteLine("Для завершения работы программы нажмите Escape, иначе - любую кнопку");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            //File.Move()
        }
    }
}
