
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    ToolbarFillDesigner.cs
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
    public class ToolbarFillDesigner : ControlBaseDesigner
    {
        /// <summary>
        /// 设计时展示
        /// </summary>
        /// <returns></returns>
        public override string GetDesignTimeHtml()
        {
            return "&nbsp;&nbsp;&nbsp;<&nbsp;&nbsp;>&nbsp;&nbsp;&nbsp;";
        }

    }
}
