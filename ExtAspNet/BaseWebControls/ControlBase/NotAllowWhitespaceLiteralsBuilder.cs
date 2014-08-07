
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    NotAllowWhitespaceLiteralsBuilder.cs
 * CreatedOn:   2008-06-05
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
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI.Design.WebControls;



namespace ExtAspNet
{

    // 控件内部不允许存在非标签形式的字符串
    internal class NotAllowWhitespaceLiteralsBuilder : ControlBuilder
    {
        /// <summary>
        /// 不允许空白字符
        /// </summary>
        /// <returns></returns>
        public override bool AllowWhitespaceLiterals()
        {
            return false;
        }

        /// <summary>
        /// 忽略游离于标签外的字符串
        /// </summary>
        /// <param name="s"></param>
        public override void AppendLiteralString(string s)
        {
        }

        public override Type GetChildControlType(string tagName, System.Collections.IDictionary attribs)
        {
            return base.GetChildControlType(tagName, attribs);
        }

    }
}
