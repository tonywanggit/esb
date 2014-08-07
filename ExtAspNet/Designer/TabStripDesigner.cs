
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    TabStripDesigner.cs
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
using System.Text;
using System.ComponentModel.Design;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI.Design;
using System.Web.UI.HtmlControls;
using System.ComponentModel;

namespace ExtAspNet
{

    public class TabStripDesigner : ControlBaseDesigner
    {
        #region CurrentControl

        /// <summary>
        /// Current Control
        /// </summary>
        public new TabStrip CurrentControl
        {
            get
            {
                return base.CurrentControl as TabStrip;
            }
        }

        #endregion

        #region GetDesignTimeHtml

        public override string GetDesignTimeHtml(DesignerRegionCollection regions)
        {
            if (CurrentControl.Tabs.Count == 0)
            {
                return GetEmptyDesignTimeHtml();
            }


            // 1. Add tabs title list
            StringBuilder sb = new StringBuilder();
            int tabIndex = 0;
            foreach (Tab tab in CurrentControl.Tabs)
            {
                HtmlNodeBuilder nb = new HtmlNodeBuilder("div");

                if (!String.IsNullOrEmpty(tab.Title))
                {
                    nb.InnerProperty = tab.Title;
                }
                else
                {
                    nb.InnerProperty = String.Format("[{0}]", tab.ID);
                }

                string styleStr = "padding:0 5px;margin-right:5px;display:inline;";
                if (CurrentControl.ActiveTabIndex == tabIndex)
                {
                    styleStr += "background-color:#666;";
                }
                nb.SetProperty("style", styleStr);

                nb.SetProperty(DesignerRegion.DesignerRegionAttributeName, tabIndex.ToString());

                DesignerRegion region = new DesignerRegion(this, "Tab_" + tabIndex, true);
                region.Properties["TabIndex"] = tabIndex.ToString();
                regions.Add(region);

                sb.Append(nb.ToString());
                tabIndex++;
            }
            string tabsHtml = sb.ToString();


            // 2. Add current active tab content
            // Note: Currently, we have add (CurrentControl.Tabs.Count - 1) items into regions,
            // So This editable region's index is CurrentControl.Tabs.Count.
            EditableDesignerRegion editableRegion = new EditableDesignerRegion(this, "Content", true);
            regions.Add(editableRegion);
            //editableRegion.Properties["ActiveTabIndex"] = CurrentControl.ActiveTabIndex.ToString();

            string contentHtml = String.Format("<div {0}='{1}'>{2}</div>",
                 DesignerRegion.DesignerRegionAttributeName, CurrentControl.Tabs.Count, GetEditableDesignerRegionContent(editableRegion));

            return String.Format(PANEL_TEMPLATE, tabsHtml, contentHtml);
        }

        #endregion

        #region GetEditableDesignerRegionContent/SetEditableDesignerRegionContent

        public override string GetEditableDesignerRegionContent(EditableDesignerRegion region)
        {
            IDesignerHost service = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
            if (service != null)
            {
                if (region.Name == "Content")
                {
                    Tab tab = CurrentControl.Tabs[CurrentControl.ActiveTabIndex];

                    StringBuilder sb = new StringBuilder();
                    foreach (Control c in tab.Items)
                    {
                        sb.Append(ControlPersister.PersistControl(c, service));
                    }
                    return sb.ToString();

                    // return ControlPersister.PersistControl(CurrentControl.Tabs[CurrentControl.ActiveTabIndex], service);
                }
            }
            return String.Empty;
        }

        public override void SetEditableDesignerRegionContent(EditableDesignerRegion region, string content)
        {
            IDesignerHost service = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
            if (service != null)
            {
                if (region.Name == "Content")
                {
                    Tab tab = CurrentControl.Tabs[CurrentControl.ActiveTabIndex];

                    Control[] parsedControls = ControlParser.ParseControls(service, content);

                    tab.Items.Clear();
                    for (int i = 0, length = parsedControls.Length; i < length; i++)
                    {
                        ControlBase c = parsedControls[i] as ControlBase;
                        if (c != null)
                        {
                            tab.Items.Add(c);
                        }
                    }
                    //CurrentControl.Tabs[CurrentControl.ActiveTabIndex] = ControlParser.ParseControls(service, content)[0] as Tab;
                }
            }
        }

        #endregion

        #region OnClick

        protected override void OnClick(DesignerRegionMouseEventArgs e)
        {
            if (e.Region == null)
            {
                return;
            }

            // 点击的不是Tab标签
            if (!e.Region.Name.StartsWith("Tab_"))
            {
                return;
            }

            int regionTabIndex = Convert.ToInt32(e.Region.Properties["TabIndex"]);

            // 如果当前不是激活的Tab
            if (regionTabIndex != CurrentControl.ActiveTabIndex)
            {
                CurrentControl.ActiveTabIndex = regionTabIndex;

                UpdateDesignTimeHtml();
            }
        }

