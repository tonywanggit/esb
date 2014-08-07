

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
    /// Used by Grid and Tree.
    /// </summary>
    internal class SimulateTreeHeper
    {
        // "|-"
        private static string X_ELBOW = "<div class=\"x-elbow\"></div>";
        // "|_"
        private static string X_ELBOW_END = "<div class=\"x-elbow-end\"></div>";
        // "| "
        private static string X_ELBOW_LINE = "<div class=\"x-elbow-line\"></div>";
        // " "
        private static string X_ELBOW_EMPTY = "<div class=\"x-elbow-empty\"></div>";

        /// <summary>
        /// Calculate tree.
        /// </summary>
        /// <param name="silumateTreeNodes"></param>
        /// <param name="postfixOriginalContent"></param>
        public void ResolveSimulateTree(List<SimulateTreeNode> silumateTreeNodes, bool modifiyOriginalContent)
        {
            int rowIndex = 0;
            foreach (SimulateTreeNode node in silumateTreeNodes)
            {
                node.ParentNode = GetParentNode(silumateTreeNodes, rowIndex);
                node.HasLittleBrother = GetHasLittleBrother(silumateTreeNodes, rowIndex);

                rowIndex++;
            }

            foreach (SimulateTreeNode node in silumateTreeNodes)
            {
                string treePrefix = GetNodeContentLevelPrefix(node);
                if (modifiyOriginalContent)
                {
                    node.Text = treePrefix + node.Text;
                }
                node.SimulateTreeText = treePrefix;
            }
        }

        private string GetNodeContentLevelPrefix(SimulateTreeNode node)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = node.Level; i > 0; i--)
            {
                sb.Append(GetNodeContentLevelPrefix(node, i));
            }

            return sb.ToString();
        }

        

        private string GetNodeContentLevelPrefix(SimulateTreeNode node, int level)
        {
            #region Rules

            //level = 0, 
            //level = 1,    有弟节点  |-
            //              没弟节点  |_
            //level = 2,    父有弟节点  |   有弟节点  |-
            //              父没弟节点      没弟节点  |_    
            //level = 3,    父的父有弟节点  |   父有弟节点  |   有弟节点  |-
            //              父的父没弟节点      父没弟节点      没弟节点  |_   

            #endregion

            if (level == 1)
            {
                if (node.HasLittleBrother)
                {
                    return X_ELBOW;
                }
                else
                {
                    return X_ELBOW_END;
                }
            }
            else if (level == 2)
            {
                if (node.ParentNode.HasLittleBrother)
                {
                    return X_ELBOW_LINE;
                }
                else
                {
                    return X_ELBOW_EMPTY;
                }
            }
            else if (level == 3)
            {
                if (node.ParentNode.ParentNode.HasLittleBrother)
                {
                    return X_ELBOW_LINE;
                }
                else
                {
                    return X_ELBOW_EMPTY;
                }
            }
            else if (level == 4)
            {
                if (node.ParentNode.ParentNode.ParentNode.HasLittleBrother)
                {
                    return X_ELBOW_LINE;
                }
                else
                {
                    return X_ELBOW_EMPTY;
                }
            }
            else if (level == 5)
            {
                if (node.ParentNode.ParentNode.ParentNode.ParentNode.HasLittleBrother)
                {
                    return X_ELBOW_LINE;
                }
                else
                {
                    return X_ELBOW_EMPTY;
                }
            }
            else if (level == 6)
            {
                if (node.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.HasLittleBrother)
                {
                    return X_ELBOW_LINE;
                }
                else
                {
                    return X_ELBOW_EMPTY;
                }
            }

            // We support 6 levels at the most.
            return "  ";
        }

        private SimulateTreeNode GetParentNode(List<SimulateTreeNode> silumateTree, int rowIndex)
        {
            SimulateTreeNode currentNode = silumateTree[rowIndex];
            if (currentNode.Level == 0)
            {
                return null;
            }
            else
            {
                for (int i = rowIndex - 1; i >= 0; i--)
                {
                    SimulateTreeNode node = silumateTree[i];
                    if (node.Level == currentNode.Level - 1)
                    {
                        return node;
                    }
                }
            }

            return null;
        }

        private bool GetHasLittleBrother(List<SimulateTreeNode> silumateTree, int rowIndex)
        {
            SimulateTreeNode currentNode = silumateTree[rowIndex];
            if (rowIndex == silumateTree.Count - 1)
            {
                // 树的最后一个节点，当然没有弟节点
                return false;
            }
            else
            {
                //SilumateTreeNode nextNode = silumateTree[rowIndex + 1];
                //if (nextNode.Level != currentNode.Level)
                //{
                //    return false;
                //}
                //else
                //{
                //    return true;
                //}
                for (int i = rowIndex + 1; i < silumateTree.Count; i++)
                {
                    SimulateTreeNode node = silumateTree[i];
                    if (node.Level == currentNode.Level)
                    {
                        return true;
                    }
                    else if (node.Level < currentNode.Level)
                    {
                        return false;
                    }
                }
            }

            return false;
        }


        #region old code
        //private string X_ELBOW
        //{
        //    get
        //    {
        //        //return String.Format("<img src=\"{0}\" style=\"vertical-align:text-bottom;\" alt=\"elbow\">", ResourceHelper.GetWebResourceUrl("ExtAspNet.res.X.images.elbow.gif"));
        //        return "<div class=\"x-elbow\"></div>";
        //    }
        //}
        //private string X_ELBOW_END
        //{
        //    get
        //    {
        //        //return String.Format("<img src=\"{0}\" style=\"vertical-align:text-bottom;\" alt=\"elbow-end\">", ResourceHelper.GetWebResourceUrl("ExtAspNet.res.X.images.elbow-end.gif"));
        //        return "<div class=\"x-elbow-end\"></div>";
        //    }
        //}
        //private string X_ELBOW_LINE
        //{
        //    get
        //    {
        //        //return String.Format("<img src=\"{0}\" style=\"vertical-align:text-bottom;\" alt=\"elbow-line\">", ResourceHelper.GetWebResourceUrl("ExtAspNet.res.X.images.elbow-line.gif"));
        //        return "<div class=\"x-elbow-line\"></div>";
        //    }
        //}
        //private string X_ELBOW_EMPTY
        //{
        //    get
        //    {
        //        //return String.Format("<img src=\"{0}\" style=\"vertical-align:text-bottom;\" alt=\"elbow-empty\">", ResourceHelper.GetWebResourceUrl("ExtAspNet.res.X.images.elbow-empty.gif"));
        //        return "<div class=\"x-elbow-empty\"></div>";
        //    }
        //}
        
        #endregion

    }
}
