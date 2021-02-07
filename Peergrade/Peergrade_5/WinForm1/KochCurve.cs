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

    public partial class KochCurve : System.Windows.Forms.Form
    {
        int step;

        public KochCurve()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }
        private void KochCurveDraw(int step, int x, int y, double angle, double lenght, PaintEventArgs e, int iterations)
        {
            // Присваиваю две переменные начала.
            double x1, y1;
            // Создаю ручку и график.
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(this.ColorKoch.Color,1);

            // Проверка если шаг равен 0 то делаем это.
            if (step == 0)
            {
                // Задаём переменным градус и умножаем на длину затем закидываем в DrawLine
                x1 = x + lenght * Math.Cos(angle * Math.PI * 2 / 360.0);
                y1 = y + lenght * Math.Sin(angle * Math.PI * 2 / 360.0);
                graphics.DrawLine(pen, x, y, (int)x1, (int)y1);
            }
            // А если нет, то делает это.
            else
            {
                // Первая рекурсия
                this.KochCurveDraw(step - 1, x, y, angle, lenght / 3, e, iterations);
                double x2 = x + lenght / 3 * Math.Cos(angle * Math.PI * 2 / 360.0);
                double y2 = y + lenght / 3 * Math.Sin(angle * Math.PI * 2 / 360.0);
                // Вторая рекурсия
                this.KochCurveDraw(step - 1, (int)x2, (int)y2, angle - 60, lenght / 3, e, iterations + 1);
                double x3 = x2 + lenght / 3 * Math.Cos((angle - 60) * Math.PI * 2 / 360.0);
                double y3 = y2 + lenght / 3 * Math.Sin((angle - 60) * Math.PI * 2 / 360.0);
                // Третья рекурсия , а зачем я считаю ? 
                this.KochCurveDraw(step - 1, (int)x3, (int)y3, angle + 60, lenght / 3, e, iterations + 1);
                double x4 = x3 + lenght / 3 * Math.Cos((angle + 60) * Math.PI * 2 / 360.0);
                double y4 = y3 + lenght / 3 * Math.Sin((angle + 60) * Math.PI * 2 / 360.0);
                // И последняя.
                this.KochCurveDraw(step - 1, (int)x4, (int)y4, angle, lenght / 3, e, iterations);
            }

        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Через OnPaintBackground присваиваю значение count
            int count = 0;
            // Фрактал будет рисоваться на форме
            base.OnPaintBackground(e);
            // Вызываю KochCurveDraw
            this.KochCurveDraw(step, 0, 2 * this.Height / 3, 0, this.Width, e, count);
            count = 0;
        }

        private void IterationClicked(object sender, EventArgs e)
        {
            // Сколько итераций выполнено
            if (this.step > 30)
            {
                MessageBox.Show("Итерация должна быть меньше 30!");
            }
            else
            {
                this.step += 5;
                this.Text = $"Итераций - {this.step}\n Макс - 30";
                this.Invalidate();
            }
        }
        private void SetFractalColor(Control panel)
        {
            if (ColorKoch.ShowDialog() == DialogResult.Cancel)
                return;
            // установка цвета формы
            this.BackColor = ColorKoch.Color;
        }

        private void ColorSet(object sender, EventArgs e)
        {
            this.ColorKoch.ShowDialog();
            this.Invalidate();
        }

        private void ResetAll(object sender, EventArgs e)
        {
            this.step = 0;
        }
    }
}
