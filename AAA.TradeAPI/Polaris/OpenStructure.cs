using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class OpenStructure : PolarisStructure
    {
        public OpenStructure()
        {
            ApiId = "00";
            ApiIdHex = "00";
            ClientName = "Open";
            DisplayName = "開啟連線";
        }
    }
}
