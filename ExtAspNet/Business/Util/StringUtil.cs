
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    StringUtil.cs
 * CreatedOn:   2008-06-25
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
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;
using System.Text.RegularExpressions;

namespace ExtAspNet
{
    public class StringUtil
    {
        #region EnumFromName EnumToName

        public static object EnumFromName(Type enumType, string enumName)
        {
            return Enum.Parse(enumType, enumName);
        }

        public static string EnumToName(Enum param)
        {
            return Enum.GetName(param.GetType(), param);
        }

        #endregion

        #region StripHtml

        /// <summary>
        /// 去除字符串中的Html
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string StripHtml(string source)
        {
            return Regex.Replace(source, @"<[\s\S]*?>", "", RegexOptions.IgnoreCase);
        }

        #endregion

        #region GetIntListFromString GetStringListFromString

        /// <summary>
        /// 由字符串"1,2,3"转化为整形列表[1,2,3]
        /// </summary>
        /// <param name="postValue"></param>
        /// <returns></returns>
        public static List<int> GetIntListFromString(string postValue)
        {
            if (String.IsNullOrEmpty(postValue))
            {
                return new List<int>();
            }

            List<int> intList = new List<int>();
            string[] intStrArray = postValue.Trim().TrimEnd(',').Split(',');
            foreach (string rowIndex in intStrArray)
            {
                if (!String.IsNullOrEmpty(rowIndex))
                {
                    intList.Add(Convert.ToInt32(rowIndex));
                }
            }

            intList.Sort();

            return intList;
        }

        /// <summary>
        /// 由字符串"ssdd,2,ok"转化为字符串列表["ssdd","2","ok"]
        /// </summary>
        /// <param name="postValue"></param>
        /// <returns></returns>
        public static List<string> GetStringListFromString(string postValue)
        {
            if (String.IsNullOrEmpty(postValue))
            {
                return new List<string>();
            }

            List<string> strList = new List<string>();
            string[] strArray = postValue.Trim().TrimEnd(',').Split(',');
            foreach (string str in strArray)
            {
                if (!String.IsNullOrEmpty(str))
                {
                    strList.Add(str);
                }
            }

            // 按照从小到大排序 
            strList.Sort();

            return strList;
        }

        /// <summary>
        /// 由字符串数组["ssdd","2","ok"]转化为字符串"ssdd,2,ok"
        /// </summary>
        /// <param name="postValue"></param>
        /// <returns></returns>
        public static string GetStringFromStringArray(string[] strArray)
        {
            if (strArray == null || strArray.Length == 0)
            {
                return String.Empty;
            }

            StringBuilder sb = new StringBuilder();
            foreach (string str in strArray)
            {
                sb.AppendFormat("{0},", str);
            }

            return sb.ToString().TrimEnd(',');
        }

        /// <summary>
        /// 由整型数组[2,3,4]转化为字符串"2,3,4"
        /// </summary>
        /// <param name="postValue"></param>
        /// <returns></returns>
        public static string GetStringFromIntArray(int[] intArray)
        {
            if (intArray == null || intArray.Length == 0)
            {
                return String.Empty;
            }

            StringBuilder sb = new StringBuilder();
            foreach (int str in intArray)
            {
                sb.AppendFormat("{0},", str);
            }

            return sb.ToString().TrimEnd(',');
        }

        #endregion

        #region CompareIntArray/CompareStringArray

        /// <summary>
        /// 比较两个整形数组是否相等
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public static bool CompareIntArray(int[] array1, int[] array2)
        {
            if (array1 == null && array2 == null)
            {
                return true;
            }

            if ((array1 == null && array2 != null) || (array1 != null && array2 == null))
            {
                return false;
            }

            if (array1.Length != array2.Length)
            {
                return false;
            }

            List<int> list1 = new List<int>(array1);
            List<int> list2 = new List<int>(array2);

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 比较两个字符串数组是否相等
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        public static bool CompareStringArray(string[] array1, string[] array2)
        {
            if (array1 == null && array2 == null)
            {
                return true;
            }

            if ((array1 == null && array2 != null) || (array1 != null && array2 == null))
            {
                return false;
            }

            if (array1.Length != array2.Length)
            {
                return false;
            }

            List<string> list1 = new List<string>(array1);
            List<string> list2 = new List<string>(array2);

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i])
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region ConvertPercentageToDecimalString

        /// <summary>
        /// 将 10% 转换为 0.1 的字符串的形式
        /// </summary>
        /// <param name="percentageStr"></param>
        /// <returns></returns>
        public static string ConvertPercentageToDecimalString(string percentageStr)
        {
            string decimalStr = String.Empty;

            percentageStr = percentageStr.Trim().Replace("％", "%").TrimEnd('%');

            try
            {
                decimalStr = (Convert.ToDouble(percentageStr) * 0.01).ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                ;
            }

            return decimalStr;
        }

        #endregion
    }
}
