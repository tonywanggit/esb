﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

using DatabaseTypeEnum = XCode.DataAccessLayer.DatabaseType;

namespace JN.Studio.Entity
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [Description("")]
    [BindIndex("IX_Database_ConnName", true, "ConnName")]
    [BindIndex("PK_Database", true, "OID")]
    [BindTable("Database", Description = "", ConnName = "JNMIS_Studio", DbType = DatabaseTypeEnum.SqlServer)]
    public partial class Database<TEntity> : IDatabase
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

        private String _ConnName;
        /// <summary>连接名</summary>
        [DisplayName("连接名")]
        [Description("连接名")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "ConnName", "连接名", null, "nvarchar(50)", 0, 0, true)]
        public virtual String ConnName
        {
            get { return _ConnName; }
            set { if (OnPropertyChanging(__.ConnName, value)) { _ConnName = value; OnPropertyChanged(__.ConnName); } }
        }

        private String _DatabaseType;
        /// <summary>数据库类型</summary>
        [DisplayName("数据库类型")]
        [Description("数据库类型")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(3, "DatabaseType", "数据库类型", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DatabaseType
        {
            get { return _DatabaseType; }
            set { if (OnPropertyChanging(__.DatabaseType, value)) { _DatabaseType = value; OnPropertyChanged(__.DatabaseType); } }
        }

        private String _Server;
        /// <summary>服务器地址</summary>
        [DisplayName("服务器地址")]
        [Description("服务器地址")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(4, "Server", "服务器地址", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Server
        {
            get { return _Server; }
            set { if (OnPropertyChanging(__.Server, value)) { _Server = value; OnPropertyChanged(__.Server); } }
        }

        private String _DatabaseName;
        /// <summary>数据库名称或SID</summary>
        [DisplayName("数据库名称或SID")]
        [Description("数据库名称或SID")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(5, "DatabaseName", "数据库名称或SID", null, "nvarchar(50)", 0, 0, true)]
        public virtual String DatabaseName
        {
            get { return _DatabaseName; }
            set { if (OnPropertyChanging(__.DatabaseName, value)) { _DatabaseName = value; OnPropertyChanged(__.DatabaseName); } }
        }

        private String _UserName;
        /// <summary>用户名</summary>
        [DisplayName("用户名")]
        [Description("用户名")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(6, "UserName", "用户名", null, "nvarchar(50)", 0, 0, true)]
        public virtual String UserName
        {
            get { return _UserName; }
            set { if (OnPropertyChanging(__.UserName, value)) { _UserName = value; OnPropertyChanged(__.UserName); } }
        }

        private String _Password;
        /// <summary>密码</summary>
        [DisplayName("密码")]
        [Description("密码")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn(7, "Password", "密码", null, "nvarchar(50)", 0, 0, true)]
        public virtual String Password
        {
            get { return _Password; }
            set { if (OnPropertyChanging(__.Password, value)) { _Password = value; OnPropertyChanged(__.Password); } }
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
                    case __.ConnName : return _ConnName;
                    case __.DatabaseType : return _DatabaseType;
                    case __.Server : return _Server;
                    case __.DatabaseName : return _DatabaseName;
                    case __.UserName : return _UserName;
                    case __.Password : return _Password;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.OID : _OID = Convert.ToString(value); break;
                    case __.ConnName : _ConnName = Convert.ToString(value); break;
                    case __.DatabaseType : _DatabaseType = Convert.ToString(value); break;
                    case __.Server : _Server = Convert.ToString(value); break;
                    case __.DatabaseName : _DatabaseName = Convert.ToString(value); break;
                    case __.UserName : _UserName = Convert.ToString(value); break;
                    case __.Password : _Password = Convert.ToString(value); break;
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

            ///<summary>连接名</summary>
            public static readonly Field ConnName = FindByName(__.ConnName);

            ///<summary>数据库类型</summary>
            public static readonly Field DatabaseType = FindByName(__.DatabaseType);

            ///<summary>服务器地址</summary>
            public static readonly Field Server = FindByName(__.Server);

            ///<summary>数据库名称或SID</summary>
            public static readonly Field DatabaseName = FindByName(__.DatabaseName);

            ///<summary>用户名</summary>
            public static readonly Field UserName = FindByName(__.UserName);

            ///<summary>密码</summary>
            public static readonly Field Password = FindByName(__.Password);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        class __
        {
            ///<summary>主键</summary>
            public const String OID = "OID";

            ///<summary>连接名</summary>
            public const String ConnName = "ConnName";

            ///<summary>数据库类型</summary>
            public const String DatabaseType = "DatabaseType";

            ///<summary>服务器地址</summary>
            public const String Server = "Server";

            ///<summary>数据库名称或SID</summary>
            public const String DatabaseName = "DatabaseName";

            ///<summary>用户名</summary>
            public const String UserName = "UserName";

            ///<summary>密码</summary>
            public const String Password = "Password";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IDatabase
    {
        #region 属性
        /// <summary>主键</summary>
        String OID { get; set; }

        /// <summary>连接名</summary>
        String ConnName { get; set; }

        /// <summary>数据库类型</summary>
        String DatabaseType { get; set; }

        /// <summary>服务器地址</summary>
        String Server { get; set; }

        /// <summary>数据库名称或SID</summary>
        String DatabaseName { get; set; }

        /// <summary>用户名</summary>
        String UserName { get; set; }

        /// <summary>密码</summary>
        String Password { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值。</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}