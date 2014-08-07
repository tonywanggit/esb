using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace JN.FP.Core
{
    public class XConfig
    {
        #region 属性
        private String _AccessFile;
        /// <summary>Access文件</summary>
        public String AccessFile
        {
            get
            {
                if (String.IsNullOrEmpty(_AccessFile)) _AccessFile = "";
                return _AccessFile;
            }
            set { _AccessFile = value; }
        }

        private String _XmlFile;
        /// <summary>Xml文件</summary>
        public String XmlFile
        {
            get
            {
                if (String.IsNullOrEmpty(_XmlFile)) _XmlFile = "";
                return _XmlFile;
            }
            set { _XmlFile = value; }
        }
        private String _NSRSBH;
        /// <summary>纳税人识别号</summary>
        public String NSRSBH
        {
            get
            {
                if (String.IsNullOrEmpty(_NSRSBH)) _NSRSBH = "纳税人识别号";
                return _NSRSBH;
            }
            set { _NSRSBH = value; }
        }

        private String _NSRMC;
        /// <summary>纳税人名称</summary>
        public String NSRMC
        {
            get
            {
                if (String.IsNullOrEmpty(_NSRMC)) _NSRMC = "纳税人名称";
                return _NSRMC;
            }
            set { _NSRMC = value; }
        }

        private String _KPRXM;
        /// <summary>开票人姓名</summary>
        public String KPRXM
        {
            get
            {
                if (String.IsNullOrEmpty(_KPRXM)) _KPRXM = "开票人姓名";
                return _KPRXM;
            }
            set { _KPRXM = value; }
        }

        private String _FHRXM;
        /// <summary>复核人姓名</summary>
        public String FHRXM
        {
            get
            {
                if (String.IsNullOrEmpty(_FHRXM)) _FHRXM = "复核人姓名";
                return _FHRXM;
            }
            set { _FHRXM = value; }
        }

        private String _FPDM;
        /// <summary>发票代码</summary>
        public String FPDM
        {
            get
            {
                if (String.IsNullOrEmpty(_FPDM)) _FPDM = "发票代码";
                return _FPDM;
            }
            set { _FPDM = value; }
        }

        private String _KPFDZJDH;
        /// <summary>开票方地址及电话</summary>
        public String KPFDZJDH
        {
            get
            {
                if (String.IsNullOrEmpty(_KPFDZJDH)) _KPFDZJDH = "开票方地址及电话";
                return _KPFDZJDH;
            }
            set { _KPFDZJDH = value; }
        }

        private String _KPFYHJZH;
        /// <summary>开票方银行及帐号</summary>
        public String KPFYHJZH
        {
            get
            {
                if (String.IsNullOrEmpty(_KPFYHJZH)) _KPFYHJZH = "开票方银行及帐号";
                return _KPFYHJZH;
            }
            set { _KPFYHJZH = value; }
        }

        private String _KPZLDM;
        /// <summary>
        /// 开票种类代码：国税（21233）、地税（22744）
        /// </summary>
        public String KPZLDM
        {
            get
            {
                if (String.IsNullOrEmpty(_KPZLDM)) _KPZLDM = "21233";
                return _KPZLDM;
            }
            set { _KPZLDM = value; }
        }
        #endregion

        #region 全局
        private static XConfig _Current;
        /// <summary>实例</summary>
        public static XConfig Current
        {
            get { return _Current ?? (_Current = Load()); }
            set { _Current = value; }
        }
        #endregion

        #region 加载/保存
        public static XConfig Load()
        {
            if (!File.Exists(DefaultFile)) return Create();

            NewLife.Xml.XmlReaderX xml = new NewLife.Xml.XmlReaderX();
            using (XmlReader xr = XmlReader.Create(DefaultFile))
            {
                try
                {
                    Object obj = null;
                    xml.Reader = xr;
                    if (xml.ReadObject(typeof(XConfig), ref obj, null) && obj != null)
                    {
                        return obj as XConfig;
                    }
                    return Create();
                }
                catch { return Create(); }
            }
        }

        static XConfig Create()
        {
            XConfig config = new XConfig();
            return config;
        }

        public void Save()
        {
            if (File.Exists(DefaultFile)) File.Delete(DefaultFile);

            NewLife.Xml.XmlWriterX xml = new NewLife.Xml.XmlWriterX();
            using (XmlWriter writer = XmlWriter.Create(DefaultFile))
            {
                xml.Writer = writer;
                xml.WriteObject(this, typeof(XConfig), null);
            }
        }

        static String DefaultFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FPSetting.xml");
        #endregion
    }
}