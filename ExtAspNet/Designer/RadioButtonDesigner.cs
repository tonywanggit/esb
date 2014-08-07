
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    RadioButtonDesigner.cs
 * CreatedOn:   2008-06-20
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

namespace ExtAspNet
{
   
    public class RadioButtonDesigner : ControlBaseDesigner
    {

        public override string GetDesignTimeHtml()
        {
            RadioButton control = CurrentControl as RadioButton;

            string content = String.Empty;

            HtmlNodeBuilder nb = new HtmlNodeBuilder("input");
            nb.SetProperty("type", "radio");

            if (control.Checked)
            {
                nb.SetProperty("checked", "checked");
            }

            content = nb.ToString();
            if (!String.IsNullOrEmpty(control.Text))
            {
                content += control.Text;
            }

            return control.GetDesignTimeHtml(content);
        }
       
    }
}
