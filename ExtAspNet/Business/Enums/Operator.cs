
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    Operator.cs
 * CreatedOn:   2008-07-08
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
    /// 操作符（用于表单控件的客户端验证）
    /// </summary>
    public enum Operator
    {
        /// <summary>
        /// 等于（默认值）
        /// </summary>
        Equal,
        /// <summary>
        /// 大于
        /// </summary>
        GreaterThan,
        /// <summary>
        /// 大于等于
        /// </summary>
        GreaterThanEqual,
        /// <summary>
        /// 小于
        /// </summary>
        LessThan,
        /// <summary>
        /// 小于等于
        /// </summary>
        LessThanEqual,
        /// <summary>
        /// 不等于
        /// </summary>
        NotEqual
    }

    /// <summary>
    /// 操作符名称
    /// </summary>
    internal static class OperatorHelper
    {
        public static string GetName(Operator type)
        {
            string result = String.Empty;

            switch (type)
            {
                case Operator.Equal:
                    result = "==";
                    break;
                case Operator.GreaterThan:
                    result = ">";
                    break;
                case Operator.GreaterThanEqual:
                    result = ">=";
                    break;
                case Operator.LessThan:
                    result = "<";
                    break;
                case Operator.LessThanEqual:
                    result = "<=";
                    break;
                case Operator.NotEqual:
                    result = "!=";
                    break;
            }

            return result;
        }
    }
}