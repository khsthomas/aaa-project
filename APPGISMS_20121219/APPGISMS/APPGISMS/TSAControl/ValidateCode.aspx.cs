using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace APPGISMS.TSAControl
{
    public partial class ValidateCode : System.Web.UI.Page
    {
        // </summary>
        // 撰寫人：Hilda
        // 撰寫日期：2012/02/06
        // 功能簡述：圖片驗證碼顯示
        // 修改人：
        // 修改日期：
        // </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validate Code

            string[] Code ={ "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",

                            "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",

                            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            string strRd = string.Empty;



            Random rd = new Random(unchecked((int)DateTime.Now.Ticks));

            Bitmap Bmp = new Bitmap(80, 25);  //建立實體圖檔並設定大小

            Graphics Gpi = Graphics.FromImage(Bmp);

            Font Font1 = new Font("Verdana", 14, FontStyle.Italic);



            for (int i = 0; i < 5; i++)       // 亂數產生驗證文字
            {

                strRd += Code[rd.Next(35)];

            }



            Pen PenLine = new Pen(Brushes.BlueViolet, 5);  //實體化筆刷並設定顏色、大小(畫X,Y軸用)

            Gpi.Clear(Color.BlanchedAlmond);    //設定背景顏色

            Gpi.DrawLine(PenLine, 0, rd.Next(80), 90, rd.Next(25));

            Gpi.DrawString(strRd, Font1, Brushes.DarkSlateGray, 0, 0);



            for (int i = 0; i <= 25; i++)            //亂數產生霧點，擾亂機器人辨別
            {

                int RandPixelX = rd.Next(0, 80);

                int RandPixelY = rd.Next(0, 25);

                Bmp.SetPixel(RandPixelX, RandPixelY, Color.DarkViolet);

            }



            Session["ValidateCode"] = strRd;        //將驗證碼存入Session以便稍後進行驗證

            Bmp.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);
        }
    }
}
