using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YEZZ.Database;
using System.Data;
using System.Data.Common;

namespace YEZZ.Model
{
    public abstract class AbstractDataModel : IDataModel
    {
        private Dictionary<string, object> _dicValue;
        private List<string> _lstAutoIncreaseField;
        private string _strErrorMessage;
        private string _strTablePostfix = "";

        public const string NOT_CHANGE_VALUE = "ABSTRACT_DATA_MODEL_NOT_CHANGE_VALUE";        

        public string TablePostfix
        {
            get { return _strTablePostfix; }
            set { _strTablePostfix = value; }
        }

        public string CurrentTableName
        {
            get { return TableName + TablePostfix; }
        }

        public string ErrorMessage
        {
            get { return _strErrorMessage; }
            set { _strErrorMessage = value; }
        }

        public AbstractDataModel()
        {
            _dicValue = new Dictionary<string, object>();
            _lstAutoIncreaseField = new List<string>();
        }

        public void AddAutoIncreaseField(string strField)
        {
            if(_lstAutoIncreaseField.IndexOf(strField) < 0)
            _lstAutoIncreaseField.Add(strField);
        }

        private string[] _strPrimaryKeys;

        public string[] PrimaryKeys
        {
            get { return _strPrimaryKeys; }
            set { _strPrimaryKeys = value; }
        }
        private string[] _strFields;

        public string[] Fields
        {
            get { return _strFields; }
            set { _strFields = value; }
        }

        private SqlDbType[] _eDataTypes;

        public SqlDbType[] DataTypes
        {
            get { return _eDataTypes; }
            set { _eDataTypes = value; }
        }

        private string _strTableName;

        public string TableName
        {
            get { return _strTableName; }
            set { _strTableName = value; }
        }

        private string _strDatabaseName;
        protected void SetDatabaseName(string strDatabaseName)
        {
            _strDatabaseName = strDatabaseName;
        }
        public string DatabaseName { get { return _strDatabaseName; } }

        public MsSqlDatabase Database { get { return DataBuilder.CreateDatabase(DatabaseName); } }

        public bool Exists()
        {
            MsSqlDatabase db = Database;
            string strCondition = "";
            string[] strValues;
            object oScalarValue;

            strValues = new string[PrimaryKeys.Length];

            for(int i = 0; i < PrimaryKeys.Length; i++)
            {
                strCondition += " AND " + PrimaryKeys[i] + " = @" + PrimaryKeys[i];
                strValues[i] = Value(PrimaryKeys[i]).ToString();
            }
            
            oScalarValue = db.ExecuteScalar("SELECT COUNT(*) FROM " + TableName + TablePostfix + " WHERE " + strCondition.Substring(" AND ".Length),
                                            PrimaryKeys,
                                            strValues);

            db.Close();
            if (oScalarValue == null)
            {               
                ErrorMessage = db.ErrorMessage;
                return false;
            }

            if (((int)oScalarValue) > 0)
                return true;

            return false;

        }

        public void Value(string strField, object oValue)
        {
            if (_dicValue.ContainsKey(strField))
                _dicValue[strField] = oValue;
            else
                _dicValue.Add(strField, oValue);
        }

        public object Value(string strField)
        {
            return _dicValue.ContainsKey(strField)
                    ? _dicValue[strField]
                    : null;
        }

        public bool ExecuteUpdate(string strStatement, string[] strFields, string[] strValues)
        {
            if (strFields == null)
                strFields = new string[0];
            if (strValues == null)
                strValues = new string[0]; 
                
            return Database.ExecuteNonQuery(strStatement, strFields, strValues) >= 0;
        }

