using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using INFOSERVICE.UserControl;

namespace APPGISMS.UserControl
{

    // </summary>
    // 撰寫人：Oliver
    // 撰寫日期：2010/04/23
    // 功能簡述：牙醫師院所資料明細
    // 修改人：
    // 修改日期：
    // </summary>
    public partial class Hospital_Detail : System.Web.UI.UserControl
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：頁面讀取
        // 修改人：
        // 修改日期：
        // </summary>
        protected void Page_Load(object sender, EventArgs e) { }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：牙醫師資料頁尾文字設定
        // 修改人：
        // 修改日期：
        // </summary>
        protected void gvHospitalDoctor_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int intCellCount = e.Row.Cells.Count;
                for (int i = intCellCount - 1; i >= 1; i -= 1)
                    e.Row.Cells.RemoveAt(i);
                e.Row.Cells[0].ColumnSpan = intCellCount;
                e.Row.Cells[0].Text = "*支援醫師不在此列";
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：醫師門診時間頁尾文字設定
        // 修改人：
        // 修改日期：
        // </summary>
        protected void gvHospitalDoctorTime_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int intCellCount = e.Row.Cells.Count;
                for (int i = intCellCount - 1; i >= 1; i -= 1)
                    e.Row.Cells.RemoveAt(i);
                e.Row.Cells[0].ColumnSpan = intCellCount;
                e.Row.Cells[0].Text = "依實際看診時間為準";
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：牙醫師資料分頁
        // 修改人：
        // 修改日期：
        // </summary>
        protected void gvHospitalDoctor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHospitalDoctor.PageIndex = e.NewPageIndex;
            gvHospitalDoctor.DataSource = (DataTable)ViewState["dtDoctor"];
            gvHospitalDoctor.DataBind();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：門診時間頁尾文字設定
        // 修改人：
        // 修改日期：
        // </summary>
        protected void gvHospitalTime_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int intCellCount = e.Row.Cells.Count;
                for (int i = intCellCount - 1; i >= 1; i -= 1)
                    e.Row.Cells.RemoveAt(i);
                e.Row.Cells[0].ColumnSpan = intCellCount;
                e.Row.Cells[0].Text = "該門診時間依診所內各醫師實際看診時間為準";
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得醫院詳細資訊
        // 修改人：Hilda
        // 修改日期：2012/04/30
        // </summary>
        public void getHospitalDetail(string strHospital_Id, string strUserID, string strD_H_Type)
        {
            ViewState["HOSPITAL_SN"] = "";
            Hospital_Detail_Service hds = new Hospital_Detail_Service();
            DataSet ds = hds.getHospitalDetail(strHospital_Id, strUserID, strD_H_Type);
            ViewState["HOSPITAL_SN"] = strHospital_Id;

            //醫院名稱
            lbHospital_Name.Text = ds.Tables[0].Rows[0]["HOSPITAL_NAME"].ToString();

            //詳細資料
            dtlHospital.DataSource = ds.Tables[0];
            dtlHospital.DataBind();
            //院所時間
            gvHospitalTime.DataSource = ds.Tables[1];
            gvHospitalTime.DataBind();
            //院所醫生
            ViewState["dtDoctor"] = ds.Tables[2];
            gvHospitalDoctor.DataSource = ds.Tables[2];
            gvHospitalDoctor.DataBind();

            //專案計畫
            ViewState["dtProject"] = ds.Tables[3];
            grvProject.DataSource = ds.Tables[3];
            grvProject.DataBind();
        }

        // </summary>
        // 撰寫人：Hilda
        // 撰寫日期：2011/10/11
        // 功能簡述：顯示醫師門診時間
        // 修改人：
        // 修改日期：
        // </summary>
        protected void gvHospitalDoctor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lbDoctor_Name.Text = "";

            if (e.CommandName == "Time")
            {
                
                int intRowIndex = Convert.ToInt32(e.CommandArgument);
                string strDoctor_Sn = gvHospitalDoctor.DataKeys[intRowIndex].Value.ToString();
                string strHospital_Sn = ViewState["HOSPITAL_SN"].ToString();
                string strDisplay = ((Label)gvHospitalDoctor.Rows[intRowIndex].Cells[4].FindControl("display")).Text;
                if (strDisplay == "1")//是否顯示詳細院所資料(1-是/0-否)
                {
                    Hospital_Detail_Service hds = new Hospital_Detail_Service();
                    DataSet dsTime = hds.getDoctor_Time(strHospital_Sn, strDoctor_Sn);
                    dlLanguageInfo_Doctor.DataSource = dsTime.Tables[1];
                    dlLanguageInfo_Doctor.DataBind();
                    grvTime_Doctor.DataSource = dsTime.Tables[0];
                    grvTime_Doctor.DataBind();

                    DataTable dtDoctor = (DataTable)ViewState["dtDoctor"];
                    DataRow[] drDoctor = dtDoctor.Select("DOCTOR_SN = '" + strDoctor_Sn + "'");
                    foreach (DataRow dr in drDoctor)
                    {
                        lbDoctor_Name.Text = dr["DOCTOR_NAME"].ToString();
                    }


                    mpeDoctor_Time.Show();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "", "<script language=\"javascript\" type=\"text/javascript\">alert(\"該醫師相關資訊，目前不提供公開檢視，不便之處請見諒!\");</script>", false);
                }
            }
        }

        // </summary>
        // 撰寫人：Hilda
        // 撰寫日期：2011/10/11
        // 功能簡述：設定是否顯示該醫師詳細資料(1-是/0-否)
        // 修改人：
        // 修改日期：
        // </summary>
        protected void gvHospitalDoctor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                string strDisplay = ((Label)e.Row.FindControl("display")).Text;

                if (strDisplay == "0")//是否顯示詳細院所資料(1-是/0-否)
                {
                    e.Row.Cells[2].Text = "--不公開--";
                }
            }
        }
    }
}