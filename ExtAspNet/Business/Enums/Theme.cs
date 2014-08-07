
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    ThemeType.cs
 * CreatedOn:   2008-08-20
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

namespace ExtAspNet
{
    /// <summary>
    /// 样式
    /// </summary>
    public enum Theme
    {
        /// <summary>
        /// 蓝色（默认值）
        /// </summary>
        Blue,
        /// <summary>
        /// 银灰色
        /// </summary>
        Gray,
        /// <summary>
        /// Access
        /// </summary>
        Access
        //Black
    }

    /// <summary>
    /// 样式的类型名称
    /// </summary>
    internal static class ThemeHelper
    {
        public static string GetName(Theme type)
        {
            string result = String.Empty;

            switch (type)
            {
                case Theme.Blue:
                    result = "blue";
                    break;
                case Theme.Gray:
                    result = "gray";
                    break;
                case Theme.Access:
                    result = "access";
                    break;
                //case ThemeType.Slate:
                //    result = "slate";
                //    break;
                //case ThemeType.Black:
                //    result = "black";
                //    break;
            }

            return result;
        }
    }
}