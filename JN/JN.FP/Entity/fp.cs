﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace JN.FP.Entity
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("发票编号", true, "发票编号")]
    [BindTable("fp", Description = "", ConnName = "CWFP", DbType = DatabaseType.Access)]
    public partial class fp<TEntity> : Ifp
    {
        #region 属性
        private String _发票编号;
        /// <summary></summary>
        [DisplayName("发票编号")]
        [Description("")]
        [DataObjectField(true, false, true, 20)]
        [BindColumn(1, "发票编号", "", null, "VarChar", 0, 0, false)]
        public virtual String 发票编号
        {
            get { return _发票编号; }
            set { if (OnPropertyChanging(__.发票编号, value)) { _发票编号 = value; OnPropertyChanged(__.发票编号); } }
        }

        private DateTime _开票日期;
        /// <summary></summary>
        [DisplayName("开票日期")]
        [Description("")]
        [DataObjectField(false, false, true, 8)]
        [BindColumn(2, "开票日期", "", null, "DateTime", 0, 0, false)]
        public virtual DateTime 开票日期
        {
            get { return _开票日期; }
            set { if (OnPropertyChanging(__.开票日期, value)) { _开票日期 = value; OnPropertyChanged(__.开票日期); } }
        }

        private String _付款单位名称;
        /// <summary></summary>
        [DisplayName("付款单位名称")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(3, "付款单位名称", "", null, "VarChar", 0, 0, false)]
        public virtual String 付款单位名称
        {
            get { return _付款单位名称; }
            set { if (OnPropertyChanging(__.付款单位名称, value)) { _付款单位名称 = value; OnPropertyChanged(__.付款单位名称); } }
        }

        private String _付款单位税号;
        /// <summary></summary>
        [DisplayName("付款单位税号")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(4, "付款单位税号", "", null, "VarChar", 0, 0, false)]
        public virtual String 付款单位税号
        {
            get { return _付款单位税号; }
            set { if (OnPropertyChanging(__.付款单位税号, value)) { _付款单位税号 = value; OnPropertyChanged(__.付款单位税号); } }
        }

        private String _收款单位名称;
        /// <summary></summary>
        [DisplayName("收款单位名称")]
        [Description("")]
        [DataObjectField(false, false, true, 100)]
        [BindColumn(5, "收款单位名称", "", "江南造船（集团）有限责任公司", "VarChar", 0, 0, false)]
        public virtual String 收款单位名称
        {
            get { return _收款单位名称; }
            set { if (OnPropertyChanging(__.收款单位名称, value)) { _收款单位名称 = value; OnPropertyChanged(__.收款单位名称); } }
        }

        private String _收款单位税号;
        /// <summary></summary>
        [DisplayName("收款单位税号")]
        [Description("")]
        [DataObjectField(false, false, true, 20)]
        [BindColumn(6, "收款单位税号", "", "310101132204312", "VarChar", 0, 0, false)]
        public virtual String 收款单位税号
        {
            get { return _收款单位税号; }
            set { if (OnPropertyChanging(__.收款单位税号, value)) { _收款单位税号 = value; OnPropertyChanged(__.收款单位税号); } }
        }

        private String _项目;
        /// <summary></summary>
        [DisplayName("项目")]
        [Description("")]
        [DataObjectField(false, false, true, 120)]
        [BindColumn(7, "项目", "", null, "VarChar", 0, 0, false)]
        public virtual String 项目
        {
            get { return _项目; }
            set { if (OnPropertyChanging(__.项目, value)) { _项目 = value; OnPropertyChanged(__.项目); } }
        }

        private String _项目1;
        /// <summary></summary>
        [DisplayName("项目1")]
        [Description("")]
        [DataObjectField(false, false, true, 120)]
        [BindColumn(8, "项目1", "", null, "VarChar", 0, 0, false)]
        public virtual String 项目1
        {
            get { return _项目1; }
            set { if (OnPropertyChanging(__.项目1, value)) { _项目1 = value; OnPropertyChanged(__.项目1); } }
        }

        private String _项目2;
        /// <summary></summary>
        [DisplayName("项目2")]
        [Description("")]
        [DataObjectField(false, false, true, 120)]
        [BindColumn(9, "项目2", "", null, "VarChar", 0, 0, false)]
        public virtual String 项目2
        {
            get { return _项目2; }
            set { if (OnPropertyChanging(__.项目2, value)) { _项目2 = value; OnPropertyChanged(__.项目2); } }
        }

        private String _项目3;
        /// <summary></summary>
        [DisplayName("项目3")]
        [Description("")]
        [DataObjectField(false, false, true, 120)]
        [BindColumn(10, "项目3", "", null, "VarChar", 0, 0, false)]
        public virtual String 项目3
        {
            get { return _项目3; }
            set { if (OnPropertyChanging(__.项目3, value)) { _项目3 = value; OnPropertyChanged(__.项目3); } }
        }

        private String _单位;
        /// <summary></summary>
        [DisplayName("单位")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(11, "单位", "", null, "VarChar", 0, 0, false)]
        public virtual String 单位
        {
            get { return _单位; }
            set { if (OnPropertyChanging(__.单位, value)) { _单位 = value; OnPropertyChanged(__.单位); } }
        }

        private String _单位1;
        /// <summary></summary>
        [DisplayName("单位1")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(12, "单位1", "", null, "VarChar", 0, 0, false)]
        public virtual String 单位1
        {
            get { return _单位1; }
            set { if (OnPropertyChanging(__.单位1, value)) { _单位1 = value; OnPropertyChanged(__.单位1); } }
        }

        private String _单位2;
        /// <summary></summary>
        [DisplayName("单位2")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(13, "单位2", "", null, "VarChar", 0, 0, false)]
        public virtual String 单位2
        {
            get { return _单位2; }
            set { if (OnPropertyChanging(__.单位2, value)) { _单位2 = value; OnPropertyChanged(__.单位2); } }
        }

        private String _单位3;
        /// <summary></summary>
        [DisplayName("单位3")]
        [Description("")]
        [DataObjectField(false, false, true, 10)]
        [BindColumn(14, "单位3", "", null, "VarChar", 0, 0, false)]
        public virtual String 单位3
        {
            get { return _单位3; }
            set { if (OnPropertyChanging(__.单位3, value)) { _单位3 = value; OnPropertyChanged(__.单位3); } }
        }

        private Decimal _数量;
        /// <summary></summary>
        [DisplayName("数量")]
        [Description("")]
        [DataObjectField(false, false, true, 15)]
        [BindColumn(15, "数量", "", "0", "Decimal", 15, 0, false)]
        public virtual Decimal 数量
        {
            get { return _数量; }
            set { if (OnPropertyChanging(__.数量, value)) { _数量 = value; OnPropertyChanged(__.数量); } }
        }

        private Decimal _数量1;
        /// <summary></summary>
        [DisplayName("数量1")]
        [Description("")]
        [DataObjectField(false, false, true, 15)]
        [BindColumn(16, "数量1", "", null, "Decimal", 15, 0, false)]
        public virtual Decimal 数量1
        {
            get { return _数量1; }
            set { if (OnPropertyChanging(__.数量1, value)) { _数量1 = value; OnPropertyChanged(__.数量1); } }
        }

        private Decimal _数量2;
        /// <summary></summary>
        [DisplayName("数量2")]
        [Description("")]
        [DataObjectField(false, false, true, 15)]
        [BindColumn(17, "数量2", "", null, "Decimal", 15, 0, false)]
        public virtual Decimal 数量2
        {
            get { return _数量2; }
            set { if (OnPropertyChanging(__.数量2, value)) { _数量2 = value; OnPropertyChanged(__.数量2); } }
        }

        private Decimal _数量3;
        /// <summary></summary>
        [DisplayName("数量3")]
        [Description("")]
        [DataObjectField(false, false, true, 15)]
        [BindColumn(18, "数量3", "", null, "Decimal", 15, 0, false)]
        public virtual Decimal 数量3
        {
            get { return _数量3; }
            set { if (OnPropertyChanging(__.数量3, value)) { _数量3 = value; OnPropertyChanged(__.数量3); } }
        }

        private Decimal _单价;
        /// <summary></summary>
        [DisplayName("单价")]
        [Description("")]
        [DataObjectField(false, false, true, 15)]
        [BindColumn(19, "单价", "", null, "Decimal", 15, 0, false)]
        public virtual Decimal 单价
        {
            get { return _单价; }
            set { if (OnPropertyChanging(__.单价, value)) { _单价 = value; OnPropertyChanged(__.单价); } }
        }

        private Decimal _单价1;
        /// <summary></summary>
        [DisplayName("单价1")]
        [Description("")]
        [DataObjectField(false, false, true, 15)]
        [BindColumn(20, "单价1", "", null, "Decimal", 15, 0, false)]
        public virtual Decimal 单价1
        {
            get { return _单价1; }
            set { if (OnPropertyChanging(__.单价1, value)) { _单价1 = value; OnPropertyChanged(__.单价1); } }
        }

        private Decimal _单价2;
        /// <summary></summary>
        [DisplayName("单价2")]
        [Description("")]
        [DataObjectField(false, false, true, 15)]
        [BindColumn(21, "单价2", "", null, "Decimal", 15, 0, false)]
        public virtual Decimal 单价2
        {
            get { return _单价2; }
            set { if (OnPropertyChanging(__.单价2, value)) { _单价2 = value; OnPropertyChanged(__.单价2); } }
        }

        private Decimal _单价3;
        /// <summary></summary>
        [DisplayName("单价3")]
        [Description("")]
        [DataObjectField(false, false, true, 15)]
        [BindColumn(22, "单价3", "", null, "Decimal", 15, 0, false)]
        public virtual Decimal 单价3
        {
            get { return _单价3; }
            set { if (OnPropertyChanging(__.单价3, value)) { _单价3 = value; OnPropertyChanged(__.单价3); } }
        }

        private Decimal _金额;
        /// <summary></summary>
        [DisplayName("金额")]
        [Description("")]
        [DataObjectField(false, false, true, 15)]
        [BindColumn(23, "金额", "", "0", "Decimal", 15, 0, false)]
        public virtual Decimal 金额
        {
            get { return _金额; }
            set { if (OnPropertyChanging(__.金额, value)) { _金额 = value; OnPropertyChanged(__.金额); } }
        }

        private Decimal _金额1;
        /// <summary></summary>
        [DisplayName("金额1")]
        [Description("")]
        [DataObjectField(false, false, true, 15)]
        [BindColumn(24, "金额1", "", null, "Decimal", 15, 0, false)]
        public virtual Decimal 金额1
        {
            get { return _金额1; }
            set { if (OnPropertyChanging(__.金额1, value)) { _金额1 = value; OnPropertyChanged(__.金额1); } }
        }

        private Decimal _金额2;
        /// <summary></summary>
        [DisplayName("金额2")]
        [Description("")]
        [DataObjectField(false, false, true, 15)]
        [BindColumn(25, "金额2", "", null, "Decimal", 15, 0, false)]
        public virtual Decimal 金额2
        {
            get { return _金额2; }
            set { if (OnPropertyChanging(__.金额2, value)) { _金额2 = value; OnPropertyChanged(__.金额2); } }
        }

        private Decimal _金额3;
        /// <summary></summary>
        [DisplayName("金额3")]
        [Description("")]
        [DataObjectField(false, false, true, 15)]
        [BindColumn(26, "金额3", "", null, "Decimal", 15, 0, false)]
        public virtual Decimal 金额3
        {
            get { return _金额3; }
            set { if (OnPropertyChanging(__.金额3, value)) { _金额3 = value; OnPropertyChanged(__.金额3); } }
        }

        private Decimal _税率;
        /// <summary></summary>
        [DisplayName("税率")]
        [Description("")]
        [DataObjectField(false, false, true, 15)]
        [BindColumn(27, "税率", "", null, "Decimal", 15, 0, false)]
        public virtual Decimal 税率
        {
            get { return _税率; }
            set { if (OnPropertyChanging(__.税率, value)) { _税率 = value; OnPropertyChanged(__.税率); } }
        }

        private Decimal _税额;
        /// <summary></summary>
        [DisplayName("税额")]
        [Description("")]
        [DataObjectField(false, false, true, 15)]
        [BindColumn(28, "税额", "", null, "Decimal", 15, 0, false)]
        public virtual Decimal 税额
        {
            get { return _税额; }
            set { if (OnPropertyChanging(__.税额, value)) { _税额 = value; OnPropertyChanged(__.税额); } }
        }

        private String _备注;
        /// <summary></summary>
        [DisplayName("备注")]
        [Description("")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(29, "备注", "", null, "VarChar", 0, 0, false)]
        public virtual String 备注
        {
            get { return _备注; }
            set { if (OnPropertyChanging(__.备注, value)) { _备注 = value; OnPropertyChanged(__.备注); } }
        }

        private String _机打信息;
        /// <summary></summary>
        [DisplayName("机打信息")]
        [Description("")]
        [DataObjectField(false, false, true, 255)]
        [BindColumn(30, "机打信息", "", null, "VarChar", 0, 0, false)]
        public virtual String 机打信息
        {
            get { return _机打信息; }
            set { if (OnPropertyChanging(__.机打信息, value)) { _机打信息 = value; OnPropertyChanged(__.机打信息); } }
        }

        private Boolean _作废;
        /// <summary></summary>
        [DisplayName("作废")]
        [Description("")]
        [DataObjectField(false, false, false, 2)]
        [BindColumn(31, "作废", "", "0", "Bit", 0, 0, false)]
        public virtual Boolean 作废
        {
            get { return _作废; }
            set { if (OnPropertyChanging(__.作废, value)) { _作废 = value; OnPropertyChanged(__.作废); } }
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
                    case __.发票编号: return _发票编号;
                    case __.开票日期: return _开票日期;
                    case __.付款单位名称: return _付款单位名称;
                    case __.付款单位税号: return _付款单位税号;
                    case __.收款单位名称: return _收款单位名称;
                    case __.收款单位税号: return _收款单位税号;
                    case __.项目: return _项目;
                    case __.项目1: return _项目1;
                    case __.项目2: return _项目2;
                    case __.项目3: return _项目3;
                    case __.单位: return _单位;
                    case __.单位1: return _单位1;
                    case __.单位2: return _单位2;
                    case __.单位3: return _单位3;
                    case __.数量: return _数量;
                    case __.数量1: return _数量1;
                    case __.数量2: return _数量2;
                    case __.数量3: return _数量3;
                    case __.单价: return _单价;
                    case __.单价1: return _单价1;
                    case __.单价2: return _单价2;
                    case __.单价3: return _单价3;
                    case __.金额: return _金额;
                    case __.金额1: return _金额1;
                    case __.金额2: return _金额2;
                    case __.金额3: return _金额3;
                    case __.税率: return _税率;
                    case __.税额: return _税额;
                    case __.备注: return _备注;
                    case __.机打信息: return _机打信息;
                    case __.作废: return _作废;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.发票编号: _发票编号 = Convert.ToString(value); break;
                    case __.开票日期: _开票日期 = Convert.ToDateTime(value); break;
                    case __.付款单位名称: _付款单位名称 = Convert.ToString(value); break;
                    case __.付款单位税号: _付款单位税号 = Convert.ToString(value); break;
                    case __.收款单位名称: _收款单位名称 = Convert.ToString(value); break;
                    case __.收款单位税号: _收款单位税号 = Convert.ToString(value); break;
                    case __.项目: _项目 = Convert.ToString(value); break;
                    case __.项目1: _项目1 = Convert.ToString(value); break;
                    case __.项目2: _项目2 = Convert.ToString(value); break;
                    case __.项目3: _项目3 = Convert.ToString(value); break;
                    case __.单位: _单位 = Convert.ToString(value); break;
                    case __.单位1: _单位1 = Convert.ToString(value); break;
                    case __.单位2: _单位2 = Convert.ToString(value); break;
                    case __.单位3: _单位3 = Convert.ToString(value); break;
                    case __.数量: _数量 = Convert.ToDecimal(value); break;
                    case __.数量1: _数量1 = Convert.ToDecimal(value); break;
                    case __.数量2: _数量2 = Convert.ToDecimal(value); break;
                    case __.数量3: _数量3 = Convert.ToDecimal(value); break;
                    case __.单价: _单价 = Convert.ToDecimal(value); break;
                    case __.单价1: _单价1 = Convert.ToDecimal(value); break;
                    case __.单价2: _单价2 = Convert.ToDecimal(value); break;
                    case __.单价3: _单价3 = Convert.ToDecimal(value); break;
                    case __.金额: _金额 = Convert.ToDecimal(value); break;
                    case __.金额1: _金额1 = Convert.ToDecimal(value); break;
                    case __.金额2: _金额2 = Convert.ToDecimal(value); break;
                    case __.金额3: _金额3 = Convert.ToDecimal(value); break;
                    case __.税率: _税率 = Convert.ToDecimal(value); break;
                    case __.税额: _税额 = Convert.ToDecimal(value); break;
                    case __.备注: _备注 = Convert.ToString(value); break;
                    case __.机打信息: _机打信息 = Convert.ToString(value); break;
                    case __.作废: _作废 = Convert.ToBoolean(value); break;
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
            public static readonly Field 发票编号 = FindByName(__.发票编号);

            ///<summary></summary>
            public static readonly Field 开票日期 = FindByName(__.开票日期);

            ///<summary></summary>
            public static readonly Field 付款单位名称 = FindByName(__.付款单位名称);

            ///<summary></summary>
            public static readonly Field 付款单位税号 = FindByName(__.付款单位税号);

            ///<summary></summary>
            public static readonly Field 收款单位名称 = FindByName(__.收款单位名称);

            ///<summary></summary>
            public static readonly Field 收款单位税号 = FindByName(__.收款单位税号);

            ///<summary></summary>
            public static readonly Field 项目 = FindByName(__.项目);

            ///<summary></summary>
            public static readonly Field 项目1 = FindByName(__.项目1);

            ///<summary></summary>
            public static readonly Field 项目2 = FindByName(__.项目2);

            ///<summary></summary>
            public static readonly Field 项目3 = FindByName(__.项目3);

            ///<summary></summary>
            public static readonly Field 单位 = FindByName(__.单位);

            ///<summary></summary>
            public static readonly Field 单位1 = FindByName(__.单位1);

            ///<summary></summary>
            public static readonly Field 单位2 = FindByName(__.单位2);

            ///<summary></summary>
            public static readonly Field 单位3 = FindByName(__.单位3);

            ///<summary></summary>
            public static readonly Field 数量 = FindByName(__.数量);

            ///<summary></summary>
            public static readonly Field 数量1 = FindByName(__.数量1);

            ///<summary></summary>
            public static readonly Field 数量2 = FindByName(__.数量2);

            ///<summary></summary>
            public static readonly Field 数量3 = FindByName(__.数量3);

            ///<summary></summary>
            public static readonly Field 单价 = FindByName(__.单价);

            ///<summary></summary>
            public static readonly Field 单价1 = FindByName(__.单价1);

            ///<summary></summary>
            public static readonly Field 单价2 = FindByName(__.单价2);

            ///<summary></summary>
            public static readonly Field 单价3 = FindByName(__.单价3);

            ///<summary></summary>
            public static readonly Field 金额 = FindByName(__.金额);

            ///<summary></summary>
            public static readonly Field 金额1 = FindByName(__.金额1);

            ///<summary></summary>
            public static readonly Field 金额2 = FindByName(__.金额2);

            ///<summary></summary>
            public static readonly Field 金额3 = FindByName(__.金额3);

            ///<summary></summary>
            public static readonly Field 税率 = FindByName(__.税率);

            ///<summary></summary>
            public static readonly Field 税额 = FindByName(__.税额);

            ///<summary></summary>
            public static readonly Field 备注 = FindByName(__.备注);

            ///<summary></summary>
            public static readonly Field 机打信息 = FindByName(__.机打信息);

            ///<summary></summary>
            public static readonly Field 作废 = FindByName(__.作废);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        class __
        {
            ///<summary></summary>
            public const String 发票编号 = "发票编号";

            ///<summary></summary>
            public const String 开票日期 = "开票日期";

            ///<summary></summary>
            public const String 付款单位名称 = "付款单位名称";

            ///<summary></summary>
            public const String 付款单位税号 = "付款单位税号";

            ///<summary></summary>
            public const String 收款单位名称 = "收款单位名称";

            ///<summary></summary>
            public const String 收款单位税号 = "收款单位税号";

            ///<summary></summary>
            public const String 项目 = "项目";

            ///<summary></summary>
            public const String 项目1 = "项目1";

            ///<summary></summary>
            public const String 项目2 = "项目2";

            ///<summary></summary>
            public const String 项目3 = "项目3";

            ///<summary></summary>
            public const String 单位 = "单位";

            ///<summary></summary>
            public const String 单位1 = "单位1";

            ///<summary></summary>
            public const String 单位2 = "单位2";

            ///<summary></summary>
            public const String 单位3 = "单位3";

            ///<summary></summary>
            public const String 数量 = "数量";

            ///<summary></summary>
            public const String 数量1 = "数量1";

            ///<summary></summary>
            public const String 数量2 = "数量2";

            ///<summary></summary>
            public const String 数量3 = "数量3";

            ///<summary></summary>
            public const String 单价 = "单价";

            ///<summary></summary>
            public const String 单价1 = "单价1";

            ///<summary></summary>
            public const String 单价2 = "单价2";

            ///<summary></summary>
            public const String 单价3 = "单价3";

            ///<summary></summary>
            public const String 金额 = "金额";

            ///<summary></summary>
            public const String 金额1 = "金额1";

            ///<summary></summary>
            public const String 金额2 = "金额2";

            ///<summary></summary>
            public const String 金额3 = "金额3";

            ///<summary></summary>
            public const String 税率 = "税率";

            ///<summary></summary>
            public const String 税额 = "税额";

            ///<summary></summary>
            public const String 备注 = "备注";

            ///<summary></summary>
            public const String 机打信息 = "机打信息";

            ///<summary></summary>
            public const String 作废 = "作废";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface Ifp
    {
        #region 属性
        /// <summary></summary>
        String 发票编号 { get; set; }

        /// <summary></summary>
        DateTime 开票日期 { get; set; }

        /// <summary></summary>
        String 付款单位名称 { get; set; }

        /// <summary></summary>
        String 付款单位税号 { get; set; }

        /// <summary></summary>
        String 收款单位名称 { get; set; }

        /// <summary></summary>
        String 收款单位税号 { get; set; }

        /// <summary></summary>
        String 项目 { get; set; }

        /// <summary></summary>
        String 项目1 { get; set; }

        /// <summary></summary>
        String 项目2 { get; set; }

        /// <summary></summary>
        String 项目3 { get; set; }

        /// <summary></summary>
        String 单位 { get; set; }

        /// <summary></summary>
        String 单位1 { get; set; }

        /// <summary></summary>
        String 单位2 { get; set; }

        /// <summary></summary>
        String 单位3 { get; set; }

        /// <summary></summary>
        Decimal 数量 { get; set; }

        /// <summary></summary>
        Decimal 数量1 { get; set; }

        /// <summary></summary>
        Decimal 数量2 { get; set; }

        /// <summary></summary>
        Decimal 数量3 { get; set; }

        /// <summary></summary>
        Decimal 单价 { get; set; }

        /// <summary></summary>
        Decimal 单价1 { get; set; }

        /// <summary></summary>
        Decimal 单价2 { get; set; }

        /// <summary></summary>
        Decimal 单价3 { get; set; }

        /// <summary></summary>
        Decimal 金额 { get; set; }

        /// <summary></summary>
        Decimal 金额1 { get; set; }

        /// <summary></summary>
        Decimal 金额2 { get; set; }

        /// <summary></summary>
        Decimal 金额3 { get; set; }

        /// <summary></summary>
        Decimal 税率 { get; set; }

        /// <summary></summary>
        Decimal 税额 { get; set; }

        /// <summary></summary>
        String 备注 { get; set; }

        /// <summary></summary>
        String 机打信息 { get; set; }

        /// <summary></summary>
        Boolean 作废 { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}