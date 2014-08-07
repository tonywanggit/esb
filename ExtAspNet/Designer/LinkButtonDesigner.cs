
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    LinkButtonDesigner.cs
 * CreatedOn:   2008-06-23
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
    /// <summary>
    /// 按钮设计时
    /// </summary>
    public class LinkButtonDesigner : ControlBaseDesigner
    {

        public override string GetDesignTimeHtml()
        {
            LinkButton control = CurrentControl as LinkButton;

            string text = control.Text;

            string content = String.Format("<a href=\"javascript:;\">{0}</a>", text);

            return control.GetDesignTimeHtml(content);

        }


    }
}
