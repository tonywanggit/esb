
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    JSONUtil.cs
 * CreatedOn:   2010-04-18
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
using System.Reflection;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ExtAspNet
{
    public class JSONUtil
    {
        public static int[] IntArrayFromJArray(JArray ja)
        {
            int length = ja.Count;

            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = ja[i].Value<int>();
            }
            return array;
        }


        public static string[] StringArrayFromJArray(JArray ja)
        {
            int length = ja.Count;

            string[] array = new string[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = ja[i].Value<string>();// ja.getString(i);
            }
            return array;
        }

        public static object[] ObjectArrayFromJArray(JArray ja)
        {
            int length = ja.Count;

            object[] array = new object[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = ja[i].Value<JValue>().Value;// ja.getValue(i);
            }
            return array;
        }

    }
}
