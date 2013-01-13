using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YEZZ;
using System.Data;
using INFOSERVICE.Report;
using YEZZ.Model;
using System.Drawing;

namespace APPGISMS.Project
{
    public partial class Project_Report : System.Web.UI.Page
    {
        private MapControlLibrary _mapControlLibrary;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBuilder.FillProjectName(ddlProjectName, true);                
                DataBuilder.FillFormulaName(ddlFormulaName, ddlProjectName.SelectedValue, true);
                DataBuilder.FillDataYear(ddlYearly, true);
                DataBuilder.FillArea(ddlArea_Info, true);
                DataBuilder.FillCountry(ddlCounty_Info, ddlYearly.SelectedValue, ddlArea_Info.SelectedValue, true);
                MapArea.Visible = false;
            }
        }

        protected void ddlProjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBuilder.FillFormulaName(ddlFormulaName, ddlProjectName.SelectedValue, true);
        }

        protected string getImageMap()
        {
            _mapControlLibrary = new MapControlLibrary();
            _mapControlLibrary.Init_mapini(ddlYearly.SelectedValue.ToString());
            _mapControlLibrary.ReportImagePath = Server.MapPath("~") + @"\ReportImages";
            _mapControlLibrary.ASPImagePath = Server.MapPath("~") + @"\ASPImages";

            if (ViewState["formulaValue"] != null)
                SetTownColor(_mapControlLibrary);

            bool blSchoolChk = false;
            bool blHospialChk = false;
            foreach (ListItem li in cblDispaly.Items)
            {
                if (li.Selected)
                {
                    switch (li.Value)
                    {
                        case "0":
                            blSchoolChk = true;
                            break;
                        case "1":
                            blHospialChk = true;
                            break;
                    }
                }
            }

            return _mapControlLibrary.SaveASPImage(ddlCounty_Info.SelectedValue.ToString(), 
                                                   ddlYearly.SelectedValue.ToString(), 
                                                   blSchoolChk, 
                                                   blHospialChk);
        }


        protected void btnQuery_Click(object sender, EventArgs e)
        {
            if (ddlProjectName.SelectedItem.Value == "NoChoose")
            {
                emcMsg.ShowErrorMessage("請選擇專案名稱");
                return;
            }
            if (ddlFormulaName.SelectedItem.Value == "NoChoose")
            {
                emcMsg.ShowErrorMessage("請選擇公式名稱");
                return;
            }

            if (ddlYearly.SelectedItem.Value == "NoChoose")
            {
                emcMsg.ShowErrorMessage("請選擇年度");
                return;
            }
            if ((ddlArea_Info.SelectedItem.Value == "NoChoose") && ((bool)ViewState["displayArea"]))
            {
                emcMsg.ShowErrorMessage("請選擇分區");
                return;
            }
            if ((ddlCounty_Info.SelectedItem.Value == "NoChoose") && ((bool)ViewState["displayCounty"]))
            {
                emcMsg.ShowErrorMessage("請選擇縣市");
                return;
            }


            MapArea.Visible = true;
            
            string strFilename = getImageMap();
            tblDistribute.DataSource = (ViewState["formulaValue"] == null) ? getgrvDistribute() : createDistribute();
            MapArea.ImageUrl = "~/ASPImages/" + strFilename;            
            tblDistribute.DataBind();
        }

        private void SetTownColor(MapControlLibrary mapControlLibrary)
        {
            try
            {
                string[] strFields = ViewState["formulaValue"].ToString().Split(new char[] {'+', '-', '*', '/'});
                string[] strOperators = ViewState["formulaValue"].ToString().Split(']');

                for (int i = 0; i < strOperators.Length; i++)
                {
                    if ((strOperators[i].Trim().Length > 0) && (!strOperators[i].Trim().StartsWith("[")))
                        strOperators[i] = strOperators[i].Trim().Substring(0, 1);
                    else
                        strOperators[i] = "";
                }

                string strFormulaValue = "";
                string strFormulaTable = "";
                string strCondition = "";
/*
                for (int i = 0; i < strFields.Length; i++)
                {
                    strFormulaValue += strOperators[i] + 
                                       (strFields[i].IndexOf(',') > -1
                                       ? "CAST(" + Convert.ToChar(i + Convert.ToInt16('a')) + ".FIELD_COUNT AS float)" 
                                       : "CAST(" + strFields[i] + " AS float)");
                    if(strFields[i].IndexOf(',') > -1)
                        strFormulaTable += DataMapping.FormulaToSql(strFields[i]) + " " + Convert.ToChar(i + Convert.ToInt16('a')) + ",";                    
                }
*/
                for (int i = 0; i < strFields.Length; i++)
                {
                    strFormulaValue += strOperators[i] + "CAST(" + Convert.ToChar(i + Convert.ToInt16('a')) + ".FIELD_COUNT AS float)";
                    strFormulaTable += DataMapping.FormulaToSql(strFields[i]) + " " + Convert.ToChar(i + Convert.ToInt16('a')) + ",";
                }

/*
                for(int i = 0; i < strFields.Length - 1; i++)
                {
                    if (strFields[i].IndexOf(',') < 0)
                        continue;
                    for (int j = i + 1; j < strFields.Length; j++)
                    {
                        if (strFields[j].IndexOf(',') < 0)
                            continue;

                        strCondition += " AND " + Convert.ToChar(i + Convert.ToInt16('a')) + ".GROUP_ID = " + Convert.ToChar(j + Convert.ToInt16('a')) + ".GROUP_ID ";
                    }
                }
*/
                for (int i = 0; i < strFields.Length - 1; i++)
                {
                    for (int j = i + 1; j < strFields.Length; j++)
                    {
                        strCondition += " AND " + Convert.ToChar(i + Convert.ToInt16('a')) + ".GROUP_ID = " + Convert.ToChar(j + Convert.ToInt16('a')) + ".GROUP_ID ";
                    }
                }
                string strSQL = "SELECT a.GROUP_ID, " + strFormulaValue + " AS FORMULA_VALUE FROM " +
                                strFormulaTable.Substring(0, strFormulaTable.Length - 1) +
                                " WHERE " + strCondition.Substring(" AND ".Length);

                List<IDataModel> lstFormula = (new TB_LAYER_COLOR()).Query<IDataModel>(new string[] { "PROJECT_SN", "FORMULA_ID"},
                                                                                       new string[] { ddlProjectName.SelectedValue, ddlFormulaName.SelectedValue});

                List<IDataModel> lstGroup = (new DefaultDataModel()).Query<IDataModel>(strSQL, new string[] {"PROJECT_SN"}, new string[] {ddlProjectName.SelectedValue});
                Dictionary<string, Color> dicTownColor = new Dictionary<string, Color>();

                for (int i = 0; i < lstGroup.Count; i++)
                {
                    for (int j = 0; j < lstFormula.Count; j++)
                    {
                        if (double.Parse(lstGroup[i].Value("FORMULA_VALUE").ToString()) >= double.Parse(lstFormula[j].Value("LAYER_START").ToString()) &&
                            double.Parse(lstGroup[i].Value("FORMULA_VALUE").ToString()) < double.Parse(lstFormula[j].Value("LAYER_END").ToString()))
                        {
                            if(dicTownColor.ContainsKey(lstGroup[i].Value("GROUP_ID").ToString()))
                            {
                                dicTownColor[lstGroup[i].Value("GROUP_ID").ToString()] = 
                                                 Color.FromName("#" + lstFormula[j].Value("LAYER_COLOR").ToString());
                            }
                            else
                            {
                                dicTownColor.Add(lstGroup[i].Value("GROUP_ID").ToString(),
                                                 Color.FromName("#" + lstFormula[j].Value("LAYER_COLOR").ToString()));
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                emcMsg.ShowErrorMessage(ex.Message + "," + ex.StackTrace);
            }
        }

        private DataSet createDistribute()
        {
            DataSet returnSet = new DataSet();
            int iFormulaLevel = DataMapping.ALL_LEVEL;
            int iDataLevel = DataMapping.COUNTY_LEVEL;

            if(ViewState["formulaLevel"] == null)
            {
                emcMsg.ShowErrorMessage("請選擇公式名稱");
                return null;
            }

            if(ViewState["formulaValue"] == null)
            {
                iFormulaLevel = DataMapping.COUNTY_LEVEL;
                iDataLevel = DataMapping.TOWN_LEVEL;
            }
            else
            {
                switch ((int)ViewState["formulaLevel"])
                {
                    case DataMapping.ALL_LEVEL:
                        iDataLevel = DataMapping.COUNTY_LEVEL;
                        break;
                    case DataMapping.AREA_LEVEL:
                        iDataLevel = DataMapping.COUNTY_LEVEL;
                        break;
                    case DataMapping.COUNTY_LEVEL:
                        iDataLevel = DataMapping.TOWN_LEVEL;
                        break;
                }
                iFormulaLevel = (int)ViewState["formulaLevel"];
            }
            string strSQL = DataMapping.ProjectBRSql(iFormulaLevel, iDataLevel);

            List<IDataModel> lstDistribute = (new DefaultDataModel()).Query<IDataModel>(strSQL,
                                                                                        new string[] { "DATA_YEAR", "COUNTY_AREA", "COUNTY_NO"},
                                                                                        new string[] { ddlYearly.SelectedValue, ddlArea_Info.SelectedValue, ddlCounty_Info.SelectedValue});



            return returnSet;


        }

        // </summary>
        // 撰寫人：Jacky
        // 撰寫日期：2011/02/26
        // 功能簡述：grid資料擷取
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        protected DataSet getgrvDistribute()
        {
            Distribute_Map_Service DMS = new Distribute_Map_Service();
            return DMS.getgrvDistribute(ddlYearly.SelectedValue.ToString(), ddlArea_Info.SelectedValue.ToString(), ddlCounty_Info.SelectedValue.ToString());
        }


        protected void btnExpand_Click(object sender, EventArgs e)
        {

        }

        protected void ddlYearly_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProjectName.SelectedItem.Value == "NoChoose")
            {
                emcMsg.ShowErrorMessage("請選擇專案名稱");
                return;
            }
            if (ddlFormulaName.SelectedItem.Value == "NoChoose")
            {
                emcMsg.ShowErrorMessage("請選擇公式名稱");
                return;
            }
            DataBuilder.FillArea(ddlArea_Info);
            ddlCounty_Info.Visible = false;
        }

        protected void ddlArea_Info_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProjectName.SelectedItem.Value == "NoChoose")
            {
                emcMsg.ShowErrorMessage("請選擇專案名稱");
                return;
            }
            if (ddlFormulaName.SelectedItem.Value == "NoChoose")
            {
                emcMsg.ShowErrorMessage("請選擇公式名稱");
                return;
            }
            DataBuilder.FillCountry(ddlCounty_Info, ddlYearly.SelectedValue, ddlArea_Info.SelectedValue);
            ddlCounty_Info.Visible = (ViewState["displayCounty"] == null ? true : (bool)ViewState["displayCounty"]);
        }

        protected void ddlFormulaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            TB_PROJECT_FORMULA formula = DataBuilder.GetFormulaDetail(ddlProjectName.SelectedValue, ddlFormulaName.SelectedValue);
            object oFormulaValue = formula.Value("FORMULA_VALUE");

            ddlArea_Info.Visible = false;
            ddlCounty_Info.Visible = false;
            ViewState["formulaValue"] = null;
            ViewState["formulaLevel"] = DataMapping.ALL_LEVEL;

            if (oFormulaValue == null)
                return;

            if (oFormulaValue.ToString().IndexOf("HOSPITAL_AREA") > -1)
            {                
                ddlArea_Info.Visible = true;
                ddlCounty_Info.Visible = false;
                ViewState["formulaLevel"] = DataMapping.AREA_LEVEL;
                DataBuilder.FillArea(ddlArea_Info, true);                
            }
            else if (oFormulaValue.ToString().IndexOf("HOSPITAL_COUNTY") > -1)
            {                
                ddlArea_Info.Visible = true;
                ddlCounty_Info.Visible = true;
                ViewState["formulaLevel"] = DataMapping.COUNTY_LEVEL;
                DataBuilder.FillArea(ddlArea_Info, true);
                DataBuilder.FillCountry(ddlCounty_Info, ddlYearly.SelectedValue, ddlArea_Info.SelectedValue, true);
            }
            ViewState["displayArea"] = false;
            ViewState["displayCounty"] = false;
            ViewState["formulaValue"] = oFormulaValue.ToString();

        }
    }
}
