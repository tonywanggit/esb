using System;
using System.Collections.Generic;
using System.Text;

namespace ExtAspNet
{
    /// <summary>
    /// 文本排列位置
    /// </summary>
    public enum TextAlign
    {
        /// <summary>
        /// 靠左排列（默认值）
        /// </summary>
        Left,
        /// <summary>
        /// 居中排列
        /// </summary>
        Center,
        /// <summary>
        /// 靠右排列
        /// </summary>
        Right
    }

    /// <summary>
    /// 文本排列位置名称
    /// </summary>
    internal static class TextAlignName
    {
        public static string GetName(TextAlign type)
        {
            string result = String.Empty;

            switch (type)
            {
                case TextAlign.Left:
                    result = "left";
                    break;
                case TextAlign.Center:
                    result = "center";
                    break;
                case TextAlign.Right:
                    result = "right";
                    break;
            }

            return result;
        }
    }
}