
#region Comment

/*
 * Project£º    ExtAspNet
 * 
 * FileName:    ConfigSection.cs
 * CreatedOn:   2008-04-07
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description£º
 *      ->
 *   
 * History£º
 *      ->2008-04-11    sanshi.ustc@gmail.com  
 * 
 * 
 * 
 * 
 */

#endregion


using System;
using System.Configuration;

namespace ExtAspNet
{
    public class ConfigSection : ConfigurationSection
    {
        [ConfigurationProperty(ConfigPropertyName.THEME, DefaultValue = ConfigPropertyValue.THEME_DEFAULT)]
        public string Theme
        {
            get
            {
                return (string)base[ConfigPropertyName.THEME];
            }
            set
            {
                base[ConfigPropertyName.THEME] = value;
            }
        }


        [ConfigurationProperty(ConfigPropertyName.LANGUAGE, DefaultValue = ConfigPropertyValue.LANGUAGE_DEFAULT)]
        public string Language
        {
            get
            {
                return (string)base[ConfigPropertyName.LANGUAGE];
            }
            set
            {
                base[ConfigPropertyName.LANGUAGE] = value;
            }
        }

        [ConfigurationProperty(ConfigPropertyName.FROMMESSAGETARGET, DefaultValue = ConfigPropertyValue.FORM_MESSAGETARGET_DEFAULT)]
        public string FormMessageTarget
        {
            get
            {
                return (string)base[ConfigPropertyName.FROMMESSAGETARGET];
            }
            set
            {
                base[ConfigPropertyName.FROMMESSAGETARGET] = value;
            }
        }

        [ConfigurationProperty(ConfigPropertyName.FORMOFFSETRIGHT, DefaultValue = ConfigPropertyValue.FORM_OFFSETRIGHT_DEFAULT)]
        public int FormOffsetRight
        {
            get
            {
                return (int)base[ConfigPropertyName.FORMOFFSETRIGHT];
            }
            set
            {
                base[ConfigPropertyName.FORMOFFSETRIGHT] = value;
            }
        }

        [ConfigurationProperty(ConfigPropertyName.FORMLABELWIDTH, DefaultValue = ConfigPropertyValue.FORM_LABELWIDTH_DEFAULT)]
        public int FormLabelWidth
        {
            get
            {
                return (int)base[ConfigPropertyName.FORMLABELWIDTH];
            }
            set
            {
                base[ConfigPropertyName.FORMLABELWIDTH] = value;
            }
        }

        [ConfigurationProperty(ConfigPropertyName.FORMLABELSEPARATOR, DefaultValue = ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT)]
        public string FormLabelSeparator
        {
            get
            {
                return (string)base[ConfigPropertyName.FORMLABELSEPARATOR];
            }
            set
            {
                base[ConfigPropertyName.FORMLABELSEPARATOR] = value;
            }
        }

        [ConfigurationProperty(ConfigPropertyName.ENABLEAJAX, DefaultValue = ConfigPropertyValue.ENABLE_AJAX_DEFAULT)]
        public bool EnableAjax
        {
            get
            {
                return (bool)base[ConfigPropertyName.ENABLEAJAX];
            }
            set
            {
                base[ConfigPropertyName.ENABLEAJAX] = value;
            }
        }

        [ConfigurationProperty(ConfigPropertyName.ENABLEAJAXLOADING, DefaultValue = ConfigPropertyValue.ENABLE_AJAX_LOADING_DEFAULT)]
        public bool EnableAjaxLoading
        {
            get
            {
                return (bool)base[ConfigPropertyName.ENABLEAJAXLOADING];
            }
            set
            {
                base[ConfigPropertyName.ENABLEAJAXLOADING] = value;
            }
        }

        [ConfigurationProperty(ConfigPropertyName.AJAXLOADINGTYPE, DefaultValue = ConfigPropertyValue.AJAX_LOADING_TYPE_DEFAULT)]
        public string AjaxLoadingType
        {
            get
            {
                return (string)base[ConfigPropertyName.AJAXLOADINGTYPE];
            }
            set
            {
                base[ConfigPropertyName.AJAXLOADINGTYPE] = value;
            }
        }

        [ConfigurationProperty(ConfigPropertyName.AJAXTIMEOUT, DefaultValue = ConfigPropertyValue.AJAX_TIMEOUT_DEFAULT)]
        public int AjaxTimeout
        {
            get
            {
                return (int)base[ConfigPropertyName.AJAXTIMEOUT];
            }
            set
            {
                base[ConfigPropertyName.AJAXTIMEOUT] = value;
            }
        }

        [ConfigurationProperty(ConfigPropertyName.ENABLEBIGFONT, DefaultValue = false)]
        public bool EnableBigFont
        {
            get
            {
                return (bool)base[ConfigPropertyName.ENABLEBIGFONT];
            }
            set
            {
                base[ConfigPropertyName.ENABLEBIGFONT] = value;
            }
        }


        [ConfigurationProperty(ConfigPropertyName.DEBUGMODE, DefaultValue = false)]
        public bool DebugMode
        {
            get
            {
                return (bool)base[ConfigPropertyName.DEBUGMODE];
            }
            set
            {
                base[ConfigPropertyName.DEBUGMODE] = value;
            }
        }


        [ConfigurationProperty(ConfigPropertyName.ICONBASEPATH, DefaultValue = ConfigPropertyValue.ICON_BASE_PATH_DEFAULT)]
        public string IconBasePath
        {
            get
            {
                return (string)base[ConfigPropertyName.ICONBASEPATH];
            }
            set
            {
                base[ConfigPropertyName.ICONBASEPATH] = value;
            }
        }

        [ConfigurationProperty(ConfigPropertyName.CUSTOMTHEMEBASEPATH, DefaultValue = ConfigPropertyValue.CUSTOM_THEME_BASE_PATH_DEFAULT)]
        public string CustomThemeBasePath
        {
            get
            {
                return (string)base[ConfigPropertyName.CUSTOMTHEMEBASEPATH];
            }
            set
            {
                base[ConfigPropertyName.CUSTOMTHEMEBASEPATH] = value;
            }
        }

        [ConfigurationProperty(ConfigPropertyName.CUSTOMTHEME, DefaultValue = ConfigPropertyValue.CUSTOM_THEME_DEFAULT)]
        public string CustomTheme
        {
            get
            {
                return (string)base[ConfigPropertyName.CUSTOMTHEME];
            }
            set
            {
                base[ConfigPropertyName.CUSTOMTHEME] = value;
            }
        }

    }
}
