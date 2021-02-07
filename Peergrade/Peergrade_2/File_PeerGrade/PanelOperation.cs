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
    class PanelOperation
    {
       // Тут просто вычисление , самый главный Main и отец русской демократии это файл MainFileOperation.cs
       // Вычисления идентичны с MainFileOperation
       
        #region Параметры панели
        
        public static int PANEL_HEIGHT = 18;
        public static int PANEL_WIDTH = 120;

        #endregion

        #region Местоположение панели
        //присваиваем 2 перменных top т.е верхний 
        private int top;
        public int Top
        {
            get
            {
                return top;
            }
            set
            {
                //Проверка на размерность окна
                if (0 <= value && value <= Console.WindowHeight - PanelOperation.PANEL_HEIGHT)
                {
                    top = value;
                }
                else
                {
                    throw new Exception(String.Format("Выход координаты top ({0}) файловой панели за допустимое значение", value));
                }
            }
        }
        //присваиваем значение левого окна
        private int left;
        public int Left
        {
            get
            {
                return left;
            }
            set
            {
                //Проверка на размерность окна
                if (0 <= value && value <= Console.WindowWidth - PanelOperation.PANEL_WIDTH)
                {
                    left = value;
                }
                else
                {
                    throw new Exception(string.Format("Выход координаты left ({0}) файловой панели за пределы окна", value));
                }
            }
        }
        //присваивание значение ширины окна
        private int height = PanelOperation.PANEL_HEIGHT;
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                //Проверка на размерность окна
                if (0 < value && value <= Console.WindowHeight)
                {
                    height = value;
                }
                else
                {
                    throw new Exception(String.Format("Высота файловой панели {0} больше размера окна", value));
                }
            }
        }
        //Присваивание значения длины окна
        private int width = PanelOperation.PANEL_WIDTH;
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                //Проверка на размерность окна
                if (0 < value && value <= Console.WindowWidth)
                    width = value;
                else
                    throw new Exception(string.Format("Ширина файловой панели {0} больше размера окна", value));
            }
        }
        #endregion

        #region Panel state
        
        private string path;
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                //Получаем информацию про директорию
                DirectoryInfo di = new DirectoryInfo(value);
                //Проходим валидацию директории
                if (di.Exists)
                    path = value;
                else
                    throw new Exception(string.Format($"Путь {value} не существует"));
            }
        }
        //Присваиваем переменные некоторе значения
        private int activeObjectIndex = 0;
        private int firstObjectIndex = 0;
        private int displayedObjectsAmount = PANEL_HEIGHT - 2;
        private bool active;
        //Активна ли операция или нет
        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        }
        private bool discs;
        // Существует ои диск или нет
        public bool isDiscsOrNot
        {
            get
            {
                return discs;
            }
        }
                                  
        #endregion
                
        private List<FileSystemInfo> panelObjects = new List<FileSystemInfo>();

        #region PanelMain

        public PanelOperation()
        {
            //Инициализая диска
            SetDiscs();
        }
      
        public PanelOperation(string path)
        {
            //Присваиваем пути
            this.path =  path;
            //Панель
            SetLists();
        }

        public FileSystemInfo GetActiveObject()
        {
            //Если объект не является пустым , то выполняем действие
            if (panelObjects != null && panelObjects.Count != 0)
            {
                return panelObjects[activeObjectIndex];
            }
            throw new Exception("Список объектов панели пуст");
        }
        #endregion

        #region Поиск файлов
        public bool FindFile(string name)
        {
            int index = 0;
            try
            {
                //Foreach'ом перебираем эелементы
                foreach (FileSystemInfo file in panelObjects)
                {
                    //Проверка валидации файла
                    if (file != null && file.Name == name)
                    {
                        activeObjectIndex = index;
                        //Если индекс больше чем количество, то присваивается значение
                        if (activeObjectIndex > displayedObjectsAmount)
                        {
                            firstObjectIndex = activeObjectIndex;
                        }
                        //После операции мы присваиваем булевское значение False в метод UpdateContent
                        UpdateContent(false);
                        return true;
                    }
                    index++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message} , {e.GetType()}");
            }
            return false;
        }
        #endregion

        #region Навигации действий

        public void KeyboardProcessing(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    ScrollUp();
                    break;
                case ConsoleKey.DownArrow:
                    ScrollDown();
                    break;
                case ConsoleKey.Home:
                    GoBegin();
                    break;
                case ConsoleKey.End:
                    GoEnd();
                    break;
                case ConsoleKey.PageUp:
                    PageUp();
                    break;
                case ConsoleKey.PageDown:
                    PageDown();
                    break;
                default:
                    break;
            }
        }
       /// <summary>
       /// Перемещает кнопку вниз
       /// </summary>
        private void ScrollDown()
        {

            if (activeObjectIndex >= firstObjectIndex + displayedObjectsAmount - 1)
            {
                firstObjectIndex += 1;
                if (firstObjectIndex + displayedObjectsAmount >= panelObjects.Count)
                {
                    firstObjectIndex = panelObjects.Count - displayedObjectsAmount;
                }
                activeObjectIndex = firstObjectIndex + displayedObjectsAmount - 1;
                UpdateContent(false);
            }

            else
            {
                if (activeObjectIndex >= panelObjects.Count - 1)
                {
                    return;
                }
                DeactivateObject(activeObjectIndex);
                activeObjectIndex++;
                ActivateObject(activeObjectIndex);
            }
        }
        /// <summary>
        /// Перемещение кнопок вверх
        /// </summary>
        private void ScrollUp()
        {
            if (activeObjectIndex <= firstObjectIndex)
            {
                firstObjectIndex -= 1;
                if (firstObjectIndex < 0)
                {
                    firstObjectIndex = 0;
                }
                activeObjectIndex = firstObjectIndex;
                UpdateContent(false);
            }
            else
            {
                DeactivateObject(activeObjectIndex);
                activeObjectIndex--;
                ActivateObject(activeObjectIndex);
            }
        }
        /// <summary>
        /// Перемещение в самый вниз
        /// </summary>
        private void GoEnd()
        {
            if (firstObjectIndex + displayedObjectsAmount < panelObjects.Count)
            {
                firstObjectIndex = panelObjects.Count - displayedObjectsAmount;
            }
            activeObjectIndex = panelObjects.Count - 1;
            UpdateContent(false);
        }

        /// <summary>
        /// Перемещение кнопок в начало
        /// </summary>
        private void GoBegin()
        {
            firstObjectIndex = 0;
            activeObjectIndex = 0;
            UpdateContent(false);
        }

        /// <summary>
        /// Перемещает кнопку вниз
        /// </summary>
        private void PageDown()
        {
            if (activeObjectIndex + displayedObjectsAmount < panelObjects.Count)
            {
                firstObjectIndex += displayedObjectsAmount;
                activeObjectIndex += displayedObjectsAmount;
            }
            else
            {
                activeObjectIndex = panelObjects.Count - 1;
            }
            UpdateContent(false);
        }

        /// <summary>
        /// Перемещает кнопку вверх
        /// </summary>
        private void PageUp()
        {
            if (activeObjectIndex > displayedObjectsAmount)
            {
                firstObjectIndex -= displayedObjectsAmount;
                if (firstObjectIndex < 0)
                {
                    firstObjectIndex = 0;
                }

                activeObjectIndex -= displayedObjectsAmount;

                if (activeObjectIndex < 0)
                {
                    activeObjectIndex = 0;
                }
            }
            else
            {
                firstObjectIndex = 0;
                activeObjectIndex = 0;
            }
            UpdateContent(false);
        }

        #endregion

        #region Заполнение панелей
       
        public void SetLists()
        {
            if (panelObjects.Count != 0)
            {
                panelObjects.Clear();
            }

            discs = false;

            DirectoryInfo levelUpDirectory = null;
            panelObjects.Add(levelUpDirectory);
             
            //Директория и добавление
            string[] directories = Directory.GetDirectories(path);
            foreach (string directory in directories)
            {
                DirectoryInfo di = new DirectoryInfo(directory);
                panelObjects.Add(di);
            }

            //Файлы и добавление
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                panelObjects.Add(fi);
            }
        }

        //инициализация диска
        public void SetDiscs()
        {
            if (panelObjects.Count != 0)
            {
                panelObjects.Clear();
            }

            this.discs = true;

            DriveInfo[] discs = DriveInfo.GetDrives();
            foreach (DriveInfo disc in discs)
            {
                if (disc.IsReady)
                {
                    DirectoryInfo di = new DirectoryInfo(disc.Name);
                    panelObjects.Add(di);
                }
            }
        }

        #endregion

        #region Показывает два окна

        public void Show()
        {
            //Очищаем окно
            Clear();
            //Создаём рамки вокруг окна
            ThemeSelectorEditor.ThemeSelectorEditor.PrintFrameLine(left, top, width, height, ConsoleColor.White, ConsoleColor.Black);

            StringBuilder caption = new StringBuilder();
            if (discs)
            {
                caption.Append(' ').Append("Диски").Append(' ');
            }
            else
            {
                caption.Append(' ').Append(this.path).Append(' ');
            }
            //Внутри рамки ставим информацию про диски и т.д
            ThemeSelectorEditor.ThemeSelectorEditor.PrintString(caption.ToString(), left + width / 2 - caption.ToString().Length / 2, top, ConsoleColor.White, ConsoleColor.Black);

            PrintContent();
        }
        /// <summary>
        /// Очищает окно
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < height; i++)
            {
                string space = new String(' ', width);
                Console.SetCursorPosition(left, top + i);
                Console.Write(space);
            }
        }

        /// <summary>
        /// Выводит контент
        /// </summary>
        private void PrintContent()
        {
            if (panelObjects.Count == 0)
            {
                return;
            }
            int count = 0;

            int lastElement = firstObjectIndex + displayedObjectsAmount;
            if (lastElement > panelObjects.Count)
            {
                lastElement = panelObjects.Count;
            }


            if (activeObjectIndex >= panelObjects.Count)
            {
                activeObjectIndex = 0;
            }

            for (int i = firstObjectIndex; i < lastElement; i++)
            {
                Console.SetCursorPosition(left + 1, top + count + 1);
                
                if (i == activeObjectIndex && active == true)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                PrintObject(i);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                count++;
            }
        }
        /// <summary>
        /// Очистка контента от ненжужный сообщений
        /// </summary>
        private void ClearContent()
        {
            for (int i = 1; i < height - 1; i++)
            {
                string space = new String(' ', width - 2);
                Console.SetCursorPosition(left + 1, top + i);
                Console.Write(space);
            }
        }

        private void PrintObject(int index)
        {
            if (index < 0 || panelObjects.Count <= index)
            {
                throw new Exception(String.Format("Невозможно вывести объект c индексом {0}. Выход индекса за диапазон", index));
            }

            int currentCursorTopPosition = Console.CursorTop;
            int currentCursorLeftPosition = Console.CursorLeft;

            if (!discs && index == 0)
            {
                Console.Write("..");
                return;
            }

            Console.Write("{0}", panelObjects[index].Name);
            Console.SetCursorPosition(currentCursorLeftPosition + width / 2, currentCursorTopPosition);
            if (panelObjects[index] is DirectoryInfo)
            {
                Console.Write("{0}", ((DirectoryInfo)panelObjects[index]).LastWriteTime);
            }
            else
            {
                Console.Write("{0}", ((FileInfo)panelObjects[index]).Length);
            }
        }

        public void UpdatePanel()
        {
            firstObjectIndex = 0;
            activeObjectIndex = 0;
            Show();
        }

        public void UpdateContent(bool updateList)
        {
            if (updateList)
            {
                SetLists();
            }
            ClearContent();
            PrintContent();
        }

        private void ActivateObject(int index)
        {
            int offsetY = activeObjectIndex - firstObjectIndex;
            Console.SetCursorPosition(left + 1, top + offsetY + 1);
            
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            
            PrintObject(index);
           
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void DeactivateObject(int index)
        {
            int offsetY = activeObjectIndex - firstObjectIndex;
            Console.SetCursorPosition(left + 1, top + offsetY + 1);
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
           
            PrintObject(index);
        }

        #endregion
    }
}
