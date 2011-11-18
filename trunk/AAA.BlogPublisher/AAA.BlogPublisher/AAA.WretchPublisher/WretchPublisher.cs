using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.WebPublisher;
using System.Windows.Forms;
using AAA.Web;
using System.IO;
using System.Threading;

namespace AAA.WretchPublisher
{
    public class WretchPublisher : AbstractPublisher
    {        
        private string _strHomepage = "http://www.wretch.cc/";
        //private string _strHomepage = "http://mail.google.com/";

        //private string _strHomepage = "http://tw.rd.yahoo.com/referurl/wretch/index/turf/login/*http://www.wretch.cc/IDintegration/?ref=%2525252F";        

        private const int REDIRECT_TO_YAHOO_LOGIN = 0;
        private const int YAHOO_LOGIN_FORM = 1;
        private const int REDIRECT_TO_BLOG = 2;
        private const int LOGIN_COMPLETED = 3;
        private const int FILL_BLOG = 4;
        private const int PUBLISH = 5;
        private const int POST_COMPLETED = 6;
        private const int LOGOUT = 7;


        private string _strTitle;
        private string _strArticle;

        private int _iCurrentStep = -1;
        private bool _isCompleted;

        public WretchPublisher()
        {
            WebSite = "www.wretch.cc";
            WebSiteName = "無名部落格";
        }

        public override bool Login()
        {
            try
            {
                Console.WriteLine(WebBrowser.Version);
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
                            HtmlAction.HrefClick(document, "http://tw.rd.yahoo.com/referurl/wretch/index/turf/login/*http://www.wretch.cc/IDintegration/?ref=%2525252F");
                        }
                        break;

                    case YAHOO_LOGIN_FORM:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = REDIRECT_TO_BLOG;
                            HtmlAction.FillTextFieldData(document, "login_form", "login", Username);
                            HtmlAction.FillTextFieldData(document, "login_form", "passwd", Password);
                            HtmlAction.ClickSubmitButton(document, "login_form", ".save");
                            //HtmlAction.ClickButton(document, null, ".save");
                        }
                        break;

                    case REDIRECT_TO_BLOG:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = LOGIN_COMPLETED;
                            HtmlAction.HrefClick(document, "http://tw.rd.yahoo.com/referurl/wretch/index/turf/login/blog/*http://www.wretch.cc/blog/" + Blogname);
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
                            HtmlAction.FillTextFieldData(document, "addpost", "title", _strTitle);
                            HtmlAction.FillTextAreaData(document, "addpost", "text", _strArticle);
                            HtmlAction.ClickCheckButton(document, "default_category", null);
                            Thread.Sleep(3000);
                            HtmlAction.Submit(document, "addpost", "confirm");                            
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
            WebBrowser.Url = new Uri("http://tw.rd.yahoo.com/referurl/wretch/index/turf/logout/*http://www.wretch.cc/index/logout.php?url=http://www.wretch.cc");

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
                HtmlAction.ClickButton(WebBrowser.Document, null, "發表新文章(舊版)");

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
