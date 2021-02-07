namespace WinForm1
{
    using System;

    partial class SerpinskiyForm
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
            this.FractalPictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.SerpinskiyTriangle = new System.Windows.Forms.ToolStripMenuItem();
            this.SerpinskiyCarpet = new System.Windows.Forms.ToolStripMenuItem();
            this.Iteration = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorOption = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.Reset = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.FractalPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FractalPictureBox
            // 
            this.FractalPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FractalPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.FractalPictureBox.Location = new System.Drawing.Point(0, 27);
            this.FractalPictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FractalPictureBox.Name = "FractalPictureBox";
            this.FractalPictureBox.Size = new System.Drawing.Size(800, 800);
            this.FractalPictureBox.TabIndex = 2;
            this.FractalPictureBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save,
            this.SerpinskiyTriangle,
            this.SerpinskiyCarpet,
            this.Iteration,
            this.ColorOption,
            this.Reset});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(43, 20);
            this.Save.Text = "Save";
            this.Save.Click += new System.EventHandler(this.dlgSaveFile_Click);
            // 
            // SerpinskiyTriangle
            // 
            this.SerpinskiyTriangle.Name = "SerpinskiyTriangle";
            this.SerpinskiyTriangle.Size = new System.Drawing.Size(115, 20);
            this.SerpinskiyTriangle.Text = "SerpinskiyTriangle";
            this.SerpinskiyTriangle.Click += new System.EventHandler(this.TriangleButton);
            // 
            // SerpinskiyCarpet
            // 
            this.SerpinskiyCarpet.Name = "SerpinskiyCarpet";
            this.SerpinskiyCarpet.Size = new System.Drawing.Size(107, 20);
            this.SerpinskiyCarpet.Text = "SerpinskiyCarpet";
            this.SerpinskiyCarpet.Click += new System.EventHandler(this.CarpetButton);
            // 
            // Iteration
            // 
            this.Iteration.Name = "Iteration";
            this.Iteration.Size = new System.Drawing.Size(88, 20);
            this.Iteration.Text = "Add Iteration";
            this.Iteration.Click += new System.EventHandler(this.AddIteration_Click);
            // 
            // ColorOption
            // 
            this.ColorOption.Name = "ColorOption";
            this.ColorOption.Size = new System.Drawing.Size(88, 20);
            this.ColorOption.Text = "Color Option";
            this.ColorOption.Click += new System.EventHandler(this.ColorOptionGet);
            // 
            // dlgSave
            // 
            this.dlgSave.DefaultExt = "png";
            this.dlgSave.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif;*.tiff|BMP|*.bmp|JPEG|*.jpg;*.jp" +
    "eg|GIF|*.gif|PNG|*.png|TIFF|*.tif;*.tiff|All Files|*.*";
            // 
            // Reset
            // 
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(47, 20);
            this.Reset.Text = "Reset";
            this.Reset.Click += new EventHandler(this.ResetAll);
            // 
            // SerpinskiyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Controls.Add(this.FractalPictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "SerpinskiyForm";
            this.Text = "Serpinski";
            ((System.ComponentModel.ISupportInitialize)(this.FractalPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox FractalPictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SerpinskiyTriangle;
        private System.Windows.Forms.ToolStripMenuItem SerpinskiyCarpet;
        private System.Windows.Forms.ToolStripMenuItem Iteration;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.ToolStripMenuItem ColorOption;
        private System.Windows.Forms.ColorDialog dlgColor;
        private System.Windows.Forms.ToolStripMenuItem Reset;
    }
}

