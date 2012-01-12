using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Base.Util.Reader;
using System.IO;


namespace AAA.BlogPublisher
{
    public partial class ArticleEditor : Form
    {
        private const string COMPLETED_TITLE = "免費寄存檔案和圖片 - BADONGO";
        private Dictionary<string, string> _dicPicture;
        private bool _isProcessing = false;
        private string _strCurrentPicture = "";
        private string _strPictureWebSite = "http://www.badongo.com";
        private string _strAppPath = Environment.CurrentDirectory;
        public ArticleEditor()
        {
            InitializeComponent();
            wbPictureSite.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wbPictureSite_DocumentCompleted);
            wbPictureSite.Url = new Uri(_strPictureWebSite);            
        }

        void wbPictureSite_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if ((_isProcessing == false) && (wbPictureSite.ReadyState == WebBrowserReadyState.Complete))
                {                                        
                    try
                    {
                        wbPictureSite.Document.Window.ScrollTo(150, 0);
                    }
                    catch { }
                    ParseHtml(wbPictureSite.Document);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        void ParseHtml(HtmlDocument document)
        {
            HtmlElement pictureLink;
            string strPictureDesc = DateTime.Now.ToString("yyyyMMddHHmmss");
            try
            {
                if (document.Title != COMPLETED_TITLE)
                    return;

                pictureLink = document.GetElementById("box0");

                if (pictureLink == null)
                    return;

                if (pictureLink.GetAttribute("value") != null)
                {
                    if ((_isProcessing == false))
                    {
                        if (txtPictureDesc.Text != "")
                        {
                            if (_dicPicture.ContainsKey(txtPictureDesc.Text) && (pictureLink.GetAttribute("value") != _strCurrentPicture))
                            {
                                MessageBox.Show("圖片說明重覆, 將使用" + strPictureDesc + "作為圖片說明");
                            }
                            else
                            {
                                strPictureDesc = txtPictureDesc.Text;
                            }
                        }
                        else
                        {
                            MessageBox.Show("圖片說明為空白, 將使用" + strPictureDesc + "作為圖片說明");
                        }
                    }
                    _isProcessing = true;
                    _strCurrentPicture = pictureLink.GetAttribute("value").ToString().Replace("/pic/", "/t/800/");
                    _dicPicture.Add(strPictureDesc, _strCurrentPicture);
                    tblPicture.Rows.Add(new string[] { strPictureDesc, _strCurrentPicture });
                    WriteList(strPictureDesc, _strCurrentPicture);
                    wbPictureSite.Url = new Uri(_strPictureWebSite);                    
                    _isProcessing = false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                _isProcessing = false;                
            }
        }

        void WriteList(string strDesc, string strUrl)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(_strAppPath + @"\cfg\picture.ini", true, Encoding.Default);
                sw.WriteLine(strDesc + "=" + strUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

        private void ArticleEditor_Load(object sender, EventArgs e)
        {
            tblPicture.Columns.Add("Picture", "圖片說明");
            tblPicture.Columns.Add("PictureUrl", "圖片連結");

            _dicPicture = new Dictionary<string, string>();
            if (File.Exists(_strAppPath + @"\cfg\picture.ini") == false)
                return;

            IniReader iniReader = new IniReader(_strAppPath + @"\cfg\picture.ini");
            try
            {
                foreach (string strKey in iniReader.GetKey("Default"))
                {
                    _dicPicture.Add(strKey, iniReader.GetParam(strKey));
                    tblPicture.Rows.Add(new string[] { strKey, iniReader.GetParam(strKey)});
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            wbPictureSite.Url = new Uri(_strPictureWebSite);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (lblFilename.Text.Trim().Length == 0)
            {
                MessageBox.Show("請先載入文章, 謝謝!");
                return;
            }

            try
            {
                for (int i = 0; i < tblPicture.SelectedRows.Count; i++)
                {
                    txtArticle.AppendText("<img src=\"" + tblPicture.SelectedRows[i].Cells["PictureUrl"].Value.ToString() + "\">\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnLoadArticle_Click(object sender, EventArgs e)
        {
            StreamReader sr = null;
            string strLine = null;
            try
            {
                openFile.FileName = Environment.CurrentDirectory + @"\articles\*.txt";
                if (openFile.ShowDialog() != DialogResult.OK)
                    return;

                lblFilename.Text = openFile.FileName;

                sr = new StreamReader(lblFilename.Text, Encoding.Default);

                while ((strLine = sr.ReadLine()) != null)
                    txtArticle.AppendText(strLine + "\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        private void btnSaveArticle_Click(object sender, EventArgs e)
        {
            StreamWriter sw = null;
            try
            {
                if (lblFilename.Text.Trim().Length == 0)
                {
                    MessageBox.Show("請先載入文章, 謝謝!");
                    return;
                }

                sw = new StreamWriter(lblFilename.Text, false, Encoding.Default);
                for (int i = 0; i < txtArticle.Lines.Length; i++)
                {
                    sw.WriteLine(txtArticle.Lines[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }
    }
}
