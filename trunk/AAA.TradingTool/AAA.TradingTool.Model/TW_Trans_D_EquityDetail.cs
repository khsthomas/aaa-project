using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradingTool.Model
{
    public class TW_Trans_D_EquityDetail : TradingDefaultModel
    {
        public TW_Trans_D_EquityDetail()
        {
            PrimaryKeys = new string[] { "ExDate", "AccountNo", "CurrencyType" };
            TableName = "TW_Trans_D_EquityDetail";
            Fields = new string[] { "AvlAmt", "ActBalance", "TGain", "BGain", "OBGain", "PmAmt", 
                                    "ApAmt", "TmAmt", "Fee", "Tax", "OtAmt", "CogtAmt", "CmgtAmt", 
                                    "WarnN", "WarnV", "BidVolume", "AskVolume", "BidMatch", "AskMatch", 
                                    "BEquity", "GdAmt", "Equity", "OGain", "ExRate", "XdgAmt", "AgtAmt", 
                                    "YEquity", "MuNet" };
        }

        public override AAA.Database.Model.IDataModel CreateInstance()
        {
            return new TW_Trans_D_EquityDetail();
        }
    }
}
