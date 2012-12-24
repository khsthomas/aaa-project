using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using System.Net;
using System.Net.Mail;
using System.ComponentModel;

namespace APPGISMS
{
    public class EmailControl
    {
        public bool sendEmail(string strtoEmail, string strSubject, string strBody)
        {

            string strfromEmail = "gisadmin@cda.org.tw";
            string strfromName = "GIS DBAdmin";
            //MailAddress from = new MailAddress(strfromEmail, strfromName, System.Text.Encoding.UTF8);

            //MailMessage mail = new MailMessage(from, new MailAddress(strtoEmail));
            MailMessage mail = new MailMessage();
            mail.To.Add(strtoEmail);
            mail.From = new MailAddress(strfromEmail, strfromName);

            mail.Subject = strSubject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            mail.Body = strBody;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = false;
            mail.Priority = MailPriority.High;

            //SmtpClient client = new SmtpClient("203.69.170.193");
            //client.Credentials = new NetworkCredential("gisadmin", "gisadmin123");
            SmtpClient client = new SmtpClient("m2k.yezz.com.tw");
            client.Credentials = new NetworkCredential("bennet@yezz.com.tw", "ZXCasd0972");
            client.EnableSsl = false;
            client.Port = 25;

            try
            {
                //you can also call client.Send(msg)                
                //client.SendAsync(mailMsg, userState);
                client.Send(mail);
                return true;
            }
            catch (SmtpException)
            {
                //Catch errors...   
                return false;
            }

        }

        public bool sendEmail(string strfromEmail, string strfromName, string strtoEmail, string strSubject, string strBody)
        {



            //MailAddress from = new MailAddress(strfromEmail, strfromName, System.Text.Encoding.UTF8);

            //MailMessage mail = new MailMessage(from, new MailAddress(strtoEmail));
            MailMessage mail = new MailMessage();
            mail.To.Add(strtoEmail);
            mail.From = new MailAddress(strfromEmail, strfromName);

            mail.Subject = strSubject;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            mail.Body = strBody;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = false;
            mail.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient("203.69.170.193");
            client.Credentials = new NetworkCredential("gisadmin", "gisadmin123");
            client.EnableSsl = false;

            try
            {
                //you can also call client.Send(msg)                
                //client.SendAsync(mailMsg, userState);
                client.Send(mail);
                return true;
            }
            catch (SmtpException)
            {
                //Catch errors...   
                return false;
            }

        }

        // </summary>
        // 撰寫人：Jacky
        // 撰寫日期：2010/09/09
        // 功能簡述：Email發送
        // 最後更新日期：
        // 修改人：
        // 修改日期：
        // </summary>
        public bool sendEmail(DataTable dttoEmail, string strSubject, string strBody)
        {
            string strfromEmail = "gisadmin@cda.org.tw";
            string strfromName = "GIS Administrator";

            MailMessage mailMsg = new MailMessage();
            mailMsg.From = new MailAddress(strfromEmail, strfromName, System.Text.Encoding.UTF8);
            for (int i = 0; i < dttoEmail.Rows.Count; i++)
            {
                mailMsg.To.Add(dttoEmail.Rows[i]["EMAIL"].ToString());
            }

            mailMsg.Subject = strSubject;
            mailMsg.SubjectEncoding = System.Text.Encoding.UTF8;

            mailMsg.Body = strBody;
            mailMsg.BodyEncoding = System.Text.Encoding.UTF8;
            mailMsg.IsBodyHtml = false;
            mailMsg.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();
            //client.Host = "smtp.gmail.com";
            //client.Port = 110;
            client.Host = "203.69.170.193";

            // 寄件人信箱, 密碼
            //client.Credentials = new NetworkCredential(strfromEmail, "密碼");
            client.Credentials = new NetworkCredential("gisadmin", "gisadmin123");
            client.EnableSsl = false;


            try
            {
                //you can also call client.Send(msg)                
                //client.SendAsync(mailMsg, userState);
                client.Send(mailMsg);
                return true;
            }
            catch (SmtpException)
            {
                //Catch errors...   
                return false;
            }


        }
    }
}
