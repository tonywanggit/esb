

#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    PositionType.cs
 * CreatedOn:   2008-06-12
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
    /// Region控件所在RegionPanel中的位置
    /// </summary>
    public enum Position
    {
        /// <summary>
        /// 上方
        /// </summary>
        Top,
        /// <summary>
        /// 底部
        /// </summary>
        Bottom,
        /// <summary>
        /// 左侧
        /// </summary>
        Left,
        /// <summary>
        /// 右侧
        /// </summary>
        Right,
        /// <summary>
        /// 中部（默认值）
        /// </summary>
        Center
    }

    /// <summary>
    /// 布局类型名称
    /// </summary>
    internal static class PositionHelper
    {
        public static string GetName(Position type)
        {
            string result = String.Empty;

            switch (type)
            {
                case Position.Top:
                    result = "north";
                    break;
                case Position.Bottom:
                    result = "south";
                    break;
                case Position.Left:
                    result = "west";
                    break;
                case Position.Right:
                    result = "east";
                    break;
                case Position.Center:
                    result = "center";
                    break;
            }

            return result;
        }
    }
}