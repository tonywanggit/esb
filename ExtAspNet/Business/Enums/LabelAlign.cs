using System;
using System.Collections.Generic;
using System.Text;

namespace ExtAspNet
{
    /// <summary>
    /// 表单中标签的排列位置
    /// </summary>
    public enum LabelAlign
    {
        /// <summary>
        /// 靠左（默认值）
        /// </summary>
        Left,
        /// <summary>
        /// 靠右
        /// </summary>
        Right,
        /// <summary>
        /// 靠上
        /// </summary>
        Top
    }

    /// <summary>
    /// 表单中标签的排列位置名称
    /// </summary>
    internal static class LabelAlignHelper
    {
        public static string GetName(LabelAlign type)
        {
            string result = String.Empty;

            switch (type)
            {
                case LabelAlign.Left:
                    result = "left";
                    break;
                case LabelAlign.Right:
                    result = "right";
                    break;
                case LabelAlign.Top:
                    result = "top";
                    break;
            }

            return result;
        }
    }
}