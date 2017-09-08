using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTI.Modules.Shared;
using GTI.Modules.SystemSettings.Data;
using GTI.Modules.SystemSettings.Properties;
using GTI.Modules.Shared.Business;
using GTI.Modules.Shared.Data;

namespace GTI.Modules.SystemSettings.UI
{
    public partial class LEDFlashboardColorPicker : GradientForm
    {
        public Color pickedColor;
        public Color initColor;

        public LEDFlashboardColorPicker(Color color)
        {
            InitializeComponent();
            if (color == null)
            {
                panel1.BackColor = System.Drawing.Color.White;
                initColor = System.Drawing.Color.White;
            }
            else
            {
                panel1.BackColor = color;
                initColor = color;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Color has been chosen, lose the dialog
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pickedColor = initColor;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;
            if (mouseEventArgs != null)
            {
                Bitmap bmp = (Bitmap)pictureBox1.Image;
                Color pxlColor = bmp.GetPixel(mouseEventArgs.X/3, mouseEventArgs.Y/3);
                panel1.BackColor = pxlColor;
                pickedColor = pxlColor;
            }
        }
    }
}
