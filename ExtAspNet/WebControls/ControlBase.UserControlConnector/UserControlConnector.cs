
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    UserControlConnector.cs
 * CreatedOn:   2008-07-02
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
    /// <summary>
    /// 用户控件的容器
    /// </summary>
    [Designer(typeof(UserControlConnectorDesigner))]
    [ToolboxData("<{0}:UserControlConnector runat=\"server\"></{0}:UserControlConnector>")]
    [ToolboxBitmap(typeof(UserControlConnector), "res.toolbox.UserControlConnector.bmp")]
    [Description("用户控件的容器")]
    [ParseChildren(false)]
    [PersistChildren(true)]
    public class UserControlConnector : ControlBase
    {
        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            //if (PropertyModified("Text"))
            //{
            //    sb.AppendFormat("{0}.setValue({1});", XID, JsHelper.Enquote(Text));
            //}

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            // 不渲染，此控件只作为中间转化层
            RenderWrapperNode = false;
            AddStartupScript(String.Empty);

            // 一个UserControlConnector里面可能放多个UserControl，
            // 每个UserControl中的所有直接子节点都不要即时渲染
            StringBuilder sb = new StringBuilder();
            foreach (Control userControl in Controls)
            {
                if (userControl is UserControl)
                {
                    // 用户控件中的ExtAspNet控件（x1,x4,x6）
                    sb.AppendFormat("{0},", GetControlIds(userControl.Controls));

                    // 用户控件里面的都不要即时渲染
                    foreach (Control c in userControl.Controls)
                    {
                        ControlBase childControl = c as ControlBase;
                        if (childControl != null)
                        {
                            childControl.RenderWrapperNode = false;
                        }
                    }
                }
            }

            // 重新设置父节点的注册脚本
            ControlBase parentControl = Parent as ControlBase;
            if (parentControl != null)
            {
                ScriptBlock cs = ResourceManager.Instance.GetStartupScript(parentControl);
                cs.Script = GetResolveScript(cs.Script, sb.ToString().TrimEnd(','));
            }


            //// 目前只处理第一个子控件，其他的舍弃
            //UserControl userControl = GetFirstChildUserControl(Controls);
            //if (userControl != null)
            //{
            //    // 用户控件里面的都不要即时渲染
            //    foreach (Control c in userControl.Controls)
            //    {
            //        ControlBase childControl = c as ControlBase;
            //        if (childControl != null)
            //        {
            //            childControl.RenderWrapperNode = false;
            //        }
            //    }


            //    // 重新设置父节点的注册脚本
            //    ControlBase parentControl = Parent as ControlBase;
            //    if (parentControl != null)
            //    {
            //        ScriptBlock cs = ResourceManager.Instance.GetStartupScript(parentControl);
            //        cs.Script = GetResolveScript(cs.Script, GetControlIds(userControl.Controls));
            //    }
            //}

        }

        #endregion

        #region private GetFirstChildUserControl

        /// <summary>
        /// 取得第一个子控件
        /// </summary>
        /// <param name="controls"></param>
        /// <returns></returns>
        private UserControl GetFirstChildUserControl(ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is UserControl)
                {
                    return (c as UserControl);
                }
            }

            return null;
        }

        #endregion

        #region private GetControlIds

        private string GetControlIds(ControlCollection controls)
        {
            StringBuilder sb = new StringBuilder();
            if (controls.Count > 0)
            {
                foreach (Control item in controls)
                {
                    // 再次检查是否ControlBase，并且只有Visible时才添加
                    // 还有一个例外情况，Window控件不作为任何控件的子控件
                    if (item is ControlBase && item.Visible && !(item is Window) && !(item is Toolbar))
                    {
                        string itemJSId = String.Format("{0}", (item as ControlBase).XID);
                        sb.AppendFormat("{0},", itemJSId);
                    }
                }
            }

            return sb.ToString().TrimEnd(',');
        }

        #endregion

        #region private GetResolveScript

        private string GetResolveScript(string script, string ids)
        {
            int itemsStartIndex = script.IndexOf("items:[");
            if (itemsStartIndex >= 0)
            {
                itemsStartIndex += "items:[".Length;
                int itemsEndIndex = script.IndexOf("]", itemsStartIndex);
                string itemsStr = script.Substring(itemsStartIndex, itemsEndIndex - itemsStartIndex);

                // 防止itemsStr出现类似：x1,x2,x13,x20的情况
                string newItemStr = itemsStr + ",";
                newItemStr = newItemStr.Replace(XID + ",", ids + ",");
                newItemStr = newItemStr.TrimEnd(',');

                return script.Substring(0, itemsStartIndex) + newItemStr + script.Substring(itemsEndIndex);

                //StringBuilder sb = new StringBuilder();
                //string currentId = String.Format("box.{0}", ClientJavascriptID);
                //Nii.JSON.JSONArray ja = new Nii.JSON.JSONArray(itemsStr);
                //for (int i = 0; i < ja.Count; i++)
                //{
                //    string item = ja.getString(i);
                //    if (item == currentId)
                //    {
                //        sb.AppendFormat("{0},", ids);
                //    }
                //    else
                //    {
                //        sb.AppendFormat("{0},", item);
                //    }
                //}

                //string newItemsStr = String.Format("[{0}]", sb.ToString().TrimEnd(','));

                //return script.Replace(itemsStr, newItemsStr);
            }

            return script;
        }

        #endregion
    }
}
