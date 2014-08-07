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
    [BindIndex("PK_UserInfo", true, "OID")]
    [BindTable("UserInfo", Description = "", ConnName = "JNMIS_Studio", DbType = DatabaseType.SqlServer)]
    public partial class UserInfo<TEntity> : IUserInfo
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

        private String _LoginName;
        /// <summary>登录名</summary>
        [DisplayName("登录名")]
        [Description("登录名")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(2, "LoginName", "登录名", null, "nvarchar(50)", 0, 0, true)]
        public virtual String LoginName
        {
            get { return _LoginName; }
            set { if (OnPropertyChanging(__.LoginName, value)) { _LoginName = value; OnPropertyChanged(__.LoginName); } }
        }

        private String _TrueName;
        /// <summary>姓名</summary>
        [DisplayName("姓名")]
        [Description("姓名")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(3, "TrueName", "姓名", null, "nvarchar(50)", 0, 0, true)]
        public virtual String TrueName
        {
            get { return _TrueName; }
            set { if (OnPropertyChanging(__.TrueName, value)) { _TrueName = value; OnPropertyChanged(__.TrueName); } }
        }

        private String _Password;
        /// <summary>密码</summary>
        [DisplayName("密码")]
        [Description("密码")]
        [DataObjectField(false, false, false, 50)]
        [BindColumn(4, "Password", "密码", null, "nvarchar(50)", 0, 0, true)]
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
                    case __.LoginName : return _LoginName;
                    case __.TrueName : return _TrueName;
                    case __.Password : return _Password;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.OID : _OID = Convert.ToString(value); break;
                    case __.LoginName : _LoginName = Convert.ToString(value); break;
                    case __.TrueName : _TrueName = Convert.ToString(value); break;
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

            ///<summary>登录名</summary>
            public static readonly Field LoginName = FindByName(__.LoginName);

            ///<summary>姓名</summary>
            public static readonly Field TrueName = FindByName(__.TrueName);

            ///<summary>密码</summary>
            public static readonly Field Password = FindByName(__.Password);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得字段名称的快捷方式</summary>
        class __
        {
            ///<summary>主键</summary>
            public const String OID = "OID";

            ///<summary>登录名</summary>
            public const String LoginName = "LoginName";

            ///<summary>姓名</summary>
            public const String TrueName = "TrueName";

            ///<summary>密码</summary>
            public const String Password = "Password";

        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IUserInfo
    {
        #region 属性
        /// <summary>主键</summary>
        String OID { get; set; }

        /// <summary>登录名</summary>
        String LoginName { get; set; }

        /// <summary>姓名</summary>
        String TrueName { get; set; }

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