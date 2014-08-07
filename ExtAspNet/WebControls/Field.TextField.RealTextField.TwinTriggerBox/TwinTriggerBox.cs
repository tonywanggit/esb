
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    TwinTriggerBox.cs
 * CreatedOn:   2008-06-27
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
    /// 扩展文本框控件
    /// </summary>
    [Designer(typeof(TwinTriggerBoxDesigner))]
    [DefaultProperty("Text")]
    [DefaultEvent("TriggerClick")]
    [ToolboxData("<{0}:TwinTriggerBox Label=\"Label\" Trigger1Icon=\"Clear\" Trigger2Icon=\"Search\" runat=\"server\"></{0}:TwinTriggerBox>")]
    [ToolboxBitmap(typeof(TwinTriggerBox), "res.toolbox.TwinTriggerBox.bmp")]
    [Description("扩展文本框控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class TwinTriggerBox : RealTextField, IPostBackEventHandler, IPostBackDataHandler
    {
        #region Constructor

        public TwinTriggerBox()
        {
            AddServerAjaxProperties("ShowTrigger1", "ShowTrigger2");
            AddClientAjaxProperties();
        }

        #endregion
        
        #region Properties

        /// <summary>
        /// 是否允许编辑
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否允许编辑")]
        public bool EnableEdit
        {
            get
            {
                object obj = XState["EnableEdit"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableEdit"] = value;
            }
        }


        /// <summary>
        /// 是否显示触发器
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否显示触发器")]
        public bool ShowTrigger
        {
            get
            {
                object obj = XState["ShowTrigger"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["ShowTrigger"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]是否显示第一个触发器
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("[AJAX属性]是否显示第一个触发器")]
        public bool ShowTrigger1
        {
            get
            {
                object obj = XState["ShowTrigger1"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["ShowTrigger1"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]是否显示第一个触发器
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("[AJAX属性]是否显示第二个触发器")]
        public bool ShowTrigger2
        {
            get
            {
                object obj = XState["ShowTrigger2"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["ShowTrigger2"] = value;
            }
        }


        /// <summary>
        /// 是否可以回发第一个触发器
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否可以回发第一个触发器")]
        public bool EnableTrigger1PostBack
        {
            get
            {
                object obj = XState["EnableTrigger1PostBack"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableTrigger1PostBack"] = value;
            }
        }


        /// <summary>
        /// 是否可以回发第一个触发器
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否可以回发")]
        public bool EnableTrigger2PostBack
        {
            get
            {
                object obj = XState["EnableTrigger2PostBack"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableTrigger2PostBack"] = value;
            }
        }


        /// <summary>
        /// 第一个触发器图片
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("第一个触发器图片")]
        public virtual string Trigger1IconUrl
        {
            get
            {
                object obj = XState["Trigger1IconUrl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["Trigger1IconUrl"] = value;
            }
        }

        /// <summary>
        /// 第二个触发器图片
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("第二个触发器图片")]
        public virtual string Trigger2IconUrl
        {
            get
            {
                object obj = XState["Trigger2IconUrl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["Trigger2IconUrl"] = value;
            }
        }



        /// <summary>
        /// 第一个触发器图片
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(TriggerIcon.None)]
        [Description("第一个触发器图片")]
        public virtual TriggerIcon Trigger1Icon
        {
            get
            {
                object obj = XState["Trigger1Icon"];
                return obj == null ? TriggerIcon.None : (TriggerIcon)obj;
            }
            set
            {
                XState["Trigger1Icon"] = value;
            }
        }

        /// <summary>
        /// 第二个触发器图片
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(TriggerIcon.None)]
        [Description("第二个触发器图片")]
        public virtual TriggerIcon Trigger2Icon
        {
            get
            {
                object obj = XState["Trigger2Icon"];
                return obj == null ? TriggerIcon.None : (TriggerIcon)obj;
            }
            set
            {
                XState["Trigger2Icon"] = value;
            }
        }

        /// <summary>
        /// 点击第一个触发器时需要执行的客户端脚本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("点击第一个触发器时需要执行的客户端脚本")]
        public string OnClientTrigger1Click
        {
            get
            {
                object obj = XState["OnClientTrigger1Click"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["OnClientTrigger1Click"] = value;
            }
        }

        /// <summary>
        /// 点击第二个触发器时需要执行的客户端脚本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("点击第二个触发器时需要执行的客户端脚本")]
        public string OnClientTrigger2Click
        {
            get
            {
                object obj = XState["OnClientTrigger2Click"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["OnClientTrigger2Click"] = value;
            }
        }

        #endregion

        #region RenderBeginTag/RenderEndTag

        protected override void RenderBeginTag(HtmlTextWriter writer)
        {
            base.RenderBeginTag(writer);
        }

        protected override void RenderEndTag(HtmlTextWriter writer)
        {
            base.RenderEndTag(writer);
        }

        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            if (PropertyModified("ShowTrigger1"))
            {
                sb.AppendFormat("{0}.getTrigger(0).{1}();", XID, ShowTrigger1 ? "show" : "hide");
            }

            if (PropertyModified("ShowTrigger2"))
            {
                sb.AppendFormat("{0}.getTrigger(1).{1}();", XID, ShowTrigger2 ? "show" : "hide");
            }

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            #region options

            if (!ShowTrigger)
            {
                OB.AddProperty("hideTrigger", true);
            }


            if (!ShowTrigger1)
            {
                OB.AddProperty("hideTrigger1", true);
            }
            if (!ShowTrigger2)
            {
                OB.AddProperty("hideTrigger2", true);
            }

            if (!EnableEdit)
            {
                OB.AddProperty("editable", false);
            }

            #endregion

            #region Trigger1Icon/Trigger2Icon

            if (Trigger1Icon != TriggerIcon.None)
            {
                OB.AddProperty("trigger1Class", TriggerIconHelper.GetName(Trigger1Icon));
            }
            else if (!String.IsNullOrEmpty(Trigger1IconUrl))
            {
                string className = String.Format("extaspnet_{0}_twintriggerbox_icon1", XID);
                string selector = String.Format(".x-form-field-wrap .x-form-twin-triggers .{0}", className);
                AddStartupCSS(className, StyleUtil.GetBackgroundStyle(selector, ResolveUrl(Trigger1IconUrl)));

                OB.AddProperty("trigger1Class", className);
            }


            if (Trigger2Icon != TriggerIcon.None)
            {
                OB.AddProperty("trigger2Class", TriggerIconHelper.GetName(Trigger2Icon));
            }
            else if (!String.IsNullOrEmpty(Trigger2IconUrl))
            {
                string className = String.Format("extaspnet_{0}_twintriggerbox_icon2", XID);
                string selector = String.Format(".x-form-field-wrap .x-form-twin-triggers .{0}", className);
                AddStartupCSS(className, StyleUtil.GetBackgroundStyle(selector, ResolveUrl(Trigger2IconUrl)));

                OB.AddProperty("trigger2Class", className);
            }


            #endregion

            #region Trigger1Click/Trigger1Click

            if (Enabled)
            {
                string clientTrigger1ClickScript = OnClientTrigger1Click;
                if (!String.IsNullOrEmpty(clientTrigger1ClickScript) && !clientTrigger1ClickScript.EndsWith(";"))
                {
                    clientTrigger1ClickScript += ";";
                }
                string trigger1PostbackScript = String.Empty;
                if (EnableTrigger1PostBack)
                {
                    trigger1PostbackScript = GetPostBackEventReference("Trigger$1");
                }
                //string trigger1ClickScript = String.Format("function(){{{0}}}", clientTrigger1ClickScript + trigger1PostbackScript);
                //// createDelegate 用来为一个Function创建一个Scope
                //OB.AddProperty(OptionName.OnTrigger1Click, String.Format("({0}).createDelegate(box)", trigger1ClickScript), true);
                OB.AddProperty("onTrigger1Click", JsHelper.GetFunction(clientTrigger1ClickScript + trigger1PostbackScript), true);


                string clientTrigger2ClickScript = OnClientTrigger2Click;
                if (!String.IsNullOrEmpty(clientTrigger2ClickScript) && !clientTrigger2ClickScript.EndsWith(";"))
                {
                    clientTrigger2ClickScript += ";";
                }
                string trigger2PostbackScript = String.Empty;
                if (EnableTrigger2PostBack)
                {
                    trigger2PostbackScript = GetPostBackEventReference("Trigger$2");
                }
                //string trigger2ClickScript = String.Format("function(){{{0}}}", clientTrigger2ClickScript + Trigger2PostbackScript);
                //// createDelegate 用来为一个Function创建一个Scope
                //OB.AddProperty(OptionName.OnTrigger2Click, String.Format("({0}).createDelegate(box)", trigger2ClickScript), true);
                OB.AddProperty("onTrigger2Click", JsHelper.GetFunction(clientTrigger2ClickScript + trigger2PostbackScript), true);

            }

            #endregion

            #region Specialkey

            if (Enabled)
            {
                // 首先启用enableKeyEvents
                //OB.AddProperty("enableKeyEvents", true);
                OB.Listeners.AddProperty("specialkey", String.Format("function(field,e){{if(e.getKey()==e.ENTER){{{0}.onTrigger2Click();e.stopEvent();}}}}", XID), true);
            }

            #endregion

            #region old code

            //string renderScript = String.Empty;

            
            ////// 只禁用文本框，不禁用Trigger
            ////if (!EnableTextBox)
            ////{
            ////    //AddAbsoluteStartupScript(String.Format("{0}.el.dom.disabled=true;", ClientJavascriptID));
            ////    renderScript += String.Format("{0}.el.dom.disabled=true;", ClientJavascriptID);
            ////}

            
            //if (AjaxPropertyChanged("ShowTrigger1", ShowTrigger1))
            //{
            //    AddAjaxPropertyChangedScript(String.Format("{0}.getTrigger(0).{1}();", XID, ShowTrigger1 ? "show" : "hide"));
            //}

            //if (AjaxPropertyChanged("ShowTrigger2", ShowTrigger2))
            //{
            //    AddAjaxPropertyChangedScript(String.Format("{0}.getTrigger(1).{1}();", XID, ShowTrigger2 ? "show" : "hide"));
            //}


            //renderScript = "(function(){" + renderScript + "}).defer(20);";
            //OB.Listeners.AddProperty("render", "function(component){" + renderScript + "}", true);

            #endregion

            string jsContent = String.Format("var {0}=new Ext.form.TwinTriggerField({1});", XID, OB.ToString());
            AddStartupScript(jsContent);

        }

        #endregion

        #region IPostBackEventHandler Members

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public void RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument == "Trigger$1")
            {
                OnTrigger1Click(EventArgs.Empty);
            }
            else if (eventArgument == "Trigger$2")
            {
                OnTrigger2Click(EventArgs.Empty);
            }
        }

        #endregion

        #region Trigger1Click

        private static readonly object _trigger1HandlerKey = new object();

        /// <summary>
        /// 点击第一个触发按钮事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("点击第一个触发按钮事件")]
        public event EventHandler Trigger1Click
        {
            add
            {
                Events.AddHandler(_trigger1HandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_trigger1HandlerKey, value);
            }
        }


        protected virtual void OnTrigger1Click(EventArgs e)
        {
            EventHandler handler = Events[_trigger1HandlerKey] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region Trigger2Click

        private static readonly object _Trigger2HandlerKey = new object();

        /// <summary>
        /// 点击第二个触发按钮事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("点击第二个触发按钮事件")]
        public event EventHandler Trigger2Click
        {
            add
            {
                Events.AddHandler(_Trigger2HandlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_Trigger2HandlerKey, value);
            }
        }


        protected virtual void OnTrigger2Click(EventArgs e)
        {
            EventHandler handler = Events[_Trigger2HandlerKey] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion
    }
}
