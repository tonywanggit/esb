using System;
using System.Collections.Generic;
using System.Text;

namespace ExtAspNet
{
    /// <summary>
    /// Tab标签的显示位置
    /// </summary>
    public enum TabPosition
    {
        /// <summary>
        /// 顶部（默认值）
        /// </summary>
        Top,
        /// <summary>
        /// 底部
        /// </summary>
        Bottom
    }

    /// <summary>
    /// Tab显示的位置名称
    /// </summary>
    internal static class TabPositionHelper
    {
        public static string GetName(TabPosition type)
        {
            string result = String.Empty;

            switch (type)
            {
                case TabPosition.Top:
                    result = "top";
                    break;
                case TabPosition.Bottom:
                    result = "bottom";
                    break;
            }

            return result;
        }
    }
}