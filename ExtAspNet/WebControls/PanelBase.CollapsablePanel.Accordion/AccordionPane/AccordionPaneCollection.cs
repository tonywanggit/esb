
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    AccordionPanelCollection.cs
 * CreatedOn:   2008-06-16
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
    /// 手风琴面板控件集合，继承自Collection<AccordionPane>
    /// </summary>
    public class AccordionPaneCollection : Collection<AccordionPane>
    {
        private Accordion _accordion;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="accordion">手风琴实例</param>
        public AccordionPaneCollection(Accordion accordion)
        {
            _accordion = accordion;
        }


        protected override void InsertItem(int index, AccordionPane item)
        {
            item.RenderWrapperNode = false;
            _accordion.Controls.AddAt(index, item);

            base.InsertItem(index, item);
        }

    }
}
