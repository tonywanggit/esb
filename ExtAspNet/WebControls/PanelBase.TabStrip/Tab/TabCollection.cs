
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    TabCollection.cs
 * CreatedOn:   2008-05-06
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

namespace ExtAspNet
{
    /// <summary>
    /// 选项卡集合，继承自Collection<Tab>
    /// </summary>
    public class TabCollection : Collection<Tab>
    {
        private TabStrip _tabStrip;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="tabStrip">选项卡面板实例</param>
        public TabCollection(TabStrip tabStrip)
        {
            _tabStrip = tabStrip;
        }

        protected override void InsertItem(int index, Tab item)
        {
            item.RenderWrapperNode = false;
            _tabStrip.Controls.AddAt(index, item);

            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            _tabStrip.Controls.RemoveAt(index);

            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            // We should only remove this collection related controls
            // Note we must loop from the last element(Count-1) to the first one(0)
            for (int i = Count - 1; i >= 0; i--)
            {
                _tabStrip.Controls.RemoveAt(i);
            }

            base.ClearItems();
        }


    }
}
