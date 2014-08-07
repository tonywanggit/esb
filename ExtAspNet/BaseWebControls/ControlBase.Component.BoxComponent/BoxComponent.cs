
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    Component.cs
 * CreatedOn:   2008-04-14
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


namespace ExtAspNet
{
    /// <summary>
    /// 控件基类（抽象类）
    /// </summary>
    public abstract class BoxComponent : Component
    {
        #region Constructor

        public BoxComponent()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties();

        }

        #endregion

        #region Properties

        /// <summary>
        /// 宽度
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(Unit), "")]
        [Description("宽度")]
        public Unit Width
        {
            get
            {
                object obj = XState["Width"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                XState["Width"] = value;
            }
        }


        /// <summary>
        /// 高度
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(Unit), "")]
        [Description("高度")]
        public Unit Height
        {
            get
            {
                object obj = XState["Height"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                XState["Height"] = value;
            }
        }


        #endregion

        #region Layout Properties

        /// <summary>
        /// 锚点值
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue("")]
        [Description("锚点值")]
        public string AnchorValue
        {
            get
            {
                object obj = XState["AnchorValue"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["AnchorValue"] = value;
            }
        }


        /// <summary>
        /// 列的宽度
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue("")]
        [Description("列的宽度")]
        public string ColumnWidth
        {
            get
            {
                object obj = XState["ColumnWidth"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["ColumnWidth"] = value;
            }
        }


        /// <summary>
        /// 行的宽度
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue("")]
        [Description("行的宽度")]
        public string RowHeight
        {
            get
            {
                object obj = XState["RowHeight"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["RowHeight"] = value;
            }
        }


        /// <summary>
        /// AbsoluteX
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(Unit), "")]
        [Description("X")]
        public Unit AbsoluteX
        {
            get
            {
                object obj = XState["AbsoluteX"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                XState["AbsoluteX"] = value;
            }
        }


        /// <summary>
        /// AbsoluteY
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(Unit), "")]
        [Description("Y")]
        public Unit AbsoluteY
        {
            get
            {
                object obj = XState["AbsoluteY"];
                return obj == null ? Unit.Empty : (Unit)obj;
            }
            set
            {
                XState["AbsoluteY"] = value;
            }
        }


        /// <summary>
        /// 表格列数
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(3)]
        [Description("表格列数")]
        public int TableConfigColumns
        {
            get
            {
                object obj = XState["TableConfigColumns"];
                return obj == null ? 3 : (int)obj;
            }
            set
            {
                XState["TableConfigColumns"] = value;
            }
        }

        /// <summary>
        /// 表格合并行
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(1)]
        [Description("表格合并行")]
        public int TableRowspan
        {
            get
            {
                object obj = XState["TableRowspan"];
                return obj == null ? 1 : (int)obj;
            }
            set
            {
                XState["TableRowspan"] = value;
            }
        }

        /// <summary>
        /// 表格合并列
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(1)]
        [Description("表格合并列")]
        public int TableColspan
        {
            get
            {
                object obj = XState["TableColspan"];
                return obj == null ? 1 : (int)obj;
            }
            set
            {
                XState["TableColspan"] = value;
            }
        }

        /// <summary>
        /// 位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(BoxLayoutAlign.Start)]
        [Description("位置")]
        public BoxLayoutAlign BoxConfigAlign
        {
            get
            {
                object obj = XState["BoxConfigAlign"];
                return obj == null ? BoxLayoutAlign.Start : (BoxLayoutAlign)obj;
            }
            set
            {
                XState["BoxConfigAlign"] = value;
            }
        }

        /// <summary>
        /// 位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(BoxLayoutPosition.Start)]
        [Description("位置")]
        public BoxLayoutPosition BoxConfigPosition
        {
            get
            {
                object obj = XState["BoxConfigPosition"];
                return obj == null ? BoxLayoutPosition.Start : (BoxLayoutPosition)obj;
            }
            set
            {
                XState["BoxConfigPosition"] = value;
            }
        }

        /// <summary>
        /// Padding
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue("0")]
        [Description("Padding")]
        public string BoxConfigPadding
        {
            get
            {
                object obj = XState["BoxConfigPadding"];
                return obj == null ? "0" : (string)obj;
            }
            set
            {
                XState["BoxConfigPadding"] = value;
            }
        }

        /// <summary>
        /// 子控件之间的Margin
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue("0")]
        [Description("子控件之间的Margin")]
        public string BoxConfigChildMargin
        {
            get
            {
                object obj = XState["BoxConfigChildMargin"];
                return obj == null ? "0" : (string)obj;
            }
            set
            {
                XState["BoxConfigChildMargin"] = value;
            }
        }

        /// <summary>
        /// Flex
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(0)]
        [Description("Flex")]
        public int BoxFlex
        {
            get
            {
                object obj = XState["BoxFlex"];
                return obj == null ? 0 : (int)obj;
            }
            set
            {
                XState["BoxFlex"] = value;
            }
        }


        /// <summary>
        /// Margin
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue("")]
        [Description("Margin")]
        public string BoxMargin
        {
            get
            {
                object obj = XState["BoxMargin"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["BoxMargin"] = value;
            }
        }

        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();
            
            
            if (Width != Unit.Empty)
            {
                OB.AddProperty("width", Width.Value);
            }
            if (Height != Unit.Empty)
            {
                OB.AddProperty("height", Height.Value);
            }


            #region Controls in Layout

            Container parentControl = null;

            // 此面板放在用户控件中的情况
            if (Parent is UserControl)
            {
                if (Parent.Parent is UserControlConnector)
                {
                    parentControl = Parent.Parent.Parent as Container;
                }
            }
            else
            {
                parentControl = Parent as Container;
            }


            if (parentControl != null)
            {
                if (parentControl.Layout == Layout.Anchor)
                {
                    // 如果父节点是Anchor布局
                    if (!String.IsNullOrEmpty(AnchorValue))
                    {
                        OB.AddProperty("anchor", AnchorValue);
                    }
                }
                else if (parentControl.Layout == Layout.Column)
                {
                    if (!String.IsNullOrEmpty(ColumnWidth))
                    {
                        string columnWidth = StringUtil.ConvertPercentageToDecimalString(ColumnWidth);

                        // 1.00 在IE下会有BUG，把1.00转换为0.999
                        if (columnWidth == "1.00")
                        {
                            columnWidth = "0.999";
                        }
                        OB.AddProperty("columnWidth", columnWidth, true);
                    }
                }
                else if (parentControl.Layout == Layout.Absolute)
                {
                    if (AbsoluteX != Unit.Empty)
                    {
                        OB.AddProperty("x", AbsoluteX.Value);
                    }
                    if (AbsoluteY != Unit.Empty)
                    {
                        OB.AddProperty("y", AbsoluteY.Value);
                    }
                }
                else if (parentControl.Layout == Layout.Row)
                {
                    if (!String.IsNullOrEmpty(RowHeight))
                    {
                        string rowHeight = StringUtil.ConvertPercentageToDecimalString(RowHeight);

                        // 1.00 在IE下会有BUG，把1.00转换为0.999
                        if (rowHeight == "1.00")
                        {
                            rowHeight = "0.999";
                        }
                        OB.AddProperty("rowHeight", rowHeight, true);
                    }
                }
                else if (parentControl.Layout == Layout.Table)
                {
                    if (TableRowspan != 1)
                    {
                        OB.AddProperty("rowspan", TableRowspan);
                    }

                    if (TableColspan != 1)
                    {
                        OB.AddProperty("colspan", TableColspan);
                    }
                }
                else if (parentControl.Layout == Layout.HBox || parentControl.Layout == Layout.VBox)
                {
                    if (BoxFlex != 0)
                    {
                        OB.AddProperty("flex", BoxFlex);
                    }

                    // 用户可能会设置 BoxMargin="0" 来覆盖 BoxConfigChildMargin 属性。
                    if (BoxMargin != "")
                    {
                        OB.AddProperty("margins", BoxMargin);
                    }

                }
            }

            #endregion

        }

        #endregion

    }
}
