
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    DropDownListDesigner.cs
 * CreatedOn:   2008-04-24
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


    public class DropDownListDesigner : ControlBaseDesigner
    {

        public override string GetDesignTimeHtml()
        {
            DropDownList control = CurrentControl as DropDownList;

            string content = String.Empty;
            content += "<select style=\"width:120px;\"><option></option></select>";


            //if (!String.IsNullOrEmpty(control.SelectedText))
            //{
            //    content = template.Replace("#VALUE#", control.SelectedText);
            //}
            //else if (!String.IsNullOrEmpty(control.EmptyText))
            //{
            //    content = template.Replace("#VALUE#", control.EmptyText);
            //}
            //else
            //{
            //    content = template.Replace("#VALUE#", String.Empty);
            //}



            return control.GetDesignTimeHtml(content);
        }


        #region old code
        //#region static readonly

        //private static readonly string DROPDOWNLIST_TEMPLATE = "<div style='width: #DIV_WIDTH#;' class='x-form-field-wrap #DISABLED_CLASSNAME#'><input #DISABLED_HTML# style='width: #INPUT_WIDTH#;' class='x-form-text x-form-field #DISABLED_CLASSNAME#' value='#VALUE#' size='24' autocomplete='off' type='text'><img src='#BLANK_IMAGE_URL#' class='x-form-trigger x-form-arrow-trigger'></div>";

        //#endregion

        //#region GetDesignTimeHtml

        ///// <summary>
        ///// 设计时展示
        ///// </summary>
        ///// <returns></returns>
        //public override string GetDesignTimeHtml()
        //{
        //    DropDownList control = CurrentControl as DropDownList;

        //    string content = DROPDOWNLIST_TEMPLATE;

        //    content = content.Replace("#BLANK_IMAGE_URL#", GetBlankImageUrl());

        //    if (control.Enabled)
        //    {
        //        content = content.Replace("#DISABLED_CLASSNAME#", String.Empty);
        //        content = content.Replace("#DISABLED_HTML#", String.Empty);
        //    }
        //    else
        //    {
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

        //    if (control.SelectedItem != null)
        //    {
        //        content = content.Replace("#VALUE#", control.SelectedItem.Text);
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

        //    return content;
        //}


        //#endregion 
        #endregion




    }
}
