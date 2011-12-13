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

//        private string _strTitle;
//        private string _strArticle;

        private int _iCurrentStep = -1;
        private bool _isCompleted;

        public PixnetPublisher()
        {
            WebSite = "www.pixnet.net";
            WebSiteName = "痞客邦部落格";
            IsRegisterReleased = true;
            IsPublisherReleased = true;
        }

        public override bool Register()
        {
            _isCompleted = false;
            _iCurrentStep = REDIRECT_TO_REGISTER;
            WebBrowser.Url = new Uri("http://www.pixnet.net/");

            Username = RegisterInfo["帳號"];
            Password = RegisterInfo["密碼"];
            Blogname = "";

            while (_isCompleted == false)
            {
                Application.DoEvents();
                Thread.Sleep(10);

            }
            return true;
        }

        public override bool CreateBlog()
        {
            _isCompleted = false;
            _iCurrentStep = CREATE_BLOG_LOGIN;
            WebBrowser.Url = new Uri(_strHomepage);

            Username = RegisterInfo["帳號"];
            Password = RegisterInfo["密碼"];
            Blogname = RegisterInfo["帳號"].ToLower();

            while (_isCompleted == false)
            {
                Application.DoEvents();
                Thread.Sleep(10);

            }
            return true;
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
                            HtmlAction.FillTextFieldData(document, "blogarticle_new", "blogarticle_title", Title);
                            HtmlAction.FillTextAreaData(document, "blogarticle_new", "blogarticle_body", Article);
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

                    case REDIRECT_TO_REGISTER:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = REGISTER_FORM;
                            //                            HtmlAction.HrefClick(document, "https://accounts.google.com/NewAccount?continue=http%3A%2F%2Fwww.blogger.com%2Fhome&followup=http%3A%2F%2Fwww.blogger.com%2Fhome&service=blogger&ltmpl=start");                        
                            HtmlAction.HrefClick(document, "http://www.pixnet.net/signup");
                        }
                        break;

                    case REGISTER_FORM:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            if (WebBrowser.Url.ToString() != "http://panel.pixnet.cc/signup/step2")
                                break;

                            HtmlAction.FillTextFieldData(document, "signup_form", "user_name", RegisterInfo["帳號"]);
                            HtmlAction.FillTextFieldData(document, "signup_form", "user_password", RegisterInfo["密碼"]);
                            HtmlAction.FillTextFieldData(document, "signup_form", "user_password2", RegisterInfo["密碼"]);
                            HtmlAction.FillTextFieldData(document, "signup_form", "user_email", RegisterInfo["電子郵件"]);
                            HtmlAction.FillTextFieldData(document, "signup_form", "name", RegisterInfo["姓"] + RegisterInfo["名"]);
                            HtmlAction.ClickRadioButton(document, "Sex", RegisterInfo["性別"] == "男" ? "M" : "F");
                            HtmlAction.SetOptionValue(document, "BirthYear", RegisterInfo["生日年"]);
                            HtmlAction.SetOptionValue(document, "BirthMonth", RegisterInfo["生日月"]);
                            HtmlAction.SetOptionValue(document, "BirthDay", RegisterInfo["生日日"]);
                            HtmlAction.SetOptionValue(document, "Area", RegisterInfo["居住地"]);                            
                            HtmlAction.ClickCheckButton(document, "agree_box", "agree");
                            MessageBox.Show("請確認圖片認証內容, 謝謝!");
                            _isCompleted = true;
                        }
                        break;

                    case CREATE_BLOG_LOGIN:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = REDIRECT_TO_CREATE_BLOG;
                            HtmlAction.FillTextFieldData(document, "input-username", Username);
                            HtmlAction.FillTextFieldData(document, "input-password", Password);
                            HtmlAction.ClickSubmitButton(document, "login-send");
                        }
                        break;

                    case REDIRECT_TO_CREATE_BLOG:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            if (WebBrowser.Url.ToString() != "http://www.pixnet.net/")
                                break;

                            _iCurrentStep = CREATE_BLOG_FORM;
                            HtmlAction.HrefClick(document, "http://panel.pixnet.cc/");
                        }
                        break;
                        

                    case CREATE_BLOG:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {//628530
                            _iCurrentStep = CREATE_BLOG_FORM;
                            HtmlAction.HrefClick(document, "http://panel.pixnet.cc/blog?master_self=true");
                        }
                        break;

                    case CREATE_BLOG_FORM:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = CREATE_BLOG_FORM2;
                            HtmlAction.SetOptionValue(document, "blog_sitecategoryid", RegisterInfo["分類"]);                            
                            HtmlAction.ClickSubmitButton(document, "settings-form", "送出");
                        }
                        break;

                    case CREATE_BLOG_FORM2:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = CREATE_BLOG_FORM3;
                            HtmlAction.Submit(document, "choosetemplate", "ok");
                        }
                        break;

                    case CREATE_BLOG_FORM3:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            //_iCurrentStep = CREATE_BLOG_FORM4;
                            //HtmlAction.Submit(document, "newblog", "ok");
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
