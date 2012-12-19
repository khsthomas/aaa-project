using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TSAControl
{
    /// <summary>
    /// 撰寫人：Oliver
    /// 轉寫日期：2009/11/22
    /// 功能簡述：TextBox擴充控制項
    /// 最後更新日期：
    /// 修改人：
    /// 修改日期：
    /// </summary>
    public partial class TextBoxExtender : System.Web.UI.UserControl
    {
        //目標TextBox之ID
        protected string strTarget_Control_ID;
        public string TargetControlID
        {
            set { strTarget_Control_ID = value; }
        }

        //Submit Button之ID
        protected string strSubmit_Button_ID;
        public string SubmitButtonID
        {
            set { strSubmit_Button_ID = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox txtTargetControl = (TextBox) Page.FindControl(strTarget_Control_ID);
            txtTargetControl.Attributes.Add("onkeydown", "TextBoxInputEnter()");
        }
    }
}