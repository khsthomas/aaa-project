using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Base.Util;
using AAA.Base.Util.Cryptography;
using System.IO;

namespace AAA.TradingTool
{
    public partial class KeyGeneratorForm : Form
    {
        private const int KEY_LEN = 200;
        private const string DEFAULT_KEY = "P@ssw0rd";
        private readonly int[] INDEX = new int[] {15, 28, 46,  1, 75, 99, 61, 25, 53, 36, 
                                                  47,  8, 29, 33, 83, 77, 68,  3, 19, 93,
                                                  27, 43, 97, 61, 87};
        private const string ALLOWED_CHAR = "!@#$%^&*()_+=-~`,./|ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        //ID = 10
        //PW = 7
        //Date = 8;

        public KeyGeneratorForm()
        {
            InitializeComponent();
        }

        private void Encrypt()
        {
            StringBuilder sbKey = new StringBuilder(KEY_LEN);
            StreamWriter sw = null;

            try
            {

                string strIndex = "";
                for (int i = 0; i < INDEX.Length; i++)
                    strIndex += INDEX[i].ToString("00");

                sw = new StreamWriter(Environment.CurrentDirectory + @"\net.dll");
                sw.Write(DES.EncryptString(strIndex, DEFAULT_KEY, Encoding.Default));
                sw.Close();

                string strData = txtIdNo.Text.Trim() +
                                 txtAccountPassword.Text.Trim() +
                                 dtpDueDate.Value.ToString("yyyyMMdd").Trim();
                string strRSAKey = txtPassword.Text.Trim();

                for (int i = 0; i < KEY_LEN; i++)
                {
                    sbKey.Append(ALLOWED_CHAR.Substring(NumericHelper.Randomize(0, ALLOWED_CHAR.Length - 1), 1));
                }

                for (int i = 0; i < INDEX.Length; i++)
                {
                    sbKey[INDEX[i]] = strData[i];
                }

                string strEnRSA = RSA.EncryptString(sbKey.ToString(), strRSAKey);

                sw = new StreamWriter(Environment.CurrentDirectory + @"\errorcode.dat");
                sw.Write(strEnRSA);
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            

            try
            {
                //MessageBox.Show(strEnRSA);



                //string strDeDes = RSA.DecryptString(strEnRSA, strRSAKey);

                //string strDeString = "";
                //for (int i = 0; i < INDEX.Length; i++)
                //    strDeString += strDeDes[INDEX[i]];

                //MessageBox.Show(strDeString);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
