
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    WindowDesigner.cs
 * CreatedOn:   2008-05-20
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
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExtAspNet
{

    public class WindowDesigner : ControlBaseDesigner
    {

        #region CurrentControl

        /// <summary>
        /// Current Control
        /// </summary>
        public new Window CurrentControl
        {
            get
            {
                return base.CurrentControl as Window;
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

        //private static readonly string WINDOW_TEMPLATE = "<div class='x-window x-resizable-pinned' style='#DIV_WIDTH# display: block;'><div class='x-window-tl'><div class='x-window-tr'><div class='x-window-tc'><div class='x-window-header x-unselectable x-window-draggable' style='-moz-user-select: none;'>#TOOL_CLOSE_HTML# #TOOL_COLLAPSE_HTML#<span class='x-window-header-text'>#TITLE#</span></div></div></div></div><div class='x-window-bwrap'><div class='x-window-ml'><div class='x-window-mr'><div class='x-window-mc'><div class='x-window-body' style='#BODY_PADDING# #CONTENT_WIDTH# #CONTENT_HEIGHT#'>#DESIGNER_REGION_EDITABLE#</div></div></div></div><div class='x-window-bl x-panel-nofooter'><div class='x-window-br'><div class='x-window-bc'/></div></div></div></div></div>";

        //private static readonly string TOOL_CLOSE_HTML = "<div class='x-tool x-tool-close'></div>";
        //private static readonly string TOOL_COLLAPSE_HTML = "<div class='x-tool x-tool-toggle'></div>";

        //#endregion

        //#region CurrentControl

        ///// <summary>
        ///// Current Control
        ///// </summary>
        //public new Window CurrentControl
        //{
        //    get
        //    {
        //        return base.CurrentControl as Window;
        //    }
        //}

        //#endregion

        //#region GetDesignTimeHtml

        //public override string GetDesignTimeHtml(DesignerRegionCollection regions)
        //{
        //    string content = ResolveTemplateHtml();

        //    EditableDesignerRegion editableRegion = new EditableDesignerRegion(this, "Content", false);
        //    regions.Add(editableRegion);

        //    content = content.Replace("#DESIGNER_REGION_EDITABLE#", String.Format("<div {0}='{1}'>{2}</div>",
        //        DesignerRegion.DesignerRegionAttributeName, 0, GetEditableDesignerRegionContent(editableRegion)));

        //    return content;
        //}


        //private string ResolveTemplateHtml()
        //{
        //    //Window control = CurrentControl as Window;
        //    //string htmlTemplate = htmlTemplate = "<input type=\"text\" value=\"{0}\" />";
        //    //return String.Format(htmlTemplate, control.SelectedDate == null ? String.Empty : control.SelectedDate.Value.ToString(control.DateFormatString));

        //    Window control = CurrentControl;

        //    string content = WINDOW_TEMPLATE;

        //    // 内容高度/宽度需要减少的值
        //    int contentHeightReduceValue = 32;
        //    int contentWidthReduceValue = 14;

        //    #region Title

        //    if (!String.IsNullOrEmpty(control.Title))
        //    {
        //        content = content.Replace("#TITLE#", control.Title);
        //    }
        //    else
        //    {
        //        content = content.Replace("#TITLE#", String.Format("[{0}]", CurrentControl.ID));
        //    }
        //    #endregion

        //    #region EnableCollapse/EnableClose

        //    if (control.EnableCollapse)
        //    {
        //        content = content.Replace("#TOOL_COLLAPSE_HTML#", TOOL_COLLAPSE_HTML);
        //    }
        //    else
        //    {
        //        content = content.Replace("#TOOL_COLLAPSE_HTML#", String.Empty);
        //    }

        //    if (control.EnableClose)
        //    {
        //        content = content.Replace("#TOOL_CLOSE_HTML#", TOOL_CLOSE_HTML);
        //    }
        //    else
        //    {
        //        content = content.Replace("#TOOL_CLOSE_HTML#", String.Empty);
        //    }

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
