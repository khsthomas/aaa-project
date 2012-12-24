using System;
using System.Data;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFOSERVICE.DialogControl;



namespace APPGISMS.DialogControl
{
    public partial class Address_Info_Dialog : System.Web.UI.UserControl
    {
        #region 各項屬性
        //來源彈跳視窗控制項
        private Dialog dcTarget;
        #endregion

        #region 公有方法－取得彈跳視窗資訊 getDialogPopupControl(Dialog)
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/01/04
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

        // </summary>
        // 撰寫人：Edison
        // 撰寫日期：2012/09/28
        // 功能簡述：
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //擷取縣市下拉式選單
                Address_Info_Dialog_Service aids = new Address_Info_Dialog_Service();
                DataSet ds = aids.getlbxCounty();
                lbxCounty.DataSource = ds;
                lbxCounty.DataBind();

                lbxTown.Items.Insert(0, new ListItem("請選擇", "NoChoose"));
                lbxRoad.Items.Insert(0, new ListItem("請選擇", "NoChoose"));
            }
        }

        // </summary>
        // 撰寫人：Edison
        // 撰寫日期：2012/09/28
        // 功能簡述：依選取之縣市，顯示所屬鄉鎮資料與地址資料
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        protected void lbxCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            //擷取鄉鎮下拉式選單
            Address_Info_Dialog_Service aids = new Address_Info_Dialog_Service();
            DataSet ds = aids.getlbxTown(lbxCounty.SelectedValue);
            lbxTown.DataSource = ds;
            lbxTown.DataBind();

            //鄉鎮清單
            lbxTown.Enabled = true;
            //道路清單
            lbxRoad.Enabled = false;

            //清除道路清單
            lbxRoad.Items.Clear();
            lbxRoad.Items.Insert(0, new ListItem("請選擇", "NoChoose"));

            //顯示地址
            lbAddress_Detail1.Text = lbxCounty.SelectedItem.ToString();
            lbAddress_Info.Text = lbAddress_Detail1.Text + lbAddress_Detail2.Text;
        }

        // </summary>
        // 撰寫人：Edison
        // 撰寫日期：2012/09/28
        // 功能簡述：依選取之鄉鎮，顯示所屬道路資料與地址資料
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        protected void lbxTown_SelectedIndexChanged(object sender, EventArgs e)
        {
            //擷取道路下拉式選單
            Address_Info_Dialog_Service aids = new Address_Info_Dialog_Service();
            DataSet ds = aids.getlbxRoad(lbxCounty.SelectedValue, lbxTown.SelectedValue);
            lbxRoad.DataSource = ds;
            lbxRoad.DataBind();

            //道路清單
            lbxRoad.Enabled = true;

            //顯示地址
            lbAddress_Detail1.Text = lbxCounty.SelectedItem.ToString() + lbxTown.SelectedItem.ToString();
            lbAddress_Info.Text = lbAddress_Detail1.Text + lbAddress_Detail2.Text;
        }

        // </summary>
        // 撰寫人：Edison
        // 撰寫日期：2012/09/28
        // 功能簡述：顯示地址資料
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        protected void lbxRoad_SelectedIndexChanged(object sender, EventArgs e)
        {
            //顯示地址
            lbAddress_Detail1.Text = lbxCounty.SelectedItem.ToString() + lbxTown.SelectedItem.ToString() + lbxRoad.SelectedItem.ToString();
            lbAddress_Info.Text = lbAddress_Detail1.Text + lbAddress_Detail2.Text;
        }

        // </summary>
        // 撰寫人：Edison
        // 撰寫日期：2012/09/28
        // 功能簡述：顯示地址資料
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        protected void btnAddress_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.ID != "btnBackspace")
            {
                lbAddress_Detail2.Text += btn.Text;
            }
            else if (btn.ID == "btnBackspace" && lbAddress_Detail2.Text.Length != 0)
            {
                lbAddress_Detail2.Text = lbAddress_Detail2.Text.Substring(0, lbAddress_Detail2.Text.Length - 1);
            }
            
            lbAddress_Info.Text = lbAddress_Detail1.Text + lbAddress_Detail2.Text;
        }

        // </summary>
        // 撰寫人：Edison
        // 撰寫日期：2012/09/28
        // 功能簡述：確定選擇
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        protected void btnChoose_Click(object sender, EventArgs e)
        {
            if (lbxCounty.SelectedValue != "" && lbxTown.SelectedValue != "" && lbxRoad.SelectedValue != "" && lbAddress_Detail2.Text != "")
            {
                string strCounty_No = lbxCounty.SelectedValue;
                string strTown_No = lbxTown.SelectedValue;
                string strRoad_No = lbxRoad.SelectedValue;

                Address_Info_Dialog_Service aids = new Address_Info_Dialog_Service();
                string strZip_Code = aids.getZipCode(strCounty_No, strTown_No, strRoad_No);

                dcTarget.setReturnValue(strZip_Code + " " + lbAddress_Info.Text, strZip_Code + "|" + strCounty_No + "|" + strTown_No + "|" + strRoad_No + "|" + lbAddress_Detail2.Text);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "", "<script language=\"javascript\" type=\"text/javascript\">alert(\"尚未完成地址填寫!\");</script>", false);
            }
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/01/04
        // 功能簡述：設定回傳值
        // 修改人：
        // 修改日期：
        // </summary>
        public void setReturnValue(string strText, string strValue)
        {
            //取得完整下拉式選單
            Address_Info_Dialog_Service aids = new Address_Info_Dialog_Service();
            DataSet ds = aids.getlbxAddress(strValue.Split('|')[1], strValue.Split('|')[2]);

            lbxCounty.DataSource = ds.Tables[0];
            lbxCounty.DataBind();
            lbxTown.DataSource = ds.Tables[1];
            lbxTown.DataBind();
            lbxRoad.DataSource = ds.Tables[2];
            lbxRoad.DataBind();

            //縣市代碼
            lbxCounty.SelectedValue = strValue.Split('|')[1];
            //鄉鎮代碼
            lbxTown.SelectedValue = strValue.Split('|')[2];
            //道路代碼
            lbxRoad.SelectedValue = strValue.Split('|')[3];
            //縣市/鄉鎮/道路代碼
            lbAddress_Detail1.Text = strValue.Split('|')[1] + "|" + strValue.Split('|')[2] + "|" + strValue.Split('|')[3];
            //地址
            lbAddress_Detail2.Text = strValue.Split('|')[4];

            //完整地址資訊
            lbAddress_Info.Text = strText;

            //鄉鎮清單
            lbxTown.Enabled = true;
            //道路清單
            lbxRoad.Enabled = true;
        }

        // </summary>
        // 撰寫人：Edison
        // 撰寫日期：2012/09/28
        // 功能簡述：清除資訊
        // 修改人：
        // 修改日期：
        // </summary>
        public void clearDialogControl()
        {
            lbxCounty.SelectedIndex = 0;
            lbxTown.Items.Clear();
            lbxTown.Items.Insert(0, new ListItem("請選擇", "NoChoose"));
            lbxTown.Enabled = false;
            lbxRoad.Items.Clear();
            lbxRoad.Items.Insert(0, new ListItem("請選擇", "NoChoose"));
            lbxRoad.Enabled = false;

            lbAddress_Info.Text = "";
            lbAddress_Detail1.Text = "";
            lbAddress_Detail2.Text = "";
        }
    }
}