using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinForm1
{
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;

    public partial class JuliaForm : System.Windows.Forms.Form
    {
        // Выдаю переменные Битмап и Графики а также для увеличения фрактала
        public Bitmap MBm;
        private int zoom;

        //Определяем после какого числа итераций функция должна прекратить свою работу
        private int maxIterations = 20;
        public JuliaForm()
        {
            InitializeComponent();
            int x = Screen.PrimaryScreen.WorkingArea.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Height;
            this.zoom = 1;
            ClientSize = new Size(x, y);
        }

        public void DrawFractal(int w, int h, Graphics g, Pen pen)
        {
            // вещественная  и мнимая части постоянной C
            double cRe, cIm;
            // вещественная и мнимая части старой и новой
            double newRe, newIm, oldRe, oldIm;
            // Можно увеличивать и изменять положение
            double moveX = 0, moveY = 0;
            //выбираем несколько значений константы С, это определяет форму фрактала Жюлиа
            cRe = -0.70176;
            cIm = -0.3842;

            //"перебираем" каждый пиксель
            for (int x = 0; x < w; x++)
                for (int y = 0; y < h; y++)
                {
                    //вычисляется реальная и мнимая части числа z
                    //на основе расположения пикселей,масштабирования и значения позиции
                    newRe = 1.5 * (x - w / 2) / (0.5 * zoom * w) + moveX;
                    newIm = (y - h / 2) / (0.5 * zoom * h) + moveY;

                    //i представляет собой число итераций 
                    int i;

                    //начинается процесс итерации
                    for (i = 0; i < maxIterations; i++)
                    {

                        //Запоминаем значение предыдущей итерации
                        oldRe = newRe;
                        oldIm = newIm;

                        // в текущей итерации вычисляются действительная и мнимая части 
                        newRe = oldRe * oldRe - oldIm * oldIm + cRe;
                        newIm = 2 * oldRe * oldIm + cIm;

                        // если точка находится вне круга с радиусом 2 - прерываемся
                        if ((newRe * newRe + newIm * newIm) > 4) break;
                    }

                    pen.Color = Color.FromArgb(255, (i * 9) % 255, 0, (i * 9) % 255);
                    //рисуем пиксель
                    g.DrawRectangle(pen, x, y, 1, 1);

                }
        }

        private void menuStrip1_ItemClicked(object sender, EventArgs e)
        {
            //Выбираем перо "myPen" черного цвета Black
            //толщиной в 1 пиксель:
            LinearGradientBrush lgb = new LinearGradientBrush(this.ClientRectangle, Color.Black , Color.Blue, LinearGradientMode.Horizontal);
            Pen myPen = new Pen(lgb, 1);
            //Объявляем объект "gpPythagoras" класса Graphics и предоставляем
            //ему возможность рисования на pictureBox1:
            this.MBm = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            Graphics g = Graphics.FromImage(this.MBm);
            this.pictureBox1.BackgroundImage = this.MBm;
            //вызываем функцию рисования фрактала
            DrawFractal(ClientSize.Width, ClientSize.Height, g, myPen);
        }

        private void IterationCount(object sender, EventArgs e)
        {
            if (this.maxIterations >= 300)
            {
                MessageBox.Show("Максимальная итерация - 300!");
            }
            else
            {
                this.maxIterations += 20;
                this.Iterations.Text = $"Итераций: {this.maxIterations} \n" + $"Макс - 300";
            }
        }

        /// <summary>
        /// Возвращает в дефолтную итерацию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetIteration(object sender, EventArgs e)
        {
            this.maxIterations = 25;
            this.Text = "Успешно!";
        }

        /// <summary>
        /// Все последующие действия увеличивают приближение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zoom_clickedx2(object sender, EventArgs e)
        {
            this.zoom += 2;
        }

        private void zoom_clickedx5(object sender, EventArgs e)
        {
            this.zoom += 5;
        }

        private void FullScreen(object sender, EventArgs e)
        {
            this.zoom = 1;
        }
        /// <summary>
        /// Панель выбора цветов
        /// </summary>
        /// <param name="panel"></param>
        private void SetFractalColor(Control panel)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            ForeColor = this.colorDialog1.Color;
        }
        /// <summary>
        /// Вызывается с меню и впередаю с ColorOption на SetFractal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorOptionGet(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();
        }
        /// <summary>
        /// Сохранение фрактала как изображение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFractal(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.MBm.Save(saveFileDialog1.FileName);
                string filename = saveFileDialog1.FileName;
                string extension = filename.Substring(filename.LastIndexOf("."));
                switch (extension)
                {
                    case ".bmp":
                        this.MBm.Save(filename, ImageFormat.Bmp);
                        break;
                    case ".jpg":
                    case ".jpeg":
                        this.MBm.Save(filename, ImageFormat.Jpeg);
                        break;
                    case ".gif":
                        this.MBm.Save(filename, ImageFormat.Gif);
                        break;
                    case ".png":
                        this.MBm.Save(filename, ImageFormat.Png);
                        break;
                    case ".tif":
                    case ".tiff":
                        this.MBm.Save(filename, ImageFormat.Tiff);
                        break;
                }
            }
        }
    }
}
