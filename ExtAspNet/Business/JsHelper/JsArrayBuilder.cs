
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    JsArrayBuilder.cs
 * CreatedOn:   2008-04-21
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
using System.Collections.Specialized;

namespace ExtAspNet
{
    /// <summary>
    /// 创建Javascript数组参数的帮助类
    /// </summary>
    public class JsArrayBuilder
    {
        #region fields

        private List<string> _properties = new List<string>();

        //public List<string> Properties
        //{
        //    get { return _properties; }
        //    set { _properties = value; }
        //}

        #endregion

        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public JsArrayBuilder()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="propertyValue">初始属性值</param>
        public JsArrayBuilder(object propertyValue)
        {
            AddProperty(propertyValue, false);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="propertyValue">初始属性值</param>
        /// <param name="persistOriginal">是否保持原样</param>
        public JsArrayBuilder(object propertyValue, bool persistOriginal)
        {
            AddProperty(propertyValue, persistOriginal);
        }

        #endregion

        #region RemoveProperty

        /// <summary>
        /// 删除属性
        /// </summary>
        /// <param name="propertyValue">属性值</param>
        public void RemoveProperty(string propertyValue)
        {
            if (_properties.Contains(propertyValue))
            {
                _properties.Remove(propertyValue);
            }
        }

        #endregion

        #region AddProperty

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="propertyValue">属性值</param>
        public void AddProperty(object propertyValue)
        {
            AddProperty(propertyValue, false);
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="propertyValue">属性值</param>
        /// <param name="persistOriginal">是否保持原样</param>
        public void AddProperty(object propertyValue, bool persistOriginal)
        {
            if (persistOriginal)
            {
                _properties.Add(propertyValue.ToString());
            }
            else
            {
                if (propertyValue is string)
                {
                    _properties.Add(JsHelper.Enquote(propertyValue.ToString()));
                }
                else if (propertyValue is bool)
                {
                    _properties.Add(propertyValue.ToString().ToLower());
                }
                else if (propertyValue is float || propertyValue is double)
                {
                    _properties.Add(JsHelper.NumberToString(propertyValue));
                }
                else
                {
                    _properties.Add(propertyValue.ToString());
                }
            }
        }

        #endregion

        #region Count

        /// <summary>
        /// 已经添加属性的个数
        /// </summary>
        public int Count
        {
            get
            {
                return _properties.Count;
            }
        }

        #endregion

        #region override ToString

        /// <summary>
        /// 返回对象的JSON字符串形式
        /// </summary>
        /// <returns>对象的JSON形式</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (string item in _properties)
            {
                sb.AppendFormat("{0},", item);
            }

            return "[" + sb.ToString().TrimEnd(',') + "]";
        }

        #endregion
    }
}
