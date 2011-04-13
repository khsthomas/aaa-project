using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Base.Util.Reader;
using System.Xml;
using AAA.Web;
using AAA.Download.BasicRecord;

namespace AAA.Download.PageDownload
{
    public class Program
    {
        private static void DisplayUsage()
        {
            Console.WriteLine("Usage : ");
            Console.WriteLine("AAA.Download.PageDownload config-file param-type(int | date | stockno) [start index] [end index]");
        }

        static void Main(string[] args)
        {            
            if (args.Length < 2)
            {
                DisplayUsage();
                return;
            }

            XmlParser xmlParser = new XmlParser(args[0]);
            HtmlPageDownloader downloader = new HtmlPageDownloader();
            string strRootPath;
            string strUrl;
            string strFilename;
            string strFileType;
            string strPath;
            List<object> lstParameter = new List<object>();
            List<string> lstStockNo;
            DateTime dtStart;
            DateTime dtEnd;

            strRootPath = xmlParser.GetSingleNode("/config/root-path").InnerText;

            if (strRootPath == ".")
                strRootPath = Environment.CurrentDirectory;

            switch (args[1])
            {
                case "int":
                    if (args.Length < 4)
                    {
                        DisplayUsage();
                        return;
                    }
                    for (int i = int.Parse(args[2]); i <= int.Parse(args[3]); i++)
                        lstParameter.Add(i);
                    break;
                case "date":
                    switch (args.Length)
                    {
                        case 2:
                            lstParameter.Add(DateTime.Now);
                            break;
                        case 3:
                            lstParameter.Add(DateTime.Now.AddDays(int.Parse(args[2])));
                            break;
                        case 4:
                            dtStart = DateTime.Parse(args[2]);
                            dtEnd = DateTime.Parse(args[3]);

                            while (dtStart <= dtEnd)
                            {
                                lstParameter.Add(new DateTime(dtStart.Ticks));
                                dtStart = dtStart.AddDays(1);
                            }
                            break;
                    }
                    break;
                case "stockno":
                    IBasicRecord basicRecord = new DefaultBasicRecord();
                    ((DefaultBasicRecord)basicRecord).Database = xmlParser.GetSingleNode("/config/database/database").InnerText;
                    ((DefaultBasicRecord)basicRecord).Username = xmlParser.GetSingleNode("/config/database/username").InnerText;
                    ((DefaultBasicRecord)basicRecord).Password = xmlParser.GetSingleNode("/config/database/password").InnerText;

                    if (((DefaultBasicRecord)basicRecord).Database.StartsWith("."))
                        ((DefaultBasicRecord)basicRecord).Database = Environment.CurrentDirectory + ((DefaultBasicRecord)basicRecord).Database.Substring(1);

                    lstStockNo = basicRecord.GetStockNo(xmlParser.GetSingleNode("/config/database/sql").InnerText);
                    foreach (string strStockNo in lstStockNo)
                        lstParameter.Add(strStockNo);
                    break;

            }

            foreach (XmlNode xmlNode in xmlParser.GetNodes("/config/web"))
            {
                strUrl = xmlParser.GetSingleNode(xmlNode, "url").InnerText;
                strPath = xmlParser.GetSingleNode(xmlNode, "path").InnerText;
                strFilename = xmlParser.GetSingleNode(xmlNode, "filename").InnerText;
                strFileType = xmlParser.GetSingleNode(xmlNode, "file-type").InnerText;

                downloader.Path = strRootPath + @"\" + strPath;
                downloader.FileType = (FileTypeEnum)Enum.Parse(typeof(FileTypeEnum), strFileType);
                downloader.DownloadPages(strUrl, strFilename, lstParameter);
                Console.WriteLine(downloader.Message);
            }

        }
    }
}
