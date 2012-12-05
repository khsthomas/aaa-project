using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Quote;
using AAA.Meta.Quote.Data;

namespace AAA.ProgramTrade.Quote
{
    public class DatabaseHistoryQuote : AbstractHistoryQuote
    {
        public override void InitProgram(Dictionary<string, object> dicParam)
        {
        }

        public override void Close()
        {

        }
        public override List<AAA.Meta.Quote.Data.BarRecord> GetBarData(string strSymbolId)
        {
            return GetBarData(strSymbolId, DateTime.Now.AddDays(-2), DateTime.Now);
        }

        public override List<AAA.Meta.Quote.Data.BarRecord> GetBarData(string strSymbolId, DateTime dtStartTime, DateTime dtEndTime)
        {
            List<BarRecord> lstReturn = new List<BarRecord>();
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstReturn;
        }

        public override Dictionary<string, List<AAA.Meta.Quote.Data.BarRecord>> GetBarRecord(string strRecordType, string strSymbolId)
        {
            return GetBarRecord(strRecordType, strSymbolId, DateTime.Now.AddDays(-2), DateTime.Now);
        }

        public override Dictionary<string, List<AAA.Meta.Quote.Data.BarRecord>> GetBarRecord(string strRecordType, string strSymbolId, DateTime dtStartTime, DateTime dtEndTime)
        {
            Dictionary<string, List<AAA.Meta.Quote.Data.BarRecord>> dicReturn = new Dictionary<string, List<AAA.Meta.Quote.Data.BarRecord>>();
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dicReturn;
        }
    }  
}
