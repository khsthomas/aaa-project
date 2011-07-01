using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Base.Image;

namespace AAA.ImageMatching
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            try
            {
                picGoldenImage.Image = Image.FromFile(Environment.CurrentDirectory + @"\Golden\" + txtGoldenImage.Text);
                picCompare.Image = Image.FromFile(Environment.CurrentDirectory + @"\Defect\" + txtCompareImage.Text);

                //ImageProcessor imageProcessor = new ImageProcessor((Bitmap)picGoldenImage.Image);
                //picResult.Image = imageProcessor.CutBackground((Bitmap)picCompare.Image, 20);
                picResult.Image = ImageHelper.CutBackground((Bitmap)picGoldenImage.Image, (Bitmap)picCompare.Image, int.Parse(txtTollence.Text));                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

    }
}
