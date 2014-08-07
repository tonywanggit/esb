
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    FormDesigner.cs
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
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.Web;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace ExtAspNet
{
    /// <summary>
    /// Deign support for From control.
    /// </summary>
    public class FormDesigner : ControlBaseDesigner
    {
        #region static readonly

        private static readonly string EDITOR_REGION_PREFIX = "Content_";

        #endregion

        #region CurrentControl

        /// <summary>
        /// Current Control
        /// </summary>
        public new Form CurrentControl
        {
            get
            {
                return base.CurrentControl as Form;
            }
        }

        #endregion

        #region GetDesignTimeHtml

        public override string GetDesignTimeHtml(DesignerRegionCollection regions)
        {
            StringBuilder sb = new StringBuilder();

            int rowIndex = 0;
            foreach (FormRow row in CurrentControl.Rows)
            {
                #region oldcode
                //bool showInnerTable = row.Fields.Count > 1 ? true : false;
                //if (showInnerTable)
                //{
                //    sb.Append("<table cellpadding='0' cellspacing='2' border='0' width='100%'><tbody><tr>");
                //}

                //int columnIndex = 0;
                //foreach (Field field in row.Fields)
                //{
                //if (showInnerTable)
                //{
                //    sb.Append("<td>");
                //} 
                #endregion

                string regionName = String.Format("{0}_{1}", EDITOR_REGION_PREFIX, rowIndex);
                EditableDesignerRegion editableRegion = new EditableDesignerRegion(this, regionName, false);
                editableRegion.Properties["RowIndex"] = rowIndex;
                regions.Add(editableRegion);

                sb.AppendFormat("<div style='margin:2px;' {0}='{1}'>{2}</div>",
                    DesignerRegion.DesignerRegionAttributeName, rowIndex, GetEditableDesignerRegionContent(editableRegion));

                rowIndex++;
            }


            string title = CurrentControl.Title;
            if (String.IsNullOrEmpty(title))
            {
                title = String.Format("[{0}]", CurrentControl.ID);
            }

            string content = String.Format(PANEL_TEMPLATE, title, sb.ToString());


            return content;
        }

        #endregion

        #region GetEditableDesignerRegionContent/SetEditableDesignerRegionContent

        public override string GetEditableDesignerRegionContent(EditableDesignerRegion region)
        {
            IDesignerHost service = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
            if (service != null)
            {
                int rowIndex = Convert.ToInt32(region.Properties["RowIndex"]);

                StringBuilder sb = new StringBuilder();

                foreach (ControlBase c in CurrentControl.Rows[rowIndex].Items)
                {
                    sb.Append(ControlPersister.PersistControl(c, service));
                }

                return sb.ToString();

                #region old code

                // table不会自动更新，还不如先不用
                ////int rowIndex = Convert.ToInt32(region.Name.Substring(EDITOR_REGION_PREFIX.Length));

                //int rowIndex = Convert.ToInt32(region.Properties["RowIndex"]);

                //ControlBaseCollection controls = CurrentControl.Rows[rowIndex].Items;

                //StringBuilder sb = new StringBuilder();
                //sb.Append("<table cellpadding='0' cellspacing='0' border='0' style='width:100%;'><tbody><tr>");

                //string columnWidthStr = (1.0 / controls.Count * 100).ToString("F0") + "%";

                //if (controls.Count == 0)
                //{
                //    sb.Append("<td style='width:100%;'></td>");
                //}
                //else
                //{
                //    foreach (ControlBase c in controls)
                //    {
                //        sb.AppendFormat("<td style='width:{0};'>", columnWidthStr);

                //        sb.Append(ControlPersister.PersistControl(c, service));

                //        sb.Append("</td>");
                //    }
                //}

                //sb.Append("</tr></tbody></table>");
                ////sb.Append(ControlPersister.PersistControl(CurrentControl.Rows[rowIndex].Fields[columnIndex], service));

                //return sb.ToString(); 

                #endregion

            }
            return String.Empty;
        }

        public override void SetEditableDesignerRegionContent(EditableDesignerRegion region, string content)
        {
            IDesignerHost service = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
            if (service != null)
            {
                int rowIndex = Convert.ToInt32(region.Properties["RowIndex"]);

                Control[] parsedControls = ControlParser.ParseControls(service, content);
                FormRow row = CurrentControl.Rows[rowIndex];

                row.Items.Clear();
                for (int i = 0, length = parsedControls.Length; i < length; i++)
                {
                    ControlBase c = parsedControls[i] as ControlBase;
                    if (c != null)
                    {
                        row.Items.Add(c);
                    }
                }

                #region old code

                //int rowIndex = Convert.ToInt32(region.Properties["RowIndex"]);
                ////int columnIndex = Convert.ToInt32(region.Properties["ColumnIndex"]);

                //// 首先从字符串中把所有的 <td style='width:50%;'></td> 中的字符串抽取出来
                //content = GetControlsString(content);

                //Control[] parsedControls = ControlParser.ParseControls(service, content);

                //CurrentControl.Rows[rowIndex].Controls.Clear();
                //CurrentControl.Rows[rowIndex].Items.Clear();
                //for (int i = 0, length = parsedControls.Length; i < length; i++)
                //{
                //    ControlBase c = parsedControls[i] as ControlBase;

                //    if (c != null)
                //    {
                //        CurrentControl.Rows[rowIndex].Items.Add(c);
                //    }
                //}  

                #endregion


            }
        }





        #endregion

        #region old code
        //private static readonly string TD_START_STRING = "<td";
        //private string GetControlsString(string content)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    do
        //    {
        //        int tdStartIndex = content.IndexOf(TD_START_STRING);
        //        int contentStartIndex = content.IndexOf(">", tdStartIndex) + 1;
        //        int contentEndIndex = content.IndexOf("</td>", contentStartIndex);

        //        sb.Append(content.Substring(contentStartIndex, contentEndIndex - contentStartIndex));
        //        content = content.Substring(contentEndIndex + "</td>".Length);
        //    }
        //    while (content.IndexOf(TD_START_STRING) >= 0);

        //    return sb.ToString();
        //}


        ///// <summary>
        ///// 取得某一行的控件集合
        ///// </summary>
        ///// <param name="row"></param>
        ///// <returns></returns>
        //private List<ControlBase> GetRowControls(FormRow row)
        //{
        //    List<ControlBase> controls = new List<ControlBase>();

        //    foreach (Control c in row.Controls)
        //    {
        //        ControlBase control = c as ControlBase;
        //        if (control != null)
        //        {
        //            controls.Add(control);
        //        }
        //    }

        //    return controls;

        //    //return row.Controls;
        //}


        #endregion

        #region old code AddRow

        //public void AddRow()
        //{
        //    //PropertyDescriptor descriptor;
        //    IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));
        //    if (host == null)
        //    {
        //        return;
        //    }

        //    FormRow row = (FormRow)host.CreateComponent(typeof(FormRow));
        //    if (row == null)
        //    {
        //        return;
        //    }


        //    IComponentChangeService service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
        //    try
        //    {
        //        service.OnComponentChanging(CurrentControl, TypeDescriptor.GetProperties(CurrentControl)["Rows"]);

        //        CurrentControl.Rows.Add(row);

        //    }
        //    finally
        //    {
        //        service.OnComponentChanged(CurrentControl, TypeDescriptor.GetProperties(CurrentControl)["Rows"], null, null);
        //    }

        //}

        #endregion
    }
}
