using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CommonClass
{
    public class CommonEnum
    {
        //列舉型別－頁面狀態
        // Load - 載入,  Write - 寫入, CancelWrite - 取消寫入 Insert - 新增同一層, InsertNext - 新增下一層, Edit - 編輯, CancelEdit - 取消編輯, Cancel - 取消, Clear - 清除
        public enum PageStatusType { Load, Write, CancelWrite, Insert, InsertNext, Edit, CancelEdit, Clear, Query };
        //列舉型別－彈跳視窗取值類型
        public enum ValueTypeEnum { Text, Value };
    }
}
