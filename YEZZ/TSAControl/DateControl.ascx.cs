using System;
using System.ComponentModel;
using System.Web.UI.WebControls;
//using CommonClass;

namespace APPGISMS.TSAControl
{
    // <summary>
    // 撰寫人：Oliver
    // 撰寫日期：2011/04/25
    // 更新日期：
    // 功能簡述：樹狀結構顯示元件
    // 版本：1.0.110425
    // </summary>
    public partial class DateControl : System.Web.UI.UserControl
    {
        #region 日期屬性
        //年個數
        private int intYearCount = 100;
        //曆別
        private DateTypeEnum dteDate = DateTypeEnum.AD;

        private bool boolRun = true;

        /// <summary>
        /// 設定日期曆別
        /// </summary>
        [Category("日期屬性")]
        [Description("設定日期曆別")]
        [DefaultValue(DateTypeEnum.AD)]
        public DateTypeEnum DateType
        {
            set { dteDate = value; }
            get { return dteDate; }
        }

        /// <summary>
        /// 設定日期曆別
        /// </summary>
        [Category("日期屬性")]
        [Description("是否執行PageLoad")]
        [DefaultValue(true)]
        public bool RunPageLoad
        {
            set { boolRun = value; }
            get { return boolRun; }
        }

        /// <summary>
        /// 設定或取得年個數
        /// </summary>
        [Category("日期屬性")]
        [Description("設定或取得年個數")]
        [DefaultValue(100)]
        public int TreeViewDataSoucre
        {
            set { intYearCount = value; }
            get { return intYearCount; }
        }

        /// <summary>
        /// 設定或取得日期
        /// </summary>
        [Browsable(false)]
        public string FullDateString
        {
            set
            {
                string[] arr_strDate = value.Trim().Split('-');
                //年份
                ddlDate_Year.SelectedValue = arr_strDate[0];
                //月份
                ddlDate_Month.SelectedValue = arr_strDate[1];
                //日期
                getDateContent();
                ddlDate_Day.SelectedValue = arr_strDate[2];
            }
            get { return ddlDate_Year.SelectedValue + "-" + ddlDate_Month.SelectedValue + "-" + ddlDate_Day.SelectedValue; }
        }
        #endregion

        #region 類舉型別
        public enum DateTypeEnum { AD, CH }
        #endregion

        #region Page_Load事件－產生年份與月份資料
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/04/25
        // 功能簡述：頁面讀取
        // 修改人：
        // 修改日期：
        // </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && boolRun)
                LoadDate();
        }

        public void LoadDate()
        {

            //年份
            ddlDate_Year.Items.Add(new ListItem("請選擇", "NoChoose"));
            if (dteDate == DateTypeEnum.AD)
                for (int i = 0; i <= intYearCount - 1; i++)
                    ddlDate_Year.Items.Add(new ListItem((DateTime.Now.Year - i).ToString(), (DateTime.Now.Year - i).ToString()));
            else
            {
                for (int i = 0; i <= intYearCount - 1; i++)
                {
                    int intYear = DateTime.Now.Year - 1911 - i;
                    string strYear = "000" + intYear.ToString();
                    strYear = strYear.Substring(strYear.Length - 3, 3);
                    ddlDate_Year.Items.Add(new ListItem(strYear, strYear));
                }
            }
            //月份
            ddlDate_Month.Items.Add(new ListItem("請選擇", "NoChoose"));
            for (int i = 1; i <= 12; i++)
            {
                string strMonth = i < 10 ? "0" + i.ToString() : i.ToString();
                ddlDate_Month.Items.Add(new ListItem(i.ToString() + "月", strMonth));
            }
            //日期
            ddlDate_Day.Items.Add(new ListItem("請選擇年份", "NoChoose"));
        }
        
        #endregion

