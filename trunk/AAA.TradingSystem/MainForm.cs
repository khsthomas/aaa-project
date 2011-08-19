using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AAA.TradingSystem
{
    public partial class MainForm : Form
    {
        private int childFormNumber = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MaxChildForm(Form form)
        {

            if (form.FormBorderStyle == FormBorderStyle.Sizable)
            {
                Rectangle mdiClientArea = Rectangle.Empty;
                foreach (Control c in Controls)
                    if (c is MdiClient)
                        mdiClientArea = c.ClientRectangle;

                form.Bounds = mdiClientArea;
            }
            form.MdiParent = this;
        }

        private void menuItemKBar_Click(object sender, EventArgs e)
        {
            try
            {
                KBarForm childForm = new KBarForm();
                MaxChildForm(childForm);
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void menuItemMarketProfile_Click(object sender, EventArgs e)
        {
            try
            {
                ProfileChartForm childForm = new ProfileChartForm();
                MaxChildForm(childForm);
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void dataGetter_Click(object sender, EventArgs e)
        {
            try
            {
                DataGetterForm childForm = new DataGetterForm();
                MaxChildForm(childForm);
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void filterStock_Click(object sender, EventArgs e)
        {
            try
            {
                StockQueryForm childForm = new StockQueryForm();
                MaxChildForm(childForm);
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void MenuItemJournal_Click(object sender, EventArgs e)
        {
            try
            {
                DiaryForm childForm = new DiaryForm();
                //MaxChildForm(childForm);
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void userDefineSymbol_Click(object sender, EventArgs e)
        {
            try
            {
                UserDefineSymbolForm childForm = new UserDefineSymbolForm();
                MaxChildForm(childForm);
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void dataTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                DataTransferForm childForm = new DataTransferForm();                
                childForm.MdiParent = this;
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }


    }
}
