
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    PageManager.cs
 * CreatedOn:   2008-07-31
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
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Web;

namespace ExtAspNet
{
    /// <summary>
    /// 页面配置管理器（每个页面必须包含一个 PageManager 控件）
    /// </summary>
    [Designer(typeof(PageManagerDesigner))]
    [ToolboxData("<{0}:PageManager runat=\"server\"></{0}:PageManager>")]
    [ToolboxBitmap(typeof(PageManager), "res.toolbox.PageManager.bmp")]
    [Description("页面配置管理器（每个页面必须包含一个 PageManager 控件）")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class PageManager : ControlBase
    {
        #region Unsupported Properties

        ///// <summary>
        ///// 不支持此属性
        ///// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public override bool WrapperDisplayInline
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool Enabled
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool Hidden
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
        public override HideMode HideMode
        {
            get
            {
                return HideMode.Display;
            }
        }

        #endregion

        #region Properties

        #region old code


        // v1.2.9版本后不需要此属性，实现为JS的静态方法
        ///// <summary>
        ///// 向页面注册监视页面中表单内容改变的脚本
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("向页面注册监视页面中表单内容改变的脚本")]
        //public bool RegisterPageStateChangedScript
        //{
        //    get
        //    {
        //        object obj = BoxState["RegisterPageStateChangedScript"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["RegisterPageStateChangedScript"] = value;
        //    }
        //}


        // 内联样式表和Javascipt
        // 这两个没啥效果，干脆先去掉
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("启用内联的样式表和脚本引擎")]
        //public bool EnableInlineStyleJavascript
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableInlineStyleJavascript"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableInlineStyleJavascript"] = value;
        //    }
        //}
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("使用父页面的样式表和脚本引擎")]
        //public bool ApplyParentStyleJavascript
        //{
        //    get
        //    {
        //        object obj = BoxState["ApplyParentStyleJavascript"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["ApplyParentStyleJavascript"] = value;
        //    }
        //} 

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("启用设计时样式")]
        //public bool EnableDesignTimeStyle
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableDesignTimeStyle"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableDesignTimeStyle"] = value;
        //    }
        //}

        #endregion

        /// <summary>
        /// 自动调整此容器的宽度和高度，以填充整个页面
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("自动调整此容器的宽度和高度，以填充整个页面")]
        public string AutoSizePanelID
        {
            get
            {
                object obj = XState["AutoSizePanelID"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["AutoSizePanelID"] = value;
            }
        }

        /// <summary>
        /// 是否隐藏滚动条
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否隐藏滚动条")]
        [Obsolete("请使用 HideScrollbars 属性")]
        public bool HideScrollbar
        {
            get
            {
                return HideScrollbars;
            }
            set
            {
                HideScrollbars = value;
            }
        }


        /// <summary>
        /// 是否隐藏滚动条
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否隐藏滚动条")]
        public bool HideScrollbars
        {
            get
            {
                object obj = XState["HideScrollbars"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["HideScrollbars"] = value;
            }
        }

        /// <summary>
        /// 启用Asp.Net提交按钮（type=submit）的AJAX功能
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用Asp.Net提交按钮（type=submit）的AJAX功能")]
        public bool EnableAspnetSubmitButtonAjax
        {
            get
            {
                object obj = XState["EnableAspnetSubmitButtonAjax"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableAspnetSubmitButtonAjax"] = value;
            }
        }


        /// <summary>
        /// 每次页面回发时总是执行onReady脚本（包括Ajax局部回发）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("每次页面回发时总是执行onReady脚本（包括Ajax局部回发）")]
        public bool ExecuteOnReadyWhenPostBack
        {
            get
            {
                object obj = XState["ExecuteOnReadyWhenPostBack"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["ExecuteOnReadyWhenPostBack"] = value;
            }
        }


        /// <summary>
        /// 是否启用页面加载标示
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否启用页面加载标示")]
        public bool EnablePageLoading
        {
            get
            {
                object obj = XState["EnablePageLoading"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnablePageLoading"] = value;
            }
        }


        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("需要在AJAX回发时更新的Asp.net控件列表，逗号分隔")]
        [TypeConverter(typeof(StringArrayConverter))]
        public string[] AjaxAspnetControls
        {
            get
            {
                object obj = XState["AjaxAspnetControls"];
                return obj == null ? null : (string[])obj;
            }
            set
            {
                XState["AjaxAspnetControls"] = value;
            }
        }


        private List<string> _ajaxGridClientIDs = new List<string>();

        /// <summary>
        /// 本次AJAX请求过程中需要更新TemplateField的表格
        /// </summary>
        internal List<string> AjaxGridClientIDs
        {
            get
            {
                return _ajaxGridClientIDs;
            }
            set
            {
                _ajaxGridClientIDs = value;
            }
        }

        private List<string> _ajaxGridReloadedClientIDs = new List<string>();

        /// <summary>
        /// 本次AJAX请求过程中重新加载的表格
        /// </summary>
        internal List<string> AjaxGridReloadedClientIDs
        {
            get
            {
                return _ajaxGridReloadedClientIDs;
            }
            set
            {
                _ajaxGridReloadedClientIDs = value;
            }
        }


        #endregion

        #region config

        /// <summary>
        /// 样式
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Theme.Blue)]
        [Description("样式")]
        public Theme Theme
        {
            get
            {
                object obj = XState["Theme"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return Theme.Blue;
                    }
                    else
                    {
                        return GlobalConfig.GetTheme();
                    }
                }
                return (Theme)obj;
            }
            set
            {
                XState["Theme"] = value;
            }
        }

        /// <summary>
        /// 自定义样式的根路径
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("自定义样式的根路径")]
        public string CustomThemeBasePath
        {
            get
            {
                object obj = XState["CustomThemeBasePath"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return "";
                    }
                    else
                    {
                        return GlobalConfig.GetCustomThemeBasePath();
                    }
                }
                return obj.ToString();
            }
            set
            {
                XState["CustomThemeBasePath"] = value;
            }
        }


        /// <summary>
        /// 自定义样式的名称
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("自定义样式的名称")]
        public string CustomTheme
        {
            get
            {
                object obj = XState["CustomTheme"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return "";
                    }
                    else
                    {
                        return GlobalConfig.GetCustomTheme();
                    }
                }
                return obj.ToString();
            }
            set
            {
                XState["CustomTheme"] = value;
            }
        }


        /// <summary>
        /// 语言
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Language.ZH_CN)]
        [Description("语言")]
        public Language Language
        {
            get
            {
                object obj = XState["Language"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return Language.ZH_CN;
                    }
                    else
                    {
                        return GlobalConfig.GetLanguage();
                    }
                }
                return (Language)obj;
            }
            set
            {
                XState["Language"] = value;
            }
        }


        /// <summary>
        /// 表单中消息的位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(MsgTarget.Side)]
        [Description("表单中消息的位置")]
        public MsgTarget FormMessageTarget
        {
            get
            {
                object obj = XState["MsgTarget"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return MsgTarget.Side;
                    }
                    else
                    {
                        return GlobalConfig.GetFormMessageTarget();
                    }
                }
                return (MsgTarget)obj;
            }
            set
            {
                XState["MsgTarget"] = value;
            }
        }


        /// <summary>
        /// 表单中右侧的空白宽度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), ConfigPropertyValue.FORM_OFFSETRIGHT_DEFAULT_STRING)]
        [Description("表单中右侧的空白宽度")]
        public Unit FormOffsetRight
        {
            get
            {
                object obj = XState["FormOffsetRight"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return (Unit)ConfigPropertyValue.FORM_OFFSETRIGHT_DEFAULT;
                    }
                    else
                    {
                        return (Unit)GlobalConfig.GetFormOffsetRight();
                    }
                }
                return (Unit)obj;
            }
            set
            {
                XState["FormOffsetRight"] = value;
            }
        }


        /// <summary>
        /// 表单中字段标签的宽度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), ConfigPropertyValue.FORM_LABELWIDTH_DEFAULT_STRING)]
        [Description("表单中标签的宽度")]
        public Unit FormLabelWidth
        {
            get
            {
                object obj = XState["FormLabelWidth"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return (Unit)ConfigPropertyValue.FORM_LABELWIDTH_DEFAULT;
                    }
                    else
                    {
                        return (Unit)GlobalConfig.GetFormLabelWidth();
                    }
                }
                return (Unit)obj;
            }
            set
            {
                XState["FormLabelWidth"] = value;
            }
        }

        /// <summary>
        /// 表单中字段与标签的分隔符
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(String), ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT)]
        [Description("表单中字段与标签的分隔符")]
        public string FormLabelSeparator
        {
            get
            {
                object obj = XState["FormLabelSeparator"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT;
                    }
                    else
                    {
                        return GlobalConfig.GetFormLabelSeparator();
                    }
                }
                return (String)obj;
            }
            set
            {
                XState["FormLabelSeparator"] = value;
            }
        }


        /// <summary>
        /// 是否启用大字体
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否启用大字体")]
        public bool EnableBigFont
        {
            get
            {
                object obj = XState["EnableBigFont"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return false;
                    }
                    else
                    {
                        return GlobalConfig.GetEnableBigFont();
                    }
                }
                return (bool)obj;
            }
            set
            {
                XState["EnableBigFont"] = value;
            }
        }


        /// <summary>
        /// 是否启用Ajax
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否启用Ajax")]
        public override bool EnableAjax
        {
            get
            {
                object obj = XState["EnableAjax"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return true;
                    }
                    else
                    {
                        return GlobalConfig.GetEnableAjax();
                    }
                }
                return (bool)obj;
            }
            set
            {
                XState["EnableAjax"] = value;
            }
        }



        /// <summary>
        /// 是否启用Ajax正在加载提示
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否启用Ajax正在加载提示")]
        public new bool EnableAjaxLoading
        {
            get
            {
                object obj = XState["EnableAjaxLoading"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return true;
                    }
                    else
                    {
                        return GlobalConfig.GetEnableAjaxLoading();
                    }
                }
                return (bool)obj;
            }
            set
            {
                XState["EnableAjaxLoading"] = value;
            }
        }


        /// <summary>
        /// Ajax正在加载提示的类型
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue(AjaxLoadingType.Default)]
        [Description("Ajax正在加载提示的类型")]
        public new AjaxLoadingType AjaxLoadingType
        {
            get
            {
                object obj = XState["AjaxLoadingType"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return AjaxLoadingType.Default;
                    }
                    else
                    {
                        return GlobalConfig.GetAjaxLoadingType();
                    }
                }
                return (AjaxLoadingType)obj;
            }
            set
            {
                XState["AjaxLoadingType"] = value;
            }
        }


        /// <summary>
        /// Ajax超时时间（单位：秒，默认：60秒）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(ConfigPropertyValue.AJAX_TIMEOUT_DEFAULT)]
        [Description("Ajax超时时间（单位：秒，默认：60秒）")]
        public int AjaxTimeout
        {
            get
            {
                object obj = XState["AjaxTimeout"];
                if (obj == null)
                {
                    if (DesignMode)
                    {
                        return (int)ConfigPropertyValue.AJAX_TIMEOUT_DEFAULT;
                    }
                    else
                    {
                        return (int)GlobalConfig.GetAjaxTimeout();
                    }
                }
                return (int)obj;
            }
            set
            {
                XState["AjaxTimeout"] = value;
            }
        }

        #endregion

        #region PageLoadingControlExist

        /// <summary>
        /// PageLoading控件是否存在页面
        /// </summary>
        internal bool PageLoadingControlExist
        {
            get
            {
                Control loading = ControlUtil.FindControl(Page, typeof(PageLoading));
                return loading != null;
            }
        }

        #endregion

        #region RenderBeginTag/RenderEndTag

        protected override void RenderBeginTag(HtmlTextWriter writer)
        {
            if (!PageLoadingControlExist)
            {
                if (EnablePageLoading)
                {
                    string content = PageLoading.LOADING_TEMLATE;
                    content = content.Replace("#LOADING_IMAGE_SRC#", ResourceHelper.GetWebResourceUrl(Page, PageLoading.LOADING_IMAGE_NAME));

                    writer.Write(content);
                }
            }


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
            //if (PropertyModified("Readonly"))
            //{
            //    sb.AppendFormat("{0}.setReadOnly({1});", XID, Readonly.ToString().ToLower());
            //}

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            // 不渲染
            RenderWrapperNode = false;

            // 这个是必须的，2009-08-04
            // 因为每个页面都会有 PageManager 控件，每个页面要至少调用 GetPostBackEventReference 一次，以在页面产生 __doPostBack 函数。
            Page.ClientScript.GetPostBackEventReference(this, "");

            // Move it to ResourceManager.cs
            // 为页面的 Form 添加 autocomplete="off" 属性
            // 参考http://www.cnblogs.com/sanshi/archive/2009/09/04/1560146.html#1635830
            // Page.Form.Attributes["autocomplete"] = "off";

            #region HideScrollbars

            if (HideScrollbars)
            {
                //if (Page.Request.UserAgent.ToLower().Contains("msie"))
                //{
                //    //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "noscroll", String.Format("window.document.body.scroll='no';"), true);
                //    AddStartupAbsoluteScript("window.document.body.scroll='no';");
                //}
                //else
                //{
                //    //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "noscroll",  String.Format("window.document.body.style.overflow='hidden';"), true);
                //    AddStartupAbsoluteScript("window.document.body.style.overflow='hidden';");
                //}
                AddStartupAbsoluteScript("X.util.hideScrollbar();");
            }

            #endregion

            #region PageLoading
            
            

            if (!PageLoadingControlExist)
            {
                string jsContent = String.Empty;

                if (EnablePageLoading)
                {
                    jsContent += "X.util.removePageLoading(false);";
                }

                AddStartupAbsoluteScript(jsContent);
            }


            #endregion

            //#region EnableAjax

            //if (!EnableAjax)
            //{
            //    AddStartupAbsoluteScript("X.global_disable_ajax=true;");
            //}
 
            //#endregion

            #region AutoSizePanelID

            if (!String.IsNullOrEmpty(AutoSizePanelID))
            {
                PanelBase autosizePanel = ControlUtil.FindControl(Page.Form, AutoSizePanelID) as PanelBase;

                if (autosizePanel != null)
                {
                    #region oldcode
                    //string resizePanelScript = String.Empty;

                    //resizePanelScript += String.Format("{0}_resize_outerpanel=function(){{var panel=Ext.getCmp('{1}');panel.setSize(Ext.getBody().getSize());panel.doLayout();}};", ClientJavascriptID, panel.ClientID);
                    //resizePanelScript += String.Format("{0}_resize_outerpanel();", ClientJavascriptID);
                    //resizePanelScript += String.Format("if(Ext.isIE){{X.{0}_resize_outerpanel.defer(60);}}", ClientJavascriptID);
                    //resizePanelScript += String.Format("Ext.EventManager.onWindowResize(function(){{X.{0}_resize_outerpanel();}},box);", ClientJavascriptID);

                    //AddAbsoluteStartupScript(resizePanelScript);

                    // X._3=new Ext.FormViewport({renderTo:"RegionPanel1_wrapper",id:"RegionPanel1",layout:"border",items:[X._1,X._2],bodyStyle:"",border:false,animCollapse:false});

                    #endregion

                    // 子节点不向页面输出HTML，此PageManager向页面输出HTML
                    autosizePanel.RenderWrapperNode = false;
                    RenderWrapperNode = true;

                    OB.AddProperty("layout", "fit");
                    OB.AddProperty("border", false);
                    OB.AddProperty("items", String.Format("{0}", autosizePanel.XID), true);

                    string jsContent = String.Format("var {0}=new Ext.ux.FormViewport({1});", XID, OB.ToString());

                    AddStartupAbsoluteScript(jsContent);
                }
            }

            #endregion

            //if (EnableBigFont)
            //{
            //    AddStartupAbsoluteScript("Ext.getBody().addClass('bigfont');");
            //}

            #region oldcode

            // Move to X.util.init
            // Asp.Net Buttons(type="submit")
            // AddStartupAbsoluteScript("X.util.makeAspnetSubmitButtonAjax();");

            #endregion
        }

        #region old code

        //private PanelBase GetFirstPanelControl(ControlCollection controls)
        //{
        //    foreach (Control c in controls)
        //    {
        //        if (c is PanelBase)
        //        {
        //            return c as PanelBase;
        //        }
        //        else if (c.Controls != null && c.Controls.Count > 0)
        //        {
        //            PanelBase findPanel = GetFirstPanelControl(c.Controls);
        //            if (findPanel != null)
        //            {
        //                return findPanel;
        //            }
        //        }
        //    }

        //    return null;
        //} 

        #endregion

        #endregion

        #region Instance

        //// 这是一个严重的错误，不应该将_manager保存为全局变量，而是作为随页面存在的
        //private static PageManager _manager = null;
        public static PageManager Instance
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    if (HttpContext.Current.Items["PageManagerInstanceCached"] == null)
                    {
                        HttpContext.Current.Items["PageManagerInstanceCached"] = true;
                        HttpContext.Current.Items["PageManagerInstance"] = ControlUtil.FindControl(typeof(ExtAspNet.PageManager)) as PageManager;
                    }
                    return HttpContext.Current.Items["PageManagerInstance"] as PageManager;
                }
                // It's design time.
                return null;
            }
        }

        public static PageManager GetInstance(ISite site)
        {
            foreach (System.ComponentModel.IComponent c in site.Container.Components)
            {
                if (c is ExtAspNet.PageManager)
                {
                    return c as ExtAspNet.PageManager;
                }
            }
            return null;
        }

        //public static PageManager GetInstance(Page page)
        //{
        //    if (page == null)
        //    {
        //        page = HttpContext.Current.CurrentHandler as Page;
        //    }

        //    PageManager pageManager = ControlUtil.FindControl(page, typeof(ExtAspNet.PageManager)) as PageManager;
        //    if (pageManager == null)
        //    {
        //        throw new Exception("每个页面必须包含一个PageManager控件。");
        //    }

        //    return pageManager;
        //}

        #endregion

        #region BeforeAjaxPostBackScript

        private List<string> beforeAjaxPostBackScriptKeys = new List<string>();

        private string beforeAjaxPostBackScript = String.Empty;

        internal string BeforeAjaxPostBackScript
        {
            get { return beforeAjaxPostBackScript; }
            set { beforeAjaxPostBackScript = value; }
        }

        /// <summary>
        /// Used by FCKeditor, Add script before ajax postback.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="script"></param>
        public void RegisterOnAjaxPostBack(string key, string script)
        {
            if (!beforeAjaxPostBackScriptKeys.Contains(key))
            {
                beforeAjaxPostBackScriptKeys.Add(key);
                BeforeAjaxPostBackScript += script;
            }
        }

        #endregion
    }
}
