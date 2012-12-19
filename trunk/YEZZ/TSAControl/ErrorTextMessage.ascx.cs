using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TSAControl
{
    public partial class ErrorTextMessage : System.Web.UI.UserControl
    {
        public string CssClass
        {
            set { txtMsg.CssClass = value; }
        }

        protected void Page_Load(object sender, EventArgs e) {}

        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2009/08/17
        // 功能簡述：顯示錯誤訊息
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public void ShowErrorMessage(string strErrorMessage)
        {
            string strTime = DateTime.Now.ToString("hh:mm:ss");
            string strMessage = "";


            strMessage = "警示訊息:";
            strMessage += strErrorMessage  ;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "self", "<script language=\"javascript\" type=\"text/javascript\">alert('" + strMessage + "');</script>", false);



            txtMsg.Text = "[" + strTime + "] \n"+strMessage + "\n" + txtMsg.Text;
            upErrorMessage.Update();
        }
    }
}