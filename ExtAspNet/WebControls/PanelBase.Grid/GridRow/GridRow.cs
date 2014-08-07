#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    GridRow.cs
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
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Web.UI;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

using Newtonsoft.Json.Linq;

namespace ExtAspNet
{
    // 去除 GridRow 的 INamingContainer，即不参与层次命名，从而减少ClientID的长度
    [ToolboxItem(false)]
    public class GridRow : WebControl
    {
        #region Constructor

        public GridRow()
        {

        }

        public GridRow(Grid grid, object dataItem, int rowIndex)
        {
            _grid = grid;
            _dataItem = dataItem;
            _rowIndex = rowIndex;
        }

        #endregion

        #region Grid/DataItem/RowIndex

        private Grid _grid;

        public Grid Grid
        {
            get
            {
                return _grid;
            }
        }

        private object _dataItem = null;

        /// <summary>
        /// 本行对应的数据源（不维护状态）
        /// </summary>
        public object DataItem
        {
            get { return _dataItem; }
            set { _dataItem = value; }
        }


        private int _rowIndex = 0;

        /// <summary>
        /// 第几行
        /// </summary>
        public int RowIndex
        {
            get
            {
                return _rowIndex;
            }
            set
            {
                _rowIndex = value;
            }
        }


        #endregion

        #region Properties

        private string[] _values = null;

        /// <summary>
        /// 此行的状态信息
        /// </summary>
        public string[] Values
        {
            get
            {
                return _values;
            }
            set
            {
                _values = value;
            }
        }

        private object[] _dataKeys = null;

        /// <summary>
        /// 此行DataKeyNames字段的值
        /// </summary>
        public object[] DataKeys
        {
            get
            {
                return _dataKeys;
            }
            set
            {
                _dataKeys = value;
            }
        }

        private object[] _states = null;
        public object[] States
        {
            get
            {
                return _states;
            }
            set
            {
                _states = value;
            }
        }

        //private object[] _extraValues = null;
        ///// <summary>
        ///// 附加要保存的值（比如CheckBoxField需要保存是否选中的状态）
        ///// </summary>
        //internal object[] ExtraValues
        //{
        //    get
        //    {
        //        return _extraValues;
        //    }
        //    set
        //    {
        //        _extraValues = value;
        //    }
        //}

        #endregion

        #region ToShortStates/FromShortStates

        internal object[] ToShortStates()
        {
            List<object> shortStates = new List<object>();
            GridColumnCollection columns = _grid.AllColumns;
            for (int i = 0, count = columns.Count; i < count; i++)
            {
                if (columns[i].PersistState)
                {
                    shortStates.Add(States[i]);
                }
            }
            return shortStates.ToArray();
        }

        internal void FromShortStates(object[] shortStates)
        {
            GridColumnCollection columns = _grid.AllColumns;
            States = new object[columns.Count];
            int shortStateIndex = 0;
            for (int i = 0, count = columns.Count; i < count; i++)
            {
                GridColumn column = columns[i];
                if (column.PersistState)
                {
                    object state = shortStates[shortStateIndex++];
                    //Values[i] = column.GetColumnValue(this);
                    if (state is JValue)
                    {
                        States[i] = (state as JValue).Value;
                    }
                    else
                    {
                        States[i] = state;
                    }
                }
            }
        }
        #endregion

        #region TemplateContainers

        private GridRowControl[] _templateContainers = null;
        public GridRowControl[] TemplateContainers
        {
            get
            {
                return _templateContainers;
            }
            set
            {
                _templateContainers = value;
            }
        }

        public void InitTemplateContainers()
        {
            GridColumnCollection columns = _grid.AllColumns;
            TemplateContainers = new GridRowControl[columns.Count];

            for (int i = 0, count = columns.Count; i < count; i++)
            {
                GridColumn column = columns[i];
                if (column is TemplateField)
                {
                    TemplateField field = column as TemplateField;
                    GridRowControl control = new GridRowControl(DataItem, RowIndex);
                    //control.ID = String.Format("{0}_{1}_{2}", Grid.ID, RowIndex, column.ColumnIndex);
                    control.ID = String.Format("c{0}r{1}", column.ColumnIndex, RowIndex);

                    field.ItemTemplate.InstantiateIn(control);

                    Controls.Add(control);
                    TemplateContainers[column.ColumnIndex] = control;

                }

            }
        }

        #endregion

        #region DataBindRow

        /// <summary>
        /// 绑定子控件
        /// </summary>
        protected override void DataBindChildren()
        {
            base.DataBindChildren();

            DataBindRow();
        }

