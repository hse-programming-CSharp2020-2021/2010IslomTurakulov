using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinForm1
{
    using System.Collections.Generic;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;

    public partial class SerpinskiyForm : System.Windows.Forms.Form
    {

        private int Level;
        //Высота и ширина для отрисовки
        private int _width;
        private int _height;
        // Bitmap для фрактала
        private Bitmap _fractal;
        // используем для отрисовки на PictureBox
        private Graphics _graph;
        private LinearGradientBrush changeColor;
        public SerpinskiyForm()
        {
            InitializeComponent();
            //инициализируем ширину и высоту
            _width = Screen.PrimaryScreen.WorkingArea.Width;
            _height = Screen.PrimaryScreen.WorkingArea.Height;
            ClientSize = new System.Drawing.Size(_width, _height);
            ResizeRedraw = true;
        }

        private void TriangleButton(object sender, EventArgs e)
        {
            //создаем Bitmap для треугольника
            _fractal = new Bitmap(ClientSize.Width, ClientSize.Height);
            // cоздаем новый объект Graphics из указанного Bitmap
            _graph = Graphics.FromImage(_fractal);
            //вершины треугольника
            PointF topPoint = new PointF(ClientSize.Width / 2, 0);
            PointF leftPoint = new PointF(0, ClientSize.Height);
            PointF rightPoint = new PointF(ClientSize.Width, ClientSize.Height);
            //вызываем функцию отрисовки
            DrawTriangle(Level, topPoint, leftPoint, rightPoint);
            //отображаем получившийся фрактал
            FractalPictureBox.BackgroundImage = _fractal;
        }

        private void CarpetButton(object sender, EventArgs e)
        {
            //создаем Bitmap для прямоугольника
            _fractal = new Bitmap(ClientSize.Width, ClientSize.Height);
            // cоздаем новый объект Graphics из указанного Bitmap
            _graph = Graphics.FromImage(_fractal);
            //создаем прямоугольник и вызываем функцию отрисовки ковра
            RectangleF carpet = new RectangleF(0, 0, ClientSize.Width, ClientSize.Height);
            changeColor = new LinearGradientBrush(carpet, this.dlgColor.Color, Color.MediumVioletRed, LinearGradientMode.Horizontal);
            DrawCarpet(Level, carpet);
            //отображаем результат
            FractalPictureBox.BackgroundImage = _fractal;
        }
        private void DrawTriangle(int level, PointF top, PointF left, PointF right)
        {
            //проверяем, закончили ли мы построение
            if (level == 0)
            {
                PointF[] points = new PointF[3]
                {
                    top, right, left
                };
                changeColor = new LinearGradientBrush(top, right, this.dlgColor.Color, Color.Green);
                _graph.FillPolygon(changeColor, points);
            }
            else
            {
                //вычисляем среднюю точку
                var leftMid = MidPoint(top, left); //левая сторона
                var rightMid = MidPoint(top, right); //правая сторона
                var topMid = MidPoint(left, right); // основание
                //рекурсивно вызываем функцию для каждого и 3 треугольников
                DrawTriangle(level - 1, top, leftMid, rightMid);
                DrawTriangle(level - 1, leftMid, left, topMid);
                DrawTriangle(level - 1, rightMid, topMid, right);
            }
        }

        //функция вычисления координат средней точки
        private PointF MidPoint(PointF p1, PointF p2)
        {
            return new PointF((p1.X + p2.X) / 2f, (p1.Y + p2.Y) / 2f);
        }

        private void DrawCarpet(int level, RectangleF carpet)
        {
            //проверяем, закончили ли мы построение
            if (level == 0)
            {
                //Рисуем прямоугольник
                _graph.FillRectangle(this.changeColor,carpet);
            }
            else
            {
                // делим прямоугольник на 9 частей
                var width = carpet.Width / 3f;
                var height = carpet.Height / 3f;
                // (x1, y1) - координаты левой верхней вершины прямоугольника
                // от нее будем отсчитывать остальные вершины маленьких прямоугольников
                var x1 = carpet.Left;
                var x2 = x1 + width;
                var x3 = x1 + 2f * width;

                var y1 = carpet.Top;
                var y2 = y1 + height;
                var y3 = y1 + 2f * height;

                DrawCarpet(level - 1, new RectangleF(x1, y1, width, height)); // левый 1(верхний)
                DrawCarpet(level - 1, new RectangleF(x2, y1, width, height)); // средний 1
                DrawCarpet(level - 1, new RectangleF(x3, y1, width, height)); // правый 1
                DrawCarpet(level - 1, new RectangleF(x1, y2, width, height)); // левый 2
                DrawCarpet(level - 1, new RectangleF(x3, y2, width, height)); // правый 2
                DrawCarpet(level - 1, new RectangleF(x1, y3, width, height)); // левый 3
                DrawCarpet(level - 1, new RectangleF(x2, y3, width, height)); // средний 3
                DrawCarpet(level - 1, new RectangleF(x3, y3, width, height)); // правый 3
            }
        }

        private void AddIteration_Click(object sender, EventArgs e)
        {
            if (this.Level >= 10)
                MessageBox.Show("Максимальная итерация это 10!");
            else
            {
                ++Level;
                this.Iteration.Text = $"Итерации: {Level}";
                this.Invalidate();
            }
        }
        private void SetFractalColor(Control panel)
        {
            if (this.dlgColor.ShowDialog() == DialogResult.Cancel)
                return;
            // установка цвета формы
            this.BackColor = this.dlgColor.Color;
        }
        /// <summary>
        /// Показывает панель выбора цветов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorOptionGet(object sender, EventArgs e)
        {
            this.dlgColor.ShowDialog();
        }

        /// <summary>
        /// Возвращаем в дефолтное значение.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetAll(object sender, EventArgs e)
        {
            this.Level = 0;
            this.Reset.Text = "Успешно!";
        }

        private void dlgSaveFile_Click(object sender, EventArgs e)
        {
            if (this.dlgSave.ShowDialog() == DialogResult.OK)
            {
                _fractal.Save(this.dlgSave.FileName);
                string filename = this.dlgSave.FileName;
                string extension = filename.Substring(filename.LastIndexOf("."));
                switch (extension)
                {
                    case ".bmp":
                        _fractal.Save(filename, ImageFormat.Bmp);
                        break;
                    case ".":
                    case ".jpg":
                    case ".jpeg":
                        _fractal.Save(filename, ImageFormat.Jpeg);
                        break;
                    case ".gif":
                        _fractal.Save(filename, ImageFormat.Gif);
                        break;
                    case ".png":
                        _fractal.Save(filename, ImageFormat.Png);
                        break;
                    case ".tif":
                    case ".tiff":
                        _fractal.Save(filename, ImageFormat.Tiff);
                        break;
                }
            }
        }
    }
}
