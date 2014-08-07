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
    [BindIndex("PK_UserConn", true, "OID")]
    [BindTable("UserConn", Description = "", ConnName = "JNMIS_Studio", DbType = DatabaseType.SqlServer)]
    public partial class UserConn<TEntity> : IUserConn
    {
        #region 属性
        private String _OID;
        /// <summary>主键</summary>
        [DisplayName("主键")]
        [Description("主键")]
        [DataObjectField(true, false, false, 50)]
        [BindColumn(1, "OID", "主键", null, "nvarchar(50)", 0, 0, true)]
        public virtual String OID
        {
            get { return _OID; }
            set { if (OnPropertyChanging(__.OID, value)) { _OID = value; OnPropertyChanged(__.OID); } }
        }

        private String _UserID;
        /// <summary>用户ID</summary>
        [DisplayName("用户ID")]
        [Description("用户ID")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "UserID", "用户ID", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UserID
        {
            get { return _UserID; }
            set { if (OnPropertyChanging(__.UserID, value)) { _UserID = value; OnPropertyChanged(__.UserID); } }
        }

        private String _DatabaseID;
        /// <summary>数据库ID</summary>
        [DisplayName("数据库ID")]
        [Description("数据库ID")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(3, "DatabaseID", "数据库ID", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DatabaseID
        {
            get { return _DatabaseID; }
            set { if (OnPropertyChanging(__.DatabaseID, value)) { _DatabaseID = value; OnPropertyChanged(__.DatabaseID); } }
        }

        private String _ConnString;
        /// <summary>连接字符串</summary>
        [DisplayName("连接字符串")]
        [Description("连接字符串")]
        [DataObjectField(false, false, false, 200)]
        [BindColumn(4, "ConnString", "连接字符串", null, "nvarchar(200)", 0, 0, true)]
        public virtual String ConnString
        {
            get { return _ConnString; }
            set { if (OnPropertyChanging(__.ConnString, value)) { _ConnString = value; OnPropertyChanged(__.ConnString); } }
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
                    case __.OID : return _OID;
                    case __.UserID : return _UserID;
                    case __.DatabaseID : return _DatabaseID;
                    case __.ConnString : return _ConnString;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.OID : _OID = Convert.ToString(value); break;
                    case __.UserID : _UserID = Convert.ToString(value); break;
                    case __.DatabaseID : _DatabaseID = Convert.ToString(value); break;
                    case __.ConnString : _ConnString = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得字段信息的快捷方式</summary>
        public class _
        {
            ///<summary>主键</summary>
            public static readonly Field OID = FindByName(__.OID);

            ///<summary>用户ID</summary>
            public static readonly Field UserID = FindByName(__.UserID);

            ///<summary>数据库ID</summary>
            public static readonly Field DatabaseID = FindByName(__.DatabaseID);

            ///<summary>连接字符串</summary>
            public static readonly Field ConnString = FindByName(__.ConnString);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        class __
        {
            ///<summary>主键</summary>
            public const String OID = "OID";

            ///<summary>用户ID</summary>
            public const String UserID = "UserID";

            ///<summary>数据库ID</summary>
            public const String DatabaseID = "DatabaseID";

            ///<summary>连接字符串</summary>
            public const String ConnString = "ConnString";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IUserConn
    {
        #region 属性
        /// <summary>主键</summary>
        String OID { get; set; }

        /// <summary>用户ID</summary>
        String UserID { get; set; }

        /// <summary>数据库ID</summary>
        String DatabaseID { get; set; }

        /// <summary>连接字符串</summary>
        String ConnString { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}