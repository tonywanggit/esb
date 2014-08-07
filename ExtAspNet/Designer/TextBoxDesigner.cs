
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    js_css_resource.cs
 * CreatedOn:   2008-04-07
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->2008-04-11    sanshi.ustc@gmail.com  
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
    /// <summary>
    /// 按钮设计时
    /// </summary>
    public class TextBoxDesigner : ControlBaseDesigner
    {
        public override string GetDesignTimeHtml()
        {
            TextBox control = CurrentControl as TextBox;

            HtmlNodeBuilder nb = new HtmlNodeBuilder("input");

          
            if (!String.IsNullOrEmpty(control.Text))
            {
                nb.SetProperty("value", control.Text);
            }
            else if (!String.IsNullOrEmpty(control.EmptyText))
            {
                nb.SetProperty("value", control.EmptyText);
            }
            else
            {
                nb.SetProperty("value", String.Empty);
            }

            if (control.TextMode == TextMode.Text)
            {
                nb.SetProperty("type", "text");
            }
            else
            {
                nb.SetProperty("type", "password");
            }
            nb.SetProperty("style", "width:80%;");

            return control.GetDesignTimeHtml(nb.ToString());
        }


    }
}