        #region SelectedIndexChanged事件－選擇年份
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/04/25
        // 功能簡述：選擇年份
        // 修改人：
        // 修改日期：
        // </summary>
        protected void ddlDate_Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDate_Year.SelectedIndex == 0)
            {
                ddlDate_Day.Items.Clear();
                ddlDate_Day.Items.Add(new ListItem("請選擇年份", "NoChoose"));
                ddlDate_Day.Enabled = false;
            }
            else
            {
                if (ddlDate_Month.SelectedIndex == 0)
                {
                    ddlDate_Day.Items.Clear();
                    ddlDate_Day.Items.Add(new ListItem("請選擇月份", "NoChoose"));
                    ddlDate_Day.Enabled = false;
                }
                else
                    //取得日期資料
                    getDateContent();
            }
        }
        #endregion

        #region SelectedIndexChanged事件－選擇月份
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/04/25
        // 功能簡述：選擇月份
        // 修改人：
        // 修改日期：
        // </summary>
        protected void ddlDate_Month_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDate_Month.SelectedIndex == 0)
            {
                string strItem_Text = ddlDate_Year.SelectedIndex == 0 ? "請選擇年份" : "請選擇月份";
                ddlDate_Day.Items.Clear();
                ddlDate_Day.Items.Add(new ListItem(strItem_Text, "NoChoose"));
                ddlDate_Day.Enabled = false;
            }
            else
            {
                if (ddlDate_Year.SelectedIndex == 0)
                {
                    ddlDate_Day.Items.Clear();
                    ddlDate_Day.Items.Add(new ListItem("請選擇年份", "NoChoose"));
                    ddlDate_Day.Enabled = false;
                }
                else
                    //取得日期資料
                    getDateContent();
            }
        }
        #endregion

        #region 公有方法－清除日期選擇 clearDateChoose()
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/04/25
        // 功能簡述：清除日期選擇
        // 修改人：
        // 修改日期：
        // </summary>
        /// <summary>
        /// 清除日期選擇
        /// </summary>
        public void clearDateChoose()
        {
            //年份
            ddlDate_Year.SelectedIndex = 0;
            //月份
            ddlDate_Month.SelectedIndex = 0;
            //日期
            ddlDate_Day.Items.Clear();
            ddlDate_Day.Items.Add(new ListItem("請選擇年份", "NoChoose"));
            ddlDate_Day.Enabled = false;
        }
        #endregion

        #region 公有方法－檢查日期是否選擇 checkDateChoose()
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/04/25
        // 功能簡述：檢查日期是否選擇
        // 修改人：
        // 修改日期：
        // </summary>
        /// <summary>
        /// 檢查日期是否選擇
        /// </summary>
        public bool checkDateChoose()
        {
            return ddlDate_Year.SelectedIndex == 0 && ddlDate_Month.SelectedIndex == 0 && ddlDate_Day.SelectedIndex == 0;
        }
        #endregion

        public bool checkChoose()
        {
            return ddlDate_Year.SelectedIndex != 0 && ddlDate_Month.SelectedIndex != 0 && ddlDate_Day.SelectedIndex != 0;
        }

        #region 私有方法－取得日期資料 getDateContent()
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/04/25
        // 功能簡述：取得日期資料
        // 修改人：
        // 修改日期：
        // </summary>
        private void getDateContent()
        {
            int[] arr_intDate = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            //年份
            int intYear = dteDate == DateTypeEnum.AD ? Convert.ToInt32(ddlDate_Year.SelectedValue) : Convert.ToInt32(ddlDate_Year.SelectedValue) + 1911;
            //月份
            int intMonth = Convert.ToInt32(ddlDate_Month.SelectedValue);
            string strDay;

            //是否為閏年
            //能被4整除, 且不能被100整除
            //能被400整除
            bool boolYear = (intYear % 4 == 0 && intYear % 100 != 0) || intYear % 400 == 0;

            ddlDate_Day.Items.Clear();
            ddlDate_Day.Items.Add(new ListItem("請選擇", "NoChoose"));
            if (intMonth != 2)
                for (int i = 1; i <= arr_intDate[intMonth - 1]; i++)
                {
                    strDay = i < 10 ? "0" + i.ToString() : i.ToString();
                    ddlDate_Day.Items.Add(new ListItem(i.ToString(), strDay));
                }
            else
            {
                int intDate = boolYear ? 29 : 28;
                for (int i = 1; i <= intDate; i++)
                {
                    strDay = i < 10 ? "0" + i.ToString() : i.ToString();
                    ddlDate_Day.Items.Add(new ListItem(i.ToString(), strDay));
                }
            }
            ddlDate_Day.Enabled = true;
        }
        #endregion
    }
}