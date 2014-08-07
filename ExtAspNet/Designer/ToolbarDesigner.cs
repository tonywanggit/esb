
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    PanelDesigner.cs
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
   
    public class ToolbarDesigner : ControlBaseDesigner
    {

        #region CurrentControl

        /// <summary>
        /// Current Control
        /// </summary>
        public new Toolbar CurrentControl
        {
            get
            {
                return base.CurrentControl as Toolbar;
            }
        }

        #endregion

        #region GetDesignTimeHtml

        public override string GetDesignTimeHtml(DesignerRegionCollection regions)
        {
            EditableDesignerRegion editableRegion = new EditableDesignerRegion(this, "Content", true);
            regions.Add(editableRegion);

            string content = String.Format("<div {0}='{1}'>{2}</div>",
                DesignerRegion.DesignerRegionAttributeName, 0, GetEditableDesignerRegionContent(editableRegion));

            return content;
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

       
    }
}
