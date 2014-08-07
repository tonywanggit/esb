
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    js_css_resource.cs
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

namespace ExtAspNet
{
    /// <summary>
    /// 表单字段基类（抽象类）
    /// </summary>
    public abstract class Field : BoxComponent
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public Field()
        {
            AddServerAjaxProperties("Readonly");
            AddClientAjaxProperties();
        }

        #endregion

        #region Properties

        /// <summary>
        /// 是否显示标签
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否显示标签")]
        public virtual bool ShowLabel
        {
            get
            {
                object obj = XState["ShowLabel"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["ShowLabel"] = value;
            }
        }

        /// <summary>
        /// 是否显示空白的标签
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否显示空白的标签")]
        public virtual bool ShowEmptyLabel
        {
            get
            {
                object obj = XState["ShowEmptyLabel"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["ShowEmptyLabel"] = value;
            }
        }


        /// <summary>
        /// 标签文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("标签文本")]
        public virtual string Label
        {
            get
            {
                object obj = XState["Label"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["Label"] = value;
            }
        }

        /// <summary>
        /// 表单中字段与标签的分隔符
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(String), ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT)]
        [Description("表单中字段与标签的分隔符")]
        public virtual string LabelSeparator
        {
            get
            {
                object obj = XState["LabelSeparator"];
                if (obj == null)
                {
                    //return ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT;
                    return PageManager.Instance.FormLabelSeparator;
                }
                return (String)obj;
            }
            set
            {
                XState["LabelSeparator"] = value;
            }
        }

        /// <summary>
        /// 在标签后面显示红色的星号（用来标识必填项）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("在标签后面显示红色的星号（用来标识必填项）")]
        public bool ShowRedStar
        {
            get
            {
                object obj = XState["ShowRedStar"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["ShowRedStar"] = value;
            }
        }

        #region old code

        //private string LabelSeparator_Default = "";

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("标签分割符")]
        //public string LabelSeparator
        //{
        //    get
        //    {
        //        object obj = BoxState["LabelSeparator"];
        //        return obj == null ? LabelSeparator_Default : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["LabelSeparator"] = value;
        //    }
        //}


        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(MsgTarget.Qtip)]
        //[Description("提示消息类型")]
        //public virtual MsgTarget MsgTarget
        //{
        //    get
        //    {
        //        object obj = BoxState["MsgTarget"];
        //        return obj == null ? MsgTarget.Qtip : (MsgTarget)obj;
        //    }
        //    set
        //    {
        //        BoxState["MsgTarget"] = value;
        //    }
        //}


        #endregion


