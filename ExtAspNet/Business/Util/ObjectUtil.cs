
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    ObjectUtil.cs
 * CreatedOn:   2008-06-11
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
using System.Reflection;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtAspNet
{
    public class ObjectUtil
    {
        /// <summary>
        /// 取得属性的值
        /// </summary>
        /// <param name="obj">可能是DataRowView或一个对象</param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static object GetPropertyValue(object obj, string propertyName)
        {
            object result = null;

            try
            {
                if (obj is DataRow)
                {
                    result = (obj as DataRow)[propertyName];
                }
                else if (obj is DataRowView)
                {
                    result = (obj as DataRowView)[propertyName];
                }
                else if (obj is JObject)
                {
                    result = (obj as JObject).Value<JValue>(propertyName).Value; //.getValue(propertyName);
                }
                else
                {
                    result = GetPropertyValueFormObject(obj, propertyName);
                }
            }
            catch (Exception)
            {
                // 找不到此属性
            }

            return result;
        }

        /// <summary>
        /// Get the property from an object.
        /// The property can be "Color", "BodyStyle" or "Info.UserName".
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private static object GetPropertyValueFormObject(object obj, string propertyName)
        {
            object rowObj = obj;
            object result = null;

            if (propertyName.IndexOf(".") > 0)
            {
                string[] properties = propertyName.Split('.');
                object tmpObj = rowObj;

                for (int i = 0; i < properties.Length; i++)
                {
                    PropertyInfo property = tmpObj.GetType().GetProperty(properties[i]);
                    if (property != null)
                    {
                        tmpObj = property.GetValue(tmpObj, null);
                    }
                }

                result = tmpObj;
            }
            else
            {
                PropertyInfo property = rowObj.GetType().GetProperty(propertyName);
                if (property != null)
                {
                    result = property.GetValue(rowObj, null);
                }
            }

            return result;
        }
    }
}
