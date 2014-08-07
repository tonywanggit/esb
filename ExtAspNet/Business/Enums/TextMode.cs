
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
    /// 文本框类型
    /// </summary>
    public enum TextMode
    {
        /// <summary>
        /// 普通文本框（默认值）
        /// </summary>
        Text,
        /// <summary>
        /// 密码输入框
        /// </summary>
        Password
    }

    /// <summary>
    /// 文本框类型名称
    /// </summary>
    internal static class TextModeHelper
    {
        public static string GetName(TextMode type)
        {
            string result = String.Empty;

            switch (type)
            {
                case TextMode.Text:
                    result = "text";
                    break;
                case TextMode.Password:
                    result = "password";
                    break;
            }

            return result;
        }
    }
}