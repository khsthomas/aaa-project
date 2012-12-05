using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AAA.Schedule;
using AAA.TradeLanguage;

namespace AAA.ProgramTrade.Task
{
    public class ExecuteStrategy : AbstractTask
    {
        public override IExecuteResult Execute(Dictionary<string, object> dicData)
        {
            IExecuteResult executeResult = null;
            try
            {
/*
                if ((AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.CURRENT_TIME] == null) ||
                    (AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.STRATEGY_MANAGER] == null))
                    return null;
                ((CurrentTime)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.CURRENT_TIME]).CurrentDateTime = DateTime.Now;
 */ 
                ((StrategyManager)AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.STRATEGY_MANAGER]).VerifyClose();

                SystemHelper.WriteLog(AAA.DesignPattern.Singleton.SystemParameter.Parameter[ProgramTradeConstants.PROGRAM_ROOT_PATH].ToString() + @"\log",
                                      "[Info]-ExecuteStrategy-" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "-" + NextExecuteTime.ToString("yyyy/MM/dd HH:mm:ss"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return executeResult;
        }


    }
}
