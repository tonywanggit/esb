
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    TextBox.cs
 * CreatedOn:   2008-04-07
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->2008-04-11    sanshi.ustc@gmail.com  
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

namespace ExtAspNet
{
    /// <summary>
    /// 文本框控件
    /// </summary>
    [Designer(typeof(TextBoxDesigner))]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TextBox Label=\"Label\" Text=\"\" runat=\"server\"></{0}:TextBox>")]
    [ToolboxBitmap(typeof(TextBox), "res.toolbox.TextBox.bmp")]
    [Description("文本框控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class TextBox : RealTextField
    {
        #region Constructor

        public TextBox()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties();

        }

        #endregion

        #region Properties

        
        /// <summary>
        /// 文本框类型
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(TextMode.Text)]
        [Description("文本框类型")]
        public virtual TextMode TextMode
        {
            get
            {
                object obj = XState["TextMode"];
                return obj == null ? TextMode.Text : (TextMode)obj;
            }
            set
            {
                XState["TextMode"] = value;
            }
        }

        #endregion

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




            if (TextMode != TextMode.Text)
            {
                OB.AddProperty("inputType", TextModeHelper.GetName(TextMode));
            }

            string jsContent = String.Format("var {0}=new Ext.form.TextField({1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #endregion


    }
}