        public virtual bool ExecuteUpdate()
        {
            MsSqlDatabase db = Database;
            string strCondition = "";
            string strSetStatement = "";
            string[] strValues;
            string[] strFields;
            int iRowCount;

            ErrorMessage = null;

            try
            {
                if (Fields.Length == 0)
                    return true;

                strValues = new string[PrimaryKeys.Length + Fields.Length];
                strFields = new string[PrimaryKeys.Length + Fields.Length];

                for (int i = 0; i < PrimaryKeys.Length; i++)
                {
                    strCondition += " AND " + PrimaryKeys[i] + " = @" + PrimaryKeys[i];
                    strValues[i] = Value(PrimaryKeys[i]) == null ? null : Value(PrimaryKeys[i]).ToString();
                    strFields[i] = "@" + PrimaryKeys[i];
                }

                for (int i = 0; i < Fields.Length; i++)
                {
                    if(Value(Fields[i]) != null)
                        if (Value(Fields[i]).ToString() == NOT_CHANGE_VALUE)
                            continue;
                    strSetStatement += "," + Fields[i] + "=" + "@" + Fields[i];

                    strValues[i + PrimaryKeys.Length] = Value(Fields[i]) == null ? null : Value(Fields[i]).ToString();
                    strFields[i + PrimaryKeys.Length] = "@" + Fields[i];
                }

                iRowCount = db.ExecuteNonQuery("UPDATE " + TableName + TablePostfix + " SET " + strSetStatement.Substring(1) + " WHERE " + strCondition.Substring(" AND ".Length),
                                                strFields,
                                                strValues);

                db.Close();

                if (iRowCount < 0)
                {                    
                    ErrorMessage = db.ErrorMessage;
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "," + ex.StackTrace;
            }
            return false;


        }

        public virtual bool ExecuteInsert()
        {
            MsSqlDatabase db = Database;
            string strFieldList = "";
            string strParamList = "";
            string[] strValues;
            string[] strFields;
            int iRowCount;
            int iOffset;
            ErrorMessage = null;

            try
            {
                strValues = new string[PrimaryKeys.Length + Fields.Length - _lstAutoIncreaseField.Count];
                strFields = new string[PrimaryKeys.Length + Fields.Length - _lstAutoIncreaseField.Count];
                iOffset = 0;
                for (int i = 0; i < PrimaryKeys.Length; i++)
                {
                    if (_lstAutoIncreaseField.IndexOf(PrimaryKeys[i]) > -1)
                    {
                        iOffset++;
                        continue;
                    }

                    strFieldList += "," + PrimaryKeys[i];
                    strParamList += ", @" + PrimaryKeys[i];

                    strValues[i - iOffset] = Value(PrimaryKeys[i]) == null ? null : Value(PrimaryKeys[i]).ToString();
                    strFields[i - iOffset] = "@" + PrimaryKeys[i];
                }

                for (int i = 0; i < Fields.Length; i++)
                {
                    strFieldList += "," + Fields[i];
                    strParamList += ", @" + Fields[i];

                    strValues[i + PrimaryKeys.Length - iOffset] = Value(Fields[i]) == null ? null : Value(Fields[i]).ToString();
                    strFields[i + PrimaryKeys.Length - iOffset] = "@" + Fields[i];
                }

                iRowCount = db.ExecuteNonQuery("INSERT INTO " + TableName + TablePostfix + "(" + strFieldList.Substring(1) + ") VALUES(" + strParamList.Substring(1) + ")",
                                               strFields,
                                               strValues);

                db.Close();

                if (iRowCount < 0)
                {                    
                    ErrorMessage = db.ErrorMessage;
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "," + ex.StackTrace;
            }
            return false;

        }

        public virtual bool ExecuteDelete()
        {
            MsSqlDatabase db = Database;
            string strCondition = "";
            string[] strValues;
            int iRowCount;

            ErrorMessage = null;

            try
            {
                strValues = new string[PrimaryKeys.Length];

                for (int i = 0; i < PrimaryKeys.Length; i++)
                {
                    strCondition += " AND " + PrimaryKeys[i] + " = @" + PrimaryKeys[i];
                    strValues[i] = Value(PrimaryKeys[i]).ToString();
                }

                iRowCount = db.ExecuteNonQuery("DELETE FROM " + TableName + TablePostfix + " WHERE " + strCondition.Substring(" AND ".Length),
                                                PrimaryKeys,
                                                strValues);

                db.Close();

                if (iRowCount < 0)
                {                 
                    ErrorMessage = db.ErrorMessage;
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "," + ex.StackTrace;
            }
            return false;

        }

        public bool ExecuteDelete(string strStatement, string[] strFields, string[] strValues)
        {
            if (strFields == null)
                strFields = new string[0];
            if (strValues == null)
                strValues = new string[0];

            MsSqlDatabase db = Database;
            bool isSuccess = db.ExecuteNonQuery(strStatement, strFields, strValues) >= 0;
            if (isSuccess == false)
                ErrorMessage = db.ErrorMessage;
            db.Close();
            
            return isSuccess;
            
        }

        public abstract IDataModel CreateInstance();

        public virtual T QueryFirst<T> (string[] strFields, string[] strValues)
        {
            List<T> lstResult = Query<T>(strFields, strValues);
            if (lstResult == null)
                return default(T);

            if (lstResult.Count > 0)
                return lstResult[0];

            return default(T);
        }

        public virtual T QueryByPrimaryKey<T>(string[] strValues)
        {
            return QueryFirst<T>(PrimaryKeys, strValues);
        }

        public virtual List<T> Query<T>(string[] strFields, string[] strValues)
        {
            return Query<T>(null, strFields, strValues);
        }

        public virtual List<T> Query<T>(string strStatement, string[] strFields, string[] strValues)
        {            
            string strFieldList = "";
            MsSqlDatabase db = Database;
            DbDataReader dbReader = null;            
            string strCondition = "";
            ErrorMessage = null;
            List<T> lstResult = new List<T>();
            IDataModel dataModel;
            string[] strResultFields;

            try
            {

                if (strFields == null)
                    strFields = new string[0];
                if (strValues == null)
                    strValues = new string[0];


                if (strStatement == null)
                {
                    for (int i = 0; i < PrimaryKeys.Length; i++)
                        strFieldList += "," + PrimaryKeys[i];

                    for (int i = 0; i < Fields.Length; i++)
                        strFieldList += "," + Fields[i];

                    for (int i = 0; i < strFields.Length; i++)
                    {
                        strCondition += " AND " + strFields[i] + " = @" + strFields[i];
                        strValues[i] = strValues[i] == null ? null : strValues[i].ToString();
                    }

                    if (strFieldList.Length > 0)
                        strStatement = "SELECT " + strFieldList.Substring(1) +
                                        " FROM " + TableName + TablePostfix +
                                        ((strCondition.Length > 0)
                                            ? " WHERE " + strCondition.Substring(" AND ".Length)
                                            : "");
                }

                dbReader = db.ExecuteQuery(strStatement,
                                           strFields,
                                           strValues);


                strResultFields = new string[dbReader.FieldCount];
                for (int i = 0; i < strResultFields.Length; i++)
                    strResultFields[i] = dbReader.GetName(i);

                while (dbReader.Read())
                {
                    dataModel = CreateInstance();

                    if (dataModel.Fields == null)
                        dataModel.Fields = strResultFields;

                    for (int i = 0; i < dbReader.FieldCount; i++)
                        dataModel.Value(dbReader.GetName(i), dbReader[dbReader.GetName(i)]);

                    lstResult.Add((T)dataModel);
                }

                dbReader.Close();
                db.Close();

                return lstResult;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "," + ex.StackTrace;
            }
            finally
            {
                if (dbReader != null)
                    dbReader.Close();
                if (db != null)
                    db.Close();
            }
            return null;
        }

        public virtual bool Update()
        {
            ErrorMessage = null;
            try
            {
                if (Exists())
                    ExecuteUpdate();
                else
                    ExecuteInsert();
                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + "," + ex.StackTrace;
            }
            return false;                     

        }
    }
}
