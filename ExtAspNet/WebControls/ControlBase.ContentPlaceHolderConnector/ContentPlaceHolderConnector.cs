
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    ContentPlaceHolderConnector.cs
 * CreatedOn:   2008-07-03
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
using System.Web.UI;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI.WebControls;

namespace ExtAspNet
{
    [Designer(typeof(ContentPlaceHolderConnectorDesigner))]
    [ToolboxData("<{0}:ContentPlaceHolderConnector runat=\"server\"></{0}:ContentPlaceHolderConnector>")]
    [ToolboxBitmap(typeof(ContentPlaceHolderConnector), "resources.toolbox_icons.ContentPlaceHolderConnector.bmp")]
    [Description("ContentPlaceHolder的容器")]
    [ParseChildren(false)]
    [PersistChildren(true)]
    internal class ContentPlaceHolderConnector : ControlBase
    {
        #region OnPreRender

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            // 不渲染，此控件只作为中间转化层
            RenderHtmlToPage = false;
            AddStartupScript(this, String.Empty);

            // 目前只处理第一个子控件，其他的舍弃
            ContentPlaceHolder userControl = GetFirstChildUserControl(Controls);
            if (userControl != null)
            {
                #region First UserControl

                // 用户控件里面的都不要即时渲染
                foreach (Control c in userControl.Controls)
                {
                    ControlBase childControl = c as ControlBase;
                    if (childControl != null)
                    {
                        childControl.RenderHtmlToPage = false;
                    }
                }

                if (!IsExtAspNetAjaxPostBack)
                {
                    // 重新设置父节点的注册脚本
                    ControlBase parentControl = Parent as ControlBase;
                    if (parentControl != null)
                    {
                        ScriptBlock cs = ResourceManagerInstance.GetStartupScript(parentControl);
                        cs.Script = GetResolveScript(cs.Script, GetControlIds(userControl.Controls));
                    }
                }

                #endregion
            }


        }

        #region GetFirstChildUserControl

        /// <summary>
        /// 取得第一个子控件
        /// </summary>
        /// <param name="controls"></param>
        /// <returns></returns>
        private ContentPlaceHolder GetFirstChildUserControl(ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is ContentPlaceHolder)
                {
                    return (c as ContentPlaceHolder);
                }
            }

            return null;
        }

        #endregion

        #region GetControlIds

        protected string GetControlIds(ControlCollection controls)
        {
            StringBuilder sb = new StringBuilder();
            if (controls.Count > 0)
            {
                foreach (Control item in controls)
                {
                    // 再次检查是否ControlBase，并且只有Visible时才添加
                    // 还有一个例外情况，Window控件不作为任何控件的子控件，Window的RenderImmediately一定为true
                    if (item is ControlBase && item.Visible && !(item is Window) && !(item is Toolbar))
                    {
                        string itemJSId = String.Format("box.{0}", (item as ControlBase).ClientJavascriptID);
                        sb.AppendFormat("{0},", itemJSId);
                    }
                }
            }

            return sb.ToString().TrimEnd(',');
        }

        #endregion

        #region GetResolveScript

        private string GetResolveScript(string script, string ids)
        {
            int itemsStartIndex = script.IndexOf("items:[");
            if (itemsStartIndex >= 0)
            {
                itemsStartIndex += 6;
                int itemsEndIndex = script.IndexOf("]", itemsStartIndex);
                string itemsStr = script.Substring(itemsStartIndex, itemsEndIndex - itemsStartIndex + 1);

                StringBuilder sb = new StringBuilder();
                string currentId = String.Format("box.{0}", ClientJavascriptID);
                Nii.JSON.JSONArray ja = new Nii.JSON.JSONArray(itemsStr);
                for (int i = 0; i < ja.Count; i++)
                {
                    string item = ja.getString(i);
                    if (item == currentId)
                    {
                        sb.AppendFormat("{0},", ids);
                    }
                    else
                    {
                        sb.AppendFormat("{0},", item);
                    }
                }

                string newItemsStr = String.Format("[{0}]", sb.ToString().TrimEnd(','));

                return script.Replace(itemsStr, newItemsStr);
            }

            return script;
        }

        #endregion

        #endregion
    }
}
