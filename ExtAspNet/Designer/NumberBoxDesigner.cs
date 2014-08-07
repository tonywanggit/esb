
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
  
    public class NumberBoxDesigner : ControlBaseDesigner
    {


        public override string GetDesignTimeHtml()
        {
            NumberBox control = CurrentControl as NumberBox;

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

            nb.SetProperty("style", "width:80%;");
            nb.SetProperty("type", "text");

            string content = nb.ToString();
            return control.GetDesignTimeHtml(content);
        }


        #region old code
        //private static readonly string NUMBERBOX_TEMPLATE = "<input value='#VALUE#' style='width:#WIDTH#;' class='x-form-text x-form-field x-form-num-field #DISABLED_CLASSNAME#' size='20' autocomplete='off' type='text'>";

        ///// <summary>
        ///// 设计时展示
        ///// </summary>
        ///// <returns></returns>
        //public override string GetDesignTimeHtml()
        //{
        //    NumberBox control = CurrentControl as NumberBox;

        //    //string htmlTemplate = htmlTemplate = "<input type=\"text\" value=\"{0}\" />";

        //    //return String.Format(htmlTemplate, control.Text);

        //    string content = NUMBERBOX_TEMPLATE;

        //    if (!String.IsNullOrEmpty(control.Text))
        //    {
        //        content = content.Replace("#VALUE#", control.Text);
        //    }
        //    else if (!String.IsNullOrEmpty(control.EmptyText))
        //    {
        //        content = content.Replace("#VALUE#", control.EmptyText);
        //    }
        //    else
        //    {
        //        content = content.Replace("#VALUE#", String.Empty);
        //    }

        //    if (control.Enabled)
        //    {
        //        content = content.Replace("#DISABLED_CLASSNAME#", String.Empty);
        //    }
        //    else
        //    {
        //        content = content.Replace("#DISABLED_CLASSNAME#", DISABLED_CLASSNAME);
        //    }


        //    if (control.Width == Unit.Empty)
        //    {
        //        content = content.Replace("#WIDTH#", String.Format("{0}px", FIELD_DEFAULT_WIDTH_DESIGNTIME));
        //    }
        //    else
        //    {
        //        content = content.Replace("#WIDTH#", String.Format("{0}px", control.Width.Value - 8));
        //    }

        //    // Form表单字段
        //    content = GetDesignTimeFormItemHtml(content);

        //    return content;
        //} 
        #endregion

       
    }
}
