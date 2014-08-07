
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    GridPreRowEventArgs.cs
 * CreatedOn:   2008-06-27
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
    /// 表格行预绑定事件参数
    /// </summary>
    public class GridPreRowEventArgs : EventArgs
    {

        private object _dataItem;

        /// <summary>
        /// 行数据源（如果数据源为DataTable，则DataItem为DataRowView）
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
        public GridPreRowEventArgs(object dataItem, int rowIndex)
        {
            _dataItem = dataItem;
            _rowIndex = rowIndex;
        }

    }
}



