
namespace CTLLIBRARY.WebServices
{
    public class FunctionWebService_Library
    {
        public string sqlFunctionInfo(string strType, string strUser_Id, string strSystem_Type)
        {
            string strSql = "";
            switch (strType)
            {
                case "getFunctionInfo":
                    strSql = string.Format(@"WITH
                                            USER_FUN AS
                                            (
	                                            SELECT b.FUN_ID, c.FUN_NAME, c.FUN_FLOOR, c.PARENT_FUN_ID, 
		                                            CASE WHEN c.FUN_URL = '' THEN c.FUN_URL ELSE c.FUN_URL + '?FUN_ID=' + b.FUN_ID END FUN_URL,
		                                            CASE WHEN FUN_FLOOR = 1 THEN 'MAIN' ELSE 'SUB' END FUN_TYPE, c.FUN_ORDER
	                                            FROM TB_USER_ROLE a INNER JOIN 
		                                            TB_ROLE_FUN b ON (a.ROLE_ID = b.ROLE_ID) INNER JOIN 
		                                            TB_FUN_INFO c ON (b.FUN_ID = c.FUN_ID)
	                                            WHERE a.USERID = '{0}' AND STS_INFO = 'S' AND b.SYS_TYPE = '{1}'
	                                            GROUP BY b.FUN_ID, c.FUN_NAME, c.FUN_FLOOR, c.PARENT_FUN_ID, c.FUN_URL, c.FUN_ORDER
                                            )
                                            SELECT a.FUN_ID, a.FUN_NAME, a.FUN_FLOOR, a.PARENT_FUN_ID, a.FUN_URL, a.FUN_TYPE,
	                                            CASE WHEN a.FUN_TYPE = 'MAIN' THEN a.FUN_ORDER ELSE b.FUN_ORDER END MAIN_ORDER,
	                                            CASE WHEN a.FUN_TYPE = 'MAIN' THEN 0 ELSE a.FUN_ORDER END SUB_ORDER
                                            FROM USER_FUN a LEFT JOIN
	                                             (SELECT * FROM USER_FUN WHERE FUN_TYPE = 'MAIN') b ON (a.PARENT_FUN_ID = b.FUN_ID)", strUser_Id, strSystem_Type);
                    break;
            }
            return strSql;
        }
    }
}
