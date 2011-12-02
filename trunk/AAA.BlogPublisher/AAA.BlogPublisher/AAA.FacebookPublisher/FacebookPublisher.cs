using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.WebPublisher;
using System.Windows.Forms;
using AAA.Web;
using System.IO;
using System.Threading;

namespace AAA.FacebookPublisher
{
    public class FacebookPublisher : AbstractPublisher
    {
        private string _strHomepage = "http://www.facebook.com/";

        private int _iCurrentStep = -1;
        private bool _isCompleted;

        public FacebookPublisher()
        {
            WebSite = "www.facebook.com";
            WebSiteName = "Facebook";
            IsRegisterReleased = false;
            IsPublisherReleased = false;
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
                _iCurrentStep = LOGIN_FORM;
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
                    case LOGIN_FORM:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = LOGIN_COMPLETED;
                            HtmlAction.FillTextFieldData(document, "login_form", "email", Username);
                            HtmlAction.FillTextFieldData(document, "login_form", "pass", Password);
                            HtmlAction.SetOptionValue(document, "persistent", "0");                            
                            HtmlAction.Submit(document, "login_form", "登入");
                            //HtmlAction.ClickButton(document, null, ".save");
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
                            HtmlAction.ClickTextArea(document, "/ajax/updatestatus.php", "xhpc_message");
                            //HtmlAction.FillTextAreaData(document, "/ajax/updatestatus.php", "xhpc_message", Article);

                            //HtmlAction.ClickCheckButton(document, "default_category", null);                                                        
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
            WebBrowser.Url = new Uri("http://www.facebook.com/logout.php");

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
                //HtmlAction.HrefClick(WebBrowser.Document, "http://www.blogger.com/post-create.g?blogID=6612753544305311345");
                HtmlAction.HrefClick(WebBrowser.Document, "http://www.facebook.com/");


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
