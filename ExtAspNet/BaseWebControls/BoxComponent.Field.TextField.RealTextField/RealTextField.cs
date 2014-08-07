
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    RealTextField.cs
 * CreatedOn:   2008-07-24
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
using System.Drawing.Design;

namespace ExtAspNet
{
    /// <summary>
    /// 表单文本输入框字段基类（抽象类）
    /// </summary>
    public abstract class RealTextField : TextField, IPostBackDataHandler
    {
        #region Constructor

        public RealTextField()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties("Text");
        }

        #endregion

        #region EmptyText

        /// <summary>
        /// 文本框为空时显示的文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("文本框为空时显示的文本")]
        public virtual string EmptyText
        {
            get
            {
                object obj = XState["EmptyText"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["EmptyText"] = value;
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

        /// <summary>
        /// 是否自动回发（文本值改变）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否自动回发（文本值改变）")]
        public bool AutoPostBack
        {
            get
            {
                object obj = XState["AutoPostBack"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["AutoPostBack"] = value;
            }
        }

        ///// <summary>
        ///// Enable server validate, trigger the Validate event.
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("Enable server validate, trigger the Validate event.")]
        //public bool EnableServerValidate
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableServerValidate"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableServerValidate"] = value;
        //    }
        //}

        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            if (PropertyModified("Text"))
            {
                //if (ClientPropertyModifiedInServer("Text"))

                sb.AppendFormat("{0}.x_setValue();", XID);
            }

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();


            if (!String.IsNullOrEmpty(EmptyText))
            {
                OB.AddProperty("emptyText", EmptyText);
            }

            if (!String.IsNullOrEmpty(Text))
            {
                OB.AddProperty("value", Text);
            }

            if (AutoPostBack)
            {
                OB.Listeners.AddProperty("change", JsHelper.GetFunction(GetPostBackEventReference()), true);

                #region old code
                //// First remove change event, because we has already register this event in super class - Field.
                //OB.Listeners.RemoveProperty("change");

                //string changeScript = "X.util.setPageStateChanged();";
                //changeScript += GetPostBackEventReference();
                //OB.Listeners.AddProperty("change", JsHelper.GetFunction(changeScript), true);

                //else if (EnableServerValidate)
                //{
                //    // The Validate event will not be triggered when the filed fail to pass the client side validte.
                //    //changeScript += String.Format("if(X.{0}.isValid()){{{1}}}", ClientJavascriptID, GetPostBackEventReference("Validate"));
                //}
                //else if (AutoPostBack && EnableServerValidate)
                //{
                //    changeScript += GetPostBackEventReference("#VALIDATE#").Replace("'#VALIDATE#'", String.Format("{0}.isValid() ? 'Validate' : ''"));
                //} 
                #endregion
            }

            //if (EnableServerValidate)
            //{
            //    OB.Listeners.AddProperty("blur", JsHelper.GetFunctionWrapper(GetPostBackEventReference("Validate")), true);
            //}
        }

        #endregion

        #region IPostBackDataHandler Members

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public virtual bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            string postValue = postCollection[UniqueID];

            // 只有启用表单控件时，才判断Text是否改变
            // 对于TextBox，如果禁用了（disabled="disabled"）则postValue == null，也就是说此表单字段不会提交到服务器（这是浏览器行为）。
            if (Enabled)
            {
                // If post value is empty, null or equals to the EmptyText property, we can consider it to be String.Empty.
                if (String.IsNullOrEmpty(postValue) || postValue == EmptyText)
                {
                    postValue = String.Empty;
                }

                if (Text != postValue)
                {
                    Text = postValue;
                    XState.BackupPostDataProperty("Text");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 触发回发数据改变事件
        /// </summary>
        public virtual void RaisePostDataChangedEvent()
        {
            OnTextChanged(EventArgs.Empty);
        }

        #endregion

        #region OnTextChanged

        private object _handlerKey = new object();

        /// <summary>
        /// 文本改变事件（需要启用AutoPostBack）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("文本改变事件（需要启用AutoPostBack）")]
        public virtual event EventHandler TextChanged
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

        protected virtual void OnTextChanged(EventArgs e)
        {
            EventHandler handler = Events[_handlerKey] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region old code

        //#region OnValidate

        ///// <summary>
        ///// Form field server validate event.
        ///// </summary>
        //[Category(CategoryName.ACTION)]
        //[Description("Form field server validate event.")]
        //public virtual event EventHandler Validate
        //{
        //    add
        //    {
        //        Events.AddHandler(validateHandlerKey, value);
        //    }
        //    remove
        //    {
        //        Events.RemoveHandler(validateHandlerKey, value);
        //    }
        //}

        //private object validateHandlerKey = new object();

        //public virtual void OnValidate(EventArgs e)
        //{
        //    EventHandler handler = Events[validateHandlerKey] as EventHandler;

        //    if (handler != null)
        //    {
        //        handler(this, e);
        //    }
        //}

        //#endregion

        //#region IPostBackEventHandler

        //public void RaisePostBackEvent(string eventArgument)
        //{
        //    if (eventArgument == "Validate")
        //    {
        //        OnValidate(EventArgs.Empty);
        //    }
        //}

        //#endregion 

        #endregion
    }
}
