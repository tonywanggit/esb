
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    MenuItemCollection.cs
 * CreatedOn:   2008-07-12
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
    /// 菜单项控件集合，继承自Collection<BaseMenuItem>
    /// </summary>
    public class MenuItemCollection : Collection<BaseMenuItem>
    {

        private Menu _parent;

        /// <summary>
        /// /// 构造函数
        /// </summary>
        /// <param name="parent">菜单实例</param>
        public MenuItemCollection(Menu parent)
        {
            _parent = parent;
        }

        protected override void InsertItem(int index, BaseMenuItem item)
        {
            base.InsertItem(index, item);

            item.RenderWrapperNode = false;
            _parent.Controls.AddAt(index, item);
        }

    }
}
