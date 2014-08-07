
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    BoxLayoutPosition.cs
 * CreatedOn:   2012-01-10
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
    /// 在HBox布局或者VBox布局中，用来控制容器子控件的位置
    /// </summary>
    public enum BoxLayoutPosition
    {
        /// <summary>
        /// 子控件靠父容器的开始位置排列（废弃，请使用Start代替）
        /// </summary>
        Left,
        /// <summary>
        /// 子控件靠父容器的中间位置排列
        /// </summary>
        Center,
        /// <summary>
        /// 子控件靠父容器的结束位置排列（废弃，请使用End代替）
        /// </summary>
        Right,
        /// <summary>
        /// 子控件靠父容器的开始位置排列（默认值）
        /// </summary>
        Start,
        /// <summary>
        /// 子控件靠父容器的结束位置排列
        /// </summary>
        End
    }

    /// <summary>
    /// HBox或者VBox的位置的名称
    /// </summary>
    internal static class BoxLayoutPositionHelper
    {
        public static string GetName(BoxLayoutPosition type)
        {
            string result = String.Empty;

            switch (type)
            {
                case BoxLayoutPosition.Left:
                case BoxLayoutPosition.Start:
                    result = "start";
                    break;
                case BoxLayoutPosition.Center:
                    result = "center";
                    break;
                case BoxLayoutPosition.Right:
                case BoxLayoutPosition.End:
                    result = "end";
                    break;
            }

            return result;
        }
    }
}