        #endregion

        #region GetEmptyDesignTimeHtml

        protected override string GetEmptyDesignTimeHtml()
        {
            //string content = TABPANEL_EMPTY_TEMPLATE;

            //if (CurrentControl.Width != Unit.Empty)
            //{
            //    content = content.Replace("#DIV_WIDTH#", String.Format(" width:{0}px; ", CurrentControl.Width.Value));
            //    content = content.Replace("#CONTENT_WIDTH#", String.Format(" width:{0}px; ", CurrentControl.Width.Value - 12));
            //}
            //else
            //{
            //    content = content.Replace("#DIV_WIDTH#", String.Empty);
            //    content = content.Replace("#CONTENT_WIDTH#", String.Empty);
            //}

            ////return HttpUtility.HtmlEncode(content) + content;
            //return content;

            return String.Format(PANEL_TEMPLATE, "", "Please add a tab.");
        }

        #endregion

        #region old code

        //private string ResolveTemplateHtml()
        //{
        //    //Window control = CurrentControl as Window;
        //    //string htmlTemplate = htmlTemplate = "<input type=\"text\" value=\"{0}\" />";
        //    //return String.Format(htmlTemplate, control.SelectedDate == null ? String.Empty : control.SelectedDate.Value.ToString(control.DateFormatString));

        //    TabStrip control = CurrentControl;

        //    string content = TABPANEL_TEMPLATE;

        //    // 内容高度/宽度需要减少的值
        //    int contentHeightReduceValue = 29;
        //    int contentWidthReduceValue = 2;

        //    #region BodyPadding

        //    //if (String.IsNullOrEmpty(control.BodyPadding))
        //    //{
        //    //    content = content.Replace("#BODY_PADDING#", String.Empty);
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
        //        content = content.Replace("#PANEL_HEADER_WIDTH#", String.Empty);
        //    }
        //    else
        //    {
        //        content = content.Replace("#DIV_WIDTH#", String.Format("width: {0}px;", control.Width.Value));
        //        content = content.Replace("#CONTENT_WIDTH#", String.Format("width: {0}px;", control.Width.Value - contentWidthReduceValue));
        //        content = content.Replace("#PANEL_HEADER_WIDTH#", String.Format("width: {0}px;", control.Width.Value - 2));
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

        //    #region TITLE_BAR_UL

        //    string titleBarContent = TITLE_BAR_UL;

        //    titleBarContent = titleBarContent.Replace("#LI_LIST#", BuildTabTitleList());

        //    content = content.Replace("#TITLE_BAR_UL#", titleBarContent);

        //    #endregion

        //    return content;
        //}



        //public string BuildTabTitleList()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    int tabIndex = 0;
        //    foreach (Tab tab in CurrentControl.Tabs)
        //    {
        //        string content = LI_TEMPLATE;

        //        if (!String.IsNullOrEmpty(tab.Title))
        //        {
        //            content = content.Replace("#TITLE#", tab.Title);
        //        }
        //        else
        //        {
        //            content = content.Replace("#TITLE#", String.Format("[{0}]", tab.ID));
        //        }

        //        if (CurrentControl.ActiveTabIndex == tabIndex)
        //        {
        //            content = content.Replace("#ACTIVE_CLASSNAME#", ACTIVE_CLASSNAME);
        //        }
        //        else
        //        {
        //            content = content.Replace("#ACTIVE_CLASSNAME#", String.Empty);
        //        }

        //        content = content.Replace("#DESIGNER_REGION_TAB#", String.Format(" {0}='{1}' ", DesignerRegion.DesignerRegionAttributeName, tabIndex));

        //        DesignerRegion region = new DesignerRegion(this, HEADER_REGION_NAME_PREFIX + tabIndex, true);
        //        _regions.Add(region);

        //        // 高亮的任务由样式做就行了
        //        //if (tabIndex == CurrentControl.ActiveTabIndex)
        //        //{
        //        //    region.Highlight = true;
        //        //}

        //        sb.Append(content);

        //        tabIndex++;
        //    }

        //    return sb.ToString();
        //}
        #endregion

        #region old code

        ///// <summary>
        ///// 空白模板
        ///// </summary>
        //private static readonly string TABPANEL_EMPTY_TEMPLATE = "<div style='#DIV_WIDTH#' class='x-tab-panel'><div class='x-tab-panel-header x-unselectable'></div><div class='x-tab-panel-bwrap'><div class='x-tab-panel-body x-tab-panel-body-top' style='padding: 5px; #CONTENT_WIDTH# height: 50px;'>请添加选项卡</div></div></div>";


