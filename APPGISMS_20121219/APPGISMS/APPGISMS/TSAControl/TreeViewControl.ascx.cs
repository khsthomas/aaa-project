using System;
using System.ComponentModel;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TSAControl
{
    // <summary>
    // 撰寫人：Oliver
    // 撰寫日期：2011/03/12
    // 更新日期：2011/03/29
    // 功能簡述：樹狀結構顯示元件
    // 版本：1.0.110330
    // </summary>
    public partial class TreeViewControl : System.Web.UI.UserControl
    {
        #region 欄位屬性
        [Category("欄位屬性")]
        [Description("節點層數資料欄位名稱")]
        public string FloorColumn { set; get; }

        [Category("欄位屬性")]
        [Description("節點之上一層節點欄位名稱")]
        public string ParentColumn { set; get; }

        [Category("欄位屬性")]
        [Description("節點排序資料欄位名稱")]
        public string OrderColumn { set; get; }

        [Category("欄位屬性")]
        [Description("節點文字資料欄位名稱")]
        public string TextColumn { set; get; }

        [Category("欄位屬性")]
        [Description("節點值資料欄位名稱")]
        public string ValueColumn { set; get; }

        [Category("欄位屬性")]
        [Description("節點提示文字資料欄位名稱")]
        public string TooltipColumn { set; get; }

        [Category("欄位屬性")]
        [Description("節點超連結資料欄位名稱")]
        public string NavigateUrlColumn { set; get; }

        [Category("欄位屬性")]
        [Description("節點連結對象資料欄位名稱")]
        public string TargetColumn { set; get; }

        [Category("欄位屬性")]
        [Description("節點選擇動作資料欄位名稱")]
        public string SelectActionColumn { set; get; }

        [Category("欄位屬性")]
        [Description("節點圖示資料欄位名稱")]
        public string NodeImageUrlColumn { set; get; }
        #endregion

        #region 樹狀屬性
        //資料來源
        private static DataTable dtTreeViewSource;
        //根節點選擇動作
        private TreeNodeSelectAction tnsaRootSelectAction = TreeNodeSelectAction.None;
        //一般節點選擇動作
        private TreeNodeSelectAction tnsaNode = TreeNodeSelectAction.None;
        //UpdatePanel ID
        protected string strUpdatePanelID;
        //第一次開啟之階層數
        private int intTreeViewExpandDepth = -1;

        /// <summary>
        /// 設定或取得在TreeView控制項的資料來源
        /// </summary>
        [Category("樹狀屬性")]
        [Description("設定或取得在TreeView控制項的資料來源")]
        public DataTable TreeViewDataSoucre
        {
            set
            {
                dtTreeViewSource = value;
                //顯示樹狀結構內容
                ShowTreeView();
            }
            get { return dtTreeViewSource; }
        }

        /// <summary>
        /// 設定或取得在TreeView控制項中的哪種類型會顯示CheckBox
        /// </summary>
        [Category("樹狀屬性")]
        [Description("設定或取得在TreeView控制項中的哪種類型會顯示CheckBox")]
        [DefaultValue(TreeNodeTypes.None)]
        public TreeNodeTypes ShowCheckBoxes
        {
            set { trvControl.ShowCheckBoxes = value; }
            get { return trvControl.ShowCheckBoxes; }
        }

        /// <summary>
        /// 設定根節點選取動作類型
        /// </summary>
        [Category("樹狀屬性")]
        [Description("設定根節點選取動作類型")]
        [DefaultValue(TreeNodeSelectAction.None)]
        public TreeNodeSelectAction RootSelectAction
        {
            set { tnsaRootSelectAction = value; }
            get { return tnsaRootSelectAction; }
        }

        /// <summary>
        /// 設定子節點選取動作類型
        /// </summary>
        [Category("樹狀屬性")]
        [Description("設定子節點選取動作類型")]
        [DefaultValue(TreeNodeSelectAction.None)]
        public TreeNodeSelectAction NodeSelectAction
        {
            set { tnsaNode = value; }
            get { return tnsaNode; }
        }

        /// <summary>
        /// 取得或設定要用於 TreeView 控制項的影像群組
        /// </summary>
        [Category("樹狀屬性")]
        [Description("取得或設定要用於 TreeView 控制項的影像群組")]
        [DefaultValue(TreeViewImageSet.XPFileExplorer)]
        public TreeViewImageSet ImageSet
        {
            set { trvControl.ImageSet = value; }
            get { return trvControl.ImageSet; }
        }

        /// <summary>
        /// 設定第一次顯示TreeView控制項時展開的層級數目
        /// </summary>
        [Category("樹狀屬性")]
        [Description("設定第一次顯示TreeView控制項時展開的層級數目")]
        [DefaultValue(-1)]
        public int TreeViewExpandDepth
        {
            set { intTreeViewExpandDepth = value; }
            get { return intTreeViewExpandDepth; }
        }

        /// <summary>
        /// 設定或取得控制項是否啟用
        /// </summary>
        [Category("樹狀屬性")]
        [Description("設定或取得控制項是否啟用")]
        [DefaultValue(true)]
        public bool Enabled
        {
            set { trvControl.Enabled = value; }
            get { return trvControl.Enabled; }
        }

        /// <summary>
        /// 設定控制項所在之Update Panel的ID
        /// </summary>
        [Category("樹狀屬性")]
        [Description("設定控制項所在之Update Panel的ID")]
        public string UpdatePanelID
        {
            set { strUpdatePanelID = value; }
            get { return strUpdatePanelID; }
        }

        /// <summary>
        /// 取得TreeView控制項中的根節點
        /// </summary>
        [Browsable(false)]
        public TreeNodeCollection Nodes
        {
            get { return trvControl.Nodes; }
        }

        /// <summary>
        /// 取得TreeView控制項中選取的節點
        /// </summary>
        [Browsable(false)]
        public TreeNode SelectedNode
        {
            get { return trvControl.SelectedNode; }
        }
        #endregion

        #region 圖示屬性
        /// <summary>
        /// 摺疊的節點指示器之自訂影像 URL
        /// </summary>
        [Category("圖示屬性")]
        [Description("摺疊的節點指示器之自訂影像 URL")]
        public string CollapseImageUrl
        {
            set { trvControl.CollapseImageUrl = value; }
            get { return trvControl.CollapseImageUrl; }
        }

        /// <summary>
        /// 展開的節點指示器之自訂影像 URL
        /// </summary>
        [Category("圖示屬性")]
        [Description("展開的節點指示器之自訂影像 URL")]
        public string ExpandImageUrl
        {
            set { trvControl.ExpandImageUrl = value; }
            get { return trvControl.ExpandImageUrl; }
        }

        /// <summary>
        /// 資料夾的 URL，該資料夾包含以線條連接之節點的自訂影像
        /// </summary>
        [Category("圖示屬性")]
        [Description("資料夾的圖示位置，該資料夾包含以線條連接之節點的圖示")]
        public string LineImagesFolder
        {
            set { trvControl.LineImagesFolder = value; }
            get { return trvControl.LineImagesFolder; }
        }

        /// <summary>
        /// 非展開節點指示器的自訂影像 URL
        /// </summary>
        [Category("圖示屬性")]
        [Description("非展開節點指示器的圖示位置")]
        public string NoExpandImageUrl
        {
            set { trvControl.NoExpandImageUrl = value; }
            get { return trvControl.NoExpandImageUrl; }
        }

        /// <summary>
        /// 設定根節點的圖示
        /// </summary>
        [Category("圖示屬性")]
        [Description("非展開節點指示器的圖示位置")]
        public string RootNodeImageUrl
        {
            set { trvControl.RootNodeStyle.ImageUrl = value; }
            get { return trvControl.RootNodeStyle.ImageUrl; }
        }

        /// <summary>
        /// 設定一般節點的圖示
        /// </summary>
        [Category("圖示屬性")]
        [Description("設定一般節點的圖示位置")]
        public string NodeImageUrl
        {
            set { trvControl.NodeStyle.ImageUrl = value; }
            get { return trvControl.NodeStyle.ImageUrl; }
        }

        /// <summary>
        /// 設定葉節點的圖示
        /// </summary>
        [Category("圖示屬性")]
        [Description("設定葉節點的圖示位置")]
        public string LeafNodeImageUrl
        {
            set { trvControl.LeafNodeStyle.ImageUrl = value; }
            get { return trvControl.LeafNodeStyle.ImageUrl; }
        }
        #endregion

        #region 類舉型別
        public enum SetCheckBoxEnum { Parent, Child, All };
        #endregion

        #region Page_Load事件
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/03/12
        // 功能簡述：Page_Load事件
        // 修改人：
        // 修改日期：
        // </summary>
        protected void Page_Load(object sender, EventArgs e) {}
        #endregion

        #region 事件－SelectedNodeChanged事件
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/03/12
        // 功能簡述：SelectedNodeChanged事件
        // 修改人：
        // 修改日期：
        // </summary>
        public event EventHandler SelectedNodeChanged;
        protected void trvControl_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (SelectedNodeChanged != null)
                SelectedNodeChanged(sender, e);
        }
        #endregion

        #region 事件－TreeNodeCheckChanged事件
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/03/12
        // 功能簡述：TreeNodeCheckChanged事件
        // 修改人：
        // 修改日期：
        // </summary>
        public event TreeNodeEventHandler TreeNodeCheckChanged;
        protected void trvControl_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            if (TreeNodeCheckChanged != null)
                TreeNodeCheckChanged(sender, e);
        }
        #endregion

        #region 事件－TreeNodeExpanded事件
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/03/12
        // 功能簡述：TreeNodeExpanded事件
        // 修改人：
        // 修改日期：
        // </summary>
        public event TreeNodeEventHandler TreeNodeExpanded;
        protected void trvControl_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
        {
            if (TreeNodeExpanded != null)
                TreeNodeExpanded(sender, e);
        }
        #endregion

        #region 公有方法－設定TreeView資料來源 setTreeViewDataSource(Object, bool)
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/03/12
        // 功能簡述：設定TreeView資料來源
        // 修改人：
        // 修改日期：
        // </summary>
        /// <summary>
        /// 設定TreeView資料來源
        /// </summary>
        /// <param name="obj">樹狀結構資料(DataSet/DataTable)</param>
        /// <param name="boolIsShow">是否顯示樹狀內容</param>
        public void setTreeViewDataSource(Object obj, bool boolIsShow)
        {
            //設定TreeView資料來源
            switch (obj.GetType().ToString())
            {
                case "System.Data.DataSet":
                    dtTreeViewSource = ((DataSet)obj).Tables[0];
                    break;
                case "System.Data.DataTable":
                    dtTreeViewSource = (DataTable)obj;
                    break;
                default:
                    ShowErrorMessage("未允許的資料來源型別");
                    return;
            }

            //判斷是否顯示樹狀結構內容
            if (boolIsShow && checkTreeViewSource())
                //顯示樹狀結構內容
                ShowTreeView();
        }
        #endregion

        #region 公有方法－顯示樹狀結構內容 ShowTreeView()
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/03/12
        // 功能簡述：顯示樹狀結構內容
        // 修改人：
        // 修改日期：
        // </summary>
        /// <summary>
        /// 顯示樹狀結構內容
        /// </summary>
        public void ShowTreeView()
        {
            if (dtTreeViewSource == null)
            {
                ShowErrorMessage("[錯誤] 請設定TreeView之TreeViewSource屬性");
                return;
            }

            //清除樹資料
            trvControl.Nodes.Clear();
            //建立根節點
            InitTree();
            //設定樹呈現狀況
            if (intTreeViewExpandDepth == -1)
                trvControl.ExpandAll();
            if (intTreeViewExpandDepth == 0)
                trvControl.Nodes[0].CollapseAll();
            else if (intTreeViewExpandDepth != -1)
                getTreeViewCollapse(trvControl.Nodes[0]);

            //更新頁面
            if (strUpdatePanelID != null)
            {
                UpdatePanel up = (UpdatePanel)Page.FindControl(strUpdatePanelID);
                up.Update();
            }
        }
        #endregion

        #region 公有方法－清除TreeView所有節點CheckBox選取狀態 clearTreeNodeChecked()
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/03/12
        // 功能簡述：清除TreeView所有節點CheckBox選取狀態
        // 修改人：
        // 修改日期：
        // </summary>
        /// <summary>
        /// 清除TreeView所有節點CheckBox選取狀態
        /// </summary>
        public void clearTreeNodeChecked()
        {
            if (ShowCheckBoxes != TreeNodeTypes.None)
            {
                foreach (TreeNode node in trvControl.Nodes)
                {
                    node.Checked = false;
                    setTreeNodeChildChecked(node);
                }
            }
        }
        #endregion

        #region 公有方法－設定特定節點父節點或子節點CheckBox選取狀態 setTreeNodeChecked(TreeNode, bool, SetCheckBoxEnum)
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/03/12
        // 功能簡述：設定特定節點父節點或子節點CheckBox選取狀態
        // 修改人：
        // 修改日期：
        // </summary>
        /// <summary>
        /// 設定特定節點父節點或子節點CheckBox選取狀態
        /// </summary>
        /// <param name="node">樹節點</param>
        /// <param name="boolChecked">選取狀態</param>
        /// <param name="scb">設定類型 (Parent-只針對父節點, Child-只針對子節點, All-父子節點皆設定)</param>
        public void setTreeNodeChecked(TreeNode node, bool boolChecked, SetCheckBoxEnum scb)
        {
            if (ShowCheckBoxes != TreeNodeTypes.None)
            {
                node.Checked = boolChecked;
                if (scb == SetCheckBoxEnum.Child || scb == SetCheckBoxEnum.All)
                    setTreeNodeChildChecked(node);
                if (scb == SetCheckBoxEnum.Parent || scb == SetCheckBoxEnum.All)
                    setTreeNodeParentChecked(node);
            }
        }
        #endregion

        #region 公有方法－依資料內容設定節點CheckBox選取狀態 setTreeNodeChecked(DataTable)
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/03/12
        // 功能簡述：依資料內容設定節點CheckBox選取狀態
        // 修改人：
        // 修改日期：
        // </summary>
        /// <summary>
        /// 依資料內容設定節點CheckBox選取狀態
        /// </summary>
        /// <param name="dt">選取節點資料</param>
        public void setTreeNodeChecked(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                foreach (TreeNode node in trvControl.Nodes)
                {
                    if (node.Value == dr[1].ToString())
                        node.Checked = true;
                    if (node.ChildNodes.Count != 0)
                        setTreeNodeChecked(dr, node);
                }
            }
        }
        #endregion

        #region 公有方法－取得已勾選CheckBox之節點資料 getTreeNodeChecked()
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/03/12
        // 功能簡述：取得已勾選CheckBox之節點資料
        // 修改人：
        // 修改日期：
        // </summary>
        /// <summary>
        /// 取得已勾選CheckBox之節點資料
        /// </summary>
        /// <returns></returns>
        public DataTable getTreeNodeChecked()
        {
            DataTable dtCheckBox = new DataTable();
            dtCheckBox.Columns.Add("TreeNodeText");
            dtCheckBox.Columns.Add("TreeNodeValue");

            if (ShowCheckBoxes != TreeNodeTypes.None)
            {
                foreach (TreeNode node in trvControl.Nodes)
                {
                    if (node.Checked)
                    {
                        //記錄資料
                        DataRow dr = dtCheckBox.NewRow();
                        dr["TreeNodeText"] = node.Text.ToString();
                        dr["TreeNodeValue"] = node.Value.ToString();
                        dtCheckBox.Rows.Add(dr);

                        //查詢子節點
                        if (node.ChildNodes.Count != 0)
                            getTreeNodeChecked(dtCheckBox, node);
                    }
                }
            }
            return dtCheckBox;
        }
        #endregion

        #region 私有方法－建立根節點 InitTree()
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/03/12
        // 功能簡述：建立根節點
        // 修改人：
        // 修改日期：
        // </summary>
        private void InitTree()
        {
            //根節點資料篩選－Floor = 1 AND Parent = 1
            string strRoot_Filter = string.Format("{0} = '1' AND {1} = '1'", FloorColumn, ParentColumn);
            DataRow[] arr_dr = dtTreeViewSource.Select(strRoot_Filter);

            if (arr_dr.Length == 0)
            {
                ShowErrorMessage("資料來源中無根節點資料");
                return;
            }

            //設定根節點各屬性
            foreach (DataRow dr in arr_dr)
            {
                TreeNode tmpNote = new TreeNode();
                //節點文字
                tmpNote.Text = dr[TextColumn].ToString();
                //節點值
                tmpNote.Value = dr[ValueColumn].ToString();
                //根節點選擇狀態
                if (SelectActionColumn == "" || SelectActionColumn == null)
                    tmpNote.SelectAction = tnsaRootSelectAction;
                else
                    tmpNote.SelectAction = getTreeNodeSelectAction(dr[SelectActionColumn].ToString());

                //建立根節點 
                trvControl.Nodes.Add(tmpNote);

                //建立子節點 
                AddNodes(tmpNote, 2, tmpNote.Value);
            }
        }
        #endregion

        #region 私有方法－建立子節點 AddNodes(TreeNode, int, string)
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/03/12
        // 功能簡述：建立子節點
        // 修改人：
        // 修改日期：
        // </summary>
        private void AddNodes(TreeNode node, int intFloor, string strParent_Id)
        {
            try
            {
                string strNode_Filter = string.Format("{0} = {1} AND {2} = '{3}'", FloorColumn, intFloor, ParentColumn, strParent_Id);
                DataRow[] arr_dr = dtTreeViewSource.Select(strNode_Filter, OrderColumn);

                ///判斷是否有資料
                if (arr_dr.Length >= 1)
                {
                    //設定根節點各屬性
                    foreach (DataRow dr in arr_dr)
                    {
                        //實體化新節點 
                        TreeNode nodeChild = new TreeNode();
                        //節點文字
                        nodeChild.Text = dr[TextColumn].ToString();
                        //節點值
                        nodeChild.Value = dr[ValueColumn].ToString();
                        //節點提示
                        if (TooltipColumn != "" && TooltipColumn != null)
                        {
                            string strTooltip = "";
                            for (int i = 0; i <= TooltipColumn.Split(',').Length - 1; i++)
                                strTooltip += dr[TooltipColumn.Split(',')[i]].ToString() + " ";
                            nodeChild.ToolTip = strTooltip.TrimEnd();
                        }
                        //節點選取動作
                        TreeNodeSelectAction tnSelectAction;
                        if (SelectActionColumn == "" || SelectActionColumn == null)
                            tnSelectAction = tnsaNode;
                        else
                            tnSelectAction = getTreeNodeSelectAction(dr[SelectActionColumn].ToString());

                        //節點位址, 節點選取動作
                        if (NavigateUrlColumn != "" && NavigateUrlColumn != null)
                        {
                            if (dr[NavigateUrlColumn].ToString() == "")
                                nodeChild.SelectAction = tnSelectAction;
                            else
                            {
                                nodeChild.NavigateUrl = dr[NavigateUrlColumn].ToString();
                                nodeChild.Target = TargetColumn;
                            }
                        }
                        else
                            nodeChild.SelectAction = tnSelectAction;

                        //節點圖示
                        if (NodeImageUrlColumn != "" && NodeImageUrlColumn != null)
                            nodeChild.ImageUrl = dr[NodeImageUrlColumn].ToString();

                        //將節點加入上層節點中
                        node.ChildNodes.Add(nodeChild);

                        //呼叫遞回取得子節點 
                        AddNodes(nodeChild, intFloor + 1, dr[ValueColumn].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage(ex.Message);
            }
        }
        #endregion

        #region 私有方法－設定樹呈現狀況 getTreeViewCollapse(TreeNode)
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/03/12
        // 功能簡述：設定樹呈現狀況
        // 修改人：
        // 修改日期：
        // </summary>
        private void getTreeViewCollapse(TreeNode node)
        {
            foreach (TreeNode nodeChild in node.ChildNodes)
            {
                if (nodeChild.Depth == intTreeViewExpandDepth)
                    nodeChild.CollapseAll();
                else
                    getTreeViewCollapse(nodeChild);
            }
        }
        #endregion

        #region 私有方法－設定特定節點父節點CheckBox選取狀態 setTreeNodeParentChecked(TreeNode)
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/03/12
        // 功能簡述：設定特定節點父節點CheckBox選取狀態
        // 修改人：
        // 修改日期：
        // </summary>
        private void setTreeNodeParentChecked(TreeNode nodeCurrent)
        {
            if (nodeCurrent.Parent != null)
            {
                TreeNode nodeParent = nodeCurrent.Parent;
                bool boolChecked = false;

                if (nodeCurrent.Checked)
                    nodeParent.Checked = true;
                else
                {
                    foreach (TreeNode node in nodeParent.ChildNodes)
                        if (node.Checked)
                        {
                            boolChecked = true;
                            break;
                        }
                    nodeParent.Checked = boolChecked;
                }
                setTreeNodeParentChecked(nodeParent);
            }
        }
        #endregion

        #region 私有方法－設定特定節點子節點CheckBox選取狀態 setTreeNodeChildChecked(TreeNode)
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/03/12
        // 功能簡述：設定特定節點子節點CheckBox選取狀態
        // 修改人：
        // 修改日期：
        // </summary>
        private void setTreeNodeChildChecked(TreeNode nodeCurrent)
        {
            foreach (TreeNode node in nodeCurrent.ChildNodes)
            {
                node.Checked = nodeCurrent.Checked;
                if (node.ChildNodes.Count > 0)
                    setTreeNodeChildChecked(node);
            }
        }
        #endregion

        #region 私有方法－設定節點CheckBox之選取狀態 setTreeNodeChecked(DataRow, TreeNode)
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/02/01
        // 功能簡述：設定節點CheckBox之選取狀態
        // 修改人：
        // 修改日期：
        // </summary>
        private void setTreeNodeChecked(DataRow row, TreeNode nodes)
        {
            foreach (TreeNode node in nodes.ChildNodes)
            {
                if (node.Value == row[1].ToString())
                    node.Checked = true;
                if (node.ChildNodes.Count != 0)
                    setTreeNodeChecked(row, node);
            }
        }
        #endregion

        #region 私有方法－取得已勾選CheckBox之節點資料 getTreeNodeChecked(DataTable, TreeNode)
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/02/01
        // 功能簡述：取得已勾選CheckBox之節點資料
        // 修改人：
        // 修改日期：
        // </summary>
        private void getTreeNodeChecked(DataTable dt, TreeNode nodeCurrent)
        {
            foreach (TreeNode node in nodeCurrent.ChildNodes)
            {
                if (node.Checked)
                {
                    //記錄資料
                    DataRow dr = dt.NewRow();
                    dr["TreeNodeText"] = node.Text.ToString();
                    dr["TreeNodeValue"] = node.Value.ToString();
                    dt.Rows.Add(dr);

                    //查詢子節點
                    if (node.ChildNodes.Count != 0)
                        getTreeNodeChecked(dt, node);
                }
            }
        }
        #endregion

        #region 私有方法－檢查來源資料是否正確 checkTreeViewSource()
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/03/12
        // 功能簡述：檢查來源資料是否正確
        // 修改人：
        // 修改日期：
        // </summary>
        private bool checkTreeViewSource()
        {
            if (FloorColumn == "" || FloorColumn == null)
            {
                ShowErrorMessage("[錯誤] 請設定TreeView之FloorColumn屬性");
                return false;
            }
            else if (ParentColumn == "" || ParentColumn == null)
            {
                ShowErrorMessage("[錯誤] 請設定TreeView之ParentColumn屬性");
                return false;
            }
            else if (TextColumn == "" || TextColumn == null)
            {
                ShowErrorMessage("[錯誤] 請設定TreeView之TextColumn屬性");
                return false;
            }
            else if (ValueColumn == "" || ValueColumn == null)
            {
                ShowErrorMessage("[錯誤] 請設定TreeView之ValueColumn屬性");
                return false;
            }
            return true;
        }
        #endregion

        #region 私有方法－取得節點選取方式 getTreeNodeSelectAction(string)
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2010/02/01
        // 功能簡述：取得已勾選CheckBox之節點資料
        // 修改人：
        // 修改日期：
        // </summary>
        private TreeNodeSelectAction getTreeNodeSelectAction(string strSelectAction)
        {
            switch (strSelectAction.ToUpper())
            {
                case "EXPAND":
                    return TreeNodeSelectAction.Expand;
                case "SELECT":
                    return TreeNodeSelectAction.Select;
                case "SELECTEXPAND":
                    return TreeNodeSelectAction.SelectExpand;
                default:
                    return TreeNodeSelectAction.None;
            }
        }
        #endregion

        #region 私有方法－顯示錯誤訊息 ShowErrorMessage(string)
        // <summary>
        // 撰寫人：Oliver
        // 撰寫日期：2011/03/12
        // 功能簡述：顯示錯誤訊息
        // 修改人：
        // 修改日期：
        // </summary>
        private void ShowErrorMessage(string strMessage)
        {
            trvControl.Visible = false;
            lbMessage.Visible = true;
            lbMessage.Text = strMessage;
        }
        #endregion
    }
}