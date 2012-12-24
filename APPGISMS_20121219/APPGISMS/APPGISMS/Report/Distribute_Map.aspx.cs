using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using INFOSERVICE.Report;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using CommonClass;

namespace APPGISMS.Report
{
    public partial class Distribute_Map : System.Web.UI.Page
    {
        private static string strUser;
        private MapControlLibrary _mapControlLibrary;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //判斷是否正常登入
                if (Session["strKey"] == null || Session["strUser_Id"] == null)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "", "<script language=\"javascript\" type=\"text/javascript\">alert(\"由於您未執行任何瀏覽動作已逾時10分鐘，故系統已自動為您登出網站，以確保安全。\");window.opener = null;window.open('', '_parent', '');window.close();window.open='http://gis.cda.org.tw/GIS/InitPage.aspx';</script>", false);

                    Page.Session.Clear();

                    return;
                }

                //判斷是否正常登入
                if (!LimitValidator.checkUserIsLogin(Page, Session["strUser_Id"].ToString(), Request.QueryString["FUN_ID"].ToString()))
                    Response.Redirect(LimitValidator.strErrorPageUrl);


                //登入人員
                strUser = Session["strUser_Id"].ToString();

                getddlYearly();
                ddlYearly.DataBind();
                ddlYearly.Items.Insert(0, new ListItem("請選擇", "NoChoose")); //插入一個資料項目，位置為"0"，名稱為"請選擇"，值為"NoChoose"
                ddlYearly.SelectedIndex = 0;

                getddlArea();
                ddlArea_Info.Items.Insert(0, new ListItem("請選擇", "NoChoose")); //插入一個資料項目，位置為"0"，名稱為"請選擇"，值為"NoChoose"
                ddlArea_Info.SelectedIndex = 0;

                ddlCounty_Info.Items.Insert(0, new ListItem("請選擇", "NoChoose")); //插入一個資料項目，位置為"0"，名稱為"請選擇"，值為"NoChoose"
                ddlCounty_Info.SelectedIndex = 0;

                MapArea.Visible = false;
            }
        }

        protected void btnQuery_OnClick(object sender, EventArgs e)
        {
            if (ddlYearly.SelectedItem.Value == "NoChoose")
            {
                //emcMsg.ShowErrorMessage("請選擇年度");
                return;
            }
            if (ddlArea_Info.SelectedItem.Value == "NoChoose")
            {
                //emcMsg.ShowErrorMessage("請選擇分區");
                return;
            }
            if (ddlCounty_Info.SelectedItem.Value == "NoChoose")
            {
                //emcMsg.ShowErrorMessage("請選擇縣市");
                return;
            }


            MapArea.Visible = true;
            string strFilename = getImageMap();
            
            MapArea.ImageUrl = "~/ASPImages/" + strFilename;

            grvDistribute.DataSource = getgrvDistribute();
            grvDistribute.DataBind();
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

        // </summary>
        // 撰寫人：Jacky
        // 撰寫日期：2011/02/26
        // 功能簡述：(下拉式選單)分區資料擷取
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        protected DataSet getddlArea()
        {
            DataSet ds = new DataSet();
            if (ViewState["ddlArea"] == null)
            {
                Distribute_Map_Service DMS = new Distribute_Map_Service();
                ds = DMS.getddlArea();
            }
            else
            {
                ds = (DataSet)ViewState["ddlArea"];
            }
            return ds;
        }

        // </summary>
        // 撰寫人：Jacky
        // 撰寫日期：2011/02/26
        // 功能簡述：(下拉式選單)年度資料擷取
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getddlYearly()
        {
            DataSet ds = new DataSet();
            if (ViewState["ddlYearly"] == null)
            {
                Distribute_Map_Service DMS = new Distribute_Map_Service();
                ds = DMS.getddlYearly();
            }
            else
            {
                ds = (DataSet)ViewState["ddlYearly"];
            }
            return ds;
        }

        // </summary>
        // 撰寫人：Jacky
        // 撰寫日期：2011/02/26
        // 功能簡述：(下拉式選單)縣市資料擷取
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public DataSet getddlCounty(string strDataYear, string strArea)
        {
            DataSet ds = new DataSet();
            Distribute_Map_Service DMS = new Distribute_Map_Service();
            ds = DMS.getddlCounty(strDataYear, strArea);
            return ds;
        }

        protected void ddlYearly_SelectedIndexChanged(object sender, EventArgs e)
        {
            //getddlArea();
            ddlArea_Info.DataBind();
            ddlArea_Info.Items.Insert(0, new ListItem("請選擇", "NoChoose")); //插入一個資料項目，位置為"0"，名稱為"請選擇"，值為"NoChoose"
            ddlArea_Info.SelectedIndex = 0;
            ddlCounty_Info.Visible = false;
        }

        protected void ddlArea_Click(object sender, EventArgs e)
        {
            ddlCounty_Info.DataSource = getddlCounty(ddlYearly.SelectedValue.ToString(), ddlArea_Info.SelectedValue.ToString());
            ddlCounty_Info.DataBind();
            ddlCounty_Info.Items.Insert(0, new ListItem("請選擇", "NoChoose")); //插入一個資料項目，位置為"0"，名稱為"請選擇"，值為"NoChoose"
            ddlCounty_Info.SelectedIndex = 0;
            ddlCounty_Info.Visible = true;
        }

        protected string getImageMap()
        {
            _mapControlLibrary = new MapControlLibrary();
            //_mapControlLibrary.strDataYear = ddlYearly.SelectedValue.ToString();
            _mapControlLibrary.Init_mapini(ddlYearly.SelectedValue.ToString());
            _mapControlLibrary.ReportImagePath = Server.MapPath("~") + @"\ReportImages";
            _mapControlLibrary.ASPImagePath = Server.MapPath("~") + @"\ASPImages";
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

            return _mapControlLibrary.SaveASPImage(ddlCounty_Info.SelectedValue.ToString(), ddlYearly.SelectedValue.ToString(), blSchoolChk, blHospialChk);
        }

        protected void btnExpand_Click(object sender, EventArgs e)
        {
            if (ddlYearly.SelectedItem.Value == "NoChoose")
            {
                //emcMsg.ShowErrorMessage("請選擇年度");
                return;
            }
            if (ddlArea_Info.SelectedItem.Value == "NoChoose")
            {
                //emcMsg.ShowErrorMessage("請選擇分區");
                return;
            }
            if (ddlCounty_Info.SelectedItem.Value == "NoChoose")
            {
                //emcMsg.ShowErrorMessage("請選擇縣市");
                return;
            }


            string strFilename = getImageMap();

            string strFilePath = HttpContext.Current.Server.MapPath("~/ASPImages/" + strFilename).ToString();

            Response.ClearHeaders();
            Response.Clear();
            Response.AddHeader("Accept-Language", "zh-tw");
            Response.AddHeader("content-disposition", "attachment; filename=" + strFilename);
            Response.ContentType = "application/vnd.text";
            Response.TransmitFile(strFilePath);
            Response.Flush();
            Response.End();
        }

        protected void grvDistribute_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strColor = ((Label)e.Row.Cells[5].Controls[1]).Text;
                if (strColor != "")
                {
                    e.Row.Cells[4].BackColor = Color.FromArgb(int.Parse(strColor, System.Globalization.NumberStyles.HexNumber));
                    e.Row.Cells[4].ForeColor = Color.FromArgb(int.Parse("000000", System.Globalization.NumberStyles.HexNumber));
                }
                
            }
        }
    }
}
