using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

using INFOSERVICE.UserControl;


namespace APPGISMS.UserControl
{
    public partial class Activity_List : System.Web.UI.UserControl
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
                getActivity_List();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：顯示公告內容
        // 修改人：
        // 修改日期：
        // </summary>
        protected void grvActivity_List_RowCommand(object sender, GridViewCommandEventArgs e)
        { 
            string strAnn_Id = e.CommandArgument.ToString();
            //編號 
            Session["Activity_Sn"] = strAnn_Id;
            switch (e.CommandName)
            {
                case "Content": 
                    getActivity_ListContent(strAnn_Id);
                    panContent_Title.Visible = true;
                    break;
                case "btnRegis_Click":
                    Response.Redirect("~/Activity/Registration_Operations.aspx?DoorType=D");
                    break;
            }
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：公告分頁
        // 修改人：
        // 修改日期：
        // </summary>
        protected void grvActivity_List_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvActivity_List.PageIndex = e.NewPageIndex;
            getActivity_List();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：設定內容顯示狀況
        // 修改人：
        // 修改日期：
        // </summary>
        protected void dtActivity_List_DataBound(object sender, EventArgs e)
        {
            dtAnncoune.Rows[7].Cells[1].Text = dtAnncoune.Rows[7].Cells[1].Text.Replace("\n", "<BR>");
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得公告資訊
        // 修改人：
        // 修改日期：
        // </summary>
        private void getActivity_List()
        {
            Activity_List_Service anns = new Activity_List_Service();
            grvActivity_List.DataSource = anns.getActivity_List();
            grvActivity_List.DataBind();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得公告內容
        // 修改人：
        // 修改日期：
        // </summary>
        private void getActivity_ListContent(string strAnn_Id)
        {
            Activity_List_Service anns = new Activity_List_Service();
            dtAnncoune.DataSource = anns.getActivity_ListContent(strAnn_Id);
            dtAnncoune.DataBind();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：顯示公告內容
        // 修改人：
        // 修改日期：
        // </summary>
        protected void getActivity_ListContent_ItemCommand(object sender, DetailsViewCommandEventArgs e)
        {
           switch (e.CommandName)
            {
                case "Activity":
                    string strAct_Sn = e.CommandArgument.ToString();
                    Session["Activity_Id"] = strAct_Sn;
                    Session["ViewType"] = "";
                    Response.Redirect("~/Activity/Activity_Info_Publish.aspx");
                    break;
                case "File":
                    string strAttach_Name = e.CommandArgument.ToString();

                    if (strAttach_Name != null && strAttach_Name != "")
                    {
                        //WriteFile實現下載
                        string filePath = this.Server.MapPath(@"~\File\ActivityFile\" + strAttach_Name);//路徑

                        Response.Clear();
                        // Specify the Type of the downloadable file.
                        Response.ContentType = "application/octet-stream";
                        // Set the Default file name in the FileDownload dialog box.
                        Response.AddHeader("Content-Disposition", "attachment; filename=" + strAttach_Name);
                        Response.Flush();
                        // Download the file.
                        Response.WriteFile(filePath);
                        Response.End();

                        

                    }
                    break;
            }
        }

        // <summary>
        // 撰寫人：Una
        // 撰寫日期：2012/05/25
        // 功能簡述：GV按鈕控制
        // 修改人：
        // 修改日期：
        // </summary>
        protected void grvActivity_list_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            { 
                //報名
                Button btnRegis = (Button)e.Row.Cells[4].FindControl("btnRegis");
                if (((Label)e.Row.Cells[4].FindControl("lbRegis_sts")).Text == "N")
                    btnRegis.Enabled = false; 
            }
        }
    }
}