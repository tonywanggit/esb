using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace JN.Studio.Core
{
    public class XConfig
    {
        #region 常量
        /// <summary>
        /// 实体业务
        /// </summary>
        public const string TEMPLATE_ENTITY_BIZ = "实体业务";

        /// <summary>
        /// 实体数据
        /// </summary>
        public const string TEMPLATE_ENTITY_DATA = "实体数据";
        #endregion

        #region 属性
        private String _ConnName;
        /// <summary>链接名</summary>
        public String ConnName
        {
            get
            {
                if (String.IsNullOrEmpty(_ConnName)) _ConnName = "ConnName";
                return _ConnName;
            }
            set { _ConnName = value; }
        }

        private String _Prefix;
        /// <summary>前缀</summary>
        public String Prefix
        {
            get { return _Prefix; }
            set { _Prefix = value; }
        }

        private String _NameSpace;
        /// <summary>命名空间</summary>
        public String NameSpace
        {
            get { return String.IsNullOrEmpty(_NameSpace) ? EntityConnName : _NameSpace; }
            set { _NameSpace = value; }
        }

        private String _TemplateName;
        /// <summary>模板名</summary>
        public String TemplateName
        {
            get { return _TemplateName; }
            set { _TemplateName = value; }
        }

        private String _OutputPath;
        /// <summary>输出目录</summary>
        public String OutputPath
        {
            get { return String.IsNullOrEmpty(_OutputPath) ? EntityConnName : _OutputPath; }
            set { _OutputPath = value; }
        }

        private String _EntityConnName;
        /// <summary>实体链接名</summary>
        public String EntityConnName
        {
            get { return String.IsNullOrEmpty(_EntityConnName) ? ConnName : _EntityConnName; }
            set { _EntityConnName = value; }
        }

        private String _BaseClass;
        /// <summary>实体基类</summary>
        public String BaseClass
        {
            get
            {
                if (String.IsNullOrEmpty(_BaseClass)) _BaseClass = "Entity";
                return _BaseClass;
            }
            set { _BaseClass = value; }
        }

        private Boolean _RenderGenEntity;
        /// <summary>生成泛型实体类</summary>
        public Boolean RenderGenEntity
        {
            get { return _RenderGenEntity; }
            set { _RenderGenEntity = value; }
        }

        private Boolean _AutoCutPrefix;
        /// <summary>自动去除前缀</summary>
        public Boolean AutoCutPrefix
        {
            get { return _AutoCutPrefix; }
            set { _AutoCutPrefix = value; }
        }

        private Boolean _CutTableName;
        /// <summary>是否自动去除字段前面的表名</summary>
        public Boolean AutoCutTableName { get { return _CutTableName; } set { _CutTableName = value; } }

        private Boolean _AutoFixWord;
        /// <summary>自动纠正大小写</summary>
        public Boolean AutoFixWord
        {
            get { return _AutoFixWord; }
            set { _AutoFixWord = value; }
        }

        private Boolean _UseCNFileName;
        /// <summary>使用中文文件名</summary>
        public Boolean UseCNFileName { get { return _UseCNFileName; } set { _UseCNFileName = value; } }

        private Boolean _UseID;
        /// <summary>强制使用ID</summary>
        public Boolean UseID { get { return _UseID; } set { _UseID = value; } }

        private Boolean _UseHeadTemplate;
        /// <summary>使用头部模版</summary>
        public Boolean UseHeadTemplate
        {
            get { return _UseHeadTemplate; }
            set { _UseHeadTemplate = value; }
        }

        private String _HeadTemplate;
        /// <summary>头部模版</summary>
        public String HeadTemplate
        {
            get { return _HeadTemplate; }
            set { _HeadTemplate = value; }
        }

        private Boolean _Debug;
        /// <summary>调试</summary>
        public Boolean Debug
        {
            get { return _Debug; }
            set { _Debug = value; }
        }

        private DateTime _LastUpdate;
        /// <summary>最后更新时间</summary>
        public DateTime LastUpdate
        {
            get { return _LastUpdate; }
            set { _LastUpdate = value; }
        }

        private Dictionary<String, String> _Items;
        /// <summary> 字典属性</summary>
        public Dictionary<String, String> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

        #endregion

        #region 构造
        /// <summary>
        /// 模板配置
        /// </summary>
        /// <param name="templateName">模板名称</param>
        /// <param name="nameSpace">命名空间</param>
        /// <param name="entityConnName">实体连接名</param>
        public XConfig(String templateName, String nameSpace, String entityConnName)
        {
            HeadTemplate = GetHeadTemplate();
            TemplateName = templateName;
            NameSpace = nameSpace;
            EntityConnName = entityConnName;
            ConnName = String.Empty;
            OutputPath = String.Empty;
            BaseClass = "Entity";
            RenderGenEntity = true;
            Prefix = String.Empty;
            AutoCutPrefix = false;
            AutoCutTableName = false;
            AutoFixWord = false;
            UseCNFileName = false;
            UseID = false;
            UseHeadTemplate = true;
            Debug = false;
        }

        /// <summary>
        /// 模板配置-简化版
        /// </summary>
        /// <param name="templateName">模板名称</param>
        /// <param name="databaseName">数据库名称</param>
        public XConfig(String templateName, String databaseName)
            : this(templateName, String.Format("JN.{0}.Entity", databaseName), databaseName)
        {
            
        }

        /// <summary>
        /// 获取版权信息
        /// </summary>
        /// <returns></returns>
        private String GetHeadTemplate()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("/*");
            //sb.AppendLine(" * XCoder v<#=Version#>");
            sb.AppendLine(" * 作者：<#=Environment.UserName + \"/\" + Environment.MachineName#>");
            sb.AppendLine(" * 时间：<#=DateTime.Now.ToString(\"yyyy-MM-dd HH:mm:ss\")#>");
            sb.AppendLine(" * 版权：版权所有 (C) 江南造船（集团）软件研发团队 <#=DateTime.Now.ToString(\"yyyy\")#>");
            sb.AppendLine("*/");

            return sb.ToString();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 获取用于存储编译后模版的名字
        /// </summary>
        /// <returns></returns>
        public String GetTemplateName()
        {
            return String.Format("{0}_{1}_{2}", TemplateName, NameSpace, EntityConnName);
        }
        #endregion
    }
}