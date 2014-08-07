using System;
using System.Collections.Generic;
using XCode.Configuration;
using System.Reflection;

namespace NewLife.CommonEntity.Common
{
    /// <summary>
    /// 增强版的FieldItem,用于增加UI控制的字段
    /// </summary>
    public class FieldItemEx
    {
        public static implicit operator FieldItemEx(FieldItem fi){
            return new FieldItemEx(fi);
        }

        public FieldItemEx(FieldItem fi){
            _field = fi;
        }

        private FieldItem _field = null;
        /// <summary>
        /// 获取到原始字段
        /// </summary>
        public FieldItem Field
        {
            get { return _field; }
        }

        private bool _editabled = true;
        /// <summary>
        /// 获取或设置字段对应的控件是否可以进行编辑
        /// </summary>
        public bool Editabled
        {
            get { return _editabled; }
            set { _editabled = value; }
        }


    }
}
