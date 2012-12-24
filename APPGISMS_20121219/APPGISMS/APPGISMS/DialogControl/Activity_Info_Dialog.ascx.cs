using System;
using System.Data;
using System.Web.UI.WebControls;
using INFOSERVICE.DialogControl;
using APPGISMS.DialogControl;

namespace APPGISMS.DialogControl
{
    public partial class Activity_Info_Dialog : System.Web.UI.UserControl
    {
        #region 各項屬性
        //來源彈跳視窗控制項
        private Dialog dcTarget;
        #endregion

        #region 事件－Page_Load
        //</summary>
        // 撰寫人：Hilda
        // 撰寫日期：2012/03/05
        // 功能簡述：頁面讀取
        // 修改人：
        // 修改日期：
        // </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["strActInfo"] = "";
                getgrvActInfo();
            }
        }
        #endregion

        #region 事件－查詢活動資料
        //</summary>
        // 撰寫人：Hilda
        // 撰寫日期：2012/03/05
        // 功能簡述：查詢活動資料
        // 修改人：
        // 修改日期：
        // </summary>
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            ViewState["strActInfo"] = txtAct_Info.Text;
            getgrvActInfo(txtAct_Info.Text);
        }
        #endregion

        #region 事件－活動資料分頁
        //</summary>
        // 撰寫人：Hilda
        // 撰寫日期：2012/03/05
        // 功能簡述：分頁
        // 修改人：
        // 修改日期：
        // </summary>
        protected void grvAct_Info_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvAct_Info.PageIndex = e.NewPageIndex;
            getgrvActInfo();
        }
        #endregion

        #region 事件－單選活動資料
        //</summary>
        // 撰寫人：Hilda
        // 撰寫日期：2012/03/05
        // 功能簡述：單選
        // 修改人：
        // 修改日期：
        // </summary>
        protected void rbtChoose_CheckedChanged(object sender, System.EventArgs e)
        {
            //取消GridView內之RadioButton選取
            foreach (GridViewRow row in grvAct_Info.Rows)
                ((RadioButton)row.FindControl("rbtChoose")).Checked = false;

            //取得ReadioButton
            RadioButton rbt = (RadioButton)sender;
            //取得控制項所屬性 GridViewRow 
            GridViewRow grvAct_Info_Row = (GridViewRow)rbt.NamingContainer;
            //設定該Row之RadioButton
            ((RadioButton)grvAct_Info_Row.FindControl("rbtChoose")).Checked = true;
            //取得目前 GridViewRow 的索引
            int intRowIndex = grvAct_Info_Row.RowIndex;
            //取得資訊
            string strText = grvAct_Info.Rows[intRowIndex].Cells[2].Text.Trim() + " " + grvAct_Info.Rows[intRowIndex].Cells[1].Text.Trim();
            string strValue = grvAct_Info.DataKeys[intRowIndex].Value.ToString().Trim();
            hfDialog.Value = strText + "," + strValue;
        }
        #endregion

        #region 事件－確定並結束選擇活動資料
        //</summary>
        // 撰寫人：Hilda
        // 撰寫日期：2012/03/05
        // 功能簡述：確定選擇
        // 修改人：
        // 修改日期：
        // </summary>
        protected void btnChoose_OnClick(object sender, EventArgs e)
        {
            string strText = hfDialog.Value == "" ? "" : hfDialog.Value.Split(',')[0];
            string strValue = hfDialog.Value == "" ? "" : hfDialog.Value.Split(',')[1];

            DataSet ds = (DataSet)ViewState["dsActInfo"];
            DataTable dt = ds.Tables[0];
            DataRow[] arr_dr = dt.Select("ACTIVITY_SN = '" + strValue + "' ");
            foreach (DataRow dr in arr_dr)
            {
                Session["ACTIVITY_SN"] = dr["ACTIVITY_SN"].ToString();
                Session["ACTIVITY_NAME"] = dr["ACTIVITY_NAME"].ToString();
                Session["ORGANIZER_ID"] = dr["ORGANIZER_ID"].ToString();
                Session["ORGANIZER_NAME"] = dr["ORGANIZER_NAME"].ToString();
                Session["ACTIVITY_STATE"] = dr["ACTIVITY_STATE"].ToString();
                Session["ACTIVITY_SDATE"] = dr["ACTIVITY_SDATE"].ToString();
                Session["ACTIVITY_EDATE"] = dr["ACTIVITY_EDATE"].ToString();
            }
            dcTarget.setReturnValue(strText, strValue);
        }
        #endregion

        #region 公有方法－取得彈跳視窗資訊 getDialogPopupControl(Dialog)
        // </summary>
        // 撰寫人：Hilda
        // 撰寫日期：2012/03/05
        // 功能簡述：公用方法－取得彈跳視窗資訊
        // 修改人：
        // 修改日期：
        // </summary>
        /// <summary>
        /// 取得彈跳視窗資訊
        /// </summary>
        /// <param name="dc">來源彈跳視窗控制項</param>
        /// <returns></returns>
        public string[] getDialogPopupControl(Dialog dc)
        {
            string[] arr_strControl_ID = new string[3];

            //Dialog Panel
            arr_strControl_ID[0] = panDialog.ClientID;
            //OK Button
            arr_strControl_ID[1] = btnChoose.ClientID;
            //Cancel Button
            arr_strControl_ID[2] = btnCancel.ClientID;

            //設定觸發之DialogControl
            dcTarget = dc;

            return arr_strControl_ID;
        }
        #endregion

        #region 私有方法－取得活動資料
        // </summary>
        // 撰寫人：Hilda
        // 撰寫日期：2012/03/05
        // 功能簡述：活動資料擷取
        // 修改人：
        // 修改日期：
        // </summary>
        private void getgrvActInfo()
        {
            string strAct_Info = ViewState["strActInfo"].ToString();
            getgrvActInfo(strAct_Info);
        }
        #endregion

        #region 私有方法－取得活動資料
        // </summary>
        // 撰寫人：Hilda
        // 撰寫日期：2012/03/05
        // 功能簡述：活動資料擷取
        // 修改人：
        // 修改日期：
        // </summary>
        private void getgrvActInfo(string strAct_Info)
        {
            Activity_Info_Dialog_Service aids = new Activity_Info_Dialog_Service();
            DataSet ds = aids.getgrvActInfo(strAct_Info);
            grvAct_Info.DataSource = ds;
            grvAct_Info.DataBind();
            ViewState["dsActInfo"] = ds;
        }
        #endregion

    }
}
