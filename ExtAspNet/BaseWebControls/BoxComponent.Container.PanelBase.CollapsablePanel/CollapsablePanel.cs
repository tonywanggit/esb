
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    CollapsablePanel.cs
 * CreatedOn:   2008-05-07
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

using Newtonsoft.Json;
using System.Web.UI.HtmlControls;

namespace ExtAspNet
{
    /// <summary>
    /// 可折叠面板控件基类（抽象类）
    /// </summary>
    public abstract class CollapsablePanel : PanelBase, IPostBackDataHandler
    {
        #region Constructor

        public CollapsablePanel()
        {
            AddServerAjaxProperties("Collapsed", "Title");
            AddClientAjaxProperties();
        }

        #endregion

        #region Properties

        /// <summary>
        /// 是否展开
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否展开")]
        public virtual bool Expanded
        {
            get
            {
                return !Collapsed;
            }
            set
            {
                Collapsed = !value;
            }
        }


        /// <summary>
        /// [AJAX属性]是否折叠
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("[AJAX属性]是否折叠")]
        public virtual bool Collapsed
        {
            get
            {
                object obj = XState["Collapsed"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["Collapsed"] = value;
            }
        }

        /// <summary>
        /// 是否允许折叠
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否允许折叠")]
        public virtual bool EnableCollapse
        {
            get
            {
                object obj = XState["EnableCollapse"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["EnableCollapse"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]标题
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]标题")]
        public string Title
        {
            get
            {
                object obj = XState["Title"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["Title"] = value;
            }
        }

        /// <summary>
        /// 是否显示标题栏
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否显示标题栏")]
        public virtual bool ShowHeader
        {
            get
            {
                object obj = XState["ShowHeader"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["ShowHeader"] = value;
            }
        }

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("图标样式类")]
        //public string IconClassName
        //{
        //    get
        //    {
        //        object obj = BoxState["IconClassName"];
        //        return obj == null ? "" : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["IconClassName"] = value;
        //    }
        //}

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否自动回发")]
        //public bool AutoPostBack
        //{
        //    get
        //    {
        //        object obj = BoxState["AutoPostBack"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["AutoPostBack"] = value;
        //    }
        //}

        #endregion

        #region CollapsedHiddenFieldID

        #region old code

        //private System.Web.UI.WebControls.HiddenField _collapsedHiddenField;

        //private System.Web.UI.WebControls.HiddenField CollapsedHiddenField
        //{
        //    get
        //    {
        //        if (_collapsedHiddenField == null)
        //        {
        //            _collapsedHiddenField = new HiddenField();
        //            _collapsedHiddenField.ID = "collapsed";
        //        }
        //        return _collapsedHiddenField;
        //    }
        //}

        #endregion

        // 这个值在 X.ajax.js 中和 getXStateViaCmp 函数相呼应
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected string CollapsedHiddenFieldID
        {
            get
            {
                return String.Format("{0}_Collapsed", ClientID);
            }
        }

        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            if (PropertyModified("Collapsed"))
            {
                sb.AppendFormat("{0}.x_setCollapse();", XID);
            }
            if (ShowHeader && PropertyModified("Title"))
            {
                sb.AppendFormat("{0}.x_setTitle();", XID);
            }

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            #region options

            OB.AddProperty("animCollapse", true);
            OB.AddProperty("collapsible", EnableCollapse);
            OB.AddProperty("collapsed", Collapsed);

            #endregion

            #region ShowHeader

            if (ShowHeader)
            {
                OB.AddProperty("title", String.IsNullOrEmpty(Title) ? String.Format("[{0}]", ID) : Title);
            }
            else
            {
                OB.AddProperty("header", false);
            }

            #endregion

            #region old code

            //if (IconClassName != "") OB.AddProperty(OptionName.IconCls, IconClassName);

            // Listeners, 折叠展开
            //JsObjectBuilder listenersBuilder = new JsObjectBuilder();
            //listenersBuilder.AddProperty("collapse", String.Format("function(panel){{Ext.get('{0}').dom.value=true;}}", CollapsedHiddenField.ClientID), true);
            //listenersBuilder.AddProperty("expand", String.Format("function(panel){{Ext.get('{0}').dom.value=false;}}", CollapsedHiddenField.ClientID), true);
            //OBuilder.AddProperty("listeners", listenersBuilder.ToString(), true);


            //if (EnableCollapse)
            //{
            //    OB.Listeners.AddProperty("collapse", String.Format("function(panel){{Ext.get('{0}').dom.value=true;}}", CollapsedHiddenFieldID), true);
            //    OB.Listeners.AddProperty("expand", String.Format("function(panel){{Ext.get('{0}').dom.value=false;}}", CollapsedHiddenFieldID), true);
            //}



            //string hiddenFieldsScript = String.Empty;

            //if (EnableCollapse)
            //{
            //    hiddenFieldsScript += GetSetHiddenFieldValueScript(CollapsedHiddenFieldID, Collapsed.ToString().ToLower());
            //}

            //hiddenFieldsScript += "\r\n";

            //// 在ControlBase的RegisterControlStartupScript函数中做过处理，会把在基类中注册的脚本合并后再整体注册
            ////AddStartupScript(this, hiddenFieldsScript);
            //AddPageFirstLoadScript(hiddenFieldsScript);

            #endregion

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
            bool postCollapsed = Convert.ToBoolean(postCollection[CollapsedHiddenFieldID]);
            if (Collapsed != postCollapsed)
            {
                Collapsed = postCollapsed;
                XState.BackupPostDataProperty("Collapsed");
                return true;
            }

            return false;
        }

        /// <summary>
        /// 触发回发数据改变事件
        /// </summary>
        public virtual void RaisePostDataChangedEvent()
        {
            //OnCollapsedChanged(EventArgs.Empty);
        }

        ///// <summary>
        ///// 是否折叠变化
        ///// </summary>
        //public event EventHandler CollapsedChanged
        //{
        //    add
        //    {
        //        Events.AddHandler(_handlerKey, value);
        //    }
        //    remove
        //    {
        //        Events.RemoveHandler(_handlerKey, value);
        //    }
        //}

        //public object _handlerKey = new object();

        //public virtual void OnCollapsedChanged(EventArgs e)
        //{
        //    EventHandler handler = Events[_handlerKey] as EventHandler;

        //    if (handler != null)
        //    {
        //        handler(this, e);
        //    }
        //}

        #endregion

    }
}
