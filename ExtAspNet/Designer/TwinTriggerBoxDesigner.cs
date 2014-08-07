
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    TwinTriggerBoxDesigner.cs
 * CreatedOn:   2008-06-27
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

    public class TwinTriggerBoxDesigner : ControlBaseDesigner
    {


        public override string GetDesignTimeHtml()
        {
            TwinTriggerBox control = CurrentControl as TwinTriggerBox;

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

            if (control.ShowTrigger)
            {
                if (control.ShowTrigger1)
                {
                    content += "<input type=\"button\" value=\"x\" />"; 
                }

                if (control.ShowTrigger2)
                {
                    content += "<input type=\"button\" value=\"x\" />"; 
                }
            }

            return control.GetDesignTimeHtml(content);
        }


    }
}
