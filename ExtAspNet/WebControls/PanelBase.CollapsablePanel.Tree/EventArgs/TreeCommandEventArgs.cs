
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    TreeCommandEventArgs.cs
 * CreatedOn:   2008-07-22
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
    /// 树节点命令事件参数
    /// </summary>
    public class TreeCommandEventArgs : EventArgs
    {
        private TreeNode _node;

        /// <summary>
        /// 树实例
        /// </summary>
        public TreeNode Node
        {
            get { return _node; }
            set { _node = value; }
        }

        private string _nodeID;

        /// <summary>
        /// 树节点ID
        /// </summary>
        public string NodeID
        {
            get { return _nodeID; }
            set { _nodeID = value; }
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
        /// <param name="node">树节点</param>
        /// <param name="commandName">命令名称</param>
        /// <param name="commandArgument">命令参数</param>
        public TreeCommandEventArgs(TreeNode node, string commandName, string commandArgument)
        {
            _node = node;
            _nodeID = node.NodeID;
            _commandName = commandName;
            _commandArgument = commandArgument;
        }

    }
}



