using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace YEZZ
{
    public class WebHelper
    {
        public static string DownloadFile(Page page, string strFilename, string strContents)
        {
            try
            {
                page.Response.ClearHeaders();
                page.Response.Clear();
                page.Response.Expires = 0;
                page.Response.Buffer = true;
                page.Response.AddHeader("Accept-Language", "zh-tw");
                //檔案名稱
                page.Response.AddHeader("content-disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(strFilename, System.Text.Encoding.UTF8) + "");
                page.Response.ContentType = "Application/octet-stream";
                //檔案內容
                page.Response.Write(strContents);
                page.Response.End();
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }            
        }
    }
}
