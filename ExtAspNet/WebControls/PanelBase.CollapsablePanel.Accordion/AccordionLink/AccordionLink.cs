
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    AccordionLink.cs
 * CreatedOn:   2008-09-27
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

using Nii.JSON;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Web.UI.Design;


namespace ExtAspNet
{
    //[ToolboxItem(false)]
    //[ParseChildren(true, DefaultProperty = "Text")]
    //[PersistChildren(false)]
    //[ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    [ToolboxItem(false)]
    [Description("链接")]
    [ToolboxData("<{0}:AccordionLink NavigateUrl=\"#\" Target=\"_blank\" Text=\"Accordion Link\" IconUrl=\"\" runat=\"server\"></{0}:AccordionLink>")]
    [ParseChildren(true, DefaultProperty = "Text")]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    internal class AccordionLink : ControlBase
    {

        #region constructor

        public AccordionLink()
        {

        }

        #endregion

        #region properties

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
                object obj = XState["Selected"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["Selected"] = value;
            }
        }

        /// <summary>
        /// 图标地址
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("图标地址")]
        [Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
        public string IconUrl
        {
            get
            {
                object obj = XState["IconUrl"];
                if (obj == null)
                {
                    if (Icon != Icon.None)
                    {
                        obj = IconHelper.GetIconUrl(Icon);
                    }
                }
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["IconUrl"] = value;
            }
        }


        /// <summary>
        /// 预定义图标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Icon.None)]
        [Description("预定义图标")]
        public virtual Icon Icon
        {
            get
            {
                object obj = XState["Icon"];
                return obj == null ? Icon.None : (Icon)obj;
            }
            set
            {
                XState["Icon"] = value;
            }
        }

        /// <summary>
        /// 文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("文本")]
        [NotifyParentProperty(true)]
        public virtual string Text
        {
            get
            {
                object obj = XState["Text"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["Text"] = value;
            }
        }

        /// <summary>
        /// 点击链接时需要执行的客户端脚本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("点击链接时需要执行的客户端脚本")]
        [NotifyParentProperty(true)]
        public string OnClientClick
        {
            get
            {
                object obj = XState["OnClientClick"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["OnClientClick"] = value;
            }
        }

        /// <summary>
        /// 链接地址
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("链接地址")]
        [NotifyParentProperty(true)]
        public string NavigateUrl
        {
            get
            {
                object obj = XState["NavigateUrl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["NavigateUrl"] = value;
            }
        }

        /// <summary>
        /// 链接目标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("链接目标")]
        [NotifyParentProperty(true)]
        public string Target
        {
            get
            {
                object obj = XState["Target"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["Target"] = value;
            }
        }


        #endregion

    }
}
