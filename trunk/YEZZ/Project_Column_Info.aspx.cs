using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YEZZ;
using YEZZ.Model;
using System.Data;

namespace APPGISMS.Project
{
    public partial class Project_Column_Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBuilder.FillStsInfo(ddlStsInfo);
                DataBuilder.FillProjectName(ddlProjectName, DataBuilder.START_STS_INFO);
                DataBuilder.FillColumnOrder(ddlColumnOrder);
            }
            tblProjectColumn.RowEditing += new GridViewEditEventHandler(tblProjectColumn_RowEditing);
        }

        void tblProjectColumn_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (ViewState["CurrentTable"] == null)
                return;

            DataTable tblColumn = (DataTable)ViewState["CurrentTable"];
            DataRow dataRow = tblColumn.Rows[e.NewEditIndex];

            txtColumnName.Text = dataRow["COLUMN_NAME"].ToString();
            ddlStsInfo.SelectedValue = DataBuilder.StsValue(dataRow["STS_INFO"].ToString());
            ddlColumnOrder.SelectedValue = dataRow["CUS_COLUMN_ORDER"].ToString();
            hfColumnId.Value = dataRow["COLUMN_ID"].ToString();
        }

        private void LoadProject()
        {
            string strSQL = "SELECT a.PROJECT_SN, b.PROJECT_NAME, a.COLUMN_ID, a.COLUMN_NAME, a.CUS_COLUMN_ORDER, a.STS_INFO " +
                            "  FROM " + SystemConstants.DATABASE_CATALOG + ".dbo.TB_COLUMN_STATE a, " + SystemConstants.DATABASE_CATALOG + ".dbo.TB_PROJECT_INFO b " +
                            " WHERE a.PROJECT_SN = b.PROJECT_SN " +
                            "   AND a.PROJECT_SN = @PROJECT_SN ";
            List<IDataModel> lstProject = (new TB_COLUMN_STATE()).Query<IDataModel>(strSQL,
                                                                                    new string[] { "PROJECT_SN" },
                                                                                    new string[] { ddlProjectName.SelectedValue });

            DataTable tblColumn = new DataTable();
            DataRow dataRow = null;

            tblColumn.Columns.Add("Edit", typeof(string));
            tblColumn.Columns.Add("PROJECT_NAME", typeof(string));
            tblColumn.Columns.Add("PROJECT_SN", typeof(string));
            tblColumn.Columns.Add("COLUMN_NAME", typeof(string));
            tblColumn.Columns.Add("COLUMN_ID", typeof(string));
            tblColumn.Columns.Add("STS_INFO", typeof(string));
            tblColumn.Columns.Add("CUS_COLUMN_ORDER", typeof(string));

            for (int i = 0; i < lstProject.Count; i++)
            {
                dataRow = tblColumn.NewRow();

                dataRow["Edit"] = "編輯";
                dataRow["PROJECT_NAME"] = lstProject[i].Value("PROJECT_NAME").ToString();
                dataRow["PROJECT_SN"] = lstProject[i].Value("PROJECT_SN").ToString();
                dataRow["COLUMN_NAME"] = lstProject[i].Value("COLUMN_NAME").ToString();
                dataRow["COLUMN_ID"] = lstProject[i].Value("COLUMN_ID").ToString();
                dataRow["STS_INFO"] = DataBuilder.StsText(lstProject[i].Value("STS_INFO").ToString());
                dataRow["CUS_COLUMN_ORDER"] = lstProject[i].Value("CUS_COLUMN_ORDER").ToString();

                tblColumn.Rows.Add(dataRow);
            }

            tblProjectColumn.DataSource = tblColumn;
            tblProjectColumn.DataBind();

            ViewState["CurrentTable"] = tblColumn;
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            LoadProject();
        }

        private string CheckImport()
        {
            if (ViewState["CurrentTable"] == null)
                return null;

            DataTable tblColumn = (DataTable)ViewState["CurrentTable"];
            DataRow dataRow = null;

            for (int i = 0; i < tblColumn.Rows.Count; i++)
            {
                dataRow = tblColumn.Rows[i];

                if ((dataRow["COLUMN_NAME"].ToString() == txtColumnName.Text) && (dataRow["COLUMN_ID"].ToString() != hfColumnId.Value))
                {
                    txtColumnName.Focus();
                    return "重覆的欄位名稱, 請重新輸入, 謝謝!!";
                }

                if ((dataRow["CUS_COLUMN_ORDER"].ToString() == ddlColumnOrder.SelectedValue) && (dataRow["COLUMN_ID"].ToString() != hfColumnId.Value))
                {
                    ddlColumnOrder.Focus();
                    return "重覆的欄位項次, 請重新選擇, 謝謝!!";
                }
            }

            return null;
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            string strCheckMessage;
            try
            {
                hfColumnId.Value = "-1";
                if ((strCheckMessage = CheckImport()) != null)
                {
                    emcMsg.ShowErrorMessage(strCheckMessage);
                    return;
                }

                TB_COLUMN_STATE columnState = new TB_COLUMN_STATE();
                columnState.Value("PROJECT_SN", ddlProjectName.SelectedValue);
                columnState.Value("COLUMN_NAME", txtColumnName.Text);
                columnState.Value("DB_COLUMN_NAME", "CUSTOM_COLUMN" + ddlColumnOrder.Text);
                columnState.Value("CUS_COLUMN_ORDER", ddlColumnOrder.Text);
                columnState.Value("STS_INFO", ddlStsInfo.SelectedValue);
                columnState.Value("CREATE_DATE", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                columnState.Value("CREATE_USER", DataBuilder.GetCurrentUser().Value("USERID"));
                columnState.Value("MODIFY_DATE", null);
                columnState.Value("MODIFY_USER", null);
                if(columnState.ExecuteInsert() != true)
                    emcMsg.ShowErrorMessage(columnState.ErrorMessage);
            }
            catch (Exception ex)
            {
                emcMsg.ShowErrorMessage(ex.Message + "," + ex.StackTrace);
            }
            LoadProject();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string strCheckMessage;
            try
            {
                if ((hfColumnId.ID == "") || (hfColumnId.ID == "-1"))
                {
                    emcMsg.ShowErrorMessage("請選擇要修改的欄位, 謝謝!!");
                    return;
                }
                if ((strCheckMessage = CheckImport()) != null)
                {
                    emcMsg.ShowErrorMessage(strCheckMessage);
                    return;
                }

                TB_COLUMN_STATE columnState = new TB_COLUMN_STATE();
                columnState.Value("PROJECT_SN", ddlProjectName.SelectedValue);
                columnState.Value("COLUMN_NAME", txtColumnName.Text);
                columnState.Value("COLUMN_ID", hfColumnId.Value);
                columnState.Value("DB_COLUMN_NAME", "CUSTOM_COLUMN" + ddlColumnOrder.Text);
                columnState.Value("CUS_COLUMN_ORDER", ddlColumnOrder.Text);
                columnState.Value("STS_INFO", ddlStsInfo.SelectedValue);
                columnState.Value("CREATE_DATE", AbstractDataModel.NOT_CHANGE_VALUE);
                columnState.Value("CREATE_USER", AbstractDataModel.NOT_CHANGE_VALUE);
                columnState.Value("MODIFY_DATE", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                columnState.Value("MODIFY_USER", DataBuilder.GetCurrentUser().Value("USERID"));
                if (columnState.ExecuteUpdate() != true)
                    emcMsg.ShowErrorMessage(columnState.ErrorMessage);
            }
            catch (Exception ex)
            {
                emcMsg.ShowErrorMessage(ex.Message + "," + ex.StackTrace);
            }
            LoadProject();
        }

    }
}
