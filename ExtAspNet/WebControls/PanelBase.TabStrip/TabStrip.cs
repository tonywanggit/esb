
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    TabStrip.cs
 * CreatedOn:   2008-04-21
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
    /// 选项卡面板控件
    /// </summary>
    [Designer(typeof(TabStripDesigner))]
    [ToolboxData("<{0}:TabStrip ShowBorder=\"True\" ActiveTabIndex=\"0\" runat=\"server\"><Tabs><{0}:Tab runat=\"server\" Title=\"Tab1\" EnableBackgroundColor=\"true\" BodyPadding=\"5px\"></{0}:Tab><{0}:Tab runat=\"server\" Title=\"Tab2\" EnableBackgroundColor=\"true\" BodyPadding=\"5px\"></{0}:Tab></Tabs></{0}:TabStrip>")]
    [ToolboxBitmap(typeof(TabStrip), "res.toolbox.TabStrip.bmp")]
    [Description("选项卡面板控件")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    [DefaultEvent("TabIndexChanged")]
    public class TabStrip : PanelBase, IPostBackDataHandler, IPostBackEventHandler
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public TabStrip()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties("ActiveTabIndex");
        }

        #endregion

        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ControlBaseCollection Items
        {
            get
            {
                return base.Items;
            }
        }

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool EnableIFrame
        {
            get
            {
                return base.EnableIFrame;
            }
        }


        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string IFrameUrl
        {
            get
            {
                return base.IFrameUrl;
            }
        }


        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string IFrameName
        {
            get
            {
                return base.IFrameName;
            }
        }

        /// <summary>
        /// 布局类型
        /// </summary>
        [ReadOnly(true)]
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(Layout.Card)]
        [Description("布局类型")]
        public override Layout Layout
        {
            get
            {
                return Layout.Card;
            }
        }

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool EnableLightBackgroundColor
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool EnableBackgroundColor
        {
            get
            {
                return false;
            }
        }


        #endregion

        #region Properties

        /// <summary>
        /// 是否自动回发（切换Tab）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否自动回发（切换Tab）")]
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

        /// <summary>
        /// 显示标题的背景颜色
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("显示标题的背景颜色")]
        public bool EnableTitleBackgroundColor
        {
            get
            {
                object obj = XState["EnableTitleBackgroundColor"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableTitleBackgroundColor"] = value;
            }
        }

        /// <summary>
        /// 是否启用右键菜单 - 可用来关闭当前Tab和所有其他Tab
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否启用右键菜单 - 可用来关闭当前Tab和所有其他Tab")]
        public bool EnableTabCloseMenu
        {
            get
            {
                object obj = XState["EnableTabCloseMenu"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["EnableTabCloseMenu"] = value;
            }
        }


        ///// <summary>
        ///// 选项卡之间空白
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(typeof(Unit), "2")]
        //[Description("选项卡之间空白")]
        //public Unit TabMargin
        //{
        //    get
        //    {
        //        object obj = BoxState["TabMargin"];
        //        return obj == null ? (Unit)2 : (Unit)obj;
        //    }
        //    set
        //    {
        //        BoxState["TabMargin"] = value;
        //    }
        //}


        /// <summary>
        /// 选项卡显示的位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(TabPosition.Top)]
        [Description("选项卡显示的位置")]
        public TabPosition TabPosition
        {
            get
            {
                object obj = XState["TabPosition"];
                return obj == null ? TabPosition.Top : (TabPosition)obj;
            }
            set
            {
                XState["TabPosition"] = value;
            }
        }


        /// <summary>
        /// 是否启用延迟加载选项卡
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否启用延迟加载选项卡")]
        public bool EnableDeferredRender
        {
            get
            {
                object obj = XState["EnableDeferredRender"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["EnableDeferredRender"] = value;
            }
        }



        /// <summary>
        /// [AJAX属性]当前激活选项卡的索引
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(0)]
        [Description("[AJAX属性]当前激活选项卡的索引")]
        public int ActiveTabIndex
        {
            get
            {
                object obj = XState["ActiveTabIndex"];
                return obj == null ? 0 : (int)obj;
            }
            set
            {
                XState["ActiveTabIndex"] = value;
            }
        }

        #endregion

        #region Tabs

        private TabCollection tabs;

        /// <summary>
        /// 选项卡集合
        /// </summary>
        [Browsable(false)]
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual TabCollection Tabs
        {
            get
            {
                if (tabs == null)
                {
                    tabs = new TabCollection(this);
                }
                return tabs;
            }
        }

        #endregion

        #region ActiveTabIndexHiddenFieldID

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected string ActiveTabIndexHiddenFieldID
        {
            get
            {
                return String.Format("{0}_ActiveTabIndex", ClientID);
            }
        }

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[Description("需要回发的Tab列表")]
        //private string NeedPostBackTabIDS
        //{
        //    get
        //    {
        //        return String.Format("{0}_need_postback_tab_ids", XID);
        //    }
        //}

        #endregion

        #region old code - LoadXState/SaveXState

        //protected override void LoadXState(JObject state, string property)
        //{
        //    base.LoadXState(state, property);

        //    // This property is persisted inside every Tabs.
        //    //if (property == "X_AutoPostBackTabs")
        //    //{
        //    //    AutoPostBackTabsFromJSON(state.getJArray(property));
        //    //}
        //}

        //protected override void OnInit(EventArgs e)
        //{
        //    base.OnInit(e);

        //    //SaveXProperty("X_AutoPostBackTabs", AutoPostBackTabsToJSON().ToString());
        //}

        //protected override void OnBothPreRender()
        //{
        //    base.OnBothPreRender();

        //    //// Make sure X_AutoPostBackTabs property exist in X_STATE during page's first load.
        //    //if (!Page.IsPostBack)
        //    //{
        //    //    XState.AddModifiedProperties("X_AutoPostBackTabs");
        //    //}
        //    //else
        //    //{
        //    //    // Items has been changed in server-side code after onInit.
        //    //    if (XPropertyModified("X_AutoPostBackTabs", AutoPostBackTabsToJSON().ToString()))
        //    //    {
        //    //        XState.AddModifiedProperties("X_AutoPostBackTabs");
        //    //    }
        //    //}
        //}

        //protected override void SaveXState(JObject state, string property)
        //{
        //    //if (property == "X_AutoPostBackTabs")
        //    //{
        //    //    state.put(property, AutoPostBackTabsToJSON());
        //    //}
        //}

        /////// <summary>
        /////// These tabs need to auto postback when actived.
        /////// </summary>
        /////// <returns></returns>
        ////private JArray AutoPostBackTabsToJSON()
        ////{
        ////    JArray ja = new JArray();
        ////    for (int i = 0; i < Tabs.Count; i++)
        ////    {
        ////        Tab tab = Tabs[i];
        ////        if (tab.EnablePostBack)
        ////        {
        ////            ja.Add(tab.ClientID);
        ////        }
        ////    }
        ////    return ja;
        ////}

        ////private void AutoPostBackTabsFromJSON(JArray ja)
        ////{
        ////    List<string> autoPostackTabIds = new List<string>(JSONUtil.StringArrayFromJArray(ja));
        ////    foreach (Tab tab in Tabs)
        ////    {
        ////        if (autoPostackTabIds.Contains(tab.ClientID))
        ////        {
        ////            tab.EnablePostBack = true;
        ////        }
        ////        else
        ////        {
        ////            tab.EnablePostBack = false;
        ////        }
        ////    }
        ////}

        #endregion

        #region old code - OnPreLoad

        //protected override void OnPreLoad(object sender, EventArgs e)
        //{
        //    base.OnPreLoad(sender, e);

        //    SaveAjaxProperty("ActiveTabIndex", ActiveTabIndex);
        //    SaveAjaxProperty("NeedPostBackTabIdsScript", GetNeedPostBackTabIDsScript());

        //}

        #endregion

        #region OnPreRender
        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            if (PropertyModified("ActiveTabIndex"))
            {
                //if (ClientPropertyModifiedInServer("ActiveTabIndex"))

                sb.AppendFormat("{0}.x_setActiveTab();", XID);

            }

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            ResourceManager.Instance.AddJavaScriptComponent("tab");

            if (EnableTabCloseMenu)
            {
                ResourceManager.Instance.AddJavaScriptComponent("menu");
            }

            #region Tabs

            if (Tabs.Count > 0)
            {
                JsArrayBuilder ab = new JsArrayBuilder();
                foreach (Tab tab in Tabs)
                {
                    if (tab.Visible)
                    {
                        ab.AddProperty(String.Format("{0}", tab.XID), true);
                    }
                }
                OB.AddProperty("items", ab.ToString(), true);
            }

            #endregion

            #region options

            // 删除Layout配置参数
            OB.RemoveProperty("layout");

            //OB.AddProperty(OptionName.TabMargin, TabMargin.Value);
            OB.AddProperty("tabPosition", TabPositionHelper.GetName(TabPosition));
            //if (Plain) OB.AddProperty(OptionName.Plain, Plain);
            if (!EnableTitleBackgroundColor)
            {
                OB.AddProperty("plain", true);
            }


            // 去掉deferredRender=true，渲染速度会提高200ms左右
            // 每个Tab是否只在第一次访问时渲染，false表示全部渲染，否则没有访问的Tab的内容渲染的位置不正确。
            OB.AddProperty("deferredRender", EnableDeferredRender);

            //OB.AddProperty("bufferResize", true);

            // 在切换Tab时重新布局Tab的内容
            OB.AddProperty("layoutOnTabChange", true);

            OB.AddProperty("enableTabScroll", true);

            if (EnableTabCloseMenu)
            {
                OB.AddProperty("plugins", "new Ext.ux.TabCloseMenu()", true);
            }

            ////Note: By default, a tab's close tool destroys the child tab Component and all its descendants. 
            //// This makes the child tab Component, and all its descendants unusable. 
            //// To enable re-use of a tab, configure the TabPanel with autoDestroy: false. 
            //OB.AddProperty("autoDestroy", false);

            #endregion

            #region ActiveTabIndex/IFrameDelayLoad

            OB.AddProperty("activeTab", ActiveTabIndex);

            //for (int i = 0; i < Tabs.Count; i++)
            //{
            //    Tab tab = Tabs[i];
            //    if (tab.EnableIFrame && i != ActiveTabIndex)
            //    {
            //        // 拥有IFrame的Tab如果不是激活Tab，则不设置Url，只有在激活时才设置Url
            //        tab.IFrameDelayLoad = true;
            //    }
            //    else
            //    {
            //        tab.IFrameDelayLoad = false;
            //    }
            //}

            #endregion

            #region Listeners

            #region old code

            // 如果存在Tabs集合
            //if (Tabs.Count > 0)
            //{
            //    JsArrayBuilder ab = new JsArrayBuilder();
            //    foreach (Tab tab in Tabs)
            //    {
            //        ab.AddProperty(String.Format("{0}", tab.ClientID), true);
            //    }
            //    OB.AddProperty(OptionName.Items, ab.ToString(), true);
            //}

            // listeners
            //JsObjectBuilder listenersBuilder = new JsObjectBuilder();
            //listenersBuilder.AddProperty(OptionName.Tabchange, String.Format("function(tabPanel, activeTab){{Ext.get('{0}').dom.value=tabPanel.items.indexOf(activeTab);}}", ActiveTabHiddenField.ClientID), true);
            //OBuilder.AddProperty("listeners", listenersBuilder.ToString(), true);

            #endregion

            // 如果要激活的Tab含有IFrame，则需要加载IFrame
            // 改变Tab需要回发的脚本
            // Make sure X_AutoPostBackTabs property exist in X_STATE during page's first load.
            //string tabchangeScript2 = String.Format("if(tabPanel.x_autoPostBackTabsContains(tab.id)){{{0}}}", GetPostBackEventReference());

            string tabchangeScript = "X.wnd.updateIFrameNode(tab);";
            string postbackScript = String.Empty;
            if (AutoPostBack)
            {
                tabchangeScript += "if(!tab.x_dynamic_added_tab){" + GetPostBackEventReference() + "}";
            }

            // 如果是动态添加的Tab，不做任何处理（在js/box/extender.js中）
            //string tabchangeScript = "X.wnd.updateIFrameNode(tab);if(!tab.x_dynamic_added_tab){" + postbackScript + "}";
            OB.Listeners.AddProperty("tabchange", JsHelper.GetFunction(tabchangeScript, "tabPanel", "tab"), true);

            #endregion

            #region old code

            //// 添加隐藏字段
            //string needPostBackTabIDsScript = GetNeedPostBackTabIDsScript();
            //hiddenFieldsScript += needPostBackTabIDsScript;

            //if (AjaxPropertyChanged("NeedPostBackTabIdsScript", needPostBackTabIDsScript))
            //{
            //    AddAjaxPropertyChangedScript(needPostBackTabIDsScript);
            //}


            //hiddenFieldsScript += GetSetHiddenFieldValueScript(ActiveTabHiddenFieldID, ActiveTabIndex.ToString().ToLower());

            #endregion

            #region old code

            //// An bug in IE.
            //string renderScript = "if(Ext.isIE){(function(){this.getActiveTab().removeClass('x-hide-display');}).defer(20,this);}";

            //OB.Listeners.AddProperty("render", JsHelper.GetFunction(renderScript), true);

            #endregion

            string jsContent = String.Format("var {0}=new Ext.TabPanel({1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }


        #endregion

        #region IPostBackDataHandler Members

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            string postValue = postCollection[ActiveTabIndexHiddenFieldID];

            int postActiveTabIndex = Convert.ToInt32(postValue);
            if (ActiveTabIndex != postActiveTabIndex)
            {
                ActiveTabIndex = postActiveTabIndex;
                XState.BackupPostDataProperty("ActiveTabIndex");
                return true;
            }
            return false;
        }

        /// <summary>
        /// 触发回发数据改变事件
        /// </summary>
        public void RaisePostDataChangedEvent()
        {
            OnTabIndexChanged(EventArgs.Empty);
        }

        #endregion

        #region IPostBackEventHandler

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public void RaisePostBackEvent(string eventArgument)
        {
            OnTabIndexChanged(EventArgs.Empty);
        }

        #endregion

        #region OnTabIndexChanged

        private static readonly object _handlerKey = new object();

        /// <summary>
        /// 选项卡改变事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("选项卡改变事件")]
        public event EventHandler TabIndexChanged
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


        protected virtual void OnTabIndexChanged(EventArgs e)
        {
            EventHandler handler = Events[_handlerKey] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region GetShowReference

        /// <summary>
        /// 获取添加选项卡的脚本
        /// </summary>
        /// <param name="tabID">选项卡ID</param>
        /// <param name="iframeUrl">IFrame地址</param>
        /// <param name="tabTitle">选项卡标题</param>
        /// <param name="enableClose">是否可以关闭</param>
        /// <returns>客户端脚本</returns>
        public string GetAddTabReference(string tabID, string iframeUrl, string tabTitle, bool enableClose)
        {
            return GetAddTabReference(tabID, iframeUrl, tabTitle, String.Empty, enableClose);
        }

        /// <summary>
        /// 获取添加选项卡的脚本
        /// </summary>
        /// <param name="tabID">选项卡ID</param>
        /// <param name="iframeUrl">IFrame地址</param>
        /// <param name="tabTitle">选项卡标题</param>
        /// <param name="iconUrl">选项卡图标</param>
        /// <param name="enableClose">是否可以关闭</param>
        /// <returns>客户端脚本</returns>
        public string GetAddTabReference(string tabID, string iframeUrl, string tabTitle, string iconUrl, bool enableClose)
        {
            if (!String.IsNullOrEmpty(iframeUrl))
            {
                iframeUrl = ResolveIFrameUrl(iframeUrl);
            }

            JsObjectBuilder options = new JsObjectBuilder();
            options.AddProperty("id", tabID);
            options.AddProperty("url", iframeUrl);
            options.AddProperty("title", tabTitle);
            options.AddProperty("closable", enableClose);

            string iconScript = String.Empty;
            if (!String.IsNullOrEmpty(iconUrl))
            {
                string className = String.Format("icon_{0}", System.Guid.NewGuid().ToString("N"));
                iconScript = String.Format("X.util.addCSS('{0}','{1}');", className, StyleUtil.GetNoRepeatBackgroundStyle("." + className, ResolveUrl(iconUrl)));

                options.AddProperty("iconCls", className);
            }

            return iconScript + String.Format("{0}.addTab({1});", ScriptID, options);
        }


        /// <summary>
        /// 获取移除选项卡的脚本
        /// </summary>
        /// <param name="tabID">选项卡ID</param>
        /// <returns>客户端脚本</returns>
        public string GetRemoveTabReference(string tabID)
        {
            return String.Format("{0}.removeTab('{1}');", ScriptID, tabID);
        }

        #endregion

        #region old code

        //#region SaveViewState/LoadViewState/TrackViewState

        //protected override object SaveViewState()
        //{
        //    object[] states = new object[] { base.SaveViewState(), ((IStateManager)Tabs).SaveViewState() };

        //    return states;
        //}

        //protected override void LoadViewState(object savedState)
        //{
        //    if (savedState != null)
        //    {
        //        object[] states = (object[])savedState;

        //        base.LoadViewState(states[0]);

        //        ((IStateManager)Tabs).LoadViewState(states[1]);
        //    }
        //}

        //protected override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    ((IStateManager)Tabs).TrackViewState();
        //}

        //#endregion 

        #endregion
    }
}
