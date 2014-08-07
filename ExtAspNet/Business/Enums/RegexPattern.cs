
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    RegexPattern.cs
 * CreatedOn:   2008-04-24
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
    /// 正则表达式常用类型（用于表单控件的客户端验证）
    /// </summary>
    public enum RegexPattern
    {
        /// <summary>
        /// 无（默认值）
        /// </summary>
        None,
        /// <summary>
        /// 数字
        /// </summary>
        NUMBER,
        /// <summary>
        /// 字母
        /// </summary>
        ALPHA,
        /// <summary>
        /// 字母数字
        /// </summary>
        ALPHA_NUMERIC,
        /// <summary>
        /// 字母下划线
        /// </summary>
        ALPHA_UNDERLINE,
        /// <summary>
        /// 字母数字下划线
        /// </summary>
        ALPHA_NUMERIC_UNDERLINE,
        /// <summary>
        /// 小写字母
        /// </summary>
        ALPHA_LOWER_CASE,
        /// <summary>
        /// 大写字母
        /// </summary>
        ALPHA_UPPER_CASE,
        /// <summary>
        /// 电子邮箱
        /// </summary>
        EMAIL,
        /// <summary>
        /// 网址
        /// </summary>
        URL,
        /// <summary>
        /// 邮政编码（中华人民共和国）
        /// </summary>
        POSTAL_CODE,
        /// <summary>
        /// IP地址
        /// </summary>
        IP_ADDRESS,
        /// <summary>
        /// 身份证（中华人民共和国）
        /// </summary>
        IDENTITY_CARD
    }

    /// <summary>
    /// 正则表达式常用类型 内容
    /// </summary>
    internal static class RegexPatternHelper
    {
        private const string NUMBER = "^[0-9]+$";
        private const string ALPHA = "^[a-zA-Z]+$";
        private const string ALPHA_NUMERIC = "^[a-zA-Z0-9]+$";
        private const string ALPHA_UNDERLINE = "^[a-zA-Z_]+$";
        private const string ALPHA_NUMERIC_UNDERLINE = "^[a-zA-Z0-9_]+$";
        private const string ALPHA_LOWER_CASE = @"^[a-z]+$";
        private const string ALPHA_UPPER_CASE = @"^[A-Z]+$";
        private const string EMAIL = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
        private const string URL = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
        private const string POSTAL_CODE = @"^\d{6}$";
        private const string IP_ADDRESS = @"/(\d+)\.(\d+)\.(\d+)\.(\d+)/g";
        private const string IDENTITY_CARD = @"/^(\d{15}|\d{17}[x0-9])$/i";

        public static string GetRegexValue(RegexPattern type)
        {
            string result = String.Empty;

            switch (type)
            {
                case RegexPattern.None:
                    result = String.Empty;
                    break;
                case RegexPattern.NUMBER:
                    result = NUMBER;
                    break;
                case RegexPattern.ALPHA:
                    result = ALPHA;
                    break;
                case RegexPattern.ALPHA_NUMERIC:
                    result = ALPHA_NUMERIC;
                    break;
                case RegexPattern.ALPHA_UNDERLINE:
                    result = ALPHA_UNDERLINE;
                    break;
                case RegexPattern.ALPHA_NUMERIC_UNDERLINE:
                    result = ALPHA_NUMERIC_UNDERLINE;
                    break;
                case RegexPattern.ALPHA_LOWER_CASE:
                    result = ALPHA_LOWER_CASE;
                    break;
                case RegexPattern.ALPHA_UPPER_CASE:
                    result = ALPHA_UPPER_CASE;
                    break;
                case RegexPattern.EMAIL:
                    result = EMAIL;
                    break;
                case RegexPattern.URL:
                    result = URL;
                    break;
                case RegexPattern.POSTAL_CODE:
                    result = POSTAL_CODE;
                    break;
                case RegexPattern.IP_ADDRESS:
                    result = IP_ADDRESS;
                    break;
                case RegexPattern.IDENTITY_CARD:
                    result = IDENTITY_CARD;
                    break;
            }

            return result;
        }
    }

}
