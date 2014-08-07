﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace JN.Studio.Entity
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("PK_Orderdrawinfo", true, "工程号,图号")]
    [BindTable("Orderdrawinfo", Description = "", ConnName = "GEOADES", DbType = DatabaseType.SqlServer)]
    public partial class Orderdrawinfo<TEntity> : IOrderdrawinfo
    {
        #region 属性
        private String _工程号;
        /// <summary></summary>
        [DisplayName("工程号")]
        [Description("")]
        [DataObjectField(true, false, false, 50)]
        [BindColumn(1, "工程号", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String 工程号
        {
            get { return _工程号; }
            set { if (OnPropertyChanging(__.工程号, value)) { _工程号 = value; OnPropertyChanged(__.工程号); } }
        }

        private String _图号;
        /// <summary></summary>
        [DisplayName("图号")]
        [Description("")]
        [DataObjectField(true, false, false, 50)]
        [BindColumn(2, "图号", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String 图号
        {
            get { return _图号; }
            set { if (OnPropertyChanging(__.图号, value)) { _图号 = value; OnPropertyChanged(__.图号); } }
        }

        private String _图纸名称;
        /// <summary></summary>
        [DisplayName("图纸名称")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(3, "图纸名称", "", null, "nvarchar(100)", 0, 0, true)]
        public virtual String 图纸名称
        {
            get { return _图纸名称; }
            set { if (OnPropertyChanging(__.图纸名称, value)) { _图纸名称 = value; OnPropertyChanged(__.图纸名称); } }
        }

        private String _专业;
        /// <summary></summary>
        [DisplayName("专业")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(4, "专业", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String 专业
        {
            get { return _专业; }
            set { if (OnPropertyChanging(__.专业, value)) { _专业 = value; OnPropertyChanged(__.专业); } }
        }

        private String _创建日期;
        /// <summary></summary>
        [DisplayName("创建日期")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(5, "创建日期", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String 创建日期
        {
            get { return _创建日期; }
            set { if (OnPropertyChanging(__.创建日期, value)) { _创建日期 = value; OnPropertyChanged(__.创建日期); } }
        }

        private String _入库日期;
        /// <summary></summary>
        [DisplayName("入库日期")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "入库日期", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String 入库日期
        {
            get { return _入库日期; }
            set { if (OnPropertyChanging(__.入库日期, value)) { _入库日期 = value; OnPropertyChanged(__.入库日期); } }
        }

        private String _计划日期;
        /// <summary></summary>
        [DisplayName("计划日期")]
        [Description("")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "计划日期", "", null, "nvarchar(50)", 0, 0, true)]
        public virtual String 计划日期
        {
            get { return _计划日期; }
            set { if (OnPropertyChanging(__.计划日期, value)) { _计划日期 = value; OnPropertyChanged(__.计划日期); } }
        }

        private String _备注;
        /// <summary></summary>
        [DisplayName("备注")]
        [Description("")]
        [DataObjectField(false, false, true, 1073741823)]
        [BindColumn(8, "备注", "", null, "ntext", 0, 0, true)]
        public virtual String 备注
        {
            get { return _备注; }
            set { if (OnPropertyChanging(__.备注, value)) { _备注 = value; OnPropertyChanged(__.备注); } }
        }

        private String _状态;
        /// <summary></summary>
        [DisplayName("状态")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(9, "状态", "", "未发布", "nvarchar(10)", 0, 0, true)]
        public virtual String 状态
        {
            get { return _状态; }
            set { if (OnPropertyChanging(__.状态, value)) { _状态 = value; OnPropertyChanged(__.状态); } }
        }

        private Int32 _类型;
        /// <summary></summary>
        [DisplayName("类型")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(10, "类型", "", "0", "int", 10, 0, false)]
        public virtual Int32 类型
        {
            get { return _类型; }
            set { if (OnPropertyChanging(__.类型, value)) { _类型 = value; OnPropertyChanged(__.类型); } }
        }
        #endregion

        #region 获取/设置 字段值
        /// <summary>
        /// 获取/设置 字段值。
        /// 一个索引，基类使用反射实现。
        /// 派生实体类可重写该索引，以避免反射带来的性能损耗
        /// </summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case __.工程号 : return _工程号;
                    case __.图号 : return _图号;
                    case __.图纸名称 : return _图纸名称;
                    case __.专业 : return _专业;
                    case __.创建日期 : return _创建日期;
                    case __.入库日期 : return _入库日期;
                    case __.计划日期 : return _计划日期;
                    case __.备注 : return _备注;
                    case __.状态 : return _状态;
                    case __.类型 : return _类型;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.工程号 : _工程号 = Convert.ToString(value); break;
                    case __.图号 : _图号 = Convert.ToString(value); break;
                    case __.图纸名称 : _图纸名称 = Convert.ToString(value); break;
                    case __.专业 : _专业 = Convert.ToString(value); break;
                    case __.创建日期 : _创建日期 = Convert.ToString(value); break;
                    case __.入库日期 : _入库日期 = Convert.ToString(value); break;
                    case __.计划日期 : _计划日期 = Convert.ToString(value); break;
                    case __.备注 : _备注 = Convert.ToString(value); break;
                    case __.状态 : _状态 = Convert.ToString(value); break;
                    case __.类型 : _类型 = Convert.ToInt32(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得字段信息的快捷方式</summary>
        public class _
        {
            ///<summary></summary>
            public static readonly Field 工程号 = FindByName(__.工程号);

            ///<summary></summary>
            public static readonly Field 图号 = FindByName(__.图号);

            ///<summary></summary>
            public static readonly Field 图纸名称 = FindByName(__.图纸名称);

            ///<summary></summary>
            public static readonly Field 专业 = FindByName(__.专业);

            ///<summary></summary>
            public static readonly Field 创建日期 = FindByName(__.创建日期);

            ///<summary></summary>
            public static readonly Field 入库日期 = FindByName(__.入库日期);

            ///<summary></summary>
            public static readonly Field 计划日期 = FindByName(__.计划日期);

            ///<summary></summary>
            public static readonly Field 备注 = FindByName(__.备注);

            ///<summary></summary>
            public static readonly Field 状态 = FindByName(__.状态);

            ///<summary></summary>
            public static readonly Field 类型 = FindByName(__.类型);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        class __
        {
            ///<summary></summary>
            public const String 工程号 = "工程号";

            ///<summary></summary>
            public const String 图号 = "图号";

            ///<summary></summary>
            public const String 图纸名称 = "图纸名称";

            ///<summary></summary>
            public const String 专业 = "专业";

            ///<summary></summary>
            public const String 创建日期 = "创建日期";

            ///<summary></summary>
            public const String 入库日期 = "入库日期";

            ///<summary></summary>
            public const String 计划日期 = "计划日期";

            ///<summary></summary>
            public const String 备注 = "备注";

            ///<summary></summary>
            public const String 状态 = "状态";

            ///<summary></summary>
            public const String 类型 = "类型";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IOrderdrawinfo
    {
        #region 属性
        /// <summary></summary>
        String 工程号 { get; set; }

        /// <summary></summary>
        String 图号 { get; set; }

        /// <summary></summary>
        String 图纸名称 { get; set; }

        /// <summary></summary>
        String 专业 { get; set; }

        /// <summary></summary>
        String 创建日期 { get; set; }

        /// <summary></summary>
        String 入库日期 { get; set; }

        /// <summary></summary>
        String 计划日期 { get; set; }

        /// <summary></summary>
        String 备注 { get; set; }

        /// <summary></summary>
        String 状态 { get; set; }

        /// <summary></summary>
        Int32 类型 { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}