using System;
using System.IO;

namespace Matrix_Calculus
{
    //Объявляю класс Matrix для дальнейшего вычисления операций над матрицами
    class Matrix
    {
        // Вот чтобы почитать про классы и объекты https://metanit.com/sharp/tutorial/3.1.php
        // Слушай, а может после пиргрейда в Among us поиграть?
        // Если да , то Я тебе скину после пиргрейда код 

        //Чисто отдельный объект рандома, чтобы находить случайные цифры от -10 до 50
        Random rnd = new Random();
        #region ValidateNumber
        /// <summary>
        /// Проверка на валидность чисел
        /// </summary>
        /// <returns></returns>
        static int ValidateNumber()
        {
            int numberValidate;
            do
            {

            }
            while (!int.TryParse(Console.ReadLine(), out numberValidate));

            return numberValidate;
        }
        #endregion

        #region NumberLessThanZeroOrNot
        /// <summary>
        /// Проверка на отрицательность числа
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int NumberLessThanZeroOrNot(int n)
        {
            //Циклом while проверяем число на корректность, если оно мень 0 то выводится Incorrect input
            while (n <= 0)
            {
                Console.WriteLine("\tIncorrect input");
                Console.Write("\t");
                n = ValidateNumber();
            }
            //А если всё правильно , то выводим число
            return n;
        }
        #endregion

        #region ChoiceInput
        /// <summary>
        /// Какой способ заполнения хочет выбрать пользватель
        /// </summary>
        /// <param name="choice">Цифра выбора способа</param>
        /// <returns></returns>
        static int ChoiceInputMatrix(out int choice)
        {
            Console.WriteLine("\tКак вы хотите заполнить матрицу? ");
            Console.WriteLine("\t1 - Вручную ");
            Console.WriteLine("\t2 - Случайными цифрами");
            Console.WriteLine("\t3 - Матрица записывается в файл (../bin/netcore3.1/text.txt)", Environment.NewLine);
            Console.Write("\tВаш ответ: ");
            // Проверка на валидность числа
            choice = ValidateNumber();
            choice = NumberLessThanZeroOrNot(choice);
            //Возвращаем число
            return choice;
        }
        #endregion

