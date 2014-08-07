
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

namespace ExtAspNet
{
    /// <summary>
    /// 消息框图标类型
    /// </summary>
    public enum MessageBoxIcon
    {
        /// <summary>
        /// 信息（默认值）
        /// </summary>
        Information,
        /// <summary>
        /// 警告
        /// </summary>
        Warning,
        /// <summary>
        /// 问题
        /// </summary>
        Question,
        /// <summary>
        /// 错误
        /// </summary>
        Error
    }

    /// <summary>
    /// 消息框图标类型名称
    /// </summary>
    internal static class MessageBoxIconHelper
    {
        public static string GetName(MessageBoxIcon type)
        {
            string result = String.Empty;

            switch (type)
            {
                case MessageBoxIcon.Information:
                    //result = "ext-mb-info";
                    result = "Ext.MessageBox.INFO";
                    break;
                case MessageBoxIcon.Warning:
                    //result = "ext-mb-warning";
                    result = "Ext.MessageBox.WARNING";
                    break;
                case MessageBoxIcon.Question:
                    //result = "ext-mb-question";
                    result = "Ext.MessageBox.QUESTION";
                    break;
                case MessageBoxIcon.Error:
                    //result = "ext-mb-error";
                    result = "Ext.MessageBox.ERROR";
                    break;
            }

            return result;
        }
    }
}