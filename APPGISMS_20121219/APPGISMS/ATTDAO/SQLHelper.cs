using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace ATTDAO
{
    public class SQLHelper
    {
        public static string strConnection = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        public static string strConnectionSA = ConfigurationManager.ConnectionStrings["ConnectionStringSA"].ToString();


        //Create a hashtable for the parameter cached
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;

            if (trans != null)
                cmd.Transaction = trans;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    if (parm != null)
                    {
                        if ((parm.Direction == ParameterDirection.InputOutput ||
                        parm.Direction == ParameterDirection.Input) &&
                        (parm.Value == null) || parm.Value.ToString() == string.Empty)
                        {
                            parm.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(parm);
                    }
            }
        }




        /// <summary>
        /// Execute a select query that will return a result set
        /// </summary>
        public static SqlDataReader ExecuteReader(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch (Exception e)
            {
                conn.Close();
                throw e;
            }
        }

        /// <summary>
        /// Execute a select query that will return a result set
        /// </summary>
        public static SqlDataReader ExecuteReader(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            //SqlConnection conn = new SqlConnection(connString);
            try
            {
                //PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return rdr;
            }
            catch (Exception e)
            {
                trans.Connection.Close();
                trans.Connection.Dispose();
                throw e;
            }
        }

        /// <summary>
        /// Execute a select query that will return a result set
        /// </summary>
        public static SqlDataReader ExecuteReaderNoClose(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            //SqlConnection conn = new SqlConnection(connString);
            try
            {
                //PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
                SqlDataReader rdr = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return rdr;
            }
            catch (Exception e)
            {
                trans.Connection.Close();
                trans.Connection.Dispose();
                throw e;
            }
        }

        /// <summary>
        /// Execute an OracleCommand (that returns no resultset) against an existing database transaction 
        /// using the provided parameters.
        /// </summary>
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        /// <summary>
        /// Execute a database query which does not include a select
        /// </summary>
        public static int ExecuteNonQuery(string connString, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// Add a set of parameters to the cached
        /// </summary>
        public static void CacheParameters(string cacheKey, params SqlParameter[] cmdParms)
        {
            parmCache[cacheKey] = cmdParms;
        }

        /// <summary>
        /// Fetch parameters from the cache
        /// </summary>
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];
            if (cachedParms == null)
                return null;
            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

      
    }
}
