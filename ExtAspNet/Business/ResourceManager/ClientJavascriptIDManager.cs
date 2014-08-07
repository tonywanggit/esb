
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    ClientJavascriptIDManager.cs
 * CreatedOn:   2008-08-01
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
    internal class ClientJavascriptIDManager
    {
        #region static fields
        public static readonly string CONTEXT_NAME = "ClientJavascriptIDManagerContextName";

        #endregion

        #region Instance

        public static ClientJavascriptIDManager Instance
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    ClientJavascriptIDManager manager = HttpContext.Current.Items[CONTEXT_NAME] as ClientJavascriptIDManager;
                    if (manager == null)
                    {
                        manager = new ClientJavascriptIDManager();
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

        public string GetNextJavascriptID()
        {
            return String.Format("x{0}", _num++);
        }

        #endregion
    }
}
