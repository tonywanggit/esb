
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    Component.cs
 * CreatedOn:   2008-04-14
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


namespace ExtAspNet
{
    /// <summary>
    /// 控件基类（抽象类）
    /// </summary>
    public abstract class Component : ControlBase
    {
        #region Constructor

        public Component()
        {
            AddServerAjaxProperties("CssClass", "FormItemClass", "CssStyle");
            AddClientAjaxProperties();

        }

        #endregion

        #region Properties


        /// <summary>
        /// 页面加载后立即获得焦点
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue(false)]
        [Description("页面加载后立即获得焦点")]
        public virtual bool FocusOnPageLoad
        {
            get
            {
                object obj = XState["FocusOnPageLoad"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["FocusOnPageLoad"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]控件样式类名
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]控件样式类名")]
        public virtual string CssClass
        {
            get
            {
                object obj = XState["CssClass"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["CssClass"] = value;
            }
        }

        /// <summary>
        /// 控件所在容器的样式类名
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue("")]
        [Description("控件所在容器的样式类名")]
        public virtual string ContainerClass
        {
            get
            {
                object obj = XState["ContainerClass"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["ContainerClass"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]表单中每一项的样式类名
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]表单中每一项的样式类名")]
        public virtual string FormItemClass
        {
            get
            {
                object obj = XState["FormItemClass"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["FormItemClass"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]控件样式
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]控件样式")]
        public virtual string CssStyle
        {
            get
            {
                object obj = XState["CssStyle"];
                return obj == null ? String.Empty : (string)obj;
            }
            set
            {
                XState["CssStyle"] = value;
            }
        }

        #region old code
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("控件容器样式类")]
        //public string ContainerClassName
        //{
        //    get
        //    {
        //        object obj = BoxState["ExtendContainerClassName"];
        //        return obj == null ? "" : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["ExtendContainerClassName"] = value;
        //    }
        //} 

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[Description("extjs控件类型")]
        //public string Xtype
        //{
        //    get
        //    {
        //        object[] xtypeAttributes = GetType().GetCustomAttributes(typeof(XTypeAttribute), true);
        //        if (xtypeAttributes != null && xtypeAttributes.Length == 1)
        //        {
        //            return (xtypeAttributes[0] as XTypeAttribute).Name;
        //        }

        //        return String.Empty;
        //    }
        //}

        //public override string AccessKey
        //{
        //    get
        //    {
        //        return base.AccessKey;
        //    }
        //    set
        //    {
        //        base.AccessKey = value;
        //    }
        //}
        #endregion

        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            if (PropertyModified("CssStyle"))
            {
                sb.AppendFormat("{0}.el.applyStyles({1});", XID, JsHelper.Enquote(CssStyle));
            }

            // 老的 CssClass 会在 X.state(x0,{"CssClass":"green"}) 时自动删除，并自动添加新的 CssClass。
            // 为什么不在这里先removeClass，再addClass？因为此时我们已经不知道之前的CssClass是什么了，这里取得的是已经修改过的。
            // 在X.util的setXState函数中处理的
            if (PropertyModified("CssClass"))
            {
                //sb.AppendFormat("{0}.el.addClass({1});", XID, JsHelper.Enquote(CssClass));
            }

            if (PropertyModified("FormItemClass"))
            {
                //sb.AppendFormat("{0}.el.addClass({1});", XID, JsHelper.Enquote(FormItemClass));
            }

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();


            if (!String.IsNullOrEmpty(CssClass))
            {
                OB.AddProperty("cls", CssClass);
            }
            if (!String.IsNullOrEmpty(ContainerClass))
            {
                OB.AddProperty("ctCls", ContainerClass);
            }
            if (!String.IsNullOrEmpty(FormItemClass))
            {
                OB.AddProperty("itemCls", FormItemClass);
            }
            if (!String.IsNullOrEmpty(CssStyle))
            {
                OB.AddProperty("style", CssStyle);
            }

            //// 不保持状态
            //OB.AddProperty("stateful", false);


            #region old code
            //if (ContainerClassName != "") OB.AddProperty(OptionName.CtCls, ContainerClassName);

            // 需要为控件添加 display:inline; 属性，否则控件会单独占用一行
            // 这是不可行的解决方法，会造成LayoutPanel莫名奇妙的问题，去掉
            //if (CssStyle == "")
            //{
            //    CssStyle = "display:inline;";
            //}
            //else if (!CssStyle.ToLower().Contains("display"))
            //{
            //    CssStyle += "display:inline;";
            //} 
            #endregion


            if (FocusOnPageLoad)
            {
                string focusScript = String.Format("{0}.focus(true,500);", XID);
                AddStartupAbsoluteScript(focusScript);
            }
        }

        #endregion

        #region GetFocusReference

        /// <summary>
        /// 使控件获得焦点
        /// </summary>
        public new void Focus()
        {
            PageContext.RegisterStartupScript(GetFocusReference());
        }


        /// <summary>
        /// 使控件获得焦点，并选中控件中的文本内容
        /// </summary>
        /// <param name="selectText">是否选中控件中的文本内容</param>
        public void Focus(bool selectText)
        {
            PageContext.RegisterStartupScript(GetFocusReference(selectText));
        }

        /// <summary>
        /// 使控件获得焦点，并选中控件中的文本内容
        /// </summary>
        /// <param name="selectText">是否选中控件中的文本内容</param>
        /// <param name="delayMilliseconds">使控件获得焦点前延迟的毫秒数</param>
        public void Focus(bool selectText, int delayMilliseconds)
        {
            PageContext.RegisterStartupScript(GetFocusReference(selectText, delayMilliseconds));
        }

        /// <summary>
        /// 获得使控件获得焦点的脚本
        /// </summary>
        /// <returns>JS脚本</returns>
        public virtual string GetFocusReference()
        {
            return String.Format("{0}.focus();", ScriptID);
        }

        /// <summary>
        /// 获得使控件获得焦点，并选中控件中的文本内容的脚本 
        /// </summary>
        /// <param name="selectText">是否选中控件中的文本内容</param>
        /// <returns>JS脚本</returns>
        public virtual string GetFocusReference(bool selectText)
        {
            return String.Format("{0}.focus({1});", ScriptID, selectText.ToString().ToLower());
        }

        /// <summary>
        /// 获得使控件获得焦点，并选中控件中的文本内容的脚本
        /// </summary>
        /// <param name="selectText">是否选中控件中的文本内容</param>
        /// <param name="delayMilliseconds">使控件获得焦点前延迟的毫秒数</param>
        /// <returns>JS脚本</returns>
        public virtual string GetFocusReference(bool selectText, int delayMilliseconds)
        {
            return String.Format("{0}.focus({1}, {2});", ScriptID, selectText.ToString().ToLower(), delayMilliseconds);
        }

        #endregion

        #region AddExtraStyle

        /// <summary>
        /// 为已经添加到OB中的Style增加新的样式
        /// 注意：这个key-value不会保存到属性CssStyle中
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected void AddExtraStyle(string key, string value)
        {
            // string style = OB.GetProperty(OptionName.Style);
            // 这样不行，添加到OB中的字符串都是被编码过的
            // 比如"margin-right:5px;"被添加到OB中就变成："\"margin-right:5px;\""，在JsObjectBuilder中的AddProperty中处理的。
            // 这样做是为了在JsObjectBuilder中的ToString中，这样来添加属性：sb.AppendFormat("{0}:{1},", key, _properties[key]);


            string style = CssStyle.ToLower();

            if (style == "" || !style.Contains(key))
            {
                style += String.Format("{0}:{1};", key, value);
            }

            OB.AddProperty("style", style);
        }

        #endregion

    }
}
