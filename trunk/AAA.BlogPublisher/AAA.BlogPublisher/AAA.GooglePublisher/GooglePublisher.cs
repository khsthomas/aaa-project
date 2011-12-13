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

        private string _strTitle;
        private string _strArticle;
*/
        private int _iCurrentStep = -1;
        private bool _isCompleted;
        private bool _isReference;

        public GooglePublisher()
        {
            WebSite = "www.google.com";
            WebSiteName = "Google部落格";
            IsRegisterReleased = true;
            IsPublisherReleased = true;
        }

        public override bool Register()
        {
            _isCompleted = false;
            _iCurrentStep = REDIRECT_TO_REGISTER;
            WebBrowser.Url = new Uri("http://mail.google.com");

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
            WebBrowser.Url = new Uri("http://www.blogger.com");

            Username = RegisterInfo["帳號"] + "@gmail.com";
            Password = RegisterInfo["密碼"];
            Blogname = "";

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
            string strBlogId;
            try
            {                
                switch (_iCurrentStep)
                {
                    case REDIRECT_TO_LOGIN:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = LOGIN_FORM;
                            HtmlAction.HrefClick(document, "https://accounts.google.com/ServiceLogin?hl=zh-TW&continue=http://www.google.com/");
                        }
                        break;

                    case LOGIN_FORM:
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
                            if (Blogname == "")
                            {
                                strBlogId = ParseBlogId(WebBrowser.Document);
                                Blogname = strBlogId;
                                _isReference = false;
                            }
                            LoginCompleted = true;
                        }
                        break;

                    case FILL_BLOG:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            Thread.Sleep(3000);
                            _iCurrentStep = PUBLISH;
                            HtmlAction.FillTextFieldData(document, "postingForm", "title", Title);
                            HtmlAction.FillTextAreaData(document, "postingForm", "postBody", Article);
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


                    case REDIRECT_TO_REGISTER:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {                        
                            _iCurrentStep = REGISTER_FORM;
//                            HtmlAction.HrefClick(document, "https://accounts.google.com/NewAccount?continue=http%3A%2F%2Fwww.blogger.com%2Fhome&followup=http%3A%2F%2Fwww.blogger.com%2Fhome&service=blogger&ltmpl=start");                        
                            HtmlAction.HrefClick(document, "http://mail.google.com/mail/signup");
                        }
                        break;

                    case REGISTER_FORM:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = BLOG_MOBILE_CONFIRM;
                            HtmlAction.FillTextFieldData(document, "createaccount", "LastName", RegisterInfo["姓"]);
                            HtmlAction.FillTextFieldData(document, "createaccount", "FirstName", RegisterInfo["名"]);
                            HtmlAction.FillTextFieldData(document, "createaccount", "Email", RegisterInfo["帳號"]);
                            HtmlAction.FillTextFieldData(document, "createaccount", "Passwd", RegisterInfo["密碼"]);
                            HtmlAction.FillTextFieldData(document, "createaccount", "PasswdAgain", RegisterInfo["密碼"]);
                            HtmlAction.ClickCheckButton(document, "PersistentCookie", null);                                                                   
                            HtmlAction.ClickCheckButton(document, "smhck", "1");
                            HtmlAction.ClickCheckButton(document, "homepageSet", null);
                            HtmlAction.SetOptionValue(document, "questions", "您小時候最要好的朋友姓名為何？");
                            HtmlAction.FillTextFieldData(document, "createaccount", "IdentityAnswer", RegisterInfo["答案1"]);
                            HtmlAction.SetOptionValue(document, "loc", "TW");
                            HtmlAction.FillTextFieldData(document, "createaccount", "Birthday", RegisterInfo["生日年"] + "/" + RegisterInfo["生日月"] + "/" + RegisterInfo["生日日"]);                            
                            MessageBox.Show("請確認圖片認証內容, 謝謝!");                                                        
                        }
                        break;

                    case BLOG_MOBILE_CONFIRM:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            if (WebBrowser.Url.ToString() == "http://mail.google.com/mail/help/intl/zh-TW/intro.html")
                            {
                                HtmlAction.HrefClick(document, "http://mail.google.com/mail");
                                
                            }
                            else
                            {
                                _iCurrentStep = INPUT_CONFIRM_CODE;
                                HtmlAction.FillTextFieldData(document, "smschallenge", "MobileNumber", RegisterInfo["手機號碼"]);
                                HtmlAction.Submit(document, "smschallenge", "submitbutton");                                
                            }
                        }
                        break;

                    case INPUT_CONFIRM_CODE:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = COMPLETED_CONFIRM;
                            MessageBox.Show("請輸入驗證碼後按確認, 確認後請按開站按鈕, 謝謝!");
                        }
                        break;

                    case COMPLETED_CONFIRM:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            //WebBrowser.Url = new Uri("http://www.blogger.com");
                            _isCompleted = true;
                        }
                        break;

                    case CREATE_BLOG_LOGIN:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = CREATE_BLOG_LOGIN_FORM;
                            HtmlAction.HrefClick(document, "https://accounts.google.com/ServiceLogin?hl=zh-TW&continue=http://www.blogger.com/");
                        }
                        break;

                    case CREATE_BLOG_LOGIN_FORM:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = REDIRECT_TO_CREATE_BLOG;
                            //_iCurrentStep = CREATE_BLOG;
                            HtmlAction.FillTextFieldData(document, "gaia_loginform", "Email", Username);
                            HtmlAction.FillTextFieldData(document, "gaia_loginform", "Passwd", Password);
                            HtmlAction.Submit(document, "gaia_loginform", "signIn");
                            //HtmlAction.ClickButton(document, null, ".save");
                        }
                        break;


                    case REDIRECT_TO_CREATE_BLOG:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = CREATE_BLOG;
                            HtmlAction.FillTextFieldData(document, "createaccount", "displayname", RegisterInfo["顯示名稱"]);
                            HtmlAction.SetOptionValue(document, "Gender", RegisterInfo["性別"] == "男" ? "MALE" : "FEMALE");
                            HtmlAction.ClickCheckButton(document, "termsofservice", "1");
                            HtmlAction.Submit(document, "createaccount", "submitbutton");                                
                            
                        }
                        break;                        

                    case CREATE_BLOG:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = CREATE_BLOG_FORM;
                            //HtmlAction.HrefClick(document, "create-blog.g");
                            HtmlAction.HrefClick(document, "http://www.blogger.com/create-blog.g");                            
                        }                                            
                        break;

                    case CREATE_BLOG_FORM:
                        if (WebBrowser.ReadyState == WebBrowserReadyState.Complete)
                        {
                            _iCurrentStep = CREATE_BLOG_FORM2;

                            HtmlAction.FillTextFieldData(document, "newblog", "blogtitle", RegisterInfo["網誌標題"]);
                            HtmlAction.FillTextFieldData(document, "newblog", "blogspotname", RegisterInfo["帳號"]);                            
                            HtmlAction.Submit(document, "newblog", "ok");                                
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

        private string ParseBlogId(HtmlDocument document)
        {
            string strBlogId = "";
            string strHref = "";
            int iStartIndex;            
            try
            {
                for (int i = 0; i < document.All.Count; i++)
                {
                    if (document.All[i].TagName == "A")
                    {
                        strHref = document.All[i].GetAttribute("href").ToString();

                        if ((iStartIndex = strHref.IndexOf("blogID=")) > -1)
                        {
                            iStartIndex += "blogID=".Length;
                            strBlogId = strHref.Substring(iStartIndex);
                            break;
                        }                        
                    }
                }

/*
                iStartIndex = strHtml.IndexOf("<a href=\"posts.g?blogID=") + "<a href=\"posts.g?blogID=".Length;
                iEndIndex = strHtml.IndexOf("\"", iStartIndex + 1);
                strBlogId = strHtml.Substring(iStartIndex, iEndIndex);
 */ 
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "," + ex.StackTrace;
            }

            return strBlogId;
        }

        public override bool Logout()
        {
            _isCompleted = false;
            _iCurrentStep = LOGOUT;
            WebBrowser.Url = new Uri("http://www.blogger.com/logout.g");
            //https://mail.google.com/mail/?logout&hl=zh-TW
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
