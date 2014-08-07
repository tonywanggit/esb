
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    BoxLayoutAlign.cs
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
    /// 在HBox布局或者VBox布局中，用来控制容器子控件的尺寸
    /// </summary>
    public enum BoxLayoutAlign
    {
        /// <summary>
        /// 所有子控件位于父容器的开始位置（废弃，请使用Start代替）
        /// </summary>
        Top,
        /// <summary>
        /// 所有子控件位于父容器的中间位置（废弃，请使用Center代替）
        /// </summary>
        Middle,
        /// <summary>
        /// 所有子控件位于父容器的开始位置（默认值）
        /// </summary>
        Start,
        /// <summary>
        /// 所有子控件位于父容器的中间位置
        /// </summary>
        Center,
        /// <summary>
        /// 所有子控件被拉伸至父容器的大小
        /// </summary>
        Stretch,
        /// <summary>
        /// 所有子控件被拉伸至最大子控件的大小
        /// </summary>
        StretchMax 
    }

    /// <summary>
    /// HBox或者VBox的位置的名称
    /// </summary>
    internal static class BoxLayoutAlignHelper
    {
        public static string GetName(BoxLayoutAlign type, Layout theLayout)
        {
            string result = String.Empty;

            switch (type)
            {
                case BoxLayoutAlign.Top:
                case BoxLayoutAlign.Start:
                    if (theLayout == Layout.HBox)
                    {
                        result = "top";
                    }
                    else
                    {
                        result = "left";
                    }
                    break;
                case BoxLayoutAlign.Middle:
                case BoxLayoutAlign.Center:
                    if (theLayout == Layout.HBox)
                    {
                        result = "middle";
                    }
                    else
                    {
                        result = "center";
                    }
                    break;
                case BoxLayoutAlign.Stretch:
                    result = "stretch";
                    break;
                case BoxLayoutAlign.StretchMax:
                    result = "stretchmax";
                    break;
            }

            return result;
        }
    }
}