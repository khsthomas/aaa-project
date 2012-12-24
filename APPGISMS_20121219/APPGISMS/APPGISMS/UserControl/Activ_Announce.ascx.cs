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
    public partial class Activ_Announce : System.Web.UI.UserControl
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
                getActiv_Announce();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：顯示公告內容
        // 修改人：
        // 修改日期：
        // </summary>
        protected void grvActiv_Announce_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Content")
            {
                string strAnn_Id = e.CommandArgument.ToString();
                getActiv_AnnounceContent(strAnn_Id);
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
        protected void grvActiv_Announce_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvActiv_Announce.PageIndex = e.NewPageIndex;
            getActiv_Announce();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：設定內容顯示狀況
        // 修改人：
        // 修改日期：
        // </summary>
        protected void dtActiv_Announce_DataBound(object sender, EventArgs e)
        {
            dtAnncoune.Rows[2].Cells[1].Text = dtAnncoune.Rows[2].Cells[1].Text.Replace("\n", "<BR>");
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得公告資訊
        // 修改人：
        // 修改日期：
        // </summary>
        private void getActiv_Announce()
        {
            Activ_Announce_Service anns = new Activ_Announce_Service();
            grvActiv_Announce.DataSource = anns.getActiv_Announce();
            grvActiv_Announce.DataBind();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得公告內容
        // 修改人：
        // 修改日期：
        // </summary>
        private void getActiv_AnnounceContent(string strAnn_Id)
        {
            Activ_Announce_Service anns = new Activ_Announce_Service();
            dtAnncoune.DataSource = anns.getActiv_AnnounceContent(strAnn_Id);
            dtAnncoune.DataBind();
        }
    }
}