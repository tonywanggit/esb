
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    ControlBaseDesigner.cs
 * CreatedOn:   2008-04-07
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->2008-04-11    sanshi.ustc@gmail.com  
 * 
 * 
 * 
 * 
 */

#endregion

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using System.Web.UI.WebControls;


namespace ExtAspNet
{
    /// <summary>
    /// 设计时支持
    /// </summary>
    public class ControlBaseDesigner : ControlDesigner
    {

        #region static

        //internal static readonly string PANEL_TEMPLATE = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"border: 2px solid #ccc;\" >" +
        //          "<tbody><tr><td style=\"background-color: #eee;padding:2px;\">{0}</td></tr>" +
        //          "<tr><td style=\"padding:2px;\">{1}</td></tr></tbody></table>";

        internal static readonly string PANEL_TEMPLATE =
            "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"border:1px solid #666;margin-bottom:5px;width:95%;\" >" +
                "<tbody>" +
                "<tr><td><div style=\"background-color:#bbb;padding:5px;\">{0}</div></td></tr>" +
                "<tr><td style=\"padding:0px;\">{1}</td></tr>" +
            "</tbody></table>";

        #endregion

        #region Properties

        private ControlBase currentControl;

        /// <summary>
        /// 当前呈现的控件
        /// </summary>
        internal ControlBase CurrentControl
        {
            get
            {
                return currentControl;
            }
        }


        ///// <summary>
        ///// 是否允许调整大小
        ///// </summary>
        //public override bool AllowResize
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}

        #endregion

        #region Initialize

