
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    ControlBaseContainerDesigner.cs
 * CreatedOn:   2008-05-05
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
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design;

using System.Web.UI.WebControls;


namespace ExtAspNet
{
    /// <summary>
    /// 设计时支持
    /// </summary>
    public class ControlBaseContainerDesigner : ContainerControlDesigner
    {
        #region static readonly

        public static readonly string DISABLED_HTML = " disabled='disabled' ";
        public static readonly string CHECKED_HTML = " checked='checked' ";
        public static readonly string DISABLED_CLASSNAME = "x-item-disabled";


        #endregion

        #region fields

        //private DesignerActionListCollection _actionLists;

        private ControlBase _control;

        #endregion

        #region GetDesignTimeHtml

        /// <summary>
        /// 设计时展示
        /// </summary>
        /// <returns></returns>
        public override string GetDesignTimeHtml()
        {

            return base.GetDesignTimeHtml();
        }
        #endregion

        #region GetErrorDesignTimeHtml

        /// <summary>
        /// 出错时设计时显示
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override string GetErrorDesignTimeHtml(Exception e)
        {
            return String.Format("{0}<br />Error Message:{1}", base.GetDesignTimeHtml(), e.Message);
        }

        #endregion

        #region Initialize

        /// <summary>
        /// 初始化控件设计时
        /// </summary>
        /// <param name="component"></param>
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            _control = component as ControlBase;
        }
        #endregion

        #region oldcode


        ///// <summary>
        ///// 取得空白图片的URL
        ///// </summary>
        ///// <returns></returns>
        //public string GetBlankImageUrl()
        //{
        //    return ResourceHelper.GetWebResourceUrl(Component.Site, ResourceManager.BLANK_IMAGE_RESOURCE_NAME);
        //}

        #endregion

        #region Properties

        /// <summary>
        /// 当前呈现的控件
        /// </summary>
        internal ControlBase CurrentControl
        {
            get
            {
                return _control;
            }
        }



        /// <summary>
        /// 是否允许调整大小
        /// </summary>
        public override bool AllowResize
        {
            get
            {
                return false;
            }
        }

        public virtual string HtmlBegin
        {
            get
            {
                return string.Empty;
            }
        }

        public virtual string HtmlEnd
        {
            get
            {
                return string.Empty;
            }
        }
        #endregion
    }
}

