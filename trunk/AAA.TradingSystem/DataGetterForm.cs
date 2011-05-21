using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Base.Util.Reader;
using AAA.Web;
using AAA.ResultSet;

namespace AAA.TradingSystem
{
    public partial class DataGetterForm : Form
    {
        public DataGetterForm()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\download.ini");
            IResultSet resultSet;
            HtmlPageDownloader pageDownloader = new HtmlPageDownloader();
            HtmlFileParser fileParser = new HtmlFileParser();
            string[] strUrls;
            string[] strFilenames;
            string[] strWebs;
            
            try
            {
                strWebs = iniReader.GetParam("Web", "WebList").Split(',');
                pageDownloader.Path = Environment.CurrentDirectory;
                pageDownloader.FileType = FileTypeEnum.asc;

                for (int i = 0; i < strWebs.Length; i++)
                {
                    strUrls = iniReader.GetParam(strWebs[i], "URLList").Split(',');
                    strFilenames = iniReader.GetParam(strWebs[i], "Filename").Split(',');

                    for (int j = 0; j < strUrls.Length; j++)
                    {
                        pageDownloader.DownloadPage(iniReader.GetParam(strWebs[i], strUrls[j]), strFilenames[j]);
                        fileParser.ParseTable(Environment.CurrentDirectory + @"\" + strFilenames[j],
                                              Environment.CurrentDirectory + @"\" + strFilenames[j].Replace("html", "csv"),
                                              "/body[1]/table[2]",
                                              ",", 1, 7);
                        resultSet = new TextResultSet(Environment.CurrentDirectory + @"\" + strFilenames[j].Replace("html", "csv"), false);
                        

                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
