
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

using Nii.JSON;
using System.Web.UI.HtmlControls;


namespace ExtAspNet
{
    [ToolboxItem(false)]
    [Description("页面布局子控件")]
    [ToolboxData("<{0}:Region Position=\"Center\" runat=\"server\"></{0}:Region>")]
    [ParseChildren(true, "Items")]
    [PersistChildren(true)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    internal class Region : CollapsablePanel
    {
        #region override properties

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

        #region properties

        //private string ContentPlaceHolderId_Default = "";

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("ContentPlaceHolderId")]
        //public string ContentPlaceHolderId
        //{
        //    get
        //    {
        //        object obj = ViewState["ContentPlaceHolderId"];
        //        return obj == null ? ContentPlaceHolderId_Default : (string)obj;
        //    }
        //    set
        //    {
        //        ViewState["ContentPlaceHolderId"] = value;
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
                object obj = ViewState["Split"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                ViewState["Split"] = value;
            }
        }


        /// <summary>
        /// 分隔符的颜色
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("分隔符的颜色")]
        public string SplitColor
        {
            get
            {
                object obj = ViewState["SplitColor"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                ViewState["SplitColor"] = value;
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
                object obj = ViewState["Margins"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                ViewState["Margins"] = value;
            }
        }


        /// <summary>
        /// 位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(PositionType.Center)]
        [Description("位置")]
        public PositionType Position
        {
            get
            {
                object obj = ViewState["PositionType"];
                return obj == null ? PositionType.Center : (PositionType)obj;
            }
            set
            {
                ViewState["PositionType"] = value;
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

            if (Parent is PageLayout || Parent is BorderLayout)
            {
                // 正确
            }
            else
            {
                throw new Exception("Region 控件必须包含在 PageLayout 或 BorderLayout  中。");
            }

        }

        #endregion

        #region Items

        private ControlBaseCollection _items;

        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public virtual ControlBaseCollection Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new ControlBaseCollection(this);

                    //if (base.IsTrackingViewState)
                    //{
                    //    ((IStateManager)_rows).TrackViewState();
                    //}
                }
                return _items;
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

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            // Add Options

            #region Options

            //// 默认Layout
            //OB.AddProperty(OptionName.Layout, LayoutTypeName.GetName(Layout));

            // 必须设置位置
            OB.AddProperty(OptionName.Region, PositionTypeName.GetName(Position));

            if (!String.IsNullOrEmpty(Margins)) OB.AddProperty(OptionName.Margins, Margins);

            if (Split) OB.AddProperty(OptionName.Split, true);



            #endregion

            #region ContentPlaceHolderId

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




            #region renderScript

            if (!String.IsNullOrEmpty(SplitColor))
            {
                AddAbsoluteStartupScript(String.Format("Ext.get('{0}-xsplit').setStyle('background-color','{1}');", ClientID, SplitColor));
            }

            //string renderScript = String.Empty;

            //if (!String.IsNullOrEmpty(SplitColor))
            //{
            //    renderScript += String.Format("Ext.get('{0}-xsplit').setStyle('background-color','{1}');", ClientID, SplitColor);
            //}

            //OB.Listeners.AddProperty("render", "function(component){" + renderScript + "}", true);

            #endregion

            string jsContent = String.Format("box.{0}=new Ext.Panel({1});", ClientJavascriptID, OB.ToString());
            RegisterControlStartupScript(jsContent);


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
