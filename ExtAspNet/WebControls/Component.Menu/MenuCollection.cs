
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    MenuCollection.cs
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
    /// 菜单控件集合，继承自Collection<Menu>
    /// </summary>
    public class MenuCollection : Collection<Menu>
    {

        private ControlBase _parent;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parent">父控件实例</param>
        public MenuCollection(ControlBase parent)
        {
            _parent = parent;
        }

        protected override void InsertItem(int index, Menu item)
        {
            base.InsertItem(index, item);

            item.RenderWrapperNode = false;
            _parent.Controls.AddAt(index, item);
        }
    }
}
