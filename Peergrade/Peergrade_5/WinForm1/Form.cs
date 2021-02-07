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
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            this.Text = "Fractal - Alhamdulillah";
            this.Icon = new Icon("icon.ico");
            this.BackColor = Color.Azure;
            this.pictureBox1.Image = Image.FromFile("2021.gif");
            this.Height = 600;
            this.Width = 750;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.pictureBox1.Invalidate();

        }

        /// <summary>
        /// Вызываются формы Фракталов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void JuliaClicked(object sender, EventArgs e)
        {
            JuliaForm jw = new JuliaForm();
            jw.ShowDialog();
            jw.Text = "Julia - Fractal";
        }

        public void SerpinskiyClicked(object sender, EventArgs e)
        {
            SerpinskiyForm sf = new SerpinskiyForm();
            sf.ShowDialog();
            sf.Text = "Serpinskiy - Fractal";
        }

        public void MandelBrotClicked(object sender, EventArgs e)
        { 
            Mandelbrot md = new Mandelbrot();
            md.ShowDialog();
            md.Text = "Mandelbrot - Fractal";
        }

        public void PythagorasClicked(object sender, EventArgs e)
        {
            Pythagoras ph = new Pythagoras();
            ph.ShowDialog();
            ph.Text = "Pythagoras - Fractal";
        }

        private void KochCurveClicked(object sender, EventArgs e)
        { 
            KochCurve kc = new KochCurve();
            kc.ShowDialog();
            kc.Text = "KochCurve - Fractal";
        }

    }
}
