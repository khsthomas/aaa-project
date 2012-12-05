using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.DataSource;
using AAA.Meta.Quote.Data;
using AAA.Forms.Components.Util;
using AAA.Base.Util;
using System.IO;
using AAA.TradeLanguage;
using AAA.Base.Util.Reflection;

namespace AAA.ProgramTrade
{
    public partial class DataExportForm : Form
    {
        private Dictionary<string, IFunction> _dicFunction;
        public DataExportForm()
        {
            InitializeComponent();
            Init();
            LoadSymbolId();
        }

        private void Init()
        {
            List<IFunction> lstFunction;
            try
            {
                tblMergeSymbolId.Columns.Add("SymbolId", "商品名稱");
                tblMergeSymbolId.Columns.Add("FieldList", "輸出欄位");

                lstFunction = (List<IFunction>)Builder.LoadClasses<IFunction>((string)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH] + @"\Function");

                _dicFunction = new Dictionary<string, IFunction>();
                for (int i = 0; i < lstFunction.Count; i++)
                    _dicFunction.Add(lstFunction[i].DisplayName, lstFunction[i]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void LoadSymbolId()
        {
            IDataSource dataSource;
            List<string> lstSymbolId;
            try
            {
                dataSource = (IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE];
                lstSymbolId = dataSource.GetSymbolList();

                while (cboBaseSymbolId.Items.Count > 0)
                    cboBaseSymbolId.Items.RemoveAt(0);

                foreach (string strSymbolId in lstSymbolId)
                {
                    cboBaseSymbolId.Items.Add(strSymbolId);
                }

                if (cboBaseSymbolId.Items.Count > 0)
                    cboBaseSymbolId.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                LoadSymbolId();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void LoadSymbolField()
        {
            IDataSource dataSource;
            List<BarRecord> lstBarRecord;
            try
            {
                dataSource = (IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE];
                lstBarRecord = dataSource.GetBar(cboBaseSymbolId.Text);

                if (lstBarRecord == null)
                    return;

                if (lstBarRecord.Count == 0)
                    return;

                while (lstField.Items.Count > 0)
                    lstField.Items.RemoveAt(0);

                foreach (string strParamName in lstBarRecord[0].GetParamNames())
                    lstField.Items.Add(strParamName, true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void cboBaseSymbolId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadSymbolField();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnDeleteSymbol_Click(object sender, EventArgs e)
        {
            string strSymbolId;

            if (tblMergeSymbolId.SelectedRows.Count == 0)
            {
                MessageBox.Show("請選擇要刪除的商品, 謝謝!");
                return;
            }            

            while(tblMergeSymbolId.SelectedRows.Count > 0)
            {
                strSymbolId = tblMergeSymbolId.SelectedRows[0].Cells["SymbolId"].Value.ToString();
                cboMergeBaseSymbolId.Items.Remove(strSymbolId);
                DataGridViewUtil.DeleteRow(tblMergeSymbolId,
                                           new string[] { "SymbolId" },
                                           new object[] { strSymbolId });
            }
        }

        private void btnAddSymbol_Click(object sender, EventArgs e)
        {
            string strFieldList;
            try
            {
                if (DataGridViewUtil.FindRowIndex(tblMergeSymbolId,
                                                 new string[] { "SymbolId" },
                                                 new object[] { cboBaseSymbolId.Text}) >= 0)
                {
                    MessageBox.Show("該商品已在列表內, 請重新選擇, 謝謝!");
                    return;
                }

                strFieldList = "";
                foreach (string strField in lstField.CheckedItems)
                {
                    strFieldList += "," + strField;
                }

                if (strFieldList.Length == 0)
                {
                    MessageBox.Show("請至少選擇一個輸出欄位, 謝謝!");
                    return;
                }

                DataGridViewUtil.InsertRow(tblMergeSymbolId,
                                           new object[] {cboBaseSymbolId.Text,
                                                         strFieldList.Substring(1)});
                cboMergeBaseSymbolId.Items.Add(cboBaseSymbolId.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnUpdateField_Click(object sender, EventArgs e)
        {
            string strFieldList;
            try
            {
                if (DataGridViewUtil.FindRowIndex(tblMergeSymbolId,
                                                 new string[] { "SymbolId" },
                                                 new object[] { cboBaseSymbolId.Text }) < 0)
                {
                    MessageBox.Show("所選商品不在列表內, 請重新選擇, 謝謝!");
                    return;
                }

                strFieldList = "";
                foreach (string strField in lstField.CheckedItems)
                {
                    strFieldList += "," + strField;
                }

                if (strFieldList.Length == 0)
                {
                    MessageBox.Show("請至少選擇一個輸出欄位, 謝謝!");
                    return;
                }

                DataGridViewUtil.UpdateRow(tblMergeSymbolId,
                                           new string[] {"SymbolId"},
                                           new object[] {cboBaseSymbolId.Text,
                                                         strFieldList.Substring(1)});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void ExportFile(string strSymbolId, string strFilename, string[] strFields)
        {
            List<BarRecord> lstBarRecord;
            IDataSource dataSource;
            string strExport;
            StreamWriter sw = null;
            try
            {
                dataSource = (IDataSource)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.DATA_SOURCE];
                lstBarRecord = dataSource.GetBar(strSymbolId);
                sw = new StreamWriter(strFilename, true, Encoding.Default);

                strExport = "DateTime";
                for (int i = 0; i < strFields.Length; i++)
                    strExport += "\t" + strFields[i];
                sw.WriteLine(strExport);

                for (int i = 0; i < lstBarRecord.Count; i++)
                {
                    strExport = lstBarRecord[i].BarDateTime.ToString("yyyy/MM/dd HH:mm:ss");
                    for (int j = 0; j < strFields.Length; j++)
                        strExport += "\t" + lstBarRecord[i][strFields[j]].ToString("0.00");
                    sw.WriteLine(strExport);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {            
            string strFilename;
            string strSymbolId;
            string[] strFields;
            try
            {
                IOHelper.CreateDirectory(txtExportDirectory.Text);

                for (int i = 0; i < tblMergeSymbolId.Rows.Count; i++)
                {
                    strSymbolId = tblMergeSymbolId.Rows[i].Cells["SymbolId"].Value.ToString();
                    strFilename = txtExportDirectory.Text + "\\" + strSymbolId + ".csv";
                    strFields = tblMergeSymbolId.Rows[i].Cells["FieldList"].Value.ToString().Split(',');
                    ExportFile(strSymbolId, strFilename, strFields);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            IFunction executeFunction;
            Dictionary<string, object> dicParam;
            string strDataSource;
            string strFieldList;
            try
            {
                if (tblMergeSymbolId.Rows.Count < 2)
                {
                    MessageBox.Show("請至少選擇二個合併的商品, 謝謝!");
                    return;
                }

                executeFunction = _dicFunction["DataMerge"];
                dicParam = new Dictionary<string, object>();

                strDataSource = "";
                strFieldList = "";
                for (int i = 0; i < tblMergeSymbolId.Rows.Count; i++)
                {
                    strDataSource += ";" + tblMergeSymbolId.Rows[i].Cells["SymbolId"].Value.ToString();
                    strFieldList += ";" + tblMergeSymbolId.Rows[i].Cells["FieldList"].Value.ToString();
                }

                dicParam.Add("TransferSymbolId", txtMergedSymbolId.Text);
                dicParam.Add("SymbolIdList", strDataSource.Substring(1));
                dicParam.Add("FieldList", strFieldList.Substring(1));

                ProgramUtil.RunFunction(executeFunction,
                                        cboMergeBaseSymbolId.Text,
                                        dicParam);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
