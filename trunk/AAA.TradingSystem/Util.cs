using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AAA.Database;
using AAA.Base.Util.Reader;
using System.Windows.Forms;

namespace AAA.TradingSystem
{
    public class Util
    {
        public static void CreateTable()
        {
            if (File.Exists(Environment.CurrentDirectory + @"\create_table.ini") == false)
                return;

            IDatabase database = new AccessDatabase();
            IniReader iniReader = new IniReader(Environment.CurrentDirectory + @"\cfg\system.ini");
            string strUsername;
            string strPassword;
            string strSQL;
            StreamReader sr = null;

            try
            {
                strUsername = iniReader.GetParam("DataSource", "Username");
                strPassword = iniReader.GetParam("DataSource", "Password");
                database.Open(Environment.CurrentDirectory + @"\stocks.mdb", strUsername, strPassword);

                sr = new StreamReader(Environment.CurrentDirectory + @"\create_table.ini");

                while ((strSQL = sr.ReadLine()) != null)
                {
                    if (strSQL.StartsWith("#"))
                        continue;

                    database.ExecuteUpdate(strSQL);
                }

                database.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
                File.Delete(Environment.CurrentDirectory + @"\create_table.ini");
            }

        }

    }
}
