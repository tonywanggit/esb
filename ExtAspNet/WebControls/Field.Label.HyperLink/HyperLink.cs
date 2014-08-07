
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    HyperLink.cs
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
using System.Web.UI.Design.WebControls;

namespace ExtAspNet
{
    /// <summary>
    /// 链接控件
    /// </summary>
    [Designer(typeof(HyperLinkDesigner))]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:HyperLink Text=\"HyperLink\" Label=\"Label\" NavigateUrl=\"\" Target=\"_blank\" runat=server></{0}:HyperLink>")]
    [ToolboxBitmap(typeof(HyperLink), "res.toolbox.HyperLink.bmp")]
    [Description("链接控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class HyperLink : TooltipField
    {
        #region Constructor

        public HyperLink()
        {
            AddServerAjaxProperties("NavigateUrl", "Target", "OnClientClick", "Text");
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
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["Text"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]点击链接时需要执行的客户端脚本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]点击链接时需要执行的客户端脚本")]
        public string OnClientClick
        {
            get
            {
                object obj = XState["OnClientClick"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["OnClientClick"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]链接地址
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]链接地址")]
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
        /// [AJAX属性]链接目标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]链接目标")]
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

        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();

            if (PropertyModified("NavigateUrl", "Target", "OnClientClick", "Text", "ToolTip", "ToolTipTitle", "ToolTipAutoHide", "Enabled"))
            {
                sb.AppendFormat("{0}.setValue({1});", XID, JsHelper.Enquote(GetInnerHtml()));
            }

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();


            OB.AddProperty("htmlEncode", false);

            OB.AddProperty("value", GetInnerHtml());

            //AddExtraStyle("display", "inline");

            string jsContent = String.Format("var {0}=new Ext.form.DisplayField({1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        private string GetInnerHtml()
        {
            HtmlNodeBuilder htmlBuilder = new HtmlNodeBuilder("a");

            if (Enabled)
            {
                if (!String.IsNullOrEmpty(NavigateUrl))
                {
                    if (NavigateUrl == "#")
                    {
                        htmlBuilder.SetProperty("href", "#");
                    }
                    else
                    {
                        htmlBuilder.SetProperty("href", ResolveUrl(NavigateUrl));
                    }
                }

                if (!String.IsNullOrEmpty(Target))
                {
                    htmlBuilder.SetProperty("target", Target);
                }

                if (!String.IsNullOrEmpty(OnClientClick))
                {
                    htmlBuilder.SetProperty("onclick", "javascript:" + OnClientClick);
                }
            }
            else
            {
                htmlBuilder.SetProperty("class", "x-item-disabled");
                htmlBuilder.SetProperty("disabled", "disabled");
            }

            ResolveTooltip(htmlBuilder);

            string text = Text;
            if (EncodeText)
            {
                text = HttpUtility.HtmlEncode(text);
            }
            htmlBuilder.InnerProperty = text;

            return htmlBuilder.ToString();
        }

        #endregion
    }
}
