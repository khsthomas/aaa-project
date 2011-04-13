using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Meta.Chart.Data;

namespace AAA.AGS.DataSource
{
    public interface IPriceVolumeDataSource : IDataSourceInfo
    {
        Dictionary<string, PriceVolumeData> GetPriceVolume(Dictionary<string, string> queryProperties);    
    }
}

