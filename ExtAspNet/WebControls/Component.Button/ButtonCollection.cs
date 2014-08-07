
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    FieldCollection.cs
 * CreatedOn:   2008-04-22
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

namespace ExtAspNet
{
    public class ButtonCollection : Collection<Button>
    {
        protected override void InsertItem(int index, Button item)
        {
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, Button item)
        {
            base.SetItem(index, item);
        }
    }
}
