
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    GridRowEventArgs.cs
 * CreatedOn:   2008-06-23
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


namespace ExtAspNet
{
    /// <summary>
    /// 表格行绑定事件参数
    /// </summary>
    public class GridRowEventArgs : EventArgs
    {

        private object[] _values;

        /// <summary>
        /// 本行各列的值（渲染后的HTML片段）
        /// </summary>
        public object[] Values
        {
            get { return _values; }
            set { _values = value; }
        }


        private object _dataItem;

        /// <summary>
        /// 行数据源
        /// </summary>
        public object DataItem
        {
            get { return _dataItem; }
            set { _dataItem = value; }
        }


        private int _rowIndex;

        /// <summary>
        /// 行索引
        /// </summary>
        public int RowIndex
        {
            get { return _rowIndex; }
            set { _rowIndex = value; }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataItem">行数据源</param>
        /// <param name="rowIndex">行索引</param>
        /// <param name="values">本行各列的值</param>
        public GridRowEventArgs(object dataItem, int rowIndex, object[] values)
        {
            _dataItem = dataItem;
            _values = values;
            _rowIndex = rowIndex;
        }

    }
}



