using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Database;
using System.Data.Common;

namespace AAA.Download.BasicRecord
{
    public class DefaultBasicRecord : IBasicRecord
    {
        private string _strDatabase;
        private string _strUsername;
        private string _strPassword;

        public string Database
        {
            get { return _strDatabase; }
            set { _strDatabase = value; }
        }
        
        public string Username
        {
            get { return _strUsername; }
            set { _strUsername = value; }
        }        

        public string Password
        {
            get { return _strPassword; }
            set { _strPassword = value; }
        }


        #region IBasicRecord Members

        public List<string> GetStockNo(string strSQL)
        {
            List<string> lstStockNo = new List<string>();
            IDatabase database = null;
            DbDataReader dataReader = null;

            try
            {
                database = new AccessDatabase();
                database.Open(Database, Username, Password);
                dataReader = database.ExecuteQuery(strSQL);

                while (dataReader.Read())
                {
                    lstStockNo.Add(dataReader[0].ToString());
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (dataReader != null)
                    dataReader.Close();
                database.Close();
            }

            return lstStockNo;
        }

        #endregion
    }
}
