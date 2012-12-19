using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YEZZ;

namespace APPGISMS.Project
{
    public partial class Project_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBuilder.FillProjectName(ddlProjectName);                
                DataBuilder.FillFormulaName(ddlFormulaName, ddlProjectName.SelectedValue);
            }
        }

        protected void ddlProjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBuilder.FillFormulaName(ddlFormulaName, ddlProjectName.SelectedValue);
        }
    }
}
