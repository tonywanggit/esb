
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    GridCommandEventArgs.cs
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
    /// 表格行命令事件参数
    /// </summary>
    public class GridCommandEventArgs : EventArgs
    {

        private int _rowIndex;

        /// <summary>
        /// 行索引
        /// </summary>
        public int RowIndex
        {
            get { return _rowIndex; }
            set { _rowIndex = value; }
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


        private string _commandName;

        /// <summary>
        /// 命令名称
        /// </summary>
        public string CommandName
        {
            get { return _commandName; }
            set { _commandName = value; }
        }


        private string _commandArgument;

        /// <summary>
        /// 命令参数
        /// </summary>
        public string CommandArgument
        {
            get { return _commandArgument; }
            set { _commandArgument = value; }
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="rowIndex">行索引</param>
        /// <param name="columnIndex">列索引</param>
        /// <param name="commandName">命令名称</param>
        /// <param name="commandArgument">命令参数</param>
        public GridCommandEventArgs(int rowIndex, int columnIndex, string commandName, string commandArgument)
        {
            _rowIndex = rowIndex;
            _columnIndex = columnIndex;
            _commandName = commandName;
            _commandArgument = commandArgument;
        }

    }
}



