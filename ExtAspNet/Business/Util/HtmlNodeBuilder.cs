
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    HtmlNodeBuilder.cs
 * CreatedOn:   2008-05-27
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
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;

namespace ExtAspNet
{
    /// <summary>
    /// 创建HTML节点的帮助类
    /// </summary>
    public class HtmlNodeBuilder
    {
        private string _nodeName;
        private string _innerProperty;

        private Dictionary<string, string> _properties = new Dictionary<string, string>();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="nodeName">节点名称</param>
        public HtmlNodeBuilder(string nodeName)
        {
            _nodeName = nodeName;
        }

        /// <summary>
        /// 节点内部值
        /// </summary>
        public string InnerProperty
        {
            get { return _innerProperty; }
            set { _innerProperty = value; }
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="name">属性名</param>
        /// <param name="value">属性值</param>
        public void SetProperty(string name, string value)
        {
            if (_properties.ContainsKey(name))
            {
                _properties[name] = value;
            }
            else
            {
                _properties.Add(name, value);
            }
        }

        /// <summary>
        /// 取得属性的值
        /// </summary>
        /// <param name="name">属性名</param>
        /// <returns>属性值</returns>
        public string GetProperty(string name)
        {
            if (_properties.ContainsKey(name))
            {
                return _properties[name];
            }
            else
            {
                return String.Empty;
            }
        }


        /// <summary>
        /// 转化为客户端可用的HTML标签字符串
        /// </summary>
        /// <returns>客户端可用的HTML标签字符串</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("<{0}", _nodeName);

            foreach (string name in _properties.Keys)
            {
                //// Double quote is forbidden in html node property value.
                //sb.AppendFormat(" {0}={1}", name, JsHelper.Enquote(_properties[name].Replace("\"", "\\\"")));

                // HTML节点属性中不能包括双引号、左尖括号，右尖括号等等
                // <input value="ss\"dd" />  -> <input dd?="" value="ss\"/>
                // 需要对其进行HTML转意
                sb.AppendFormat(" {0}=\"{1}\"", name, HttpUtility.HtmlEncode(_properties[name]));
            }

            sb.AppendFormat(">{0}</{1}>", _innerProperty, _nodeName);

            return sb.ToString();
        }
    }
}
