
namespace WinForm1
{
    using System;
    using System.Drawing;

    partial class Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Mandelbrot Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Fractals = new System.Windows.Forms.ToolStripMenuItem();
            this.Mandelbrot = new System.Windows.Forms.ToolStripMenuItem();
            this.Julia = new System.Windows.Forms.ToolStripMenuItem();
            this.Serpinskiy = new System.Windows.Forms.ToolStripMenuItem();
            this.Pythagoras = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SaveFractal = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.KochCurve = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Fractals});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(835, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Fractals
            // 
            this.Fractals.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Mandelbrot,
            this.Julia,
            this.Serpinskiy,
            this.Pythagoras,
            this.KochCurve});
            this.Fractals.Name = "Fractals";
            this.Fractals.Size = new System.Drawing.Size(59, 20);
            this.Fractals.Text = "Fractals";
            // 
            // Mandelbrot
            // 
            this.Mandelbrot.Name = "Mandelbrot";
            this.Mandelbrot.Size = new System.Drawing.Size(136, 22);
            this.Mandelbrot.Text = "Mandelbrot";
            this.Mandelbrot.Click += new System.EventHandler(this.MandelBrotClicked);
            // 
            // Julia
            // 
            this.Julia.Name = "Julia";
            this.Julia.Size = new System.Drawing.Size(136, 22);
            this.Julia.Text = "Julia";
            this.Julia.Click += new System.EventHandler(this.JuliaClicked);
            // 
            // Serpinskiy
            // 
            this.Serpinskiy.Name = "Serpinskiy";
            this.Serpinskiy.Size = new System.Drawing.Size(136, 22);
            this.Serpinskiy.Text = "Serpinskiy";
            this.Serpinskiy.Click += new System.EventHandler(this.SerpinskiyClicked);
            // 
            // Pythagoras
            // 
            this.Pythagoras.Name = "Pythagoras";
            this.Pythagoras.Size = new System.Drawing.Size(136, 22);
            this.Pythagoras.Text = "Pythagoras";
            this.Pythagoras.Click += new System.EventHandler(this.PythagorasClicked);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(150, 100);
            this.splitContainer1.TabIndex = 0;
            // 
            // SaveFractal
            // 
            this.SaveFractal.Name = "SaveFractal";
            this.SaveFractal.Size = new System.Drawing.Size(133, 22);
            this.SaveFractal.Text = "SaveFractal";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(932, 451);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // KochCurve
            // 
            this.KochCurve.Name = "KochCurve";
            this.KochCurve.Size = new System.Drawing.Size(136, 22);
            this.KochCurve.Text = "KochCurve";
            this.KochCurve.Click += new EventHandler(this.KochCurveClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 476);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Fractals;
        private System.Windows.Forms.ToolStripMenuItem Mandelbrot;
        private System.Windows.Forms.ToolStripMenuItem Julia;
        private System.Windows.Forms.ToolStripMenuItem Serpinskiy;
        private System.Windows.Forms.ToolStripMenuItem Pythagoras;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem SaveFractal;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem KochCurve;
    }
}

