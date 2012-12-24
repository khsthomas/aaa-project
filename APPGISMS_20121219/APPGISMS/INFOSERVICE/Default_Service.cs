using ATTDAO;

namespace INFOSERVICE
{
    public class Default_Service
    {
        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：取得人數
        // 修改人：
        // 修改日期：
        // </summary>
        public uint getApplicationCount()
        {
            Default_DAO dd = new Default_DAO();
            return dd.getApplicationCount();
        }

        // </summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/04/23
        // 功能簡述：更新人數
        // 修改人：
        // 修改日期：
        // </summary>
        public int setApplicationCount(string strCount)
        {
            Default_DAO dd = new Default_DAO();
            return dd.setApplicationCount(strCount);
        }
    }
}
