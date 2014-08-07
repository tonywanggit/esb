
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    ToolbarTextDesigner.cs
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

namespace ExtAspNet
{
    /// <summary>
    /// 按钮设计时
    /// </summary>
    public class ToolbarTextDesigner : ControlBaseDesigner
    {
        /// <summary>
        /// 设计时展示
        /// </summary>
        /// <returns></returns>
        public override string GetDesignTimeHtml()
        {
            ToolbarText tbText = CurrentControl as ToolbarText;

            return String.Format("&nbsp;{0}&nbsp;", tbText.Text);
        }

    }
}
