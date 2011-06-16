using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using AAA.Meta.Quote.Data;
using AAA.Meta.Chart.Data;

namespace AAA.AGS.Service
{
    [ServiceContract(CallbackContract = typeof(IQuoteServiceCallBack))]
    public interface IQuoteService
    {
        [OperationContract]
        //return List<SymbolProfile> 的string
        string AvailableSymbolList();

        [OperationContract(IsOneWay = true)]
        void Register();

        [OperationContract(IsOneWay = true)]
        void Unregister();

        [OperationContract(IsOneWay = true)]
        void StartService();

        [OperationContract(IsOneWay = true)]
        void SetWatchingSymbolList(string[] strSymbols);

        [OperationContract(IsOneWay = false)]
        List<BarRecord> GetData(Dictionary<string, string> queryProperties);

        [OperationContract(IsOneWay = false)]
        Dictionary<string, AAA.Meta.Chart.Data.PriceVolumeData> GetPriceVolume(Dictionary<string, string> queryProperties);

        [OperationContract(IsOneWay = false)]
        List<DateInfo> GetTransactionDay();       

    }



    public interface IQuoteServiceCallBack
    {
        [OperationContract]
        void OnDataReceive(QuoteData quoteData);
        //return TickData 的string
        //void OnDataReceive(string strTickData);

    }  

}
