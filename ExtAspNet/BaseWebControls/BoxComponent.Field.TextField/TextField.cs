
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    TextField.cs
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
using System.Drawing.Design;

namespace ExtAspNet
{
    /// <summary>
    /// 表单文本输入框字段基类（抽象类）
    /// </summary>
    public abstract class TextField : Field
    {
        #region Constructor

        public TextField()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties();

        }

        #endregion

        #region validate properties

        /// <summary>
        /// 是否必填项
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(false)]
        [Description("是否必填项")]
        public bool Required
        {
            get
            {
                object obj = XState["Required"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["Required"] = value;
            }
        }

        /// <summary>
        /// 为空时提示信息
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue("")]
        [Description("为空时提示信息")]
        public string RequiredMessage
        {
            get
            {
                object obj = XState["RequiredMessage"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["RequiredMessage"] = value;
            }
        }

        /// <summary>
        /// 最大长度
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(null)]
        [Description("最大长度")]
        public int? MaxLength
        {
            get
            {
                object obj = XState["MaxLength"];
                return obj == null ? null : (int?)obj;
            }
            set
            {
                XState["MaxLength"] = value;
            }
        }

        /// <summary>
        /// 超过最大长度时提示信息
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue("")]
        [Description("超过最大长度时提示信息")]
        public string MaxLengthMessage
        {
            get
            {
                object obj = XState["MaxLengthMessage"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["MaxLengthMessage"] = value;
            }
        }


        /// <summary>
        /// 最小长度
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(null)]
        [Description("最小长度")]
        public int? MinLength
        {
            get
            {
                object obj = XState["MinLength"];
                return obj == null ? null : (int?)obj;
            }
            set
            {
                XState["MinLength"] = value;
            }
        }


        /// <summary>
        /// 少于最小长度时提示信息
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue("")]
        [Description("少于最小长度时提示信息")]
        public string MinLengthMessage
        {
            get
            {
                object obj = XState["MinLengthMessage"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["MinLengthMessage"] = value;
            }
        }

        /// <summary>
        /// RegexPattern
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(RegexPattern.None)]
        [Description("正则表达式常用类型")]
        public RegexPattern RegexPattern
        {
            get
            {
                object obj = XState["RegexPattern"];
                return obj == null ? RegexPattern.None : (RegexPattern)obj;
            }
            set
            {
                XState["RegexPattern"] = value;
            }
        }


        /// <summary>
        /// 正则表达式
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue("")]
        [Description("正则表达式")]
        [Editor("System.Web.UI.Design.WebControls.RegexTypeEditor", typeof(UITypeEditor))]
        public string Regex
        {
            get
            {
                object obj = XState["Regex"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["Regex"] = value;
            }
        }

        /// <summary>
        /// 不满足正则表达式时提示信息
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue("")]
        [Description("不满足正则表达式时提示信息")]
        public string RegexMessage
        {
            get
            {
                object obj = XState["RegexMessage"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["RegexMessage"] = value;
            }
        }

        #endregion

        #region Compare

        /// <summary>
        /// 需要比较的控件ID
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue("")]
        [Description("需要比较的控件ID")]
        public string CompareControl
        {
            get
            {
                object obj = XState["CompareControl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["CompareControl"] = value;
            }
        }



        /// <summary>
        /// 需要比较的值
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue("")]
        [Description("需要比较的值")]
        public string CompareValue
        {
            get
            {
                object obj = XState["CompareValue"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["CompareValue"] = value;
            }
        }


        /// <summary>
        /// 比较操作符
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(Operator.Equal)]
        [Description("比较操作符")]
        public Operator CompareOperator
        {
            get
            {
                object obj = XState["CompareOperator"];
                return obj == null ? Operator.Equal : (Operator)obj;
            }
            set
            {
                XState["CompareOperator"] = value;
            }
        }

        /// <summary>
        /// 比较的类型
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(CompareType.String)]
        [Description("比较的类型")]
        public CompareType CompareType
        {
            get
            {
                object obj = XState["CompareType"];
                return obj == null ? CompareType.String : (CompareType)obj;
            }
            set
            {
                XState["CompareType"] = value;
            }
        }

        /// <summary>
        /// 不满足比较条件时提示信息
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue("")]
        [Description("不满足比较条件时提示信息")]
        public string CompareMessage
        {
            get
            {
                object obj = XState["CompareMessage"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["CompareMessage"] = value;
            }
        }

        #endregion

        #region NextFocusControl

        /// <summary>
        /// 下一步获得焦点的控件（响应回车事件）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("下一步获得焦点的控件（响应回车事件）")]
        public string NextFocusControl
        {
            get
            {
                object obj = XState["NextFocusControl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["NextFocusControl"] = value;
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


            #region validate properties

            if (Required)
            {
                OB.AddProperty("allowBlank", false);
                if (!String.IsNullOrEmpty(RequiredMessage))
                {
                    OB.AddProperty("blankText", RequiredMessage);
                }
            }

            if (MaxLength != null)
            {
                OB.AddProperty("maxLength", MaxLength.Value);
                if (!String.IsNullOrEmpty(MaxLengthMessage))
                {
                    OB.AddProperty("maxLengthText", MaxLengthMessage);
                }
            }
            if (MinLength != null)
            {
                OB.AddProperty("minLength", MinLength.Value);
                if (!String.IsNullOrEmpty(MinLengthMessage))
                {
                    OB.AddProperty("minLengthText", MinLengthMessage);
                }
            }

            // Calculate regex expression via RegexPattern and Regex
            string regexStr = String.Empty;
            if (RegexPattern != RegexPattern.None)
            {
                regexStr = RegexPatternHelper.GetRegexValue(RegexPattern);
            }
            else if (!String.IsNullOrEmpty(Regex))
            {
                regexStr = Regex;
            }

            if (!String.IsNullOrEmpty(regexStr))
            {
                OB.AddProperty("regex", String.Format("new RegExp({0})", JsHelper.Enquote(regexStr)), true);
                if (!String.IsNullOrEmpty(RegexMessage))
                {
                    OB.AddProperty("regexText", RegexMessage);
                }
            }

            #endregion

            #region NextFocusControl

            if (!String.IsNullOrEmpty(NextFocusControl))
            {
                Control nextControl = ControlUtil.FindControl(Page, NextFocusControl);

                if (nextControl != null && nextControl is ControlBase)
                {
                    //// true to enable the proxying of key events for the HTML input field (defaults to false)
                    //OB.AddProperty("enableKeyEvents", true);
                    // Fires when any key related to navigation (arrows, tab, enter, esc, etc.) is pressed. 
                    OB.Listeners.AddProperty("specialkey", String.Format("function(field,e){{if(e.getKey()==e.ENTER){{{0}.focus(true,10);e.stopEvent();}}}}", (nextControl as ControlBase).XID), true);
                }
            }

            #endregion

            #region ControlToCompare

            string compareValue = String.Empty;
            // If CompareControl and CompareValue both exist, then CompareControl has higher priority.
            if (!String.IsNullOrEmpty(CompareControl))
            {
                Control compareControl = ControlUtil.FindControl(Page, CompareControl);
                if (compareControl != null && compareControl is ControlBase)
                {
                    compareValue = String.Format("X.util.getFormFieldValue(Ext.getCmp({0}))", JsHelper.Enquote((compareControl as ControlBase).ClientID));
                }
            }
            else if (!String.IsNullOrEmpty(CompareValue))
            {
                compareValue = CompareValue;
                if (CompareType == CompareType.String)
                {
                    compareValue = JsHelper.Enquote(compareValue);
                }
            }

            // Check whether compareValue exist, which may produced from CompareControl or CompareValue.
            if (!String.IsNullOrEmpty(compareValue))
            {
                string compareOperatorJs = OperatorHelper.GetName(CompareOperator);
                string compareExpressionScript = String.Empty;
                if (CompareType == CompareType.String)
                {
                    compareExpressionScript = String.Format("value{0}{1}", compareOperatorJs, compareValue);
                }
                else if (CompareType == CompareType.Int)
                {
                    compareExpressionScript = String.Format("parseInt(value,10){0}parseInt({1},10)", compareOperatorJs, compareValue);
                }
                else if (CompareType == CompareType.Float)
                {
                    compareExpressionScript = String.Format("parseFloat(value){0}parseFloat({1})", compareOperatorJs, compareValue);
                }
                //else if (CompareType == CompareType.Date)
                //{
                //    compareExpressionScript = String.Format("Date.parse(value){0}Date.parse({1})", compareOperatorJs, compareValueJs);
                //}

                string compareScript = String.Format("if({0}){{return true;}}else{{return {1};}}", compareExpressionScript, JsHelper.Enquote(CompareMessage));
                OB.AddProperty("validator", String.Format("function(value){{if(this.getXType()==='combo'){{value=this.getValue();}}{0}}}", compareScript), true);
            }

            #endregion
        }

        #endregion

        #region GetMarkInvalidReference GetClearInvalidReference

        /// <summary>
        /// 设置字段验证失败的提示信息
        /// </summary>
        /// <param name="message">提示信息</param>
        public void MarkInvalid(string message)
        {
            PageContext.RegisterStartupScript(GetMarkInvalidReference(message));
        }

        /// <summary>
        /// 清除验证失败的提示信息
        /// </summary>
        public void ClearInvalid()
        {
            PageContext.RegisterStartupScript(GetClearInvalidReference());
        }

        /// <summary>
        /// 获取字段验证失败提示信息的客户端脚本
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <returns>客户端脚本</returns>
        public string GetMarkInvalidReference(string message)
        {
            return String.Format("{0}.markInvalid({1});", ScriptID, JsHelper.GetJsString(message));
        }

        /// <summary>
        /// 获取清除验证失败提示信息的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetClearInvalidReference()
        {
            return String.Format("{0}.clearInvalid();", ScriptID);
        }

        #endregion

    }
}
