using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm1
{
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;

    public partial class Pythagoras : System.Windows.Forms.Form
    {
        public Graphics gpPythagoras; //Графика
        public Bitmap bitMapPythagoras; //Битмап
        public Pen p; //Ручка
        public double angle = Math.PI / 2; //Угол поворота на 90 градусов
        public double ang1 = Math.PI / 4;  //Угол поворота на 45 градусов
        public double ang2 = Math.PI / 6;  //Угол поворота на 30 градусов
        private int a = 0;
        public Pythagoras()
        {
            InitializeComponent();
            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            ClientSize = new Size(this.Width, this.Height);
            pictureBox1.Width = Width;
            pictureBox1.Height = Height;
            ResizeRedraw = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.bitMapPythagoras = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);//Подключаем Битмап
            this.gpPythagoras = Graphics.FromImage(this.bitMapPythagoras); //Подключаем графику
            this.gpPythagoras.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//Включаем сглаживание
            //Вызов рекурсивной функции отрисовки дерева
            //DrawTree(300, 450, a, angle);
             DrawTree(ClientSize.Width/2, ClientSize.Height/2, a, angle);
            //Переносим картинку из битмапа на picturebox	
            pictureBox1.BackgroundImage = this.bitMapPythagoras;
        }

        //Рекурсивная функция отрисовки дерева
        //x и y - координаты родительской вершины
        //a - параметр, который фиксирует количество итераций в рекурсии
        //angle - угол поворота на каждой итерации
        public int DrawTree(double x, double y, double a, double angle)
        {

            if (a > 2)
            {
                a *= 0.7; //Меняем параметр a

                //Считаем координаты для вершины-ребенка
                double xnew = Math.Round(x + a * Math.Cos(angle)),
                       ynew = Math.Round(y - a * Math.Sin(angle));
                LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, colorDialog.Color, 
                    Color.Blue, LinearGradientMode.Vertical);
                //рисуем линию между вершинами
                this.gpPythagoras.DrawLine(new Pen(lgb), (float)x, (float)y, (float)xnew, (float)ynew);
                //Переприсваеваем координаты
                x = xnew;
                y = ynew;

                //Вызываем рекурсивную функцию для левого и правого ребенка
                DrawTree(x, y, a, angle + ang1);
                DrawTree(x, y, a, angle - ang2);
            }
            return 0;
        }

        private void SetFractalColor(Control panel)
        {
            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // установка цвета формы
            this.BackColor = colorDialog.Color;
        }

        private void ColorOptionGet(object sender, EventArgs e)
        {
            this.colorDialog.ShowDialog();
        }

        private void Iterations_Click(object sender, EventArgs e)
        {
            if (this.a > 200)
                MessageBox.Show("Итерация больше 200!");
            else
            {
                a += 15;
                this.Iteration.Text = $"Итераций: {this.a}\n Макс - 200";
                this.Invalidate();
            }
        }

        /// <summary>
        /// Возвращение в дефолтное значение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetAll(object sender, EventArgs e)
        {
            this.a = 0;
            this.Invalidate();
        }

        /// <summary>
        /// Сохранение фрактала как картинку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SavePythagorasTree(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bitMapPythagoras.Save(this.saveFileDialog1.FileName);
                string filename = this.saveFileDialog1.FileName;
                string extension = filename.Substring(filename.LastIndexOf("."));
                switch (extension)
                {
                    case ".bmp":
                        bitMapPythagoras.Save(filename, ImageFormat.Bmp);
                        break;
                    case ".jpg":
                    case ".jpeg":
                        bitMapPythagoras.Save(filename, ImageFormat.Jpeg);
                        break;
                    case ".gif":
                        bitMapPythagoras.Save(filename, ImageFormat.Gif);
                        break;
                    case ".png":
                        bitMapPythagoras.Save(filename, ImageFormat.Png);
                        break;
                    case ".tif":
                    case ".tiff":
                        bitMapPythagoras.Save(filename, ImageFormat.Tiff);
                        break;
                    default:
                        MessageBox.Show("Возникла ошибка при сохранении файла!");
                        break;
                }
            }
        }
    }
}