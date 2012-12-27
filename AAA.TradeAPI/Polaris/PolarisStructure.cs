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
