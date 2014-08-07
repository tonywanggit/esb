
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    FormRowCollection.cs
 * CreatedOn:   2008-04-23
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
    /// 表单行控件集合，继承自Collection<FormRow>
    /// </summary>
    public class FormRowCollection : Collection<FormRow>
    {
        private Form form;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="form">表单实例</param>
        public FormRowCollection(Form form)
        {
            this.form = form;
        }

        protected override void InsertItem(int index, FormRow item)
        {
            item.RenderWrapperNode = false;
            form.Controls.AddAt(index, item);

            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            form.Controls.RemoveAt(index);

            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            // We should only remove this collection related controls
            // Note we must loop from the last element(Count-1) to the first one(0)
            for (int i = Count - 1; i >= 0; i--)
            {
                form.Controls.RemoveAt(i);
            }

            base.ClearItems();
        }
    }
}
