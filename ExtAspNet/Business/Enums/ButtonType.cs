using System;
using System.Collections.Generic;
using System.Text;

namespace ExtAspNet
{
    /// <summary>
    /// 按钮类型
    /// </summary>
    public enum ButtonType
    {
        /// <summary>
        /// 普通按钮（默认值）
        /// </summary>
        Button,
        /// <summary>
        /// 提交按钮（会为生成的input标签添加type="submit"）
        /// </summary>
        Submit,
        /// <summary>
        /// 重置按钮（会为生成的input标签添加type="reset"）
        /// </summary>
        Reset
    }

    /// <summary>
    /// 按钮类型名称
    /// </summary>
    internal static class ButtonTypeName
    {
        public static string GetName(ButtonType type)
        {
            string result = String.Empty;

            switch (type)
            {
                case ButtonType.Button:
                    result = "button";
                    break;
                case ButtonType.Reset:
                    result = "reset";
                    break;
                case ButtonType.Submit:
                    result = "submit";
                    break;
            }

            return result;
        }
    }
}