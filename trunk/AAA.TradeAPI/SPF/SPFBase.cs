using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using AAA.Meta.Trade.Data;
using AAA.Meta.Trade;

namespace AAA.TradeAPI.SPF
{
    public class SPFBase
    {
        [DllImport("t4.dll")]
        public static extern int log_out();
        /*
         初始化
         login_id = 登入id
         login_pass = 登入密碼
         dll_path = Dll所在的目錄
        */
        [DllImport("t4.dll")]
        public static extern string init_t4(string strAccount, string strPassword, string strDllPath);

        /*
         CA測試
         branch = 分行
         account = 帳戶
        */
        [DllImport("t4.dll")]
        public static extern string verify_ca_pass(string strBranch, string strAccountNo);

        /*
         國內期貨下單
         buy_or_sell : "B" = 買, "S" = 賣
         branch : 分公司代號
         account : 帳號
         code : 商品代號
         price :  價格 6位數
         amount : 口數 3位數
         price type : "MKT"市價, "LMT"限價
         ordtype: ROD / FOK / IOC
         octtype: 倉別 "0" = 新倉  "1" = 平倉 " "= 自動  "6"= 當沖
        */
        [DllImport("t4.dll")]
        public static extern string future_order(string strBuyOrSell, string strBranch,
                                                 string strAccount, string strCode,
                                                 string strPrice, string strAmount,
                                                 string strPriceType, string strOrderType,
                                                 string strOCType);

        /*
         future_cancel 國內期貨刪單
         branch : 分公司代號
         account : 帳號
         code : 商品代號
         ord_seq   :  網路單號
         ord_num   :  委託單號
         octtype : "0" 新倉, "1" 平倉, " " 自動
         pre_order : "N" - 非預約單, " " - 預約單
        */
        [DllImport("t4.dll")]
        public static extern string future_cancel(string strBranch, string strAccount,
                                                   string strCode, string strOrderSeq,
                                                   string strOrderNum, string strOCtype,
                                                   string strPreOrder);
        /*
        option_order 國內選擇權下單
        buy_or_sell : "B" = 買, "S" = 賣
        branch : 分公司代號
        account : 帳號
        code : 商品代號
        price :  價格 6位數
        amount : 口數 3位數
        price type : "MKT"市價, "LMT"限價        
        ordertype : "IOC" or "ROD" or "FOK"
        octype : "0" 新倉, "1" 平倉, " " 自動
        IsComp : "S" 單式 , "C" 複式
        bs2 : 第二商品 買 / 賣
        commodity2 : 第二商品代號
        */
        [DllImport("t4.dll")]
        public static extern string option_order(string strBuyOrSell, string strBranch, string strAccount,
                                                 string strCode, string strPrice, string strAmount,
                                                 string strPriceType, string strOrderType, string strOCType,
                                                 string strIsComp, string strBS2, string strCommodity2);


        /*
        option_cancel 國內選擇權下單        
        branch : 分公司代號
        account : 帳號
        code : 商品代號
        ord_seq : 網路單號
        ord_num : 委託單號
        octype : "0" 新倉, "1" 平倉, " " 自動
        pre_order : 是否為預約單 "N" 非預約單, " " 預約單
        */
        [DllImport("t4.dll")]
        public static extern string option_cancel(string strBranch, string strAccount, string strCode,
                                                  string strOrderSeq, string strOrderNo,
                                                  string strOCType, string strPreOrder);

        /*
         國內期權未平倉部位查詢
         gubn : 0:單一帳號 1:群組
         group name : 群組 name
         branch : 分公司代號
         account : 帳號
         type_1 : 0:all ;1:Future ;2:Option ;3:USD
         type_2 : 0:明細 1.匯整
        */
        [DllImport("t4.dll")]
        public static extern string fo_unsettled_qry(string strFlag, string strLeng, string strNekst,
                                                     string strPrev, string strGubn, string strGroupName,
                                                     string strBranch, string strAccount, string strType_1,
                                                     string strType_2, string strTimeOut);

        /*
         查詢下單帳號
        */
        [DllImport("t4.dll")]
        public static extern string show_list();

