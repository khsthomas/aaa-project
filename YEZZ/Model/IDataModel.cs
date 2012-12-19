using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YEZZ.Database;
using System.Data;

namespace YEZZ.Model
{
    public interface IDataModel
    {
        string[] PrimaryKeys { get; set; }
        string[] Fields { get; set; }
        SqlDbType[] DataTypes { get; set; }
        string TableName { get; set; }
        string DatabaseName { get; }
        string ErrorMessage { get; set; }
        MsSqlDatabase Database {get;}
        string TablePostfix { get; set; }
        string CurrentTableName { get; }


        void AddAutoIncreaseField(string strFieldName);
        bool Exists();
        bool Update();
        List<T> Query<T>(string[] strFields, string[] strValues);
        List<T> Query<T>(string strStatement, string[] strFields, string[] strValues);
        T QueryByPrimaryKey<T>(string[] strValues);
        T QueryFirst<T>(string[] strFields, string[] strValues);
        bool ExecuteUpdate();
        bool ExecuteUpdate(string strStatement, string[] strFields, string[] strValues);
        bool ExecuteInsert();
        bool ExecuteDelete();
        bool ExecuteDelete(string strStatement, string[] strFields, string[] strValues);
        void Value(string strField, object oValue);
        object Value(string strField);
        IDataModel CreateInstance();
    }
}