        /// <summary>
        /// [AJAX属性]表单控件的只读状态
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("[AJAX属性]表单控件的只读状态")]
        public virtual bool Readonly
        {
            get
            {
                object obj = XState["Readonly"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["Readonly"] = value;
            }
        }

        ///// <summary>
        ///// 是否可用
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(true)]
        //[Description("是否可用")]
        //public virtual bool Enabled
        //{
        //    get
        //    {
        //        object obj = XState["Enabled"];
        //        return obj == null ? true : (bool)obj;
        //    }
        //    set
        //    {
        //        XState["Enabled"] = value;
        //    }
        //}

        /// <summary>
        /// Tab按键的跳转顺序
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("Tab按键的跳转顺序")]
        public virtual short? TabIndex
        {
            get
            {
                object obj = XState["TabIndex"];
                return obj == null ? null : (short?)obj;
            }
            set
            {
                XState["TabIndex"] = value;
            }
        }

        /// <summary>
        /// 距离右侧边界的宽度
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(typeof(Unit), ConfigPropertyValue.FORM_OFFSETRIGHT_DEFAULT_STRING)]
        [Description("距离右侧边界的宽度")]
        public Unit OffsetRight
        {
            get
            {
                object obj = XState["OffsetRight"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return (Unit)ConfigPropertyValue.FORM_OFFSETRIGHT_DEFAULT;
                    }
                    else
                    {
                        return (Unit)PageManager.Instance.FormOffsetRight;
                    }
                }
                return (Unit)obj;
            }
            set
            {
                XState["OffsetRight"] = value;
            }
        }

        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            if (PropertyModified("Readonly"))
            {
                sb.AppendFormat("{0}.setReadOnly({1});", XID, Readonly.ToString().ToLower());
            }

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            ResourceManager.Instance.AddJavaScriptComponent("form");
            
            // 默认隐藏空白标签
            if (ShowEmptyLabel)
            {
                OB.AddProperty("hideEmptyLabel", false);
            }
            
            // A Field should be in a Form control, then some properties can take effects.
            if (ShowLabel)
            {
                if (!String.IsNullOrEmpty(Label))
                {
                    if (ShowRedStar)
                    {
                        OB.AddProperty("fieldLabel", Label + "<span style=\"color:red;\">*</span>");
                    }
                    else
                    {
                        OB.AddProperty("fieldLabel", Label);
                    }

                    if (LabelSeparator != ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT)
                    {
                        OB.AddProperty("labelSeparator", LabelSeparator);
                    }
                }
            }
            else
            {
                OB.AddProperty("hideLabel", true);
            }

            if (Width == Unit.Empty)
            {
                //if (this is CheckBox || this is RadioButton)
                //{
                //    // Don't add anchor layout.
                //}
                //else
                //{
                //    OB.AddProperty("anchor", String.Format("-{0}", OffsetRight));
                //}
                //if (this is CheckBox || this is RadioButton)
                //{
                //    // Don't add anchor layout.
                //}

                if (OffsetRight.Value != 0)
                {
                    OB.AddProperty("anchor", "-" + OffsetRight.Value + "px");
                }
                else
                {
                    OB.AddProperty("anchor", "100%");
                }
            }

            // Every Field need a name property, which is used in form submit.
            OB.AddProperty("name", UniqueID);

            // Enabled has been processed in ControlBase.
            //OB.AddProperty(OptionName.Disabled, !Enabled);
            //if (AjaxPropertyChanged("Enabled", Enabled))
            //{
            //    AddAjaxPropertyChangedScript(String.Format("{0}.{1}();", XID, Enabled ? "enable" : "disable"));
            //    //AddAjaxPropertyChangedScript(String.Format("{0}.setDisabled({1});", ClientJavascriptID, !Enabled));
            //}

            if (TabIndex != null)
            {
                OB.AddProperty("tabIndex", TabIndex.Value);
            }

            if (Readonly)
            {
                OB.AddProperty("readOnly", true);
            }

            // We don't need to add this change event to all Field, only SimpleForm and Form has such event.
            // We have enableBubble for Ext.form.Field

            //// Fires just before the field blurs if the field value has changed.
            //string changeScript = "X.util.setPageStateChanged();";
            //OB.Listeners.AddProperty("change", JsHelper.GetFunction(changeScript), true);

        }

        #endregion

        #region GetValueReference

        /// <summary>
        /// 获取此字段值的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public virtual string GetValueReference()
        {
            // Don't add ; in the end, because we will invoke this code like this:
            // windowField1.DataIFrameUrlFormatString = "grid_iframe_run_window1.aspx?id={0}&page={1}&param1=<script>" + TextBox1.GetValueReference() + "</script>";
            return String.Format("{0}.getValue()", ScriptID);
        }

        #endregion

        #region GetDesignTimeHtml

        
        internal string GetDesignTimeHtml(string content)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div style=\"margin:2px;\">");
            if (!ShowLabel)
            {
                sb.AppendFormat("{0}&nbsp;", content);
            }
            else
            {
                string redstar = String.Empty;
                if (ShowRedStar)
                {
                    redstar = "<span style=\"color:red;\">*</span>";
                }
                sb.AppendFormat("<table width=\"100%\"><tr><td style=\"width:150px;\">{0}</td><td>{1}&nbsp;</td></tr></table>", Label + redstar, content);
            }
            sb.Append("</div>");
            return sb.ToString();
        }

        #endregion
    }
}
