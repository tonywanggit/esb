
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    GroupPanelDesigner.cs
 * CreatedOn:   2008-05-07
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
using System.ComponentModel.Design;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;

namespace ExtAspNet
{
   
    public class GroupPanelDesigner : ControlBaseDesigner
    {

        #region CurrentControl

        /// <summary>
        /// Current Control
        /// </summary>
        public new GroupPanel CurrentControl
        {
            get
            {
                return base.CurrentControl as GroupPanel;
            }
        }

        #endregion


        #region GetDesignTimeHtml

        public override string GetDesignTimeHtml(DesignerRegionCollection regions)
        {
            
            EditableDesignerRegion editableRegion = new EditableDesignerRegion(this, "Content", true);
            regions.Add(editableRegion);

            string title = CurrentControl.Title;
            if (String.IsNullOrEmpty(title))
            {
                title = String.Format("[{0}]", CurrentControl.ID);
            }
            string content = String.Format("<div {0}='{1}'>{2}</div>",
                DesignerRegion.DesignerRegionAttributeName, 0, GetEditableDesignerRegionContent(editableRegion));

            return String.Format(PANEL_TEMPLATE, title, content);
        }

        #endregion

        #region GetEditableDesignerRegionContent/SetEditableDesignerRegionContent

        public override string GetEditableDesignerRegionContent(EditableDesignerRegion region)
        {
            IDesignerHost service = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
            if (service != null)
            {
                StringBuilder sb = new StringBuilder();

                foreach (ControlBase c in CurrentControl.Items)
                {
                    sb.Append(ControlPersister.PersistControl(c, service));
                }

                return sb.ToString();
            }
            return String.Empty;
        }

        public override void SetEditableDesignerRegionContent(EditableDesignerRegion region, string content)
        {
            IDesignerHost service = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
            if (service != null)
            {
                Control[] parsedControls = ControlParser.ParseControls(service, content);

                CurrentControl.Controls.Clear();
                CurrentControl.Items.Clear();
                for (int i = 0, length = parsedControls.Length; i < length; i++)
                {
                    ControlBase c = parsedControls[i] as ControlBase;

                    if (c != null)
                    {
                        CurrentControl.Items.Add(c);
                    }
                }
            }
        }

        #endregion

        #region old code

        //#region static readonly

        //private static readonly string GROUPPANEL_TEMPLATE = "<FIELDSET class='x-fieldset' style='#DIV_WIDTH#'>#LEGEND_HTML#<DIV class=x-fieldset-bwrap><DIV class=x-fieldset-body style='#BODY_PADDING# #CONTENT_WIDTH# #CONTENT_HEIGHT#'>#DESIGNER_REGION_EDITABLE#</DIV></DIV></FIELDSET>";

        //// 标题栏
        //private static readonly string LEGEND_HTML = "<LEGEND class='x-fieldset-header x-unselectable' style='MozUserSelect: none; KhtmlUserSelect: none' unselectable='on'>#COLLAPSED_ICON_HTML#<SPAN class=x-fieldset-header-text>#TITLE#</SPAN></LEGEND>";

        ////private static readonly string COLLAPSED_ICON_HTML = "<DIV class='x-tool x-tool-toggle'>&nbsp;</DIV>";
        //private static readonly string COLLAPSED_ICON_HTML = "<span>▲&nbsp;</span>";

        //#endregion

        //#region CurrentControl

        ///// <summary>
        ///// Current Control
        ///// </summary>
        //public new GroupPanel CurrentControl
        //{
        //    get
        //    {
        //        return base.CurrentControl as GroupPanel;
        //    }
        //}

        //#endregion

        //#region GetDesignTimeHtml

        //#region GetDesignTimeHtml

        //public override string GetDesignTimeHtml(DesignerRegionCollection regions)
        //{
        //    string content = ResolveTemplateHtml();


        //    EditableDesignerRegion editableRegion = new EditableDesignerRegion(this, "Content", false);
        //    regions.Add(editableRegion);

        //    content = content.Replace("#DESIGNER_REGION_EDITABLE#", String.Format("<div {0}='{1}'>{2}</div>",
        //        DesignerRegion.DesignerRegionAttributeName, 0, GetEditableDesignerRegionContent(editableRegion)));

        //    //return HttpUtility.HtmlEncode(content) + content;
        //    return content;
        //}
        //#endregion

        //#region ResolveTemplateHtml

        //private string ResolveTemplateHtml()
        //{
        //    GroupPanel control = CurrentControl;

        //    string content = GROUPPANEL_TEMPLATE;

        //    // 内容高度/宽度需要减少的值
        //    int contentHeightReduceValue = 27;
        //    int contentWidthReduceValue = 22;

        //    #region titleBar

        //    string titleBar = LEGEND_HTML;

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

        //    content = content.Replace("#LEGEND_HTML#", titleBar);
        //    #endregion

        //    #region BodyPadding

        //    //if (String.IsNullOrEmpty(control.BodyPadding))
        //    //{
        //    //    content = content.Replace("#BODY_PADDING#", String.Empty);

        //    //    //content = content.Replace("#CONTENT_WIDTH#", String.Format("width: {0}px;", control.Width.Value - 2));
        //    //}
        //    //else
        //    //{
        //    //    content = content.Replace("#BODY_PADDING#", String.Format("padding:{0};", control.BodyPadding));

        //    //    Rectangle paddingRect = StyleUtil.ResolvePadding(control.BodyPadding);

        //    //    contentWidthReduceValue += paddingRect.Left + paddingRect.Right;
        //    //    contentHeightReduceValue += paddingRect.Top + paddingRect.Bottom;
        //    //}


        //    #endregion

        //    #region WIDTH/HEIGHT

        //    if (control.Width == Unit.Empty)
        //    {
        //        content = content.Replace("#DIV_WIDTH#", String.Empty);
        //        content = content.Replace("#CONTENT_WIDTH#", String.Empty);
        //    }
        //    else
        //    {
        //        content = content.Replace("#DIV_WIDTH#", String.Format("width: {0}px;", control.Width.Value - contentWidthReduceValue));
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
        //#endregion

        //#endregion

        //#region GetEditableDesignerRegionContent/SetEditableDesignerRegionContent

        //public override string GetEditableDesignerRegionContent(EditableDesignerRegion region)
        //{
        //    IDesignerHost service = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
        //    if (service != null)
        //    {
        //        StringBuilder sb = new StringBuilder();

        //        foreach (ControlBase c in CurrentControl.Rows)
        //        {
        //            sb.Append(ControlPersister.PersistControl(c, service));
        //        }

        //        return sb.ToString();
        //    }
        //    return String.Empty;
        //}

        //public override void SetEditableDesignerRegionContent(EditableDesignerRegion region, string content)
        //{
        //    IDesignerHost service = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
        //    if (service != null)
        //    {
        //        Control[] parsedControls = ControlParser.ParseControls(service, content);

        //        CurrentControl.Rows.Clear();
        //        for (int i = 0, length = parsedControls.Length; i < length; i++)
        //        {
        //            ControlBase c = parsedControls[i] as ControlBase;

        //            if (c != null)
        //            {
        //                CurrentControl.Rows.Add(c);
        //            }
        //        }
        //    }
        //}
        //#endregion 

        #endregion

      
    }
}
