
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    CheckBoxDesigner.cs
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
using System.Web;

namespace ExtAspNet
{


    public class CheckBoxDesigner : ControlBaseDesigner
    {

        public override string GetDesignTimeHtml()
        {
            CheckBox control = CurrentControl as CheckBox;

            string content = String.Empty;

            HtmlNodeBuilder nb = new HtmlNodeBuilder("input");
            nb.SetProperty("type", "checkbox");

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

        #region old code

        //#region static readonly

        ////private static readonly string CHECKBOX_TEMPLATE = "<div class='x-form-check-wrap'><input #DISABLED_HTML# #CHECKED_HTML# class='x-form-checkbox x-form-field' autocomplete='off' type='checkbox'><label class='x-form-cb-label'>#TEXT#</label></div>";


        //#endregion




        //public override string GetDesignTimeHtml()
        //{
        //    CheckBox control = CurrentControl as CheckBox;

        //    string content = CHECKBOX_TEMPLATE;

        //    content = content.Replace("#CHECKED_HTML#", control.Checked ? CHECKED_HTML : String.Empty);

        //    #region Enabled

        //    if (control.Enabled)
        //    {
        //        content = content.Replace("#DISABLED_HTML#", String.Empty);
        //        content = content.Replace("#DISABLED_CLASSNAME#", String.Empty);
        //    }
        //    else
        //    {
        //        content = content.Replace("#DISABLED_HTML#", DISABLED_HTML);
        //        content = content.Replace("#DISABLED_CLASSNAME#", DISABLED_CLASSNAME);
        //    }


        //    #endregion

        //    content = content.Replace("#TEXT#", control.Text);

        //    // Form表单字段
        //    content = GetDesignTimeFormItemHtml(content);

        //    return content;
        //}

        #endregion


    }
}
