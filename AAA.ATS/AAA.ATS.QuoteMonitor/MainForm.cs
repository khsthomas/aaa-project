using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.AGS.Client;

namespace AAA.ATS.QuoteMonitor
{
    public partial class MainForm : Form
    {
        private int childFormNumber = 0;
        private Client _client;

        public MainForm()
        {
            InitializeComponent();
            Init();            
        }

        private void Init()
        {
            _client = new Client();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void chartToolStripMenuItem_Click(object sender, EventArgs e)
        {
/*      
            // Select Symbol Definition
            SelectSymbolDialog symbolDialog = new SelectSymbolDialog();
            symbolDialog.ShowDialog();
 */
            ChartForm chartForm = null;

            chartForm = new ChartForm(_client, Environment.CurrentDirectory + @"\chart_config\tfhtx_chart.xml");
//            chartForm = new ChartForm(_client, Environment.CurrentDirectory + @"\chart_config\hfhhsi_chart.xml");
            chartForm.MdiParent = this;
            chartForm.Show();

            chartForm = new ChartForm(_client, Environment.CurrentDirectory + @"\chart_config\tfhtx_pv.xml");
            chartForm.MdiParent = this;
            chartForm.Show();
        }

        private void quoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GridQuoteForm quoteForm = new GridQuoteForm(_client);
            quoteForm.MdiParent = this;
            quoteForm.Show();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestChartForm chartForm = new TestChartForm();
            chartForm.MdiParent = this;
            chartForm.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _client.Unregister();
            Application.Exit();
        }

        private bool IsExists(string strFormName)
        {
            return IsExists(strFormName, null);
        }
        private bool IsExists(string strFormName, string strTitle)
        {
            Form[] childrenForms = MdiChildren;

            foreach (Form child in childrenForms)
            {
                if (child.Name == strFormName)
                {
                    if ((strTitle != null) && (child.Text != strTitle))
                        continue;

                    child.Activate();
                    child.WindowState = FormWindowState.Normal;
                    return true;
                }

            }
            return false;
        }

        private void CreateChartForm(string strConfig, string strTitle)
        {
            if (IsExists("ChartForm", strTitle))
                return;

            ChartForm chartForm = null;
            chartForm = new ChartForm(_client, strConfig);
            chartForm.MdiParent = this;
            chartForm.Show();
        }

        private void DataSourceMenu_Click(object sender, EventArgs e)
        {
            if (IsExists("GridQuoteForm"))
                return;
            GridQuoteForm quoteForm = new GridQuoteForm(_client);
            quoteForm.MdiParent = this;
            quoteForm.Show();
        }

        private void TFHTX_PV_Click(object sender, EventArgs e)
        {
            CreateChartForm(Environment.CurrentDirectory + @"\chart_config\tfhtx_pv.xml",
                            "TWFE_TFHTX 台指期近 壓力關卡");
/*
            if (IsExists("ChartForm", "TWFE_TFHTX 台指期近 壓力關卡"))
                return;

            ChartForm chartForm = null;
            chartForm = new ChartForm(_client, Environment.CurrentDirectory + @"\chart_config\tfhtx_pv.xml");
            chartForm.MdiParent = this;
            chartForm.Show();
*/
        }

        private void TFHTE_PV_Click(object sender, EventArgs e)
        {
            CreateChartForm(Environment.CurrentDirectory + @"\chart_config\tfhte_pv.xml",
                            "TWFE_TFHTE 電子期近 壓力關卡");
/*
            if (IsExists("ChartForm", "TWFE_TFHTE 電子期近 壓力關卡"))
                return;

            ChartForm chartForm = null;
            chartForm = new ChartForm(_client, Environment.CurrentDirectory + @"\chart_config\tfhte_pv.xml");
            chartForm.MdiParent = this;
            chartForm.Show();
 */ 
        }

        private void TFHTF_PV_Click(object sender, EventArgs e)
        {
            CreateChartForm(Environment.CurrentDirectory + @"\chart_config\tfhtf_pv.xml",
                            "TWFE_TFHTF 金融期近 壓力關卡");

/*
            if (IsExists("ChartForm", "TWFE_TFHTF 金融期近 壓力關卡"))
                return;

            ChartForm chartForm = null;
            chartForm = new ChartForm(_client, Environment.CurrentDirectory + @"\chart_config\tfhtf_pv.xml");
            chartForm.MdiParent = this;
            chartForm.Show();
 */ 
        }

        private void TFHTX_PV_Tick_Click(object sender, EventArgs e)
        {
            CreateChartForm(Environment.CurrentDirectory + @"\chart_config\tfhtx_pv_tick.xml",
                            "TWFE_TFHTX 台指期近 壓力關卡(Tick)");
        }

        private void TFHTE_PV_Tick_Click(object sender, EventArgs e)
        {
            CreateChartForm(Environment.CurrentDirectory + @"\chart_config\tfhte_pv_tick.xml",
                            "TWFE_TFHTE 電子期近 壓力關卡(Tick)");
        }

        private void TFHTF_PV_Tick_Click(object sender, EventArgs e)
        {
            CreateChartForm(Environment.CurrentDirectory + @"\chart_config\tfhtf_pv_tick.xml",
                            "TWFE_TFHTF 金融期近 壓力關卡(Tick)");

        }

        private void jChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChartForm chartForm = null;
            chartForm = new ChartForm(_client, Environment.CurrentDirectory + @"\chart_config\tfhtx_j.xml");
            chartForm.MdiParent = this;
            chartForm.Show();
        }

    }
}
