
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    ImageField.cs
 * CreatedOn:   2008-05-28
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
using System.Web.UI.WebControls;
using System.Globalization;
using System.Reflection;


namespace ExtAspNet
{
    /// <summary>
    /// 表格图片列
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class ImageField : GridColumn
    {

        #region Properties


        public string _dataImageUrlField = String.Empty;

        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("图片地址字段")]
        public string DataImageUrlField
        {
            get
            {
                return _dataImageUrlField;
            }
            set
            {
                _dataImageUrlField = value;
            }
        }



        public string _dataImageUrlFormatString = String.Empty;

        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("图片地址字段格式化字符串")]
        public string DataImageUrlFormatString
        {
            get
            {
                return _dataImageUrlFormatString;
            }
            set
            {
                _dataImageUrlFormatString = value;
            }
        }


        public Unit _imageWidth = Unit.Empty;

        /// <summary>
        /// 图片的宽度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "")]
        [Description("图片的宽度")]
        public Unit ImageWidth
        {
            get
            {
                return _imageWidth;
            }
            set
            {
                _imageWidth = value;
            }
        }

        public Unit _imageHeight = Unit.Empty;

        /// <summary>
        /// 图片的高度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "")]
        [Description("图片的高度")]
        public Unit ImageHeight
        {
            get
            {
                return _imageHeight;
            }
            set
            {
                _imageHeight = value;
            }
        }

        #endregion

        #region Methods

        internal override string GetColumnValue(GridRow row)
        {
            string result = String.Empty;

            if (!String.IsNullOrEmpty(DataImageUrlField))
            {
                object value = row.GetPropertyValue(DataImageUrlField);
                string imageUrl = String.Empty;

                if (!String.IsNullOrEmpty(DataImageUrlFormatString))
                {
                    imageUrl = String.Format(DataImageUrlFormatString, value);
                }
                else
                {
                    imageUrl = value.ToString();
                }

                string cssStr = String.Empty;
                if (ImageWidth != Unit.Empty)
                {
                    cssStr += String.Format("width:{0}px;", ImageWidth.Value);
                }
                if (ImageHeight != Unit.Empty)
                {
                    cssStr += String.Format("height:{0}px;", ImageHeight.Value);
                }

                result = String.Format("<img src=\"{0}\" style=\"border-width: 0px;{1}\"/>", Grid.ResolveUrl(imageUrl), cssStr);
            }

            string tooltip = GetTooltipString(row);
            if (!String.IsNullOrEmpty(tooltip))
            {
                result = result.ToString().Insert(4, tooltip);
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