        //private static readonly string TABPANEL_TEMPLATE = "<style type='text/css'>ul.x-tab-strip{display:block;width:100%;zoom:1;}</style><div style='#DIV_WIDTH#' class='x-tab-panel'><div style='mozuserselect: none; khtmluserselect: none; #PANEL_HEADER_WIDTH#' unselectable='on' class='x-tab-panel-header x-unselectable'><div class='x-tab-strip-wrap'>#TITLE_BAR_UL#</div><div class='x-tab-strip-spacer'></div></div><div class='x-tab-panel-bwrap'><div class='x-tab-panel-body x-tab-panel-body-top' style='#BODY_PADDING# #CONTENT_WIDTH# #CONTENT_HEIGHT#'>#DESIGNER_REGION_EDITABLE#</div></div></div>";
        //private static readonly string TITLE_BAR_UL = "<ul class='x-tab-strip x-tab-strip-top'>#LI_LIST#<li class='x-tab-edge'></li><div class='x-clear'></div></ul>";
        //private static readonly string LI_TEMPLATE = "<li class='#ACTIVE_CLASSNAME#'><a class='x-tab-right' href='#' onclick='return false;'><em class='x-tab-left'><span class='x-tab-strip-inner'><span class='x-tab-strip-text' #DESIGNER_REGION_TAB#>#TITLE#</span></span></em></a></li>";
        //private static readonly string ACTIVE_CLASSNAME = "x-tab-strip-active";
        //// <a class='x-tab-strip-close' onclick='return false;'></a>

        //private static readonly string HEADER_REGION_NAME_PREFIX = "TAB_";
        //private static readonly string CONTENT_REGION_NAME_PREFIX = "CONTENT_";

        #endregion

        #region old code

        ///// <summary>
        ///// 添加一个新的选项卡
        ///// </summary>
        //private void OnAddTabStrip()
        //{

        //    IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));
        //    if (host != null)
        //    {
        //        TabStrip tabPanel = CurrentControl;

        //        using (DesignerTransaction dt = host.CreateTransaction("Add new TabStrip"))
        //        {

        //            Tab tab = (Tab)host.CreateComponent(typeof(Tab));
        //            if (tab != null)
        //            {
        //                //tab.ID = GetUniqueName(typeof(TabStrip), tabPanel);
        //                tab.ID = "Tab" + CurrentControl.Tabs.Count.ToString();
        //                tab.Title = String.Format("[{0}]", tab.ID);
        //                IComponentChangeService changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));

        //                try
        //                {
        //                    changeService.OnComponentChanging(tabPanel, TypeDescriptor.GetProperties(tabPanel)["Tabs"]);
        //                    tabPanel.Tabs.Add(tab);
        //                }
        //                finally
        //                {
        //                    changeService.OnComponentChanged(tabPanel, TypeDescriptor.GetProperties(tabPanel)["Tabs"], tabPanel.Tabs, tabPanel.Tabs);
        //                }

        //                //TypeDescriptor.GetProperties(tabPanel)["ActiveTabIndex"].SetValue(tabPanel, tab);

        //                UpdateDesignTimeHtml();
        //            }
        //            dt.Commit();
        //        }
        //    }

        //}

        ///// <summary>
        ///// Helper to get a unique name.  Since our Tabs aren't onthe designer surface,
        ///// INamingSurface won't do the right thing.  Fortunately, it's easy.
        ///// </summary>
        ///// <returns>A unique name like "TabStrip3"</returns>
        //private static string GetUniqueName(Type t, System.Web.UI.Control parent)
        //{
        //    string baseName = t.Name;
        //    int count = 1;

        //    while (parent.FindControl(baseName + count.ToString(CultureInfo.InvariantCulture)) != null)
        //    {
        //        count++;
        //    }
        //    return baseName + count.ToString(CultureInfo.InvariantCulture);
        //}

        //private void OnRemoveTabStrip()
        //{
        //    TabContainer tc = TabContainer;
        //    if (tc.ActiveTab != null)
        //    {
        //        int oldIndex = tc.ActiveTabIndex;

        //        IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));

        //        if (host != null)
        //        {
        //            using (DesignerTransaction dt = host.CreateTransaction("Remove TabStrip"))
        //            {
        //                TabStrip activeTab = tc.ActiveTab;

        //                IComponentChangeService changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));

        //                try
        //                {
        //                    changeService.OnComponentChanging(tc, TypeDescriptor.GetProperties(tc)["Tabs"]);
        //                    tc.Tabs.Remove(activeTab);
        //                }
        //                finally
        //                {
        //                    changeService.OnComponentChanged(tc, TypeDescriptor.GetProperties(tc)["Tabs"], tc.Tabs, tc.Tabs);
        //                }

        //                activeTab.Dispose();

        //                if (tc.Tabs.Count > 0)
        //                {
        //                    TypeDescriptor.GetProperties(tc)["ActiveTabIndex"].SetValue(tc, Math.Min(oldIndex, tc.Tabs.Count - 1));
        //                }


        //                UpdateDesignTimeHtml();
        //                dt.Commit();
        //            }

        //        }
        //    }
        //} 
        #endregion

    }

}