        /// <summary>
        /// 绑定行的值
        /// </summary>
        internal void DataBindRow()
        {
            GridColumnCollection columns = _grid.AllColumns;

            //int columnsCount = columns.Count;
            //// 如果Grid启用RowExpander，需要附加额外的数据
            //if (!String.IsNullOrEmpty(Grid.RowExpander.DataFormatString))
            //{
            //    columnsCount += Grid.RowExpander.DataFields.Length;
            //}

            // 计算每列的值
            Values = new string[columns.Count];
            //ExtraValues = new object[columns.Count];
            States = new object[columns.Count];
            int i = 0;
            for (int count = columns.Count; i < count; i++)
            {
                GridColumn column = columns[i];
                Values[i] = StrimColumnValue(column.GetColumnValue(this));

                if (column.PersistState)
                {
                    States[i] = column.GetColumnState(this);
                }
            }
            //// 如果Grid启用RowExpander，需要附加额外的数据
            //if (!String.IsNullOrEmpty(Grid.RowExpander.DataFormatString))
            //{
            //    foreach (string field in Grid.RowExpander.DataFields)
            //    {
            //        Values[i++] = GetPropertyValue(field).ToString();
            //    }
            //}


            // 计算DataKeys的值
            if (_grid.DataKeyNames != null)
            {
                string[] keyNames = _grid.DataKeyNames;
                DataKeys = new object[keyNames.Length];
                for (int j = 0, count = keyNames.Length; j < count; j++)
                {
                    DataKeys[j] = GetPropertyValue(keyNames[j]);
                }
            }
        }

        public object GetPropertyValue(string propertyName)
        {
            return ObjectUtil.GetPropertyValue(DataItem, propertyName);
        }

        #endregion

        #region StrimColumnValue

        private string StrimColumnValue(string columnValue)
        {
            // 删除生成HTML中的 "\r\n     "
            return Regex.Replace(columnValue, "\r\n\\s*", "");
        }

        #endregion

        #region RenderBeginTag

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            //base.RenderBeginTag(writer);

            //writer.Write("<div id=\"ok\">");
        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {
            //base.RenderEndTag(writer);

            //writer.Write("</div>");
        }

        #endregion

        #region FindControl

        public override Control FindControl(string id)
        {
            foreach (GridRowControl control in TemplateContainers)
            {
                if (control != null)
                {
                    Control found = control.FindControl(id);
                    if (found != null)
                    {
                        return found;
                    }
                }
            }

            return null;
        }

        #endregion

        #region old code

        ///// <summary>
        ///// 取得属性的值
        ///// </summary>
        ///// <param name="rowObj"></param>
        ///// <param name="propertyName"></param>
        ///// <returns></returns>
        //public object GetPropertyValue(string propertyName)
        //{
        //    object rowObj = _dataItem;
        //    object result = null;

        //    try
        //    {
        //        if (rowObj is DataRow)
        //        {
        //            result = (rowObj as DataRow)[propertyName];
        //        }
        //        else
        //        {
        //            result = ObjectUtil.GetPropertyValueFormObject(rowObj, propertyName);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        // 找不到此属性
        //    }

        //    return result;
        //}




        #endregion

        #region old code

        ///// <summary>
        ///// Returns a value from the item indexed by the field name or index.
        ///// </summary>
        ///// <param name="obj">Field name or numeric index.</param>
        ///// <returns>Cell value</returns>
        //public object this[object obj]
        //{
        //    get
        //    {
        //        if (obj is string)
        //        {
        //            if (_columns != null && _values != null)
        //            {
        //                int iColumnIndex = _columns.IndexOf((string)obj);
        //                if (iColumnIndex >= 0)
        //                {
        //                    return _values[iColumnIndex];
        //                }
        //                else
        //                {
        //                    return null;
        //                }
        //            }
        //            else
        //            {
        //                return null;
        //            }
        //        }
        //        else if (obj is int)
        //        {
        //            return _values[(int)obj];
        //        }
        //        else
        //        {
        //            throw new ArgumentException("Only a string (field name) or integer index is permitted.");
        //        }
        //    }
        //    set
        //    {
        //        if (obj is string)
        //        {
        //            if (_columns != null && _values != null)
        //            {
        //                _values[_columns.IndexOf((string)obj)] = value;
        //            }
        //        }
        //        else if (obj is int)
        //        {
        //            _values[(int)obj] = value;
        //        }
        //        else
        //        {
        //            throw new ArgumentException("Only a string (column name) or int parameter are permitted.");
        //        }
        //    }
        //}



        ///// <summary>
        ///// Returns whether this item equals the passed-in item.
        ///// </summary>
        ///// <param name="o">A GridItem.</param>
        ///// <returns>Whether this item equals the passed-in item.</returns>
        //public override bool Equals(object o)
        //{
        //    if (o is GridItem && o != null)
        //    {
        //        GridItem other = (GridItem)o;

        //        for (int i = 0; i < _values.Length; i++)
        //        {
        //            if (!Object.Equals(this[i], other[i]))
        //            {
        //                return false;
        //            }
        //        }

        //        return true;
        //    }

        //    return false;
        //} 

        #endregion

    }
}



