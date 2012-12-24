using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CommonClass
{
    public class CommonMethod
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/01/31
        // 功能簡述：設定GridView內下拉選單的項目
        // 修改人：
        // 修改日期：
        // </summary>
        /// <summary>
        /// 設定GridView內下拉選單的項目
        /// </summary>
        /// <param name="ddl">欲設定之下拉選單</param>
        /// <param name="strSelectedValue">設定值</param>
        /// <param name="ddlType">設定值類型</param>
        public static void setDropDownListSelectedValue(DropDownList ddl, string strSelectedValue, CommonEnum.ValueTypeEnum vteType)
        {
            string strValue;
            
            //DropDownList的項目筆數大於i時
            for (int i = 0; i <= ddl.Items.Count - 1; i++)
            {
                //DropDownList設定選定項目為第i項
                ddl.SelectedIndex = i;

                //欲判斷之項目值
                strValue = vteType == CommonEnum.ValueTypeEnum.Text ? ddl.SelectedItem.Text : ddl.SelectedItem.Value;
                     

                //DropDownList的項目內容等於選定的項目內容
                if (strValue == strSelectedValue)
                {
                    return;
                }
            }
        }
    }
}
