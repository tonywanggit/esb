
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    DatePickerDesigner.cs
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
using System.Web;

namespace ExtAspNet
{
    /// <summary>
    /// 按钮设计时
    /// </summary>
    public class DatePickerDesigner : ControlBaseDesigner
    {

        public override string GetDesignTimeHtml()
        {
            DatePicker control = CurrentControl as DatePicker;

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
            content += "<input type=\"button\" value=\"x\" />"; 


            return control.GetDesignTimeHtml(content);
        }


        #region old code
        //private static readonly string DATEPICKER_TEMPLATE = "<div style='width: #DIV_WIDTH#;' class='x-form-field-wrap #DISABLED_CLASSNAME#'><input #DISABLED_HTML# style='width: #INPUT_WIDTH#;' class='x-form-text x-form-field #DISABLED_CLASSNAME#' size='10' autocomplete='off' value='#VALUE#' type='text'><img src='#BLANK_IAMGE_URL#' class='x-form-trigger x-form-date-trigger'></div>";


        //public override string GetDesignTimeHtml()
        //{
        //    DatePicker control = CurrentControl as DatePicker;

        //    //string htmlTemplate = htmlTemplate = "<input type=\"text\" value=\"{0}\" />";
        //    //return String.Format(htmlTemplate, control.Text);


        //    string content = DATEPICKER_TEMPLATE;

        //    content = content.Replace("#BLANK_IAMGE_URL#", GetBlankImageUrl());

        //    if (control.Enabled)
        //    {
        //        content = content.Replace("#DISABLED_CLASSNAME#", String.Empty);
        //        content = content.Replace("#DISABLED_HTML#", String.Empty);
        //    }
        //    else
        //    {
        //        // 由于 Design-Time 不支持透明度样式（opacity:0.6;），所以设计时表现不出来
        //        content = content.Replace("#DISABLED_CLASSNAME#", DISABLED_CLASSNAME);
        //        content = content.Replace("#DISABLED_HTML#", DISABLED_HTML);
        //    }

        //    if (control.Width == Unit.Empty)
        //    {
        //        content = content.Replace("#DIV_WIDTH#", String.Format("{0}px", FIELD_DEFAULT_WIDTH_DESIGNTIME + 8));
        //        content = content.Replace("#INPUT_WIDTH#", String.Format("{0}px", FIELD_DEFAULT_WIDTH_DESIGNTIME + 8 - 25));
        //    }
        //    else
        //    {
        //        content = content.Replace("#DIV_WIDTH#", String.Format("{0}px", control.Width.Value));
        //        content = content.Replace("#INPUT_WIDTH#", String.Format("{0}px", control.Width.Value - 25));
        //    }

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

        //    // Form表单字段
        //    content = GetDesignTimeFormItemHtml(content);

        //    //return HttpUtility.HtmlEncode(content) + content;
        //    return content;
        //} 
        #endregion


    }
}
