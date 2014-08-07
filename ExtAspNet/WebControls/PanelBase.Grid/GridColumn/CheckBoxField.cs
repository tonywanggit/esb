
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    CheckBoxField.cs
 * CreatedOn:   2008-05-27
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
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Text;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Globalization;
using System.Reflection;
using System.Collections.Generic;


namespace ExtAspNet
{
    /// <summary>
    /// 表格复选框列
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class CheckBoxField : GridColumn
    {

        #region Properties

        private bool _enabled = true;

        /// <summary>
        /// 是否可用（只在RenderAsStaticField=false时有效）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否可用（只在RenderAsStaticField=false时有效）")]
        public virtual bool Enabled
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

        private bool _autoPostBack = false;

        /// <summary>
        /// 是否自动回发
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否自动回发")]
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


        public string _dataField = "";

        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("字段名称")]
        public string DataField
        {
            get
            {
                return _dataField;
            }
            set
            {
                _dataField = value;
            }
        }


        public bool _renderAsStaticField = true;

        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("渲染为静态内容")]
        public bool RenderAsStaticField
        {
            get
            {
                return _renderAsStaticField;
            }
            set
            {
                _renderAsStaticField = value;
            }
        }

        #endregion

        #region CommandName

        private string _commandName = "";

        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("")]
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

        private string _commandArgument = "";

        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("")]
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

        #region Methods

        internal override string GetColumnValue(GridRow row)
        {
            string result = String.Empty;

            bool checkState = Convert.ToBoolean(GetColumnState(row));

            result = GetColumnValue(row, checkState);

            string tooltip = GetTooltipString(row);
            if (!String.IsNullOrEmpty(tooltip))
            {
                result = result.ToString().Insert("<div".Length, tooltip);
            }

            return result;
        }

        /// <summary>
        /// 取得单元格的数据
        /// </summary>
        /// <param name="row"></param>
        /// <param name="checkState"></param>
        /// <returns></returns>
        private string GetColumnValue(GridRow row, bool checkState)
        {
            string result = String.Empty;

            if (!String.IsNullOrEmpty(DataField))
            {
                string textAlignClass = String.Empty;
                if (TextAlign != TextAlign.Left)
                {
                    textAlignClass = "box-grid-checkbox-" + TextAlignName.GetName(TextAlign);
                }

                if (RenderAsStaticField)
                {
                    if (checkState)
                    {
                        result = "<div class=\"box-grid-static-checkbox " + textAlignClass + "\"></div>";
                    }
                    else
                    {
                        result = "<div class=\"box-grid-static-checkbox box-grid-static-checkbox-unchecked " + textAlignClass + "\"></div>";
                    }
                }
                else
                {
                    string paramStr = String.Format("Command${0}${1}${2}${3}", row.RowIndex, ColumnIndex, CommandName.Replace("'", "\""), CommandArgument.Replace("'", "\""));
                    // 延迟执行
                    string postBackReference = JsHelper.GetDeferScript(Grid.GetPostBackEventReference(paramStr), 0);

                    // string onClickScript = String.Format("{0}_checkbox{1}(event,this,{2});", Grid.XID, ColumnIndex, row.RowIndex);
                    string onClickScript = "Ext.get(this).toggleClass('box-grid-checkbox-unchecked');";
                    if (AutoPostBack)
                    {
                        onClickScript += postBackReference;
                    }

                    onClickScript += "X.util.stopEventPropagation.apply(null, arguments);";

                    if (checkState)
                    {
                        if (Enabled)
                        {
                            result = String.Format("<div class=\"box-grid-checkbox {0}\" onclick=\"{1}\"></div>", textAlignClass, onClickScript);
                        }
                        else
                        {
                            result = String.Format("<div class=\"box-grid-checkbox box-grid-checkbox-disabled {0}\"></div>", textAlignClass);
                        }
                    }
                    else
                    {
                        if (Enabled)
                        {
                            result = String.Format("<div class=\"box-grid-checkbox box-grid-checkbox-unchecked {0}\" onclick=\"{1}\"></div>", textAlignClass, onClickScript);
                        }
                        else
                        {
                            result = String.Format("<div class=\"box-grid-checkbox box-grid-checkbox-disabled box-grid-checkbox-unchecked-disabled {0}\"></div>", textAlignClass);
                        }
                    }
                }
            }

            return result;
        }


        //public override string GetFieldType()
        //{
        //    return "string";
        //}

        #endregion

        #region SaveColumnState/LoadColumnState

        internal override bool PersistState
        {
            get
            {
                if (RenderAsStaticField)
                {
                    return false;
                }
                return true;
            }
        }

        internal override object GetColumnState(GridRow row)
        {
            if (row.DataItem == null)
            {
                return row.States[ColumnIndex];
            }
            else
            {
                return row.GetPropertyValue(DataField);
            }
        }

       

        ///// <summary>
        ///// 将列状态保存到字符串
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <returns></returns>
        //public override string SaveColumnState()
        //{
        //    //StringBuilder sb = new StringBuilder();

        //    //int columnIndex = GetColumnIndex(grid);

        //    List<int> rowIndexList = new List<int>();

        //    int rowIndex = 0;
        //    foreach (GridRow row in Grid.Rows)
        //    {
        //        bool check = Convert.ToBoolean(row.ExtraValues[ColumnIndex]);

        //        if (check)
        //        {
        //            //sb.AppendFormat("{0},", rowIndex);
        //            rowIndexList.Add(rowIndex);
        //        }

        //        rowIndex++;
        //    }

        //    return StringUtil.GetStringFromIntArray(rowIndexList.ToArray());
        //    //return sb.ToString();
        //}


        ///// <summary>
        ///// 从字符串加载列的状态
        ///// </summary>
        ///// <param name="grid"></param>
        ///// <param name="state"></param>
        ///// <returns></returns>
        //public override void LoadColumnState(string state)
        //{
        //    // 此列选中的行列表
        //    int[] checkedArray = StringUtil.GetIntListFromString(state).ToArray();
        //    List<int> checkedList = new List<int>(checkedArray);

        //    // 当前哪一列
        //    //int columnIndex = GetColumnIndex(grid);

        //    int startRowIndex, endRowIndex;
        //    Grid.ResolveStartEndRowIndex(out startRowIndex, out endRowIndex);

        //    for (int i = startRowIndex; i <= endRowIndex; i++)
        //    {
        //        GridRow row = Grid.Rows[i];

        //        if (checkedList.Contains(i))
        //        {
        //            row.ExtraValues[ColumnIndex] = true;
        //            row.Values[ColumnIndex] = GetColumnValue(row, true);
        //        }
        //        else
        //        {
        //            row.ExtraValues[ColumnIndex] = false;
        //            row.Values[ColumnIndex] = GetColumnValue(row, false);
        //        }
        //    }
        //}

        #endregion


        /// <summary>
        /// 当前行的这个复选框是否处于选中状态
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public bool GetCheckedState(int rowIndex)
        {
            GridRow row = this.Grid.Rows[rowIndex];

            return Convert.ToBoolean(row.States[ColumnIndex]);
        }

        public void SetCheckedState(int rowIndex, bool isChecked)
        {
            GridRow row = this.Grid.Rows[rowIndex];

            row.States[ColumnIndex] = isChecked;
        }

        #region old code

        ///// <summary>
        ///// 维持页面上CheckBox的值
        ///// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public List<bool> Checked
        //{
        //    get
        //    {
        //        object obj = ViewState["Checked"];
        //        return obj == null ? (new List<bool>()) : (List<bool>)obj;
        //    }
        //    set
        //    {
        //        ViewState["Checked"] = value;
        //    }
        //}

        #endregion
    }
}



