
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    RegionPanel.cs
 * CreatedOn:   2008-08-14
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
    [Designer(typeof(RegionPanelDesigner))]
    [ToolboxData("<{0}:RegionPanel ShowBorder=\"false\" runat=\"server\"><Regions><{0}:Region Split=\"true\" Width=\"200px\" ShowHeader=\"true\" Title=\"Left Region\" Position=\"Left\" runat=\"server\"></{0}:Region><{0}:Region Title=\"Center Region\" Position=\"Center\" ShowHeader=\"true\" runat=\"server\"></{0}:Region></Regions></{0}:RegionPanel>")]
    [ToolboxBitmap(typeof(RegionPanel), "res.toolbox.RegionPanel.bmp")]
    [Description("布局控件")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class RegionPanel : PanelBase
    {
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
        [DefaultValue(Layout.Border)]
        [Description("布局类型")]
        public override Layout Layout
        {
            get
            {
                return Layout.Border;
            }
        }


        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[Description("设置Wrapper的Display=inline")]
        //public override bool WrapperDisplayInline
        //{
        //    get
        //    {
        //        return true;
        //    }
        //}


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
        [PersistenceMode(PersistenceMode.InnerProperty)]
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



            #region Regions

            if (Regions.Count > 0)
            {
                JsArrayBuilder ab = new JsArrayBuilder();
                foreach (Region item in Regions)
                {
                    if (item.Visible)
                    {
                        ab.AddProperty(String.Format("{0}", item.XID), true);
                    }
                }

                OB.AddProperty("items", ab.ToString(), true);
            }

            #endregion


            string jsContent = String.Format("var {0}=new Ext.Panel({1});", XID, OB.ToString());

            AddStartupScript(jsContent);

        }

        #endregion

    }
}
