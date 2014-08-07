
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    CollapsablePanelDesigner.cs
 * CreatedOn:   2009-11-12
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

    public class CollapsablePanelDesigner : ControlBaseDesigner
    {

        //internal static readonly string PANEL_TEMPLATE =
        //    "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"border:1px solid #aaa;margin-bottom:5px;width:95%;\" >" +
        //        "<tbody>" +
        //        "<tr><td><div style=\"background-color:#bbb;padding:5px;\">{0}</div></td></tr>" +
        //        "<tr><td style=\"padding:0px;\">{1}</td></tr>" +
        //    "</tbody></table>";

        #region CurrentControl

        /// <summary>
        /// Current Control
        /// </summary>
        public new CollapsablePanel CurrentControl
        {
            get
            {
                return base.CurrentControl as CollapsablePanel;
            }
        }

        #endregion

        #region GetDesignTimeHtml

        public override string GetDesignTimeHtml(DesignerRegionCollection regions)
        {
            //// Width and Height
            //string sizeStyle = String.Empty;
            //if (CurrentControl.Width != Unit.Empty)
            //{
            //    sizeStyle += String.Format("width:{0}px;", CurrentControl.Width);
            //}
            //if (CurrentControl.Height != Unit.Empty)
            //{
            //    sizeStyle += String.Format("height:{0}px;", CurrentControl.Height);
            //}

            // Title
            string title = CurrentControl.Title;
            if (String.IsNullOrEmpty(title))
            {
                title = String.Format("[{0}]", CurrentControl.ID);
            }

            // Items
            EditableDesignerRegion itemsRegion = new EditableDesignerRegion(this, "Items", true);
            regions.Add(itemsRegion);

            string itemsContent = String.Format("<div style=\"border:solid 1px #ccc;font-size:11px;background-color:#ddd;\">Items</div><div style=\"padding:2px;\" {0}=\"{1}\"></div>",
                DesignerRegion.DesignerRegionAttributeName, "0"); //GetEditableDesignerRegionContent(itemsRegion));

            // Toolbars
            string toolbarsContent = "";
            if (CurrentControl.Toolbars.Count > 0)
            {
                EditableDesignerRegion toolbarsRegion = new EditableDesignerRegion(this, "Toolbars", true);
                regions.Add(toolbarsRegion);

                toolbarsContent = String.Format("<div style=\"border:solid 1px #ccc;font-size:11px;background-color:#ddd;\">Toolbars</div><div style=\"padding:2px;\" {0}=\"{1}\"></div>",
                    DesignerRegion.DesignerRegionAttributeName, "1");
            }

            return String.Format(PANEL_TEMPLATE, title, toolbarsContent + itemsContent);
        }

        #endregion

        #region GetEditableDesignerRegionContent/SetEditableDesignerRegionContent

        public override string GetEditableDesignerRegionContent(EditableDesignerRegion region)
        {
            IDesignerHost service = (IDesignerHost)CurrentControl.Site.GetService(typeof(IDesignerHost));
            if (service != null)
            {
                if (region.Name == "Items")
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (ControlBase c in CurrentControl.Items)
                    {
                        sb.Append(ControlPersister.PersistControl(c, service));
                    }
                    //sb.Append(ControlPersister.PersistControl(CurrentControl.Items[1], service));
                    //sb.Append("<ext:CheckBox runat=\"server\" Text=\"Click to postback\" Checked=\"True\" AutoPostBack=\"True\" Label=\"CheckBox\" ID=\"CheckBox1\" __designer:mapid=\"4\" OnCheckedChanged=\"CheckBox1_CheckedChanged\"></ext:CheckBox>");
                    //sb.Append("<ext:CheckBox runat=\"server\" Text=\"Click to postback\" Checked=\"True\" AutoPostBack=\"True\" Label=\"CheckBox\" ID=\"CheckBox1\" OnCheckedChanged=\"CheckBox1_CheckedChanged\"></ext:CheckBox>");
                    return sb.ToString();
                }
                else if (region.Name == "Toolbars")
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (Toolbar c in CurrentControl.Toolbars)
                    {
                        sb.Append(ControlPersister.PersistControl(c, service));
                    }
                    return sb.ToString();
                }
            }
            return String.Empty;
        }

        public override void SetEditableDesignerRegionContent(EditableDesignerRegion region, string content)
        {
            IDesignerHost service = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
            if (service != null)
            {
                Control[] parsedControls = ControlParser.ParseControls(service, content);

                if (region.Name == "Items")
                {
                    CurrentControl.Items.Clear();
                    for (int i = 0; i < parsedControls.Length; i++)
                    {
                        ControlBase c = parsedControls[i] as ControlBase;
                        if (c != null)
                        {
                            CurrentControl.Items.Add(c);
                        }
                    }
                }
                else if (region.Name == "Toolbars")
                {
                    CurrentControl.Toolbars.Clear();
                    for (int i = 0; i < parsedControls.Length; i++)
                    {
                        Toolbar c = parsedControls[i] as Toolbar;
                        if (c != null)
                        {
                            CurrentControl.Toolbars.Add(c);
                        }
                    }
                }
            }
        }

        #endregion


    }
}
