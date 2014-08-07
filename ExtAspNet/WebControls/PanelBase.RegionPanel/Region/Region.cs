
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    RegionCollection.cs
 * CreatedOn:   2008-06-12
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
    [ToolboxItem(false)]
    [Description("页面布局子控件")]
    [ToolboxData("<{0}:Region Position=\"Center\" runat=\"server\"></{0}:Region>")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Region : CollapsablePanel
    {
        #region Unsupported Properties

        //[Category(CategoryName.OPTIONS)]
        //[Description("布局类型")]
        //[Browsable(false)]
        //public override LayoutType Layout
        //{
        //    get
        //    {
        //        return LayoutType.Fit;
        //    }
        //}


        #endregion

        #region Properties

        //private string ContentPlaceHolderId_Default = "";

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("ContentPlaceHolderId")]
        //public string ContentPlaceHolderId
        //{
        //    get
        //    {
        //        object obj = BoxState["ContentPlaceHolderId"];
        //        return obj == null ? ContentPlaceHolderId_Default : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["ContentPlaceHolderId"] = value;
        //    }
        //}

        /// <summary>
        /// 是否可以拖动边界
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否可以拖动边界")]
        public bool Split
        {
            get
            {
                object obj = XState["Split"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["Split"] = value;
            }
        }


        /// <summary>
        /// true to display a tooltip when the user hovers over a region's split bar (defaults to false). The tooltip text will be the value of either SplitTip or CollapsibleSplitTip as appropriate.
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否可以拖动边界")]
        public bool EnableSplitTip
        {
            get
            {
                object obj = XState["EnableSplitTip"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["EnableSplitTip"] = value;
            }
        }


        /// <summary>
        /// The tooltip to display when the user hovers over a non-collapsible region's split bar (defaults to 'Drag to resize.'). Only applies if EnableSplitTip = true.
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("The tooltip to display when the user hovers over a non-collapsible region's split bar (defaults to 'Drag to resize.'). Only applies if EnableSplitTip = true.")]
        public string SplitTip
        {
            get
            {
                object obj = XState["SplitTip"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["SplitTip"] = value;
            }
        }

        /// <summary>
        /// The tooltip to display when the user hovers over a collapsible region's split bar (defaults to 'Drag to resize. Double click to hide.'). Only applies if EnableSplitTip = true.
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("The tooltip to display when the user hovers over a collapsible region's split bar (defaults to 'Drag to resize. Double click to hide.'). Only applies if EnableSplitTip = true.")]
        public string CollapsibleSplitTip
        {
            get
            {
                object obj = XState["CollapsibleSplitTip"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["CollapsibleSplitTip"] = value;
            }
        }


        /// <summary>
        /// 边距
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("边距")]
        public string Margins
        {
            get
            {
                object obj = XState["Margins"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["Margins"] = value;
            }
        }

        /// <summary>
        /// 折叠后的边距
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("折叠后的边距")]
        public string CMargins
        {
            get
            {
                object obj = XState["CMargins"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["CMargins"] = value;
            }
        }


        /// <summary>
        /// 位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Position.Center)]
        [Description("位置")]
        public Position Position
        {
            get
            {
                object obj = XState["PositionType"];
                return obj == null ? Position.Center : (Position)obj;
            }
            set
            {
                XState["PositionType"] = value;
            }
        }

        /// <summary>
        /// Collapse Mode.
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(CollapseMode.Default)]
        [Description("Collapse Mode.")]
        public CollapseMode CollapseMode
        {
            get
            {
                object obj = XState["CollapseMode"];
                return obj == null ? CollapseMode.Default : (CollapseMode)obj;
            }
            set
            {
                XState["CollapseMode"] = value;
            }
        }


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
                if (!(Parent is RegionPanel))
                {
                    throw new Exception("Region control must be included in RegionPanel control.");
                }
            }

        }

        #endregion

        #region oldcode

        //private ControlBaseCollection _items;

        //[Category(CategoryName.OPTIONS)]
        //[NotifyParentProperty(true)]
        //[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        //public virtual ControlBaseCollection Items
        //{
        //    get
        //    {
        //        if (_items == null)
        //        {
        //            _items = new ControlBaseCollection(this);

        //            //if (base.IsTrackingViewState)
        //            //{
        //            //    ((IStateManager)_rows).TrackViewState();
        //            //}
        //        }
        //        return _items;
        //    }
        //}
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


            

            #region Options

            //// 默认Layout
            //OB.AddProperty(OptionName.Layout, LayoutTypeName.GetName(Layout));

            // 必须设置位置
            OB.AddProperty("region", PositionHelper.GetName(Position));

            if (!String.IsNullOrEmpty(Margins))
            {
                OB.AddProperty("margins", Margins);
            }

            if (Split)
            {
                OB.AddProperty("split", true);
            }

            if (EnableSplitTip)
            {
                OB.AddProperty("useSplitTips", true);
                if (EnableCollapse)
                {
                    if (!String.IsNullOrEmpty(CollapsibleSplitTip))
                    {
                        OB.AddProperty("collapsibleSplitTip", CollapsibleSplitTip);
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(SplitTip))
                    {
                        OB.AddProperty("splitTip", SplitTip);
                    }
                }
            }

            if (CollapseMode == CollapseMode.Mini)
            {
                OB.AddProperty("collapseMode", CollapseModeName.GetName(CollapseMode));

            }

            if (!String.IsNullOrEmpty(CMargins))
            {
                OB.AddProperty("cmargins", CMargins);
            }

            
            #endregion

            #region oldcode

            //if (!String.IsNullOrEmpty(ContentPlaceHolderId))
            //{
            //    // 取得ContentPlaceHolder
            //    Control hoderControl = ControlUtil.FindControl(Page, ContentPlaceHolderId);

            //    // Clear Items
            //    OB.RemoveProperty(OptionName.Items);

            //    // 内容页面的控件列表
            //    foreach (Control c in hoderControl.Controls)
            //    {
            //        ControlBase component = c as ControlBase;
            //        if (component != null)
            //        {
            //            component.RenderImmediately = false;
            //            component.RefParentControl = this;

            //            ExtAspNet.PanelBase panel = component as ExtAspNet.PanelBase;
            //            if (panel != null)
            //            {
            //                panel.AutoHeight = false;
            //                panel.AutoWidth = false;
            //            }
            //        }
            //    }

            //    AddItemsToOB(hoderControl.Controls);

            //    #region old code
            //    //// 这中改变控件层级的做法不对
            //    //// 取得 ContentPlaceHolder 下面的所有控件
            //    //List<ControlBase> componentList = new List<ControlBase>();
            //    //for (int i = 0, count = hoderControl.Controls.Count; i < count; i++)
            //    //{
            //    //    ControlBase component = hoderControl.Controls[i] as ControlBase;
            //    //    if (component != null)
            //    //    {
            //    //        componentList.Add(component);
            //    //    }
            //    //}

            //    //// 把这些控件添加到 本控件的子控件
            //    //foreach (ControlBase c in componentList)
            //    //{
            //    //    c.RenderImmediately = false;

            //    //    Controls.Add(c);
            //    //}

            //    //// Add Items
            //    //AddItemsToOB();

            //    #endregion
            //}

            #endregion

            #region oldcode

            //if (!String.IsNullOrEmpty(SplitColor))
            //{
            //    AddPageFirstLoadAbsoluteScript(String.Format("Ext.get('{0}-xsplit').setStyle('background-color','{1}');", ClientID, SplitColor), 1000);
            //}

            //string renderScript = String.Empty;

            //if (!String.IsNullOrEmpty(SplitColor))
            //{
            //    renderScript += String.Format("Ext.get('{0}-xsplit').setStyle('background-color','{1}');", ClientID, SplitColor);
            //}

            //OB.Listeners.AddProperty("render", "function(component){" + renderScript + "}", true);

            #endregion

            string jsContent = String.Format("var {0}=new Ext.Panel({1});", XID, OB.ToString());
            AddStartupScript(jsContent);


        }

        #endregion

        #region old code


        //#region ChildrenContentID

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[Description("子控件的容器的样式类（Tab用到了）")]
        //protected override string ChildrenContentClass
        //{
        //    get
        //    {
        //        return "x-hide-display";
        //    }
        //}

        //#endregion

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
