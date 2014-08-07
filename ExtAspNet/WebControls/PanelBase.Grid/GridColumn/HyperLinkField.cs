
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    HyperLinkField.cs
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
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Text;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Globalization;
using System.Reflection;

using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ExtAspNet
{
    /// <summary>
    /// 表格超链接列
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class HyperLinkField : GridColumn
    {

        #region Properties

        private bool _enabled = true;

        /// <summary>
        /// 是否可用
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否可用")]
        public virtual bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }

        private string _dataTextField = String.Empty;

        /// <summary>
        /// 字段名称
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("字段名称")]
        public string DataTextField
        {
            get
            {
                return _dataTextField;
            }
            set
            {
                _dataTextField = value;
            }
        }

        private string _dataTextFormatString = String.Empty;
        
        /// <summary>
        /// 字段格式化字符串
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("字段格式化字符串")]
        public string DataTextFormatString
        {
            get
            {
                return _dataTextFormatString;
            }
            set
            {
                _dataTextFormatString = value;
            }
        }

        private string[] _dataNavigateUrlFields = null;

        /// <summary>
        /// 绑定到超链接地址的字段名称列表
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("绑定到超链接地址的字段名称列表")]
        [TypeConverter(typeof(StringArrayConverter))]
        public string[] DataNavigateUrlFields
        {
            get
            {
                return _dataNavigateUrlFields;
            }
            set
            {
                _dataNavigateUrlFields = value;
            }
        }

        //private bool _dataNavigateUrlFieldsEncode = false;

        /// <summary>
        /// 对每个绑定到超链接地址的字段进行URL编码（此属性废弃，请使用UrlEncode属性）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("对每个绑定到超链接地址的字段进行URL编码（此属性废弃，请使用UrlEncode属性）")]
        public bool DataNavigateUrlFieldsEncode
        {
            get
            {
                return _urlEncode;
            }
            set
            {
                _urlEncode = value;
            }
        }


        private bool _urlEncode = true;

        /// <summary>
        /// 对每个绑定到超链接地址的字段进行URL编码（默认为true）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("对每个绑定到超链接地址的字段进行URL编码")]
        public bool UrlEncode
        {
            get
            {
                return _urlEncode;
            }
            set
            {
                _urlEncode = value;
            }
        }


        public string _dataNavigateUrlFormatString = String.Empty;

        /// <summary>
        /// 绑定到超链接地址的字段格式化字符串
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("绑定到超链接地址的字段格式化字符串")]
        public string DataNavigateUrlFormatString
        {
            get
            {
                return _dataNavigateUrlFormatString;
            }
            set
            {
                _dataNavigateUrlFormatString = value;
            }
        }

        public string _target = String.Empty;

        /// <summary>
        /// 打开超链接的目标框架
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("打开超链接的目标框架")]
        public string Target
        {
            get
            {
                return _target;
            }
            set
            {
                _target = value;
            }
        }


        public string _navigateUrl = String.Empty;

        /// <summary>
        /// 超链接地址
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("超链接地址")]
        public string NavigateUrl
        {
            get
            {
                return _navigateUrl;
            }
            set
            {
                _navigateUrl = value;
            }
        }

        public string _text = String.Empty;

        /// <summary>
        /// 超链接文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("超链接文本")]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }



        private bool _htmlEncode = true;

        /// <summary>
        /// 显示之前进行HTML编码（默认为true）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("显示之前进行HTML编码（默认为true）")]
        public bool HtmlEncode
        {
            get
            {
                return _htmlEncode;
            }
            set
            {
                _htmlEncode = value;
            }
        }


        private bool _htmlEncodeFormatString = true;

        /// <summary>
        /// 是否在应用DataFormatString属性之后进行HTML编码（默认为true）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否在应用DataFormatString属性之后进行HTML编码（默认为true）")]
        public bool HtmlEncodeFormatString
        {
            get
            {
                return _htmlEncodeFormatString;
            }
            set
            {
                _htmlEncodeFormatString = value;
            }
        }

        #endregion

        #region Methods

        internal override string GetColumnValue(GridRow row)
        {
            HtmlNodeBuilder nb = new HtmlNodeBuilder("a");

            #region DataTextField

            if (!String.IsNullOrEmpty(DataTextField))
            {
                object value = row.GetPropertyValue(DataTextField);

                string text = String.Empty;
                if (!String.IsNullOrEmpty(DataTextFormatString))
                {
                    text = String.Format(DataTextFormatString, value);
                    if (HtmlEncodeFormatString)
                    {
                        text = HttpUtility.HtmlEncode(text);
                    }
                }
                else
                {
                    text = value.ToString();
                    if (HtmlEncode)
                    {
                        text = HttpUtility.HtmlEncode(text);
                    }
                }

                nb.InnerProperty = text;
            }
            else
            {
                nb.InnerProperty = Text;
            }

            #endregion

            if (Enabled)
            {

                #region DataNavigateUrlFields

                string hrefOriginal = String.Empty;

                if (DataNavigateUrlFields != null && DataNavigateUrlFields.Length > 0)
                {
                    //string[] fields = DataNavigateUrlFields.Trim().TrimEnd(',').Split(',');
                    string[] fields = DataNavigateUrlFields;

                    List<object> fieldValues = new List<object>();
                    foreach (string field in fields)
                    {
                        if (!String.IsNullOrEmpty(field))
                        {
                            string fieldValue = row.GetPropertyValue(field).ToString();
                            if (UrlEncode)
                            {
                                fieldValue = HttpUtility.UrlEncode(fieldValue);
                            }
                            fieldValues.Add(fieldValue);
                        }
                    }

                    if (!String.IsNullOrEmpty(DataNavigateUrlFormatString))
                    {
                        hrefOriginal = String.Format(DataNavigateUrlFormatString, fieldValues.ToArray());
                    }
                    else
                    {
                        if (fieldValues.Count > 0)
                        {
                            hrefOriginal = fieldValues[0].ToString();
                        }
                    }
                }
                else
                {
                    hrefOriginal = NavigateUrl;
                }

                nb.SetProperty("href", Grid.ResolveUrl(hrefOriginal));

                #endregion

                #region Target

                if (!String.IsNullOrEmpty(Target))
                {
                    nb.SetProperty("target", Target);
                }
                else
                {
                    nb.SetProperty("target", "_blank");
                }

                #endregion

                nb.SetProperty("onclick", "X.util.stopEventPropagation.apply(null, arguments);");

            }
            else
            {
                nb.SetProperty("class", "x-item-disabled");
                nb.SetProperty("disabled", "disabled");
            }

            //string result2 = nb.ToString();

            //string tooltip = GetTooltipString(row);
            //if (!String.IsNullOrEmpty(tooltip))
            //{
            //    result2 = result2.ToString().Insert(2, tooltip);
            //}


            //return result2;

            string result = nb.ToString();

            string tooltip = GetTooltipString(row);
            if (!String.IsNullOrEmpty(tooltip))
            {
                result = result.ToString().Insert("<a".Length, tooltip);
            }

            return result;
        }


        //public override string GetFieldType()
        //{
        //    return "string";
        //}

        #endregion

    }
}



