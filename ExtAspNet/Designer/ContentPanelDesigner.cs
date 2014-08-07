
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    ContentPanelDesigner.cs
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
using System.Text;
using System.ComponentModel.Design;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;

namespace ExtAspNet
{

    public class ContentPanelDesigner : ControlBaseDesigner
    {

        #region CurrentControl

        /// <summary>
        /// Current Control
        /// </summary>
        public new ContentPanel CurrentControl
        {
            get
            {
                return base.CurrentControl as ContentPanel;
            }
        }

        #endregion

        #region GetDesignTimeHtml

        public override string GetDesignTimeHtml(DesignerRegionCollection regions)
        {
            EditableDesignerRegion editableRegion = new EditableDesignerRegion(this, "Content", false);
            regions.Add(editableRegion);

            string content = String.Format("<div {0}='{1}'>{2}</div>",
                DesignerRegion.DesignerRegionAttributeName, 0, GetEditableDesignerRegionContent(editableRegion));

            string title = CurrentControl.Title;
            if (String.IsNullOrEmpty(title))
            {
                title = String.Format("[{0}]", CurrentControl.ID);
            }

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

                foreach (Control c in CurrentControl.Controls)
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
                for (int i = 0, length = parsedControls.Length; i < length; i++)
                {
                    Control c = parsedControls[i] as Control;

                    if (c != null)
                    {
                        CurrentControl.Controls.Add(c);
                    }
                }
            }
        }

        #endregion


    }
}
