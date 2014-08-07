
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    LinkButton.cs
 * CreatedOn:   2008-06-23
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
    /// 链接按钮控件
    /// </summary>
    [Designer(typeof(LinkButtonDesigner))]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:LinkButton Text=\"LinkButton\" Label=\"Label\" runat=server></{0}:LinkButton>")]
    [ToolboxBitmap(typeof(LinkButton), "res.toolbox.LinkButton.bmp")]
    [Description("链接按钮控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    [DefaultEvent("Click")]
    public class LinkButton : TooltipField, IPostBackEventHandler
    {
        #region Constructor

        public LinkButton()
        {
            AddServerAjaxProperties("Text", "ConfirmText", "ConfirmTitle", "ConfirmIcon", "ConfirmTarget", "OnClientClick");
            AddClientAjaxProperties();
        }

        #endregion

        #region Unsupported Properties



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
        /// [AJAX属性]点击按钮时需要执行的客户端脚本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]点击按钮时需要执行的客户端脚本")]
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
        /// 提交之前需要验证的表单名称列表
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("提交之前需要验证的表单名称列表")]
        [TypeConverter(typeof(StringArrayConverter))]
        public string[] ValidateForms
        {
            get
            {
                object obj = XState["ValidateForms"];
                return obj == null ? null : (string[])obj;
            }
            set
            {
                XState["ValidateForms"] = value;
            }
        }


        /// <summary>
        /// 验证失败时提示对话框弹出位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Target.Self)]
        [Description("验证失败时提示对话框弹出位置")]
        public Target ValidateTarget
        {
            get
            {
                object obj = XState["ValidateTarget"];
                return obj == null ? Target.Self : (Target)obj;
            }
            set
            {
                XState["ValidateTarget"] = value;
            }
        }

        /// <summary>
        /// 验证失败时是否出现提示对话框
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("验证失败时是否出现提示对话框")]
        public bool ValidateMessageBox
        {
            get
            {
                object obj = XState["ValidateMessageBox"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["ValidateMessageBox"] = value;
            }
        }

        /// <summary>
        /// 是否可以回发
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否可以回发")]
        public bool EnablePostBack
        {
            get
            {
                object obj = XState["EnablePostBack"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnablePostBack"] = value;
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

        #region ConfirmText/ConfirmTitle/ConfirmIcon

        /// <summary>
        /// [AJAX属性]确认对话框标题
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]确认对话框标题")]
        public string ConfirmTitle
        {
            get
            {
                object obj = XState["ConfirmTitle"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["ConfirmTitle"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]确认对话框内容
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]确认对话框内容")]
        public string ConfirmText
        {
            get
            {
                object obj = XState["ConfirmText"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["ConfirmText"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]确认对话框提示图标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(MessageBoxIcon.Warning)]
        [Description("[AJAX属性]确认对话框提示图标")]
        public MessageBoxIcon ConfirmIcon
        {
            get
            {
                object obj = XState["ConfirmIcon"];
                return obj == null ? MessageBoxIcon.Warning : (MessageBoxIcon)obj;
            }
            set
            {
                XState["ConfirmIcon"] = value;
            }
        }

        ///// <summary>
        ///// 确认对话框弹出位置
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("确认对话框弹出位置")]
        //public string ConfirmTarget
        //{
        //    get
        //    {
        //        object obj = BoxState["ConfirmTarget"];
        //        return obj == null ? "" : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["ConfirmTarget"] = value;
        //    }
        //}

        /// <summary>
        /// [AJAX属性]确认对话框弹出位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Target.Self)]
        [Description("[AJAX属性]确认对话框弹出位置")]
        public Target ConfirmTarget
        {
            get
            {
                object obj = XState["ConfirmTarget"];
                return obj == null ? Target.Self : (Target)obj;
            }
            set
            {
                XState["ConfirmTarget"] = value;
            }
        }
        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();

            if (PropertyModified("Enabled", "Text", "ConfirmText", "ConfirmTitle", "ConfirmIcon", "ConfirmTarget", "OnClientClick", "ToolTip", "ToolTipTitle", "ToolTipAutoHide"))
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
            string text = Text;
            if (EncodeText)
            {
                text = HttpUtility.HtmlEncode(text);
            }

            HtmlNodeBuilder htmlBuilder = new HtmlNodeBuilder("a");

            if (Enabled)
            {
                htmlBuilder.SetProperty("href", "javascript:;");

                // ValidateForms/Click
                string clientScript = Button.ResolveClientScript(ValidateForms, ValidateTarget, ValidateMessageBox, EnablePostBack, GetPostBackEventReference(),
                   ConfirmText, ConfirmTitle, ConfirmIcon, ConfirmTarget, OnClientClick, String.Empty);
                htmlBuilder.SetProperty("onclick", String.Format("javascript:{0}", clientScript));

                if (TabIndex != null)
                {
                    htmlBuilder.SetProperty("tabindex", TabIndex.Value.ToString());
                }

            }
            else
            {
                //htmlBuilder.SetProperty("class", "gray");
                htmlBuilder.SetProperty("class", "x-item-disabled");
                htmlBuilder.SetProperty("disabled", "disabled");
            }

            ResolveTooltip(htmlBuilder);

            htmlBuilder.InnerProperty = text;

            return htmlBuilder.ToString();
        }

        #endregion

        #region IPostBackEventHandler

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public void RaisePostBackEvent(string eventArgument)
        {
            OnClick(EventArgs.Empty);
        }

        #endregion

        #region OnClick

        private static readonly object _handlerKey = new object();

        /// <summary>
        /// 点击按钮事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("点击按钮事件")]
        public event EventHandler Click
        {
            add
            {
                Events.AddHandler(_handlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_handlerKey, value);
            }
        }


        protected virtual void OnClick(EventArgs e)
        {
            EventHandler handler = Events[_handlerKey] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion
    }
}