        /*
         查詢委託回報
         */
        [DllImport("t4.dll")]
        public static extern string get_response();

        /*
         查詢成交回報
         */
        [DllImport("t4.dll")]
        public static extern string get_response_log();

        /*
         增加驗證群組的CA
         */
        [DllImport("t4.dll")]
        public static extern string add_acc_ca(string strBranch, string strAccount, string strIdNo,
                                               string strCAPath, string strCAPassword);

        [DllImport("t4.dll")]
        public static extern string fo_order_qry(string strBranch, string strAccount, string strCode,
                                                 string strMatchFlag, string strOrderType, string strOCTType,
                                                 string strIsDaily, string strStartDate, string strEndDate,
                                                 string strPreOrder);

        /*
         查看server資訊
         */
        [DllImport("t4.dll")]
        public static extern string show_ip();

        /*
         查看API資訊
         */
        [DllImport("t4.dll")]
        public static extern string show_version();

        /*
         * 查詢當日權益數
         */
        [DllImport("t4.dll")]
        public static extern string fo_get_day_info(string strBranch, string strAccount);

        protected AccountInfo _accountInfo;

        private bool _isInitial = false;
        private bool _isLogin = false;
        private bool _isCheckCA = false;

        private List<AccountInfo> _lstSubAccount;

        public event MessageEvent _messageEvent;

        public List<AccountInfo> AccountList
        {
            get
            {
                return _lstSubAccount;
            }
        }

        private Dictionary<string, SPFStructure> _dicStructure;

        public SPFBase()
        {
            _dicStructure = new Dictionary<string, SPFStructure>();
        }

        public void AddMessageStructure(SPFStructure messageStructure)
        {
            if (_dicStructure.ContainsKey(messageStructure.ClientName))
            {
                _dicStructure[messageStructure.ClientName] = messageStructure;
            }
            else
            {
                _dicStructure.Add(messageStructure.ClientName, messageStructure);                
            }
        }

        public SPFStructure GetMessageStructure(string strClientName)
        {
            return _dicStructure.ContainsKey(strClientName)
                    ? _dicStructure[strClientName]
                    : null;
        }


        string GenerateHeader(string[] strFields)
        {
            string strHeader = "";
            try
            {
                for (int i = 0; i < strFields.Length; i++)
                    strHeader += "," + strFields[i];
            }
            catch (Exception ex)
            {
                return ex.Message + "," + ex.StackTrace;
            }
            return (strHeader.Length > 0) ? strHeader.Substring(1) : "";
        }

        protected Dictionary<string, object> ConvertMessage(string strMessage, BaseStructure structure)
        {
            Dictionary<string, object> dicReturn = new Dictionary<string, object>();
            Dictionary<string, object> dicChildren = new Dictionary<string, object>();
            string[] strNames;
            int[] iLens;
            string[] strTypes;
            string strValue;

            try
            {
                strNames = structure.GetNames(BaseStructure.OUTPUT_PARENT);
                iLens = structure.GetLens(BaseStructure.OUTPUT_PARENT);
                strTypes = structure.GetTypes(BaseStructure.OUTPUT_PARENT);

                if (strNames == null)
                {
                    dicReturn.Add("ReturnText", strMessage);
                    return dicReturn;
                }

                for (int i = 0; i < strNames.Length; i++)
                {
                    strValue = strMessage.Substring(0, iLens[i]);
                    strMessage = strMessage.Substring(iLens[i]);
                    dicReturn.Add(strNames[i], strValue);
                }

                dicReturn.Add("Header", GenerateHeader(strNames));
                if (!dicReturn.ContainsKey("Count"))
                    return dicReturn;

                strNames = structure.GetNames(BaseStructure.OUTPUT_CHILDREN);
                iLens = structure.GetLens(BaseStructure.OUTPUT_CHILDREN);
                strTypes = structure.GetTypes(BaseStructure.OUTPUT_CHILDREN);

                if (strNames == null)
                    return dicReturn;

                for (int i = 0; i < int.Parse(dicReturn["Count"].ToString()); i++)
                {
                    dicChildren = new Dictionary<string, object>();

                    for (int j = 0; j < strNames.Length; j++)
                    {
                        strValue = strMessage.Substring(0, iLens[j]);
                        strMessage = strMessage.Substring(iLens[j]);
                        dicChildren.Add(strNames[j], strValue);
                    }

                    dicReturn.Add("ChildrenHeader" + i, GenerateHeader(strNames));
                    dicReturn.Add("Children" + i, dicChildren);
                }
            }
            catch (Exception ex)
            {
                dicReturn.Add("Exception", ex.Message + "," + ex.StackTrace);                
            }
            return dicReturn;
        }

