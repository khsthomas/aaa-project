using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class LogoutStructure : PolarisStructure
    {
        public LogoutStructure()
        {
            ApiId = "10";
            ApiIdHex = "10";
            ClientName = "Logout";
            DisplayName = "登出";

        }
    }
}