        /// <summary>
        /// 初始化控件设计时
        /// </summary>
        /// <param name="component"></param>
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            currentControl = component as ControlBase;
        }

        #endregion

        #region GetDesignTimeHtml/GetErrorDesignTimeHtml

        /// <summary>
        /// 设计时展示
        /// </summary>
        /// <returns></returns>
        public override string GetDesignTimeHtml()
        {
            return base.GetDesignTimeHtml();
        }


        /// <summary>
        /// 出错时设计时显示
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override string GetErrorDesignTimeHtml(Exception ex)
        {
            return String.Format("{0}<br />Error Message:{1}", base.GetDesignTimeHtml(), ex.Message);
        }

        #endregion





        #region old code


        //public string GetWebResourceUrl(string resourceName)
        //{
        //    IServiceProvider site = base.Component.Site;
        //    string resourceUrl = string.Empty;
        //    if (site != null)
        //    {
        //        IResourceUrlGenerator service = (IResourceUrlGenerator)site.GetService(typeof(IResourceUrlGenerator));
        //        if (service != null)
        //        {
        //            resourceUrl = service.GetResourceUrl(base.Component.GetType(), resourceName);
        //        }
        //    }

        //    return resourceUrl;
        //}

        ///// <summary>
        ///// 取得空白图片的URL
        ///// </summary>
        ///// <returns></returns>
        //public string GetBlankImageUrl()
        //{
        //    return ResourceHelper.GetWebResourceUrl(Component.Site, ResourceManager.BLANK_IMAGE_RESOURCE_NAME);
        //}

        ///// <summary>
        ///// ActionLists
        ///// </summary>
        //public override DesignerActionListCollection ActionLists
        //{
        //    get
        //    {
        //        if (_actionLists == null)
        //        {
        //            _actionLists = new DesignerActionListCollection();
        //            _actionLists.Add(new ControlBaseActionList(base.Component));
        //        }
        //        return _actionLists;
        //    }
        //}


        //#region static readonly

        //public static readonly string DISABLED_HTML = " disabled='disabled' ";
        //public static readonly string CHECKED_HTML = " checked='checked' ";
        //public static readonly string DISABLED_CLASSNAME = "x-item-disabled";

        //#region 表单相关

        //// 表单相关
        //protected static readonly string FORM_ITEM_HTML = "<div style='padding-top:2px; border-bottom:solid 0px #eeeeee;'/><div class='x-form-item'>#FORM_ITEM_LABEL_HTML#<div style='padding-left: 2px;' class='x-form-element'>#FIELD_CONTENT#</div><div class='x-form-clear-left'/></div></div>";
        ////protected static readonly string FORM_ITEM_HTML = "<span style='padding:2px 0px; border-bottom:solid 0px #eeeeee;'/>#FORM_ITEM_LABEL_HTML#<span style='padding-left: 2px;'>#FIELD_CONTENT#</span></span><br/>";
        //protected static readonly string FORM_ITEM_LABEL_HTML = "<label class='x-form-item-label' style='width: #LABEL_WIDTH#;'>&nbsp;&nbsp;#LABEL_TEXT#</label>";
        ////protected static readonly string FORM_ITEM_LABEL_HTML = "<span style='width: #LABEL_WIDTH#;'>&nbsp;&nbsp;#LABEL_TEXT#</span>";
        //protected static readonly string FORM_ITEM_RED_STAR_HTML = "&nbsp;<span style='color:red;'>*</span>";

        ///// <summary>
        ///// 如果没有设置宽度，在设计时的缺省宽度
        ///// </summary>
        //protected static readonly int FIELD_DEFAULT_WIDTH_DESIGNTIME = 142;


        //// SimpleForm设计时，在最后增加一个空白行
        //protected static readonly string BLANK_LINK_HTML = "<br/>";

        //#endregion

        //#region 容器相关

        //// 容器相关
        //private static readonly string PANEL_TEMPLATE = "<div style='#DIV_WIDTH#' class='x-panel #PANEL_NOBORDER_CLASSNAME#'>#TITLE_BAR#<div class='x-panel-bwrap'><div style='#BODY_PADDING# #CONTENT_WIDTH# #CONTENT_HEIGHT#' class='x-panel-body #PANEL_BODY_NOHEADER_CLASSNAME# #PANEL_BODY_NOBORDER_CLASSNAME#'>{0}</div></div></div>";

        //// 容器相关 - 标题栏
        //private static readonly string TITLE_BAR_HTML = "<div style='-moz-user-select: none;' class='x-panel-header x-unselectable'>#COLLAPSED_ICON_HTML#<span class='x-panel-header-text'>#TITLE#</span></div>";

        //// 容器相关 - 折叠按钮
        //private static readonly string COLLAPSED_ICON_HTML = "<div class='x-tool x-tool-toggle'>&nbsp;</div>";


        //private static readonly string PANEL_BODY_NOHEADER_CLASSNAME = "x-panel-body-noheader";
        //private static readonly string PANEL_BODY_NOBORDER_CLASSNAME = "x-panel-body-noborder";

        //private static readonly string PANEL_NOBORDER_CLASSNAME = "x-panel-noborder";
        ////private static readonly string PANEL_COLLAPSED_CLASSNAME = "x-panel-collapsed";

        //#endregion

        //protected string GetDesignTimePanelHtml()
        //{
        //    CollapsablePanel control = CurrentControl as CollapsablePanel;

        //    string content = PANEL_TEMPLATE;

        //    // 内容高度/宽度需要减少的值
        //    int contentHeightReduceValue = 0;
        //    int contentWidthReduceValue = 0;

        //    #region titleBar

        //    string titleBar = TITLE_BAR_HTML;

        //    if (!String.IsNullOrEmpty(control.Title))
        //    {
        //        titleBar = titleBar.Replace("#TITLE#", control.Title);
        //    }
        //    else
        //    {
        //        titleBar = titleBar.Replace("#TITLE#", String.Format("[{0}]", CurrentControl.ID));
        //    }

        //    if (control.EnableCollapse)
        //    {
        //        titleBar = titleBar.Replace("#COLLAPSED_ICON_HTML#", COLLAPSED_ICON_HTML);
        //    }
        //    else
        //    {
        //        titleBar = titleBar.Replace("#COLLAPSED_ICON_HTML#", String.Empty);
        //    }
        //    #endregion

        //    #region ShowHeader

        //    if (control.ShowHeader)
        //    {
        //        content = content.Replace("#TITLE_BAR#", titleBar);
        //        content = content.Replace("#PANEL_BODY_NOHEADER_CLASSNAME#", String.Empty);

        //        //content = content.Replace("#CONTENT_HEIGHT#", String.Format("height: {0}px;", control.Height.Value - 37));
        //        contentHeightReduceValue += 27;
        //    }
        //    else
        //    {
        //        content = content.Replace("#TITLE_BAR#", String.Empty);
        //        content = content.Replace("#PANEL_BODY_NOHEADER_CLASSNAME#", PANEL_BODY_NOHEADER_CLASSNAME);

        //        //content = content.Replace("#CONTENT_HEIGHT#", String.Format("height: {0}px;", control.Height.Value - 10));
        //        contentHeightReduceValue += 0;
        //    }

        //    #endregion

        //    #region Collapsed

        //    // 不响应这个属性的改变
        //    //if (control.Collapsed)
        //    //{
        //    //    content = content.Replace("#PANEL_COLLAPSED_CLASSNAME#", PANEL_COLLAPSED_CLASSNAME);
        //    //    content = content.Replace("#CONTENT_COLLAPSED_STYLE#", CONTENT_COLLAPSED_STYLE);

        //    //    // 重新设置高度
        //    //    content = content.Replace("#CONTENT_HEIGHT#", String.Empty);
        //    //    content = content.Replace("#DIV_HEIGHT#", String.Empty);
        //    //}
        //    //else
        //    //{
        //    //    content = content.Replace("#PANEL_COLLAPSED_CLASSNAME#", String.Empty);
        //    //    content = content.Replace("#CONTENT_COLLAPSED_STYLE#", String.Empty);
        //    //}

        //    #endregion

        //    #region ShowBorder

        //    if (control.ShowBorder)
        //    {
        //        content = content.Replace("#PANEL_NOBORDER_CLASSNAME#", String.Empty);
        //        content = content.Replace("#PANEL_BODY_NOBORDER_CLASSNAME#", String.Empty);

        //        contentWidthReduceValue += 2;
        //        contentHeightReduceValue += 2;
        //    }
        //    else
        //    {
        //        content = content.Replace("#PANEL_NOBORDER_CLASSNAME#", PANEL_NOBORDER_CLASSNAME);
        //        content = content.Replace("#PANEL_BODY_NOBORDER_CLASSNAME#", PANEL_BODY_NOBORDER_CLASSNAME);
        //    }

        //    #endregion

        //    #region BodyPadding

        //    if (String.IsNullOrEmpty(control.BodyPadding))
        //    {
        //        content = content.Replace("#BODY_PADDING#", String.Empty);

        //        //content = content.Replace("#CONTENT_WIDTH#", String.Format("width: {0}px;", control.Width.Value - 2));
        //    }
        //    else
        //    {
        //        content = content.Replace("#BODY_PADDING#", String.Format("padding:{0};", control.BodyPadding));

        //        Rectangle paddingRect = StyleUtil.ResolvePadding(control.BodyPadding);

        //        contentWidthReduceValue += paddingRect.Left + paddingRect.Right;
        //        contentHeightReduceValue += paddingRect.Top + paddingRect.Bottom;
        //    }


        //    #endregion

        //    #region WIDTH/HEIGHT

        //    if (control.Width == Unit.Empty)
        //    {
        //        content = content.Replace("#DIV_WIDTH#", String.Empty);
        //        content = content.Replace("#CONTENT_WIDTH#", String.Empty);
        //    }
        //    else
        //    {
        //        content = content.Replace("#DIV_WIDTH#", String.Format("width: {0}px;", control.Width.Value));
        //        content = content.Replace("#CONTENT_WIDTH#", String.Format("width: {0}px;", control.Width.Value - contentWidthReduceValue));
        //    }

        //    if (control.Height == Unit.Empty)
        //    {
        //        content = content.Replace("#CONTENT_HEIGHT#", String.Empty);
        //    }
        //    else
        //    {
        //        content = content.Replace("#CONTENT_HEIGHT#", String.Format("height: {0}px;", control.Height.Value - contentHeightReduceValue));
        //    }

        //    #endregion

        //    return content;
        //}  


        ///// <summary>
        ///// 如果 Field 在Form表单中， 取得设计时HTML
        ///// </summary>
        ///// <param name="fieldHtml"></param>
        ///// <returns></returns>
        //protected string GetDesignTimeFormItemHtml(string fieldHtml)
        //{
        //    Field field = CurrentControl as Field;
        //    // 如果当前控件不是表单字段
        //    if (field == null)
        //    {
        //        return fieldHtml;
        //    }

        //    bool showLabel = field.ShowLabel;
        //    string labelText = field.Label;
        //    bool showRedStar = field.ShowRedStar;

        //    Unit labelWidth = (Unit)80;

        //    string labelHtml = String.Empty;

        //    if (showLabel)
        //    {
        //        labelHtml = FORM_ITEM_LABEL_HTML;

        //        if (showRedStar)
        //        {
        //            labelHtml = labelHtml.Replace("#LABEL_TEXT#", labelText + FORM_ITEM_RED_STAR_HTML);
        //        }
        //        else
        //        {
        //            labelHtml = labelHtml.Replace("#LABEL_TEXT#", labelText);
        //        }

        //        labelHtml = labelHtml.Replace("#LABEL_WIDTH#", String.Format("{0}px", labelWidth.Value));
        //    }

        //    string content = FORM_ITEM_HTML;

        //    //if (showLabel)
        //    //{
        //    //    content = content.Replace("#DIV_PADDING_LEFT#", String.Format("{0}px", labelWidth.Value));
        //    //}
        //    //else
        //    //{
        //    //    content = content.Replace("#DIV_PADDING_LEFT#", String.Format("{0}px", 0));
        //    //}
        //    //content = content.Replace("#DIV_PADDING_LEFT#", String.Format("{0}px", 2));

        //    content = content.Replace("#FORM_ITEM_LABEL_HTML#", labelHtml);
        //    content = content.Replace("#FIELD_CONTENT#", fieldHtml);

        //    return content;
        //}

        #endregion
    }
}

