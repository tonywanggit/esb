using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtAspNet
{
    public class XState
    {
        #region Constructor
        
        private ControlBase _control = null;

        public XState(ControlBase control)
        {
            _control = control;
        }

        #endregion

        #region Index Property

        private Dictionary<string, object> _state = new Dictionary<string, object>();

        /// <summary>
        /// 获取设置 XState 属性值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get
            {
                if (!_state.ContainsKey(key))
                {
                    return null;
                }
                else
                {
                    return _state[key];
                }
            }
            set
            {
                _state[key] = value;

                // 如果是页面第一次加载（页面初始化时那些不是AjaxProperties的属性的更改，也要保存到XState中）
                // _control.Page == null, 是在初始化页面控件的属性的时候
                if (_control.Page != null && !_control.Page.IsPostBack && _control.InitialComplete)
                {
                    if (!_control.AjaxProperties.Contains(key))
                    {
                        AddModifiedProperty(key);
                    }
                }
            }
        } 

        #endregion

        #region ModifiedProperties ClientPropertiesModifiedInServer

        private List<string> _modifiedProperties = new List<string>();

        /// <summary>
        /// 当前请求中改变的属性列表，既包含服务器端改变的属性，也包含客户端改变的属性
        /// </summary>
        public List<string> ModifiedProperties
        {
            get { return _modifiedProperties; }
            set { _modifiedProperties = value; }
        }

        /// <summary>
        /// 增加在当前请求中改变的属性列表（控件可以自己手工设置，以便保存在 X_STATE 中）
        /// </summary>
        /// <param name="property"></param>
        public void AddModifiedProperty(string property)
        {
            if (!_modifiedProperties.Contains(property))
            {
                _modifiedProperties.Add(property);
            }
        }


        private List<string> _clientPropertiesModifiedInServer = new List<string>();

        /// <summary>
        /// 客户端可以改变的属性在服务器端被改变了
        /// </summary>
        public List<string> ClientPropertiesModifiedInServer
        {
            get { return _clientPropertiesModifiedInServer; }
            set { _clientPropertiesModifiedInServer = value; }
        }


        private void AddClientPropertyModifiedInServer(string property)
        {
            if (!_clientPropertiesModifiedInServer.Contains(property))
            {
                _clientPropertiesModifiedInServer.Add(property);
            }
        }
        
        #endregion

        #region BackupInitializedProperties BackupPostDataProperty

        private Dictionary<string, string> _initializedProperties = new Dictionary<string, string>();
        private Dictionary<string, string> _postDataProperties = new Dictionary<string, string>();

        /// <summary>
        /// 备份初始化属性值
        /// 在输出 AJAX 回发之前，会拿这个初始属性值和当时属性值做对比，以确定这些属性是否被用户改变
        /// </summary>
        public void BackupInitializedProperties()
        {
            foreach (string prop in _control.AjaxProperties)
            {
                _initializedProperties.Add(prop, GetPropertyHashcode(prop));
            }
        }

        /// <summary>
        /// 备份 PostData 的属性值（也就是在客户端改变的属性值）
        /// </summary>
        /// <param name="prop"></param>
        public void BackupPostDataProperty(string prop)
        {
            _postDataProperties.Add(prop, GetPropertyHashcode(prop));
        }

        /// <summary>
        /// 计算被修改的属性列表（更新 ModifiedProperties 和 ClientPropertiesModifiedInServer 两个值）
        /// 这个需要在 OnPreRender 中调用，在页面第一次加载，正常的回发以及AJAX回发时都要调用
        /// </summary>
        public void CalculateModifiedProperties()
        {
            // Step1
            foreach (string prop in _control.AjaxProperties)
            {
                if (_initializedProperties[prop] != GetPropertyHashcode(prop))
                {
                    AddModifiedProperty(prop);
                }
            }

            // Step2
            foreach (string prop in _control.ClientAjaxProperties)
            {
                string backupValue = String.Empty;
                if (_postDataProperties.ContainsKey(prop))
                {
                    backupValue = _postDataProperties[prop];
                }
                else
                {
                    backupValue = _initializedProperties[prop];
                }

                if (backupValue != GetPropertyHashcode(prop))
                {
                    AddClientPropertyModifiedInServer(prop);

                    //既然这个ClientAjaxProperty在服务器端被改变，则这个属性一定是属于ModifiedProperties，因为存在如下逻辑：
                    // 一个CheckBox默认的Checked为false，客户端改变为true，服务器端又修改为false，则在Step1中就无法判断出这是一个ModifiedProperty.
                    AddModifiedProperty(prop);
                }
            }
        }

        private string GetPropertyHashcode(string prop)
        {
            object propValue = _control.GetPropertyJSONValue(prop);
            return propValue == null ? "" : propValue.ToString();
        } 
        #endregion

        #region GetTotalModifiedProperties

        /// <summary>
        /// 页面第一次加载至今改变过的属性列表总和（其中可能经历多次正常的页面回发和局部 AJAX 回发）
        /// </summary>
        /// <returns></returns>
        public List<string> GetTotalModifiedProperties()
        {
            List<string> props = new List<string>();

            // Now we are in a page postback.
            if (_control.Page.IsPostBack)
            {
                // Get modified properties from current HTTP request values (These properties must have been changed in post client or server).
                foreach (JProperty prop in _control.PostBackState.Properties())
                {
                    props.Add(prop.Name);
                }
            }

            // Modified properties in current page load.
            foreach (string prop in _modifiedProperties)
            {
                if (!props.Contains(prop))
                {
                    props.Add(prop);
                }
            }

            return props;
        }


        #endregion

        #region oldcode


        //private List<string> _clientModifiedProperties = new List<string>();
        //public void AddClientModifiedProperties(string property)
        //{
        //    if (!_clientModifiedProperties.Contains(property))
        //    {
        //        _clientModifiedProperties.Add(property);
        //    }
        //}
        //public List<string> GetClientModifiedProperties()
        //{
        //    return _clientModifiedProperties;
        //}
        //public bool ClientModifiedPropertiesContains(string property)
        //{
        //    return _clientModifiedProperties.Contains(property);
        //}
        //public void SetPropertyViaPostData(string property, object value)
        //{
        //    _state[property] = value;

        //    AddClientModifiedProperties(property);
        //}





        //public object this[string key]
        //{
        //    get
        //    {
        //        if (!_state.ContainsKey(key))
        //        {
        //            return null;
        //        }
        //        else
        //        {
        //            return _state[key];
        //        }
        //    }
        //    set
        //    {
        //        //object oldValue = ObjectUtil.GetPropertyValue(_control, key);
        //        //if (IsValueChanged(oldValue, value))
        //        //{
        //        _state[key] = value;

        //        if (_control.ControlInitialized) //  && _ajaxProperties.Contains(key)
        //        {
        //            _modifiedProperties.Add(key);
        //        }
        //        //}
        //    }
        //}


        //// It's impossible
        //private bool IsValueChanged(object oldValue, object newValue)
        //{
        //    if (oldValue != null && newValue != null)
        //    {
        //        if (oldValue.GetType().BaseType == typeof(Array))
        //        {
        //            return new JArray((Array)oldValue).ToString() != new JArray((Array)newValue).ToString();
        //        }
        //        return !oldValue.Equals(newValue);
        //    }
        //    return oldValue != newValue;
        //}

        
        #endregion

    }
}
