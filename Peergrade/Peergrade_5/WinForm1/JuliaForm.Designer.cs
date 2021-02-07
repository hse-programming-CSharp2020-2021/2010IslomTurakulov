
namespace WinForm1
{
    using System;

    partial class JuliaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.Render = new System.Windows.Forms.ToolStripMenuItem();
            this.Iterations = new System.Windows.Forms.ToolStripMenuItem();
            this.Reset = new System.Windows.Forms.ToolStripMenuItem();
            this.Zoom = new System.Windows.Forms.ToolStripMenuItem();
            this.x2 = new System.Windows.Forms.ToolStripMenuItem();
            this.x5 = new System.Windows.Forms.ToolStripMenuItem();
            this.Fullscreen = new System.Windows.Forms.ToolStripMenuItem();
            this.Colors = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Render,
            this.Iterations,
            this.Reset,
            this.Zoom,
            this.Colors,
            this.Save});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(800, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "MainMenu";
            // 
            // Render
            // 
            this.Render.Name = "Render";
            this.Render.Size = new System.Drawing.Size(56, 20);
            this.Render.Text = "Render";
            this.Render.Click += new System.EventHandler(this.menuStrip1_ItemClicked);
            // 
            // Iterations
            // 
            this.Iterations.Name = "Iterations";
            this.Iterations.Size = new System.Drawing.Size(68, 20);
            this.Iterations.Text = "Iterations";
            this.Iterations.Click += new System.EventHandler(this.IterationCount);
            // 
            // Reset
            // 
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(47, 20);
            this.Reset.Text = "Reset";
            this.Reset.Click += new System.EventHandler(this.ResetIteration);
            // 
            // Zoom
            // 
            this.Zoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x2,
            this.x5,
            this.Fullscreen});
            this.Zoom.Name = "Zoom";
            this.Zoom.Size = new System.Drawing.Size(51, 20);
            this.Zoom.Text = "Zoom";
            // 
            // x2
            // 
            this.x2.Name = "x2";
            this.x2.Size = new System.Drawing.Size(127, 22);
            this.x2.Text = "x2";
            this.x2.Click += new System.EventHandler(this.zoom_clickedx2);
            // 
            // x5
            // 
            this.x5.Name = "x5";
            this.x5.Size = new System.Drawing.Size(127, 22);
            this.x5.Text = "x5";
            this.x5.Click += new System.EventHandler(this.zoom_clickedx5);
            // 
            // Fullscreen
            // 
            this.Fullscreen.Name = "Fullscreen";
            this.Fullscreen.Size = new System.Drawing.Size(127, 22);
            this.Fullscreen.Text = "Fullscreen";
            this.Fullscreen.Click += new System.EventHandler(this.FullScreen);
            // 
            // Colors
            // 
            this.Colors.Name = "Colors";
            this.Colors.Size = new System.Drawing.Size(53, 20);
            this.Colors.Text = "Colors";
            this.Colors.Click += new System.EventHandler(this.ColorOptionGet);
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(43, 20);
            this.Save.Text = "Save";
            this.Save.Click += new System.EventHandler(this.SaveFractal);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 426);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "png";
            this.saveFileDialog1.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif;*.tiff|BMP|*.bmp|JPEG|*.jpg;*.jp" +
    "eg|GIF|*.gif|PNG|*.png|TIFF|*.tif;*.tiff|All Files|*.*";
            // 
            // JuliaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "JuliaForm";
            this.Text = "JuliaForm";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem Render;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem Iterations;
        private System.Windows.Forms.ToolStripMenuItem Zoom;
        private System.Windows.Forms.ToolStripMenuItem x2;
        private System.Windows.Forms.ToolStripMenuItem x5;
        private System.Windows.Forms.ToolStripMenuItem Fullscreen;
        private System.Windows.Forms.ToolStripMenuItem Colors;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem Reset;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}