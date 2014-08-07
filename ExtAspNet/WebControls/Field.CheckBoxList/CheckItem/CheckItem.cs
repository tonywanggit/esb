
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    CheckItem.cs
 * CreatedOn:   2012-01-22
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
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI.Design.WebControls;

using Newtonsoft.Json;
using System.Web.UI.HtmlControls;
using System.Collections;


namespace ExtAspNet
{
    /// <summary>
    /// 复选框列表项
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true, DefaultProperty = "Text")]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class CheckItem
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public CheckItem()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        public CheckItem(string text, string value)
        {
            Text = text;
            Value = value;
        }

        #endregion

        #region Properties

        private bool _selected = false;
        /// <summary>
        /// 是否选中
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [Description("是否选中")]
        [DefaultValue(false)]
        [NotifyParentProperty(true)]
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }

        private string _text = String.Empty;
        /// <summary>
        /// 显示的文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("显示的文本")]
        [NotifyParentProperty(true)]
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

        private string _value = String.Empty;
        /// <summary>
        /// 值
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("值")]
        [NotifyParentProperty(true)]
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        #endregion

    }
}
