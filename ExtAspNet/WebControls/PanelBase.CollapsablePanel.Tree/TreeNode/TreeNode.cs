
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    TreeNode.cs
 * CreatedOn:   2008-07-21
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->
 * 
 * 
 * 
 * 
 */

#endregion

using System;
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.Design;
using System.Drawing.Design;
using System.Xml;
using System.Web.UI.WebControls;


namespace ExtAspNet
{
    /// <summary>
    /// 树节点
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true, DefaultProperty = "Nodes")]
    [PersistChildren(false)]
    public class TreeNode
    {
        #region TreeInstance

        private Tree _tree;

        /// <summary>
        /// 树实例
        /// </summary>
        public Tree TreeInstance
        {
            get
            {
                return _tree;
            }
            set
            {
                _tree = value;
            }
        }

        private TreeNode _parentNode;

        /// <summary>
        /// 父节点
        /// </summary>
        public TreeNode ParentNode
        {
            get
            {
                return _parentNode;
            }
            set
            {
                _parentNode = value;
            }
        }


        #endregion

        
        #region Nodes

        private TreeNodeCollection _nodes;

        /// <summary>
        /// 树节点集合
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public TreeNodeCollection Nodes
        {
            get
            {
                if (_nodes == null)
                {
                    // 有时TreeInstance为null，比如在ASPX设置Nodes节点时
                    // 有时TreeInstance不为null，比如通过编程的手段，先添加根节点，然后添加子节点
                    _nodes = new TreeNodeCollection(TreeInstance, this);
                }
                return _nodes;
            }
        }

        #endregion

        #region EnablePostBack|OnClientClick

        private bool _enablePostBack = false;
        /// <summary>
        /// 是否可以回发（单击树节点）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否可以回发（单击树节点）")]
        public bool EnablePostBack
        {
            get
            {
                return _enablePostBack;
            }
            set
            {
                _enablePostBack = value;
            }
        }

        private string _onClientClick = String.Empty;
        /// <summary>
        /// 点击按钮时需要执行的客户端脚本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("点击按钮时需要执行的客户端脚本")]
        public string OnClientClick
        {
            get
            {
                return _onClientClick;
            }
            set
            {
                _onClientClick = value;
            }
        }

        #endregion

        #region CommandName|CommandArgument

        private string _commandName = String.Empty;
        /// <summary>
        /// 命令名称
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("命令名称")]
        public string CommandName
        {
            get
            {
                return _commandName;
            }
            set
            {
                _commandName = value;
            }
        }

        private string _commandArgument = String.Empty;
        /// <summary>
        /// 命令参数
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("命令参数")]
        public string CommandArgument
        {
            get
            {
                return _commandArgument;
            }
            set
            {
                _commandArgument = value;
            }
        }


        #endregion

        #region EnableCheckBox|Checked|AutoPostBack

        private bool _checked = false;
        /// <summary>
        /// 是否选中
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否选中")]
        public bool Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                _checked = value;
            }
        }

        private bool _enableCheckBox = false;
        /// <summary>
        /// 是否启用复选框
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否启用复选框")]
        public bool EnableCheckBox
        {
            get
            {
                return _enableCheckBox;
            }
            set
            {
                _enableCheckBox = value;
            }
        }

        private bool _autoPostBack = false;

        /// <summary>
        /// 是否自动回发（改变复选框状态）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否自动回发（改变复选框状态）")]
        public bool AutoPostBack
        {
            get
            {
                return _autoPostBack;
            }
            set
            {
                _autoPostBack = value;
            }
        }

        #endregion

        #region Properties

        private string _text = String.Empty;
        /// <summary>
        /// 文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("文本")]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        private string _nodeID = String.Empty;
        /// <summary>
        /// 树节点ID
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("树节点ID")]
        public string NodeID
        {
            get
            {
                if (String.IsNullOrEmpty(_nodeID))
                {
                    //_nodeID = String.Format("x_{0}", TreeInstance.NodeIDIncrement++); // ClientJavascriptIDManager.Instance.GetNextJavascriptID();
                    _nodeID = TreeNodeIDManager.Instance.GetNextTreeNodeID();
                }
                return _nodeID;

                #region old code

                //object obj = ViewState["NodeID"];
                //if (obj == null)
                //{
                //    // 生成GUID的方式太占ViewState
                //    //obj = ViewState["NodeID"] = Guid.NewGuid().ToString();
                //    //obj = ViewState["NodeID"] = String.Format("{0}_n{1}", TreeInstance.ClientJavascriptID, _nextNodeIndex++);

                //    obj = ViewState["NodeID"] = ClientJavascriptIDManager.Instance.GetNextJavascriptID();
                //}
                //return (string)obj;

                #endregion
            }
            set
            {
                _nodeID = value;
            }
        }

        private bool _leaf = false;
        /// <summary>
        /// 是否叶子节点
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否叶子节点")]
        public bool Leaf
        {
            get
            {
                return _leaf;
            }
            set
            {
                _leaf = value;
            }
        }

        private bool _enabled = true;
        /// <summary>
        /// 是否可用
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否可用")]
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }


        private bool _expanded = false;
        /// <summary>
        /// 是否展开
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否展开")]
        public bool Expanded
        {
            get
            {
                return _expanded;
            }
            set
            {
                _expanded = value;
            }
        }

        private string _target = String.Empty;
        /// <summary>
        /// 链接目标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("链接目标")]
        public string Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }


        private string _navigateUrl = String.Empty;
        /// <summary>
        /// 链接地址
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("链接地址")]
        public string NavigateUrl
        {
            get
            {
                return _navigateUrl;
            }
            set
            {
                _navigateUrl = value;
            }
        }


        //private string _iconUrl = String.Empty;
        ///// <summary>
        ///// 图标地址
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("图标地址")]
        //[Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
        //public string IconUrl
        //{
        //    get
        //    {
        //        if (String.IsNullOrEmpty(_iconUrl))
        //        {
        //            if (Icon != Icon.None)
        //            {
        //                _iconUrl = IconHelper.GetIconUrl(Icon);
        //            }
        //        }
        //        return _iconUrl;
        //    }
        //    set
        //    {
        //        _iconUrl = value;
        //    }
        //}

        private string _iconUrl = String.Empty;
        /// <summary>
        /// 图标地址
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("图标地址")]
        [Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
        public string IconUrl
        {
            get
            {
                return _iconUrl;
            }
            set
            {
                _iconUrl = value;
            }
        }


        private Icon _icon = Icon.None;
        /// <summary>
        /// 预定义图标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Icon.None)]
        [Description("预定义图标")]
        public virtual Icon Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
            }
        }

        private string _toolTip = String.Empty;
        /// <summary>
        /// 提示文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("提示文本")]
        public string ToolTip
        {
            get
            {
                return _toolTip;
            }
            set
            {
                _toolTip = value;
            }
        }

        private bool _singleClickExpand = false;
        /// <summary>
        /// 单击可切换节点的折叠展开状态
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("单击可切换节点的折叠展开状态")]
        public bool SingleClickExpand
        {
            get
            {
                return _singleClickExpand;
            }
            set
            {
                _singleClickExpand = value;
            }
        }


        #endregion

        #region private DataBindRow

        ///// <summary>
        ///// 绑定行的值
        ///// </summary>
        //public void DataBindRow()
        //{
        //    #region old code
        //    //// 如果没有初始化Values，则初始化
        //    //if (Values == null)
        //    //{
        //    //    GridColumnCollection columns = _grid.Columns;

        //    //    // 计算每列的值
        //    //    Values = new object[columns.Count];
        //    //    ExtraValues = new object[columns.Count];
        //    //    for (int i = 0, count = columns.Count; i < count; i++)
        //    //    {
        //    //        Values[i] = columns[i].GetColumnValue(this);
        //    //    }

        //    //    // 计算DataKeys的值
        //    //    if (_grid.DataKeyNames != null)
        //    //    {
        //    //        string[] keyNames = _grid.DataKeyNames;
        //    //        DataKeys = new object[keyNames.Length];
        //    //        for (int i = 0, count = keyNames.Length; i < count; i++)
        //    //        {
        //    //            DataKeys[i] = GetPropertyValue(keyNames[i]);
        //    //        }
        //    //    }

        //    //    //// CheckBoxField需要特殊处理
        //    //    //for (int i = 0, count = columns.Count; i < count; i++)
        //    //    //{
        //    //    //    CheckBoxField cbField = columns[i] as CheckBoxField;
        //    //    //    if (cbField != null)
        //    //    //    {
        //    //    //        cbField.IniValues();
        //    //    //    }
        //    //    //}
        //    //} 
        //    #endregion
        //}

        #endregion

        #region GetPropertyValue

        ///// <summary>
        ///// 取得属性的值
        ///// </summary>
        ///// <param name="rowObj"></param>
        ///// <param name="propertyName"></param>
        ///// <returns></returns>
        //public object GetPropertyValue(string propertyName)
        //{
        //    //return ObjectUtil.GetPropertyValue(_dataItem, propertyName);
        //}


        #endregion

        #region old code

        //internal TreeNode AddNode()
        //{
        //    TreeNode node = new TreeNode();
        //    Nodes.Add(node);

        //    return node;
        //}

        #endregion

        #region ReadXmlAttributes

        internal void ReadXmlAttributes(XmlAttributeCollection attributes, Tree tree)
        {
            foreach (XmlAttribute attribute in attributes)
            {
                string name = attribute.Name;

                if (tree != null && tree.Mappings.Count > 0)
                {
                    name = tree.GetXmlAttributeMappingTo(name);
                }

                SetPropertyValue(name, attribute.Value);
            }
        }

        /// <summary>
        /// 设置属性的值
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        private void SetPropertyValue(string name, string value)
        {
            PropertyInfo pInfo = GetType().GetProperty(name);

            if (pInfo != null)
            {
                object objValue = null;

                if (pInfo.PropertyType == typeof(System.String))
                {
                    objValue = value;
                }
                else if (pInfo.PropertyType == typeof(System.Boolean))
                {
                    objValue = Convert.ToBoolean(value);
                }
                else if (pInfo.PropertyType == typeof(System.Int32))
                {
                    objValue = Convert.ToInt32(value);
                }
                else if (pInfo.PropertyType == typeof(Icon))
                {
                    objValue = (Icon)Enum.Parse(typeof(Icon), value, true);
                }

                pInfo.SetValue(this, objValue, null);
            }
        }

        #endregion

        #region oldcode

        //public override object SaveViewState()
        //{
        //    object[] states = new object[] { 
        //        base.SaveViewState(), 
        //        ((IStateManager)Nodes).SaveViewState()
        //    };

        //    return states;
        //}

        //public override void LoadViewState(object savedState)
        //{
        //    if (savedState != null)
        //    {
        //        object[] states = (object[])savedState;

        //        base.LoadViewState(states[0]);

        //        ((IStateManager)Nodes).LoadViewState(states[1]);
        //    }
        //}

        //public override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    ((IStateManager)Nodes).TrackViewState();
        //}

        #endregion
    }
}



