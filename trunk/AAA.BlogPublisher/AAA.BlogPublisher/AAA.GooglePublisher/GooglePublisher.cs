using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.WebPublisher;
using System.Windows.Forms;
using AAA.Web;
using System.IO;
using System.Threading;

namespace AAA.GooglePublisher
{
    public class GooglePublisher : AbstractPublisher
    {
        private string _strHomepage = "http://www.google.com/";

        private const int REDIRECT_TO_YAHOO_LOGIN = 0;
        private const int YAHOO_LOGIN_FORM = 1;
        private const int REDIRECT_TO_BLOG_HOME = 20;
        private const int REDIRECT_TO_BLOG = 21;
        private const int LOGIN_COMPLETED = 3;
        private const int FILL_BLOG = 4;
        private const int PUBLISH = 5;
        private const int POST_COMPLETED = 6;
        private const int LOGOUT = 7;

        private string _strTitle;
        private string _strArticle;

        private int _iCurrentStep = -1;
        private bool _isCompleted;

        public GooglePublisher()
        {
            WebSite = "www.google.com";
            WebSiteName = "Google部落格";

            Username = "bealover2001";
            Password = "bealover2001!111";
            Blogname = "6612753544305311345";

        }

        public override bool Login()
        {
            try
            {
                LoginCompleted = false;
                _iCurrentStep = REDIRECT_TO_YAHOO_LOGIN;
                WebBrowser.Url = new Uri(_strHomepage);

                while (LoginCompleted == false)
                {
                    Application.DoEvents();
                    Thread.Sleep(10);
                }

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
                switch (_iCurrentStep)
                {
                    case REDIRECT_TO_YAHOO_LOGIN:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = YAHOO_LOGIN_FORM;
                            HtmlAction.HrefClick(document, "https://accounts.google.com/ServiceLogin?hl=zh-TW&continue=http://www.google.com/");
                        }
                        break;

                    case YAHOO_LOGIN_FORM:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = REDIRECT_TO_BLOG;
                            HtmlAction.FillTextFieldData(document, "gaia_loginform", "Email", Username);
                            HtmlAction.FillTextFieldData(document, "gaia_loginform", "Passwd", Password);
                            HtmlAction.Submit(document, "gaia_loginform", "signIn");
                            //HtmlAction.ClickButton(document, null, ".save");
                        }
                        break;


                    case REDIRECT_TO_BLOG:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = LOGIN_COMPLETED;
                            WebBrowser.Url = new Uri("http://www.blogger.com/home?pli=1");
                        }
                        break;

                    case LOGIN_COMPLETED:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            LoginCompleted = true;
                        }
                        break;

                    case FILL_BLOG:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            Thread.Sleep(3000);
                            _iCurrentStep = PUBLISH;
                            HtmlAction.FillTextFieldData(document, "postingForm", "title", _strTitle);
                            HtmlAction.FillTextAreaData(document, "postingForm", "postBody", _strArticle);
                            //HtmlAction.ClickCheckButton(document, "default_category", null);
                            Thread.Sleep(3000);
                            HtmlAction.Submit(document, "postingForm", "publish");
                        }
                        break;
                    case PUBLISH:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _isCompleted = true;
                        }
                        break;

                    case LOGOUT:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _isCompleted = true;
                        }
                        break;
                }

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
            _isCompleted = false;
            _iCurrentStep = LOGOUT;
            WebBrowser.Url = new Uri("http://www.blogger.com/logout.g");

            while (_isCompleted == false)
            {
                Application.DoEvents();
                Thread.Sleep(10);
            }

            return true;
        }

        public override bool PictureValidate()
        {
            return true;
        }

        public override bool UploadPicture(string strPictureName)
        {
            return true;
        }

        public override bool PostArticle(string strFilename)
        {
            StreamReader sr = null;
            string strLine;
            try
            {
                sr = new StreamReader(strFilename, Encoding.Default);

                _strTitle = sr.ReadLine();
                _strArticle = "";
                while ((strLine = sr.ReadLine()) != null)
                {
                    _strArticle += strLine + "<br>";
                }

                _isCompleted = false;
                _iCurrentStep = FILL_BLOG;
                //HtmlAction.HrefClick(WebBrowser.Document, "http://www.blogger.com/post-create.g?blogID=6612753544305311345");
                HtmlAction.HrefClick(WebBrowser.Document, "http://www.blogger.com/post-create.g?blogID=" + Blogname);


                while (_isCompleted == false)
                {
                    Application.DoEvents();
                    Thread.Sleep(10);
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "," + ex.StackTrace;
            }
            return false;
        }
    }
}
