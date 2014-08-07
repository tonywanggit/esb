
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    ToolbarText.cs
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
    /// 工具栏文本控件
    /// </summary>
    [Designer(typeof(ToolbarTextDesigner))]
    [ToolboxData("<{0}:ToolbarText runat=server></{0}:ToolbarText>")]
    [ToolboxBitmap(typeof(ToolbarText), "res.toolbox.ToolbarText.bmp")]
    [Description("工具栏文本控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class ToolbarText : Component
    {
        #region Constructor

        public ToolbarText()
        {
            AddServerAjaxProperties("Text");
            AddClientAjaxProperties();
        }

        #endregion
        

        #region Properties

        /// <summary>
        /// [AJAX属性]文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]文本")]
        public virtual string Text
        {
            get
            {
                object obj = XState["Text"];
                return obj == null ? String.Empty : (string)obj;
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
            if (PropertyModified("Text"))
            {
                sb.AppendFormat("{0}.setText({1});", XID, JsHelper.Enquote(Text));
            }

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();


            OB.AddProperty("text", Text);

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



            //if (AjaxPropertyChanged("Text", Text))
            //{
            //    // 这是extjs2.2中使用的小技巧，extjs3.0已经支持对文本进行更新
            //    // AddAjaxPartialUpdateScript(String.Format("{0}.getEl().innerHTML={1};", ClientJavascriptID, JsHelper.Enquote(Text)));
            //    AddAjaxPropertyChangedScript(String.Format("{0}.setText({1});", XID, JsHelper.Enquote(Text)));
            //}

            string jsContent = String.Format("var {0}=new Ext.Toolbar.TextItem({1});", XID, OB.ToString());

            AddStartupScript(jsContent);
        }

        #endregion

    }
}
