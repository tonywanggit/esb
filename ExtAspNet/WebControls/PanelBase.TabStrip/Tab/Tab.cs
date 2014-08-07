
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    Tab.cs
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
    /// 选项卡控件
    /// </summary>
    [ToolboxData("<{0}:Tab Title=\"Tab\" EnableBackgroundColor=\"true\" BodyPadding=\"5px\" runat=\"server\"></{0}:Tab>")]
    [ToolboxBitmap(typeof(Tab), "res.toolbox.Tab.bmp")]
    [Description("选项卡控件")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [DefaultProperty("Title")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Tab : CollapsablePanel
    {
        #region Constructor

        public Tab()
        {
            ServerAjaxProperties.Remove("Hidden");
            ClientAjaxProperties.Add("Hidden");

            AddServerAjaxProperties();
            AddClientAjaxProperties();
        }

        #endregion

        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool ShowBorder
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
        public override bool EnableCollapse
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// 是否可以关闭
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否可以关闭")]
        public bool EnableClose
        {
            get
            {
                object obj = XState["EnableClose"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["EnableClose"] = value;
            }
        }

        /// <summary>
        /// 是否自动高度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否自动高度")]
        public override bool AutoHeight
        {
            get
            {
                object obj = XState["AutoHeight"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["AutoHeight"] = value;
            }
        }

        /// <summary>
        /// 是否自动宽度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否自动宽度")]
        public override bool AutoWidth
        {
            get
            {
                object obj = XState["AutoWidth"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["AutoWidth"] = value;
            }
        }


        ///// <summary>
        ///// 是否可以回发
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否可以回发")]
        //public bool EnablePostBack
        //{
        //    get
        //    {
        //        object obj = XState["EnablePostBack"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        XState["EnablePostBack"] = value;
        //    }
        //}

        //[Browsable(true)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[Description("延迟加载此选项卡的IFrame")]
        //internal bool IFrameDelayLoad
        //{
        //    get
        //    {
        //        object obj = XState["IFrameDelayLoad"];
        //        return obj == null ? true : (bool)obj;
        //    }
        //    set
        //    {
        //        XState["IFrameDelayLoad"] = value;
        //    }
        //}

        #endregion

        #region OnInit

        /// <summary>
        /// Tab 控件必须包含在 TabStrip 中
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!DesignMode)
            {
                if (!(Parent is TabStrip))
                {
                    throw new Exception("Tab must be inside TabStrip.");
                }
            }
        }

        #endregion

        #region CreateChildControls

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            //// 添加子控件
            //foreach (ControlBase row in Items)
            //{
            //    row.RenderWrapperDiv = false;
            //    Controls.Add(row);
            //}
        }

        #endregion

        #region OnPreRender

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("是否隐藏Tab")]
        private string HiddenHiddenFieldID
        {
            get
            {
                return String.Format("{0}_Hidden", ClientID);
            }
        }

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            //if (PropertyModified("Text"))
            //{
            //    sb.AppendFormat("{0}.setValue({1});", XID, JsHelper.Enquote(Text));
            //}

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            TabStrip tabStrip = Parent as TabStrip;

            if (EnableIFrame)
            {
                // 对于非激活Tab，其中的Iframe需要延迟加载
                if (this != tabStrip.Tabs[tabStrip.ActiveTabIndex])
                {
                    OB.RemoveProperty("html");
                    OB.RemoveProperty("x_iframe_loaded");
                    OB.AddProperty("x_iframe_loaded", false);
                }
            }

            OB.AddProperty("x_type", "tab");

            //OB.AddProperty("__box_hidden_field_id", HiddenHiddenFieldID);

            if (EnableClose)
            {
                OB.AddProperty("closable", true);
            }

            OB.RemoveProperty("hidden");
            if (Hidden)
            {
                //string hideScript = String.Format("{0}.hideTab(cmp);", tabStrip.ScriptID);
                //OB.Listeners.AddProperty("render", JsHelper.GetFunction(hideScript, "cmp"), true);
                AddStartupAbsoluteScript(GetHideReference());
            }

            //OB.Listeners.AddProperty("beforeclose", JsHelper.GetFunction(GetHideReference() + "return false;", "cmp"), true);


            //string hiddenFieldsScript = String.Empty;
            //hiddenFieldsScript += GetSetHiddenFieldValueScript(HiddenHiddenFieldID, Hidden.ToString().ToLower());
            ////hiddenFieldsScript += "\r\n";


            string jsContent = String.Format("var {0}=new Ext.Panel({1});", XID, OB.ToString());
            AddStartupScript(jsContent);

        }

        /// <summary>
        /// Override the same method exist in ControlBase, because we have separate logic to hide this control.
        /// </summary>
        protected override string GetHiddenPropertyChangedScript()
        {
            if (PropertyModified("Hidden"))
            {
                //if (ClientPropertyModifiedInServer("Hidden"))

                return Hidden ? GetHideReference() : GetShowReference();

            }
            return String.Empty;
        }

        #endregion

        #region IPostBackDataHandler Members

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public override bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            base.LoadPostData(postDataKey, postCollection);

            bool postHidden = Convert.ToBoolean(postCollection[HiddenHiddenFieldID]);
            if (Hidden != postHidden)
            {
                Hidden = postHidden;
                XState.BackupPostDataProperty("Hidden");
                return true;
            }

            return false;
        }

        /// <summary>
        /// 触发回发数据改变事件
        /// </summary>
        public override void RaisePostDataChangedEvent()
        {
            base.RaisePostDataChangedEvent();
        }

        #endregion

        #region GetShowReference GetHideReference

        /// <summary>
        /// 获取显示选项卡的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetShowReference()
        {
            TabStrip tabStrip = Parent as TabStrip;
            if (tabStrip != null)
            {
                return String.Format("{0}.showTab('{1}');", tabStrip.ScriptID, ClientID);
            }
            return String.Empty;
        }

        /// <summary>
        /// 获取隐藏选项卡的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetHideReference()
        {
            TabStrip tabStrip = Parent as TabStrip;
            if (tabStrip != null)
            {
                return String.Format("{0}.hideTab('{1}');", tabStrip.ScriptID, ClientID);
            }
            return String.Empty;
        }

        #endregion


        #region old code
        //#region internal RenderChildrenAsContent

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(true)]
        //[Description("渲染子控件为容器内容")]
        //internal override bool RenderChildrenAsContent
        //{
        //    get
        //    {
        //        return true;
        //    }
        //}
        //#endregion

        //#region IStateManager Members

        //bool IStateManager.IsTrackingViewState
        //{
        //    get { return base.IsTrackingViewState; }
        //}

        //void IStateManager.LoadViewState(object state)
        //{
        //    base.LoadViewState(state);
        //}

        //object IStateManager.SaveViewState()
        //{
        //    return base.SaveViewState();
        //}

        //void IStateManager.TrackViewState()
        //{
        //    base.TrackViewState();
        //}

        //#endregion 
        #endregion

        #region old code

        //#region SaveViewState/LoadViewState/TrackViewState

        //protected override object SaveViewState()
        //{
        //    object[] states = new object[2];

        //    states[0] = base.SaveViewState();

        //    states[1] = ((IStateManager)Rows).SaveViewState();

        //    return states;
        //}

        //protected override void LoadViewState(object savedState)
        //{
        //    if (savedState != null)
        //    {
        //        object[] states = (object[])savedState;

        //        base.LoadViewState(states[0]);

        //        ((IStateManager)Rows).LoadViewState(states[1]);
        //    }
        //}

        //protected override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    ((IStateManager)Rows).TrackViewState();
        //}

        //#endregion 

        #endregion
    }
}