        #region FileMatrix
        /// <summary>
        /// Запись матрицы в файл через консоль и вывод для вычисления
        /// </summary>
        /// <param name="matrix"></param>
        static void FileMatrix(int[,] matrix)
        {
            try
            {
                //Сначала создём файл text.txt в путь ../bin/netcore3.1/text.txt
                using (StreamWriter stream = new StreamWriter("text.txt"))
                {
                    //Циклом for перебираем матрицы и записываем в массив
                    for (int i = 0; i < matrix.GetLength(1); i++)
                    {
                        // Записываем столбцы и записываем в массив
                        for (int k = 0; k < matrix.GetLength(0); k++)
                            stream.Write("{0} ", matrix[i, k]);
                        stream.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t──────────────────────────────────────────────");
                Console.WriteLine("\tУпсс.. Произошла ошибка. Убираю не нужные цифры и буквы...");
                Console.WriteLine($"\tТип ошибки: {ex.GetType()} , Причина: {ex.Message}");
            }
        }
        #endregion

        #region Transposition
        /// <summary>
        /// Метод выполняет транспонирование матрицы 
        /// </summary>
        static void Transposition()
        {
            Console.Clear();
            //Присваиваем переменную
            int choice;
            try
            {
                //Присваиваем переменную где N это строка, M это столбец
                int N, M;
                //Проверка на N строку
                do
                {
                    Console.Clear();
                    Console.WriteLine("\t───────────────────{ Транспонированние }─────────────────────────");
                    Console.WriteLine("При неправильном вводе данных, автоматически заменяется на 0");
                    Console.Write("\tВведите длину строки N: ");
                } while (!int.TryParse(Console.ReadLine(), out N) && N < 0);
                //Проверка на M строку
                do
                {
                    Console.Clear();
                    Console.WriteLine("\t───────────────────{ Транспонированние }─────────────────────────");
                    Console.WriteLine("При неправильном вводе данных, автоматически заменяется на 0");
                    Console.WriteLine($"\tДлина строки N: {N}");
                    Console.Write("\tВведите длину строки M: ");
                } while (!int.TryParse(Console.ReadLine(), out M) && N < 0);
                //Создаём двумерный массив чисел и присваиваем N-строки M-столбцы
                int[,] transpositionMatrix = new int[N, M];
                //Создаём класс Random и объект rnd
                Random rnd = new Random();
                //Создаёт строковой массив
                string[] str_arr;
                //Созаём класс Matrix и присваиваем объект mtr
                Matrix mtr = new Matrix(transpositionMatrix.Length);
                //Выбор способа заполнения
                ChoiceInputMatrix(out choice);

                //Ввод через клавиатуру
                if (choice == 1)
                {
                    //Матрица вводится через пробел
                    Console.WriteLine("\tПри неправильном вводе , вместо буквы или цифры присваивается ноль!");
                    Console.WriteLine("\tВведите ваши цифры через пробел..");
                    for (int i = 0; i < N; ++i)
                    {
                        //После ввода передаётся в массив
                        str_arr = (Console.ReadLine()).Split(' ');
                        for (int j = 0; j < M; j++)
                            //Обрабатываем трай парсом и присваивается в матрицу
                            int.TryParse(str_arr[j], out transpositionMatrix[i, j]);
                    }
                }
                //Случайными цифрами записывается массив
                else if (choice == 2)
                {
                    //Через цикл for перебираем строку N
                    for (int i = 0; i < N; i++)
                        // Через цикл for перебираем столбец M
                        for (int j = 0; j < M; j++)
                            //Случайными цифрами записывается в массив
                            transpositionMatrix[i, j] = rnd.Next(-50, 50);
                }
                //ЗАпись в файл и вывод
                else if (choice == 3)
                {
                    //Матрица вводится через пробел
                    Console.WriteLine("\tПри неправильном вводе , вместо буквы или цифры присваивается ноль!");
                    Console.WriteLine("\tВведите ваши цифры через пробел..");
                    //Через цикл for перебираем строку N
                    for (int i = 0; i < N; ++i)
                    {
                        Console.Write("\t ");
                        // После ввода записываем в массив
                        str_arr = (Console.ReadLine()).Split(' ');
                        for (int j = 0; j < M; j++)
                            // Через цикл for перебираем столбец M
                            int.TryParse(str_arr[j], out transpositionMatrix[i, j]);
                    }
                    //Запись в файл ../bin/netcore3.1/text.txt
                    FileMatrix(transpositionMatrix);
                }
                else
                {
                    Console.WriteLine("\t──────────────────────────────────────────────");
                    Console.WriteLine("\tОшибка ввода");
                    Console.Clear();
                    Transposition();
                }


                Console.WriteLine();
                //Вывод массива исходной
                Console.WriteLine("\tИсходная матрица:");
                //Перебираем строки
                for (int i = 0; i < N; i++)
                {
                    //Перебираем столбец
                    Console.Write("\t");
                    for (int j = 0; j < M; j++)
                        //Выводим массив 
                        Console.Write(transpositionMatrix[i, j] + " \t ");
                    Console.WriteLine();
                }
                Console.WriteLine();
                //Присваиваем массив и задаём размерность
                int[,] trans = new int[M, N];
                //Результат транспонированной матрицы
                Console.WriteLine("\tТранспонированная матрица: ");
                Console.WriteLine();
                //Перебираем столбцы
                for (int i = 0; i < M; i++)
                {
                    //Перебираем строки
                    Console.Write("\t");
                    for (int j = 0; j < N; j++)
                    {
                        //Присваиваем столбец в строку и строку в столбец
                        trans[i, j] = transpositionMatrix[j, i];
                        //Вывод массива
                        Console.Write(trans[i, j] + " \t ");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t{ex.Message}");
                Console.ReadKey();
                Transposition();
                return;
            }
        }
        #endregion

        #region Determinant of Matrix
        /// <summary>
        /// Определитель матрицы через рекурсию
        /// </summary>
        /// <param name="matrix">матрица</param>
        /// <returns></returns>
        private static int DeterminantRecursion(int[,] matrix)
        {
            // Если матрица 2-го порядка , то выполняем эту функцию
            if (matrix.Length == 4)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            //Присваиваем переменную
            int sign = 1, result = 0;
            //Перебираем строки
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                //Получаем минор матрицы и присваиваем в массив minor
                int[,] minor = GetMinor(matrix, i);
                //Выполняем вычисление и присваиваем в result
                result += sign * matrix[0, i] * DeterminantRecursion(minor);
                sign = -sign;
            }
            //Возвращение числа
            return result;
        }
        #endregion

        #region Minor
        /// <summary>
        /// Получаем минор k-го порядка
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="n">Размерность матрицы</param>
        /// <returns></returns>
        private static int[,] GetMinor(int[,] matrix, int n)
        {
            // Создаём двумерный массив и задаём размерность
            int[,] result = new int[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            //Циклом for перебираем столбцы
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                //Перебираем строки
                for (int j = 0; j < n; j++)
                    result[i - 1, j] = matrix[i, j];
                //Перебираем столбцы
                for (int j = n + 1; j < matrix.GetLength(0); j++)
                    result[i - 1, j - 1] = matrix[i, j];
            }
            //Возвращаем массив
            return result;
        }
        #endregion

        // Скрытые поля
        private int n;
        private int[,] mass;

        // Создаем конструкторы матрицы
        public Matrix() { }

        public int numberMatrix
        {
            get { return n; }
            set { if (value > 0) n = value; }
        }

        // Задаем аксессоры для работы с полями вне класса Matrix
        public Matrix(int n)
        {
            this.n = n;
            mass = new int[this.n, this.n];
        }

        public int this[int i, int j]
        {
            get
            {
                return mass[i, j];
            }
            set
            {
                mass[i, j] = value;
            }
        }

        #region Write Matrix
        /// <summary>
        /// Ввод матрицы с клавиатуры
        /// </summary>
        public void WriteMatrix()
        {
            try
            {
                Console.WriteLine("\tКакой способ заполнения вы хотите?");
                Console.WriteLine("\t1 - Случайные числа");
                Console.WriteLine("\t2 - Ввод с клавиатуры");
                Console.WriteLine("\t3 - Матрица записывается в файл (../bin/netcore3.1/text.txt)", Environment.NewLine);
                Console.Write("\tВаше действие: ");
                // Проверка на валидность числа
                int choice = ValidateNumber();
                // Проверка на отрицательность
                choice = NumberLessThanZeroOrNot(choice);
                //Массив строк
                string[] str_arr;
                // Случайные цифры
                if (choice == 1)
                {
                    // Циклом for перебираем строки
                    for (int i = 0; i < n; i++)
                        //Циклом for перебираем столбцы от -10 до 50
                        for (int j = 0; j < n; j++)
                            mass[i, j] = rnd.Next(-10, 50);
                }
                // Ввод с клавиатуры
                else if (choice == 2)
                {
                    // Примечание
                    Console.WriteLine("\tПри неправильном вводе , вместо буквы или цифры присваивается ноль!");
                    Console.WriteLine("\tВведите ваши цифры через пробел..");
                    //Перебираем строки массива
                    for (int i = 0; i < n; ++i)
                    {
                        Console.Write("\t");
                        //Ввод с клавиатуры через пробел
                        str_arr = (Console.ReadLine()).Split(' ');
                        //Перебираем стобцы массива
                        for (int j = 0; j < n; j++)
                            int.TryParse(str_arr[j], out mass[i, j]);
                    }
                }
                //Запись матрицы в файл
                else if (choice == 3)
                {
                    //Примечание
                    Console.WriteLine("\tПри неправильном вводе , вместо буквы или цифры присваивается ноль!");
                    Console.WriteLine("\tВведите ваши цифры через пробел..");
                    //Перебираем строки
                    for (int i = 0; i < n; ++i)
                    {
                        Console.Write("\t");
                        //Записываем через пробел в массив
                        str_arr = (Console.ReadLine()).Split(' ');
                        //Перебор столбца
                        for (int j = 0; j < n; j++)
                            //Проверка трайпарсом и присваиваем в массив
                            int.TryParse(str_arr[j], out mass[i, j]);
                    }
                    //Запись матрицы в файл
                    FileMatrix(mass);
                }
                else
                {
                    Console.WriteLine("\t────────────────────────────────────────");
                    Console.WriteLine("\t Incorrect input ");
                    Console.Clear();
                    WriteMatrix();
                }


            }
            catch (Exception)
            {
                Console.WriteLine("\t────────────────────────────────────────");
                Console.WriteLine($"\t Неправильный ввод, попробуйте ещё раз!");
                Console.ReadKey();
                Console.Clear();
                return;
            }
        }
        #endregion

        #region Output Matrix
        /// <summary>
        /// Вывод матрицы с клавиатуры
        /// </summary>
        public void OutputMatrix()
        {
            try
            {
                //Перебор строки массива
                for (int i = 0; i < n; i++)
                {
                    //Перебор столбца массива
                    Console.Write("\t");
                    for (int j = 0; j < n; j++)
                        Console.Write("{0} ", mass[i, j]);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t────────────────────────────────────────");
                Console.WriteLine("\tУбираю не нужные цифры и буквы...", Environment.NewLine);
                Console.WriteLine($"\t{ex.GetType()} , {ex.Message}", Environment.NewLine);
            }
        }
        #endregion

        #region MultiplyNumberToMatrix
        // Умножение матрицы А на число
        public static Matrix MultiplicationNumToMatrix(Matrix a, int ch)
        {
            //Создаём класс и объект
            Matrix multiplicationNum = new Matrix(a.numberMatrix);
            try
            {
                //перебор строки и столбца
                for (int i = 0; i < a.numberMatrix; i++)
                    for (int j = 0; j < a.numberMatrix; j++)
                        multiplicationNum[i, j] = a[i, j] * ch;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t────────────────────────────────────────");
                Console.WriteLine("\tУбираю не нужные цифры и буквы...", Environment.NewLine);
                Console.WriteLine($"\t{ex.GetType()} , {ex.Message}", Environment.NewLine);
            }
            return multiplicationNum;
        }
        #endregion

        #region Diagonal Calculus
        /// <summary>
        /// Сумма диагональной матрицы
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int DiagonalMatrixCalculus(Matrix a)
        {
            //Создаём класс и объект
            Matrix diagonalMatrix = new Matrix(a.numberMatrix);
            int sumOfDiagonalMatrix = 0;
            try
            {
                //Суммирование массива
                for (int i = 0; i < a.numberMatrix; i++)
                    sumOfDiagonalMatrix += a[i, i];
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t────────────────────────────────────────");
                Console.WriteLine("\tУбираю не нужные цифры и буквы...", Environment.NewLine);
                Console.WriteLine($"\t{ex.GetType()} , {ex.Message}", Environment.NewLine);
            }
            return sumOfDiagonalMatrix;
        }
        #endregion

        #region Multiply Matrixes
        // Умножение матрицы А на матрицу Б
        public static Matrix MultiplyMatrixes(Matrix a, Matrix b)
        {
            //Создаём класс и объект
            Matrix multiplicationResult = new Matrix(a.numberMatrix);
            try
            {
                // Перебор строки и столбца 
                for (int i = 0; i < a.numberMatrix; i++)
                    for (int j = 0; j < b.numberMatrix; j++)
                        for (int k = 0; k < b.numberMatrix; k++)
                            //Умножение матрицы
                            multiplicationResult[i, j] += a[i, k] * b[k, j];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t{ex.GetType()} , {ex.Message}");
            }
            //Возвращение матрицы
            return multiplicationResult;
        }
        #endregion

        // перегрузка оператора умножения
        public static Matrix operator *(Matrix a, Matrix b)
        {
            return MultiplyMatrixes(a, b);
        }

        public static Matrix operator *(Matrix a, int b)
        {
            return MultiplicationNumToMatrix(a, b);
        }

        #region Substraction Matrixes
        /// <summary>
        /// Вычитание матрицы
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Matrix Substraction(Matrix a, Matrix b)
        {
            //Создаём класс и объект
            Matrix substractionMatrix = new Matrix(a.numberMatrix);
            try
            {
                //Перебор строки и столбца
                for (int i = 0; i < a.numberMatrix; i++)
                    for (int j = 0; j < b.numberMatrix; j++)
                        substractionMatrix[i, j] = a[i, j] - b[i, j];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t{ex.GetType()} , {ex.Message}");
            }
            //Возвращение матрицы
            return substractionMatrix;
        }
        #endregion

        // Перегрузка оператора вычитания
        public static Matrix operator -(Matrix a, Matrix b)
        {
            return Matrix.Substraction(a, b);
        }

        public static Matrix Sum(Matrix a, Matrix b)
        {
            Matrix sumOfMatrix = new Matrix(a.numberMatrix);
            try
            {
                for (int i = 0; i < a.numberMatrix; i++)
                    for (int j = 0; j < b.numberMatrix; j++)
                        sumOfMatrix[i, j] = a[i, j] + b[i, j];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t{ex.GetType()} , {ex.Message}");
            }
            return sumOfMatrix;
        }

        // Перегрузка сложения
        public static Matrix operator +(Matrix a, Matrix b)
        {
            return Matrix.Sum(a, b);
        }
        // Деструктор Matrix
        ~Matrix()
        {

        }

        #region DimensionOfTheMatrix
        /// <summary>
        /// Размерность матрицы
        /// </summary>
        /// <returns></returns>
        static int MatrixDimension()
        {
            Console.Write("\tВведите размерность матрицы: ");
            //Проверка на валидность числа
            int numberOfMatrix = ValidateNumber();
            //Число меньше нуля или нет
            numberOfMatrix = NumberLessThanZeroOrNot(numberOfMatrix);
            Console.Clear();
            //Возвращение значения
            return numberOfMatrix;

        }
        #endregion

        #region SumOfMatrixes
        static void SumOfMatrices()
        {
            //Присваиваем переменные
            int dimension;
            dimension = MatrixDimension();
            // Создаём классы и ообъекты
            Matrix result = new Matrix(dimension);
            Matrix firstArrayA = new Matrix(dimension);
            Matrix secondArrayB = new Matrix(dimension);

            Console.WriteLine("\t──────────────────{Сумма двух матриц}──────────────────");
            Console.WriteLine("\tРазмерность матрицы {0}", dimension);
            Console.WriteLine("\tВведите матрицу А:");
            //Пишем матрицу
            firstArrayA.WriteMatrix();
            Console.Clear();
            Console.WriteLine("\t──────────────────{Сумма двух матриц}──────────────────");
            Console.WriteLine("\tРазмерность матрицы {0}", dimension);
            Console.WriteLine("\tВведите матрицу B:");
            //Пишем вторую матрицу
            secondArrayB.WriteMatrix();

            Console.Clear();
            Console.WriteLine("──────────────────{Сумма двух матриц}──────────────────");
            Console.WriteLine("\tИсходная Матрица A:");
            //Выводим матрицу
            firstArrayA.OutputMatrix();
            Console.WriteLine("\tИсходная Матрица B:");
            // Выводим вторую матрицу
            secondArrayB.OutputMatrix();

            Console.WriteLine("\tСложение матрицы A и B: ");
            //Сложение двух матриц
            result = (firstArrayA + secondArrayB);
            //Вывод сложения
            result.OutputMatrix();
        }
        #endregion

        #region SubstractionOfMatrixes
        /// <summary>
        /// Вычитание матрицы
        /// </summary>
        static void SubstractionOfMatrices()
        {
            int dimension;
            //Создание класса и объекта
            dimension = MatrixDimension();
            //Создание класса и объекта
            Matrix result = new Matrix(dimension);
            Matrix firstArrayA = new Matrix(dimension);
            Matrix secondArrayB = new Matrix(dimension);
            // Запись матрицы
            Console.WriteLine("\t──────────────────{Разность двух матриц}──────────────────");
            Console.WriteLine("\tРазмерность матрицы {0}", dimension);
            Console.WriteLine("\tВведите матрицу А:");
            //Записываем матрицу
            firstArrayA.WriteMatrix();
            Console.Clear();
            //Запись матрицы
            Console.WriteLine("\t──────────────────{Разность двух матриц}──────────────────");
            Console.WriteLine("\tРазмерность матрицы {0}", dimension);
            Console.WriteLine("\tВведите матрицу B:");
            //Записываем вторую матрицу
            secondArrayB.WriteMatrix();

            Console.Clear();
            Console.WriteLine("\t──────────────────{Разность двух матриц}──────────────────");
            Console.WriteLine("\tИсходная Матрица A:");
            // Вывод матрицы
            firstArrayA.OutputMatrix();
            Console.WriteLine("\tИсходная Матрица B:");
            // Вывод матрицы
            secondArrayB.OutputMatrix();

            Console.WriteLine("\tВычитание матрицы A и B: ");
            // Вычитание двух матриц
            result = (firstArrayA - secondArrayB);
            // Вывод вычитания
            result.OutputMatrix();
        }
        #endregion

        #region MultiplyTwoMatrixes
        /// <summary>
        /// Умножение двух матриц
        /// </summary>
        static void MultiplyMatrices()
        {
            //Присваиваем переменные
            int dimension;
            dimension = MatrixDimension();
            // Создаём класс и объекты
            Matrix result = new Matrix(dimension);
            Matrix firstArrayA = new Matrix(dimension);
            Matrix secondArrayB = new Matrix(dimension);

            //Запись 
            Console.WriteLine("\t──────────────────{Произведение двух матриц}──────────────────");
            Console.WriteLine("\tРазмерность матрицы {0}", dimension);
            Console.WriteLine("\tВведите матрицу А:");
            // Запись матрицы
            firstArrayA.WriteMatrix();
            Console.Clear();
            Console.WriteLine("\t──────────────────{Произведение двух матриц}──────────────────");
            Console.WriteLine("\tРазмерность матрицы {0}", dimension);
            Console.WriteLine("\tВведите матрицу B:");
            // Записываем матрицу
            secondArrayB.WriteMatrix();

            Console.Clear();
            Console.WriteLine("\t──────────────────{Произведение двух матриц}──────────────────");
            Console.WriteLine("\tИсходная Матрица A:");
            //Вывод матрицы
            firstArrayA.OutputMatrix();
            Console.WriteLine("\tИсходная Матрица B:");
            // Вывод второй матрицы
            secondArrayB.OutputMatrix();

            Console.WriteLine("\tУмножение матрицы A и B: ");
            // Умножение матрицы А и B
            result = (firstArrayA * secondArrayB);
            // Вывод матрицы
            result.OutputMatrix();
        }
        #endregion

        #region MultiplyMatrixToNumber
        /// <summary>
        /// Произведение матрицы на число
        /// </summary>
        static void MultiplyNumberToMatrix()
        {
            // Присваиваем переменные
            int dimension, number;
            dimension = MatrixDimension();
            //Создаём объект и класс
            Matrix firstArrayA = new Matrix(dimension);
            Matrix result = new Matrix(dimension);

            Console.WriteLine("\t────────────────{Произведение матриц на число}────────────────");
            Console.WriteLine("\tРазмерность матрицы {0}", dimension);
            Console.WriteLine("\tВведите матрицу А:");
            // Запись матрицы
            firstArrayA.WriteMatrix();
            Console.Write("\tВведите число для умножения:");
            // Валидация числа
            number = ValidateNumber();
            Console.Clear();
            Console.WriteLine("\t────────────────{Произведение матриц на число}────────────────");
            Console.WriteLine("\tИсходная Матрица A:");
            // Вывод Исходной матрицы
            firstArrayA.OutputMatrix();
            Console.WriteLine($"\tУмножение матрицы A к числу {number}: ");
            // Вывод умноженной матрицы на число
            result = (firstArrayA * number);
            // Выводим результат
            result.OutputMatrix();
        }
        #endregion

        #region GaussInput
        /// <summary>
        /// Запись Гаусса
        /// </summary>
        static void GaussInput()
        {
            try
            {
                //Создаём переменную и присваиваем
                int dimension;
                dimension = MatrixDimension();
                //Создаём объект и класс
                Matrix firstArrayA = new Matrix(dimension);
                //Создаём массив
                double[,] x;
                Console.WriteLine();
                Console.WriteLine("\t──────────────────{Метод Гаусса}──────────────────");
                Console.WriteLine("\tМатрица принимает целочисленные значения!");
                Console.WriteLine($"\tРазмерность квадратной матрицы: {dimension}");
                Console.WriteLine("\tВведите матрицу A:");
                //Запись матрицы
                firstArrayA.WriteMatrix();
                //Создаём ещё одну матрицу полученную из firstArrayA
                double[,] arr = new double[firstArrayA.numberMatrix, firstArrayA.numberMatrix];
                //Перебором строки соединяем в другой массив
                for (int i = 0; i < arr.GetLength(1); i++)
                {
                    //Перебором столбца соединяем в другой массив
                    for (int j = 0; j < arr.GetLength(0); j++)
                    {
                        // Просто присваиваем i-строку и j-столбец в другой массив
                        arr[i, j] = firstArrayA[i, j];
                    }
                }
                // Вывод результата
                GaussMethod(arr, dimension, out x);
            }
            catch (Exception)
            {
                Console.WriteLine("\tПовторите ещё раз");
                Console.Clear();
                GaussInput();
            }
        }
        #endregion

        #region GaussMethod
        /// <summary>
        /// Привидение к каноническому виду
        /// </summary>
        /// <param name="matrix">Сама матрица</param>
        /// <param name="n">Размерность</param>
        /// <param name="x">результат вектора X</param>
        public static void GaussMethod(double[,] matrix, int n, out double[,] x)
        {
            //Объявляем переменные:
            int i;//Переменная, номер строки.
            int j;//Переменная, номер столбца.
            int m;//Размерность системы (учитываем вектор-расширение матрицы).

            m = n + 1;

            int k;
            int firstElementOfMatrix;//Переменная номер строки с ведущим элементом.
            double o = 0;//Перемнная для поиска самого большого по модулю элемента в матрице. 
            double p = 0;//Перемнная для поиска самого большого по модулю элемента в матрице.
            double tmp = 0;//Временная перемнная для прямого хода метода Гаусса.
            x = new double[n, n];
            try
            {
                Console.WriteLine();
                Console.WriteLine("\tИсходная Матрица: ");
                for (i = 0; i < matrix.GetLength(1); i++)
                {
                    Console.Write("\t");
                    for (j = 0; j < matrix.GetLength(0); j++)
                    {
                        Console.Write("{0} ", matrix[i, j]);

                    }
                    Console.WriteLine();
                }
                for (k = 0; k < n; k++)
                {
                    //Поиск ведущего элемента:
                    p = 0;
                    firstElementOfMatrix = k;
                    for (i = k; i < n; i++)
                    {
                        o = Math.Abs(matrix[i, k]);
                        if (Math.Abs(o) > Math.Abs(p))
                        {
                            p = Math.Abs(o);//Нашли значение самого большого элемента.
                            firstElementOfMatrix = i;//Нашли номер строки с самым большим по модулю элементом (ведущим элементом).
                        }
                    }

                    //Перестановка строк:
                    if (firstElementOfMatrix != k)
                        for (i = k; i < n; i++)
                        {
                            double tmp_line = 0;//Временная переменная для перестановки строк местами.
                            tmp_line = matrix[firstElementOfMatrix, i];
                            matrix[firstElementOfMatrix, i] = matrix[k, i];
                            matrix[k, i] = tmp_line;
                        }
                    //Прямой ход, приведение к верхнетреугольному виду:

                    tmp = matrix[k, k];//Первый элемент в текущей матрице.

                    if (tmp != 0)
                    {
                        for (j = k; j < n; j++)//Нормализация.
                            matrix[k, j] = matrix[k, j] / tmp;
                        for (i = k + 1; i < n; i++)
                        {
                            tmp = matrix[i, k];//Главный элемент.
                            for (j = k; j < n; j++)//Из следующей строки вычитаем первую, умноженную на главный элемент.
                                matrix[i, j] = matrix[i, j] - tmp * matrix[k, j];
                        }
                    }
                }
                //Обратный ход:
                for (k = n - 1; k >= 0; k--)
                    for (i = 0; i < k; i++)
                    {
                        tmp = matrix[i, k];//Множитель.
                        for (j = k; j < n; j++)//Из следующей строки вычитаем первую, умноженную на главный элемент.
                            matrix[i, j] = matrix[i, j] - tmp * matrix[k, j];
                    }
                bool hasZeroElement = false;//Переменная, которая обозначает, что в строке есть ненулевой элемент.
                bool matixCanSolve = false;//Переменная, которая обозначает, что система не имеет решений.
                bool hasInfiniteSolve = false;//Переменная, которая обозначает, что система имеет бесконечное множество решений.

                for (k = 0; k < n; k++)
                {
                    if (matrix[k, k] == 0)//Если на диагонали 0, значит проверяем строку.
                    {
                        hasZeroElement = false;//Обнуляем переменную.
                        for (j = k; j < n; j++)
                            if (matrix[k, j] != 0)//Если в строке есть ненулевой элемент значит обозначим это через флаг.
                                hasZeroElement = true;
                        if (!hasZeroElement)//Если в строке все нули, то проверям свободный член.
                        {
                            if (matrix[k, n] != 0)//Если не равно нулю, то решений нет.
                                matixCanSolve = true;
                            else//А иначе данное уравнение решается всегда.
                                hasInfiniteSolve = true;
                        }
                    }
                }
                //Выводим решения
                if (matixCanSolve == true)
                {
                }
                else
                {
                    if (hasInfiniteSolve == true)
                    { }
                    else
                        for (i = 0; i < n; i++)
                            x[i, i] = matrix[i, i];
                }
                Console.WriteLine();
                Console.WriteLine("\tПривидение к каноническому виду: ");
                for (i = 0; i < x.GetLength(1); i++)
                {
                    Console.Write("\t");
                    for (j = 0; j < x.GetLength(0); j++)
                    {
                        Console.Write("{0} ", x[i, j]);

                    }
                    Console.WriteLine();
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("\tЯ не смог решить данную матрицу, дайте другую :(");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\t{ex.Message}");
                Console.ReadKey();
                Console.Clear();
                GaussInput();
            }
        }
        #endregion

        #region DeterminantInput
        static void Determinant()
        {
            //Создаём переменную и присваиваем размерность
            int dimension;
            dimension = MatrixDimension();
            //Создаём классы и объекты
            Matrix firstArrayA = new Matrix(dimension);
            Matrix result = new Matrix(dimension);

            Console.WriteLine("\t──────────────────{Определитель Матрицы}──────────────────");
            Console.WriteLine($"\tРазмерность матрицы: {dimension}");
            Console.WriteLine("\tВведите матрицу A:");
            //Записываем матрицу в firstArrayA
            firstArrayA.WriteMatrix();
            //Создаём массив двумерный nxn
            int[,] arr = new int[firstArrayA.numberMatrix, firstArrayA.numberMatrix];
            //Перебором массива присваиваем к другому
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                //Переьираем столбцы и присваем к другому
                Console.Write("\t");
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    arr[i, j] = firstArrayA[i, j];
                }
            }
            //Результат опеределителя
            Console.WriteLine("");
            Console.Write("\tОпределитель матрицы равен: ");
            Console.WriteLine(DeterminantRecursion(arr));
        }
        #endregion

        #region MenuOfInstructions
        /// <summary>
        /// Просто меню , я устал писать комментарии
        /// </summary>
        static void Menu()
        {
            Console.WriteLine("\t══════════════════════╗╔═══════════════════", Environment.NewLine);
            Console.WriteLine("\tКалькулятор матриц умеет:");
            Console.WriteLine("\t1 - Находить сумму диагонали квадратной матрицы");
            Console.WriteLine("\t2 - Транспонирование матрицы");
            Console.WriteLine("\t3 - Cумма двух матриц");
            Console.WriteLine("\t4 - Разность двух матриц");
            Console.WriteLine("\t5 - Произведение двух матриц");
            Console.WriteLine("\t6 - Умножение матрицы на число");
            Console.WriteLine("\t7 - Нахождение определителя матрицы");
            Console.WriteLine("\t8 - Решение методом Гаусса");
            Console.WriteLine("\t9 - Справка");
            Console.WriteLine("\t10 - Выйти ");
            Console.WriteLine("\t──────────────────         ──────────────────", Environment.NewLine);
        }
        #endregion

        //ТОЧКА ВХОДА , НАЧАЛО ВСЕХ ОПЕРАЦИЙ
        static void Main(string[] args)
        {
            //Присваиваем булевское значение для while , чтобы сделать цикл который выключится после изменения параметров
            bool exit = false;
            while (!exit)
            {
                //Соответственно меняем цвет текста
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                //Проверка на валидность
                int choice;
                do
                {
                    Console.Clear();
                    //Выводим меню
                    Menu();
                    Console.Write("\tВаше действие: ");
                } while (!int.TryParse(Console.ReadLine(), out choice) && choice < 1 && choice > 10);
                int dimension;
                //Сумма диагональной квадратной матрицы
                if (choice == 1)
                {
                    //Присваиваем размерность и создаём класс и объект
                    dimension = MatrixDimension();
                    Matrix firstArrayA = new Matrix(dimension);

                    Console.WriteLine("\t──────────────────{Сумма диагонали}──────────────────");
                    Console.WriteLine("\tРазмерность квадратной матрицы {0}", dimension);
                    Console.WriteLine("\tВведите матрицу А:");
                    //Запись матрицы
                    firstArrayA.WriteMatrix();
                    Console.Clear();
                    Console.WriteLine("\t──────────────────{Сумма диагонали}──────────────────");
                    Console.WriteLine("\tИсходная Матрица:");
                    //Вывод исходной матрицы
                    firstArrayA.OutputMatrix();
                    Console.Write("\tСумма диагональной квадратной матрицы: ");
                    //Результат суммы
                    Console.WriteLine(DiagonalMatrixCalculus(firstArrayA));
                    Console.ReadLine();

                }
                else if (choice == 2)
                {
                    //Транспонирование
                    Transposition();
                    Console.WriteLine("\tНажмите любую клавишу для продолжения..");
                    Console.ReadKey();
                }
                else if (choice == 3)
                {
                    //Сумма матрицы
                    SumOfMatrices();
                    Console.WriteLine("\tНажмите любую клавишу для продолжения..");
                    Console.ReadKey();
                }
                else if (choice == 4)
                {
                    //Вычитание матрицы
                    SubstractionOfMatrices();
                    Console.WriteLine("\tНажмите любую клавишу для продолжения..");
                    Console.ReadKey();
                }
                else if (choice == 5)
                {
                    //Умножение матрицы
                    MultiplyMatrices();
                    Console.WriteLine("\tНажмите любую клавишу для продолжения..");
                    Console.ReadKey();
                }
                else if (choice == 6)
                {
                    //Умножение матрицы на число
                    MultiplyNumberToMatrix();
                    Console.WriteLine("\tНажмите любую клавишу для продолжения..");
                    Console.ReadKey();
                }
                else if (choice == 7)
                {
                    //Нахождение определителя
                    Determinant();
                    Console.WriteLine("\tНажмите любую клавишу для продолжения..");
                    Console.ReadKey();

                }
                else if (choice == 8)
                {
                    //Метод Гаусса
                    GaussInput();
                    Console.ReadKey();
                }
                else if (choice == 9)
                {
                    Console.Clear();
                    Console.WriteLine("\t────────────────────────         ────────────────────────", Environment.NewLine);
                    Console.WriteLine("\t\tВнимание!");
                    Console.WriteLine("\t1) Матрица только считывает целочисленные значения");
                    Console.WriteLine("\t2) При неправильном вводе данных вместо этого элемента идёт замена на ноль");
                    Console.WriteLine("\t3) Метод Гаусса он работает , просто немного заболел, он не может решить прям сложные задачи");
                    Console.WriteLine("\t4) ИЗНАЧАЛЬНО чтобы записать матрицу в текст , вы просто пишите через консоль и через него программа");
                    Console.WriteLine("\t будет предлагать вычисление");
                    Console.WriteLine("\t5) Точки отсутствуют в конце комментария");
                    Console.WriteLine("\t6) Спасибо за тест программы и оценки, буду рад за пояснения и советы, чтобы улучшить код.");
                    Console.WriteLine("\t────────────────────────         ────────────────────────", Environment.NewLine);
                    Console.Write("\tНажмите любую клавишу, чтобы продолжить");
                    Console.ReadKey();
                }
                else if (choice == 10)
                {
                    //Ну это До свидания
                    exit = true;
                    Console.WriteLine("\t───────────────────{Пока :( }──────────────────── ");
                    Console.ResetColor();
                    return;
                }
                else
                {
                    //Ну если ты неправильно написал, выводится такое сообщение
                    Console.WriteLine("\tIncorrect input");
                    exit = false;
                }

            }

        }

    }
}

