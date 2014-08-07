
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    RadioItemCollection.cs
 * CreatedOn:   2010-04-07
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
using System.Collections.ObjectModel;
using System.Web.UI;
using System.Collections;

namespace ExtAspNet
{
    /// <summary>
    /// 单选项集合，继承自Collection<RadioItem>
    /// </summary>
    public class RadioItemCollection : Collection<RadioItem>
    {

        /// <summary>
        /// 通过文本查找单选项
        /// </summary>
        /// <param name="text">文本</param>
        /// <returns>单选项</returns>
        public RadioItem FindByText(string text)
        {
            return FindByText(text, false);
        }

        /// <summary>
        /// 通过文本查找单选项
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="stripHtml">是否去除HTML标签</param>
        /// <returns>单选项</returns>
        public RadioItem FindByText(string text, bool stripHtml)
        {
            IEnumerator enumerator = GetEnumerator();

            while (enumerator.MoveNext())
            {
                RadioItem item = enumerator.Current as RadioItem;

                if (item != null)
                {
                    string itemText = item.Text;
                    if (stripHtml)
                    {
                        itemText = StringUtil.StripHtml(itemText);
                    }
                    if (itemText == text)
                    {
                        return item;
                    }
                }
            }

            return null;
        }


        /// <summary>
        /// 通过值查找单选项
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>单选项</returns>
        public RadioItem FindByValue(string value)
        {
            IEnumerator enumerator = GetEnumerator();

            while (enumerator.MoveNext())
            {
                RadioItem item = enumerator.Current as RadioItem;

                if (item != null && item.Value == value)
                {
                    return item;
                }
            }

            return null;
        }


        /// <summary>
        /// 添加单选项
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="value">值</param>
        /// <returns>新元素的插入位置</returns>
        public int Add(string text, string value)
        {
            RadioItem item = new RadioItem(text, value);

            return ((IList)this).Add(item);
        }


    }
}
