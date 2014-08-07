
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    PageLayout.cs
 * CreatedOn:   2008-06-05
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
    /// <summary>
    /// 页面布局控件
    /// </summary>
    [Designer(typeof(PageLayoutDesigner))]
    [ToolboxData("<{0}:PageLayout runat=\"server\"></{0}:PageLayout>")]
    [ToolboxBitmap(typeof(PageLayout), "resources.toolbox_icons.PageLayout.bmp")]
    [Description("页面布局控件")]
    [ParseChildren(true, "Regions")]
    [PersistChildren(true)]
    internal class PageLayout : PanelBase
    {
        #region override properties

        /// <summary>
        /// 此属性不被支持
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
        /// 此属性不被支持
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
        /// 此属性不被支持
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
        [DefaultValue(LayoutType.Border)]
        [Description("布局类型")]
        public override LayoutType Layout
        {
            get
            {
                return LayoutType.Border;
            }
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("设置Wrapper的Display=inline")]
        public override bool WrapperDisplayInline
        {
            get
            {
                return false;
            }
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool AutoHeight
        {
            get
            {
                return false;
            }
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool AutoWidth
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Regions

        private RegionCollection _regions;

        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public virtual RegionCollection Regions
        {
            get
            {
                if (_regions == null)
                {
                    _regions = new RegionCollection(this);
                }
                return _regions;
            }
        }

        #endregion

        #region CreateChildControls

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            //foreach (Region region in Regions)
            //{
            //    region.RenderWrapperDiv = false;
            //    Controls.Add(region);
            //}
        }

        #endregion

        #region OnPreRender

        protected override void OnPreRender(EventArgs e)
        {
            // 不要生成html标签
            //RenderImmediately = false;

            base.OnPreRender(e);

            // Add Options
            #region old code

            //OB.AddProperty(OptionName.Items, String.Format("[{{region:'north',height:32}},{{region:'south',split:true,title:'South',collapsible:true,height:100,margins:'0 0 0 0'}},{{region:'west',collapsible:true,width:200}},{{region:'east',collapsible:true,width:200}},{{region:'center',collapsible:true}}]"), true);


            //if (!String.IsNullOrEmpty(ContainerID))
            //{
            //    Control control = ControlUtil.FindControl(Page, ContainerID);

            //    if (control != null)
            //    {
            //        OB.AddProperty("containerId", control.ClientID);
            //    }
            //}

            #endregion


            StringBuilder panelScriptBuilder = new StringBuilder();
            //panelScriptBuilder.Append("box.startPageLayoutDateTime=new Date();");
            panelScriptBuilder.AppendFormat("box.{0}=new Ext.FormViewport({1});",  ClientJavascriptID, OB.ToString());
            //panelScriptBuilder.Append("box.endPageLayoutDateTime=new Date();");

            //AddStartupScript(this, panelScriptBuilder.ToString());

            string jsContent = panelScriptBuilder.ToString();
            RegisterControlStartupScript(jsContent);
        }

        #endregion

        #region old code

        //#region SaveViewState/LoadViewState/TrackViewState

        //protected override object SaveViewState()
        //{
        //    object[] states = new object[] { base.SaveViewState(), ((IStateManager)Regions).SaveViewState() };

        //    return states;
        //}

        //protected override void LoadViewState(object savedState)
        //{
        //    if (savedState != null)
        //    {
        //        object[] states = (object[])savedState;

        //        base.LoadViewState(states[0]);

        //        ((IStateManager)Regions).LoadViewState(states[1]);
        //    }
        //}

        //protected override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    ((IStateManager)Regions).TrackViewState();
        //}

        //#endregion 

        #endregion

    }
}
