using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Base.Util.Reader;
using AAA.TradeLanguage;
using AAA.Base.Util.Reflection;
using AAA.Forms.Components.Util;
using AAA.Base.Util;
using AAA.Trade.SignalCatcher;

namespace AAA.ProgramTrade
{
    public partial class RealTimeStrategyForm : Form
    {
        public RealTimeStrategyForm()
        {
            InitializeComponent();
            InitTable();
            LoadStrategy();
        }

        private void InitTable()
        {
            tblStrategy.Columns.Add("StrategyName", "策略名稱");
            tblStrategy.Columns.Add("ParamName", "參數名稱");
            tblStrategy.Columns.Add("ParamValue", "參數值");
            tblStrategy.Columns.Add("ParamDesc", "參數描述");
        }

        private void LoadStrategy()
        {
            IniReader iniReader = null;
            string strDllName;
            string[] strParamNames;
            string[] strParamValues;
            string strBaseSymbolId;
            List<ISignal> lstSignal;

            try
            {
                iniReader = new IniReader(AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH].ToString() + @"\cfg\realtime_strategy.ini");

                foreach (string strSection in iniReader.Section)
                {
                    strDllName = iniReader.GetParam(strSection, "DllName");
                    strBaseSymbolId = iniReader.GetParam(strSection, "BaseSymbolId");
                    strParamNames = iniReader.GetParam(strSection, "ParamName").Split(',');
                    strParamValues = iniReader.GetParam(strSection, "ParamValue").Split(',');

                    lstSignal = Builder.LoadClassesFromFile<ISignal>(AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH].ToString() + @"\" + strDllName);

                    lstSignal[0].BaseSymbolId = strBaseSymbolId;
                    lstSignal[0].SetCurrentTime((CurrentTime)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.CURRENT_TIME]);
                    lstSignal[0].PositionManager = new PositionManager();

                    for (int i = 0; i < strParamNames.Length; i++)
                    {
                        lstSignal[0].InputVariable(strParamNames[i], strParamValues[i]);
                    }

                    DataGridViewUtil.InsertRow(tblStrategy,
                                               new object[] {lstSignal[0].DisplayName,
                                                             StringHelper.ArrayToString(strParamNames, ","),
                                                             StringHelper.ArrayToString(strParamValues, ","),
                                                             StringHelper.ArrayToString(lstSignal[0].InputVariableDescs, ",")});
                    AAA.DesignPattern.Singleton.SystemParameter.Parameter[lstSignal[0].DisplayName] = lstSignal[0];
                    ((StrategyManager)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.STRATEGY_MANAGER]).AddSignal(lstSignal[0]);
                    lstSignal[0].Attach((TrackingCenter)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.TRACKING_CENTER]);                    
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }
    }
}
