using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonClass;

namespace APPGISMS.DialogControl
{
    public partial class Dialog : System.Web.UI.UserControl
    {
        #region 各項屬性
        //Update Panel
        public UpdatePanel UpdatePanelControl { set; private get; }

        //必選訊息顯示
        public bool MessageVisible
        {
            set { lbDialog_Must.Visible = value; }
        }

        //清空按鈕顯示
        public bool ClearButtonVisible
        {
            set { lbtnClear.Visible = value; }
        }

        //Label寬度
        public int DialogValueWidth
        {
            set { lbDialog.Width = value; }
        }
        #endregion

        #region 事件－Page_Load
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/01/04
        // 功能簡述：頁面讀取
        // 修改人：
        // 修改日期：
        // </summary>
        protected void Page_Load(object sender, EventArgs e) { }
        #endregion

        #region 事件－清除員工資訊
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/01/04
        // 功能簡述：清除員工資訊
        // 修改人：
        // 修改日期：
        // </summary>
        protected void lbtnClear_Click(object sender, EventArgs e)
        {
            clearDialogControl();
            if (UpdatePanelControl != null)
                UpdatePanelControl.Update();
        }
        #endregion

        #region 公有方法－設定ModalPopup屬性 setDialogInformation(string[])
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/01/04
        // 功能簡述：設定ModalPopup屬性
        // 修改人：
        // 修改日期：
        // </summary>
        /// <summary>
        /// 設定ModalPopup屬性
        /// </summary>
        /// <param name="arr_strControl_Id">ModalPopup資料陣列</param>
        public void setDialogInformation(string[] arr_strControl_Id)
        {
            mpeDialog.PopupControlID = arr_strControl_Id[0];
            mpeDialog.OkControlID = arr_strControl_Id[1];
            mpeDialog.CancelControlID = arr_strControl_Id[2];
        }
        #endregion

        #region 公有方法－設定回傳值 setReturnValue(string, string)
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/01/04
        // 功能簡述：設定回傳值
        // 修改人：
        // 修改日期：
        // </summary>
        /// <summary>
        /// 設定回傳值
        /// </summary>
        /// <param name="strText">彈跳視窗之回傳文字</param>
        /// <param name="strValue">彈跳視窗之回傳值</param>
        public event EventHandler ReturnValue;
        public void setReturnValue(string strText, string strValue)
        {
            lbDialog.Text = strText;
            lbReturnText.Text = strText;
            lbReturnValue.Text = strValue;
            if (UpdatePanelControl != null)
                UpdatePanelControl.Update();
            if (ReturnValue != null)
                ReturnValue(null, null);
        }
        #endregion

        #region 公有方法－取得回傳資訊 getReturnInfo(ValueTypeEnum)
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/01/04
        // 功能簡述：取得回傳資訊
        // 修改人：
        // 修改日期：
        // </summary>
        /// <summary>
        /// 取得回傳資訊
        /// </summary>
        /// <param name="vte">回傳類型</param>
        /// <returns></returns>
        public string getReturnInfo(CommonEnum.ValueTypeEnum vte)
        {
            switch (vte)
            {
                case CommonEnum.ValueTypeEnum.Text:
                    return lbReturnText.Text;
                case CommonEnum.ValueTypeEnum.Value:
                    return lbReturnValue.Text;
                default:
                    return "";
            }
        }
        #endregion

        #region 公有方法－清除員工資訊 clearDialogControl()
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/01/04
        // 功能簡述：清除員工資訊
        // 修改人：
        // 修改日期：
        // </summary>
        /// <summary>
        /// 清除員工資訊
        /// </summary>
        public void clearDialogControl()
        {
            lbDialog.Text = "";
            lbReturnText.Text = "";
            lbReturnValue.Text = "";
        }
        #endregion

        #region 公有方法－檢查是否完成輸入 checkIsInput()
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/01/04
        // 功能簡述：檢查是否完成輸入
        // 修改人：
        // 修改日期：
        // </summary>
        /// <summary>
        /// 檢查是否完成輸入
        /// </summary>
        /// <returns>bool</returns>
        public bool checkIsInput()
        {
            if (lbReturnText.Text == "" || lbReturnValue.Text == "")
                return true;
            else
                return false;
        }
        #endregion
    }
}