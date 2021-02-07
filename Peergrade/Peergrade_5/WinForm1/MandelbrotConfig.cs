using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForm1
{
    public partial class MandelbrotConfig : System.Windows.Forms.Form
    {
        public MandelbrotConfig()
        {
            InitializeComponent();
        }
    
        // The form this one is configuring.
        private Mandelbrot fractalMandelbrot;

        // Initialize the options.
        public void Initialize(Mandelbrot frm)
        {
            this.fractalMandelbrot = frm;

            // Deselect all colors.
            this.ButtonNoneClick(null, null);

            // Select the colors in use by the main form.
            for (int i = 0; i < this.fractalMandelbrot.Colors.Count; i++)
            {
                // Select the PictureBox with this color.
                SelectColor(this.fractalMandelbrot.Colors[i]);
            }
        }

        // Select all colors.
        private void btnAll_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is PictureBox)
                {
                    PictureBox pic = ctl as PictureBox;
                    pic.BorderStyle = BorderStyle.Fixed3D;
                }
            }
        }

        // Deselect all colors.
        private void ButtonNoneClick(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is PictureBox)
                {
                    PictureBox pic = ctl as PictureBox;
                    pic.BorderStyle = BorderStyle.None;
                }
            }
        }

        // Select the colors in this column.
        private void SelectColumn(int col)
        {
            // Deselect all colors.
            this.ButtonNoneClick(null, null);

            // Select the colors in this column.
            string pic_name;
            for (int i = 0; i <= 5; i++)
            {
                pic_name = "picColor_" + (i * 8 + col).ToString();
                SelectPictureBox(pic_name);
            }
        }

        // Select the colors in this row.
        private void SelectRow(int row)
        {
            // Deselect all colors.
            this.ButtonNoneClick(null, null);

            // Select the colors in this column.
            string pic_name;
            int first_number = row * 8;
            for (int i = 0; i <= 7; i++)
            {
                pic_name = "picColor_" + (i + first_number).ToString();
                SelectPictureBox(pic_name);
            }
        }

        // Select the PictureBox with this name.
        private void SelectPictureBox(string pic_name)
        {
            Control ctl = GetControlByName(pic_name);
            PictureBox pic = ctl as PictureBox;
            pic.BorderStyle = BorderStyle.Fixed3D;
        }

        // Select the PictureBox with this color.
        private void SelectColor(Color clr)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is PictureBox)
                {
                    if (ctl.BackColor.Equals(clr))
                    {
                        PictureBox pic = ctl as PictureBox;
                        pic.BorderStyle = BorderStyle.Fixed3D;
                        return;
                    }
                }
            }
        }

        // Return the control with this name.
        private Control GetControlByName(string pic_name)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl.Name == pic_name) return ctl;
            }
            return null;
        }

        // Select the colors in a column.
        private void btnColumn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            SelectColumn(int.Parse(btn.Tag.ToString()));
        }

        // Select the colors in this row.
        private void btnRow_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            SelectRow(int.Parse(btn.Tag.ToString()));        
        }

        // Apply the changes.
        private void btnOk_Click(object sender, EventArgs e)
        {
            // Get the number of iterations.
            this.fractalMandelbrot.MaxIterations = int.Parse(txtMaxIterations.Text);

            // Get Z and Z2.
            this.fractalMandelbrot.Zr = double.Parse(txtZr.Text);
            this.fractalMandelbrot.Zim = double.Parse(txtZim.Text);
            this.fractalMandelbrot.Z2r = double.Parse(txtZ2r.Text);
            this.fractalMandelbrot.Z2im = double.Parse(txtZ2im.Text);

            // Save the selected colors.
            // (This is a little odd because we want to save them
            // in the order in which they appear on the dialog.)
            this.fractalMandelbrot.ResetColors();
            for (int i = 0; i < 48; i++)
            {
                // See if this color is selected.
                Control ctl = GetControlByName("picColor_" + i);
                PictureBox pic = ctl as PictureBox;
                if (pic.BorderStyle == BorderStyle.Fixed3D)
                    this.fractalMandelbrot.Colors.Add(pic.BackColor);
            }

            this.Close();
        }

        // Close the dialog without saving the changes.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Select some default colors.
        private void btnDefault_Click(object sender, EventArgs e)
        {
            // Deselect all colors.
            this.ButtonNoneClick(null, null);

            // Select the default colors.
            picColor_40.BorderStyle = BorderStyle.Fixed3D;
            picColor_17.BorderStyle = BorderStyle.Fixed3D;
            picColor_18.BorderStyle = BorderStyle.Fixed3D;
            picColor_19.BorderStyle = BorderStyle.Fixed3D;
            picColor_20.BorderStyle = BorderStyle.Fixed3D;
            picColor_21.BorderStyle = BorderStyle.Fixed3D;
            picColor_22.BorderStyle = BorderStyle.Fixed3D;
            picColor_23.BorderStyle = BorderStyle.Fixed3D;

            // Remember that the default colors are selected.            
        }

        // Select ths color.
        private void picColor_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if (pic.BorderStyle == BorderStyle.Fixed3D)
                pic.BorderStyle = BorderStyle.None;
            else
                pic.BorderStyle = BorderStyle.Fixed3D;
        }
    }
}
