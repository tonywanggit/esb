
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    ResourceHelper.cs
 * CreatedOn:   2008-04-07
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->2008-04-11    sanshi.ustc@gmail.com  
 * 
 * 
 * 
 * 
 */

#endregion

using System;
using System.Collections.Generic;
using System.Text;

using System.Web;
using System.Web.UI;
using System.Collections.Specialized;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;


namespace ExtAspNet
{

    internal static class ResourceHelper
    {

        #region GetWebResourceUrl

        public static string GetWebResourceUrl(string resourceName)
        {
            Page page = HttpContext.Current.CurrentHandler as Page;
            if (page != null)
            {
                return GetWebResourceUrl(page, resourceName);
            }

            return String.Empty;
        }

        /// <summary>
        /// 嵌入资源url地址
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static string GetWebResourceUrl(Page page, string resourceName)
        {
            string resourceUrl = String.Empty;
            resourceUrl = page.ClientScript.GetWebResourceUrl(typeof(ExtAspNet.ControlBase), resourceName);

            //ManifestResourceInfo info = typeof(ExtAspNet.ControlBase).Assembly.GetManifestResourceInfo(resourceName);

            //// 告诉HttpCompress，不要设置ETag，同时设置Expires为一年后的今天
            //resourceUrl += "&expires=1";

            return resourceUrl;
        }

        /// <summary>
        /// 设计时嵌入资源url地址
        /// </summary>
        /// <param name="site"></param>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static string GetWebResourceUrl(ISite site, string resourceName)
        {
            string resourceUrl = String.Empty;
            if (site != null)
            {
                IResourceUrlGenerator service = (IResourceUrlGenerator)site.GetService(typeof(IResourceUrlGenerator));
                if (service != null)
                {
                    resourceUrl = service.GetResourceUrl(site.Component.GetType(), resourceName);
                }
            }

            //// 告诉HttpCompress，不要设置ETag，同时设置Expires为一年后的今天
            //resourceUrl += "&expires=1";

            return resourceUrl;
        }
        #endregion

        #region GetResourceContent

        /// <summary>
        /// 取得资源的内容
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static string GetResourceContent(string resourceName)
        {
            string result = String.Empty;
            using (StreamReader sr = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)))
            {
                result = sr.ReadToEnd();
            }

            return result;
        }


        public static string ResolveResourceContent(Page page, string resourceContent)
        {
            Regex regex = new Regex(@"<%=WebResource\("".*\.(gif|png)*""\)%>");
            MatchCollection matches = regex.Matches(resourceContent);
            foreach (Match match in matches)
            {
                string url = match.Value.Replace("<%=WebResource(\"", string.Empty).Replace("\")%>", string.Empty);
                resourceContent = resourceContent.Replace(match.Value, string.Format("{0}", GetWebResourceUrl(page, url)));
            }

            return resourceContent;
        }

        #endregion


    }
}
