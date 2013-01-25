using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace AAA.TradeAPI.SPF
{
    public class TodayEquityStructure : SPFStructure
    {
        /*
         * 查詢當日權益數
         */
        [DllImport("t4.dll")]
        public static extern string fo_get_day_info(string strBranch, string strAccount);

        public const string ACCOUNT_NO = "AccountNo";
        public const string BRANCH = "Branch";

        public TodayEquityStructure()
        {
            ClientName = "fo_get_day_info";
            DisplayName = "國內當日權益數查詢";

            AddParam(BaseStructure.OUTPUT_PARENT, "Date", "string", 8);
            AddParam(BaseStructure.OUTPUT_PARENT, "Time", "string", 6);
            AddParam(BaseStructure.OUTPUT_PARENT, "Count", "string", 4);

            AddParam(BaseStructure.OUTPUT_CHILDREN, "Avlamt", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "ACTbal", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "Tgain", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "Bgain", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "OBGAIN", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "PMamt", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "APamt", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "TMamt", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "Fee", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "FTax", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "OTamt", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "COGTamt", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "CMGTamt", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "WARNN", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "WARNV", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "BidVolume", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "AskVolume", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "BidMatch", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "AskMatch", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "BEQUITY", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "GdAmt", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "EQuity", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "OGAIN", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "exrate", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "xgdamt", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "agtamt", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "yequity", "string", 20);
            AddParam(BaseStructure.OUTPUT_CHILDREN, "munet", "string", 20);
        }

        public override string Invoke(Dictionary<string, object> dicValue)
        {
            return fo_get_day_info(dicValue[BRANCH].ToString(),
                                   dicValue[ACCOUNT_NO].ToString());
        }
    }
}
