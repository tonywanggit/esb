
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    TextAreaDesigner.cs
 * CreatedOn:   2008-04-23
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
using System.Web;
using System.Web.UI.Design;

namespace ExtAspNet
{

    public class TextAreaDesigner : ControlBaseDesigner
    {


        public override string GetDesignTimeHtml()
        {
            TextArea control = CurrentControl as TextArea;

            HtmlNodeBuilder nb = new HtmlNodeBuilder("textarea");


            if (!String.IsNullOrEmpty(control.Text))
            {
                nb.InnerProperty = control.Text;
            }
            else if (!String.IsNullOrEmpty(control.EmptyText))
            {
                nb.InnerProperty = control.EmptyText;
            }
            else
            {
                nb.InnerProperty = String.Empty;
            }


            string styleStr = String.Empty;
            if (control.Height != Unit.Empty)
            {
                styleStr += String.Format("height:{0}px;", control.Height.Value);
            }
            styleStr += "width:80%;";
            nb.SetProperty("style", styleStr);

            return control.GetDesignTimeHtml(nb.ToString());
        }

        #region old code

        //private static readonly string TEXTAREA_TEMPLATE = "<textarea class='x-form-textarea x-form-field #DISABLED_CLASSNAME#' style='width: #WIDTH#; height: #HEIGHT#;' autocomplete='off' >#VALUE#</textarea>";




        ///// <summary>
        ///// 设计时展示
        ///// </summary>
        ///// <returns></returns>
        //public override string GetDesignTimeHtml()
        //{

        //    TextArea control = CurrentControl as TextArea;

        //    //string htmlTemplate = "<textarea value=\"{0}\" />";

        //    //return String.Format(htmlTemplate, control.Text);

        //    string content = TEXTAREA_TEMPLATE;

        //    #region DISABLED_CLASSNAME
        //    if (control.Enabled)
        //    {
        //        content = content.Replace("#DISABLED_CLASSNAME#", String.Empty);
        //    }
        //    else
        //    {
        //        content = content.Replace("#DISABLED_CLASSNAME#", DISABLED_CLASSNAME);
        //    } 
        //    #endregion

        //    #region VALUE
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
        //    #endregion

        //    #region WIDTH/HEIGHT
        //    if (control.Width == Unit.Empty)
        //    {
        //        //if (CurrentControl.DesignTimeInSimpleForm)
        //        //{
        //        //    content = content.Replace("#WIDTH#", "95%");
        //        //}
        //        //else
        //        //{
        //        //    content = content.Replace("#WIDTH#", "100px");
        //        //}
        //        content = content.Replace("#WIDTH#", String.Format("{0}px", FIELD_DEFAULT_WIDTH_DESIGNTIME));
        //    }
        //    else
        //    {
        //        content = content.Replace("#WIDTH#", String.Format("{0}px", control.Width.Value));
        //    }

        //    if (control.Height == Unit.Empty)
        //    {
        //        content = content.Replace("#HEIGHT#", "60px");
        //    }
        //    else
        //    {
        //        content = content.Replace("#HEIGHT#", String.Format("{0}px", control.Height.Value));
        //    }
        //    #endregion

        //    // Form表单字段
        //    content = GetDesignTimeFormItemHtml(content);

        //    //return HttpUtility.HtmlEncode(content) + content;
        //    return content;
        //} 

        #endregion

    }
}
