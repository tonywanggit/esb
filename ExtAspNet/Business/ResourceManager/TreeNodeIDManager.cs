
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    TreeNodeIDManager.cs
 * CreatedOn:   2012-08-13
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
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Reflection;
using System.Collections;

namespace ExtAspNet
{
    /// <summary>
    /// 存在 Page.Items 上下文中，用于生成JavascriptID
    /// </summary>
    internal class TreeNodeIDManager
    {
        #region static fields
        public static readonly string CONTEXT_NAME = "TreeNodeIDManagerContextName";

        #endregion

        #region Instance

        public static TreeNodeIDManager Instance
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    TreeNodeIDManager manager = HttpContext.Current.Items[CONTEXT_NAME] as TreeNodeIDManager;
                    if (manager == null)
                    {
                        manager = new TreeNodeIDManager();
                        HttpContext.Current.Items[CONTEXT_NAME] = manager;
                    }
                    return manager;
                }
                return null;
            }
        }

        #endregion

        #region methods

        private int _num = 0;

        public string GetNextTreeNodeID()
        {
            return String.Format("xnode{0}", _num++);
        }

        #endregion
    }
}
