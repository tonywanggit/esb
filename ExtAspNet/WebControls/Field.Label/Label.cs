
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    Label.cs
 * CreatedOn:   2008-04-23
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

namespace ExtAspNet
{
    /// <summary>
    /// 文本控件
    /// </summary>
    [Designer(typeof(LabelDesigner))]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:Label Text=\"Label\" Label=\"Label\" runat=server></{0}:Label>")]
    [ToolboxBitmap(typeof(Label), "res.toolbox.Label.bmp")]
    [Description("文本控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Label : TooltipField
    {
        #region Constructor

        public Label()
        {
            AddServerAjaxProperties("Text");
            AddClientAjaxProperties();
        }

        #endregion

        #region Unsupported Properties

        ///// <summary>
        ///// 不支持此属性
        ///// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public override bool Enabled
        //{
        //    get
        //    {
        //        return base.Enabled;
        //    }
        //}

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override short? TabIndex
        {
            get
            {
                return base.TabIndex;
            }
        }

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool FocusOnPageLoad
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// 是否对文本编码
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否对文本编码")]
        public virtual bool EncodeText
        {
            get
            {
                object obj = XState["EncodeText"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EncodeText"] = value;
            }
        }

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
            if (PropertyModified("Text", "ToolTip", "ToolTipTitle", "ToolTipAutoHide", "Enabled"))
            {
                sb.AppendFormat("{0}.setValue({1});", XID, JsHelper.Enquote(GetInnerHtml()));
            }

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();


            //OB.AddProperty("htmlEncode", false);

            //OB.RemoveProperty(OptionName.Value);
            OB.AddProperty("value", GetInnerHtml());

            //AddExtraStyle("display", "inline");


            string jsContent = String.Format("var {0}=new Ext.form.DisplayField({1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }


        private string GetInnerHtml()
        {
            string text = Text;
            if (EncodeText)
            {
                text = HttpUtility.HtmlEncode(text);
            }

            HtmlNodeBuilder htmlBuilder = new HtmlNodeBuilder("span");

            if (!String.IsNullOrEmpty(ToolTip))
            {
                ResolveTooltip(htmlBuilder);
            }

            if (!Enabled)
            {
                htmlBuilder.SetProperty("class", "x-item-disabled");
                htmlBuilder.SetProperty("disabled", "disabled");
            }

            htmlBuilder.InnerProperty = text;

            return htmlBuilder.ToString();

        }

        #endregion
    }
}
