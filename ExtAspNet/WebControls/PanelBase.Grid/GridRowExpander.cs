
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    GridRowExpander.cs
 * CreatedOn:   2012-01-11
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
using System.Data;
using System.Reflection;
using System.Web.UI.WebControls;


namespace ExtAspNet
{
    [ToolboxItem(false)]
    internal class GridRowExpander
    {
        #region Properties

        private bool _expandOnEnter = true;

        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否回车展开行扩展")]
        public bool ExpandOnEnter
        {
            get
            {
                return _expandOnEnter;
            }
            set
            {
                _expandOnEnter = value;
            }
        }

        private bool _expandOnDoubleClick = true;

        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否双击展开行扩展")]
        public bool ExpandOnDoubleClick
        {
            get
            {
                return _expandOnDoubleClick;
            }
            set
            {
                _expandOnDoubleClick = value;
            }
        }



        private string[] _dataFields = null;

        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("数据字段")]
        [TypeConverter(typeof(StringArrayConverter))]
        public string[] DataFields
        {
            get
            {
                return _dataFields;
            }
            set
            {
                _dataFields = value;
            }
        }

        private string _dataFormatString = String.Empty;

        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("数据字段格式字符串")]
        public string DataFormatString
        {
            get
            {
                return _dataFormatString;
            }
            set
            {
                _dataFormatString = value;
            }
        }


        #endregion

        

        
    }
}



