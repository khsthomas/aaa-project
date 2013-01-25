using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace AAA.TradeAPI.SPF
{
    public class HistoryEquityStructure : SPFStructure
    {
        /*
         * 查詢歷史權益數
         */
        [DllImport("t4.dll")]
        public static extern string fo_get_hist_info(string strBranch, string strAccountNo, string strStartDate, string strEndDate);

        public const string ACCOUNT_NO = "AccountNo";
        public const string BRANCH = "Branch";
        public const string START_DATE = "StartDate";
        public const string END_DATE = "EndDate";

        public HistoryEquityStructure()
        {
            ClientName = "fo_get_hist_info";
            DisplayName = "國內期權歷史權益數查詢";

            AddParam(BaseStructure.OUTPUT_PARENT, "FeeTotal", "string", 20);
            AddParam(BaseStructure.OUTPUT_PARENT, "TaxTotal", "string", 20);
            AddParam(BaseStructure.OUTPUT_PARENT, "FConTotal", "string", 20);
            AddParam(BaseStructure.OUTPUT_PARENT, "InOutTotal", "string", 20);
            AddParam(BaseStructure.OUTPUT_PARENT, "BidTotal", "string", 20);
            AddParam(BaseStructure.OUTPUT_PARENT, "AskTotal", "string", 20);
            AddParam(BaseStructure.OUTPUT_PARENT, "OGainTotal", "string", 20);
            AddParam(BaseStructure.OUTPUT_PARENT, "Count", "string", 4);

            AddParam(BaseStructure.OUTPUT_CHILDREN, "TDate", "string", 8);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "Account", "string", 15);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "ProfitQty", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "ClearQty", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "Fee", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "Tax", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "FCon", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "FMiss", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "OMiss", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "InOut", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "OSecuAmt", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "USecuAmt", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "Status", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "BidQty", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "AskQty", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "OGain", "string", 20);

        }

        public override string Invoke(Dictionary<string, object> dicValue)
        {
            return fo_get_hist_info(dicValue[BRANCH].ToString(),
                                    dicValue[ACCOUNT_NO].ToString(),
                                    dicValue[START_DATE].ToString(),
                                    dicValue[END_DATE].ToString());
        }
    }
}
