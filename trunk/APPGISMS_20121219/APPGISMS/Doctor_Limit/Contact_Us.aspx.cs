using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace APPGISMS.Doctor_Limit
{
    public partial class Contact_Us : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            createContecterInfo();
            ContecterInfo();
             
            }
        }

        // </summary>
        // 撰寫人：Tina
        // 撰寫日期：2011/08/08
        // 功能簡述：聯絡人資料
        // 修改人：
        // 修改日期：
        // </summary>
        private void ContecterInfo()
        {
            DataTable dt = (DataTable)ViewState["dtContecter"];
                DataRow dr = dt.NewRow();
                dr["Contacter"] = "鄭至軒";
                dr["Mail"] = "den13501@cda.org.tw";
                dt.Rows.Add(dr);
                DataRow dr2 = dt.NewRow();
                dr2["Contacter"] = "陳宗揚";
                dr2["Mail"] = "jacky@itsa.com.tw";
                dt.Rows.Add(dr2);
      
            ViewState["dtContecter"] = dt;
            grvContacter_List.DataSource = ViewState["dtContecter"];
            grvContacter_List.DataBind();
        }
        // </summary>
        // 撰寫人：Tina
        // 撰寫日期：2011/08/08
        // 功能簡述：聯絡人資料
        // 修改人：
        // 修改日期：
        // </summary>
        private void createContecterInfo()
        {
            DataTable dt = new DataTable();

            //聯絡人
            dt.Columns.Add("Contacter");
            //信箱
            dt.Columns.Add("Mail");


            ViewState["dtContecter"] = dt;
        }

    }
}
