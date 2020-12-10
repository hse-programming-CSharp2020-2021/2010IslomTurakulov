using System;

namespace MyLib
{
    public class Matrix
    {
        int[,] matrix;

        public void MatrPrint()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write($"{matrix[i, j]} ");
                Console.WriteLine();
            }
        }
        public Matrix UnitMatr(int n)
        {// Сформировать единичную матрицу:
            if (n <= 0)
                throw new ArgumentOutOfRangeException("Аргумент метода должен быть положительным!");
            matrix = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matrix[i, j] = (i == j ? 1 : 0);
            return this;
        }
    }
}
