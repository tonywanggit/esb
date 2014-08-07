
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    CheckItemCollection.cs
 * CreatedOn:   2012-01-22
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
    /// 复选项集合，继承自Collection<CheckItem>
    /// </summary>
    public class CheckItemCollection : Collection<CheckItem>
    {

        /// <summary>
        /// 通过文本查找复选项
        /// </summary>
        /// <param name="text">文本</param>
        /// <returns>复选项</returns>
        public CheckItem FindByText(string text)
        {
            return FindByText(text, false);
        }

        /// <summary>
        /// 通过文本查找复选项
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="stripHtml">是否去除HTML标签</param>
        /// <returns>复选项</returns>
        public CheckItem FindByText(string text, bool stripHtml)
        {
            IEnumerator enumerator = GetEnumerator();

            while (enumerator.MoveNext())
            {
                CheckItem item = enumerator.Current as CheckItem;

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
        /// 通过值查找复选项
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>复选项</returns>
        public CheckItem FindByValue(string value)
        {
            IEnumerator enumerator = GetEnumerator();

            while (enumerator.MoveNext())
            {
                CheckItem item = enumerator.Current as CheckItem;

                if (item != null && item.Value == value)
                {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// 添加复选项
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="value">值</param>
        /// <returns>新元素的插入位置</returns>
        public int Add(string text, string value)
        {
            CheckItem item = new CheckItem(text, value);

            return ((IList)this).Add(item);
        }


    }
}
