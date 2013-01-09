using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class PolarisStructure
    {
        public const int INPUT_PARENT = 0;
        public const int INPUT_CHILDREN = 1;
        public const int OUTPUT_PARENT = 2;
        public const int OUTPUT_CHILDREN = 3;
        public const int OUTPUT_GRAND_CHILDREN = 4;

        private string _strApiId;
        private string _strApiIdHex;
        private string _strClientName;
		private string _strDisplayName;
        private bool _needWaitTillCompleted = true;

        //Input Structure
        private List<string> _lstInputParentType;
        private List<int> _lstInputParentLen;
        private List<string> _lstInputParentName;

        private List<string> _lstInputChildrenType;
        private List<int> _lstInputChildrenLen;
        private List<string> _lstInputChildrenName;

        //Output Structure
        private List<string> _lstOutputParentType;
        private List<int> _lstOutputParentLen;
        private List<string> _lstOutputParentName;

        private List<string> _lstOutputChildrenType;
        private List<int> _lstOutputChildrenLen;
        private List<string> _lstOutputChildrenName;

        private List<string> _lstOutputGrandChildrenType;
        private List<int> _lstOutputGrandChildrenLen;
        private List<string> _lstOutputGrandChildrenName;

        //Switch Structure
        private Dictionary<string, Dictionary<string, List<string>>> _dicOutputSwitchParentType;
        private Dictionary<string, Dictionary<string, List<int>>> _dicOutputSwitchParentLen;
        private Dictionary<string, Dictionary<string, List<string>>> _dicOutputSwitchParentName;
        private Dictionary<string, Dictionary<string, List<string>>> _dicOutputSwitchChildrenType;
        private Dictionary<string, Dictionary<string, List<int>>> _dicOutputSwitchChildrenLen;
        private Dictionary<string, Dictionary<string, List<string>>> _dicOutputSwitchChildrenName;
        private Dictionary<string, Dictionary<string, List<string>>> _dicOutputSwitchGrandChildrenType;
        private Dictionary<string, Dictionary<string, List<int>>> _dicOutputSwitchGrandChildrenLen;
        private Dictionary<string, Dictionary<string, List<string>>> _dicOutputSwitchGrandChildrenName;

        private bool _hasParentSwitch;

        public bool HasParentSwitch
        {
            get { return _hasParentSwitch; }
            private set { _hasParentSwitch = value; }
        }

        private bool _hasChildrenSwitch;

        public bool HasChildrenSwitch
        {
            get { return _hasChildrenSwitch; }
            private set { _hasChildrenSwitch = value; }
        }

        private bool _hasGrandChildrenSwitch;

        public bool HasGrandChildrenSwitch
        {
            get { return _hasGrandChildrenSwitch; }
            private set { _hasGrandChildrenSwitch = value; }
        }

        public PolarisStructure()
        {
            _lstInputParentType = new List<string>();
            _lstInputParentLen = new List<int>();
            _lstInputParentName = new List<string>();

            _lstInputChildrenType = new List<string>();
            _lstInputChildrenLen = new List<int>();
            _lstInputChildrenName = new List<string>();
            
            _lstOutputParentType = new List<string>();
            _lstOutputParentLen = new List<int>();
            _lstOutputParentName = new List<string>();

            _lstOutputChildrenType = new List<string>();
            _lstOutputChildrenLen = new List<int>();
            _lstOutputChildrenName = new List<string>();

            _lstOutputGrandChildrenType = new List<string>();
            _lstOutputGrandChildrenLen = new List<int>();
            _lstOutputGrandChildrenName = new List<string>();

            _dicOutputSwitchParentType = new Dictionary<string, Dictionary<string, List<string>>>();
            _dicOutputSwitchParentLen = new Dictionary<string, Dictionary<string, List<int>>>();
            _dicOutputSwitchParentName = new Dictionary<string, Dictionary<string, List<string>>>();

            _dicOutputSwitchChildrenType = new Dictionary<string, Dictionary<string, List<string>>>();
            _dicOutputSwitchChildrenLen = new Dictionary<string, Dictionary<string, List<int>>>();
            _dicOutputSwitchChildrenName = new Dictionary<string, Dictionary<string, List<string>>>();

            _dicOutputSwitchGrandChildrenType = new Dictionary<string, Dictionary<string, List<string>>>();
            _dicOutputSwitchGrandChildrenLen = new Dictionary<string, Dictionary<string, List<int>>>();
            _dicOutputSwitchGrandChildrenName = new Dictionary<string, Dictionary<string, List<string>>>();

        }

        public string ApiId
        {
            get { return _strApiId; }
			protected set { _strApiId = value; }
        }

        public string ApiIdHex
        {
            get { return _strApiIdHex; }
			protected set { _strApiIdHex = value; }
        }

        public string ClientName
        {
            get { return _strClientName; }
			protected set { _strClientName = value; }
        }

		public string DisplayName
        {
            get { return _strDisplayName; }
			protected set { _strDisplayName = value; }
        }
		
        public bool NeedWaitToCompleted
        {
            get { return _needWaitTillCompleted; }
			protected set { _needWaitTillCompleted = value; }
        }

        public string[] GetNames(int iType)
        {
            List<string> lstName = null;

            switch (iType)            
            {
                case INPUT_PARENT:
                    lstName = _lstInputParentName;
                    break;
                case INPUT_CHILDREN:
                    lstName = _lstInputChildrenName;
                    break;
                case OUTPUT_PARENT:
                    lstName = _lstOutputParentName;
                    break;
                case OUTPUT_CHILDREN:
                    lstName = _lstOutputChildrenName;
                    break;
                case OUTPUT_GRAND_CHILDREN:
                    lstName = _lstOutputGrandChildrenName;
                    break;            
            }

            if (lstName == null)
                return null;

            if (lstName.Count == 0)
                return null;            

            return (string[])lstName.ToArray<string>();
        }

        public string[] GetTypes(int iType)
        {
            List<string> lstType = null;

            switch (iType)
            {
                case INPUT_PARENT:
                    lstType = _lstInputParentType;
                    break;
                case INPUT_CHILDREN:
                    lstType = _lstInputChildrenType;
                    break;
                case OUTPUT_PARENT:
                    lstType = _lstOutputParentType;
                    break;
                case OUTPUT_CHILDREN:
                    lstType = _lstOutputChildrenType;
                    break;
                case OUTPUT_GRAND_CHILDREN:
                    lstType = _lstOutputGrandChildrenType;
                    break;
            }

            if (lstType == null)
                return null;

            if (lstType.Count == 0)
                return null;

            return (string[])lstType.ToArray<string>();
        }

        public int[] GetLens(int iType)
        {
            List<int> lstLen = null;

            switch (iType)
            {
                case INPUT_PARENT:
                    lstLen = _lstInputParentLen;
                    break;
                case INPUT_CHILDREN:
                    lstLen = _lstInputChildrenLen;
                    break;
                case OUTPUT_PARENT:
                    lstLen = _lstOutputParentLen;
                    break;
                case OUTPUT_CHILDREN:
                    lstLen = _lstOutputChildrenLen;
                    break;
                case OUTPUT_GRAND_CHILDREN:
                    lstLen = _lstOutputGrandChildrenLen;
                    break;
            }

            if (lstLen == null)
                return null;

            if (lstLen.Count == 0)
                return null;

            return (int[])lstLen.ToArray<int>();
        }

        protected void AddSwitchParam(int iType, string strSwitchName, string strSwitchValue, string strName, string strType, int iLen)
        {
            List<string> lstName = null;
            List<string> lstType = null;
            List<int> lstLen = null;

            switch(iType)
            {
                case OUTPUT_PARENT:
                    if(_dicOutputSwitchParentName.ContainsKey(strSwitchName) == false)
                    {
                        _dicOutputSwitchParentName.Add(strSwitchName, new Dictionary<string,List<string>>());
                        _dicOutputSwitchParentLen.Add(strSwitchName, new Dictionary<string,List<int>>());
                        _dicOutputSwitchParentType.Add(strSwitchName, new Dictionary<string,List<string>>());
                    }

                    if(_dicOutputSwitchParentName[strSwitchName].ContainsKey(strSwitchValue) == false)
                    {
                        _dicOutputSwitchParentName[strSwitchName].Add(strSwitchValue, new List<string>());
                        _dicOutputSwitchParentLen[strSwitchName].Add(strSwitchValue, new List<int>());
                        _dicOutputSwitchParentType[strSwitchName].Add(strSwitchValue, new List<string>());
                    }

                    HasParentSwitch = true;
                    lstName = _dicOutputSwitchParentName[strSwitchName][strSwitchValue];
                    lstType = _dicOutputSwitchParentType[strSwitchName][strSwitchValue];
                    lstLen = _dicOutputSwitchParentLen[strSwitchName][strSwitchValue];
                    break;
                case OUTPUT_CHILDREN:
                    if (_dicOutputSwitchChildrenName.ContainsKey(strSwitchName) == false)
                    {
                        _dicOutputSwitchChildrenName.Add(strSwitchName, new Dictionary<string, List<string>>());
                        _dicOutputSwitchChildrenLen.Add(strSwitchName, new Dictionary<string, List<int>>());
                        _dicOutputSwitchChildrenType.Add(strSwitchName, new Dictionary<string, List<string>>());
                    }

                    if (_dicOutputSwitchChildrenName[strSwitchName].ContainsKey(strSwitchValue) == false)
                    {
                        _dicOutputSwitchChildrenName[strSwitchName].Add(strSwitchValue, new List<string>());
                        _dicOutputSwitchChildrenLen[strSwitchName].Add(strSwitchValue, new List<int>());
                        _dicOutputSwitchChildrenType[strSwitchName].Add(strSwitchValue, new List<string>());
                    }

                    HasChildrenSwitch = true;
                    lstName = _dicOutputSwitchChildrenName[strSwitchName][strSwitchValue];
                    lstType = _dicOutputSwitchChildrenType[strSwitchName][strSwitchValue];
                    lstLen = _dicOutputSwitchChildrenLen[strSwitchName][strSwitchValue];
                    break;
                case OUTPUT_GRAND_CHILDREN:
                    if (_dicOutputSwitchGrandChildrenName.ContainsKey(strSwitchName) == false)
                    {
                        _dicOutputSwitchGrandChildrenName.Add(strSwitchName, new Dictionary<string, List<string>>());
                        _dicOutputSwitchGrandChildrenLen.Add(strSwitchName, new Dictionary<string, List<int>>());
                        _dicOutputSwitchGrandChildrenType.Add(strSwitchName, new Dictionary<string, List<string>>());
                    }

                    if (_dicOutputSwitchGrandChildrenName[strSwitchName].ContainsKey(strSwitchValue) == false)
                    {
                        _dicOutputSwitchGrandChildrenName[strSwitchName].Add(strSwitchValue, new List<string>());
                        _dicOutputSwitchGrandChildrenLen[strSwitchName].Add(strSwitchValue, new List<int>());
                        _dicOutputSwitchGrandChildrenType[strSwitchName].Add(strSwitchValue, new List<string>());
                    }

                    HasGrandChildrenSwitch = true;
                    lstName = _dicOutputSwitchGrandChildrenName[strSwitchName][strSwitchValue];
                    lstType = _dicOutputSwitchGrandChildrenType[strSwitchName][strSwitchValue];
                    lstLen = _dicOutputSwitchGrandChildrenLen[strSwitchName][strSwitchValue];
                    break;            
            }

            if (lstName == null)
                return;

            if (lstName.IndexOf(strName) > -1)
                return;

            lstName.Add(strName);
            lstType.Add(strType);
            lstLen.Add(iLen);
        }

        public bool IsSwitchField(int iType, string strSwitchName)
        {
            switch (iType)
            {
                case OUTPUT_PARENT:
                    return _dicOutputSwitchParentName.ContainsKey(strSwitchName);
                case OUTPUT_CHILDREN:
                    return _dicOutputSwitchChildrenName.ContainsKey(strSwitchName);
                case OUTPUT_GRAND_CHILDREN:
                    return _dicOutputSwitchGrandChildrenName.ContainsKey(strSwitchName);
            }

            return false;
        }

        public string[] GetSwitchName(int iType, string strSwitchName, string strSwitchValue)
        {
            List<string> lstName = null;
            switch (iType)
            {
                case OUTPUT_PARENT:
                    if (_dicOutputSwitchParentName.ContainsKey(strSwitchName) == false)
                        break;
                    if (_dicOutputSwitchParentName[strSwitchName].ContainsKey(strSwitchValue) == false)
                        break;
                    lstName = _dicOutputSwitchParentName[strSwitchName][strSwitchValue];
                    break;

                case OUTPUT_CHILDREN:
                    if (_dicOutputSwitchChildrenName.ContainsKey(strSwitchName) == false)
                        break;
                    if (_dicOutputSwitchChildrenName[strSwitchName].ContainsKey(strSwitchValue) == false)
                        break;
                    lstName = _dicOutputSwitchChildrenName[strSwitchName][strSwitchValue];
                    break;
                    
                case OUTPUT_GRAND_CHILDREN:
                    if (_dicOutputSwitchGrandChildrenName.ContainsKey(strSwitchName) == false)
                        break;
                    if (_dicOutputSwitchGrandChildrenName[strSwitchName].ContainsKey(strSwitchValue) == false)
                        break;
                    lstName = _dicOutputSwitchGrandChildrenName[strSwitchName][strSwitchValue];                    
                    break;
            }

            if (lstName == null)
                return null;

            if (lstName.Count == 0)
                return null;

            return lstName.ToArray<string>();
        }

        public string[] GetSwitchType(int iType, string strSwitchName, string strSwitchValue)
        {
            List<string> lstType = null;
            switch (iType)
            {
                case OUTPUT_PARENT:
                    if (_dicOutputSwitchParentType.ContainsKey(strSwitchName) == false)
                        break;
                    if (_dicOutputSwitchParentType[strSwitchName].ContainsKey(strSwitchValue) == false)
                        break;
                    lstType = _dicOutputSwitchParentType[strSwitchName][strSwitchValue];
                    break;

                case OUTPUT_CHILDREN:
                    if (_dicOutputSwitchChildrenType.ContainsKey(strSwitchName) == false)
                        break;
                    if (_dicOutputSwitchChildrenType[strSwitchName].ContainsKey(strSwitchValue) == false)
                        break;
                    lstType = _dicOutputSwitchChildrenType[strSwitchName][strSwitchValue];
                    break;

                case OUTPUT_GRAND_CHILDREN:
                    if (_dicOutputSwitchGrandChildrenType.ContainsKey(strSwitchName) == false)
                        break;
                    if (_dicOutputSwitchGrandChildrenType[strSwitchName].ContainsKey(strSwitchValue) == false)
                        break;
                    lstType = _dicOutputSwitchGrandChildrenType[strSwitchName][strSwitchValue];
                    break;
            }

            if (lstType == null)
                return null;

            if (lstType.Count == 0)
                return null;

            return lstType.ToArray<string>();
        }


        public int[] GetSwitchLen(int iLen, string strSwitchName, string strSwitchValue)
        {
            List<int> lstLen = null;
            switch (iLen)
            {
                case OUTPUT_PARENT:
                    if (_dicOutputSwitchParentLen.ContainsKey(strSwitchName) == false)
                        break;
                    if (_dicOutputSwitchParentLen[strSwitchName].ContainsKey(strSwitchValue) == false)
                        break;
                    lstLen = _dicOutputSwitchParentLen[strSwitchName][strSwitchValue];
                    break;

                case OUTPUT_CHILDREN:
                    if (_dicOutputSwitchChildrenLen.ContainsKey(strSwitchName) == false)
                        break;
                    if (_dicOutputSwitchChildrenLen[strSwitchName].ContainsKey(strSwitchValue) == false)
                        break;
                    lstLen = _dicOutputSwitchChildrenLen[strSwitchName][strSwitchValue];
                    break;

                case OUTPUT_GRAND_CHILDREN:
                    if (_dicOutputSwitchGrandChildrenLen.ContainsKey(strSwitchName) == false)
                        break;
                    if (_dicOutputSwitchGrandChildrenLen[strSwitchName].ContainsKey(strSwitchValue) == false)
                        break;
                    lstLen = _dicOutputSwitchGrandChildrenLen[strSwitchName][strSwitchValue];
                    break;
            }

            if (lstLen == null)
                return null;

            if (lstLen.Count == 0)
                return null;

            return lstLen.ToArray<int>();
        }

        protected void AddParam(int iType, string strName, string strType, int iLen)
        {
            List<string> lstName = null;
            List<string> lstType = null;
            List<int> lstLen = null;

            switch (iType)
            {
                case INPUT_PARENT:
                    lstName = _lstInputParentName;
                    lstType = _lstInputParentType;
                    lstLen = _lstInputParentLen;
                    break;
                case INPUT_CHILDREN:
                    lstName = _lstInputChildrenName;
                    lstType = _lstInputChildrenType;
                    lstLen = _lstInputChildrenLen;
                    break;
                case OUTPUT_PARENT:
                    lstName = _lstOutputParentName;
                    lstType = _lstOutputParentType;
                    lstLen = _lstOutputParentLen;
                    break;
                case OUTPUT_CHILDREN:
                    lstName = _lstOutputChildrenName;
                    lstType = _lstOutputChildrenType;
                    lstLen = _lstOutputChildrenLen;
                    break;
                case OUTPUT_GRAND_CHILDREN:
                    lstName = _lstOutputGrandChildrenName;
                    lstType = _lstOutputGrandChildrenType;
                    lstLen = _lstOutputGrandChildrenLen;
                    break;            
            }

            if (lstName == null)
                return;

            if (lstName.IndexOf(strName) > -1)
                return;

            lstName.Add(strName);
            lstType.Add(strType);
            lstLen.Add(iLen);
        }

    }
}
