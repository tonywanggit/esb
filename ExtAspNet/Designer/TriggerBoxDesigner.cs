
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    TriggerBoxDesigner.cs
 * CreatedOn:   2008-06-18
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
using System.Web.UI.WebControls;

namespace ExtAspNet
{
   
    public class TriggerBoxDesigner : ControlBaseDesigner
    {
        public override string GetDesignTimeHtml()
        {
            TriggerBox control = CurrentControl as TriggerBox;

            string template = "<input style=\"width:80%;\" type=\"text\" value=\"#VALUE#\" />";

            string content = String.Empty;
            if (!String.IsNullOrEmpty(control.Text))
            {
                content += template.Replace("#VALUE#", control.Text);
            }
            else if (!String.IsNullOrEmpty(control.EmptyText))
            {
                content += template.Replace("#VALUE#", control.EmptyText);
            }
            else
            {
                content += template.Replace("#VALUE#", String.Empty);
            }

            // String.Format("<img src=\"{0}\" style=\"border:0px;\" />", ResourceHelper.GetWebResourceUrl(Component.Site, "ExtAspNet.res.X.images.X.gif"));
            if (control.ShowTrigger)
            {
                content += "<input type=\"button\" value=\"x\" />"; 
            }

            return control.GetDesignTimeHtml(content);
        }


    }
}
