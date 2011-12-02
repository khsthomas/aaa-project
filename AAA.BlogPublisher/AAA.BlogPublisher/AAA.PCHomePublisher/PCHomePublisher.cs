using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.WebPublisher;
using System.Windows.Forms;
using AAA.Web;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace AAA.PCHomePublisher
{

    public class PCHomePublisher : AbstractPublisher
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount); 


        private string _strHomepage = "http://www.pchome.com.tw/";
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

        public PCHomePublisher()
        {
            WebSite = "www.pchome.com.tw";
            WebSiteName = "PCHome部落格";
            NeedPictureValidate = true;
            IsRegisterReleased = false;
            IsPublisherReleased = true;
        }

        public override bool Register()
        {
            throw new NotImplementedException();
        }

        public override bool ReadConfig(string strConfig)
        {
            throw new NotImplementedException();
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
                            HtmlAction.HrefClick(document, "https://member.pchome.com.tw/login.html?ref=http://www.pchome.com.tw/");
                        }
                        break;

                    case LOGIN_FORM:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = REDIRECT_TO_BLOG_HOME;
                            HtmlAction.FillTextFieldData(document, "idcheck", "userId", Username);
                            HtmlAction.FillTextFieldData(document, "idcheck", "passwd", Password);
                            //HtmlSimulateClickImage
                            //SendMessage(WebBrowser.Handle, downCode, wParam, lParam);
                            //SendMessage(WebBrowser.Handle, upCode, wParam, lParam);
                            //HtmlAction.ClickImage(document, null, "loading...");
                        }
                        break;

                    case REDIRECT_TO_BLOG_HOME:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = REDIRECT_TO_BLOG;
                            WebBrowser.Url = new Uri("http://blog.pchome.com.tw/");
                        }
                        break;
                        

                    case REDIRECT_TO_BLOG:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = LOGIN_COMPLETED;
                            WebBrowser.Url = new Uri("http://blog.pchome.com.tw/public_file/index_login.php");
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
                            HtmlAction.FillTextFieldData(document, "ttimes", "d_title", Title);
                            HtmlAction.FillTextAreaData(document, "ttimes", "area_content", Article);
                            //HtmlAction.ClickCheckButton(document, "default_category", null);
                            Thread.Sleep(3000);
                           HtmlAction.ClickButton(document, "pubButton", null);
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
            WebBrowser.Url = new Uri("http://member.pchome.com.tw/logout.html?ref=http://www.pchome.com.tw/");

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
                HtmlAction.HrefClick(WebBrowser.Document, "http://blog.pchome.com.tw/panel/article_add");


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
