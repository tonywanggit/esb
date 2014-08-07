
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    MenuItem.cs
 * CreatedOn:   2008-07-12
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
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI.Design.WebControls;

using Newtonsoft.Json;
using System.Web.UI.HtmlControls;

namespace ExtAspNet
{
    /// <summary>
    /// 菜单项控件基类（抽象类）
    /// </summary>
    [ToolboxData("<{0}:MenuItem runat=\"server\"></{0}:MenuItem>")]
    [ToolboxBitmap(typeof(BaseMenuItem), "res.toolbox.MenuItem.bmp")]
    [Description("菜单项控件基类")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public abstract class BaseMenuItem : Component
    {

        #region Properties


       

        #endregion


        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            //if (PropertyModified("Readonly"))
            //{
            //    sb.AppendFormat("{0}.setReadOnly({1});", XID, Readonly.ToString().ToLower());
            //}

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();
        }
        #endregion


    }
}
