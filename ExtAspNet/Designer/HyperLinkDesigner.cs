
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    HyperLinkDesigner.cs
 * CreatedOn:   2008-06-09
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
    public class HyperLinkDesigner : ControlBaseDesigner
    {

        public override string GetDesignTimeHtml()
        {
            HyperLink control = CurrentControl as HyperLink;

            string content = String.Empty;

            string text = control.Text;

            if (!String.IsNullOrEmpty(control.NavigateUrl))
            {
                content = String.Format("<a target=\"_blank\" href=\"{0}\">{1}</a>", control.ResolveUrl(control.NavigateUrl), text);
            }

            return control.GetDesignTimeHtml(content);

        }

    }
}
