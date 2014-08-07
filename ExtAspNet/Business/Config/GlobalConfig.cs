
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    AboutConfig.cs
 * CreatedOn:   2008-05-15
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
using System.Reflection;
using System.Configuration;
using System.Web.Configuration;
using System.Web.UI.Design;
using System.ComponentModel;

namespace ExtAspNet
{
    public static class GlobalConfig
    {

        #region Runtime Section and Designtime Section

        /// <summary>
        /// Runtime Section
        /// </summary>
        private static ConfigSection section = ConfigurationManager.GetSection(ConfigSectionName.ExtAspNet) as ConfigSection;


        /// <summary>
        /// Refer:http://flimflan.com/blog/AccessingWebconfigAtDesignTimeInNET20.aspx
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public static ConfigSection GetDesignTimeSection(ISite site)
        {
            IWebApplication webApp = (IWebApplication)site.GetService(typeof(IWebApplication));
            if (webApp != null)
            {
                Configuration config = webApp.OpenWebConfiguration(false);
                if (config != null)
                {
                    ConfigurationSection section = config.GetSection(ConfigSectionName.ExtAspNet);
                    if (section != null)
                    {
                        return section as ConfigSection;
                    }
                }
            }
            return null;
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// 产品名称
        /// </summary>
        public static string ProductName
        {
            get
            {
                return "ExtAspNet";
            }
        }

        /// <summary>
        /// 当前版本
        /// </summary>
        public static string ProductVersion
        {
            get
            {
                Version v = Assembly.GetExecutingAssembly().GetName().Version;
                //string vs = String.Format("{0}.{1} ", v.Major, v.Minor, v.Build);
                //vs += v.Build >= 10 ? "final" : "beta" + v.Build;
                //return vs;
                return String.Format("{0}.{1}.{2}", v.Major, v.Minor, v.Build);
            }
        }

        /// <summary>
        /// 主题
        /// </summary>
        public static Theme GetTheme()
        {
            return (Theme)Enum.Parse(typeof(Theme), section.Theme, true);
        }

        //public static ThemeType GetTheme(ISite site)
        //{
        //    return (ThemeType)Enum.Parse(typeof(ThemeType), GetDesignTimeSection(site).Theme, true);
        //}

        /// <summary>
        /// 语言
        /// </summary>
        public static Language GetLanguage()
        {
            return (Language)Enum.Parse(typeof(Language), section.Language, true);
        }

        //public static LanguageType GetLanguage(ISite site)
        //{
        //    return (LanguageType)Enum.Parse(typeof(LanguageType), GetDesignTimeSection(site).Language, true);
        //}


        /// <summary>
        /// 表单中消息的位置
        /// </summary>
        public static MsgTarget GetFormMessageTarget()
        {
            return (MsgTarget)Enum.Parse(typeof(MsgTarget), section.FormMessageTarget, true);
        }

        //public static MsgTarget GetFormMessageTarget(ISite site)
        //{
        //    return (MsgTarget)Enum.Parse(typeof(MsgTarget), GetDesignTimeSection(site).FormMessageTarget, true);
        //}


        /// <summary>
        /// 表单中字段距离右侧的宽度
        /// </summary>
        public static int GetFormOffsetRight()
        {
            return Convert.ToInt32(section.FormOffsetRight);
        }

        //public static int GetFormOffsetRight(ISite site)
        //{
        //    return Convert.ToInt32(GetDesignTimeSection(site).FormOffsetRight);
        //}

        /// <summary>
        /// 表单中字段标签的宽度
        /// </summary>
        public static int GetFormLabelWidth()
        {
            return Convert.ToInt32(section.FormLabelWidth);
        }

        /// <summary>
        /// 表单中字段与标签的分隔符
        /// </summary>
        public static string GetFormLabelSeparator()
        {
            return section.FormLabelSeparator;
        }

        //public static int GetFormLabelWidth(ISite site)
        //{
        //    return Convert.ToInt32(GetDesignTimeSection(site).FormLabelWidth);
        //}

        /// <summary>
        /// Ajax超时时间（单位：秒，默认：60s）
        /// </summary>
        public static int GetAjaxTimeout()
        {
            return Convert.ToInt32(section.AjaxTimeout);
        }


        /// <summary>
        /// 是否启用Ajax
        /// </summary>
        public static bool GetEnableAjax()
        {
            return Convert.ToBoolean(section.EnableAjax);
        }


        /// <summary>
        /// 是否启用Ajax提示
        /// </summary>
        public static bool GetEnableAjaxLoading()
        {
            return Convert.ToBoolean(section.EnableAjaxLoading);
        }

        /// <summary>
        /// Ajax提示的类型
        /// </summary>
        public static AjaxLoadingType GetAjaxLoadingType()
        {
            return (AjaxLoadingType)Enum.Parse(typeof(AjaxLoadingType), section.AjaxLoadingType, true);
        }



        /// <summary>
        /// 是否启用大字体
        /// </summary>
        public static bool GetEnableBigFont()
        {
            return Convert.ToBoolean(section.EnableBigFont);
        }

        /// <summary>
        /// DEBUG 模式
        /// </summary>
        public static bool GetDebugMode()
        {
            return Convert.ToBoolean(section.DebugMode);
        }

        /// <summary>
        /// 图标的根路径
        /// </summary>
        public static string GetIconBasePath()
        {
            return section.IconBasePath;
        }

        /// <summary>
        /// 自定义样式的根路径
        /// </summary>
        public static string GetCustomThemeBasePath()
        {
            return section.CustomThemeBasePath;
        }

        /// <summary>
        /// 自定义样式的名称
        /// </summary>
        public static string GetCustomTheme()
        {
            return section.CustomTheme;
        }

        ///// <summary>
        ///// 是否启用Ajax
        ///// </summary>
        //public static bool GetEnableAjax(ISite site)
        //{
        //    return Convert.ToBoolean(GetDesignTimeSection(site).EnableAjax);
        //}
        #endregion

        #region GetDefaultBackgroundColor

        public static string GetDefaultBackgroundColor()
        {
            string backgroundColor = String.Empty;

            if (String.IsNullOrEmpty(PageManager.Instance.CustomTheme))
            {
                string theme = PageManager.Instance.Theme.ToString();
                if (theme.ToLower() == ThemeHelper.GetName(Theme.Blue))
                {
                    backgroundColor = "#DFE8F6";
                }
                else if (theme.ToLower() == ThemeHelper.GetName(Theme.Gray))
                {
                    backgroundColor = "#efefef";
                }
            }

            return backgroundColor;
        }

        //public static string GetLightBackgroundColor(string theme)
        //{
        //    string backgroundColor = "#efefef";
        //    if (theme.ToLower() == ThemeHelper.GetName(Theme.Blue))
        //    {
        //        backgroundColor = "#E6F0FF";
        //    }

        //    return backgroundColor;
        //}

        ///// <summary>
        ///// 主题的默认背景色
        ///// </summary>
        ///// <returns></returns>
        //public static string ThemeDefaultBackgroundColor
        //{
        //    get
        //    {
        //        string backgroundColor = "#efefef";
        //        if (Theme == ConfigThemeValues.BLUE)
        //        {
        //            backgroundColor = "#DFE8F6";
        //        }

        //        return backgroundColor;
        //    }
        //}

        ///// <summary>
        ///// 主题的默认背景色
        ///// </summary>
        ///// <returns></returns>
        //public static string ThemeLightBackgroundColor
        //{
        //    get
        //    {
        //        string backgroundColor = "#efefef";
        //        if (Theme == ConfigThemeValues.BLUE)
        //        {
        //            backgroundColor = "#E6F0FF";
        //        }

        //        return backgroundColor;
        //    }
        //} 

        #endregion
    }
}
