using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MapControl.Reader
{
    public class IniReader
    {
        private Dictionary<string, Dictionary<string, string>> _dicConfig;
        private Dictionary<string, List<string>> _dicKey;
        private List<string> _lstSection;
#if SILVERLIGHT
        public IniReader(string strFile) : this(new StreamReader(strFile, Encoding.UTF8))
		{}

		public IniReader(Stream s)
			: this(new StreamReader(s, Encoding.UTF8))
		{ }

#else
        public IniReader(string strFile)
            : this(new StreamReader(strFile, Encoding.Default))
        { }

        public IniReader(Stream s)
            : this(new StreamReader(s, Encoding.Default))
        { }

#endif

        public IniReader(string dllName, string strFile)
            : this(System.Reflection.Assembly.LoadFrom(dllName).GetManifestResourceStream(strFile))
        { }

        public IniReader(StreamReader sr)
        {

            string strLine;
            string strSection;
            Dictionary<string, string> dicParam = null;
            List<string> lstKey = null;

            try
            {
                _dicConfig = new Dictionary<string,Dictionary<string,string>>();
                _dicKey = new Dictionary<string, List<string>>();
                _lstSection = new List<string>();
                strSection = "Default";

                dicParam = new Dictionary<string, string>();
                lstKey = new List<string>();

                _lstSection.Add(strSection);
                _dicConfig.Add(strSection, dicParam);
                _dicKey.Add(strSection, lstKey);

                while ((strLine = sr.ReadLine()) != null)
                {
                    if ((strLine.Length == 0) ||
                        (strLine.StartsWith("#")))
                        continue;

                    if (strLine.StartsWith("["))
                    {
                        strSection = strLine.Substring(1, strLine.Length - 2);

                        if (_lstSection.IndexOf(strSection) > -1)
                        {
                            dicParam = _dicConfig[strSection];
                            lstKey = _dicKey[strSection];
                        }
                        else
                        {
                            dicParam = new Dictionary<string, string>();
                            lstKey = new List<string>();

                            _lstSection.Add(strSection);
                            _dicConfig.Add(strSection, dicParam);
                            _dicKey.Add(strSection, lstKey);
                        }                        
                        continue;
                    }
                    dicParam.Add(strLine.Substring(0, strLine.IndexOf('=')), strLine.Substring(strLine.IndexOf('=') + 1));
                    lstKey.Add(strLine.Substring(0, strLine.IndexOf('=')));
                }

                if(_dicKey["Default"].Count == 0)
                {
                    strSection = "Default";
                    _lstSection.RemoveAt(_lstSection.IndexOf(strSection));
                    _dicConfig.Remove(strSection);
                    _dicKey.Remove(strSection);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "," + e.StackTrace);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        public List<string> Section
        {
            get { return _lstSection; }
        }

        public List<string> GetKey(string strSection)
        {
            return _dicKey.ContainsKey(strSection)
                    ? _dicKey[strSection]
                    : null;
        }

        public string GetParam(string strKey)
        {
            return GetParam("Default", strKey);
        }

        public string GetParam(string strSection, string strKey)
        {
            return GetParam(strSection, strKey, null);
        }

        public string GetParam(string strSection, string strKey, string strDefaultValue)
        {
            return _dicConfig.ContainsKey(strSection) == false
                        ? strDefaultValue
                        : _dicConfig[strSection].ContainsKey(strKey) == false
                            ?   strDefaultValue
                            :   _dicConfig[strSection][strKey];

        }

    }
}
