
#region Comment

/*
 * Project:     ExtAspNet
 * 
 * FileName:    IconHelper.cs
 * CreatedOn:   2012-05-26
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
using System.Web;
using System.Web.UI;

namespace ExtAspNet
{
    public static partial class IconHelper
    {
        /// <summary>
        /// 获得图标的服务器地址
        /// </summary>
        /// <param name="icon">图标</param>
        /// <returns>图标的服务器地址</returns>
        public static string GetIconUrl(Icon icon)
        {
            //return ResourceHelper.GetWebResourceUrl(String.Format("ExtAspNet.res.icon.{0}", IconHelper.GetName(icon)));
            if (icon == Icon.None)
            {
                return String.Empty;
            }
            else
            {
                return String.Format("{0}/{1}", GlobalConfig.GetIconBasePath(), IconHelper.GetName(icon));
            }
        }

        /// <summary>
        /// 获取客户端可用的图标URL地址
        /// </summary>
        /// <param name="icon">图标</param>
        /// <param name="iconUrl">图标地址</param>
        /// <returns>URL地址</returns>
        public static string GetResolvedIconUrl(Icon icon, string iconUrl)
        {
            string url = iconUrl;
            if (String.IsNullOrEmpty(url))
            {
                if (icon != Icon.None)
                {
                    url = IconHelper.GetIconUrl(icon);
                }
            }
            if (String.IsNullOrEmpty(url))
            {
                return String.Empty;
            }
            else
            {
                Page page = HttpContext.Current.Handler as Page;
                return page.ResolveUrl(url);
            }
        }

        /// <summary>
        /// 将图标字符串转换为图标
        /// </summary>
        /// <param name="text">图标字符串</param>
        /// <param name="ignoreCase">是否忽略大小写</param>
        /// <returns>图标</returns>
        public static Icon String2Icon(string text, bool ignoreCase)
        {
            if (Enum.IsDefined(typeof(Icon), text))
            {
                return (Icon)Enum.Parse(typeof(Icon), text, ignoreCase);
            }
            else
            {
                return Icon.None;
            }
        }

        /// <summary>
        /// 将图标转换为图标字符串
        /// </summary>
        /// <param name="type">图标</param>
        /// <returns>图标字符串</returns>
        public static String Icon2String(Icon type)
        {
            return type.ToString();
        }


    }
}
