

#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    TriggerIconType.cs
 * CreatedOn:   2008-06-18
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
    /// 触发器输入框右侧图标的类型
    /// </summary>
    public enum TriggerIcon
    {
        /// <summary>
        /// 无（默认值）
        /// </summary>
        None,
        /// <summary>
        /// 搜索图标
        /// </summary>
        Search,
        /// <summary>
        /// 清空图标
        /// </summary>
        Clear,
        /// <summary>
        /// 日期图标
        /// </summary>
        Date
    }

    /// <summary>
    /// 系统图标名称
    /// </summary>
    internal static class TriggerIconHelper
    {
        public static string GetName(TriggerIcon type)
        {
            string result = String.Empty;

            switch (type)
            {
                case TriggerIcon.Search:
                    result = "x-form-search-trigger";
                    break;
                case TriggerIcon.Clear:
                    result = "x-form-clear-trigger";
                    break;
                case TriggerIcon.Date:
                    result = "x-form-date-trigger";
                    break;
            }

            return result;
        }
    }
}