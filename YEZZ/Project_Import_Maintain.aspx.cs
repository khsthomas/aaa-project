using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YEZZ;
using System.IO;
using YEZZ.Model;
using System.Data;

namespace APPGISMS.Project
{
    public partial class Project_Import_Maintain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                DataBuilder.FillProjectName(ddlProjectName);
                lblProjectName.Text = ddlProjectName.SelectedItem.Text;
            }
        }

        private void LoadProjectDoctor()
        {
            string strSQL = "SELECT a.PROJECT_SN, b.PROJECT_NAME, b.PROJECT_REMARK, a.HOSPITAL_NO, a.DOCTOR_ID, a.PROJECT_SDATE, a.PROJECT_EDATE " +
                            "  FROM " + SystemConstants.DATABASE_CATALOG + ".dbo.TB_PROJECT_DOCTOR a, " + SystemConstants.DATABASE_CATALOG + ".dbo.TB_PROJECT_INFO b " +
                            " WHERE a.PROJECT_SN = b.PROJECT_SN " +
                            "   AND a.PROJECT_SN = @PROJECT_SN ";
            List<IDataModel> lstHospital = (new TB_PROJECT_DOCTOR()).Query<IDataModel>(strSQL,
                                                                                    new string[] { "PROJECT_SN" },
                                                                                    new string[] { ddlProjectName.SelectedValue });

            DataTable tblData = new DataTable();
            DataRow dataRow = null;

            tblData.Columns.Add("Edit", typeof(string));
            tblData.Columns.Add("PROJECT_NAME", typeof(string));
            tblData.Columns.Add("PROJECT_SN", typeof(string));
            tblData.Columns.Add("PROJECT_REMARK", typeof(string));
            tblData.Columns.Add("HOSPITAL_NO", typeof(string));
            tblData.Columns.Add("DOCTOR_ID", typeof(string));
            tblData.Columns.Add("PROJECT_SDATE", typeof(string));
            tblData.Columns.Add("PROJECT_EDATE", typeof(string));

            for (int i = 0; i < lstHospital.Count; i++)
            {
                dataRow = tblData.NewRow();

                dataRow["Edit"] = "編輯";
                dataRow["PROJECT_NAME"] = lstHospital[i].Value("PROJECT_NAME").ToString();
                dataRow["PROJECT_SN"] = lstHospital[i].Value("PROJECT_SN").ToString();
                dataRow["PROJECT_REMARK"] = lstHospital[i].Value("PROJECT_REMARK").ToString();
                dataRow["HOSPITAL_NO"] = lstHospital[i].Value("HOSPITAL_NO").ToString();
                dataRow["DOCTOR_ID"] = lstHospital[i].Value("DOCTOR_ID").ToString();
                dataRow["PROJECT_SDATE"] = lstHospital[i].Value("PROJECT_SDATE").ToString();
                dataRow["PROJECT_EDATE"] = lstHospital[i].Value("PROJECT_EDATE").ToString();

                tblData.Rows.Add(dataRow);
            }

            tblHospital.DataSource = tblData;
            tblHospital.DataBind();

            ViewState["CurrentHospitalTable"] = tblData;

            strSQL = "SELECT RECEIPT_SN, SEND_DATE, COUNTY_AREA, HOSPITAL_NO, DOCTOR_ID_RES, DOCTOR_ID_VIOLATION, VIOLATION_REASON, REAPPLICATION_RESULT, REAPPLICATION_NO, REMARK" +
                     "  FROM " + SystemConstants.DATABASE_CATALOG + ".dbo.TB_VIOLATION_INFO " +
                     " WHERE HOSPITAL_NO IN " +
                     "   (SELECT DISTINCT HOSPITAL_NO " +
                     "      FROM "+ SystemConstants.DATABASE_CATALOG + ".dbo.TB_PROJECT_DOCTOR " +
                     "     WHERE PROJECT_SN = @PROJECT_SN)";
            List<IDataModel> lstViolation = (new TB_VIOLATION_INFO()).Query<IDataModel>(strSQL,
                                                                                    new string[] { "PROJECT_SN" },
                                                                                    new string[] { ddlProjectName.SelectedValue });

            tblData = new DataTable();
            
            tblData.Columns.Add("Edit", typeof(string));
            tblData.Columns.Add("RECEIPT_SN", typeof(string));
            tblData.Columns.Add("SEND_DATE", typeof(string));
            tblData.Columns.Add("COUNTY_AREA", typeof(string));
            tblData.Columns.Add("HOSPITAL_NO", typeof(string));
            tblData.Columns.Add("DOCTOR_ID_RES", typeof(string));
            tblData.Columns.Add("DOCTOR_ID_VIOLATION", typeof(string));
            tblData.Columns.Add("VIOLATION_REASON", typeof(string));
            tblData.Columns.Add("REAPPLICATION_RESULT", typeof(string));
            tblData.Columns.Add("REAPPLICATION_NO", typeof(string));
            tblData.Columns.Add("REMARK", typeof(string));

            for (int i = 0; i < lstViolation.Count; i++)
            {
                dataRow = tblData.NewRow();

                dataRow["Edit"] = "編輯";
                dataRow["RECEIPT_SN"] = lstViolation[i].Value("RECEIPT_SN").ToString();
                dataRow["SEND_DATE"] = lstViolation[i].Value("SEND_DATE").ToString();
                dataRow["COUNTY_AREA"] = lstViolation[i].Value("COUNTY_AREA").ToString();
                dataRow["HOSPITAL_NO"] = lstViolation[i].Value("HOSPITAL_NO").ToString();
                dataRow["DOCTOR_ID_RES"] = lstViolation[i].Value("DOCTOR_ID_RES").ToString();
                dataRow["DOCTOR_ID_VIOLATION"] = lstViolation[i].Value("DOCTOR_ID_VIOLATION").ToString();
                dataRow["VIOLATION_REASON"] = lstViolation[i].Value("VIOLATION_REASON").ToString();
                dataRow["REAPPLICATION_RESULT"] = lstViolation[i].Value("REAPPLICATION_RESULT").ToString();
                dataRow["REAPPLICATION_NO"] = lstViolation[i].Value("REAPPLICATION_NO").ToString();
                dataRow["REMARK"] = lstViolation[i].Value("REMARK").ToString();

                tblData.Rows.Add(dataRow);
            }

            tblViolation.DataSource = tblData;
            tblViolation.DataBind();

            ViewState["CurrentViolationTable"] = tblData;
        }


        protected void btnQuery_Click(object sender, EventArgs e)
        {
            LoadProjectDoctor();
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            string strRelativePath = @"Uploads\";
            string strAbsolutePath = Server.MapPath("~/" + strRelativePath);            

            if (fuImportData.HasFile == false)
            {
                emcMsg.ShowErrorMessage("請選擇要匯入之檔案, 謝謝!!");
                return;
            }

            List<IDataModel> lstColumn = GetColumnState();

            if (lstColumn.Count == 0)
            {
                emcMsg.ShowErrorMessage("該專案尚未設定匯入欄位, 請先設定, 謝謝!!");
                return;
            }

            List<string> lstDBColumn = new List<string>(new string[] { "PROJECT_SN", "HOSPITAL_NO", "DOCTOR_ID", "PROJECT_SDATE", "PROJECT_EDATE" });

            string[] strAllDBColumns = new string[] { "CUSTOM_COLUMN1", "CUSTOM_COLUMN2", "CUSTOM_COLUMN3", "CUSTOM_COLUMN4", "CUSTOM_COLUMN5" };
            for (int i = 0; i < lstColumn.Count; i++)
                lstDBColumn.Add(lstColumn[i].Value("DB_COLUMN_NAME").ToString());

            if (Directory.Exists(strAbsolutePath) == false)
                Directory.CreateDirectory(strAbsolutePath);

            File.Delete(strAbsolutePath + fuImportData.FileName);
            fuImportData.SaveAs(strAbsolutePath + fuImportData.FileName);

            StreamReader sr = new StreamReader(strAbsolutePath + fuImportData.FileName);
            string strLine;
            string[] strValues;
            string strErrorMessage;
            IDataModel projectDoctor = new TB_PROJECT_DOCTOR();
            DataTable dataEvent = new DataTable();
            DataRow dataRow = null;

            dataEvent.Columns.Add("ROW_INFO", typeof(string));
            dataEvent.Columns.Add("ERROR_MESSAGES", typeof(string));

            //Set Default Value
            projectDoctor.Value("CREATE_DATE", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            projectDoctor.Value("CREATE_USER", DataBuilder.GetCurrentUser().Value("USERID"));

            for (int i = 0; i < strAllDBColumns.Length; i++)
                if (lstDBColumn.IndexOf(strAllDBColumns[i]) < 0)
                    projectDoctor.Value(strAllDBColumns[i], null);


            while ((strLine = sr.ReadLine()) != null)
            {
                strValues = strLine.Split(',');
                strErrorMessage = null;
                if (strValues.Length != lstDBColumn.Count)
                {
                    strErrorMessage = "欄位個數不對";
                }
                else
                {
                    try
                    {
                        for (int i = 0; i < lstDBColumn.Count; i++)
                            projectDoctor.Value(lstDBColumn[i], strValues[i]);

                        if (projectDoctor.ExecuteInsert() == false)
                            strErrorMessage = projectDoctor.ErrorMessage.Substring(0, projectDoctor.ErrorMessage.IndexOf('\n'));
                    }
                    catch (Exception ex)
                    {
                        strErrorMessage = ex.Message;
                    }
                }
                if (strErrorMessage != null)
                {
                    dataRow = dataEvent.NewRow();
                    dataRow["ROW_INFO"] = (dataEvent.Rows.Count + 1).ToString();
                    dataRow["ERROR_MESSAGES"] = strErrorMessage + "\n資料內容(" + strLine + ")";
                    dataEvent.Rows.Add(dataRow);
                }
            }
            sr.Close();

            if (dataEvent.Rows.Count > 0)
            {
                tblError_List.DataSource = dataEvent;
                tblError_List.DataBind();
                mpeError_List.Show();
                emcMsg.ShowErrorMessage("部份資料匯入完畢!!");
            }
            else
            {
                emcMsg.ShowErrorMessage("匯入完畢!!");
            }
        }

        protected void btnOutput_Click(object sender, EventArgs e)
        {
            try
            {                
                List<IDataModel> lstColumn = GetColumnState();


                if (lstColumn.Count == 0)
                {
                    emcMsg.ShowErrorMessage("該專案尚未設定欄位, 請先設定, 謝謝!!");
                    return;
                }

                string strErrorMessage;
                string strContents = "專案系統編號,醫事機構代碼,醫師身分證號,起始日期,結束日期";                
                List<string> lstColumnName = new List<string>(new string[] {"PROJECT_SN", "HOSPITAL_NO", "DOCTOR_ID", "PROJECT_SDATE", "PROJECT_EDATE"});
                for (int i = 0; i < lstColumn.Count; i++)
                {
                    lstColumnName.Add(lstColumn[i].Value("DB_COLUMN_NAME").ToString());
                    strContents += "," + lstColumn[i].Value("COLUMN_NAME").ToString();
                }

                List<IDataModel> lstProjectDoctor = (new TB_PROJECT_DOCTOR()).Query<IDataModel>(new string[] {"PROJECT_SN"},
                                                                                                new string[] {ddlProjectName.SelectedValue});

                string strLine;
                for (int i = 0; i < lstProjectDoctor.Count; i++)
                {
                    strLine = "";
                    for (int j = 0; j < lstColumnName.Count; j++)
                        strLine += "," + lstProjectDoctor[i].Value(lstColumnName[j]).ToString();
                    if (strLine.Length > 0)
                        strContents += "\n" + strLine.Substring(1);
                }

                if ((strErrorMessage = WebHelper.DownloadFile(this, ddlProjectName.SelectedItem.Text + ".csv", strContents)) != null)
                    emcMsg.ShowErrorMessage(strErrorMessage);
            }
            catch (Exception ex)
            {
                emcMsg.ShowErrorMessage(ex.Message + "," + ex.StackTrace);
            }
        }

        private List<IDataModel> GetColumnState()
        {
            string strSQL = "SELECT COLUMN_NAME, DB_COLUMN_NAME, CUS_COLUMN_ORDER " +
                                            "  FROM " + SystemConstants.DATABASE_CATALOG + ".dbo.TB_COLUMN_STATE " +
                                            " WHERE PROJECT_SN = @PROJECT_SN " +
                                            "   AND STS_INFO = @STS_INFO " +
                                            " ORDER BY CUS_COLUMN_ORDER ";

            List<IDataModel> lstColumn = (List<IDataModel>)(new TB_COLUMN_STATE()).Query<IDataModel>(strSQL,
                                                                                                     new string[] { "PROJECT_SN", "STS_INFO" },
                                                                                                     new string[] { ddlProjectName.SelectedValue, DataBuilder.START_STS_INFO });

            return lstColumn;
        }

        protected void btnSample_Click(object sender, EventArgs e)
        {
            List<IDataModel> lstColumn = GetColumnState();

            if (lstColumn.Count == 0)
            {
                emcMsg.ShowErrorMessage("該專案尚未設定欄位, 請先設定, 謝謝!!");
                return;
            }
            
            List<string> lstCusColumn = new List<string>(new string[] {"專案系統編號", "醫事機構代碼", "醫師身分證號", "起始日期", "結束日期"});
            List<string> lstColumnName = new List<string>(new string[] { "PROJECT_SN", "HOSPITAL_NO", "DOCTOR_ID", "PROJECT_SDATE", "PROJECT_EDATE" });
            DataTable dataTable = new DataTable();
            DataRow dataRow;

            for (int i = 0; i < lstColumn.Count; i++)
            {            
                lstCusColumn.Add(lstColumn[i].Value("COLUMN_NAME").ToString());
                lstColumnName.Add(lstColumn[i].Value("DB_COLUMN_NAME").ToString());
            }

            while (tblSample.Columns.Count > 0)
                tblSample.Columns.RemoveAt(0);

            for(int i = 0; i < lstColumnName.Count; i++)
            {
                BoundField bfField = new BoundField();
                bfField.DataField = lstColumnName[i];
                bfField.HeaderText = lstCusColumn[i];
                tblSample.Columns.Add(bfField);
                dataTable.Columns.Add(lstColumnName[i], typeof(string));
            }

            for (int i = 0; i < 5; i++)
            {
                dataRow = dataTable.NewRow();

                for (int j = 0; j < lstColumnName.Count; j++)
                    dataRow[lstColumnName[j]] = "Text";
                dataTable.Rows.Add(dataRow);
            }

            mpeSample_Info.Show();
            
            tblSample.DataSource = dataTable;
            tblSample.DataBind();
            
        }

        protected void ddlProjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblProjectName.Text = ddlProjectName.SelectedItem.Text;
        }
    }
}
