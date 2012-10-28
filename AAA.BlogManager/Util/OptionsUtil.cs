using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.ResultSet;
using System.IO;
using AAA.Base.Util;

namespace AAA.BlogManager.Util
{
    public class OptionsUtil
    {
        public IResultSet ParseOptionsZip(string strFilename)
        {
            try
            {
                string strTempPath = Path.GetTempPath();
                ZipHelper.Uncompress(strFilename, strTempPath);
                IResultSet result = new TextResultSet(strTempPath + @"\" + strFilename.Substring(strFilename.LastIndexOf("\\") + 1).Replace("zip", "rpt"), 
                                                      ',', 
                                                      true, 
                                                      0);
                result.Encoding = Encoding.Default;
                if (result.Load() == false)
                    return result;

                return result;

            }
            catch (Exception ex)
            {
                //throw new Exception("OptionsUtil", ex);
            }
            return null;
        }
    }
}
