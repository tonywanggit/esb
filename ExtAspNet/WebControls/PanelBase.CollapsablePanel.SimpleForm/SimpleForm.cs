
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    SimpleForm.cs
 * CreatedOn:   2008-04-22
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
    /// 简单的表单容器控件
    /// </summary>
    [Designer(typeof(CollapsablePanelDesigner))]
    [ToolboxData("<{0}:SimpleForm Title=\"SimpleForm\" BodyPadding=\"5px\" EnableBackgroundColor=\"true\" runat=server><Items></Items></{0}:SimpleForm>")]
    [ToolboxBitmap(typeof(SimpleForm), "res.toolbox.SimpleForm.bmp")]
    [Description("简单的表单容器控件")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class SimpleForm : CollapsablePanel
    {
        #region Constructor

        public SimpleForm()
        {
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
        /// [只读]布局类型
        /// </summary>
        [ReadOnly(true)]
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(Layout.Anchor)]
        [Description("布局类型")]
        public override Layout Layout
        {
            get
            {
                return Layout.Form;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// 标签的宽度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        //[DefaultValue(typeof(Unit), ConfigPropertyValue.FORM_LABELWIDTH_DEFAULT_STRING)]
        [Description("标签的宽度")]
        public Unit LabelWidth
        {
            get
            {
                object obj = XState["LabelWidth"];
                if (obj == null)
                {
                    //return (Unit)ConfigPropertyValue.FORM_LABELWIDTH_DEFAULT;
                    return PageManager.Instance.FormLabelWidth;
                }
                return (Unit)obj;
            }
            set
            {
                XState["LabelWidth"] = value;
            }
        }

        /// <summary>
        /// 标签与字段的分隔符
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        //[DefaultValue(typeof(String), ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT)]
        [Description("标签与字段的分隔符")]
        public String LabelSeparator
        {
            get
            {
                object obj = XState["LabelSeparator"];
                if (obj == null)
                {
                    //return ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT;
                    return PageManager.Instance.FormLabelSeparator;
                }
                return obj.ToString();
            }
            set
            {
                XState["LabelSeparator"] = value;
            }
        }

        /// <summary>
        /// 距离右侧边界的宽度
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        //[DefaultValue(typeof(Unit), ConfigPropertyValue.FORM_OFFSETRIGHT_DEFAULT_STRING)]
        [Description("距离右侧边界的宽度")]
        public Unit OffsetRight
        {
            get
            {
                object obj = XState["OffsetRight"];
                if (obj == null)
                {
                    return (Unit)PageManager.Instance.FormOffsetRight;
                }
                return (Unit)obj;
            }
            set
            {
                XState["OffsetRight"] = value;
            }
        }


        /// <summary>
        /// 标签的位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(LabelAlign.Left)]
        [Description("标签的位置")]
        public LabelAlign LabelAlign
        {
            get
            {
                object obj = XState["LabelAlign"];
                return obj == null ? LabelAlign.Left : (LabelAlign)obj;
            }
            set
            {
                XState["LabelAlign"] = value;
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

            ResourceManager.Instance.AddJavaScriptComponent("form");

            #region Options

            //JsObjectBuilder fieldDefaults = new JsObjectBuilder();
            if (LabelWidth.Value != ConfigPropertyValue.FORM_LABELWIDTH_DEFAULT)
            {
                OB.AddProperty("labelWidth", LabelWidth.Value);
            }
            if (LabelSeparator != ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT)
            {
                OB.AddProperty("labelSeparator", LabelSeparator);
            }

            if (LabelAlign != LabelAlign.Left)
            {
                OB.AddProperty("labelAlign", LabelAlignHelper.GetName(LabelAlign));
            }

            //if (fieldDefaults.Count > 0)
            //{
            //    OB.AddProperty("fieldDefaults", fieldDefaults);
            //}

            #region old code

            //// 如果存在Fields集合
            //if (Fields.Count > 0)
            //{
            //    JsArrayBuilder ab = new JsArrayBuilder();
            //    foreach (Field item in Fields)
            //    {
            //        ab.AddProperty(String.Format("{0}", item.ClientID), true);
            //    }
            //    OB.AddProperty(OptionName.Items, ab.ToString(), true);
            //} 

            #endregion

            #endregion

            #region Anchor

            //JsObjectBuilder defaults = new JsObjectBuilder();

            //if (OffsetRight.Value != ConfigPropertyValue.FORM_OFFSETRIGHT_DEFAULT)
            //{
            //    defaults.AddProperty("anchor", -OffsetRight.Value);
            //}
            //else if (PageManager.Instance.FormOffsetRight.Value != ConfigPropertyValue.FORM_OFFSETRIGHT_DEFAULT)
            //{
            //    defaults.AddProperty("anchor", -PageManager.Instance.FormOffsetRight.Value);
            //}
            //else
            //{
            //    defaults.AddProperty("anchor", "auto");
            //}

            //OB.AddProperty("defaults", defaults);

            #endregion


            OB.Listeners.AddProperty("change", JsHelper.GetFunction("X.util.setPageStateChanged();"), true); //this.doLayout();

            string jsContent = String.Format("var {0}=new Ext.Panel({1});", XID, OB.ToString());
            AddStartupScript(jsContent);


            #region old code

            //string doLayoutScript = String.Empty;

            //doLayoutScript += "\r\n";
            //if (Visible)
            //{
            //    doLayoutScript += String.Format("Ext.EventManager.onWindowResize(function(){{X.{0}.doLayout();}},box);", ClientJavascriptID);
            //}
            //AddAbsoluteStartupScript(doLayoutScript);

            #endregion
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
        //        }
        //        return _items;
        //    }
        //}

        //#endregion

        //#region CreateChildControls

        //protected override void CreateChildControls()
        //{
        //    base.CreateChildControls();


        //    //// 添加子控件
        //    //foreach (ControlBase item in Items)
        //    //{
        //    //    item.RenderWrapperDiv = false;
        //    //    Controls.Add(item);
        //    //}
        //}

        #endregion

        #region oldcode

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

        //#region Fields

        //private FieldCollection _fields;

        //[Category(CategoryName.OPTIONS)]
        //[NotifyParentProperty(true)]
        //[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        //[Browsable(false)]
        //[Description("表单字段集合")]
        //public virtual FieldCollection Fields
        //{
        //    get
        //    {
        //        if (_fields == null)
        //        {
        //            _fields = new FieldCollection();

        //            if (base.IsTrackingViewState)
        //            {
        //                ((IStateManager)_fields).TrackViewState();
        //            }
        //        }
        //        return _fields;
        //    }
        //}
        //#endregion 

        //#region SaveViewState/LoadViewState/TrackViewState

        //protected override object SaveViewState()
        //{
        //    object[] states = new object[] { base.SaveViewState(), ((IStateManager)Fields).SaveViewState() };

        //    return states;
        //}

        //protected override void LoadViewState(object savedState)
        //{
        //    if (savedState != null)
        //    {
        //        object[] states = (object[])savedState;

        //        base.LoadViewState(states[0]);

        //        ((IStateManager)Fields).LoadViewState(states[1]);
        //    }
        //}

        //protected override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    ((IStateManager)Fields).TrackViewState();
        //}

        //#endregion

        #endregion

    }
}
