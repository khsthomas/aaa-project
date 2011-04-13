using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.Download.BasicRecord
{
    public interface IBasicRecord
    {
        List<string> GetStockNo(string strSQL);
    }
}
