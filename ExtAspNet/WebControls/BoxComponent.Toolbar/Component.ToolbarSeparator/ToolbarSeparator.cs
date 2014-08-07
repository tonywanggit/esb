
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    ToolbarSeparator.cs
 * CreatedOn:   2008-06-09
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

namespace ExtAspNet
{
    /// <summary>
    /// 工具栏分隔符控件
    /// </summary>
    [Designer(typeof(ToolbarSeparatorDesigner))]
    [ToolboxData("<{0}:ToolbarSeparator runat=server></{0}:ToolbarSeparator>")]
    [ToolboxBitmap(typeof(ToolbarSeparator), "res.toolbox.ToolbarSeparator.bmp")]
    [Description("工具栏分隔符控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class ToolbarSeparator : Component
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

            

            //OB.RemoveProperty("stateful");
            //OB.RemoveProperty("id");

            //string hideScript = String.Empty;
            //// Ext.Toolbar.Separator 没有 "hidden"/"hideMode" 参数
            //if (Hidden)
            //{
            //    OB.RemoveProperty("hidden");
            //    OB.RemoveProperty("hideMode");

            //    hideScript = String.Format("{0}.hide();", ClientJavascriptID);
            //}
            //AddPageFirstLoadAbsoluteScript(hideScript);



            string jsContent = String.Format("var {0}=new Ext.Toolbar.Separator({1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #endregion

    }
}
