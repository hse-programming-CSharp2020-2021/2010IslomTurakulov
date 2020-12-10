using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task9
{
    public partial class Form1 : Form
    {
        float xz, yz;                         // абсцисса и ордината центра земли
        float one;                            // единица масштаба
        float rz;                               // радиус земли
        float wz, hz;                        // левый верхний угол для земли  
        int k = 0, k2 = 0;                              // счетчик тиков
        float teta0 = (float)(5 * Math.PI / 4); // начальный угол 
        float R0;                              // начальное расстояние от земли до спутника 
        float rs;                               // радиус спутника
        float ws, hs;                       // левый верхний угол для спутника
        float dt = (float)(Math.PI / 100);      // приращение угла
        int kz = 15, ks = 4, kr = 1, kOne = 100;// коэффициенты

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = false;  // Остановлен таймер
            timer1.Interval = 100;     // Интервал тиков
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!timer1.Enabled) 	// Таймер не включен
                pictureData();	// Пересчет масштабных соотношений
            pictureBox1.Refresh();	// Обновить изображение 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureData();          // Подготовка и масштабирование данных для рисунка 
            k++; // счетчик тиков
            if (!button1.Enabled)
                k2++;
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics target = e.Graphics;
            Pen blackPen = new Pen(Color.Black);
            Pen greenPen = new Pen(Color.Green);
            target.FillEllipse(blackPen.Brush, ws, hs, 2 * rs, 2 * rs);
            target.FillEllipse(greenPen.Brush, wz, hz, 2 * rz, 2 * rz);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                timer1.Enabled = true; // Запустить таймер
                button1.Text = "Посадка";
            }
            else
                button1.Enabled = false;
        }

        private void pictureData()
        {
            xz = pictureBox1.Size.Width / 2;    // абсцисса центра земли
            yz = pictureBox1.Size.Height / 2;   // ордината центра земли
            one = Math.Min(xz, yz) / kOne;      // единица масштаба 
            rz = one * kz;                      // радиус земли
            wz = xz - rz; hz = yz - rz;         // левый верхний угол для земли   
            rs = one * ks;                      // радиус спутника
            ws = wz; hs = hz;                   // левый верхний угол для спутника
            float R;                            // расстояние от земли до спутника 
            R0 = (float)Math.Sqrt((ws - xz) * (ws - xz) + (hs - yz) * (hs - yz));
            float dR = one * kr;
            if (button1.Enabled)
                R = Math.Min(R0 + k * dR, one * 80);
            else
                R = Math.Min(R0 + (k - k2) * dR, one * 80) - k2 * dR;
            ws = (float)(R * Math.Cos(teta0 + k * dt)) + xz;
            hs = (float)(R * Math.Sin(teta0 + k * dt)) + yz;
            if (!button1.Enabled && R <= R0)
            {
                timer1.Enabled = false;
                button1.Text = "Запуск";
                button1.Enabled = true;
                k = 0;
                k2 = 0;
            }
        }

    }
}
