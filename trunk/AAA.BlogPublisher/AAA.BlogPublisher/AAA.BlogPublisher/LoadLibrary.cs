using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.WebPublisher;
using System.IO;
using System.Reflection;

namespace AAA.BlogPublisher
{
    public class LoadLibrary
    {
        public List<IRegister> LoadRegister(string strPath)
        {
            FileInfo[] filesInfo;
            Assembly asmb = null;
            IRegister register;
            string strNamespace;


            List<IRegister> lstReturn = new List<IRegister>();
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
                        register = (IRegister)asmb.CreateInstance(strNamespace + "." + strNamespace.Substring(strNamespace.LastIndexOf('.') + 1));

                        if (register == null)
                            continue;
                        lstReturn.Add(register);

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


        public List<IPublisher> LoadPublisher(string strPath)
        {
            FileInfo[] filesInfo;
            Assembly asmb = null;
            IPublisher publisher;
            string strNamespace;


            List<IPublisher> lstReturn = new List<IPublisher>();
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
                        publisher = (IPublisher)asmb.CreateInstance(strNamespace + "." + strNamespace.Substring(strNamespace.LastIndexOf('.') + 1));

                        if (publisher == null)
                            continue;
                        lstReturn.Add(publisher);

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
