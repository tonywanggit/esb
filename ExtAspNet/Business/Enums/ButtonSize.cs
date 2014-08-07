using System;
using System.Collections.Generic;
using System.Text;

namespace ExtAspNet
{
    /// <summary>
    /// 按钮的大小
    /// </summary>
    public enum ButtonSize
    {
        /// <summary>
        /// 小尺寸（默认值）
        /// </summary>
        Small,
        /// <summary>
        /// 中等尺寸
        /// </summary>
        Medium,
        /// <summary>
        /// 大尺寸
        /// </summary>
        Large
    }

    /// <summary>
    /// 按钮的大小名称
    /// </summary>
    internal static class ButtonSizeName
    {
        public static string GetName(ButtonSize type)
        {
            string result = String.Empty;

            switch (type)
            {
                case ButtonSize.Small:
                    result = "small";
                    break;
                case ButtonSize.Medium:
                    result = "medium";
                    break;
                case ButtonSize.Large:
                    result = "large";
                    break;
            }

            return result;
        }
    }
}