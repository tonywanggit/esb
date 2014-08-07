
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    MenuText.cs
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
    /// 菜单项文本控件
    /// </summary>
    [ToolboxData("<{0}:MenuText runat=\"server\"></{0}:MenuText>")]
    [ToolboxBitmap(typeof(MenuText), "res.toolbox.MenuText.bmp")]
    [Description("菜单项文本控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class MenuText : BaseMenuItem
    {

        #region Properties

        /// <summary>
        /// 文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("文本")]
        public virtual string Text
        {
            get
            {
                object obj = XState["Text"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["Text"] = value;
            }
        }

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


            OB.AddProperty("text", Text);


            string jsContent = String.Format("var {0}=new Ext.menu.TextItem({1});", XID, OB.ToString());


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
