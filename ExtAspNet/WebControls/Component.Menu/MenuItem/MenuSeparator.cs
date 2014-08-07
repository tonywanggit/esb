
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    MenuSeparator.cs
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
    /// 菜单项分隔符控件
    /// </summary>
    [ToolboxData("<{0}:MenuSeparator runat=\"server\"></{0}:MenuSeparator>")]
    [ToolboxBitmap(typeof(MenuSeparator), "res.toolbox.MenuSeparator.bmp")]
    [Description("菜单项分隔符控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class MenuSeparator : BaseMenuItem
    {


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


            string jsContent = String.Format("var {0}=new Ext.menu.Separator({1});", XID, OB.ToString());


            //if (AjaxForceCompleteUpdate)
            //{
            //    ClearAjaxUpdateScript();
            //    AddAjaxUpdateScript(jsContent);
            //    AjaxForceCompleteUpdate = false;
            //}

            AddStartupScript(jsContent);

        }

        #endregion
    }
}
