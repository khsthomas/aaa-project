using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class LoginStructure : PolarisStructure
    {
        public LoginStructure()
        {
            ApiId = "0";
            ApiIdHex = "0";
            ClientName = "Login";
			DisplayName = "登入";
			
            AddParam(PolarisStructure.OUTPUT_PARENT, "MsgCode", "string", 4);
            AddParam(PolarisStructure.OUTPUT_PARENT, "MsgContent", "string", 50);
            AddParam(PolarisStructure.OUTPUT_PARENT, "RecordCount", "int", 4);

            AddParam(PolarisStructure.OUTPUT_CHILDREN, "Account", "string", 22);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "Name", "string", 12);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "InvestorId", "string", 14);
            AddParam(PolarisStructure.OUTPUT_CHILDREN, "SellerNo", "short", 2);
        }
    }
}
