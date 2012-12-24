using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using INFOSERVICE.UserControl;

namespace APPGISMS.UserControl
{
    // </summary>
    // 撰寫人：Oliver
    // 撰寫日期：2010/04/23
    // 功能簡述：公告資訊
    // 修改人：
    // 修改日期：
    // </summary>
    public partial class Announcement : System.Web.UI.UserControl
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
                getAnnounce();
                getAnnounceContent("10000012");
            }
                //
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：顯示公告內容
        // 修改人：
        // 修改日期：
        // </summary>
        protected void grvAnnounce_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Content")
            {
                string strAnn_Id = e.CommandArgument.ToString();
                getAnnounceContent(strAnn_Id);
                panContent_Title.Visible = true;
            }
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：公告分頁
        // 修改人：
        // 修改日期：
        // </summary>
        protected void grvAnnounce_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvAnnounce.PageIndex = e.NewPageIndex;
            getAnnounce();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：設定內容顯示狀況
        // 修改人：
        // 修改日期：
        // </summary>
        //protected void dtAnnounce_DataBound(object sender, EventArgs e)
        //{
            
        //    dtAnncoune.Rows[1].Cells[1].Text = dtAnncoune.Rows[1].Cells[1].Text.Replace("\n", "<BR>");
        //}

        protected void Item_Bound(Object sender, DataListItemEventArgs e)
        {
            Label lbAnnounce_Content = (Label)e.Item.FindControl("lbAnnounce_Content");

            lbAnnounce_Content.Text = lbAnnounce_Content.Text.Replace("\n", "<BR>");

        } 

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得公告資訊
        // 修改人：
        // 修改日期：
        // </summary>
        private void getAnnounce()
        {
            Announcement_Service anns = new Announcement_Service();
            grvAnnounce.DataSource = anns.getAnnouncement();
            grvAnnounce.DataBind();
            //dlAnncoune.DataSource = anns.getAnnouncement();
            //dlAnncoune.DataBind();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得公告內容
        // 修改人：
        // 修改日期：
        // </summary>
        private void getAnnounceContent(string strAnn_Id)
        {
            Announcement_Service anns = new Announcement_Service();
            
            dlAnncoune.DataSource = anns.getAnnounceContent(strAnn_Id);
            dlAnncoune.DataBind();
            //dtAnncoune.DataSource = anns.getAnnounceContent(strAnn_Id);
            //dtAnncoune.DataBind();
        }
    }
}