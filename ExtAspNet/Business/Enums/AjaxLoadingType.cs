
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    AjaxLoadingType.cs
 * CreatedOn:   2012-05-12
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
    /// Ajax提示信息的类型
    /// </summary>
    public enum AjaxLoadingType
    {
        /// <summary>
        /// 在页面顶部显示黄色提示框（默认值）
        /// </summary>
        Default,
        /// <summary>
        /// Extjs的页面遮罩提示框
        /// </summary>
        Mask
    }


    /// <summary>
    /// Ajax提示信息的类型名称
    /// </summary>
    internal static class AjaxLoadingTypeName
    {
        public static string GetName(AjaxLoadingType type)
        {
            string result = String.Empty;

            switch (type)
            {
                case AjaxLoadingType.Default:
                    result = "default";
                    break;
                case AjaxLoadingType.Mask:
                    result = "mask";
                    break;
            }

            return result;
        }
    }

}