
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    RegionCollection.cs
 * CreatedOn:   2008-06-12
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
    internal class RegionCollection : Collection<Region> //MyStateCollection<Region>
    {
        private PanelBase _panelbase;
        public RegionCollection(PanelBase panelbase)
        {
            _panelbase = panelbase;
        }


        protected override void InsertItem(int index, Region item)
        {
            base.InsertItem(index, item);

            item.RenderWrapperDiv = false;
            _panelbase.Controls.AddAt(index, item);
        }
    }
}
