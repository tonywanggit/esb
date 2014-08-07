using System;
using System.Collections.Generic;
using System.Text;

namespace ExtAspNet
{
    public class OptionBuilder
    {
        #region fields

        private JsObjectBuilder _defaultBuilder = new JsObjectBuilder();

        #endregion

        #region Listeners

        private JsObjectBuilder _listeners = new JsObjectBuilder();

        public JsObjectBuilder Listeners
        {
            get { return _listeners; }
            set { _listeners = value; }
        }

        #endregion

        #region Constructor

        public OptionBuilder()
        {
        }

        public OptionBuilder(string propertyName, object propertyValue)
        {
            _defaultBuilder.AddProperty(propertyName, propertyValue, false);
        }

        public OptionBuilder(string propertyName, object propertyValue, bool persistOriginal)
        {
            _defaultBuilder.AddProperty(propertyName, propertyValue, persistOriginal);
        }

        #endregion

        #region RemoveProperty

        /// <summary>
        /// 删除属性
        /// </summary>
        /// <param name="propertyName"></param>
        public void RemoveProperty(string propertyName)
        {
            _defaultBuilder.RemoveProperty(propertyName);
        }

        #endregion

        #region AddProperty

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        public void AddProperty(string propertyName, object propertyValue)
        {
            AddProperty(propertyName, propertyValue, false);
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <param name="persistOriginal">是否保持原样</param>
        public void AddProperty(string propertyName, object propertyValue, bool persistOriginal)
        {
            if (_defaultBuilder.ContainsProperty(propertyName))
            {
                _defaultBuilder.RemoveProperty(propertyName);
            }

            _defaultBuilder.AddProperty(propertyName, propertyValue, persistOriginal);
        }

        #endregion

        #region GetProperty

        /// <summary>
        /// 使用这个方法需要特别注意，因为这里返回的不是设置的属性了
        /// 比如："margin-right:5px;"被添加到OB中就变成："\"margin-right:5px;\""
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        internal string GetProperty(string propertyName)
        {
            return _defaultBuilder.GetProperty(propertyName);
        } 

        #endregion

        #region override ToString
        /// <summary>
        /// 返回对象的Json字符串表示
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Listeners.Count > 0)
            {
                //// 如果在 Listeners 中没有添加上下文，则添加默认的 this
                //if (!Listeners.ContainsProperty(OptionName.Scope))
                //{
                //    Listeners.AddProperty(OptionName.Scope, "box", true);
                //}

                AddProperty("listeners", Listeners.ToString(), true);
            }

            return _defaultBuilder.ToString();
        }
        #endregion
    }
}
