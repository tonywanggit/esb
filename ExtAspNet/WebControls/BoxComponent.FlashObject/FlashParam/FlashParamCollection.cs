
#region Comment

/*
 * Project£º    ExtAspNet
 * 
 * FileName:    FlashParam.cs
 * CreatedOn:   2008-07-13
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
using System.Xml;
using System.Text;
using System.Collections;
using System.ComponentModel;


namespace ExtAspNet
{

    internal class FlashParamCollection : MyStateCollection<FlashParam>
    {
        #region GetKnownTypes/CreateKnownType

        protected override Type[] GetKnownTypes()
        {
            Type[] types = new Type[] { 
                typeof(FlashParam)
            };

            return types;
        }

        protected override object CreateKnownType(int index)
        {
            switch (index)
            {
                case 0:
                    return new FlashParam();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }
}



