
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    XmlAttributeMapping.cs
 * CreatedOn:   2008-07-21
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
using System.Data;
using System.Reflection;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.Design;
using System.Drawing.Design;
using System.Xml;


namespace ExtAspNet
{
    /// <summary>
    /// 树节点的属性映射
    /// </summary>
    [ToolboxItem(false)]
    public class XmlAttributeMapping
    {

        #region Properties

        private string _from = String.Empty;

        /// <summary>
        /// 映射源
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("映射源")]
        public string From
        {
            get
            {
                return _from;
            }
            set
            {
                _from = value;
            }
        }

        private string _to = String.Empty;


        /// <summary>
        /// 映射目标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("映射目标")]
        public string To
        {
            get
            {
                return _to;
            }
            set
            {
                _to = value;
            }
        }



        #endregion

    }
}



