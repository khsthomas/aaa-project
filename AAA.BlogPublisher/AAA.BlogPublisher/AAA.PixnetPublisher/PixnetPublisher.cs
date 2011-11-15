using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.WebPublisher;
using System.Windows.Forms;

namespace AAA.PixnetPublisher
{
    public class PixnetPublisher : AbstractPublisher
    {
        private string _strHomepage = "http://www.pixnet.net/";

        public PixnetPublisher()
        {
            WebSite = "www.pixnet.net";
            WebSiteName = "痞客幫部落格";
        }

        public override bool Login()
        {
            try
            {
                WebBrowser.Url = new Uri(_strHomepage);                
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "," + ex.StackTrace;
            }
            return false;
        }

        protected override bool ParseHtml(HtmlDocument document)
        {
            try
            {
                HtmlElement elUser = document.GetElementById("input-username");
                elUser.SetAttribute("value", "jackchen70");
                HtmlElement elPwd = document.GetElementById("input-password");
                elPwd.SetAttribute("value", "444444");
                HtmlElement elSubmit = document.GetElementById("login-send");
                elSubmit.InvokeMember("click");

                Console.WriteLine(document.Body.OuterHtml.ToString());
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "," + ex.StackTrace;
            }
            return false;
        }

        public override bool Logout()
        {
            return true;
        }

        public override bool PictureValidate()
        {
            return true;
        }

        public override bool UploadPicture()
        {
            return true;
        }

        public override bool PostArticle()
        {
            return true;
        }
    }
}
