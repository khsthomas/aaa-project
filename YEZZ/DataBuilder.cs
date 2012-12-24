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



        private static void FillDropDownList(DropDownList ddlSource, List<IDataModel> lstData, string strText)
        {
            FillDropDownList(ddlSource, lstData, strText, strText, false);
        }

        private static void FillDropDownList(DropDownList ddlSource, List<IDataModel> lstData, string strText, string strValue)
        {
            FillDropDownList(ddlSource, lstData, strText, strText, false);
        }

        private static void FillDropDownList(DropDownList ddlSource, List<IDataModel> lstData, string strText, bool appendNoChoose)
        {
            FillDropDownList(ddlSource, lstData, strText, strText, appendNoChoose);
        }

        private static void FillDropDownList(DropDownList ddlSource, List<IDataModel> lstData, string strText, string strValue, bool appendNoChoose)
        {
            while (ddlSource.Items.Count > 0)
                ddlSource.Items.RemoveAt(0);

            if (lstData == null)
                return;

            for (int i = 0; i < lstData.Count; i++)
                ddlSource.Items.Add(new ListItem(lstData[i].Value(strText).ToString(), lstData[i].Value(strValue).ToString()));

            if(appendNoChoose)
                ddlSource.Items.Insert(0, new ListItem("請選擇", "NoChoose"));

            if (ddlSource.Items.Count > 0)
                ddlSource.SelectedIndex = 0;
        }

        public static void FillDropDownList(DropDownList ddlSource, string[] strTexts, string[] strValues)
        {
            while (ddlSource.Items.Count > 0)
                ddlSource.Items.RemoveAt(0);

            if (strTexts.Length == 0)
                return;

            for (int i = 0; i < strTexts.Length; i++)
                ddlSource.Items.Add(new ListItem(strTexts[i], strValues[i]));

            if (ddlSource.Items.Count > 0)
                ddlSource.SelectedIndex = 0;
        }

        public static void FillDataYear(DropDownList ddlYear)
        {
            FillDataYear(ddlYear, true);
        }
        public static void FillDataYear(DropDownList ddlYear, bool appendNoChoose)
        {
            List<IDataModel> lstYear = (List<IDataModel>)(new DefaultDataModel()).Query<IDataModel>("SELECT DATA_YEAR FROM " + SystemConstants.DATABASE_CATALOG + ".dbo.TB_TOWN_DATA GROUP BY DATA_YEAR ORDER BY CONVERT(INT, DATA_YEAR) DESC",
                                                          null, null);
            FillDropDownList(ddlYear, lstYear, "DATA_YEAR", appendNoChoose);
        }

        public static void FillArea(DropDownList ddlArea)
        {
            FillArea(ddlArea, false);
        }

        public static void FillArea(DropDownList ddlArea, bool appendNoChoose)
        {
            string strSQL;
            strSQL = "SELECT CL_INF, CL_DESC ";
            strSQL += "FROM " + SystemConstants.DATABASE_CATALOG + ".dbo.TB_TABLE_CONFIG ";
            strSQL += "WHERE TB_NAME = @TB_NAME AND CL_NAME = @CL_NAME AND CL_STS = @CL_STS ";
            strSQL += "ORDER BY CL_ORDER ";

            List<IDataModel> lstArea = (List<IDataModel>)(new DefaultDataModel()).Query<IDataModel>(strSQL,
                                                                                                    new string[] { "TB_NAME", "CL_NAME", "CL_STS" },
                                                                                                    new string[] { "TB_COUNTY_INFO", "COUNTY_AREA", START_STS_INFO });
            FillDropDownList(ddlArea, lstArea, "CL_DESC", "CL_INF", appendNoChoose);
        }

        public static void FillCountry(DropDownList ddlCountry, string strYear, string strArea)
        {
            FillCountry(ddlCountry, strYear, strArea, false);
        }
        public static void FillCountry(DropDownList ddlCountry, string strYear, string strArea, bool appendNoChoose)
        {
            string strSQL;

            strSQL = "SELECT x.COUNTY_NO, b.COUNTY_NAME ";
            strSQL += "FROM (SELECT a.COUNTY_NO ";
            strSQL += "		FROM" + SystemConstants.DATABASE_CATALOG + ".dbo.TB_TOWN_DATA a ";
            strSQL += "		WHERE a.DATA_YEAR = @DATA_YEAR ";
            strSQL += "		GROUP BY a.COUNTY_NO) x ";
            strSQL += "INNER JOIN " + SystemConstants.DATABASE_CATALOG + ".dbo.TB_COUNTY_INFO b ON (x.COUNTY_NO = b.COUNTY_NO AND b.COUNTY_AREA = @COUNTY_AREA ";
            strSQL += "							AND b.COUNTY_VARSION = (SELECT TOP(1) COUNTY_VARSION FROM " + SystemConstants.DATABASE_CATALOG + ".dbo.TB_TOWN_DATA ";
            strSQL += "													WHERE DATA_YEAR = @DATA_YEAR ";
            strSQL += "													GROUP BY COUNTY_VARSION)) ";
            strSQL += "ORDER By x.COUNTY_NO ";

            List<IDataModel> lstCountry = (List<IDataModel>)(new DefaultDataModel()).Query<IDataModel>(strSQL,
                                                                                                    new string[] { "DATA_YEAR", "COUNTY_AREA" },
                                                                                                    new string[] { strYear, strArea });
            FillDropDownList(ddlCountry, lstCountry, "COUNTY_NAME", "COUNTY_NO", appendNoChoose);
        }

        public static TB_PROJECT_FORMULA GetFormulaDetail(string strProjectSn, string strFormulaId)
        {
            TB_PROJECT_FORMULA formula = (TB_PROJECT_FORMULA)(new TB_PROJECT_FORMULA()).QueryByPrimaryKey<TB_PROJECT_FORMULA>(new string[] {strProjectSn, strFormulaId});

            return formula;
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
            FillProjectName(ddlProject, START_STS_INFO, false);
        }

        public static void FillProjectName(DropDownList ddlProject, bool appendNoChoose)
        {
            FillProjectName(ddlProject, START_STS_INFO, appendNoChoose);
        }

        public static void FillProjectName(DropDownList ddlProject, string strStsInfo)
        {
            FillProjectName(ddlProject, strStsInfo, false);
        }
        public static void FillProjectName(DropDownList ddlProject, string strStsInfo, bool appendNoChoose)
        {
            List<IDataModel> lstProject = GetProjectList(strStsInfo);
            FillDropDownList(ddlProject, lstProject, "PROJECT_NAME", "PROJECT_SN", appendNoChoose);
/*
            while (ddlProject.Items.Count > 0)
                ddlProject.Items.RemoveAt(0);

            foreach (IDataModel project in lstProject)
                ddlProject.Items.Add(new ListItem(project.Value("PROJECT_NAME").ToString(), project.Value("PROJECT_SN").ToString()));

            if(ddlProject.Items.Count > 0)
                ddlProject.SelectedIndex = 0;
 */ 
        }

        public static void FillFormulaName(DropDownList ddlFormula, string strProjectSn)
        {
            FillFormulaName(ddlFormula, strProjectSn, false);
        }

        public static void FillFormulaName(DropDownList ddlFormula, string strProjectSn, bool appendNoChoose)
        {
            List<IDataModel> lstFormula = GetProjectFormula(strProjectSn);
            FillDropDownList(ddlFormula, lstFormula, "FORMULA_NAME", "FORMULA_ID", appendNoChoose);
/*
            while (ddlFormula.Items.Count > 0)
                ddlFormula.Items.RemoveAt(0);

            foreach (IDataModel project in lstFormula)
                ddlFormula.Items.Add(new ListItem(project.Value("FORMULA_NAME").ToString(), project.Value("FORMULA_ID").ToString()));

            if (ddlFormula.Items.Count > 0)
                ddlFormula.SelectedIndex = 0;
 */ 
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
