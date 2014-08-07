
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    TreeNodeCollection.cs
 * CreatedOn:   2008-07-21
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
using System.Data;
using System.Collections.ObjectModel;
using System.Web.UI;


namespace ExtAspNet
{
    /// <summary>
    /// 树节点控件集合，继承自Collection<TreeNode>
    /// </summary>
    public class TreeNodeCollection : Collection<TreeNode>
    {
        private Tree _treeInstance;
        private TreeNode _parentNode;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tree">树实例</param>
        /// <param name="parentNode">父节点</param>
        public TreeNodeCollection(Tree tree, TreeNode parentNode)
        {
            _treeInstance = tree;
            _parentNode = parentNode;
        }


        // 注释1:
        // 考虑这样的情况：
        // TreeNodeCollection nodes = new TreeNodeCollection();
        // TreeNode node = new TreeNode();
        // 注意此时node并没有关于tree1的任何信息，之后在后面调用tree1.Nodes.Add时才知道当前的树实例
        // nodes.Add(node);
        // tree1.Nodes.Add(nodes);

        // 注释2:
        // 对于下面的树的节点定义（在ASPX中定义的）
        //    -China
	    //          -Zhumadian
		//              -Suiping
		//              -Xiping
        // 注意 InsertItem 第一次调用是在添加Suiping这个节点时进行的，
        // 也就是说在添加Suiping时，并不知道当前的树实例，而只有在添加China到tree1.Nodes时才知道树实例
        // 所以需要在 _treeInstance 不为空时，也即是添加根节点时递归所有的子节点，设置树实例
        protected override void InsertItem(int index, TreeNode item)
        {
            if (_treeInstance != null)
            {
                ResolveTreeNode(item);
            }

            item.ParentNode = _parentNode;

            base.InsertItem(index, item);
        }


        /// <summary>
        /// 设置每个节点的Tree实例
        /// </summary>
        /// <param name="node"></param>
        private void ResolveTreeNode(TreeNode node)
        {
            node.TreeInstance = _treeInstance;
            if (node.Nodes.Count > 0)
            {
                foreach (TreeNode subNode in node.Nodes)
                {
                    ResolveTreeNode(subNode);
                }
            }
        }

    }

}