        public void OnMessage(MessageEvent messageEvent)
        {
            _messageEvent += messageEvent;
        }

        public object InitProgram(AccountInfo accountInfo)
        {
            _accountInfo = accountInfo;
            _isInitial = true;
            return "Success";
        }

        public object Login()
        {
            if (_isInitial == false)
            {
                return "請先初始化帳號";
            }
            string strRC = init_t4(_accountInfo.IdNo, _accountInfo.Password, Environment.CurrentDirectory);
            string[] strAccounts;            
            string strServerInfo;
            AccountInfo accountInfo;
            _lstSubAccount = new List<AccountInfo>();

            if ((strRC.IndexOf("已初始化") > -1) || (strRC.IndexOf("成功") > -1))
            {
                strAccounts = show_list().Replace('\n', '-').Split('-');

                for (int i = 0; i < (int)Math.Floor(strAccounts.Length / 3.0); i++)
                {
                    accountInfo = new AccountInfo();
                    accountInfo.Branch = strAccounts[i * 3 + 0];
                    accountInfo.AccountNo = strAccounts[i * 3 + 1];
                    accountInfo.AccountName = strAccounts[i * 3 + 2];
                    _lstSubAccount.Add(accountInfo);
                }

                if (_accountInfo.AccountNo != null)
                {
                    foreach(AccountInfo account in _lstSubAccount)
                        if (account.AccountNo == _accountInfo.AccountNo)
                        {
                            _accountInfo.AccountName = account.AccountName;
                            _accountInfo.Branch = account.Branch;
                        }
                }

                if ((_accountInfo.Branch == "") || (_accountInfo.Branch == null))
                {
                    _accountInfo.Branch = _lstSubAccount[0].Branch;
                    _accountInfo.AccountNo = _lstSubAccount[0].AccountNo; 
                    _accountInfo.AccountName = _lstSubAccount[0].AccountName;
                }

                _isLogin = true;                

                strServerInfo = show_ip();

                strRC += "\n" + show_ip() + "\n" + show_version();
            }

            return strRC;
        }

        public object CA()
        {
            if (_isLogin == false)
            {
                return "請先登入系統";
            }

            string strRC;
            string strVerifyCA;

            strRC = add_acc_ca(_accountInfo.Branch, _accountInfo.AccountNo, _accountInfo.IdNo,
                               _accountInfo.CAPath, _accountInfo.CAPassword);
            strRC = strRC.IndexOf("成功") > -1 ? "Success" : strRC;

            strVerifyCA = verify_ca_pass(_accountInfo.Branch, _accountInfo.AccountNo);

            _isCheckCA = true;

            return strRC + "\n" + strVerifyCA;
        }

        public object Logout()
        {
            log_out();
            return "Success";
        }

        private void OnMessageReceive(string strMessage, BaseStructure structure)
        {
            Dictionary<string, object> dicReturn;

            dicReturn = ConvertMessage(strMessage, structure);
            dicReturn.Add("name", structure.ClientName);
            if (_messageEvent != null)
                _messageEvent(dicReturn);
        }

        public void MessageSend(string strFunctonCode, Dictionary<string, object> dicValue)
        {
            try
            {
                SPFStructure structure;

                if ((structure = GetMessageStructure(strFunctonCode)) == null)
                    return;

                string strMessage = structure.Invoke(dicValue);

                OnMessageReceive(strMessage, structure);
            }
            catch (Exception ex)
            {
            }

            
        }

    }
}
