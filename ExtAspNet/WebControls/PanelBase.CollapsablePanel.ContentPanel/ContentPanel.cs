
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    ContentPanel.cs
 * CreatedOn:   2008-05-30
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
    /// 容器面板控件
    /// </summary>
    [Designer(typeof(ContentPanelDesigner))]
    [ToolboxData("<{0}:ContentPanel Title=\"ContentPanel\" BodyPadding=\"5px\" ShowHeader=\"true\" ShowBorder=\"true\" EnableBackgroundColor=\"true\" runat=\"server\"></{0}:ContentPanel>")]
    [ToolboxBitmap(typeof(ContentPanel), "res.toolbox.ContentPanel.bmp")]
    [Description("容器面板控件")]
    [ParseChildren(false)]
    [PersistChildren(true)]
    public class ContentPanel : CollapsablePanel
    {
        #region Unsupported Properties

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
        [DefaultValue(Layout.Container)]
        [Description("布局类型")]
        public override Layout Layout
        {
            get
            {
                return Layout.Container;
            }
        }


        ///// <summary>
        ///// 是否显示边框
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否显示边框")]
        //public override bool ShowBorder
        //{
        //    get
        //    {
        //        object obj = BoxState["Border"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["Border"] = value;
        //    }
        //}


        ///// <summary>
        ///// 是否显示标题栏
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否显示标题栏")]
        //public override bool ShowHeader
        //{
        //    get
        //    {
        //        object obj = BoxState["ShowHeader"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["ShowHeader"] = value;
        //    }
        //}

        #endregion

        #region internal RenderChildrenAsContent

        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("渲染子控件为容器内容")]
        internal override bool RenderChildrenAsContent
        {
            get
            {
                return true;
            }
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


            
            string jsContent = String.Format("var {0}=new Ext.Panel({1});", XID, OB.ToString());
            AddStartupScript(jsContent);

        }

        #endregion

        #region old code

        //#region Content

        //private HtmlGenericControl _contentControl;
        ///// <summary>
        ///// 创建的Content控件
        ///// </summary>
        //protected HtmlGenericControl ContentControl
        //{
        //    get
        //    {
        //        if (_contentControl == null)
        //        {
        //            _contentControl = new HtmlGenericControl("div");
        //            _contentControl.ID = "content";

        //            _content.InstantiateIn(_contentControl);
        //        }

        //        return _contentControl;
        //    }
        //}

        //private ITemplate _content;

        //[Category(CategoryName.OPTIONS)]
        //[Description("面板内容")]
        //[TemplateInstance(TemplateInstance.Single)]
        //[Browsable(false)]
        //[DefaultValue("")]
        //[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        //public virtual ITemplate Content
        //{
        //    get
        //    {
        //        if (_content == null)
        //        {
        //            throw new Exception("必须设置 Content 属性。");
        //        }
        //        return _content;
        //    }
        //    set
        //    {
        //        _content = value;
        //    }
        //}

        //#endregion

        //#region CreateChildControls

        //protected override void CreateChildControls()
        //{
        //    base.CreateChildControls();

        //    // Content
        //    if (Content != null)
        //    {
        //        Controls.Add(ContentControl);
        //    }
        //}

        //#endregion 

        #endregion
    }
}
