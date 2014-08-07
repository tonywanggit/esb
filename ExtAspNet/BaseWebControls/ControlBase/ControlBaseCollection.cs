
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    ControlBaseCollection.cs
 * CreatedOn:   2008-06-08
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
    /// 控件集合，继承自Collection<ControlBase>
    /// </summary>
    public class ControlBaseCollection : Collection<ControlBase>
    {
        // This Collection should always in the first place of Controls, Other Collections will be followed, for example Toolbars.

        private ControlBase _parent;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="parentControl">父控件实例</param>
        public ControlBaseCollection(ControlBase parentControl)
        {
            this._parent = parentControl;
        }

        protected override void InsertItem(int index, ControlBase item)
        {
            item.RenderWrapperNode = false;
            _parent.Controls.AddAt(index, item);

            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            _parent.Controls.RemoveAt(index);

            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            // We should only remove this collection related controls
            // Note we must loop from the last element(Count-1) to the first one(0)
            for (int i = Count - 1; i >= 0; i--)
            {
                _parent.Controls.RemoveAt(i);
            }

            base.ClearItems();
        }

    }
}
