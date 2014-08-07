
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    HideMode.cs
 * CreatedOn:   2008-09-16
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
    /// 隐藏的模式
    /// </summary>
    public enum HideMode
    {
        /// <summary>
        /// 通过设置CSS属性visibility来控制显示隐藏
        /// </summary>
        Visibility,
        /// <summary>
        /// 通过设置CSS属性top/left来控制显示隐藏
        /// </summary>
        Offsets,
        /// <summary>
        /// 通过设置CSS属性display来控制显示隐藏（默认值）
        /// </summary>
        Display
    }

    /// <summary>
    /// 隐藏的模式名称
    /// </summary>
    internal static class HideModeName
    {
        public static string GetName(HideMode type)
        {
            string result = String.Empty;

            switch (type)
            {
                case HideMode.Visibility:
                    result = "visibility";
                    break;
                case HideMode.Offsets:
                    result = "offsets";
                    break;
                case HideMode.Display:
                    result = "display";
                    break;
            }

            return result;
        }
    }
}