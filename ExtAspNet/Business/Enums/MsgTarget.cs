
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    js_css_resource.cs
 * CreatedOn:   2008-04-07
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->2008-04-11    sanshi.ustc@gmail.com  
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
    /// 表单客户端验证提示消息的类型
    /// </summary>
    public enum MsgTarget
    {
        /// <summary>
        /// 浮动提示
        /// </summary>
        Qtip,
        /// <summary>
        /// 使用HTML标签的title属性
        /// </summary>
        Title,
        /// <summary>
        /// 在字段下面通过一个div层来显示消息
        /// </summary>
        Under,
        /// <summary>
        /// 在字段右侧显示一个错误图标（默认值）
        /// </summary>
        Side
    }

    /// <summary>
    /// 提示消息的类型名称
    /// </summary>
    internal static class MsgTargetHelper
    {
        public static string GetName(MsgTarget type)
        {
            string result = String.Empty;

            switch (type)
            {
                case MsgTarget.Qtip:
                    result = "qtip";
                    break;
                case MsgTarget.Title:
                    result = "title";
                    break;
                case MsgTarget.Under:
                    result = "under";
                    break;
                case MsgTarget.Side:
                    result = "side";
                    break;
            }

            return result;
        }
    }
}