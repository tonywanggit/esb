

#region Comment

/*
 * Project£º    ExtAspNet
 * 
 * FileName:    MyStateItem.cs
 * CreatedOn:   2008-05-30
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description£º
 *      ->
 *   
 * History£º
 *      ->
 * 
 * 
 * 
 * 
 */

#endregion

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Security.Permissions;
using System.Web;
using System.Collections.Generic;
using System.Web.UI;
using System.Collections.ObjectModel;


namespace ExtAspNet
{
    internal abstract class MyStateCollection<T> : StateManagedCollection where T : IStateManager, ISetDirty
    {
        public T this[int index]
        {
            get
            {
                return (T)((IList)this)[index];
            }
            set
            {
                ((IList)this)[index] = value;
            }
        }

        public int Add(T value)
        {
            return ((IList)this).Add(value);
        }

        public void Insert(int index, T value)
        {
            ((IList)this).Insert(index, value);
        }

        public bool Contains(T value)
        {
            return ((IList)this).Contains(value);
        }

        public void CopyTo(T[] array, int index)
        {
            base.CopyTo(array, index);
        }

        public int IndexOf(T value)
        {
            return ((IList)this).IndexOf(value);
        }

        public void Remove(T value)
        {
            ((IList)this).Remove(value);
        }

        public void RemoveAt(int index)
        {
            ((IList)this).RemoveAt(index);
        }

        protected override void SetDirtyObject(object o)
        {
            (o as ISetDirty).SetDirty();
        }


    }
}