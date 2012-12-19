using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace AAA.GoogleMap.Component
{
    public partial class GoogleMapPane : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
/*
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "bodyevnet", "init();", false);
            HtmlGenericControl script = new HtmlGenericControl("script");
            script.Attributes.Add("type", "txext/javascript");
            script.Attributes.Add("src", ResolveUrl("/script/googleMap.js"));
            Page.Header.Controls.AddAt(0, script);
        
            script = new HtmlGenericControl("script");
            script.Attributes.Add("type", "txext/javascript");
            script.Attributes.Add("src", ResolveUrl("http://maps.google.com/maps/api/js?sensor=false"));
            Page.Header.Controls.AddAt(0, script);

            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "bodyevent", "<script>init(-34.397, 150.644);</script>");
 */ 
        }

        protected void btnDisplay_Click(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "addEvent", "<script>addMarker(-34.397, 150.644);</script>");
        }
    }
}