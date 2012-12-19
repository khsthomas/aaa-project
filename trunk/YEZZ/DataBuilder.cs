using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YEZZ.Model;
using YEZZ.Database;
using System.Data.Common;
using System.Configuration;
using System.Web.UI.WebControls;

namespace YEZZ
{
    public class DataBuilder
    {
        public const string START_STS_INFO = "S";
        public const string END_STS_INFO = "E";
        public const string ALL_STS_INFO = "A";

        public const string START_STS_TEXT = "啟用";
        public const string END_STS_TEXT = "停用";        

        public static MsSqlDatabase CreateDatabase(string strDbName)
        {
            MsSqlDatabase db = new MsSqlDatabase();
            string strConnectionString = ConfigurationManager.ConnectionStrings[strDbName].ConnectionString;
            db.Open(strConnectionString);
            return db;
        }

        public static void FillColumnOrder(DropDownList ddlOrder)
        {
            for (int i = 1; i <= 5; i++)
                ddlOrder.Items.Add(new ListItem(i.ToString(), i.ToString()));

            if (ddlOrder.Items.Count > 0)
                ddlOrder.SelectedIndex = 0;
        }

        public static void FillProjectName(DropDownList ddlProject)
        {
            FillProjectName(ddlProject, START_STS_INFO);
        }

        public static void FillProjectName(DropDownList ddlProject, string strStsInfo)
        {
            List<IDataModel> lstProject = GetProjectList(strStsInfo);

            while (ddlProject.Items.Count > 0)
                ddlProject.Items.RemoveAt(0);

            foreach (IDataModel project in lstProject)
                ddlProject.Items.Add(new ListItem(project.Value("PROJECT_NAME").ToString(), project.Value("PROJECT_SN").ToString()));

            if(ddlProject.Items.Count > 0)
                ddlProject.SelectedIndex = 0;
        }

        public static void FillFormulaName(DropDownList ddlFormula, string strProjectSn)
        {
            List<IDataModel> lstFormula = GetProjectFormula(strProjectSn);

            while (ddlFormula.Items.Count > 0)
                ddlFormula.Items.RemoveAt(0);

            foreach (IDataModel project in lstFormula)
                ddlFormula.Items.Add(new ListItem(project.Value("FORMULA_NAME").ToString(), project.Value("FORMULA_ID").ToString()));

            if (ddlFormula.Items.Count > 0)
                ddlFormula.SelectedIndex = 0;
        }

        public static string StsValue(string strStsText)
        {
            switch (strStsText)
            {
                case START_STS_TEXT:
                    return START_STS_INFO;
                case END_STS_TEXT:
                    return END_STS_INFO;
            }
            return "";
        }

        public static string StsText(string strStsValue)
        {
            switch (strStsValue)
            {
                case START_STS_INFO:
                    return START_STS_TEXT;
                case END_STS_INFO:
                    return END_STS_TEXT;
            }
            return "";
        }

        public static void FillDefinition(DropDownList ddlDefinition)
        {
            string[] strDefinitionValues = { "M", "L", "E"};
            string[] strDefinitions = { "大於", "小於", "等於" };

            for(int i = 0; i <strDefinitions.Length; i++)
                ddlDefinition.Items.Add(new ListItem(strDefinitions[i], strDefinitionValues[i]));

            ddlDefinition.SelectedIndex = 0;
        }

        public static void FillStsInfo(DropDownList ddlStsInfo)
        {           
            ddlStsInfo.Items.Add(new ListItem(START_STS_TEXT, START_STS_INFO));            
            ddlStsInfo.Items.Add(new ListItem(END_STS_TEXT, END_STS_INFO));
            ddlStsInfo.SelectedIndex = 0;
        }

        public static List<IDataModel> GetProjectFormula(string strProjectSn)
        {
            List<IDataModel> lstReturn = new List<IDataModel>();
            string[] strFields = new string[] { "PROJECT_SN" };
            string[] strValues = new string[] { strProjectSn };

            lstReturn = (new TB_PROJECT_FORMULA()).Query<IDataModel>(strFields, strValues);

            return lstReturn;
        }

        // strStsInfo  A:全部 S:啟用 E:停用
        public static List<IDataModel> GetProjectList(string strStsInfo)
        {
            List<IDataModel> lstReturn = new List<IDataModel>();
            string[] strFields;
            string[] strValues;

            if (strStsInfo == ALL_STS_INFO)
            {
                strFields = new string[0];
                strValues = new string[0];
            }
            else
            {
                strFields = new string[] { "STS_INFO" };
                strValues = new string[] { strStsInfo };
            }

            lstReturn = (new TB_PROJECT_INFO()).Query<IDataModel>(strFields, strValues);

            return lstReturn;
        }        

        public static IDataModel GetCurrentUser()
        {
            IDataModel dataModel = new DefaultDataModel();
            dataModel.Value("USERID", "Alex");
            return dataModel;
        }
    }
}
