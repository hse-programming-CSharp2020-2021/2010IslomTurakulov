namespace WinForm1
{
    partial class Mandelbrot
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
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScaleMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpt = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale_2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale_4 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale_8 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScaleFull = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScaleRefreshSep = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScaleRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.Zoom = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorFunction = new System.Windows.Forms.ToolStripMenuItem();
            this.SavePng = new System.Windows.Forms.ToolStripMenuItem();
            this.ChooseColor = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu1
            // 
            this.MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuScaleMnu,
            this.mnuOpt});
            this.MainMenu1.Location = new System.Drawing.Point(0, 0);
            this.MainMenu1.Name = "MainMenu1";
            this.MainMenu1.Size = new System.Drawing.Size(200, 24);
            this.MainMenu1.TabIndex = 0;
            // 
            // mnuFile
            // 
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(12, 20);
            // 
            // mnuScaleMnu
            // 
            this.mnuScaleMnu.Name = "mnuScaleMnu";
            this.mnuScaleMnu.Size = new System.Drawing.Size(12, 20);
            // 
            // mnuOpt
            // 
            this.ColorFunction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                                          this.mnuOptOptions});
            this.ColorFunction.Name = "mnuOpt";
            this.ColorFunction.Size = new System.Drawing.Size(61, 20);
            this.ColorFunction.Text = "&Options";
            // 
            // mnuOptOptions
            // 
            this.mnuOptOptions.Name = "mnuOptOptions";
            this.mnuOptOptions.Size = new System.Drawing.Size(135, 22);
            this.mnuOptOptions.Text = "&Set Options";
            this.mnuOptOptions.Click += new System.EventHandler(this.mnuOptOptions_Click);
            // 
            // mnuFileSaveAs
            // 
            this.mnuFileSaveAs.Checked = true;
            this.mnuFileSaveAs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuFileSaveAs.Name = "mnuFileSaveAs";
            this.mnuFileSaveAs.Size = new System.Drawing.Size(123, 22);
            this.mnuFileSaveAs.Text = "&Save As...";
            this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
            // 
            // mnuScale_2
            // 
            this.mnuScale_2.Name = "mnuScale_2";
            this.mnuScale_2.Size = new System.Drawing.Size(123, 22);
            this.mnuScale_2.Tag = "2";
            this.mnuScale_2.Text = "x&2";
            this.mnuScale_2.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale_4
            // 
            this.mnuScale_4.Name = "mnuScale_4";
            this.mnuScale_4.Size = new System.Drawing.Size(123, 22);
            this.mnuScale_4.Tag = "4";
            this.mnuScale_4.Text = "x&4";
            this.mnuScale_4.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScale_8
            // 
            this.mnuScale_8.Name = "mnuScale_8";
            this.mnuScale_8.Size = new System.Drawing.Size(123, 22);
            this.mnuScale_8.Tag = "8";
            this.mnuScale_8.Text = "x&8";
            this.mnuScale_8.Click += new System.EventHandler(this.mnuScale_Click);
            // 
            // mnuScaleFull
            // 
            this.mnuScaleFull.Name = "mnuScaleFull";
            this.mnuScaleFull.Size = new System.Drawing.Size(123, 22);
            this.mnuScaleFull.Tag = "";
            this.mnuScaleFull.Text = "&Full Scale";
            this.mnuScaleFull.Click += new System.EventHandler(this.mnuScaleFull_Click);
            // 
            // mnuScaleRefreshSep
            // 
            this.mnuScaleRefreshSep.Name = "mnuScaleRefreshSep";
            this.mnuScaleRefreshSep.Size = new System.Drawing.Size(123, 22);
            this.mnuScaleRefreshSep.Text = "-";
            // 
            // mnuScaleRefresh
            // 
            this.mnuScaleRefresh.Name = "mnuScaleRefresh";
            this.mnuScaleRefresh.Size = new System.Drawing.Size(123, 22);
            this.mnuScaleRefresh.Text = "&Refresh";
            this.mnuScaleRefresh.Click += new System.EventHandler(this.mnuScaleRefresh_Click);
            // 
            // dlgSaveFile
            // 
            this.dlgSaveFile.DefaultExt = "png";
            this.dlgSaveFile.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif;*.tiff|BMP|*.bmp|JPEG|*.jpg;*.jp" +
    "eg|GIF|*.gif|PNG|*.png|TIFF|*.tif;*.tiff|All Files|*.*";
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.Black;
            this.picCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCanvas.Location = new System.Drawing.Point(0, 24);
            this.picCanvas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(341, 246);
            this.picCanvas.TabIndex = 1;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
            this.picCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save,
            this.Zoom,
            this.ColorFunction});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(341, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Save
            // 
            this.Save.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileSaveAs});
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(37, 20);
            this.Save.Text = "&File";
            // 
            // Zoom
            // 
            this.Zoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuScale_2,
            this.mnuScale_4,
            this.mnuScale_8,
            this.mnuScaleFull,
            this.mnuScaleRefreshSep,
            this.mnuScaleRefresh});
            this.Zoom.Name = "Zoom";
            this.Zoom.Size = new System.Drawing.Size(46, 20);
            this.Zoom.Text = "&Scale";
            // 
            // SavePng
            // 
            this.SavePng.Name = "SavePng";
            this.SavePng.Size = new System.Drawing.Size(32, 19);
            // 
            // ChooseColor
            // 
            this.ChooseColor.Name = "ChooseColor";
            this.ChooseColor.Size = new System.Drawing.Size(146, 22);
            this.ChooseColor.Text = "Choose Color";
            // 
            // Mandelbrot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 270);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.MainMenu1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Mandelbrot";
            this.Text = "Mandelbrot - Fractal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip MainMenu1;
        public System.Windows.Forms.ToolStripMenuItem mnuFile;
        public System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        public System.Windows.Forms.ToolStripMenuItem mnuScaleMnu;
        public System.Windows.Forms.ToolStripMenuItem mnuScale_2;
        public System.Windows.Forms.ToolStripMenuItem mnuScale_4;
        public System.Windows.Forms.ToolStripMenuItem mnuScale_8;
        public System.Windows.Forms.ToolStripMenuItem mnuScaleFull;
        public System.Windows.Forms.ToolStripMenuItem mnuScaleRefreshSep;
        public System.Windows.Forms.ToolStripMenuItem mnuScaleRefresh;
        public System.Windows.Forms.ToolStripMenuItem mnuOpt;
        public System.Windows.Forms.ToolStripMenuItem mnuOptOptions;
        internal System.Windows.Forms.SaveFileDialog dlgSaveFile;
        internal System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.ToolStripMenuItem Zoom;
        private System.Windows.Forms.ToolStripMenuItem ColorFunction;
        private System.Windows.Forms.ToolStripMenuItem SavePng;
        private System.Windows.Forms.ToolStripMenuItem ChooseColor;
    }
}

