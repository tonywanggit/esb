
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    LinkButtonField.cs
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
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Text;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Globalization;
using System.Reflection;

using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.Drawing.Design;

namespace ExtAspNet
{
    /// <summary>
    /// 表格链接按钮列
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class LinkButtonField : GridColumn
    {

        #region Properties


        public string _dataTextField = String.Empty;

        /// <summary>
        /// 字段名称
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("字段名称")]
        public string DataTextField
        {
            get
            {
                return _dataTextField;
            }
            set
            {
                _dataTextField = value;
            }
        }


        public string _dataTextFormatString = String.Empty;

        /// <summary>
        /// 字段格式化字符串
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("字段格式化字符串")]
        public string DataTextFormatString
        {
            get
            {
                return _dataTextFormatString;
            }
            set
            {
                _dataTextFormatString = value;
            }
        }


        public string _text = String.Empty;

        /// <summary>
        /// 按钮文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("按钮文本")]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }



        private bool _htmlEncode = true;

        /// <summary>
        /// 显示之前进行HTML编码（默认为true）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("显示之前进行HTML编码（默认为true）")]
        public bool HtmlEncode
        {
            get
            {
                return _htmlEncode;
            }
            set
            {
                _htmlEncode = value;
            }
        }


        private bool _htmlEncodeFormatString = true;

        /// <summary>
        /// 是否在应用DataFormatString属性之后进行HTML编码（默认为true）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否在应用DataFormatString属性之后进行HTML编码（默认为true）")]
        public bool HtmlEncodeFormatString
        {
            get
            {
                return _htmlEncodeFormatString;
            }
            set
            {
                _htmlEncodeFormatString = value;
            }
        }

        #endregion

        #region Properties

        private bool _enablePostBack = true;

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
                return _enablePostBack;
            }
            set
            {
                _enablePostBack = value;
            }
        }

        private bool _enabled = true;

        /// <summary>
        /// 是否可用
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否可用")]
        public virtual bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }

        private string _onClientClick = String.Empty;

        /// <summary>
        /// 点击按钮时需要执行的客户端脚本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("点击按钮时需要执行的客户端脚本")]
        public string OnClientClick
        {
            get
            {
                return _onClientClick;
            }
            set
            {
                _onClientClick = value;
            }
        }

        public string[] _validateForms = null;

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
                return _validateForms;
            }
            set
            {
                _validateForms = value;
            }
        }

        public Target _validateTarget = Target.Self;

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
                return _validateTarget;
            }
            set
            {
                _validateTarget = value;
            }
        }

        public bool _validateMessageBox = true;

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
                return _validateMessageBox;
            }
            set
            {
                _validateMessageBox = value;
            }
        }



        public Icon _icon = Icon.None;

        /// <summary>
        /// 图标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Icon.None)]
        [Description("图标")]
        public Icon Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
            }
        }

        public string _iconUrl = String.Empty;

        /// <summary>
        /// 图标地址
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("图标地址")]
        [Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
        public string IconUrl
        {
            get
            {
                return _iconUrl;
            }
            set
            {
                _iconUrl = value;
            }
        }

        #endregion

        #region ConfirmText/ConfirmTitle/ConfirmIcon

        private string _confirmTitle = "";

        /// <summary>
        /// 确认对话框标题
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("确认对话框标题")]
        public string ConfirmTitle
        {
            get
            {
                return _confirmTitle;
            }
            set
            {
                _confirmTitle = value;
            }
        }

        private string _confirmText = String.Empty;

        /// <summary>
        /// 确认对话框内容
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("确认对话框内容")]
        public string ConfirmText
        {
            get
            {
                return _confirmText;
            }
            set
            {
                _confirmText = value;
            }
        }

        private MessageBoxIcon _confirmIcon = MessageBoxIcon.Warning;

        /// <summary>
        /// 确认对话框提示图标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(MessageBoxIcon.Warning)]
        [Description("确认对话框提示图标")]
        public MessageBoxIcon ConfirmIcon
        {
            get
            {
                return _confirmIcon;
            }
            set
            {
                _confirmIcon = value;
            }
        }

        public Target _confirmTarget = Target.Self;

        /// <summary>
        /// 确认对话框弹出位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Target.Self)]
        [Description("确认对话框弹出位置")]
        public Target ConfirmTarget
        {
            get
            {
                return _confirmTarget;
            }
            set
            {
                _confirmTarget = value;
            }
        }

        #endregion

        #region CommandName/CommandArgument

        public string _commandName = String.Empty;

        /// <summary>
        /// 命令名称
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("命令名称")]
        public string CommandName
        {
            get
            {
                return _commandName;
            }
            set
            {
                _commandName = value;
            }
        }

        public string _commandArgument = String.Empty;

        /// <summary>
        /// 命令参数
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("命令参数")]
        public string CommandArgument
        {
            get
            {
                return _commandArgument;
            }
            set
            {
                _commandArgument = value;
            }
        }


        #endregion

        #region Methods

        internal override string GetColumnValue(GridRow row)
        {
            //string result = String.Empty;

            #region DataTextField

            string text = String.Empty;

            if (!String.IsNullOrEmpty(DataTextField))
            {
                object value = row.GetPropertyValue(DataTextField);

                if (!String.IsNullOrEmpty(DataTextFormatString))
                {
                    text = String.Format(DataTextFormatString, value);
                    if (HtmlEncodeFormatString)
                    {
                        text = HttpUtility.HtmlEncode(text);
                    }
                }
                else
                {
                    text = value.ToString();
                    if (HtmlEncode)
                    {
                        text = HttpUtility.HtmlEncode(text);
                    }
                }
            }
            else
            {
                text = Text;
            }

            #endregion

            HtmlNodeBuilder nb;

            #region Enabled

            nb = new HtmlNodeBuilder("a");

            if (Enabled)
            {
                nb.SetProperty("href", "javascript:;");

                // click
                string paramStr = String.Format("Command${0}${1}${2}${3}", row.RowIndex, ColumnIndex, CommandName.Replace("'", "\""), CommandArgument.Replace("'", "\""));
                string postBackReference = Grid.GetPostBackEventReference(paramStr);

                string clientScript = Button.ResolveClientScript(ValidateForms, ValidateTarget, ValidateMessageBox, EnablePostBack, postBackReference,
                  ConfirmText, ConfirmTitle, ConfirmIcon, ConfirmTarget, OnClientClick, String.Empty);

                clientScript = JsHelper.GetDeferScript(clientScript, 0) + "X.util.stopEventPropagation.apply(null, arguments);";

                nb.SetProperty("onclick", clientScript);

                //result = nb.ToString();
            }
            else
            {
                nb.SetProperty("class", "x-item-disabled");
                nb.SetProperty("disabled", "disabled");

                //nb = new HtmlNodeBuilder("span");
                //nb.SetProperty("class", "gray");
                //nb.InnerProperty = text;
                //result = String.Format("<span class=\"gray\">{0}</span>", text);
            }

            nb.InnerProperty = text;

            #endregion

            string tooltip = GetTooltipString(row);

            #region Icon IconUrl

            string resolvedIconUrl = IconHelper.GetResolvedIconUrl(Icon, IconUrl);
            if (!String.IsNullOrEmpty(resolvedIconUrl))
            {
                nb.InnerProperty = String.Format("<img src=\"{0}\" {1} />", resolvedIconUrl, tooltip) + nb.InnerProperty;
            }

            #endregion

            //string result = nb.ToString();
            //#region Tooltip

            //if (!String.IsNullOrEmpty(tooltip))
            //{
            //    if (result.StartsWith("<a "))
            //    {
            //        result = result.ToString().Insert(2, tooltip);
            //    }
            //    else if (result.StartsWith("<span "))
            //    {
            //        result = result.ToString().Insert(5, tooltip);
            //    }
            //} 

            //#endregion

            //return result;

            string result = nb.ToString();

            if (!String.IsNullOrEmpty(tooltip))
            {
                result = result.ToString().Insert("<a".Length, tooltip);
            }

            return result;
        }


        //public override string GetFieldType()
        //{
        //    return "string";
        //}

        #endregion

    }
}



