using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using ThemeSelectorEditor;

namespace FileManager
{
    class MainFileOperation
    {

        #region Параметры
        public static int HEIGHT_KEYS = 3;
        public static int BOTTOM_OFFSET = 2;
        #endregion

        public event OnKey KeyPress;
        List<PanelOperation> mainPanels = new List<PanelOperation>();
        private int activePanelIndex;

        #region Панель Управления Оформления

        static MainFileOperation()
        {
            //присваиваем значение нового окна
            Console.CursorVisible = false;
            // Размер окна 120 на 41
            Console.SetWindowSize(125, 42);
            // размер Буфера 120 на 41
            Console.SetBufferSize(125, 42);
            // Задаём цвет фонового и тени
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public MainFileOperation()
        {
            // Создаём новый объект типа filepanel
            PanelOperation filePanel = new PanelOperation();
            //Присваиваем размерность
            filePanel.Top = 0;
            filePanel.Left = 0;
            mainPanels.Add(filePanel);
            // Создаём новый объект типа filepanel
            filePanel = new PanelOperation();
            //Присваиваем размерность
            filePanel.Top = PanelOperation.PANEL_HEIGHT;
            filePanel.Left = 0;
            // Добавляем в панель в List
            mainPanels.Add(filePanel);
            // Активный индекс стоит ноль
            activePanelIndex = 0;

            mainPanels[activePanelIndex].Active = true;
            //После нажатия кнопки выполняется действие
            KeyPress += mainPanels[activePanelIndex].KeyboardProcessing;

            //Foreach'ом присваиваем значение и показываем в панели
            foreach (PanelOperation filePanelForMainOperation in mainPanels)
            {
                filePanelForMainOperation.Show();
            }

            // Показывает кнопки действия
            ShowKeys();
        }

        #endregion

        #region Операции Кнопок
        public void MainOperationOfProccess()
        {
            bool exit = false;

            while (!exit)
            {
                if (Console.KeyAvailable)
                {
                    ClearTextFromConsole();

                    ConsoleKeyInfo userKey = Console.ReadKey(true);
                    switch (userKey.Key)
                    {
                        case ConsoleKey.Tab:
                            ChangeActivePanel();
                            break;
                        case ConsoleKey.Enter:
                            ChangeDirectoryOrRunProcess();
                            break;
                        case ConsoleKey.F2:
                            Concat();
                            break;
                        case ConsoleKey.F3:
                            ViewFile();
                            break;
                        case ConsoleKey.F4:
                            CreateDirectory();
                            break;
                        case ConsoleKey.F5:
                            CopyFileOrDirectory();
                            break;
                        case ConsoleKey.F6:
                            MoveFileOrDirectory();
                            break;
                        case ConsoleKey.F7:
                            FindFileOrDirectory();
                            break;
                        case ConsoleKey.F8:
                            CreateFile();
                            break;
                        case ConsoleKey.F10:
                            RenameFileOrDirectory();
                            break;
                        case ConsoleKey.F9:
                            DeleteFileOrDirectory();
                            break;
                        case ConsoleKey.F12:
                            exit = true;
                            Console.ResetColor();
                            Console.Clear();
                            break;
                        case ConsoleKey.DownArrow:
                            goto case ConsoleKey.PageUp;
                        case ConsoleKey.UpArrow:
                            goto case ConsoleKey.PageUp;
                        case ConsoleKey.End:
                            goto case ConsoleKey.PageUp;
                        case ConsoleKey.Home:
                            goto case ConsoleKey.PageUp;
                        case ConsoleKey.PageDown:
                            goto case ConsoleKey.PageUp;
                        case ConsoleKey.PageUp:
                            KeyPress(userKey);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        #endregion

        #region Основная программа инициализации действия
        /// <summary>
        /// Программа инициализации действий с названиями
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private string MainName(string message)
        {
            string name;
            Console.CursorVisible = true;
            do
            {
                //Очищает панель окна от ненужных сообщений
                ClearTextFromConsole();
                //показывает сообщение 
                ShowMessage(message);
                //Пользователь вводит имя/название каталога или файла 
                name = Console.ReadLine();
            } while (name.Length == 0);
            Console.CursorVisible = false;
            ClearTextFromConsole();
            return name;
        }
        #endregion

        #region Файловый Операции
        /// <summary>
        /// Копировка файла или каталога
        /// </summary>
        private void CopyFileOrDirectory()
        {
            foreach (PanelOperation panel in mainPanels)
            {
                //Проверка, находится ли файл в диске или нет
                if (panel.isDiscsOrNot)
                {
                    return;
                }
            }
            // 0 индекс это первое окно , 1 индекс - второе окно
            if (mainPanels[0].Path == mainPanels[1].Path)
            {
                return;
            }

            try
            {
                //Показывает путь файла
                string destPath = activePanelIndex == 0 ? mainPanels[1].Path : mainPanels[0].Path;

                // Узнаём инфо в панеле
                FileSystemInfo fileObject = mainPanels[activePanelIndex].GetActiveObject();
                //Присваиваем объект который находится в панеле присваиваем в файловой системе currentfile
                FileInfo currentFile = fileObject as FileInfo;

                //Если currentfile не является пустым то копируем путь
                if (currentFile != null)
                {
                    string fileName = currentFile.Name;
                    string destName = Path.Combine(destPath + Path.DirectorySeparatorChar  + fileName);
                    File.Copy(currentFile.FullName, destName, true);
                }
                // Если нет, то используем метод копировки
                else
                {
                    string currentDirectory = ((DirectoryInfo)fileObject).FullName;
                    string destDirectory = Path.Combine(destPath + Path.DirectorySeparatorChar + ((DirectoryInfo)fileObject).Name);
                    CopyDirectory(currentDirectory, destDirectory);
                }
                // Обновляем панель
                UpdatePanels();
            }
            catch (IOException)
            {
                Console.WriteLine("Упсс возникла проблема в копировке :(");
            }
            catch (Exception e)
            {
                ShowMessage(e.Message);
                return;
            }
        }

        /// <summary>
        /// Выполняется копирование директории или файла
        /// </summary>
        /// <param name="sourceDirName">Главный путь</param>
        /// <param name="destDirName"> Указанный путь</param>
        private void CopyDirectory(string sourceDirName, string destDirName)
        {
            try
            {
                // Находим директорию
                DirectoryInfo directory = new DirectoryInfo(sourceDirName);
                //Находим диск и присваиваем в массив
                DirectoryInfo[] inDirectories = directory.GetDirectories();

                //Если директорию не существует , то создаём
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }
                // Закидываем в массив и находим файлы
                FileInfo[] files = directory.GetFiles();

                //Foreach'ом перебираем файлы
                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(destDirName + Path.DirectorySeparatorChar + file.Name);
                    file.CopyTo(temppath, true);
                }
                //Foreach'ом перебираем директории
                foreach (DirectoryInfo subdir in inDirectories)
                {
                    string temppath = Path.Combine(destDirName + Path.DirectorySeparatorChar + subdir.Name);
                    CopyDirectory(subdir.FullName, temppath);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Упсс возникла проблема в копировке директории");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} , {e.GetType()}");
            }
        }
        /// <summary>
        /// Метод , который удаляет директорию или файл
        /// </summary>
        private void DeleteFileOrDirectory()
        {
            //Проверка находится ли файл или папка в диске или нет
            if (mainPanels[activePanelIndex].isDiscsOrNot)
            {
                return;
            }
            // Находим информацию про панель файлов или папки
            FileSystemInfo fileObject = mainPanels[activePanelIndex].GetActiveObject();
            try
            {
                //Если объект является папкой , то мы удаляем
                if (fileObject is DirectoryInfo)
                {
                    ((DirectoryInfo)fileObject).Delete(true);
                }
                // А если объект является файлом, то тоже удаляем
                else
                {
                    ((FileInfo)fileObject).Delete();
                }
                //Обновляем панель
                UpdatePanels();
            }
            catch (Exception e)
            {
                ShowMessage(e.Message);
                return;
            }
        }

        /// <summary>
        /// Создаём директорию
        /// </summary>
        private void CreateDirectory()
        {
            //Проверка находится ли файл или папка в диске или нет
            if (mainPanels[activePanelIndex].isDiscsOrNot)
            {
                return;
            }
            // Присваивание значенмя пути и имени каталога
            string destPath = mainPanels[activePanelIndex].Path;
            string dirName = MainName("Введите имя каталога: ");

            try
            {
                // Соединяем путь и имя и присваиваем в dirFullName
                string dirFullName = Path.Combine(destPath + Path.DirectorySeparatorChar + dirName);
                // Создаём переменную 
                DirectoryInfo dir = new DirectoryInfo(dirFullName);
                //Если директории не существует , то мы создаём
                if (!dir.Exists)
                {
                    dir.Create();
                }
                // А если существует, то выводим это сообщение
                else
                {
                    ShowMessage("Каталог с таким именем уже существует");
                }
                //Обновляем панель
                UpdatePanels();
            }
            catch (Exception e)
            {
                ShowMessage(e.Message);
            }
        }
        private void CreateFile()
        {
            //Проверка находится ли файл или папка в диске или нет
            if (mainPanels[activePanelIndex].isDiscsOrNot)
            {
                return;
            }
            // Присваивание значенмя пути и имени каталога
            string destPath = mainPanels[activePanelIndex].Path;
            string dirName = MainName("Введите имя файла: ");

            try
            {
                // Соединяем путь и имя и присваиваем в dirFullName
                string dirFullName = Path.Combine(destPath + Path.DirectorySeparatorChar + dirName);
                // Создаём переменную 
                FileInfo file = new FileInfo(dirFullName);

            //Пользователь вводит какой-то текст
                if (!file.Exists)
                {
                    Console.Write("Напишите вашу запись в файле: ");
                    string str = Console.ReadLine();
                    //Производится выюор кодировки от пользователя
                    Console.WriteLine("Какую кодировку выберете? utf8/ascii/unicode ");
                    string encoding = Console.ReadLine();
                    // Делаем нижний регистр строке
                    encoding = encoding.ToLower().Trim();
                    // Проверка на доступные кодировки
                    if (encoding == "utf8")
                    {
                        File.WriteAllText(dirFullName, str, Encoding.UTF8);
                        Console.Write("Успешно записано!");
                        UpdatePanels();
                        return;
                    }
                    else if (encoding == "ascii")
                    {
                        File.WriteAllText(dirFullName, str, Encoding.ASCII);
                        Console.WriteLine("Успешно записано!");
                        UpdatePanels();
                        return;
                    }
                    else if (encoding == "unicode")
                    {
                        File.WriteAllText(dirFullName, str, Encoding.Unicode);
                        Console.WriteLine("Успешно записано!");
                        UpdatePanels();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Я не нашёл кодировку , которую могу предложить :(");
                        CreateFile();
                    }
                }
                // А если существует, то выводим это сообщение
                else
                {
                    ShowMessage("Каталог с таким именем уже существует");
                }
                //Обновляем панель
                UpdatePanels();
            }
            catch (IOException)
            {
                Console.WriteLine("Ошибка в чтении файла");
                return;
            }
            catch (Exception e)
            {
                ShowMessage(e.Message);
            }
        }
        /// <summary>
        /// Перемещение файла или каталога
        /// </summary>
        private void MoveFileOrDirectory()
        {
            // Перебираем панель 
            foreach (PanelOperation panel in mainPanels)
            {
                //Находится ли элемент в панеле директории или нет
                if (panel.isDiscsOrNot)
                {
                    return;
                }
            }
            // Сравнивается первое и второе окно консоли
            if (mainPanels[0].Path == mainPanels[1].Path)
            {
                return;
            }

            try
            {
                //Присваиваем значение пути 
                string destPath = activePanelIndex == 0 ? mainPanels[1].Path : mainPanels[0].Path;
                // Создаём объект пути и присваиваем в fileObject
                FileSystemInfo fileObject = mainPanels[activePanelIndex].GetActiveObject();

                // Присваивание 2 переменные имени и полной пути
                string objectName = fileObject.Name;
                string destName = Path.Combine(destPath +  Path.DirectorySeparatorChar + objectName);

                if (fileObject is FileInfo)
                {
                    ((FileInfo)fileObject).MoveTo(destName);
                }
                else
                {
                    ((DirectoryInfo)fileObject).MoveTo(destName);
                }
                //Обновляет панель окна
                UpdatePanels();
            }
            catch (Exception e)
            {
                ShowMessage(e.Message);
                return;
            }

        }

        /// <summary>
        /// Перемеинование файла или директории
        /// </summary>
        private void RenameFileOrDirectory()
        {
            if (mainPanels[activePanelIndex].isDiscsOrNot)
            {
                return;
            }
            //присваивается объект в панели
            FileSystemInfo fileObject = mainPanels[activePanelIndex].GetActiveObject();
            string currentPath = mainPanels[activePanelIndex].Path;

            //Присваивается 2 переменных, которые смотрят имя которое нужно искать 
            string newName = MainName("Введите новое имя: ");
            string newFullName = Path.Combine(currentPath + Path.DirectorySeparatorChar + newName);

            try
            {
                if (fileObject is FileInfo)
                {
                    ((FileInfo)fileObject).MoveTo(newFullName);
                }
                else
                {
                    ((DirectoryInfo)fileObject).MoveTo(newFullName);
                }
                //Обновление панели
                UpdatePanels();
            }
            catch (Exception e)
            {
                ShowMessage(e.Message);
            }
        }

        #endregion

        #region Просмотр Файлов

        private void ViewFile()
        {
            // Находится ли элемент в диске или нет
            if (mainPanels[activePanelIndex].isDiscsOrNot)
            {
                return;
            }

            //Присваиваение значение в объект
            FileSystemInfo fileObject = mainPanels[activePanelIndex].GetActiveObject();
            //проверка , объект является ли директорией или не является пустым
            if (fileObject is DirectoryInfo || fileObject == null)
            {
                return;
            }

            //Если объект является 0 , то выводится ссобщение
            if (((FileInfo)fileObject).Length == 0)
            {
                ShowMessage("Файл пуст");
                return;
            }

            //Если объект больше 100 мб 
            if (((FileInfo)fileObject).Length > 100000000)
            {
                ShowMessage("Файл слишком большой для просмотра");
                return;
            }

            // Смотрит файлы в фрейме(окна)
            DrawViewFileFrame(fileObject.Name);
            string fileContent;
            //Производится выюор кодировки от пользователя
            Console.WriteLine("Какую кодировку вы хотите? utf8/ascii/unicode");
            string encoding = Console.ReadLine();
            // Ввод делаем в нижнем регистре
            encoding = encoding.Trim().ToLower();
            //Првоерка на кодировку если не нашли , то выводится ошибка
            if (encoding == "utf8")
            {
                fileContent = ReadFileToString(fileObject.FullName, Encoding.UTF8);
            }
            else if (encoding == "ascii")
            {
                fileContent = ReadFileToString(fileObject.FullName, Encoding.ASCII);
            }
            else if (encoding == "unicode")
            {
                fileContent = ReadFileToString(fileObject.FullName, Encoding.Unicode);
            }
            else
            {
                Console.WriteLine("Я не нашёл кодировку , которую мог бы предложить ;(");
                UpdatePanels();
                ShowKeys();
                return;
            }


            int beginPosition = 0;
            int howManySymbolsCount = 0;
            bool endOfFile = false;
            bool beginFile = true;
            //Сохраняем в стеке символы
            Stack<int> printSymbols = new Stack<int>();

            // Положение позиции и прогресса просмотра файлов
            howManySymbolsCount = PrintStingFrame(fileContent, beginPosition);
            printSymbols.Push(howManySymbolsCount);
            PrintProgress(beginPosition + howManySymbolsCount, fileContent.Length);

            bool exit = false;
            //Пока не внутри текстового пользователь не нажмёт на Escape
            while (!exit)
            {
                // Создаём конец и начало файла
                endOfFile = (beginPosition + howManySymbolsCount) >= fileContent.Length;
                beginFile = (beginPosition <= 0);
                // После действий с кнопкой производится действие
                ConsoleKeyInfo userKey = Console.ReadKey(true);
                switch (userKey.Key)
                {
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                    //Перемещает строку вниз 
                    case ConsoleKey.PageDown:
                        if (!endOfFile)
                        {
                            //добавляется +1 строка 
                            beginPosition += howManySymbolsCount;
                            //показывается в консоле
                            howManySymbolsCount = PrintStingFrame(fileContent, beginPosition);
                            printSymbols.Push(howManySymbolsCount);
                            //Показывает прогресс позиции
                            PrintProgress(beginPosition + howManySymbolsCount, fileContent.Length);
                        }
                        break;
                    //Перемещает строку наверх
                    case ConsoleKey.PageUp:
                        if (!beginFile)
                        {
                            // Пока строка не будет в нулевой позиции мы удаляем
                            if (printSymbols.Count != 0)
                            {
                                beginPosition -= printSymbols.Pop();
                                if (beginPosition < 0)
                                {
                                    beginPosition = 0;
                                }
                            }
                            else
                            {
                                beginPosition = 0;
                            }
                            //Вывод изменений в консоле
                            howManySymbolsCount = PrintStingFrame(fileContent, beginPosition);
                            PrintProgress(beginPosition + howManySymbolsCount, fileContent.Length);
                        }
                        break;
                }
            }
            // Foreach'ом перебираем файлы
            foreach (PanelOperation filePanelSecond in mainPanels)
            {
                filePanelSecond.Show();
            }
            //Показывются действия кнопок
            ShowKeys();
        }
        private void Concat()
        {
            Console.WriteLine("Извини.. Надеюсь на твоё понимание. Я не успел сделать конкатенацию");
            Console.WriteLine("А точнее просто не смог сделать. исключение выдавало...");
        }

        /// <summary>
        /// Создаёт окно в котором будет показано информацию строки внутри файлов
        /// </summary>
        /// <param name="file"></param>
        private void DrawViewFileFrame(string file)
        {
            Console.Clear();
            ThemeSelectorEditor.ThemeSelectorEditor.PrintFrameDoubleLine(0, 0, Console.WindowWidth, Console.WindowHeight - 5, ConsoleColor.DarkYellow, ConsoleColor.Black);
            string fileName = String.Format(" {0} ", file);
            ThemeSelectorEditor.ThemeSelectorEditor.PrintString(fileName, (Console.WindowWidth - fileName.Length) / 2, 0, ConsoleColor.Yellow, ConsoleColor.Black);
            ThemeSelectorEditor.ThemeSelectorEditor.PrintFrameLine(0, Console.WindowHeight - 5, Console.WindowWidth, 4, ConsoleColor.DarkYellow, ConsoleColor.Black);
            ThemeSelectorEditor.ThemeSelectorEditor.PrintString("PageDown / PageUp - навигация, Esc - выход", 1, Console.WindowHeight - 4, ConsoleColor.White, ConsoleColor.Black);
        }
        /// <summary>
        /// Показывает прогресс позиции внутри текстового файла
        /// </summary>
        /// <param name="position"></param>
        /// <param name="length"></param>
        private void PrintProgress(int position, int length)
        {
            string pageMessage = String.Format("Позиция: {0}%", (100 * position) / length);
            ThemeSelectorEditor.ThemeSelectorEditor.PrintString(new String(' ', Console.WindowWidth / 2 - 1), Console.WindowWidth / 2, Console.WindowHeight - 4, ConsoleColor.White, ConsoleColor.Black);
            ThemeSelectorEditor.ThemeSelectorEditor.PrintString(pageMessage, Console.WindowWidth - pageMessage.Length - 2, Console.WindowHeight - 4, ConsoleColor.White, ConsoleColor.Black);
        }
        /// <summary>
        /// Считывает , что находится внутри текстового документа и разделяет по строкам
        /// </summary>
        /// <param name="fullFileName"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        private string ReadFileToString(string fullFileName, Encoding encoding)
        {
            StreamReader steamReaderNew = new StreamReader(fullFileName, encoding);
            string fileContent = steamReaderNew.ReadToEnd();
            fileContent = fileContent.Replace("\a", " ").Replace("\b", " ").Replace("\f", " ").Replace("\r", " ").Replace("\v", " ");
            steamReaderNew.Close();
            return fileContent;
        }
        /// <summary>
        /// Показывает в фрейме строки
        /// </summary>
        /// <param name="text"></param>
        private void PrintStingFrame(string text)
        {
            Console.SetCursorPosition(1, 1);

            int frameWidth = Console.WindowWidth - 2;
            int colCount = 0;
            int rowCount = 1;
            int symbolIndex = 0;
            while (symbolIndex < text.Length)
            {
                if (colCount == frameWidth)
                {
                    rowCount++;
                    Console.SetCursorPosition(1, rowCount);
                    colCount = 0;
                }
                Console.Write(text[symbolIndex]);
                symbolIndex++;
                colCount++;
            }
        }
        /// <summary>
        /// Запись и вывод строки в окне
        /// </summary>
        /// <param name="text"></param>
        /// <param name="begin"></param>
        /// <returns></returns>
        private int PrintStingFrame(string text, int begin)
        {
            ClearFileViewFrame();

            int lastTopCursorPosition = Console.WindowHeight - 7;
            int lastLeftCursorPosition = Console.WindowWidth - 2;

            Console.SetCursorPosition(1, 1);

            int currentTopPosition = Console.CursorTop;
            int currentLeftPosition = Console.CursorLeft;

            int index = begin;
            while (true)
            {
                if (index >= text.Length)
                {
                    break;
                }

                Console.Write(text[index]);
                currentTopPosition = Console.CursorTop;
                currentLeftPosition = Console.CursorLeft;

                if (currentLeftPosition == 0 || currentLeftPosition == lastLeftCursorPosition)
                {
                    Console.CursorLeft = 1;
                }

                if (currentTopPosition == lastTopCursorPosition)
                {
                    break;
                }

                index++;
            }
            return index - begin;
        }
        /// <summary>
        /// Очищает от ненужный сообщений
        /// </summary>
        private void ClearFileViewFrame()
        {
            //Задём ширину и высоту окна
            int topCursorPosition = Console.WindowHeight - 7;
            int leftCursorPosition = Console.WindowWidth - 2;

            //Циклом for выводим на экран
            for (int row = 1; row < topCursorPosition; row++)
            {
                Console.SetCursorPosition(1, row);
                string space = new String(' ', leftCursorPosition);
                Console.Write(space);
            }
        }

        #endregion

        #region Поиск файлов или папки
        /// <summary>
        /// Поиск директории или файла
        /// </summary>
        private void FindFileOrDirectory()
        {
            //Существвет ли в диске или нет
            if (mainPanels[activePanelIndex].isDiscsOrNot)
            {
                return;
            }
            //присвоение значениЯ
            string fileName = MainName("Введите имя: ");

            //Есщи не найдет каталог выводится ошибка
            if (!mainPanels[activePanelIndex].FindFile(fileName))
            {
                ShowMessage("Файл/каталог в текущем каталоге не найден");
            }
        }
        #endregion

        #region Показывать примечание
        /// <summary>
        /// Показывает сообщение примечания
        /// </summary>
        /// <param name="message"></param>
        private void ShowMessage(string message)
        {
            ThemeSelectorEditor.ThemeSelectorEditor.PrintString(message, 0, Console.WindowHeight - BOTTOM_OFFSET, ConsoleColor.White, ConsoleColor.Black);
        }
        #endregion

        #region Очистить сообщение
        /// <summary>
        /// Очищает файл
        /// </summary>
        private void ClearTextFromConsole()
        {
            ThemeSelectorEditor.ThemeSelectorEditor.PrintString(new String(' ', Console.WindowWidth), 0, Console.WindowHeight - BOTTOM_OFFSET, ConsoleColor.White, ConsoleColor.Black);
        }
        #endregion

        #region Поменять активную панель
        //Меняет панели окна (смотрите в изображениях я показывал инструкцию)
        private void ChangeActivePanel()
        {
            //Пока пользователь не нажмёт TAB окно не поменяется на другую
            mainPanels[activePanelIndex].Active = false;
            KeyPress -= mainPanels[activePanelIndex].KeyboardProcessing;
            mainPanels[activePanelIndex].UpdateContent(false);

            activePanelIndex++;
            if (activePanelIndex >= mainPanels.Count)
            {
                activePanelIndex = 0;
            }
            //Есщи пользователь нажал на TAB окно не  будет меняться на другую
            mainPanels[activePanelIndex].Active = true;
            KeyPress += mainPanels[activePanelIndex].KeyboardProcessing;
            mainPanels[activePanelIndex].UpdateContent(false);
        }
        #endregion

        #region Поменять директорию или процесс
        /// <summary>
        /// Меняется директорию или процесс
        /// </summary>
        private void ChangeDirectoryOrRunProcess()
        {
            //Показывает информацию про панель окон
            FileSystemInfo panelInfo = mainPanels[activePanelIndex].GetActiveObject();
            //Проверка валидности
            if (panelInfo != null)
            {
                if (panelInfo is DirectoryInfo)
                {
                    try
                    {
                        //получает директорию

                        Directory.GetDirectories(panelInfo.FullName);
                    }
                    catch
                    {
                        return;
                    }
                    // присвоение параметров в панель
                    mainPanels[activePanelIndex].Path = panelInfo.FullName;
                    mainPanels[activePanelIndex].SetLists();
                    mainPanels[activePanelIndex].UpdatePanel();
                }
                else
                {
                    try
                    {
                        //А если нет, то запускаем процесс просмотра
                        Process.Start(((FileInfo)panelInfo).FullName);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e.Message} , {e.GetType()}");
                    }
                }
            }
            else
            {
                //Присвоение сдешнего пути 
                string currentPath = mainPanels[activePanelIndex].Path;
                DirectoryInfo currentDirectory = new DirectoryInfo(currentPath);
                DirectoryInfo upLevelDirectory = currentDirectory.Parent;

                if (upLevelDirectory != null)
                {
                    // присвоение параметров в панель
                    mainPanels[activePanelIndex].Path = upLevelDirectory.FullName;
                    mainPanels[activePanelIndex].SetLists();
                    mainPanels[activePanelIndex].UpdatePanel();
                }

                else
                {
                    // присвоение параметров в панель
                    mainPanels[activePanelIndex].SetDiscs();
                    mainPanels[activePanelIndex].UpdatePanel();
                }
            }
        }
        #endregion

        #region Обновление панели окна
        //Обновляет панель
        private void UpdatePanels()
        {
            if (mainPanels == null || mainPanels.Count == 0)
            {
                return;
            }
            //Foreach'ом перебираем панели
            foreach (PanelOperation panel in mainPanels)
            {
                if (!panel.isDiscsOrNot)
                {
                    panel.UpdateContent(true);
                }
            }
        }
        #endregion

        #region Кнопки действия
        /// <summary>
        /// Показывает кнопки действия
        /// </summary>
        private void ShowKeys()
        {
            string[] menu = { "TAB Окна F2 Конкат F3 Просмотр F4 Папка F5 Копия F6 Перемещение F7 Поиск F8 Файл F9 Удаление F10 Перемеин F12 Выход" };

            // задаётся позиция кнопок (я задал в самом внизу) 
            int cellLeft = mainPanels[0].Left;
            int cellTop = PanelOperation.PANEL_HEIGHT * mainPanels.Count;
            int cellWidth = PanelOperation.PANEL_WIDTH / menu.Length;
            int cellHeight = MainFileOperation.HEIGHT_KEYS;

            // Циклом for перебираю слова и добавляю в рамку
            for (int i = 0; i < menu.Length; i++)
            {
            
                ThemeSelectorEditor.ThemeSelectorEditor.PrintString(menu[i], cellLeft + i * cellWidth + 1, cellTop + 2, ConsoleColor.White, ConsoleColor.Black);
            }
        }
        #endregion

    }
}