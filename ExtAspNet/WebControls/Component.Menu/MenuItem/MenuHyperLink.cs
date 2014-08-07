
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    MenuHyperLink.cs
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
    /// 菜单项超链接控件
    /// </summary>
    [ToolboxData("<{0}:MenuHyperLink runat=\"server\"></{0}:MenuHyperLink>")]
    [ToolboxBitmap(typeof(MenuHyperLink), "res.toolbox.MenuHyperLink.bmp")]
    [Description("菜单项超链接控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class MenuHyperLink : MenuItem
    {

        #region Properties

        /// <summary>
        /// 链接地址
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("链接地址")]
        public string NavigateUrl
        {
            get
            {
                object obj = XState["NavigateUrl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["NavigateUrl"] = value;
            }
        }

        /// <summary>
        /// 链接目标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("链接目标")]
        public string Target
        {
            get
            {
                object obj = XState["Target"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["Target"] = value;
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

            
            #region options

            if (!String.IsNullOrEmpty(NavigateUrl))
            {
                OB.AddProperty("href", NavigateUrl);
                OB.AddProperty("hrefTarget", Target);
            }


            #endregion

            string jsContent = String.Format("var {0}=new Ext.menu.Item({1});", XID, OB.ToString());

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
