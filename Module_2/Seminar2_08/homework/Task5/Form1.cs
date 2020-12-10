using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task5
{
    public partial class Form1 : Form
    {
        string[] lines = new string[] { "один", "два", "три", "четыре", "пять", "шесть", "семь" };

        public Form1()
        {
            InitializeComponent();
            button2.Visible = false; // скрыть кнопку
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Lines = lines;
            button2.Visible = true;		// показать вторую кнопку
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // В textBox1.Lines - измененный список 
            string res = string.Join("  ", textBox1.Lines);
            MessageBox.Show("Результат изменений:\n" + res);
        }
    }
}
