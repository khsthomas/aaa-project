using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.WebPublisher;
using System.Windows.Forms;

namespace AAA.WretchPublisher
{
    public class WretchPublisher : AbstractPublisher
    {        
        //private string _strHomepage = "http://www.wretch.cc/";
        private string _strHomepage = "http://mail.google.com/";

        public WretchPublisher()
        {
            WebSite = "www.wretch.cc";
            WebSiteName = "無名部落格";
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
                Console.WriteLine(document.Body.ToString());
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
