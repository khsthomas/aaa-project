using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFOSERVICE.ManageTool;

namespace APPGISMS.ManageTool
{
    // </summary>
    // 撰寫人：Oliver
    // 撰寫日期：2010/05/02
    // 功能簡述：院所重覆資料處理
    // 修改人：
    // 修改日期：
    // </summary>
    public partial class Hospital_Repeat : System.Web.UI.Page
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/02/26
        // 功能簡述：頁面讀取
        // 修改人：
        // 修改日期：
        // </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //縣市資料
                ddlCounty_Info.DataBind();
                ddlCounty_Info.Items.Insert(0, new ListItem("請選擇", "NoChoose"));
                //鄉鎮市區
                ddlTown_Info.Items.Add(new ListItem("請選擇縣市", "NoChoose"));
            }
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/02/26
        // 功能簡述：顯示院所資料
        // 修改人：
        // 修改日期：
        // </summary>
        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (ddlCounty_Info.SelectedValue == "NoChoose")
            {
                //emcMsg.ShowErrorMessage("請選擇縣市");
                return;
            }

            if (ddlTown_Info.SelectedValue == "NoChoose")
            {
                //emcMsg.ShowErrorMessage("請選擇鄉鎮市區");
                return;
            }

            if (txtHospital_Name.Text == "")
            {
                //emcMsg.ShowErrorMessage("請輸入院所名稱");
                return;
            }

            //縣市
            ViewState["strCounty_No"] = ddlCounty_Info.SelectedValue;
            //鄉鎮市區
            ViewState["strTown_No"] = ddlTown_Info.SelectedValue;
            //院所名稱
            ViewState["strHospital_Name"] = txtHospital_Name.Text;
            getHospitalInfo(ddlCounty_Info.SelectedValue, ddlTown_Info.SelectedValue, txtHospital_Name.Text);
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/02/26
        // 功能簡述：更新院所資料
        // 修改人：
        // 修改日期：
        // </summary>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Hospital_Repeat_Service hrs = new Hospital_Repeat_Service();
            DataTable dt = (DataTable)ViewState["dtHospital_Info"];
            int i = hrs.setHospitalInfo(dt);

            string strMessage = i > 0 ? "更新成功" : "更新失敗";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "", "<script language=\"javascript\" type=\"text/javascript\">alert('" + strMessage + "');</script>", false);
            getHospitalInfo();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/02/26
        // 功能簡述：縣市資料選擇
        // 修改人：
        // 修改日期：
        // </summary>
        protected void ddlCounty_Info_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTown_Info.Items.Clear();
            if (ddlCounty_Info.SelectedIndex == 0)
            {
                ddlTown_Info.Items.Add(new ListItem("請選擇縣市", "NoChoose"));
                ddlTown_Info.Enabled = false;
            }
            else
            {
                Hospital_Repeat_Service hrs = new Hospital_Repeat_Service();
                ddlTown_Info.DataSource = hrs.getTownInfo(ddlCounty_Info.SelectedValue);
                ddlTown_Info.DataBind();
                ddlTown_Info.Items.Insert(0, new ListItem("請選擇", "NoChoose"));
                ddlTown_Info.Enabled = true;
            }
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/02/26
        // 功能簡述：選擇保留院所
        // 修改人：
        // 修改日期：
        // </summary>
        protected void grv_rbtHospital_Info_CheckedChanged(object sender, EventArgs e)
        {
            //取得ReadioButton
            RadioButton rbt = (RadioButton)sender;
            //取得控制項所屬性 GridViewRow 
            GridViewRow grvHospital_Info_Row = (GridViewRow)rbt.NamingContainer;
            //取得目前 GridViewRow 的索引
            int intRowIndex = grvHospital_Info_Row.RowIndex;
            //院所編號
            string strHospital_Sn = grvHospital_Info.DataKeys[intRowIndex].Value.ToString();

            DataTable dt = (DataTable)ViewState["dtHospital_Info"];
            foreach (DataRow dr in dt.Rows)
                dr["MAIN_CHOOSE"] = dr["HOSPITAL_SN"].ToString() == strHospital_Sn ? "1" : "0";

            ViewState["dtHospital_Info"] = dt;
            grvHospital_Info.DataSource = dt;
            grvHospital_Info.DataBind();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/02/26
        // 功能簡述：縣市資料取得
        // 修改人：
        // 修改日期：
        // </summary>
        protected DataSet getCountyInfo()
        {
            Hospital_Repeat_Service hrs = new Hospital_Repeat_Service();
            return hrs.getCountyInfo();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/02/26
        // 功能簡述：院所資料取得
        // 修改人：
        // 修改日期：
        // </summary>
        private void getHospitalInfo()
        {
            //縣市
            string strCounty_No = ViewState["strCounty_No"].ToString();
            //鄉鎮市區
            string strTown_No = ViewState["strTown_No"].ToString();
            //院所名稱
            string strHospital_Name = ViewState["strHospital_Name"].ToString();
            getHospitalInfo(strCounty_No, strTown_No, strHospital_Name);
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/02/26
        // 功能簡述：院所資料取得
        // 修改人：
        // 修改日期：
        // </summary>
        private void getHospitalInfo(string strCounty_No, string strTown_No, string strHospital_Name)
        {
            Hospital_Repeat_Service hrs = new Hospital_Repeat_Service();
            DataSet ds = hrs.getHospitalInfo(strCounty_No, strTown_No, strHospital_Name);
            //牙醫院所資料
            grvHospital_Info.DataSource = ds.Tables[0];
            grvHospital_Info.DataBind();
            ViewState["dtHospital_Info"] = ds.Tables[0];
            //牙醫師所屬院所資料
            grvHospital_Doctor.DataSource = ds.Tables[1];
            grvHospital_Doctor.DataBind();
        }
    }
}
