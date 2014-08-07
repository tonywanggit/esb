
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    GridSortEventArgs.cs
 * CreatedOn:   2008-05-28
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
using System.Text;

namespace ExtAspNet
{
    /// <summary>
    /// 表格排序事件参数
    /// </summary>
    public class GridSortEventArgs : EventArgs
    {
        private string _sortField;

        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortField
        {
            get { return _sortField; }
            set { _sortField = value; }
        }


        private string _sortDirection;

        /// <summary>
        /// 排序方向
        /// </summary>
        public string SortDirection
        {
            get { return _sortDirection; }
            set { _sortDirection = value; }
        }

        private int _columnIndex;

        /// <summary>
        /// 列索引
        /// </summary>
        public int ColumnIndex
        {
            get { return _columnIndex; }
            set { _columnIndex = value; }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sortField">排序字段</param>
        /// <param name="sortDirection">排序方向</param>
        /// <param name="columnIndex">列索引</param>
        public GridSortEventArgs(string sortField, string sortDirection, int columnIndex)
        {
            _sortField = sortField;
            _sortDirection = sortDirection;
            _columnIndex = columnIndex;
        }

    }
}
