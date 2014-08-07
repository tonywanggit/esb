
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    Grid.cs
 * CreatedOn:   2008-05-19
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI.Design.WebControls;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Web.UI.HtmlControls;
using System.Data;
using System.Collections;
using System.Collections.Specialized;

namespace ExtAspNet
{
    /// <summary>
    /// 表格控件
    /// </summary>
    [Designer(typeof(GridDesigner))]
    [ToolboxData("<{0}:Grid Title=\"Grid\" EnableRowNumber=\"true\" EnableCheckBoxSelect=\"true\" runat=\"server\"><Columns></Columns></{0}:Grid>")]
    [ToolboxBitmap(typeof(Grid), "res.toolbox.Grid.bmp")]
    [Description("表格控件")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Grid : CollapsablePanel, IPostBackDataHandler, IPostBackEventHandler
    {
        #region Constructor

        public Grid()
        {
            // 严格的说，PageIndex、SortColumnIndex、SortDirection这三个属性不可能在客户端被改变，而是向服务器发出改变的请求，然后服务器处理。
            // 因为这些属性的改变不会影响客户端的UI，必须服务器端发出UI改变的指令才行，所以它们算是服务器端属性。
            AddServerAjaxProperties("X_Rows", "PageIndex", "PageSize", "RecordCount", "SortColumnIndex", "SortDirection");
            AddClientAjaxProperties("X_States", "HiddenColumnIndexArray", "SelectedRowIndexArray");
        }

        #endregion

        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ControlBaseCollection Items
        {
            get
            {
                return base.Items;
            }
        }

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool EnableIFrame
        {
            get
            {
                return base.EnableIFrame;
            }
        }


        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string IFrameUrl
        {
            get
            {
                return base.IFrameUrl;
            }
        }


        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string IFrameName
        {
            get
            {
                return base.IFrameName;
            }
        }

        /// <summary>
        /// 布局类型
        /// </summary>
        [ReadOnly(true)]
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(Layout.Container)]
        [Description("布局类型")]
        public override Layout Layout
        {
            get
            {
                return Layout.Container;
            }
        }

        #endregion

        #region AllowPaging/IsDatabasePaging/PageSize/PageCount/PageIndex/RecordCount

        /// <summary>
        /// 允许服务器端分页
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("允许服务器端分页")]
        public bool AllowPaging
        {
            get
            {
                object obj = XState["AllowPaging"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["AllowPaging"] = value;
            }
        }

        /// <summary>
        /// 是否数据库分页
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否数据库分页")]
        public bool IsDatabasePaging
        {
            get
            {
                object obj = XState["IsDatabasePaging"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["IsDatabasePaging"] = value;
            }
        }


        /// <summary>
        /// 每页显示项数
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(20)]
        [Description("每页显示项数")]
        public int PageSize
        {
            get
            {
                object obj = XState["PageSize"];
                return obj == null ? 20 : (int)obj;
            }
            set
            {
                XState["PageSize"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]当前显示页索引
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(0)]
        [Description("[AJAX属性]当前显示页索引")]
        public int PageIndex
        {
            get
            {
                object obj = XState["PageIndex"];
                return obj == null ? 0 : (int)obj;
            }
            set
            {
                XState["PageIndex"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]总页数
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PageCount
        {
            get
            {
                int pageCount = RecordCount / PageSize;
                if (RecordCount % PageSize != 0)
                {
                    pageCount += 1;
                }
                return pageCount;
            }
        }


        /// <summary>
        /// [AJAX属性]记录的总个数
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int RecordCount
        {
            get
            {
                object obj = XState["RecordCount"];
                return obj == null ? 0 : (int)obj;
            }
            set
            {
                XState["RecordCount"] = value;
            }
        }

        #endregion

        #region AllowSorting/SortDirection/SortColumnIndex

        /// <summary>
        /// 允许服务器端排序
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("允许服务器端排序")]
        public bool AllowSorting
        {
            get
            {
                object obj = XState["AllowSorting"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["AllowSorting"] = value;
            }
        }


        /// <summary>
        /// 排序方向("ASC", "DESC")
        /// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("ASC")]
        [Description("排序方向（ASC、DESC）")]
        public string SortDirection
        {
            get
            {
                object obj = XState["SortDirection"];
                return obj == null ? "ASC" : (string)obj;
            }
            set
            {
                XState["SortDirection"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]当前按照第几列排序（从零算起）
        /// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(-1)]
        [Description("[AJAX属性]当前按照第几列排序（从零算起）")]
        public int SortColumnIndex
        {
            get
            {
                object obj = XState["SortColumnIndex"];
                if (obj == null)
                {
                    if (!String.IsNullOrEmpty(SortColumn))
                    {
                        return FindColumn(SortColumn).ColumnIndex;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return (int)obj;
                }
            }
            set
            {
                XState["SortColumnIndex"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]排序列（ColumnID）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]排序列（ColumnID）")]
        public string SortColumn
        {
            get
            {
                object obj = XState["SortColumn"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["SortColumn"] = value;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// 点击行是否自动回发（请使用EnableRowClick属性）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("点击行是否自动回发（请使用EnableRowClick属性）")]
        public bool AutoPostBack
        {
            get
            {
                object obj = XState["AutoPostBack"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["AutoPostBack"] = value;
            }
        }

        /// <summary>
        /// 点击行是否自动回发
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("点击行是否自动回发")]
        public bool EnableRowClick
        {
            get
            {
                object obj = XState["EnableRowClick"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["EnableRowClick"] = value;
            }
        }

        /// <summary>
        /// 双击行是否自动回发
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("双击行是否自动回发")]
        public bool EnableRowDoubleClick
        {
            get
            {
                object obj = XState["EnableRowDoubleClick"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["EnableRowDoubleClick"] = value;
            }
        }

        ///// <summary>
        ///// 自动回发的触发行为（默认：单击行）
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(AutoPostBackTrigger.SingleClick)]
        //[Description("自动回发的触发行为（默认：单击行）")]
        //public virtual AutoPostBackTrigger AutoPostBackTrigger
        //{
        //    get
        //    {
        //        object obj = XState["AutoPostBackTrigger"];
        //        return obj == null ? AutoPostBackTrigger.SingleClick : (AutoPostBackTrigger)obj;
        //    }
        //    set
        //    {
        //        XState["AutoPostBackTrigger"] = value;
        //    }
        //}

        /// <summary>
        /// 是否延迟渲染
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否延迟渲染")]
        public bool EnableDelayRender
        {
            get
            {
                object obj = XState["EnableDelayRender"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableDelayRender"] = value;
            }
        }


        /// <summary>
        /// 展开所有的行扩展列
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("展开所有的行扩展列")]
        public bool ExpandAllRowExpanders
        {
            get
            {
                object obj = XState["ExpandAllRowExpanders"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["ExpandAllRowExpanders"] = value;
            }
        }


        /// <summary>
        /// 启用表格中的文字选择
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("启用表格中的文字选择")]
        public bool EnableTextSelection
        {
            get
            {
                object obj = XState["EnableTextSelection"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["EnableTextSelection"] = value;
            }
        }


        #region old code

        //private bool EnableClientPaging_Default = false;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("启用客户端分页")]
        //public bool EnableClientPaging
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableClientPaging"];
        //        return obj == null ? EnableClientPaging_Default : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableClientPaging"] = value;
        //    }
        //}


        //private bool EnableClientSort_Default = false;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("启用客户端排序")]
        //public bool EnableClientSort
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableClientSort"];
        //        return obj == null ? EnableClientSort_Default : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableClientSort"] = value;
        //    }
        //}  


        //private string AutoExpandColumnID_Default = "";

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("自动扩展的列ID")]
        //public string AutoExpandColumnID
        //{
        //    get
        //    {
        //        object obj = BoxState["AutoExpandColumnID"];
        //        return obj == null ? AutoExpandColumnID_Default : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["AutoExpandColumnID"] = value;
        //    }
        //}

        #endregion

        /// <summary>
        /// 启用行索引
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("启用行索引")]
        public bool EnableRowNumber
        {
            get
            {
                object obj = XState["EnableRowNumber"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["EnableRowNumber"] = value;
            }
        }


        /// <summary>
        /// 显示表格表头
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("显示表格表头")]
        public bool ShowGridHeader
        {
            get
            {
                object obj = XState["ShowGridHeader"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["ShowGridHeader"] = value;
            }
        }

        ///// <summary>
        ///// 启用表头菜单
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(true)]
        //[Description("启用表头菜单")]
        //public bool EnableHeaderMenu
        //{
        //    get
        //    {
        //        object obj = XState["EnableHeaderMenu"];
        //        return obj == null ? true : (bool)obj;
        //    }
        //    set
        //    {
        //        XState["EnableHeaderMenu"] = value;
        //    }
        //}

        ///// <summary>
        ///// 启用表头菜单中的隐藏列功能
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(true)]
        //[Description("启用表头菜单中的隐藏列功能")]
        //public bool EnableColumnHide
        //{
        //    get
        //    {
        //        object obj = XState["EnableColumnHide"];
        //        return obj == null ? true : (bool)obj;
        //    }
        //    set
        //    {
        //        XState["EnableColumnHide"] = value;
        //    }
        //}

        /// <summary>
        /// 启用交替行显示不同的颜色
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用交替行显示不同的颜色")]
        public bool EnableAlternateRowColor
        {
            get
            {
                object obj = XState["EnableAlternateRowStyle"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableAlternateRowStyle"] = value;
            }
        }

        /// <summary>
        /// 启用鼠标移动到行的颜色
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用鼠标移动到行的颜色")]
        public bool EnableMouseOverColor
        {
            get
            {
                object obj = XState["EnableMouseOverColor"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableMouseOverColor"] = value;
            }
        }

        #endregion

        #region Width

        /// <summary>
        /// 列的最小宽度
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(Unit), "")]
        [Description("列的最小宽度")]
        public Unit MinColumnWidth
        {
            get
            {
                object obj = XState["MinColumnWidth"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                XState["MinColumnWidth"] = value;
            }
        }

        /// <summary>
        /// 自动扩展宽度以填充剩余空间的列（ColumnID）（如果设置了ForceFitFirstTime或者ForceFitAllTime，则忽略此属性）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("自动扩展宽度以填充剩余空间的列（ColumnID）（如果设置了ForceFitFirstTime或者ForceFitAllTime，则忽略此属性）")]
        public string AutoExpandColumn
        {
            get
            {
                object obj = XState["AutoExpandColumn"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["AutoExpandColumn"] = value;
            }
        }

        /// <summary>
        /// 自动扩展列的最大宽度
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(Unit), "")]
        [Description("自动扩展列的最大宽度")]
        public Unit AutoExpandColumnMax
        {
            get
            {
                object obj = XState["AutoExpandColumnMax"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                XState["AutoExpandColumnMax"] = value;
            }
        }

        /// <summary>
        /// 自动扩展列的最小宽度
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(Unit), "")]
        [Description("自动扩展列的最小宽度")]
        public Unit AutoExpandColumnMin
        {
            get
            {
                object obj = XState["AutoExpandColumnMin"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                XState["AutoExpandColumnMin"] = value;
            }
        }

        /// <summary>
        /// 成比例改变表格各列的宽度，以防止出现水平滚动条（仅在第一次加载表格时有效）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("成比例改变表格各列的宽度，以防止出现水平滚动条（仅在第一次加载表格时有效）")]
        public bool ForceFitFirstTime
        {
            get
            {
                object obj = XState["ForceFitFirstTime"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["ForceFitFirstTime"] = value;
            }
        }

        /// <summary>
        /// 成比例改变表格各列的宽度，以防止出现水平滚动条（第一次加载和之后改变表格宽度时都有效）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("成比例改变表格各列的宽度，以防止出现水平滚动条（第一次加载和之后改变表格宽度时都有效）")]
        public bool ForceFitAllTime
        {
            get
            {
                object obj = XState["ForceFitAllTime"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["ForceFitAllTime"] = value;
            }
        }

        /// <summary>
        /// 垂直滚动条的宽度（不设置则自动计算宽度，0则消除右侧预留的滚动条宽度）
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(Unit), "")]
        [Description("垂直滚动条的宽度（不设置则自动计算宽度，0则消除右侧预留的滚动条宽度）")]
        public Unit VerticalScrollWidth
        {
            get
            {
                object obj = XState["VerticalScrollWidth"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                XState["VerticalScrollWidth"] = value;
            }
        }

        #endregion

        #region old code

        //private GridRowExpander _rowExpander;

        //[Category(CategoryName.OPTIONS)]
        //[NotifyParentProperty(true)]
        //[PersistenceMode(PersistenceMode.InnerProperty)]
        //public GridRowExpander RowExpander
        //{
        //    get
        //    {
        //        if (_rowExpander == null)
        //        {
        //            _rowExpander = new GridRowExpander();
        //        }
        //        return _rowExpander;
        //    }
        //}


        #endregion

        #region EnableCheckBoxSelect/EnableMultiSelect/SelectedRowIndexArray

        /// <summary>
        /// 启用多选框
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("启用多选框")]
        public bool EnableCheckBoxSelect
        {
            get
            {
                object obj = XState["EnableCheckBoxSelect"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["EnableCheckBoxSelect"] = value;
            }
        }


        /// <summary>
        /// 启用多行选择
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用多行选择")]
        public bool EnableMultiSelect
        {
            get
            {
                object obj = XState["EnableMultiSelect"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableMultiSelect"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]选中行的索引（列表中的第一项）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedRowIndex
        {
            get
            {
                if (SelectedRowIndexArray.Length > 0)
                {
                    return SelectedRowIndexArray[0];
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                SelectedRowIndexArray = new int[] { value };
            }
        }


        /// <summary>
        /// [AJAX属性]选中行的索引列表
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int[] SelectedRowIndexArray
        {
            get
            {
                object obj = XState["SelectedRowIndexArray"];
                return obj == null ? new int[] { } : (int[])obj;
            }
            set
            {
                XState["SelectedRowIndexArray"] = GetSortedArray(value).ToArray();
            }
        }

        private List<int> GetSortedArray(int[] value)
        {
            List<int> list = new List<int>();
            if (value != null)
            {
                list.AddRange(value);
                list.Sort();
            }
            return list;
        }

        ///// <summary>
        ///// Whether this property changed.
        ///// </summary>
        ///// <param name="newValue"></param>
        ///// <returns></returns>
        //private bool SelectedRowIndexArrayChanged(int[] newValue)
        //{
        //    if (newValue == null)
        //    {
        //        newValue = new int[] { };
        //    }
        //    if (newValue.Length > 0)
        //    {
        //        // Make sure this list order ASC [1, 2, 6, 8]
        //        List<int> intList = new List<int>(newValue);
        //        intList.Sort();
        //        newValue = intList.ToArray();
        //    }

        //    return new JArray(SelectedRowIndexArray).ToString() != new JArray(newValue).ToString();
        //}

        /// <summary>
        /// [AJAX属性]隐藏的列
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int[] HiddenColumnIndexArray
        {
            get
            {

                List<int> hiddens = new List<int>();
                if (AllColumns.Count > 0)
                {
                    int prefix = GetPrefixColumnNumber();
                    for (int i = 0; i < AllColumns.Count; i++)
                    {
                        if (AllColumns[i].Hidden)
                        {
                            hiddens.Add(i + prefix);
                        }
                    }
                }
                return hiddens.ToArray();
            }
            set
            {
                List<int> hiddens = GetSortedArray(value);
                int prefix = GetPrefixColumnNumber();
                for (int i = 0; i < AllColumns.Count; i++)
                {
                    if (hiddens.Contains(i + prefix))
                    {
                        AllColumns[i].Hidden = true;
                    }
                    else
                    {
                        AllColumns[i].Hidden = false;
                    }
                }
            }
        }

        #endregion

        #region DataSource/DataKeyNames/DataKeys

        private object _dataSource = null;

        /// <summary>
        /// 数据源
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object DataSource
        {
            set
            {
                _dataSource = value;
            }
            get
            {
                return _dataSource;
            }
        }



        /// <summary>
        /// 行关键字段
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("行关键字段")]
        [TypeConverter(typeof(StringArrayConverter))]
        public string[] DataKeyNames
        {
            get
            {
                object obj = XState["DataKeyNames"];
                return obj == null ? null : (string[])obj;
            }
            set
            {
                XState["DataKeyNames"] = value;
            }
        }


        private List<object[]> _dataKeys = null;

        /// <summary>
        /// 行关键字段的值
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<object[]> DataKeys
        {
            get
            {
                if (_dataKeys == null)
                {
                    _dataKeys = new List<object[]>();

                    for (int i = 0, count = _rows.Count; i < count; i++)
                    {
                        _dataKeys.Add(_rows[i].DataKeys);
                    }
                }
                else
                {
                    for (int i = _dataKeys.Count, count = _rows.Count; i < count; i++)
                    {
                        _dataKeys.Add(_rows[i].DataKeys);
                    }

                }

                return _dataKeys;
            }
        }


        #endregion

        #region GroupColumns/Columns/Rows

        private GridGroupColumnCollection _groupColumns;

        /// <summary>
        /// 分组列数据
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual GridGroupColumnCollection GroupColumns
        {
            get
            {
                if (_groupColumns == null)
                {
                    _groupColumns = new GridGroupColumnCollection(this);
                }
                return _groupColumns;
            }
        }

        private GridColumnCollection _allColumnsInternal;
        /// <summary>
        /// 全部的列
        /// </summary>
        internal virtual GridColumnCollection AllColumnsInternal
        {
            get
            {
                if (_allColumnsInternal == null)
                {
                    _allColumnsInternal = new GridColumnCollection(this);
                }
                return _allColumnsInternal;
            }
        }

        /// <summary>
        /// 全部的列
        /// </summary>
        public virtual GridColumnCollection AllColumns
        {
            get
            {
                if (_allColumnsInternal == null)
                {
                    return Columns;
                }
                return _allColumnsInternal;
            }
        }


        private GridColumnCollection _columns;

        /// <summary>
        /// 列数据
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual GridColumnCollection Columns
        {
            get
            {
                if (_columns == null)
                {
                    _columns = new GridColumnCollection(this);
                }
                return _columns;
            }
        }

        private GridRowCollection _rows;

        /// <summary>
        /// 行数据
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual GridRowCollection Rows
        {
            get
            {
                if (_rows == null)
                {
                    _rows = new GridRowCollection();
                }
                return _rows;
            }
        }
        #endregion

        #region X Properties

        /// <summary>
        /// 保存的行数据（内部使用）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public JObject X_Rows
        {
            get
            {
                JObject jo = new JObject();

                JArray valuesJA = new JArray();
                JArray datakeysJA = new JArray();
                //JArray statesJA = new JArray();
                foreach (GridRow row in Rows)
                {
                    valuesJA.Add(new JArray(row.Values));
                    datakeysJA.Add(new JArray(row.DataKeys));
                    //statesJA.Add(new JArray(row.ToShortStates()));
                }
                jo.Add("Values", valuesJA);
                jo.Add("DataKeys", datakeysJA);
                //jo.Add("States", statesJA);

                return jo;
            }
            set
            {
                ClearRows();

                JArray valuesArray = value.Value<JArray>("Values"); // value.getJArray("Values");
                JArray dataKeysArray = value.Value<JArray>("DataKeys"); //value.getJArray("DataKeys");
                //JArray statesArray = value.Value<JArray>("States");  //value.getJArray("States");
                for (int i = 0, length = valuesArray.Count; i < length; i++)
                {
                    GridRow row = new GridRow(this, null, i);

                    // row.Values
                    row.Values = JSONUtil.StringArrayFromJArray(valuesArray[i].Value<JArray>()); // .getJArray(i));

                    // row.DataKeys
                    row.DataKeys = JSONUtil.ObjectArrayFromJArray(dataKeysArray[i].Value<JArray>()); //.getJArray(i));

                    //// row.States
                    //row.FromShortStates(JSONUtil.ObjectArrayFromJArray(statesArray[i].Value<JArray>()));

                    Rows.Add(row);
                    Controls.Add(row);


                    row.InitTemplateContainers();
                }
            }
        }

        /// <summary>
        /// 保存的行状态（内部使用）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public JArray X_States
        {
            get
            {
                JArray statesJA = new JArray();
                foreach (GridRow row in Rows)
                {
                    statesJA.Add(new JArray(row.ToShortStates()));
                }

                return statesJA;
            }
            set
            {
                for (int i = 0, length = value.Count; i < length; i++)
                {
                    GridRow row = Rows[i];

                    // row.States
                    row.FromShortStates(JSONUtil.ObjectArrayFromJArray(value[i].Value<JArray>()));
                }
            }
        }

        #endregion

        #region OnInitControl

        protected override void OnInitControl()
        {
            base.OnInitControl();

            // Note: this initialization is done in the InsertItem of GridColumnCollection.
            //// Init Columns property.
            //int columnIndex = 0;
            //foreach (GridColumn column in Columns)
            //{
            //    column.Grid = this;
            //    column.ColumnIndex = columnIndex;
            //    columnIndex++;
            //}
        }

        #endregion

        #region old code LoadXState/SaveXState

        //protected override void LoadXState(JObject state, string property)
        //{
        //    base.LoadXState(state, property);

        //    if (property == "X_Rows")
        //    {
        //        XRowsFromJSON(state.getJObject(property));
        //    }
        //}

        //protected override void OnInit(EventArgs e)
        //{
        //    base.OnInit(e);

        //    // Init Columns property.
        //    int columnIndex = 0;
        //    foreach (GridColumn column in Columns)
        //    {
        //        column.Grid = this;
        //        column.ColumnIndex = columnIndex;
        //        columnIndex++;
        //    }

        //    SaveXProperty("X_Rows", XRowsToJSON().ToString());
        //    //SaveXProperty("SelectedRowIndexArray", new JArray(SelectedRowIndexArray).ToString());
        //}

        //protected override void OnBothPreRender()
        //{
        //    base.OnBothPreRender();

        //    // Rows has been changed in server-side code after onInit.
        //    if (XPropertyModified("X_Rows", XRowsToJSON().ToString()))
        //    {
        //        XState.AddModifiedProperty("X_Rows");
        //    }

        //    // Make sure SelectedRowIndexArray property exist in X_STATE during page's first load.
        //    if (!Page.IsPostBack)
        //    {
        //        XState.AddModifiedProperty("SelectedRowIndexArray");
        //    }

        //    //if (XPropertyModified("SelectedRowIndexArray", new JArray(SelectedRowIndexArray).ToString()))
        //    //{
        //    //    XState.AddModifiedProperties("SelectedRowIndexArray");
        //    //}
        //    //else
        //    //{
        //    //    XState.RemoveModifiedProperties("SelectedRowIndexArray");
        //    //}
        //}

        //protected override void SaveXState(JObject state, string property)
        //{
        //    if (property == "X_Rows")
        //    {
        //        state.put(property, XRowsToJSON());
        //    }
        //}

        //private JObject XRowsToJSON()
        //{
        //    JObject jo = new JObject();

        //    JArray valuesJA = new JArray();
        //    JArray datakeysJA = new JArray();
        //    foreach (GridRow row in Rows)
        //    {
        //        valuesja.Add(new JArray(row.Values));
        //        datakeysja.Add(new JArray(row.DataKeys));
        //    }
        //    jo.Add("Values", valuesJA);
        //    jo.Add("DataKeys", datakeysJA);

        //    return jo;
        //}

        //private void XRowsFromJSON(JObject jo)
        //{
        //    JArray valuesArray = jo.getJArray("Values");
        //    JArray dataKeysArray = jo.getJArray("DataKeys");
        //    for (int i = 0, length = valuesArray.Count; i < length; i++)
        //    {
        //        GridRow row = new GridRow();

        //        // row.Values
        //        row.Values = JSONUtil.StringArrayFromJArray(valuesArray.getJArray(i));

        //        // row.DataKeys
        //        row.DataKeys = JSONUtil.ObjectArrayFromJArray(dataKeysArray.getJArray(i));

        //        Rows.Add(row);
        //    }
        //}

        #endregion

        #region SelectedRowsHiddenFieldID

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private string SelectedRowIndexArrayHiddenFieldID
        {
            get
            {
                return String.Format("{0}_SelectedRowIndexArray", ClientID);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private string HiddenColumnIndexArrayHiddenFieldID
        {
            get
            {
                return String.Format("{0}_HiddenColumnIndexArray", ClientID);
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private string RowStatesHiddenFieldID
        {
            get
            {
                return String.Format("{0}_RowStates", ClientID);
            }
        }

        ///// <summary>
        ///// 实际绑定到页面上的值
        ///// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //internal int[] NeedPersistStateColumnIndexArray
        //{
        //    get
        //    {
        //        object obj = XState["NeedPersistStateColumnIndexArray"];
        //        return obj == null ? null : (int[])obj;
        //    }
        //    set
        //    {
        //        XState["NeedPersistStateColumnIndexArray"] = value;
        //    }
        //}

        //private string GetNeedPersistStateColumnIndexID(int columnIndex)
        //{
        //    return String.Format("{0}_columnIndex{1}", ClientID, columnIndex);
        //}


        #region old code
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[Description("客户端分页时，开始行的序号")]
        //private string EnableClientPagingStartRowIndexID
        //{
        //    get
        //    {
        //        return String.Format("{0}_startRowIndex", ClientID);
        //    }
        //}

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[Description("客户端分页时，开始行的序号")]
        //internal int EnableClientPagingStartRowIndex
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableClientPagingStartRowIndex"];
        //        return obj == null ? 0 : (int)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableClientPagingStartRowIndex"] = value;
        //    }
        //} 
        #endregion

        #endregion

        #region OnPreRender

        #region Render_IDS

        private string Render_SelectModelID
        {
            get
            {
                return String.Format("{0}_sm", XID);
            }
        }

        private string Render_GridStoreID
        {
            get
            {
                return String.Format("{0}_store", XID);
            }
        }

        private string Render_GridColumnModelID
        {
            get
            {
                return String.Format("{0}_cm", XID);
            }
        }

        private string Render_GridRowExpanderID
        {
            get
            {
                return String.Format("{0}_expander", XID);
            }
        }

        private string Render_GridGroupColumnID
        {
            get
            {
                return String.Format("{0}_groupcolumn", XID);
            }
        }

        private string Render_PagingID
        {
            get
            {
                return String.Format("{0}_paging", XID);
            }
        }

        //// ExtAspNetAjax回发时，列是否发生变化
        //private bool _ExtAspNetAjaxColumnsChanged = false;

        #endregion

        #region OnAjaxPreRender OnFirstPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();

            bool dataReloaded = false;
            if (AllowPaging)
            {
                // 不论这三个属性是在客户端还是在服务器端被改变，都需要执行grid.getBottomToolbar().load函数
                // 如果不是数据库分页，则X_Rows不会变化，但是必须执行x_loadData
                if (PropertyModified("PageIndex", "PageSize", "RecordCount"))
                {
                    sb.AppendFormat("{0}.getBottomToolbar().load({1});", XID, GetPagingBuilder());
                    sb.AppendFormat("{0}.x_loadData();", XID);

                    sb.AppendFormat("{0}.x_setSortIcon({1}, '{2}');", XID, SortColumnIndex, SortDirection);

                    dataReloaded = true;
                }
            }

            if (PropertyModified("X_Rows"))
            {
                //if (ClientPropertyModifiedInServer("X_Rows"))
                if (!dataReloaded)
                {
                    sb.AppendFormat("{0}.x_loadData();", XID);

                    sb.AppendFormat("{0}.x_setSortIcon({1}, '{2}');", XID, SortColumnIndex, SortDirection);

                    dataReloaded = true;
                }
            }

            // 本次AJAX请求重新加载的表格
            if (dataReloaded)
            {
                PageManager.Instance.AjaxGridReloadedClientIDs.Add(ClientID);
            }

            if (PropertyModified("X_States"))
            {
                sb.AppendFormat("{0}.x_setRowStates();", XID);
            }

            if (PropertyModified("SortColumnIndex", "SortDirection"))
            {
                sb.AppendFormat("{0}.x_setSortIcon({1}, '{2}');", XID, SortColumnIndex, SortDirection);
            }

            bool selectRowsScriptRegistered = false;

            if (PropertyModified("SelectedRowIndexArray"))
            {
                sb.AppendFormat("{0}.x_selectRows();", XID);

                selectRowsScriptRegistered = true;
            }

            if (PropertyModified("HiddenColumnIndexArray"))
            {
                sb.AppendFormat("{0}.x_hiddenColumns();", XID);
            }

            // 如果数据重新加载了
            if (dataReloaded)
            {
                // 判断是否需要展开所有的行扩展列
                if (ExpandAllRowExpanders)
                {
                    sb.AppendFormat("{0}.x_expandAllRows();", XID);
                }

                // 是否启用文本选择
                if (EnableTextSelection)
                {
                    sb.AppendFormat("{0}.x_enableTextSelection();", XID);
                }

                // 不管选择的行是否有变化，都要重新选中行
                if (!selectRowsScriptRegistered)
                {
                    sb.AppendFormat("{0}.x_selectRows();", XID);
                }

                // 需要更新模版列的内容，因为HTML重新渲染了
                PageManager.Instance.AjaxGridClientIDs.Add(ClientID);
            }

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            // 确保 X_Rows 在页面第一次加载时都存在于x_state中
            XState.AddModifiedProperty("X_Rows");

            base.OnFirstPreRender();

            ResourceManager.Instance.AddJavaScriptComponent("grid");

            //OB.Listeners.AddProperty("rowmousedown", "function(){alert('ok');}", true);

            #region selectModel/gridStore/gridColumn

            #region old code
            //string dataScript = "var grid_data=[['My_Item1The id of a column in this grid that should expand to fill unused space. This id can not be 0.','1','2008'],['My_Item2','2','2007']];";
            //string storeScript = "var grid_store = new Ext.data.SimpleStore({fields:[{name:'name1'},{name:'value'},{name:'year'}]});\r\ngrid_store.loadData(grid_data);";
            //string storeScript = "var grid_store = new Ext.data.SimpleStore({fields:['name1','value1','year1'],data:[['My_Item1The id of a column in this grid that should expand to fill unused space. This id can not be 0.','1','2008'],['My_Item2','2','2007']]});";
            //OB.AddProperty(OptionName.Columns, "[{id:'name2', header: 'Price', sortable: true},{header: 'Price2', sortable: true},{header: 'Price3', sortable: true}]", true);

            #endregion

            string gridSelectModelScript = GetGridSelectModel();
            OB.AddProperty("sm", Render_SelectModelID, true);
            //OB.AddProperty("disableSelection", true);

            string gridColumnsScript = GetGridColumnScript();
            OB.AddProperty("cm", Render_GridColumnModelID, true);
            //if (!String.IsNullOrEmpty(RowExpander.DataFormatString))
            //{
            //    OB.AddProperty("plugins", Render_GridRowExpanderID, true);
            //}

            string gridStoreScript = GetGridStore();
            OB.AddProperty("store", Render_GridStoreID, true);

            //Console.WriteLine(RowExpander.DataFields);

            #endregion

            #region Width

            if (MinColumnWidth != Unit.Empty)
            {
                OB.AddProperty("minColumnWidth", MinColumnWidth.Value);
            }

            string autoExpandColumnID = AutoExpandColumn; // GetAutoExpandColumnID();
            if (String.IsNullOrEmpty(autoExpandColumnID))
            {
                autoExpandColumnID = GetAutoExpandColumnID();  
            }

            if (!String.IsNullOrEmpty(autoExpandColumnID))
            {
                OB.AddProperty("autoExpandColumn", autoExpandColumnID);

                if (AutoExpandColumnMax != Unit.Empty)
                {
                    OB.AddProperty("autoExpandMax", AutoExpandColumnMax.Value);
                }

                if (AutoExpandColumnMin != Unit.Empty)
                {
                    OB.AddProperty("autoExpandMin", AutoExpandColumnMin.Value);
                }
            }


            JsObjectBuilder viewBuilder = new JsObjectBuilder();
            if(ForceFitAllTime)
            {
                viewBuilder.AddProperty("forceFit", true);
            }
            if (ForceFitFirstTime)
            {
                viewBuilder.AddProperty("autoFill", true);
            }

            if (VerticalScrollWidth != Unit.Empty)
            {
                viewBuilder.AddProperty("scrollOffset", VerticalScrollWidth.Value);
            }

            if (viewBuilder.Count > 0)
            {
                OB.AddProperty("viewConfig", viewBuilder);
            }

            #endregion

            #region Properties

            //if (!EnableHeaderMenu)
            //{
            //    OB.AddProperty("enableHdMenu", false);
            //}
            //if (!EnableColumnHide)
            //{
            //    OB.AddProperty("enableColumnHide", false);
            //}

            OB.AddProperty("enableHdMenu", false);

            if (EnableAlternateRowColor)
            {
                OB.AddProperty("stripeRows", true);
            }

            if (!ShowGridHeader)
            {
                OB.AddProperty("hideHeaders", true);
            }

            if (!EnableMouseOverColor)
            {
                OB.AddProperty("trackMouseOver", false);
            }

            // 延迟渲染
            if (!EnableDelayRender)
            {
                OB.AddProperty("deferRowRender", false);
            }

            

            #endregion

            #region AutoPostBack

            if (AutoPostBack || EnableRowClick)
            {
                string validateScript = "var args='RowClick$'+rowIndex;";
                validateScript += GetPostBackEventReference("#RowClick#").Replace("'#RowClick#'", "args");

                string rowClickScript = String.Format("function(grid,rowIndex,e){{{0}}}", validateScript);


                OB.Listeners.AddProperty("rowclick", rowClickScript, true);
            }

            if (EnableRowDoubleClick)
            {
                string validateScript = "var args='RowDoubleClick$'+rowIndex;";
                validateScript += GetPostBackEventReference("#RowDoubleClick#").Replace("'#RowDoubleClick#'", "args");

                string rowClickScript = String.Format("function(grid,rowIndex,e){{{0}}}", validateScript);

                OB.Listeners.AddProperty("rowdblclick", rowClickScript, true);
            }

            #endregion

            #region AllowPaging

            string pagingScript = String.Empty;
            if (AllowPaging)
            {
                JsObjectBuilder pagingBuilder = GetPagingBuilder();

                pagingBuilder.AddProperty("displayInfo", true);
                //pagingBuilder.AddProperty("store", Render_GridStoreID, true);
                //// Hide refresh button, we don't implement this logic now.
                //pagingBuilder.Listeners.AddProperty("beforerender", JsHelper.GetFunction("this.x_hideRefresh();"), true);

                string postbackScript = String.Empty;
                postbackScript = GetPostBackEventReference("#PLACEHOLDER#");
                string loadPageScript = JsHelper.GetFunction(postbackScript.Replace("'#PLACEHOLDER#'", "'Page$'+pageIndex"), "pageIndex");

                pagingBuilder.AddProperty("onLoadPage", loadPageScript, true);


                pagingScript = String.Format("var {0}=new Ext.ux.SimplePagingToolbar({1});", Render_PagingID, pagingBuilder);

                OB.AddProperty("bbar", Render_PagingID, true);
            }

            #endregion

            #region old code

            //string checkBoxFieldScript = String.Empty;
            //int columnIndex = 0;
            //List<int> needPersistStateColumnIndexList = new List<int>();
            //foreach (GridColumn column in Columns)
            //{
            //    if (column is CheckBoxField)
            //    {
            //        CheckBoxField checkBoxField = column as CheckBoxField;

            //        if (!checkBoxField.RenderAsStaticField)
            //        {
            //            // check -> uncheck
            //            //string checkScript = String.Format("ele.toggleClass('box-grid-checkbox-uncheck');var domValue=Ext.get('{0}').dom.value;var rowValueIndex=domValue.indexOf(rowIndex+',');if(rowValueIndex>=0){{Ext.get('{0}').dom.value=domValue.replace(rowIndex+',','');}}else{{return;}}", GetNeedPersistStateColumnIndexID(columnIndex));
            //            //string uncheckScript = String.Format("ele.toggleClass('box-grid-checkbox-uncheck');var domValue=Ext.get('{0}').dom.value;var rowValueIndex=domValue.indexOf(rowIndex+',');if(rowValueIndex>=0){{return;}}else{{Ext.get('{0}').dom.value+=rowIndex+',';}}", GetNeedPersistStateColumnIndexID(columnIndex));

            //            //string checkScript = String.Format("ele.toggleClass('box-grid-checkbox-uncheck');X.util.removeValueFromHiddenField('{0}',rowIndex);", GetNeedPersistStateColumnIndexID(columnIndex));
            //            //string uncheckScript = String.Format("ele.toggleClass('box-grid-checkbox-uncheck');X.util.addValueToHiddenField('{0}',rowIndex);", GetNeedPersistStateColumnIndexID(columnIndex));

            //            string checkScript = "ele.toggleClass('box-grid-checkbox-uncheck');";
            //            string uncheckScript = "ele.toggleClass('box-grid-checkbox-uncheck');";


            //            checkBoxFieldScript += String.Format("{0}_checkbox{1}=function(e,ele,rowIndex){{var ele=Ext.get(ele);if(ele.hasClass('box-grid-checkbox-uncheck')){{{2}}}else{{{3}}}}};", XID, columnIndex, uncheckScript, checkScript);
            //            //checkBoxFieldScript += "\r\n";

            //            needPersistStateColumnIndexList.Add(columnIndex);
            //        }
            //    }
            //    columnIndex++;
            //}

            //NeedPersistStateColumnIndexArray = needPersistStateColumnIndexList.ToArray();

            #endregion

            #region old code

            //string hiddenFieldsScript = String.Empty;

            //hiddenFieldsScript += GetSetHiddenFieldValueScript(SelectedRowIndexArrayHiddenFieldID, StringUtil.GetStringFromIntArray(SelectedRowIndexArray));

            //// 有这些列需要保存状态
            //if (NeedPersistStateColumnIndexArray != null && NeedPersistStateColumnIndexArray.Length > 0)
            //{
            //    foreach (int needStateColumnIndex in NeedPersistStateColumnIndexArray)
            //    {
            //        hiddenFieldsScript += GetSetHiddenFieldValueScript(GetNeedPersistStateColumnIndexID(needStateColumnIndex), Columns[needStateColumnIndex].SaveColumnState());
            //    }
            //}

            //hiddenFieldsScript += "\r\n";
            #endregion

            #region remove fx

            OB.AddProperty("draggable", false);
            OB.AddProperty("enableColumnMove", false);
            OB.AddProperty("enableDragDrop", false);

            #endregion

            #region old code

            //JsObjectBuilder viewConfigBuilder = new JsObjectBuilder();
            //viewConfigBuilder.AddProperty("autoFill", true);
            //viewConfigBuilder.AddProperty("deferEmptyText", true);
            //viewConfigBuilder.AddProperty("emptyText", "没有数据需要显示");

            //OB.AddProperty("viewConfig", viewConfigBuilder);

            #endregion

            #region AllowSorting

            // 如果启用服务器端排序，则需要注册headerclick事件处理
            if (AllowSorting)
            {
                #region old code
                ////string argumentStr = "var field=sortInfo.field.substr(sortInfo.field.indexOf('__')+2);var args='Sort$'+field+'$'+ sortInfo.direction;";
                //string argumentStr = "var args='Sort$'+sortInfo.field;";
                //string postBackReference = String.Format("{1}__doPostBack('{0}',args);return false;", ClientID, argumentStr);

                //string sortChangeScript = String.Format("function(grid,sortInfo){{{0}}}", postBackReference);
                //OB.Listeners.AddProperty(OptionName.Sortchange, sortChangeScript, true); 


                // 下面这个规则不再使用，因为会引入中文，导致Ext.get('Grid1').select 函数出错
                // 还要进行验证：序号列和多选框列不能排序，没有设置SortField的列也不能排序
                // 规则：如果此列的dataIndex为空，表示不是数据列（就是序号列或多选框列），
                // 如果dataIndex为"c0__MyText"，表示排序字段是"MyText"，如果dataIndex为"c2"，表示没有定义排序列
                //string validateScript = "var dataIndex=grid.initialConfig.columns[columnIndex].dataIndex;if(dataIndex==''||dataIndex.indexOf('__')<0){return false;}";

                //string validateScript = "var dataIndex=grid.getColumnModel().getDataIndex(columnIndex);if(dataIndex==''||dataIndex.indexOf('__')<0){return false;}";
                #endregion

                string headerClickScript = "if(!cmp.getColumnModel().config[columnIndex].x_serverSortable){return false;}";
                headerClickScript += "var args='Sort$'+columnIndex;";
                headerClickScript += GetPostBackEventReference("#SORT#").Replace("'#SORT#'", "args");

                //string headerClickScript = String.Format("function(grid,columnIndex){{{0}}}", validateScript);
                OB.Listeners.AddProperty("headerclick", JsHelper.GetFunction(headerClickScript, "cmp", "columnIndex"), true);

                #region old code
                //string sortIconScript = GetSortIconScript();

                //if (_ExtAspNetAjaxColumnsChanged)
                //{
                //    // 如果列都发生了变化，需要重新设置图标
                //    AddAjaxPropertyChangedScript(sortIconScript);
                //}
                //else
                //{
                //    if (AjaxPropertyChanged("SortIconScript", sortIconScript))
                //    {
                //        AddAjaxPropertyChangedScript(sortIconScript);
                //    }
                //}

                //renderSB.Append(sortIconScript);


                //// For these columns need sorted, show the cursor pointer.
                //List<string> columnIDList = new List<string>();
                //foreach (GridColumn column in Columns)
                //{
                //    if (!String.IsNullOrEmpty(column.SortField))
                //    {
                //        columnIDList.Add(column.ColumnID);
                //    }
                //}

                //// 存在需要排序的列
                //if (columnIDList.Count > 0)
                //{
                //    string cursorScript = String.Format("Ext.each({0},{1});", JsHelper.GetJsStringArray(columnIDList.ToArray()),
                //        String.Format("function(item){{Ext.get('{0}').select('.x-grid3-hd-row .x-grid3-td-'+item).addClass('cursor-pointer');}}", ClientID));


                //    renderSB.Append(cursorScript);

                //    if (_ExtAspNetAjaxColumnsChanged)
                //    {
                //        // 如果列都发生了变化，需要重新需要排序的列，显示为手型的光标
                //        AddAjaxPropertyChangedScript(cursorScript);
                //    }
                //} 
                #endregion
            }

            #endregion

            #region Listeners - render - viewready

            StringBuilder viewreadySB = new StringBuilder();

            // Note: this.x_state['X_Rows']['Values'] will always rendered to the client side.
            //viewreadySB.Append("cmp.x_updateTpls();");

            if (AllowSorting)
            {
                // After the grid is rendered, then we can apply sort icon to grid header.
                viewreadySB.AppendFormat("cmp.x_setSortIcon({0}, '{1}');", SortColumnIndex, SortDirection);
            }
            viewreadySB.Append("cmp.x_selectRows();");


            // 展开所有的行扩展列
            if (ExpandAllRowExpanders)
            {
                viewreadySB.Append("cmp.x_expandAllRows();");
            }

            if (EnableTextSelection)
            {
                OB.AddProperty("cls", CssClass + " x-grid-selectable");

                viewreadySB.Append("cmp.x_enableTextSelection();");
            }

            OB.Listeners.AddProperty("viewready", JsHelper.GetFunction(viewreadySB.ToString(), "cmp"), true);


            #endregion

            #region Listeners - render

            StringBuilder renderSB = new StringBuilder();


            renderSB.Append("cmp.x_loadData();");

            OB.Listeners.AddProperty("render", JsHelper.GetFunction(renderSB.ToString(), "cmp"), true);


            #endregion

            StringBuilder sb = new StringBuilder();
            sb.Append(gridSelectModelScript + gridStoreScript + gridColumnsScript + pagingScript);
            sb.AppendFormat("var {0}=new Ext.grid.GridPanel({1});", XID, OB);

            AddStartupScript(sb.ToString());

            #region old code

            ////List<string> totalModifiedProperties = XState.GetTotalModifiedProperties();
            ////if (SelectedRowIndexArray.Length > 0)
            ////{
            ////    string selectScript = String.Empty;
            ////    if (totalModifiedProperties.Contains("SelectedRowIndexArray"))
            ////    {
            ////        selectScript = String.Format("{0}.x_selectRows();", XID);
            ////    }
            ////    else
            ////    {
            ////        selectScript = String.Format("{0}.selectRows({1});", Render_SelectModelID, new JArray(SelectedRowIndexArray));
            ////    }
            ////    sb.Append(JsHelper.GetDeferScript(selectScript, 200));
            ////}

            //// Make sure SelectedRowIndexArray property exist in X_STATE during page's first load.
            //sb.Append(JsHelper.GetDeferScript(String.Format("{0}.x_selectRows();", XID), 200));

            #endregion
        }

        private JsObjectBuilder GetPagingBuilder()
        {
            JsObjectBuilder pagingBuilder = new JsObjectBuilder();
            pagingBuilder.AddProperty("pageSize", PageSize);
            pagingBuilder.AddProperty("pageIndex", PageIndex);
            pagingBuilder.AddProperty("recordCount", RecordCount);
            pagingBuilder.AddProperty("pageCount", PageCount);

            int startRowIndex, endRowIndex;
            ResolveStartEndRowIndex(out startRowIndex, out endRowIndex);
            pagingBuilder.AddProperty("x_startRowIndex", startRowIndex);
            pagingBuilder.AddProperty("x_endRowIndex", endRowIndex);


            return pagingBuilder;
        }



        #region old code

        //private JsObjectBuilder GetPagingBuilder()
        //{
        //    JsObjectBuilder pagingBuilder = new JsObjectBuilder();
        //    pagingBuilder.AddProperty("pageSize", PageSize);
        //    pagingBuilder.AddProperty("pageIndex", PageIndex);
        //    pagingBuilder.AddProperty("recordCount", RecordCount);
        //    pagingBuilder.AddProperty("pageCount", PageCount);

        //    int[] startEndRowIndex = GetStartEndRowIndex();
        //    pagingBuilder.AddProperty("x_startRowIndex", startEndRowIndex[0]);
        //    pagingBuilder.AddProperty("x_endRowIndex", startEndRowIndex[1]);


        //    return pagingBuilder;
        //}

        #region old code
        //private string GetSortIconScript()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    // 清空排序图标
        //    sb.AppendFormat("Ext.get('{0}').select('.x-grid3-hd-row .x-grid3-hd').removeClass(['sort-asc','sort-desc']);", ClientID);

        //    if (CurrentSortColumnIndex != -1 && CurrentSortColumnIndex >= 0 && CurrentSortColumnIndex < Columns.Count)
        //    {
        //        GridColumn currentSortColumn = Columns[CurrentSortColumnIndex];
        //        string direction = currentSortColumn.SortDirection.ToString().ToLower();

        //        // 设置需要排序的列
        //        sb.AppendFormat("Ext.get('{0}').select('.x-grid3-hd-row .x-grid3-td-{1}').addClass('sort-{2}');", ClientID, currentSortColumn.ColumnID, direction);
        //    }

        //    return sb.ToString();
        //} 
        #endregion

        #endregion

        #endregion

        #region GetAutoExpandColumnID

        private string GetAutoExpandColumnID()
        {
            string result = String.Empty;

            int columnIndex = 0;
            foreach (GridColumn column in AllColumns)
            {
                if (column.ExpandUnusedSpace)
                {
                    result = column.ColumnID;
                    break;
                }

                columnIndex++;
            }

            return result;
        }

        #endregion

        #region GetGridColumnScript

        private string GetGridColumnScript()
        {
            string selectModelID = Render_SelectModelID;
            string gridColumnID = Render_GridColumnModelID;
            // columns
            JsArrayBuilder columnsBuilder = new JsArrayBuilder();

            //string expanderScript = String.Empty;
            //if (!String.IsNullOrEmpty(RowExpander.DataFormatString))
            //{
            //    string tplStr = String.Format(RowExpander.DataFormatString.Replace("{", "{{{").Replace("}", "}}}"), RowExpander.DataFields);
            //    expanderScript = String.Format("var {0}=new Ext.ux.grid.RowExpander({{tpl:new Ext.Template({1})}});", Render_GridRowExpanderID, JsHelper.Enquote(tplStr));
            //    columnsBuilder.AddProperty(Render_GridRowExpanderID, true);
            //}

            // 如果启用行序号，则放在第一列
            if (EnableRowNumber)
            {
                columnsBuilder.AddProperty("new Ext.grid.RowNumberer()", true);
            }
            // 如果启用CheckBox，则放在第二列
            if (EnableCheckBoxSelect)
            {
                columnsBuilder.AddProperty(selectModelID, true);
            }

            string groupColumnScript = GetGroupColumnScript();

            string expanderScript = String.Empty;
            int columnIndex = 0;
            foreach (GridColumn column in AllColumns)
            {
                if (column is TemplateField && (column as TemplateField).RenderAsRowExpander)
                {
                    //string tplStr = String.Format(RowExpander.DataFormatString.Replace("{", "{{{").Replace("}", "}}}"), RowExpander.DataFields);
                    //expanderScript = String.Format("var {0}=new Ext.ux.grid.RowExpander({{tpl:new Ext.Template({1})}});", Render_GridRowExpanderID, JsHelper.Enquote(tplStr));
                    expanderScript = String.Format("var {0}=new Ext.ux.grid.RowExpander({{tpl:new Ext.Template(\"{{{1}}}\")}});", Render_GridRowExpanderID, Render_GridRowExpanderID);

                    columnsBuilder.AddProperty(Render_GridRowExpanderID, true);

                }
                else
                {
                    JsObjectBuilder columnBuilder = new JsObjectBuilder();
                    columnBuilder.AddProperty("header", String.IsNullOrEmpty(column.HeaderText) ? "&nbsp;" : column.HeaderText);
                    if (column.Hidden)
                    {
                        columnBuilder.AddProperty("hidden", true);
                    }

                    if (AllowSorting)
                    {
                        if (!String.IsNullOrEmpty(column.SortField))
                        {
                            //// 自定义JavaScript变量
                            columnBuilder.AddProperty("x_serverSortable", true);
                            //columnBuilder.AddProperty("sortable", true);
                        }
                    }

                    if (column.PersistState)
                    {
                        columnBuilder.AddProperty("x_persistState", true);
                        columnBuilder.AddProperty("x_persistStateType", "checkbox");
                    }

                    #region old code

                    // The following config will be in defaults
                    //columnBuilder.AddProperty(OptionName.Sortable, false);
                    //columnBuilder.AddProperty("menuDisabled", true);
                    //columnBuilder.AddProperty("hideable", false);

                    //// 如果启用服务器端排序，则禁用客户端排序
                    //if (EnableServerSort)
                    //{
                    //    columnBuilder.AddProperty(OptionName.Sortable, false);
                    //}
                    //else if (EnableClientSort)
                    //{
                    //    columnBuilder.AddProperty(OptionName.Sortable, true);
                    //}
                    //else
                    //{
                    //    columnBuilder.AddProperty(OptionName.Sortable, false);
                    //}
                    //    // 客户端排序，如果没有定义SortField，则不启用服务器端排序
                    //    if (!String.IsNullOrEmpty(column.SortField))
                    //    {
                    //        columnBuilder.AddProperty(OptionName.Sortable, true);
                    //    }
                    //    else
                    //    {
                    //        columnBuilder.AddProperty(OptionName.Sortable, false);
                    //    }
                    //}
                    //if (!String.IsNullOrEmpty(column.SortField))
                    //{
                    //    columnBuilder.AddProperty(OptionName.Sortable, true);
                    //}
                    //else
                    //{
                    //    columnBuilder.AddProperty(OptionName.Sortable, false);
                    //}

                    #endregion

                    ////If not specified, the column's index is used as an index into the Record's data Array.
                    //columnBuilder.AddProperty(OptionName.DataIndex, field.DataField);
                    columnBuilder.AddProperty("dataIndex", column.ColumnID);
                    columnBuilder.AddProperty("id", column.ColumnID);

                    if (column.TextAlign != TextAlign.Left)
                    {
                        columnBuilder.AddProperty("align", TextAlignName.GetName(column.TextAlign));
                    }

                    if (column.Width != Unit.Empty)
                    {
                        columnBuilder.AddProperty("width", column.Width.Value);
                    }

                    columnsBuilder.AddProperty(columnBuilder);
                }

                columnIndex++;
            }

            // 为Grid添加plugin属性
            JsArrayBuilder pluginBuilder = new JsArrayBuilder();

            if (!String.IsNullOrEmpty(expanderScript))
            {
                pluginBuilder.AddProperty(Render_GridRowExpanderID, true);
            }

            if (!String.IsNullOrEmpty(groupColumnScript))
            {
                pluginBuilder.AddProperty(Render_GridGroupColumnID, true);
            }

            if (pluginBuilder.Count > 0)
            {
                OB.AddProperty("plugins", pluginBuilder.ToString(), true);
            }



            JsObjectBuilder defaultsBuilder = new JsObjectBuilder();
            // 这是Extjs默认的客户端排序
            //defaultsBuilder.AddProperty("sortable", false);
            //defaultsBuilder.AddProperty("menuDisabled", true);
            defaultsBuilder.AddProperty("width", 100);

            string columnModelScript = String.Format("var {0}=new Ext.grid.ColumnModel({{columns:{1},defaults:{2}}});", gridColumnID, columnsBuilder, defaultsBuilder);

            return expanderScript + groupColumnScript + columnModelScript;
        }

        #endregion

        #region GetGroupColumnScript/ResolveGroupColumns

        private string GetGroupColumnScript()
        {
            if (Columns.Count > 0)
            {
                return String.Empty;
            }

            List<List<GridGroupColumn>> resolvedGroups = new List<List<GridGroupColumn>>();
            ResolveGroupColumns(GroupColumns, 0, resolvedGroups);

            JsArrayBuilder groupHeaderBuilder = new JsArrayBuilder();

            foreach (List<GridGroupColumn> groups in resolvedGroups)
            {
                JsArrayBuilder groupsBuilder = new JsArrayBuilder();
                foreach (GridGroupColumn group in groups)
                {
                    JsObjectBuilder groupBuilder = new JsObjectBuilder();
                    groupBuilder.AddProperty("header", group.HeaderText);
                    if (group.TextAlign != TextAlign.Left)
                    {
                        groupBuilder.AddProperty("align", TextAlignName.GetName(group.TextAlign));
                    }

                    int groupColumnCount = 0;
                    ResolveColumnCount(group, ref groupColumnCount);
                    groupBuilder.AddProperty("colspan", groupColumnCount);

                    groupsBuilder.AddProperty(groupBuilder);
                }

                groupHeaderBuilder.AddProperty(groupsBuilder);
            }

            return String.Format("var {0}=new Ext.ux.grid.ColumnHeaderGroup({{rows:{1}}});", Render_GridGroupColumnID, groupHeaderBuilder.ToString());

        }

        // 递归获得每个分组头中包含的列数
        private void ResolveColumnCount(GridGroupColumn group, ref int columnCount)
        {
            if (group.Columns.Count > 0)
            {
                columnCount += group.Columns.Count;
            }
            else if (group.GroupColumns.Count > 0)
            {
                foreach (GridGroupColumn subGroup in group.GroupColumns)
                {
                    ResolveColumnCount(subGroup, ref columnCount);
                }
            }
        }

        // 将表头的树状分组转换为数组形式
        private void ResolveGroupColumns(GridGroupColumnCollection groups, int level, List<List<GridGroupColumn>> resolvedGroups)
        {
            foreach (GridGroupColumn group in groups)
            {
                if (resolvedGroups.Count <= level)
                {
                    resolvedGroups.Add(new List<GridGroupColumn>());
                }
                resolvedGroups[level].Add(group);

                if (group.GroupColumns.Count > 0)
                {
                    ResolveGroupColumns(group.GroupColumns, ++level, resolvedGroups);
                    level--;
                }
            }
        } 

        #endregion

        #region GetGridSelectModel

        private string GetGridSelectModel()
        {
            JsObjectBuilder selectOB = new JsObjectBuilder();
            selectOB.AddProperty("singleSelect", !EnableMultiSelect);
            //selectOB.AddProperty("checkOnly", true);

            //selectOB.AddProperty("listeners", "{beforerowselect:function(){return false;}}", true);

            if (EnableCheckBoxSelect)
            {
                return String.Format("var {0}=new Ext.grid.CheckboxSelectionModel({1});", Render_SelectModelID, selectOB);
            }
            else
            {
                return String.Format("var {0}=new Ext.grid.RowSelectionModel({1});", Render_SelectModelID, selectOB);
            }

            #region old code
            //// 选中行，不选中行
            //JsObjectBuilder selectListenersBuilder = new JsObjectBuilder();
            //selectListenersBuilder.AddProperty("rowselect", String.Format("function(sm,rowIndex,record){{X.util.addValueToHiddenField('{0}',rowIndex);}}", SelectedRowsHiddenFieldID), true);
            //selectListenersBuilder.AddProperty("rowdeselect", String.Format("function(sm,rowIndex,record){{X.util.removeValueFromHiddenField('{0}',rowIndex);}}", SelectedRowsHiddenFieldID), true);

            //selectOptionBuilder.AddProperty("listeners", selectListenersBuilder); 
            #endregion
        }
        #endregion

        #region GetGridStore

        private string GetGridStore()
        {
            JsObjectBuilder storeBuilder = new JsObjectBuilder();

            // store - fields
            JsArrayBuilder fieldsBuidler = new JsArrayBuilder();
            foreach (GridColumn column in AllColumns)
            {
                #region old code
                //JsObjectBuilder fieldBuilder = new JsObjectBuilder();
                //fieldBuilder.AddProperty("name", column.ColumnID);
                ////fieldBuilder.AddProperty(OptionName.Mapping, columnIndex);
                ////fieldBuilder.AddProperty(OptionName.Type, column.GetFieldType());

                //fieldsBuidler.AddProperty(fieldBuilder);
                //columnIndex++; 
                #endregion
                if (column is TemplateField && (column as TemplateField).RenderAsRowExpander)
                {
                    fieldsBuidler.AddProperty(Render_GridRowExpanderID);
                }
                else
                {
                    fieldsBuidler.AddProperty(column.ColumnID);
                }
            }

            //// 如果Grid启用RowExpander，需要附加额外的数据
            //if (!String.IsNullOrEmpty(RowExpander.DataFormatString))
            //{
            //    foreach (string field in RowExpander.DataFields)
            //    {
            //        fieldsBuidler.AddProperty(field);
            //    }
            //}

            storeBuilder.AddProperty("fields", fieldsBuidler, true);

            return String.Format("var {0}=new Ext.data.ArrayStore({1});", Render_GridStoreID, storeBuilder.ToString());

            #region old code

            //storeBuilder.AddProperty("remoteSort", true);
            //storeBuilder.AddProperty("proxy", String.Format("new Ext.ux.AspNetProxy('{0}')", ClientID), true);

            //storeBuilder.AddProperty("autoLoad", "{params:{start:0,limit:" + PageSize + "}}", true);
            //storeBuilder.AddProperty("data", GetDatas());

            //if (AllowSorting)
            //{
            //    // Default sort info
            //    if (SortColumnIndex >= 0 && SortColumnIndex < Columns.Count)
            //    {
            //        JsObjectBuilder sortInfoBuilder = new JsObjectBuilder();
            //        sortInfoBuilder.AddProperty("field", Columns[SortColumnIndex].ColumnID);
            //        sortInfoBuilder.AddProperty("direction", SortDirection);

            //        storeBuilder.AddProperty("sortInfo", sortInfoBuilder);
            //    }
            //}


            //return String.Format("var {0}=new Ext.data.ArrayStore({1});", Render_GridStoreID, storeBuilder.ToString());


            //#region store - data
            ////string dataArrayString = GetDataArrayString(startEndRowIndex[0], startEndRowIndex[1]);



            //int[] startEndRowIndex = GetStartEndRowIndex();
            //// 计算完要渲染到前台的数据的条数，就要检查当前选中的项是不是有越界的
            //ResolveSelectedRowIndexArray(startEndRowIndex[1] - startEndRowIndex[0]);

            //#endregion 
            #endregion

            #region old code

            //JsArrayBuilder rowIndexBuilder = new JsArrayBuilder();

            //if (SelectedRowIndexArray != null && SelectedRowIndexArray.Length > 0)
            //{
            //    foreach (int rowIndex in SelectedRowIndexArray)
            //    {
            //        rowIndexBuilder.AddProperty(rowIndex);
            //    }
            //}
            //string selectRowScript = String.Format("{0}.selectRows({1});", Render_SelectModelID, rowIndexBuilder);
            //// 选中哪些行，这个必须要defer(100)，否则选不中，晕（10ms就不行）
            //selectRowScript = String.Format("(function(){{{0}}}).defer(100);", selectRowScript);

            //storeBuilder.AddProperty("listeners", String.Format("{{load:{0}}}", String.Format("function(){{{0}}}", selectRowScript)), true);

            #endregion

            #region old code

            // TODO
            //string selectedRowIndexArrayString = StringUtil.GetStringFromIntArray(SelectedRowIndexArray);
            //// ExtAspNetAjax回发并且Columns发生变化，需要重新
            //if (_ExtAspNetAjaxColumnsChanged)
            //{
            //    string reconfigScript = String.Empty;
            //    reconfigScript += gridStoreScript;
            //    reconfigScript += String.Format("{0}.reconfigure({1},{2});", XID, Render_GridStoreID, Render_GridColumnModelID);
            //    reconfigScript += String.Format("{0}.load();", Render_GridStoreID);
            //    // 重新加载数据后要更新input选中哪些项（因为可能选中项也会变化）
            //    reconfigScript += GetSetHiddenFieldValueScript(SelectedRowIndexArrayHiddenFieldID, selectedRowIndexArrayString);

            //    AddAjaxPropertyChangedScript(reconfigScript);
            //}
            //else
            //{
            //    bool reloadData = false;
            //    string updateSelectRowScript = selectRowScript + GetSetHiddenFieldValueScript(SelectedRowIndexArrayHiddenFieldID, selectedRowIndexArrayString);
            //    if (AjaxPropertyChanged("DataArrayString", dataArrayString))
            //    {
            //        string reloadDataScript = String.Format("{0}.loadData({1});", Render_GridStoreID, dataArrayString);
            //        // 虽然有可能“不需要修改隐藏字段的值，因为SelectedRowIndexArray其实并没有变化，只是重新加载数据（reloadData）导致选中项丢失了”
            //        // 但是我们还是修改了input的值，这没有什么影响
            //        reloadDataScript += updateSelectRowScript;

            //        AddAjaxPropertyChangedScript(reloadDataScript);

            //        reloadData = true;
            //    }

            //    // 不管SelectedRowIndexArray==null或者是不为空，都要做这一步
            //    // 在Ajax回发中，selectedRowIndexArrayString改变了，并且没有重新加载数据
            //    if (AjaxPropertyChanged("SelectedRowIndexArrayString", selectedRowIndexArrayString) && !reloadData)
            //    {
            //        AddAjaxPropertyChangedScript(updateSelectRowScript);
            //    }

            //} 
            #endregion

            #region old code

            //gridStoreScript += "\r\n";
            //if (EnableClientPaging)
            //{

            //    // 进行分页时，改变隐藏input的值，以在回发时保持状态
            //    // 同时注意：客户端分页时，清空选中的值
            //    JsObjectBuilder listenersBuilder = new JsObjectBuilder();
            //    listenersBuilder.AddProperty(OptionName.Load, String.Format("function(store,records,options){{Ext.get('{0}').dom.value=options.params.start;Ext.get('{1}').dom.value='';}}", EnableClientPagingStartRowIndexID, SelectedRowsHiddenFieldID), true);
            //    storeBuilder.AddProperty("listeners", listenersBuilder);
            //}

            // 每次都是加载全部
            //loadStoreScript = String.Format("{0}.load({1});", gridStoreId, "{params:{start:0,limit:" + (endRowIndex - startRowIndex + 1) + "}}");


            //// load store
            ////string loadStoreScript = String.Empty;
            //if (EnableClientPaging)
            //{
            //    loadStoreScript = String.Format("{0}.load({1});", gridStoreId, "{params:{start:" + EnableClientPagingStartRowIndex + ",limit:" + PageSize + "}}");
            //}
            //else
            //{
            //    loadStoreScript = String.Format("{0}.load({1});", gridStoreId, "{params:{start:0,limit:" + Rows.Count + "}}");
            //}

            //gridStoreScript += loadStoreScript; 
            #endregion
        }

        #region old code

        //private string GetDataArrayString(int startRowIndex, int endRowIndex)
        //{
        //    // store - data
        //    JsArrayBuilder dataBuidler = new JsArrayBuilder();

        //    for (int i = startRowIndex; i <= endRowIndex; i++)
        //    {
        //        // 当前行
        //        GridRow row = Rows[i];

        //        JsArrayBuilder cellBuilder = new JsArrayBuilder();
        //        foreach (object obj in row.Values)
        //        {
        //            cellBuilder.AddProperty(obj.ToString());
        //        }
        //        dataBuidler.AddProperty(cellBuilder);
        //    }

        //    // 二维数组
        //    return dataBuidler.ToString();
        //} 

        #endregion

        /// <summary>
        /// Get the start and end row index rendering in current request.
        /// </summary>
        /// <returns></returns>
        internal void ResolveStartEndRowIndex(out int startRowIndex, out int endRowIndex)
        {
            startRowIndex = 0;
            endRowIndex = Rows.Count - 1;

            if (AllowPaging)
            {
                if (IsDatabasePaging)
                {
                    // 数据库分页
                    startRowIndex = 0;
                    endRowIndex = Rows.Count - 1;
                }
                else
                {
                    // 简单的服务器端分页
                    startRowIndex = PageSize * PageIndex;
                    endRowIndex = (PageIndex + 1) * PageSize - 1;
                    endRowIndex = endRowIndex < RecordCount - 1 ? endRowIndex : RecordCount - 1;
                }
            }

            //return new int[] { startRowIndex, endRowIndex };
        }

        //private void ResolveSelectedRowIndexArray(int maxIndex)
        //{
        //    if (SelectedRowIndexArray.Length > 0)
        //    {
        //        List<int> indexList = new List<int>();

        //        foreach (int index in SelectedRowIndexArray)
        //        {
        //            if (index >= 0 && index <= maxIndex)
        //            {
        //                indexList.Add(index);
        //            }
        //        }

        //        SelectedRowIndexArray = indexList.ToArray();
        //    }
        //}

        #endregion

        #endregion

        #region RenderBeginTag/RenderEndTag

        protected override void RenderBeginTag(HtmlTextWriter writer)
        {
            base.RenderBeginTag(writer);

            writer.Write(String.Format("<div id=\"{0}_tpls\" class=\"x-grid-tpls x-hide-display\">", ClientID));
        }

        protected override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.Write("</div>");

            base.RenderEndTag(writer);
        }

        #endregion

        #region UpdateTemplateFields

        /// <summary>
        /// 当在客户端修改了模板列中的值，调用此函数来告诉表格控件需要更新这些值；
        /// 如果对表格重新进行了数据绑定，则不需要调用此函数，因为重新绑定后会更新表格的全部内容
        /// </summary>
        public void UpdateTemplateFields()
        {
            PageManager.Instance.AjaxGridClientIDs.Add(ClientID);
        }

        #endregion

        #region DataBind

        /// <summary>
        /// 绑定到数据源
        /// </summary>
        public override void DataBind()
        {
            //base.DataBind();

            if (_dataSource != null)
            {
                ClearRows();

                if (_dataSource is DataView || _dataSource is DataSet || _dataSource is DataTable)
                {
                    DataTable dataTable = null;

                    if (_dataSource is DataView)
                    {
                        dataTable = ((DataView)_dataSource).ToTable();
                    }
                    else if (_dataSource is DataSet)
                    {
                        dataTable = ((DataSet)_dataSource).Tables[0];
                    }
                    else
                    {
                        dataTable = ((DataTable)_dataSource);
                    }

                    DataBindToDataTable(dataTable);
                }
                else if (_dataSource is IEnumerable)
                {
                    DataBindToEnumerable((IEnumerable)_dataSource);
                }
                else
                {
                    throw new Exception("DataSource doesn't support data type: " + _dataSource.GetType().ToString());
                }
            }
        }


        private void DataBindToDataTable(DataTable dataTable)
        {
            BeforeDataBind();

            int rowIndex = 0, count = dataTable.DefaultView.Count;
            for (; rowIndex < count; rowIndex++)
            {
                DataBindRow(rowIndex, dataTable.DefaultView[rowIndex]);
            }

            AfterDataBind(rowIndex);
        }

        private void DataBindToEnumerable(IEnumerable list)
        {
            BeforeDataBind();

            int rowIndex = 0;
            foreach (object rowObj in list)
            {
                DataBindRow(rowIndex, rowObj);

                rowIndex++;
            }

            AfterDataBind(rowIndex);
        }

        private void DataBindRow(int rowIndex, object rowObj)
        {
            GridRow row = new GridRow(this, rowObj, rowIndex);
            Rows.Add(row);
            Controls.Add(row);
            row.InitTemplateContainers();

            OnPreRowDataBound(new GridPreRowEventArgs(rowObj, rowIndex));

            //row.DataBindRow();
            row.DataBind();

            OnRowDataBound(new GridRowEventArgs(rowObj, rowIndex, row.Values));
        }

        private void BeforeDataBind()
        {
            OnPreDataBound(EventArgs.Empty);
        }

        private void AfterDataBind(int recordCount)
        {
            if (!IsDatabasePaging)
            {
                // 如果不是数据库分页，则每次DataBind都要更新RecordCount的值
                // 数据库分页的话，RecordCount需要用户显式的赋值
                RecordCount = recordCount;
            }


            // 在所有行都绑定结束后，需要检查模拟树显示的列，并重新计算当前列的内容（在列内容前加上树分隔符）
            // 1.查找需要模拟树显示的列
            GridColumn simulateTreeColumn = null;
            foreach (GridColumn column in AllColumns)
            {
                if (!String.IsNullOrEmpty(column.DataSimulateTreeLevelField))
                {
                    simulateTreeColumn = column;
                    break;
                }
            }

            // 2.如果找到这样的列
            if (simulateTreeColumn != null)
            {
                List<SimulateTreeNode> silumateTree = new List<SimulateTreeNode>();

                // 存在需要模拟树显示的列
                for (int rowIndex = 0, rowCount = Rows.Count; rowIndex < rowCount; rowIndex++)
                {
                    GridRow row = Rows[rowIndex];
                    int level = Convert.ToInt32(row.GetPropertyValue(simulateTreeColumn.DataSimulateTreeLevelField));
                    object content = row.Values[simulateTreeColumn.ColumnIndex];

                    SimulateTreeNode node = new SimulateTreeNode();
                    node.Text = content.ToString();
                    node.Level = level;
                    node.HasLittleBrother = false;
                    node.ParentNode = null;
                    silumateTree.Add(node);
                }

                // 计算树
                SimulateTreeHeper treeHelper = new SimulateTreeHeper();
                treeHelper.ResolveSimulateTree(silumateTree, true);

                // 赋值
                for (int rowIndex = 0, rowCount = Rows.Count; rowIndex < rowCount; rowIndex++)
                {
                    Rows[rowIndex].Values[simulateTreeColumn.ColumnIndex] = silumateTree[rowIndex].Text;
                }
            }
        }


        /// <summary>
        /// 清空Rows，同时清除Controls中的GridRow控件
        /// </summary>
        private void ClearRows()
        {
            Rows.Clear();

            // 会重新创建这些控件，所以要先删除之前存在的GridRow
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i] is GridRow)
                {
                    Controls.RemoveAt(i);
                }
            }
        }

        #endregion

        #region IPostBackDataHandler Members

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public override bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            base.LoadPostData(postDataKey, postCollection);

            // How many lines are selected.
            int[] selectedRowIndexArray = StringUtil.GetIntListFromString(postCollection[SelectedRowIndexArrayHiddenFieldID]).ToArray();
            if (!StringUtil.CompareIntArray(SelectedRowIndexArray, selectedRowIndexArray))
            {
                SelectedRowIndexArray = selectedRowIndexArray;
                XState.BackupPostDataProperty("SelectedRowIndexArray");
            }


            int[] hiddenColumnIndexArray = StringUtil.GetIntListFromString(postCollection[HiddenColumnIndexArrayHiddenFieldID]).ToArray();
            if (!StringUtil.CompareIntArray(HiddenColumnIndexArray, hiddenColumnIndexArray))
            {
                HiddenColumnIndexArray = hiddenColumnIndexArray;
                XState.BackupPostDataProperty("HiddenColumnIndexArray");
            }



            // X_Rows Maybe changed in this PostBack, because row States maybe changed in client-side.
            JArray rowStates = JArray.Parse(postCollection[RowStatesHiddenFieldID]);
            int startRowIndex, endRowIndex;
            ResolveStartEndRowIndex(out startRowIndex, out endRowIndex);
            for (int i = startRowIndex; i <= endRowIndex; i++)
            {
                int index = i - startRowIndex;
                List<object> shortStates = new List<object>();
                foreach (JArray ja in rowStates)
                {
                    shortStates.Add(ja[index]);
                }
                Rows[i].FromShortStates(shortStates.ToArray());
            }
            XState.BackupPostDataProperty("X_States");


            //// 需要恢复哪一列的数据
            //if (NeedPersistStateColumnIndexArray != null && NeedPersistStateColumnIndexArray.Length > 0)
            //{
            //    foreach (int columnIndex in NeedPersistStateColumnIndexArray)
            //    {
            //        Columns[columnIndex].LoadColumnState(postCollection[GetNeedPersistStateColumnIndexID(columnIndex)]);
            //    }
            //}

            #region old code
            //// 开始行的序号
            //if (EnableClientPaging)
            //{
            //    int postStartRowIndex = Convert.ToInt32(postCollection[EnableClientPagingStartRowIndexID]);
            //    if (EnableClientPagingStartRowIndex != postStartRowIndex)
            //    {
            //        EnableClientPagingStartRowIndex = postStartRowIndex;
            //    }
            //} 
            #endregion


            return false;
        }



        //public override void RaisePostDataChangedEvent()
        //{
        //    //OnCollapsedChanged(EventArgs.Empty);
        //}

        #endregion

        #region GetHasSelectionReference GetSelectCountReference

        /// <summary>
        /// 获取表格是否有选中项的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetHasSelectionReference()
        {
            return String.Format("{0}.getSelectionModel().hasSelection()", ScriptID);
        }

        /// <summary>
        /// 获取表格选中项数的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetSelectCountReference()
        {
            return String.Format("{0}.getSelectionModel().getCount()", ScriptID);
        }

        #endregion

        #region GetNoSelectionAlertReference GetNoSelectionAlertInParentReference

        /// <summary>
        /// 获取表格没有任何选中项时在本窗口弹出提示对话框的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetNoSelectionAlertReference(string message)
        {
            return GetNoSelectionAlertReference(message, String.Empty, Alert.DefaultIcon);
        }

        /// <summary>
        /// 获取表格没有任何选中项时在本窗口弹出提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <returns>客户端脚本</returns>
        public string GetNoSelectionAlertReference(string message, string title)
        {
            return GetNoSelectionAlertReference(message, title, Alert.DefaultIcon);
        }

        /// <summary>
        /// 获取表格没有任何选中项时在本窗口弹出提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <returns>客户端脚本</returns>
        public string GetNoSelectionAlertReference(string message, string title, MessageBoxIcon icon)
        {
            return String.Format("if(!{0}){{{1}return false;}}", GetHasSelectionReference(), Alert.GetShowReference(message, title, icon));
        }


        /// <summary>
        /// 获取表格没有任何选中项时在父级窗口弹出提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <returns>客户端脚本</returns>
        public string GetNoSelectionAlertInParentReference(string message)
        {
            return GetNoSelectionAlertInParentReference(message, String.Empty, Alert.DefaultIcon);
        }

        /// <summary>
        /// 获取表格没有任何选中项时在父级窗口弹出提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <returns>客户端脚本</returns>
        public string GetNoSelectionAlertInParentReference(string message, string title)
        {
            return GetNoSelectionAlertInParentReference(message, title, Alert.DefaultIcon);
        }

        /// <summary>
        /// 获取表格没有任何选中项时在父级窗口弹出提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <returns>客户端脚本</returns>
        public string GetNoSelectionAlertInParentReference(string message, string title, MessageBoxIcon icon)
        {
            return String.Format("if(!{0}){{{1}return false;}}", GetHasSelectionReference(), Alert.GetShowInParentReference(message, title, icon));
        }

        /// <summary>
        /// 获取表格没有任何选中项时在顶级窗口弹出提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <returns>客户端脚本</returns>
        public string GetNoSelectionAlertInTopReference(string message)
        {
            return GetNoSelectionAlertInTopReference(message, String.Empty, Alert.DefaultIcon);
        }

        /// <summary>
        /// 获取表格没有任何选中项时在顶级窗口弹出提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <returns>客户端脚本</returns>
        public string GetNoSelectionAlertInTopReference(string message, string title)
        {
            return GetNoSelectionAlertInTopReference(message, title, Alert.DefaultIcon);
        }

        /// <summary>
        /// 获取表格没有任何选中项时在顶级窗口弹出提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <returns>客户端脚本</returns>
        public string GetNoSelectionAlertInTopReference(string message, string title, MessageBoxIcon icon)
        {
            return String.Format("if(!{0}){{{1}return false;}}", GetHasSelectionReference(), Alert.GetShowInTopReference(message, title, icon));
        }
        #endregion

        #region FindColumn

        /// <summary>
        /// 通过列ID获取列实例
        /// </summary>
        /// <param name="columnId">列ID</param>
        /// <returns>列实例</returns>
        public GridColumn FindColumn(string columnID)
        {
            foreach (GridColumn column in AllColumns)
            {
                if (column.ColumnID == columnID)
                {
                    return column;
                }
            }

            return null;
        }

        #endregion

        #region IPostBackEventHandler

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public void RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument.StartsWith("Sort$"))
            {
                #region Sort

                string[] sortArgs = eventArgument.Split('$');
                if (sortArgs.Length == 2)
                {
                    #region old code
                    //// 格式为 "Sort$c0__Name"
                    //string sortStr = sortArgs[1].Substring(1);
                    //// 所在的列
                    //int sortColumnIndex = Convert.ToInt32(sortStr.Substring(0, sortStr.IndexOf("__")));
                    //string sortField = sortStr.Substring(sortStr.IndexOf("__") + 2);
                    //// 当前排序
                    //Columns[sortColumnIndex].SortDirection = Columns[sortColumnIndex].SortDirection == "ASC" ? "DESC" : "ASC";

                    //OnSort(new GridSortEventArgs(sortField, Columns[sortColumnIndex].SortDirection));  
                    #endregion

                    // 格式为 "Sort$2"，其中columnIndex = 2，这个是把前面的RowNumber，CheckBox列也算上去的，应该减掉
                    // 所在的列
                    int columnIndex = Convert.ToInt32(sortArgs[1]);
                    columnIndex -= GetPrefixColumnNumber();

                    // 当前列的排序字段和排序方向
                    string sortField = AllColumns[columnIndex].SortField;

                    // Sort column index not changed in current postback.
                    if (columnIndex == SortColumnIndex)
                    {
                        SortDirection = SortDirection == "ASC" ? "DESC" : "ASC";
                    }
                    else
                    {
                        SortColumnIndex = columnIndex;
                        SortDirection = "ASC";
                    }

                    // 服务器端排序后，清空选中的状态
                    SelectedRowIndexArray = null;

                    OnSort(new GridSortEventArgs(sortField, SortDirection, SortColumnIndex));
                }

                #endregion
            }
            else if (eventArgument.StartsWith("Command$"))
            {
                string[] commandArgs = eventArgument.Split('$');
                if (commandArgs.Length == 5)
                {
                    OnRowCommand(new GridCommandEventArgs(Convert.ToInt32(commandArgs[1]), Convert.ToInt32(commandArgs[2]), commandArgs[3], commandArgs[4]));
                }
            }
            else if (eventArgument.StartsWith("Page$"))
            {
                string[] commandArgs = eventArgument.Split('$');
                if (commandArgs.Length == 2)
                {
                    OnPageIndexChange(new GridPageEventArgs(Convert.ToInt32(commandArgs[1])));

                    // 分页后清空选中的值
                    SelectedRowIndexArray = null;
                }
            }
            else if (eventArgument.StartsWith("RowClick$"))
            {
                string[] commandArgs = eventArgument.Split('$');
                if (commandArgs.Length == 2)
                {
                    OnRowClick(new GridRowClickEventArgs(Convert.ToInt32(commandArgs[1])));
                }
            }
            else if (eventArgument.StartsWith("RowDoubleClick$"))
            {
                string[] commandArgs = eventArgument.Split('$');
                if (commandArgs.Length == 2)
                {
                    OnRowDoubleClick(new GridRowClickEventArgs(Convert.ToInt32(commandArgs[1])));
                }
            }
        }

        /// <summary>
        /// 获取Columns前面的列（比如索引列，选择框列）
        /// </summary>
        /// <returns></returns>
        private int GetPrefixColumnNumber()
        {
            int prefix = 0;
            if (EnableRowNumber)
            {
                prefix++;
            }
            if (EnableCheckBoxSelect)
            {
                prefix++;
            }
            return prefix;
        }

        #endregion

        #region OnSort

        private static readonly object _sortHandlerKey = new object();

        /// <summary>
        /// 排序事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("排序事件")]
        public event EventHandler<GridSortEventArgs> Sort
        {
            add
            {
                Events.AddHandler(_sortHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_sortHandlerKey, value);
            }
        }

        protected virtual void OnSort(GridSortEventArgs e)
        {
            EventHandler<GridSortEventArgs> handler = Events[_sortHandlerKey] as EventHandler<GridSortEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnPreDataBound

        private static readonly object _preDataBoundHandlerKey = new object();

        /// <summary>
        /// 行绑定前事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("绑定前事件")]
        public event EventHandler<EventArgs> PreDataBound
        {
            add
            {
                Events.AddHandler(_preDataBoundHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_preDataBoundHandlerKey, value);
            }
        }


        protected virtual void OnPreDataBound(EventArgs e)
        {
            EventHandler<EventArgs> handler = Events[_preDataBoundHandlerKey] as EventHandler<EventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnPreRowDataBound

        private static readonly object _preRowDataBoundHandlerKey = new object();

        /// <summary>
        /// 行绑定前事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("行绑定前事件")]
        public event EventHandler<GridPreRowEventArgs> PreRowDataBound
        {
            add
            {
                Events.AddHandler(_preRowDataBoundHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_preRowDataBoundHandlerKey, value);
            }
        }


        protected virtual void OnPreRowDataBound(GridPreRowEventArgs e)
        {
            EventHandler<GridPreRowEventArgs> handler = Events[_preRowDataBoundHandlerKey] as EventHandler<GridPreRowEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnRowDataBound

        private static readonly object _rowDataBoundHandlerKey = new object();

        /// <summary>
        /// 行绑定后事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("行绑定后事件")]
        public event EventHandler<GridRowEventArgs> RowDataBound
        {
            add
            {
                Events.AddHandler(_rowDataBoundHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_rowDataBoundHandlerKey, value);
            }
        }


        protected virtual void OnRowDataBound(GridRowEventArgs e)
        {
            EventHandler<GridRowEventArgs> handler = Events[_rowDataBoundHandlerKey] as EventHandler<GridRowEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnRowCommand

        private static readonly object _rowCommandHandlerKey = new object();

        /// <summary>
        /// 行内事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("行内事件")]
        public event EventHandler<GridCommandEventArgs> RowCommand
        {
            add
            {
                Events.AddHandler(_rowCommandHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_rowCommandHandlerKey, value);
            }
        }

        protected virtual void OnRowCommand(GridCommandEventArgs e)
        {
            EventHandler<GridCommandEventArgs> handler = Events[_rowCommandHandlerKey] as EventHandler<GridCommandEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnPageIndexChange

        private static readonly object _pageIndexChangeHandlerKey = new object();

        /// <summary>
        /// 分页跳转事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("分页跳转事件")]
        public event EventHandler<GridPageEventArgs> PageIndexChange
        {
            add
            {
                Events.AddHandler(_pageIndexChangeHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_pageIndexChangeHandlerKey, value);
            }
        }

        protected virtual void OnPageIndexChange(GridPageEventArgs e)
        {
            EventHandler<GridPageEventArgs> handler = Events[_pageIndexChangeHandlerKey] as EventHandler<GridPageEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnRowClick

        private static readonly object _rowClickHandlerKey = new object();

        /// <summary>
        /// 行点击事件（需要启用EnableRowClick）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("行点击事件（需要启用EnableRowClick）")]
        public event EventHandler<GridRowClickEventArgs> RowClick
        {
            add
            {
                Events.AddHandler(_rowClickHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_rowClickHandlerKey, value);
            }
        }

        protected virtual void OnRowClick(GridRowClickEventArgs e)
        {
            EventHandler<GridRowClickEventArgs> handler = Events[_rowClickHandlerKey] as EventHandler<GridRowClickEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region OnRowDoubleClick

        private static readonly object _rowDoubleClickHandlerKey = new object();

        /// <summary>
        /// 行点击事件（需要启用EnableRowDoubleClick）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("行点击事件（需要启用EnableRowDoubleClick）")]
        public event EventHandler<GridRowClickEventArgs> RowDoubleClick
        {
            add
            {
                Events.AddHandler(_rowDoubleClickHandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_rowDoubleClickHandlerKey, value);
            }
        }

        protected virtual void OnRowDoubleClick(GridRowClickEventArgs e)
        {
            EventHandler<GridRowClickEventArgs> handler = Events[_rowDoubleClickHandlerKey] as EventHandler<GridRowClickEventArgs>;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region old code

        //protected override void OnPreLoad(object sender, EventArgs e)
        //{
        //    base.OnPreLoad(sender, e);

        //    SaveAjaxProperty("GridColumnScript", GetGridColumnScript());
        //    if (AllowSorting)
        //    {
        //        SaveAjaxProperty("SortIconScript", GetSortIconScript());
        //    }

        //    if (AllowPaging)
        //    {
        //        JsObjectBuilder pagingBuilder;
        //        SaveAjaxProperty("TempPagingString", GetTempPagingString(out pagingBuilder));
        //    }

        //    int startRowIndex;
        //    int endRowIndex;
        //    SaveAjaxProperty("DataArrayString", GetDataArrayString(out startRowIndex, out endRowIndex));

        //    SelectedRowIndexArray = ResolveSelectedRowIndexArray(SelectedRowIndexArray, endRowIndex - startRowIndex);
        //    SaveAjaxProperty("SelectedRowIndexArrayString", StringUtil.GetStringFromIntArray(SelectedRowIndexArray));

        //}

        #endregion

        #region old code

        //protected override object SaveViewState()
        //{
        //    object[] states = new object[] { base.SaveViewState(), 
        //        ((IStateManager)Columns).SaveViewState(), 
        //        ((IStateManager)Rows).SaveViewState(),
        //        //((IStateManager)Toolbar).SaveViewState()
        //    };

        //    return states;
        //}

        //protected override void LoadViewState(object savedState)
        //{
        //    if (savedState != null)
        //    {
        //        object[] states = (object[])savedState;

        //        base.LoadViewState(states[0]);

        //        ((IStateManager)Columns).LoadViewState(states[1]);

        //        ((IStateManager)Rows).LoadViewState(states[2]);

        //        //((IStateManager)Toolbar).LoadViewState(states[3]);
        //    }
        //}

        //protected override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    ((IStateManager)Columns).TrackViewState();

        //    ((IStateManager)Rows).TrackViewState();

        //    //((IStateManager)Toolbar).TrackViewState();
        //}

        #endregion

        #region old code

        //public override void RenderBeginTag(HtmlTextWriter writer)
        //{
        //    base.RenderBeginTag(writer);

        //    //// 当前选中的哪些行的数据
        //    //writer.Write(String.Format("<input type=\"hidden\" value=\"{1}\" id=\"{0}\" name=\"{0}\"/>",
        //    //    SelectedRowsHiddenFieldID, GetSelectedRowIndexArrayHTML()));

        //    ////// 如果启用客户端排序，需要在回发时记录当前所在的第几页
        //    ////if (EnableClientPaging)
        //    ////{
        //    ////    writer.Write(String.Format("<input type=\"hidden\" value=\"{1}\" id=\"{0}\" name=\"{0}\"/>",
        //    ////        EnableClientPagingStartRowIndexID, EnableClientPagingStartRowIndex));
        //    ////}

        //    //// 有这些列需要保存状态
        //    //if (NeedPersistStateColumnIndexArray != null && NeedPersistStateColumnIndexArray.Length > 0)
        //    //{
        //    //    foreach (int columnIndex in NeedPersistStateColumnIndexArray)
        //    //    {
        //    //        writer.Write(String.Format("<input type=\"hidden\" value=\"{1}\" id=\"{0}\" name=\"{0}\"/>",
        //    //            GetNeedPersistStateColumnIndexID(columnIndex), Columns[columnIndex].SaveColumnState()));
        //    //    }
        //    //}
        //}



        //public override void RenderEndTag(HtmlTextWriter writer)
        //{
        //    base.RenderEndTag(writer);
        //}

        #endregion
    }
}
