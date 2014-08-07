
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    SimpleFormDesigner.cs
 * CreatedOn:   2008-04-22
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      -> 2008-5-7 增加设计时支持 sanshi.ustc@gmail.com
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
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.Web;
using System.ComponentModel;


namespace ExtAspNet
{
    public class SimpleFormDesigner : ControlBaseDesigner
    {

        #region CurrentControl

        /// <summary>
        /// Current Control
        /// </summary>
        public new SimpleForm CurrentControl
        {
            get
            {
                return base.CurrentControl as SimpleForm;
            }
        }

        #endregion

        #region GetDesignTimeHtml

        private static readonly string TEMPLATE =
            "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"border: 2px solid #bbb;width:80%;\" >" +
                "<tbody>" +
                "<tr><td><div style=\"background-color:#ccc;padding:3px;\">{0}</div></td></tr>" +
                "<tr><td style=\"padding:3px;\">{1}{2}</td></tr>" +
            "</tbody></table>";

        public override string GetDesignTimeHtml(DesignerRegionCollection regions)
        {
            string title = CurrentControl.Title;
            if (String.IsNullOrEmpty(title))
            {
                title = String.Format("[{0}]", CurrentControl.ID);
            }

            EditableDesignerRegion itemsRegion = new EditableDesignerRegion(this, "Items", true);
            regions.Add(itemsRegion);

            string itemsContent = String.Format("<div style=\"border:solid 1px #ccc;\"><div style=\"font-size:11px;background-color:#ddd;\">Items</div><div style=\"padding:2px;\" {0}=\"{1}\">{2}</div></div>",
                DesignerRegion.DesignerRegionAttributeName, "0", GetEditableDesignerRegionContent(itemsRegion));


            string toolbarsContent = "";

            if (CurrentControl.Toolbars.Count > 0)
            {
                EditableDesignerRegion toolbarsRegion = new EditableDesignerRegion(this, "Toolbars", true);
                regions.Add(toolbarsRegion);

                toolbarsContent = String.Format("<div style=\"border:solid 1px #ccc;margin-bottom:5px;\"><div style=\"font-size:11px;background-color:#ddd;\">Toolbars</div><div style=\"padding:2px;\" {0}=\"{1}\">{2}</div></div>",
                    DesignerRegion.DesignerRegionAttributeName, "1", GetEditableDesignerRegionContent(toolbarsRegion));
            }
            
            return String.Format(TEMPLATE, title, toolbarsContent, itemsContent);
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
