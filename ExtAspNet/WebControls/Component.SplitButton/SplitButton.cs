
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    SplitButton.cs
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
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI.Design;

namespace ExtAspNet
{

    [Designer(typeof(SplitButtonDesigner))]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:SplitButton runat=\"server\"></{0}:SplitButton>")]
    [ToolboxBitmap(typeof(SplitButton), "res.toolbox.SplitButton.bmp")]
    [Description("按钮控件")]
    [DefaultEvent("Click")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    [ParseChildren(true, "Menus")]
    [PersistChildren(false)]
    public class SplitButton : Button, IPostBackEventHandler
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


            // 首先删除注册脚本（因为已经在Button中注册过了）
            ResourceManager.Instance.RemoveStartupScript(this);

            string jsContent = String.Format("var {0}=new Ext.SplitButton({1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }


        #endregion



    }
}
