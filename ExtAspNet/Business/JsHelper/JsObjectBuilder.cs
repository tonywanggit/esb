
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
using System.Collections.Specialized;

namespace ExtAspNet
{
    /// <summary>
    /// 创建Javascript对象参数的帮助类
    /// </summary>
    public class JsObjectBuilder
    {
        #region fields

        private Dictionary<string, string> _properties = new Dictionary<string, string>();

        #endregion

        #region Properties

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

        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public JsObjectBuilder()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="propertyValue">属性值</param>
        public JsObjectBuilder(string propertyName, object propertyValue)
        {
            AddProperty(propertyName, propertyValue, false);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="propertyValue">属性值</param>
        /// <param name="persistOriginal">是否保持原样</param>
        public JsObjectBuilder(string propertyName, object propertyValue, bool persistOriginal)
        {
            AddProperty(propertyName, propertyValue, persistOriginal);
        }

        #endregion

        #region RemoveProperty

        /// <summary>
        /// 删除属性
        /// </summary>
        /// <param name="propertyName">属性名</param>
        public void RemoveProperty(string propertyName)
        {
            if (_properties.ContainsKey(propertyName))
            {
                _properties.Remove(propertyName);
            }
        }

        #endregion

        #region HasProperty

        /// <summary>
        /// 是否包含属性
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <returns></returns>
        public bool ContainsProperty(string propertyName)
        {
            return _properties.ContainsKey(propertyName);
        }

        #endregion

        #region AddProperty

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="propertyValue">属性值</param>
        public void AddProperty(string propertyName, object propertyValue)
        {
            AddProperty(propertyName, propertyValue, false);
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="propertyValue">属性值</param>
        /// <param name="persistOriginal">是否保持原样</param>
        public void AddProperty(string propertyName, object propertyValue, bool persistOriginal)
        {
            if (persistOriginal)
            {
                _properties.Add(propertyName, propertyValue.ToString());
            }
            else
            {
                if (propertyValue is string)
                {
                    _properties.Add(propertyName, JsHelper.Enquote(propertyValue.ToString()));
                }
                else if (propertyValue is bool)
                {
                    _properties.Add(propertyName, propertyValue.ToString().ToLower());
                }
                else if (propertyValue is float || propertyValue is double)
                {
                    _properties.Add(propertyName, JsHelper.NumberToString(propertyValue));
                }
                else
                {
                    _properties.Add(propertyName, propertyValue.ToString());
                }
            }
        }

        #endregion

        #region GetProperty

        /// <summary>
        /// 获取属性
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <returns>属性值</returns>
        public string GetProperty(string propertyName)
        {
            if (_properties.ContainsKey(propertyName))
            {
                return _properties[propertyName];
            }

            return String.Empty;
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

            foreach (string key in _properties.Keys)
            {
                sb.AppendFormat("{0}:{1},", key, _properties[key]);
            }

            return "{" + sb.ToString().TrimEnd(',') + "}";
        }

        #endregion
    }
}
