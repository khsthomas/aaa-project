using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.TradeLanguage;
using AAA.Meta.Quote.Data;

namespace AAA.ProgramTrade.Function
{
    public class DataMerge : AbstractFunction
    {
        public DataMerge()
        {
            DisplayName = "DataMerge";
            InputVariableNames = new string[] { "TransferSymbolId", "SymbolIdList", "FieldList" };
            InputVariableDescs = new string[] { "計算後商品名稱", "商品列表, 以';'隔開", "欄位列表, 商品以';'隔開, 欄位以','隔開" };
            DefaultValues = new object[] { "", "", "" };
        }

        public override BarRecord ExecCalculate()
        {
            BarRecord barRecord = new BarRecord();
            BarRecord barSource;
            string[] strValues;
            string[] strDataSources;
            
            try
            {                
                strDataSources = InputVariable("SymbolIdList").ToString().Split(';');
                strValues = InputVariable("FieldList").ToString().Split(';');

                for(int i = 0; i < strDataSources.Length; i++)
                {
                    barSource = Bar(strDataSources[i], 0);
                    foreach (string strField in strValues[i].Split(','))
                        barRecord[strDataSources[i] + "-" + strField] = barSource[strField];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return barRecord;
        }
    }
}
