using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace YEZZ.Database
{
    public class MsSqlDatabase
    {
        private string _strErrorMessage;

        public string ErrorMessage
        {
            get { return _strErrorMessage; }
            set { _strErrorMessage = value; }
        }

        private string _strConnectionString;
        
        public string ConnectionString
        {
            get { return _strConnectionString; }
            set { _strConnectionString = value; }
        }

        private string _strSQLStatement;

        public string SQLStatement
        {
            get { return _strSQLStatement; }
            set { _strSQLStatement = value; }
        }

        private SqlConnection _conn;

        public bool Open()
        {
            return Open(ConnectionString);
        }

        public bool Open(string strConnectionString)
        {
            try
            {
                if (_strConnectionString != strConnectionString)
                    _strConnectionString = strConnectionString;
                _conn = new SqlConnection(strConnectionString);
                _conn.Open();
                _dicDataType = new Dictionary<string, SqlDbType>();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "\n" + ex.StackTrace;
            }
            return false;
        }

        private Dictionary<string, SqlDbType> _dicDataType;
        public void SetDataType(string[] strFields, SqlDbType[] eDataType)
        {

        }

        public bool Close()
        {
            try
            {
                if (_conn != null)
                    _conn.Close();
                _dicDataType = null;
          
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "," + ex.StackTrace;
            }
            return false;
        }
        
        public DbDataReader ExecuteQuery(string[] strFields, string[] strValues)
        {
            return ExecuteQuery(SQLStatement, strFields, strValues);
        }

        public DbDataReader ExecuteQuery(string strSQLStatement, string[] strFields, string[] strValues)
        {
            Dictionary<string, string> dicParam = new Dictionary<string, string>();
            for (int i = 0; i < strFields.Length; i++)
            {
                if (strFields[i] == null)
                    continue;

                dicParam.Add(strFields[i], strValues[i]);
            }

            return ExecuteQuery(strSQLStatement, dicParam);
        }

        public DbDataReader ExecuteQuery(Dictionary<string, string> dicParam)
        {
            return ExecuteQuery(SQLStatement, dicParam);
        }

        public DbDataReader ExecuteQuery(string strStatement, Dictionary<string, string> dicParam)
        {
            DbDataReader dbReader = null;
            SqlCommand sqlCommand;
            
            if (_conn.State != ConnectionState.Open)
                _conn.Open();
           
            try
            {
                sqlCommand = new SqlCommand(strStatement, _conn);

                foreach (string strKey in dicParam.Keys)
                {
                    if (_dicDataType.ContainsKey(strKey))
                    {
                        
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue(strKey, dicParam[strKey]);
                    }
                    if (sqlCommand.Parameters[strKey] == null)
                        sqlCommand.Parameters[strKey].Value = DBNull.Value;
                }

                dbReader = sqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "\n" + ex.StackTrace + "\n" + strStatement;
            }

            return dbReader;
        }

        public object ExecuteScalar(string[] strFields, string[] strValues)
        {
            return ExecuteScalar(SQLStatement, strFields, strValues);
        }

        public object ExecuteScalar(string strSQLStatement, string[] strFields, string[] strValues)
        {
            Dictionary<string, string> dicParam = new Dictionary<string, string>();
            for (int i = 0; i < strFields.Length; i++)
            {
                if (strFields[i] == null)
                    continue;

                dicParam.Add(strFields[i], strValues[i]);
            }

            return ExecuteScalar(strSQLStatement, dicParam);
        }

        public object ExecuteScalar(Dictionary<string, string> dicParam)
        {
            return ExecuteScalar(SQLStatement, dicParam);
        }

        public object ExecuteScalar(string strStatement, Dictionary<string, string> dicParam)
        {
            
            SqlCommand sqlCommand;
            object oValue;

            if (_conn.State != ConnectionState.Open)
                _conn.Open();

            try
            {
                sqlCommand = new SqlCommand(strStatement, _conn);

                foreach (string strKey in dicParam.Keys)
                {
                    if(_dicDataType.ContainsKey(strKey))
                    {
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue(strKey, dicParam[strKey]);
                    }
                    if (sqlCommand.Parameters[strKey] == null)
                        sqlCommand.Parameters[strKey].Value = DBNull.Value;
                }

                oValue = sqlCommand.ExecuteScalar();
                _conn.Close();

                if ((oValue == null) || (oValue == DBNull.Value))
                    return null;
                return oValue;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "\n" + ex.StackTrace + "\n" + strStatement;
            }

            return null;
        }

        public int ExecuteNonQuery(string[] strFields, string[] strValues)
        {
            return ExecuteNonQuery(SQLStatement, strFields, strValues);
        }

        public int ExecuteNonQuery(string strSQLStatement, string[] strFields, string[] strValues)
        {
            Dictionary<string, string> dicParam = new Dictionary<string, string>();
            for (int i = 0; i < strFields.Length; i++)
            {
                if (strFields[i] == null)
                    continue;

                dicParam.Add(strFields[i], strValues[i]);
            }

            return ExecuteNonQuery(strSQLStatement, dicParam);
        }

        public int ExecuteNonQuery(Dictionary<string, string> dicParam)
        {
            return ExecuteNonQuery(SQLStatement, dicParam);
        }

        public int ExecuteNonQuery(string strStatement, Dictionary<string, string> dicParam)
        {

            SqlCommand sqlCommand;
            int iRowCount;

            if (_conn.State != ConnectionState.Open)
                _conn.Open();

            try
            {
                sqlCommand = new SqlCommand(strStatement, _conn);

                foreach (string strKey in dicParam.Keys)
                {
                    if (_dicDataType.ContainsKey(strKey))
                    {
                    }
                    else
                    {
                        if (dicParam[strKey] == null)
                        {
                            sqlCommand.Parameters.AddWithValue(strKey, DBNull.Value);
                        }
                        else
                        {
                            sqlCommand.Parameters.AddWithValue(strKey, dicParam[strKey]);
                        }
                    }
//                    if (sqlCommand.Parameters[strKey] == null)
//                        sqlCommand.Parameters[strKey].Value = DBNull.Value;
                }

                iRowCount = sqlCommand.ExecuteNonQuery();
                _conn.Close();
                return iRowCount;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "\n" + ex.StackTrace + "\n" + strStatement;
            }

            return -1;
        }

        public DbDataReader ExecuteStoredProcedure(string strProcedureName, string[] strFields, string[] strValues)
        {
            Dictionary<string, string> dicParam = new Dictionary<string, string>();
            for (int i = 0; i < strFields.Length; i++)
                dicParam.Add(strFields[i], strValues[i]);

            return ExecuteStoredProcedure(strProcedureName, dicParam);
        }

        public DbDataReader ExecuteStoredProcedure(string strProcedureName, Dictionary<string, string> dicParam)
        {
            DbDataReader dbReader = null;
            SqlCommand sqlCommand;

            if (_conn.State != ConnectionState.Open)
                _conn.Open();

            try
            {
                sqlCommand = new SqlCommand(strProcedureName, _conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                foreach (string strKey in dicParam.Keys)
                {
                    if (_dicDataType.ContainsKey(strKey))
                    {

                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue(strKey, dicParam[strKey]);
                    }
                    if (sqlCommand.Parameters[strKey] == null)
                        sqlCommand.Parameters[strKey].Value = DBNull.Value;
                }

                dbReader = sqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "\n" + ex.StackTrace + "\n" + strProcedureName;
            }

            return dbReader;
        }


    }
}
