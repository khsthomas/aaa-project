using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YEZZ;
using YEZZ.Model;
using System.Data;
using System.Drawing;

namespace APPGISMS.Project
{
    public partial class Project_Layer_Info : System.Web.UI.Page
    {
        private const int COLOR_COLUMN_INDEX = 9;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBuilder.FillProjectName(ddlProjectName);
                DataBuilder.FillStsInfo(ddlStsInfo);
                DataBuilder.FillFormulaName(ddlFormulaName, ddlProjectName.SelectedValue);
                DataBuilder.FillDefinition(ddlDefinition);
                lblFormulaName.Text = ddlFormulaName.SelectedItem.Text;
            }
        }

        private void LoadLayerColor()
        {
            string strSQL = "SELECT a.PROJECT_SN, b.PROJECT_NAME, a.FORMULA_ID, c.FORMULA_NAME, a.STS_INFO, a.LAYER_TYPE, a.LAYER_COLOR, a.LAYER_START, a.LAYER_END, a.LAYER_DEFINITION, a.LAYER_REMARK " +
                            "  FROM " + SystemConstants.DATABASE_CATALOG + ".dbo.TB_LAYER_COLOR a, " + SystemConstants.DATABASE_CATALOG + ".dbo.TB_PROJECT_INFO b, " + SystemConstants.DATABASE_CATALOG + ".dbo.TB_PROJECT_FORMULA c " +
                            " WHERE a.PROJECT_SN = b.PROJECT_SN " +
                            "   AND a.PROJECT_SN = c.PROJECT_SN " +
                            "   AND a.FORMULA_ID = c.FORMULA_ID " +
                            "   AND a.PROJECT_SN = @PROJECT_SN ";
            List<IDataModel> lstLayerColor = (new TB_LAYER_COLOR()).Query<IDataModel>(strSQL,
                                                                                      new string[] { "PROJECT_SN" },
                                                                                      new string[] { ddlProjectName.SelectedValue });

            DataBuilder.FillFormulaName(ddlFormulaName, ddlProjectName.SelectedValue);            
            DataTable tblFormula = new DataTable();
            DataRow dataRow = null;

            tblFormula.Columns.Add("Edit", typeof(string));
            tblFormula.Columns.Add("PROJECT_NAME", typeof(string));
            tblFormula.Columns.Add("PROJECT_SN", typeof(string));
            tblFormula.Columns.Add("FORMULA_NAME", typeof(string));
            tblFormula.Columns.Add("FORMULA_ID", typeof(string));
            tblFormula.Columns.Add("LAYER_TYPE", typeof(string));
            tblFormula.Columns.Add("LAYER_COLOR", typeof(string));
            tblFormula.Columns.Add("STS_INFO", typeof(string));
            tblFormula.Columns.Add("LAYER_REMARK", typeof(string));
            tblFormula.Columns.Add("LAYER_START", typeof(string));
            tblFormula.Columns.Add("LAYER_END", typeof(string));
            tblFormula.Columns.Add("LAYER_DEFINITION", typeof(string));

            for (int i = 0; i < lstLayerColor.Count; i++)
            {
                dataRow = tblFormula.NewRow();

                dataRow["Edit"] = "編輯";
                dataRow["PROJECT_NAME"] = lstLayerColor[i].Value("PROJECT_NAME").ToString();
                dataRow["PROJECT_SN"] = lstLayerColor[i].Value("PROJECT_SN").ToString();
                dataRow["FORMULA_NAME"] = lstLayerColor[i].Value("FORMULA_NAME").ToString();
                dataRow["FORMULA_ID"] = lstLayerColor[i].Value("FORMULA_ID").ToString();
                dataRow["LAYER_TYPE"] = lstLayerColor[i].Value("LAYER_TYPE").ToString();
                dataRow["LAYER_COLOR"] = lstLayerColor[i].Value("LAYER_COLOR").ToString();
                dataRow["STS_INFO"] = DataBuilder.StsText(lstLayerColor[i].Value("STS_INFO").ToString());
                dataRow["LAYER_REMARK"] = lstLayerColor[i].Value("LAYER_REMARK").ToString();
                dataRow["LAYER_START"] = lstLayerColor[i].Value("LAYER_START").ToString();
                dataRow["LAYER_END"] = lstLayerColor[i].Value("LAYER_END").ToString();
                dataRow["LAYER_DEFINITION"] = lstLayerColor[i].Value("LAYER_DEFINITION").ToString();

                tblFormula.Rows.Add(dataRow);
            }

            tblProjectFormula.DataSource = tblFormula;
            tblProjectFormula.DataBind();

            ViewState["CurrentTable"] = tblFormula;            
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            LoadLayerColor();
        }

        private string CheckImport()
        {
            if (ViewState["CurrentTable"] == null)
                return null;

            DataTable tblData = (DataTable)ViewState["CurrentTable"];
            DataRow dataRow = null;

            for (int i = 0; i < tblData.Rows.Count; i++)
            {
                dataRow = tblData.Rows[i];

                if ((dataRow["FORMULA_ID"].ToString() == ddlFormulaName.SelectedValue) && 
                    (dataRow["LAYER_TYPE"].ToString() == txtLayerType.Text) && 
                    (int.Parse(hfRowIndex.Value) != i))
                {
                    txtLayerType.Focus();
                    return "該公式的圖層狀態重覆, 請重新輸入, 謝謝!!";
                }
                /*
                                if ((dataRow["CUS_COLUMN_ORDER"].ToString() == ddlColumnOrder.SelectedValue) && (dataRow["COLUMN_ID"].ToString() != hfColumnId.Value))
                                {
                                    ddlColumnOrder.Focus();
                                    return "重覆的欄位項次, 請重新選擇, 謝謝!!";
                                }
                 */ 
            }

            return null;
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            string strCheckMessage;
            try
            {
                hfRowIndex.Value = "-1";
                if ((strCheckMessage = CheckImport()) != null)
                {
                    emcMsg.ShowErrorMessage(strCheckMessage);
                    return;
                }

                TB_LAYER_COLOR layerColor = new TB_LAYER_COLOR();
                layerColor.Value("PROJECT_SN", ddlProjectName.SelectedValue);
                layerColor.Value("FORMULA_ID", ddlFormulaName.SelectedValue);
                layerColor.Value("STS_INFO", ddlStsInfo.SelectedValue);
                layerColor.Value("LAYER_TYPE", txtLayerType.Text);
                layerColor.Value("LAYER_COLOR", txtLayerColor.Text);
                layerColor.Value("LAYER_START", txtStart.Text);
                layerColor.Value("LAYER_END", txtEnd.Text);
                layerColor.Value("LAYER_DEFINITION", ddlDefinition.SelectedValue);
                layerColor.Value("LAYER_REMARK", txtLayerRemark.Text);
                layerColor.Value("CREATE_DATE", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                layerColor.Value("CREATE_USER", DataBuilder.GetCurrentUser().Value("USERID"));
                layerColor.Value("MODIFY_DATE", null);
                layerColor.Value("MODIFY_USER", null);
                if (layerColor.ExecuteInsert() != true)
                    emcMsg.ShowErrorMessage(layerColor.ErrorMessage);
            }
            catch (Exception ex)
            {
                emcMsg.ShowErrorMessage(ex.Message + "," + ex.StackTrace);
            }
            LoadLayerColor();            
        }

        protected void tblProjectFormula_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (ViewState["CurrentTable"] == null)
                return;

            DataTable tblColumn = (DataTable)ViewState["CurrentTable"];
            DataRow dataRow = tblColumn.Rows[e.NewEditIndex];

            ddlProjectName.SelectedValue = dataRow["PROJECT_SN"].ToString();
            ddlStsInfo.SelectedValue = DataBuilder.StsValue(dataRow["STS_INFO"].ToString());
            txtLayerType.Text = dataRow["LAYER_TYPE"].ToString();
            ddlFormulaName.SelectedValue = dataRow["FORMULA_ID"].ToString();
            lblFormulaName.Text = dataRow["FORMULA_NAME"].ToString(); 
            txtLayerRemark.Text = dataRow["LAYER_REMARK"].ToString();
            txtStart.Text = dataRow["LAYER_START"].ToString();
            txtEnd.Text = dataRow["LAYER_END"].ToString();
            ddlDefinition.SelectedValue = dataRow["LAYER_DEFINITION"].ToString();
            txtLayerColor.Text = dataRow["LAYER_COLOR"].ToString();
            txtLayerColor.BackColor = Color.FromName("#" + txtLayerColor.Text);
            hfRowIndex.Value = e.NewEditIndex.ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string strCheckMessage;
            try
            {
                if (hfRowIndex.Value == "")
                {
                    emcMsg.ShowErrorMessage("請選擇要修改的圖層狀態, 謝謝!!");
                    return;
                }

                if (int.Parse(hfRowIndex.Value) < 0)
                {
                    emcMsg.ShowErrorMessage("請選擇要修改的圖層狀態, 謝謝!!");
                    return;
                }

                if ((strCheckMessage = CheckImport()) != null)
                {
                    emcMsg.ShowErrorMessage(strCheckMessage);
                    return;
                }

                TB_LAYER_COLOR layerColor = new TB_LAYER_COLOR();
                layerColor.Value("PROJECT_SN", ddlProjectName.SelectedValue);
                layerColor.Value("FORMULA_ID", ddlFormulaName.SelectedValue);
                layerColor.Value("STS_INFO", ddlStsInfo.SelectedValue);
                layerColor.Value("LAYER_TYPE", txtLayerType.Text);
                layerColor.Value("LAYER_COLOR", txtLayerColor.Text);
                layerColor.Value("LAYER_START", txtStart.Text);
                layerColor.Value("LAYER_END", txtEnd.Text);
                layerColor.Value("LAYER_DEFINITION", ddlDefinition.SelectedValue);
                layerColor.Value("LAYER_REMARK", txtLayerRemark.Text);
                layerColor.Value("CREATE_DATE", AbstractDataModel.NOT_CHANGE_VALUE);
                layerColor.Value("CREATE_USER", AbstractDataModel.NOT_CHANGE_VALUE);
                layerColor.Value("MODIFY_DATE", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                layerColor.Value("MODIFY_USER", DataBuilder.GetCurrentUser().Value("USERID"));

                if (layerColor.ExecuteUpdate() != true)
                    emcMsg.ShowErrorMessage(layerColor.ErrorMessage);
            }
            catch (Exception ex)
            {
                emcMsg.ShowErrorMessage(ex.Message + "," + ex.StackTrace);
            }
            LoadLayerColor();
        }

        protected void ddlFormulaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFormulaName.Text = ddlFormulaName.SelectedItem.Text;
        }

        protected void txtLayerColor_TextChanged(object sender, EventArgs e)
        {
            txtLayerColor.BackColor = Color.FromName("#" + txtLayerColor.Text);
        }        
/*
        protected void tblProjectFormula_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            
            DataTable tblData = (DataTable)ViewState["CurrentTable"];
            if(tblData == null)
                return;

            e.Row.Cells[COLOR_COLUMN_INDEX].BackColor = (Color)tblData.Rows[e.Row.RowIndex]["LAYER_COLOR"];
        }
 */ 
    }
}
