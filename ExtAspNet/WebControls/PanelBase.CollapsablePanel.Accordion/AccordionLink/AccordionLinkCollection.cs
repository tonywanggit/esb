
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    AccordionLinkCollection.cs
 * CreatedOn:   2008-09-27
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
    internal class AccordionLinkCollection : Collection<AccordionLink>
    {

        #region old code

        //protected override Type[] GetKnownTypes()
        //{
        //    return new Type[] { typeof(AccordionLink) };
        //}

        //protected override object CreateKnownType(int index)
        //{
        //    return new AccordionLink();
        //}


        #endregion


        private AccordionPane _panel;
        public AccordionLinkCollection(AccordionPane panel)
        {
            _panel = panel;
        }


        protected override void InsertItem(int index, AccordionLink item)
        {
            base.InsertItem(index, item);

            item.RenderWrapperNode = false;
            _panel.Controls.AddAt(index, item);
        }

    }
}
