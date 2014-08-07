
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    DesignTimeResourceHelper.cs
 * CreatedOn:   2008-05-04
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
using System.Text.RegularExpressions;
using System.IO;
using System.Web.UI;
using System.ComponentModel;

namespace ExtAspNet
{
    /// <summary>
    /// 注册设计时资源
    /// </summary>
    internal class DesignTimeResourceHelper
    {

        #region static readonly

        private static readonly string STYLE_BLOCK_TEMPLATE = "<style type=\"text/css\">{0}</style>";
        //private static readonly string DESIGN_TIME_CONTROL_ID = "design-time-css-holder-field-id";

        #endregion

        #region fields

        private ISite _site;


        #endregion

        #region GetInstance

        private static DesignTimeResourceHelper _helper;

        /// <summary>
        /// 取得 DesignTimeResourceHelper 的实例，单件模式
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static DesignTimeResourceHelper GetInstance(ISite site)
        {
            if (_helper == null)
            {
                _helper = new DesignTimeResourceHelper(site);

            }

            return _helper;
        }

        #endregion

        #region Constructor

        public DesignTimeResourceHelper(ISite site)
        {
            _site = site;
        }

        #endregion

        #region SetupInlineStyle


        public void SetupInlineStyle()
        {
            //System.Web.UI.WebControls.Literal litStyle = new System.Web.UI.WebControls.Literal();
            //litStyle.ID = DESIGN_TIME_CONTROL_ID;
            //litStyle.Text = GetInlineStyle();

            ////_site.Container.Add(hiddenControl);
            ////(_site.Container.Components[0] as Page).Controls.Add(litStyle);
            //_site.Container.Add(litStyle);




            //DesignTimeControl litStyle = new DesignTimeControl();
            //litStyle.ID = DESIGN_TIME_CONTROL_ID;
            //////litStyle.Text = GetInlineStyle();

            //////_site.Container.Add(hiddenControl);
            //////(_site.Container.Components[0] as Page).Controls.Add(litStyle);
            ////_site.Container.Add(litStyle);
            

           //Page page =  (_site.Container.Components[0] as Page);

           ////System.Web.UI.HtmlControls.HtmlHead header =

           // //page.Header = new System.Web.UI.HtmlControls.HtmlHead();
            
        }

        /// <summary>
        /// 设计时是否包含控件
        /// </summary>
        /// <param name="componentID"></param>
        /// <returns></returns>
        private Control GetHiddenControl(string controlID)
        {
            foreach (IComponent com in _site.Container.Components)
            {
                Control c = com as Control;
                if (c != null && c.ID == controlID)
                {
                    return c;
                }
            }

            return null;
        }


        #endregion

        #region GetInlineStyle

        private string _styleContent = String.Empty;

        /// <summary>
        /// 取得内联样式表
        /// </summary>
        /// <returns></returns>
        public string GetInlineStyle()
        {
            if (String.IsNullOrEmpty(_styleContent))
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(GetStyleContent("ExtAspNet.res.css.ext-all.css"));

                //if (AboutConfig.Theme.ToLower() == ConfigThemeValues.GRAY)
                //{
                //    sb.Append(GetStyleContent("ExtAspNet.res.css.xtheme-gray.css"));
                //}
                // ux
                sb.Append(GetStyleContent("ExtAspNet.res.css.ux.css"));

                _styleContent = sb.ToString();
            }

            return String.Format(STYLE_BLOCK_TEMPLATE, _styleContent);
        }



        /// <summary>
        /// 取得样式的内容
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        private string GetStyleContent(string resourceName)
        {
            using (StreamReader reader = new StreamReader(typeof(ExtAspNet.ControlBase).Assembly.GetManifestResourceStream(resourceName)))
            {
                return ParseCssWebResourceUrls(reader.ReadToEnd());
            }
        }

        /// <summary>
        /// 转化 CSS 的内容
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        private string ParseCssWebResourceUrls(string resourceContent)
        {
            Regex regex = new Regex("<%=WebResource\\(\".*\\.(gif|png)*\"\\)%>");
            foreach (Match match in regex.Matches(resourceContent))
            {
                string webResourceName = match.Value.Replace("<%=WebResource(\"", string.Empty).Replace("\")%>", string.Empty);
                resourceContent = resourceContent.Replace(match.Value, String.Format("\"{0}\"", ResourceHelper.GetWebResourceUrl(_site, webResourceName)));
            }
            return resourceContent;
        }
        #endregion
    }
}
