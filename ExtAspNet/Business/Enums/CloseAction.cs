

#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    CloseAction.cs
 * CreatedOn:   2010-01-25
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
    /// 关闭窗体的动作
    /// </summary>
    public enum CloseAction
    {
        /// <summary>
        /// 关闭窗体（默认值）
        /// </summary>
        Hide,
        /// <summary>
        /// 关闭窗体后刷新父页面
        /// </summary>
        HideRefresh,
        /// <summary>
        /// 关闭窗体后会发父页面（需要注册OnClose事件处理函数）
        /// </summary>
        HidePostBack
    }

    /// <summary>
    /// 关闭窗体的动作
    /// </summary>
    internal static class CloseActionName
    {
        public static string GetName(CloseAction type)
        {
            string result = String.Empty;

            switch (type)
            {
                case CloseAction.Hide:
                    result = "hide";
                    break;
                case CloseAction.HideRefresh:
                    result = "hide_refresh";
                    break;
                case CloseAction.HidePostBack:
                    result = "hide_postback";
                    break;
            }

            return result;
        }
    }
}