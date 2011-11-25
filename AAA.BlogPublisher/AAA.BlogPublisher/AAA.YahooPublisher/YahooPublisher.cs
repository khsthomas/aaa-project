using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.WebPublisher;
using System.Windows.Forms;
using AAA.Web;
using System.IO;
using System.Threading;

namespace AAA.YahooPublisher
{
    public class YahooPublisher : AbstractPublisher
    {
        private string _strHomepage = "http://tw.yahoo.com/";
/*
        private const int REDIRECT_TO_LOGIN = 0;
        private const int LOGIN_FORM = 1;
        private const int REDIRECT_TO_BLOG_HOME = 20;
        private const int REDIRECT_TO_BLOG = 21;
        private const int LOGIN_COMPLETED = 3;
        private const int FILL_BLOG = 4;
        private const int PUBLISH = 5;
        private const int POST_COMPLETED = 6;
        private const int LOGOUT = 7;
*/
//        private string _strTitle;
//        private string _strArticle;

        private int _iCurrentStep = -1;
        private bool _isCompleted;

        public YahooPublisher()
        {
            WebSite = "tw.yahoo.com";
            WebSiteName = "雅虎部落格";
        }

        public override bool Login()
        {
            try
            {
                LoginCompleted = false;
                _iCurrentStep = REDIRECT_TO_LOGIN;
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
                    case REDIRECT_TO_LOGIN:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = LOGIN_FORM;
                            HtmlAction.HrefClick(document, "http://tw.rd.yahoo.com/referurl/hp/1024/pa/in/*https://login.yahoo.com/config/login?.intl=tw&.src=fpctx&.done=http://tw.yahoo.com");
                        }
                        break;

                    case LOGIN_FORM:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = REDIRECT_TO_BLOG_HOME;
                            HtmlAction.FillTextFieldData(document, "login_form", "login", Username);
                            HtmlAction.FillTextFieldData(document, "login_form", "passwd", Password);
                            HtmlAction.ClickSubmitButton(document, "login_form", ".save");
                            //HtmlAction.ClickButton(document, null, ".save");
                        }
                        break;

                    case REDIRECT_TO_BLOG_HOME:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = REDIRECT_TO_BLOG;                        
                            HtmlAction.HrefClick(document, "http://tw.rd.yahoo.com/referurl/hp/1024/me/blog/*http://tw.blog.yahoo.com/");
                        }
                        break;

                    case REDIRECT_TO_BLOG:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = LOGIN_COMPLETED;
                            HtmlAction.HrefClick(document, "http://tw.rd.yahoo.com/referurl/blog/hp/my/*http://tw.myblog.yahoo.com");
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
                            HtmlAction.FillTextFieldData(document, "blog_compose", "title", Title);
                            HtmlAction.SetOptionValue(document, "folder_id", "5");
                            HtmlAction.FillTextAreaData(document, "blog_compose", "contents", Article);
                            //HtmlAction.ClickCheckButton(document, "default_category", null);
                            Thread.Sleep(3000);
                            HtmlAction.Submit(document, "blog_compose", "post");
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
            WebBrowser.Url = new Uri("http://tw.rd.yahoo.com/referurl/hp/1024/pa/exit/*https://login.yahoo.com/config/login?&.srv=fpctx&logout=1&.direct=1&.done=http://tw.yahoo.com");            

            while(_isCompleted == false)
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
//            StreamReader sr = null;
//            string strLine;
            try
            {
/*
                sr = new StreamReader(strFilename, Encoding.Default);

                _strTitle = sr.ReadLine();
                _strArticle = "";
                while ((strLine = sr.ReadLine()) != null)
                {
                    _strArticle += strLine + "<br>";
                }
*/

                ParseFile(strFilename);
                _isCompleted = false;
                _iCurrentStep = FILL_BLOG;
                HtmlAction.HrefClick(WebBrowser.Document, "http://tw.blog.yahoo.com/post/post_html.php");
            

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
