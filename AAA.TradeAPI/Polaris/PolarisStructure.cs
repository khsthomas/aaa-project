using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.TradeAPI.Polaris
{
    public class PolarisStructure : BaseStructure
    {

        private string _strApiId;
        private string _strApiIdHex;

        private bool _needWaitTillCompleted = true;

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

		
        public bool NeedWaitToCompleted
        {
            get { return _needWaitTillCompleted; }
			protected set { _needWaitTillCompleted = value; }
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


    }
}
