
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    ListItemCollection.cs
 * CreatedOn:   2008-04-24
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
    /// 列表项集合，继承自Collection<ListItem>
    /// </summary>
    public class ListItemCollection : Collection<ListItem>
    {
        /// <summary>
        /// 通过文本查找列表项
        /// </summary>
        /// <param name="text">文本</param>
        /// <returns>列表项</returns>
        public ListItem FindByText(string text)
        {
            return FindByText(text, false);
        }

        /// <summary>
        /// 通过文本查找列表项
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="stripHtml">是否去除HTML标签</param>
        /// <returns>列表项</returns>
        public ListItem FindByText(string text, bool stripHtml)
        {
            IEnumerator enumerator = GetEnumerator();

            while (enumerator.MoveNext())
            {
                ListItem item = enumerator.Current as ListItem;

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
        /// 通过值查找列表项
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>列表项</returns>
        public ListItem FindByValue(string value)
        {
            IEnumerator enumerator = GetEnumerator();

            while (enumerator.MoveNext())
            {
                ListItem item = enumerator.Current as ListItem;

                if (item != null && item.Value == value)
                {
                    return item;
                }
            }

            return null;
        }


        /// <summary>
        /// 添加列表项
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="value">值</param>
        /// <returns>新元素的插入位置</returns>
        public int Add(string text, string value)
        {
            ListItem item = new ListItem(text, value);

            return ((IList)this).Add(item);
        }


        #region old code

        //public int GetSelectedIndex()
        //{
        //    int selectedIndex = -1;
        //    for (int i = 0, count = Items.Count; i < count; i++)
        //    {
        //        if (Items[i].Selected)
        //        {
        //            selectedIndex = i;
        //            break;
        //        }
        //    }
        //    return selectedIndex;
        //}

        //public string GetSelectedValue()
        //{
        //    int selectedIndex = GetSelectedIndex();
        //    if (selectedIndex >= 0 && selectedIndex < Items.Count)
        //    {
        //        return Items[selectedIndex].Value;
        //    }
        //    return null;
        //}

        

        #endregion

    }
}
