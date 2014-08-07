
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    IconAlign.cs
 * CreatedOn:   2011-05-15
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
    /// 按钮上图标的摆放位置
    /// </summary>
    public enum IconAlign
    {
        /// <summary>
        /// 靠上
        /// </summary>
        Top,
        /// <summary>
        /// 靠右
        /// </summary>
        Right,
        /// <summary>
        /// 靠下
        /// </summary>
        Bottom,
        /// <summary>
        /// 靠左（默认值）
        /// </summary>
        Left
    }

    /// <summary>
    /// 图标摆放位置的名称
    /// </summary>
    internal static class IconAlignHelper
    {
        public static string GetName(IconAlign type)
        {
            string result = String.Empty;

            switch (type)
            {
                case IconAlign.Top:
                    result = "top";
                    break;
                case IconAlign.Left:
                    result = "left";
                    break;
                case IconAlign.Bottom:
                    result = "bottom";
                    break;
                case IconAlign.Right:
                    result = "right";
                    break;
                default:
                    result = "left";
                    break;
            }

            return result;
        }
    }
}