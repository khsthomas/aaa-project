using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Momentum.Strategy;
using System.Reflection;

namespace Momentum.Test
{
    public class LibraryLoader
    {
        public List<IIndicator> LoadIndicator(string strPath)
        {
            FileInfo[] filesInfo;
            Assembly asmb = null;
            IIndicator indicator;
            string strNamespace;


            List<IIndicator> lstReturn = new List<IIndicator>();
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(strPath);
                filesInfo = directoryInfo.GetFiles("*.dll");

                for (int i = 0; i < filesInfo.Length; i++)
                {
                    try
                    {
                        strNamespace = filesInfo[i].Name.Replace(".dll", "");
                        asmb = Assembly.LoadFile(filesInfo[i].FullName);
                        indicator = (IIndicator)asmb.CreateInstance(strNamespace + "." + strNamespace.Substring(strNamespace.LastIndexOf('.') + 1));

                        if (indicator == null)
                            continue;
                        lstReturn.Add(indicator);

                    }
                    catch (Exception ex)
                    {

                    }
                }


                return lstReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

    }
}
