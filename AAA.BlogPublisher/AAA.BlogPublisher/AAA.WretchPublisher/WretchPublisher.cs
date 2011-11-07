using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.WebPublisher;

namespace AAA.WretchPublisher
{
    public class WretchPublisher : AbstractPublisher
    {
        private string _strHomepage = "http://www.wretch.cc/";

        public WretchPublisher()
        {
            WebSite = "www.wretch.cc";
            WebSiteName = "無名部落格";
        }

        public override bool Login()
        {
            return true;
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
