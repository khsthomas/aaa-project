﻿using System;
using System.Data;
using System.Web.UI.WebControls;
using INFOSERVICE.SearchPage;

namespace APPGISMS.SearchPage
{
    // </summary>
    // 撰寫人：Oliver
    // 撰寫日期：2010/04/23
    // 功能簡述：牙醫師資料查詢
    // 修改人：
    // 修改日期：
    // </summary>
    public partial class Search_Doctor : System.Web.UI.Page
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：頁面讀取
        // 修改人：
        // 修改日期：
        // </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCounty_Info.DataBind();
                ddlCounty_Info.Items.Insert(0, new ListItem("全部縣市", "NoChoose"));
                ddlTown_Info.Items.Add(new ListItem("全部鄉鎮市區", "NoChoose"));
            }
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：選擇縣市
        // 修改人：
        // 修改日期：
        // </summary>
        protected void ddlCounty_Info_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTown_Info.Items.Clear();
            if (ddlCounty_Info.SelectedValue == "NoChoose")
            {
                ddlTown_Info.Items.Add(new ListItem("全部鄉鎮市區", "NoChoose"));
                ddlTown_Info.Enabled = false;
            }
            else
            {
                Search_Doctor_Service sds = new Search_Doctor_Service();
                ddlTown_Info.DataSource = sds.getTownInfo(ddlCounty_Info.SelectedValue);
                ddlTown_Info.DataBind();
                ddlTown_Info.Items.Insert(0, new ListItem("全部鄉鎮市區", "NoChoose"));
                ddlTown_Info.Enabled = true;
            }
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：查詢院所資料
        // 修改人：
        // 修改日期：
        // </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ViewState["strType"] = ddlQuery_Type.SelectedItem.Value;
            ViewState["strCounty"] = ddlCounty_Info.SelectedItem.Value;
            ViewState["strTown"] = ddlTown_Info.SelectedItem.Value;
            ViewState["strQuery"] = txtQuery.Text;

            tcDoctor.ActiveTab = tpDoctor_List;
            gvDoctor.PageIndex = 0;
            panTitle.Visible = true;

            getDoctorData(ddlQuery_Type.SelectedItem.Value, ddlCounty_Info.SelectedItem.Value, ddlTown_Info.SelectedItem.Value, txtQuery.Text);
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：頁尾橫跨欄位
        // 修改人：
        // 修改日期：
        // </summary>
        protected void gvDoctor_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                int intCellCount = e.Row.Cells.Count;
                for (int i = intCellCount - 1; i >= 1; i -= 1)
                    e.Row.Cells.RemoveAt(i);
                e.Row.Cells[0].ColumnSpan = intCellCount - 2;
            }
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：設定定位方式與頁尾文字
        // 修改人：
        // 修改日期：
        // </summary>
        protected void gvDoctor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btnPosition = (LinkButton)e.Row.Cells[4].Controls[0];
                string strHospital_Name = e.Row.Cells[0].Text;
                string strHospital_X = ((Label)e.Row.FindControl("lblX")).Text;
                string strHospital_Y = ((Label)e.Row.FindControl("lblY")).Text;

                if (btnPosition != null && strHospital_X != "")
                    btnPosition.OnClientClick = "positionXY(" + strHospital_X + "," + strHospital_Y + ");";
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "第 " + (gvDoctor.PageIndex + 1).ToString() + " 頁 / 共 " + gvDoctor.PageCount.ToString() + " 頁";
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Right;
            }
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：牙醫師資料分頁
        // 修改人：
        // 修改日期：
        // </summary>
        protected void gvDoctor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDoctor.PageIndex = e.NewPageIndex;
            getDoctorData();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：顯示院所明細
        // 修改人：
        // 修改日期：
        // </summary>
        protected void gvHospital_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detail")
            {
                tp_Hospital_Info.Enabled = true;
                tcDoctor.ActiveTab = tp_Hospital_Info;

                int intRowIndex = Convert.ToInt32(e.CommandArgument);
                string strHospital_Id = gvDoctor.DataKeys[intRowIndex].Value.ToString();
                hdDoctor.getHospitalDetail(strHospital_Id);
                upTab.Update();
            }
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得縣市資料內容
        // 修改人：
        // 修改日期：
        // </summary>
        protected DataSet getCountyInfo()
        {
            Search_Doctor_Service sds = new Search_Doctor_Service();
            return sds.getCountyInfo();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得牙醫師資料
        // 修改人：
        // 修改日期：
        // </summary>
        public void getDoctorData()
        {
            string strType = ViewState["strType"].ToString();
            string strCounty = ViewState["strCounty"].ToString();
            string strTown = ViewState["strTown"].ToString();
            string strQuery = ViewState["strQuery"].ToString();
            getDoctorData(strType, strCounty, strTown, strQuery);
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得牙醫師資料
        // 修改人：
        // 修改日期：
        // </summary>
        public void getDoctorData(string strType, string strCounty, string strTown, string strQuery)
        {
            Search_Doctor_Service sds = new Search_Doctor_Service();
            gvDoctor.DataSource = sds.getDoctorInfo(strType, strCounty, strTown, strQuery);
            gvDoctor.DataBind();
        }
    }
}