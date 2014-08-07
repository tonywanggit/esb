
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    SimulateTreeNode.cs
 * CreatedOn:   2008-06-26
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
    /// 模拟树结构的节点类
    /// </summary>
    internal class SimulateTreeNode
    {
        private string _simulateTreeText;

        /// <summary>
        /// 模拟树的节点内容
        /// </summary>
        public string SimulateTreeText
        {
            get { return _simulateTreeText; }
            set { _simulateTreeText = value; }
        }


        private string _text;

        /// <summary>
        /// 节点内容
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        private string _value;

        /// <summary>
        /// 节点内容
        /// </summary>
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private int _level;

        /// <summary>
        /// 节点所在层次（从0开始，0表示根节点）
        /// </summary>
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        private SimulateTreeNode _parentNode;

        /// <summary>
        /// 父节点
        /// </summary>
        public SimulateTreeNode ParentNode
        {
            get { return _parentNode; }
            set { _parentNode = value; }
        }

        private bool _hasLittleBrother;

        /// <summary>
        /// 是否有弟节点
        /// </summary>
        public bool HasLittleBrother
        {
            get { return _hasLittleBrother; }
            set { _hasLittleBrother = value; }
        }


        private bool _enableSelect;

        public bool EnableSelect
        {
            get { return _enableSelect; }
            set { _enableSelect = value; }
        }
    }
}
