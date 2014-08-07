
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    Target.cs
 * CreatedOn:   2010-01-30
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
    /// 窗体以及对话框的显示位置
    /// </summary>
    public enum Target
    {
        /// <summary>
        /// 当前页面（默认值）
        /// </summary>
        Self,
        /// <summary>
        /// 父页面
        /// </summary>
        Parent,
        /// <summary>
        /// 最外层页面
        /// </summary>
        Top
    }

    /// <summary>
    /// Alert,Confirm,Window显示的位置
    /// </summary>
    internal static class TargetHelper
    {
        public static string GetName(Target type)
        {
            string result = String.Empty;

            switch (type)
            {
                case Target.Self:
                    result = "_self";
                    break;
                case Target.Parent:
                    result = "_parent";
                    break;
                case Target.Top:
                    result = "_top";
                    break;
            }

            return result;
        }

        /// <summary>
        /// Get target name used inside JavaScript code.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetScriptName(Target type)
        {
            string result = String.Empty;

            switch (type)
            {
                case Target.Self:
                    result = "window";
                    break;
                case Target.Parent:
                    result = "parent";
                    break;
                case Target.Top:
                    result = "top";
                    break;
            }

            return result;
        }
    }
}