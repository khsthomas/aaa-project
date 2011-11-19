using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.WebPublisher;
using System.Windows.Forms;
using AAA.Web;
using System.IO;
using System.Threading;

namespace AAA.PixnetPublisher
{
    public class PixnetPublisher : AbstractPublisher
    {
        private string _strHomepage = "http://www.pixnet.net/";

        private string _strTitle;
        private string _strArticle;

        private int _iCurrentStep = -1;
        private bool _isCompleted;

        public PixnetPublisher()
        {
            WebSite = "www.pixnet.net";
            WebSiteName = "痞客邦部落格";
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
                            _iCurrentStep = REDIRECT_TO_BLOG;
                            HtmlAction.FillTextFieldData(document, "input-username", Username);
                            HtmlAction.FillTextFieldData(document, "input-password", Password);
                            HtmlAction.ClickSubmitButton(document, "login-send");
                            //HtmlAction.ClickButton(document, null, ".save");
                        }
                        break;

                    case REDIRECT_TO_BLOG:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = LOGIN_COMPLETED;
                            HtmlAction.HrefClick(document, "http://" + Blogname + ".pixnet.net/blog");
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
                            if (document.Url.OriginalString != "http://panel.pixnet.cc/blog/articlenew")
                            {
                                HtmlAction.HrefClick(WebBrowser.Document, "http://panel.pixnet.cc/blog/articlenew");
                                return true;
                            }
                            _iCurrentStep = PUBLISH;                            
                            HtmlAction.FillTextFieldData(document, "blogarticle_new", "blogarticle_title", _strTitle);
                            HtmlAction.FillTextAreaData(document, "blogarticle_new", "blogarticle_body", _strArticle);
                            //HtmlAction.FillTextFieldDataWithoutForm(document, "blogarticle_title", _strTitle);
                            //HtmlAction.FillTextAreaDataWithoutForm(document, "blogarticle_body", _strArticle);
                            HtmlAction.SetOptionValue(document, "blogarticle_sitecategoryid", "5");
                            Thread.Sleep(3000);
                            HtmlAction.ClickSubmitButtonById(document, "submit-button");
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
            WebBrowser.Url = new Uri("http://panel.pixnet.cc/logout");

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
                HtmlAction.HrefClick(WebBrowser.Document, "http://panel.pixnet.cc/blog/articlenew");


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
