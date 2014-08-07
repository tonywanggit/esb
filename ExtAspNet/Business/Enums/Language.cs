
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    LanguageType.cs
 * CreatedOn:   2008-08-20
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

namespace ExtAspNet
{
    /// <summary>
    /// 语言
    /// </summary>
    public enum Language
    {
        /// <summary>
        /// 英文
        /// </summary>
        EN,
        /// <summary>
        /// 中文（默认值）
        /// </summary>
        ZH_CN,
        /// <summary>
        /// 中文（台湾）
        /// </summary>
        ZH_TW,
        /// <summary>
        /// 葡萄牙文（巴西）
        /// </summary>
        PT_BR,
        /// <summary>
        /// 土耳其文
        /// </summary>
        TR,
        /// <summary>
        /// 俄文
        /// </summary>
        RU

        //AF,
        //BG,
        //CA,
        //CS,
        //DA,
        //DE,
        //EL_GR,
        
        //EN_GB,
        //ES,
        //FA,
        //FI,
        //FR,
        //FR_CA,
        //GR,
        //HE,
        //HR,
        //HU,
        //ID,
        //IT,
        //JA,
        //KO,
        //LT,
        //LV,
        //MK,
        //NL,
        //NO_NB,
        //NO_NN,
        //PL,
        //PT,
        
        //PT_PT,
        //RO,
        //RU,
        //SK,
        //SL,
        //SR,
        //SR_RS,
        //SV_SE,
        //TH,
        //UKR,
        //VN
        
    }

    /// <summary>
    /// 语言的类型名称
    /// </summary>
    internal static class LanguageHelper
    {
        public static string GetName(Language type)
        {
            string result = String.Empty;

            switch (type)
            {
                case Language.EN:
                    result = "en";
                    break;
                case Language.ZH_CN:
                    result = "zh_CN";
                    break;
                case Language.ZH_TW:
                    result = "zh_TW";
                    break;
                case Language.PT_BR:
                    result = "pt_BR";
                    break;
                case Language.TR:
                    result = "tr";
                    break;
                case Language.RU:
                    result = "ru";
                    break;

                //case Language.AF:
                //    result = "af";
                //    break;
                //case Language.BG:
                //    result = "bg";
                //    break;
                //case Language.CA:
                //    result = "ca";
                //    break;
                //case Language.CS:
                //    result = "cs";
                //    break;
                //case Language.DA:
                //    result = "da";
                //    break;
                //case Language.DE:
                //    result = "de";
                //    break;
                //case Language.EL_GR:
                //    result = "el_GR";
                //    break;
                
                //case Language.EN_GB:
                //    result = "en_GB";
                //    break;
                //case Language.ES:
                //    result = "es";
                //    break;
                //case Language.FA:
                //    result = "fa";
                //    break;
                //case Language.FI:
                //    result = "fi";
                //    break;
                //case Language.FR:
                //    result = "fr";
                //    break;
                //case Language.FR_CA:
                //    result = "fr_CA";
                //    break;
                //case Language.GR:
                //    result = "gr";
                //    break;
                //case Language.HE:
                //    result = "he";
                //    break;
                //case Language.HR:
                //    result = "hr";
                //    break;
                //case Language.HU:
                //    result = "hu";
                //    break;
                //case Language.ID:
                //    result = "id";
                //    break;
                //case Language.IT:
                //    result = "it";
                //    break;
                //case Language.JA:
                //    result = "ja";
                //    break;
                //case Language.KO:
                //    result = "ko";
                //    break;
                //case Language.LT:
                //    result = "lt";
                //    break;
                //case Language.LV:
                //    result = "lv";
                //    break;
                //case Language.MK:
                //    result = "mk";
                //    break;
                //case Language.NL:
                //    result = "nl";
                //    break;
                //case Language.NO_NB:
                //    result = "no_NB";
                //    break;
                //case Language.NO_NN:
                //    result = "no_NN";
                //    break;
                //case Language.PL:
                //    result = "pl";
                //    break;
                //case Language.PT:
                //    result = "pt";
                //    break;
                
                //case Language.PT_PT:
                //    result = "pt_PT";
                //    break;
                //case Language.RO:
                //    result = "ro";
                //    break;
                //case Language.RU:
                //    result = "ru";
                //    break;
                //case Language.SK:
                //    result = "sk";
                //    break;
                //case Language.SL:
                //    result = "sl";
                //    break;
                //case Language.SR:
                //    result = "sr";
                //    break;
                //case Language.SR_RS:
                //    result = "sr_RS";
                //    break;
                //case Language.SV_SE:
                //    result = "sv_SE";
                //    break;
                //case Language.TH:
                //    result = "th";
                //    break;
                
                //case Language.UKR:
                //    result = "ukr";
                //    break;
                //case Language.VN:
                //    result = "vn";
                //    break;
                
            }

            return result;
        }
    }
}