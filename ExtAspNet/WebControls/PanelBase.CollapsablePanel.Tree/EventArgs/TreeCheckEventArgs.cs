
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    TreeCheckEventArgs.cs
 * CreatedOn:   2008-09-14
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
    /// 树节点选中事件参数
    /// </summary>
    public class TreeCheckEventArgs : EventArgs
    {
        private TreeNode _node;

        /// <summary>
        /// 树节点
        /// </summary>
        public TreeNode Node
        {
            get { return _node; }
            set { _node = value; }
        }


        private string _nodeID;

        /// <summary>
        /// 节点ID
        /// </summary>
        public string NodeID
        {
            get { return _nodeID; }
            set { _nodeID = value; }
        }

        private bool _checked;

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Checked
        {
            get { return _checked; }
            set { _checked = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="node">树节点</param>
        /// <param name="isChecked">是否选中</param>
        public TreeCheckEventArgs(TreeNode node, bool isChecked)
        {
            _node = node;
            _nodeID = node.NodeID;
            _checked = isChecked;
        }

    }
}



