using System;

namespace CW3
{
    class Program
    {
        /// <summary>
        /// вычисляющий логическое значение функции G=F(X,Y). Результат равен true, 
        /// если точка с координатами (X,Y) попадает в фигуру G, и результат равен false, 
        /// если точка с координатами (X,Y) не попадает в фигуру G. 
        /// </summary>
        /// <param name="x">Координат X</param>
        /// <param name="y">Координат Y</param>
        /// <returns></returns>
        static bool RadiusCheckerF(double x, double y)
        {
            // используя метод Math.Atan2 () &

            // преобразование результата в градус
            double radians = Math.Atan2(x,y);
            //double overallRadians = radians * (180 / Math.PI);
            return (Math.Pow(x,2) + Math.Pow(y,2) <= 4 && Math.PI * -0.5 <= radians  && radians <= Math.PI * 0.25);
            // Проверяет 1 и 4 квадрант , от 45 до -90 градусов
            // Если значение входит в G, то выносит True, а если нет , то False
        }
        static void Main(string[] args)
        {
            double x, y;
            do
            {
                Console.Clear();

                Console.Write("Введите значение функции x: ");
                if (!double.TryParse(Console.ReadLine(), out x))
                    Console.WriteLine("Incorrect input");
                Console.Write("Введите значение функции y: ");
                if (!double.TryParse(Console.ReadLine(), out y))
                    Console.WriteLine("Incorrect input");

                Console.WriteLine($"Ответ: {RadiusCheckerF(x, y)}");
                Console.WriteLine("Нажмите на ESC, чтобы выйти");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
