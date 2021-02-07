namespace WinForm1
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    partial class Pythagoras
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Render = new System.Windows.Forms.ToolStripMenuItem();
            this.Iteration = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorOption = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Reset = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 37);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 665);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save,
            this.Render,
            this.Iteration,
            this.ColorOption,
            this.Reset});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(699, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(43, 20);
            this.Save.Text = "Save";
            this.Save.Click += new System.EventHandler(this.SavePythagorasTree);
            // 
            // Render
            // 
            this.Render.Name = "Render";
            this.Render.Size = new System.Drawing.Size(56, 20);
            this.Render.Text = "Render";
            this.Render.Click += new System.EventHandler(this.Form1_Load);
            // 
            // Iteration
            // 
            this.Iteration.Name = "Iteration";
            this.Iteration.Size = new System.Drawing.Size(63, 20);
            this.Iteration.Text = "Iteration";
            this.Iteration.Click += new System.EventHandler(this.Iterations_Click);
            // 
            // ColorOption
            // 
            this.ColorOption.Name = "ColorOption";
            this.ColorOption.Size = new System.Drawing.Size(48, 20);
            this.ColorOption.Text = "Color";
            this.ColorOption.Click += new System.EventHandler(this.ColorOptionGet);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "png";
            this.saveFileDialog1.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif;*.tiff|BMP|*.bmp|JPEG|*.jpg;*.jp" +
    "eg|GIF|*.gif|PNG|*.png|TIFF|*.tif;*.tiff|All Files|*.*";
            // 
            // Reset
            // 
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(47, 20);
            this.Reset.Text = "Reset";
            this.Reset.Click += new EventHandler(ResetAll);
            // 
            // Pythagoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 682);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Pythagoras";
            this.Text = "Pythagoras - Fractal";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem Render;
        private ColorDialog colorDialog;
        private ToolStripMenuItem ColorOption;
        private ToolStripMenuItem Iteration;
        private ToolStripMenuItem Save;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem Reset;
    }
}

