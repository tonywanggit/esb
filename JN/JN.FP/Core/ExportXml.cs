using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JN.FP.Entity;
using XCode.DataAccessLayer;
using XCode;
using System.Xml.Linq;

namespace JN.FP.Core
{
    /// <summary>
    /// 导出Xml文件
    /// Tony.2013-10-21.增加对KPLX的判断
    /// </summary>
    public class ExportXml
    {
        XConfig _config;
        String _dateTimeNow = String.Empty;
        String _xmlPath = String.Empty;
        String _accessPath = String.Empty;

        EntityList<fp> _lstFP;
        private EntityList<fp> lstFP { get { return _lstFP; } }

        public ExportXml(XConfig config, String xmlPath, string accessPath)
        {
            _config = config;
            _xmlPath = xmlPath;
            _accessPath = accessPath;
        }

        /// <summary>
        /// 导出Xml文档
        /// </summary>
        public void Export()
        {
            fp.Meta.ConnName = GetConnName();
            _lstFP = fp.FindAll();

            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "gb2312", "yes"),
                new XElement("TYFP", new XAttribute("Ver", "1"),
                    GetHead(),
                    GetFPSY(),
                    GetKP()
                )
            );
            xDoc.Save(_xmlPath);
        }

        /// <summary>
        /// 获取到链接字符串名称
        /// </summary>
        /// <returns></returns>
        private string GetConnName()
        {
            String connName = "CWFP-" + Guid.NewGuid().ToString();
            String connStr = String.Format("Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0};Persist Security Info=False;OLE DB Services=-1", _accessPath);
            DAL.AddConnStr(connName, connStr, null, String.Empty);

            return connName;
        }

        /// <summary>
        /// 获取当前时间，并转成发票所需要的格式
        /// </summary>
        /// <returns></returns>
        private string GetDateTimeNow()
        {
            if (_dateTimeNow.IsNullOrWhiteSpace())
                _dateTimeNow = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            return _dateTimeNow;
        }

        /// <summary>
        /// 文件头信息
        /// </summary>
        /// <returns></returns>
        private XElement GetHead()
        {
            return new XElement("Head",
                new XElement("NSRSBH", _config.NSRSBH),
                new XElement("NSRMC", _config.NSRMC),
                new XElement("ZYRJZCH", ""),
                new XElement("SCSJ", GetDateTimeNow()),
                new XElement("SCFS", "2")
            );
        }

        /// <summary>
        /// 发票使用
        /// </summary>
        /// <returns></returns>
        private XElement GetFPSY()
        {
            return new XElement("FPSY",
                new XElement("KSSJ", GetDateTimeNow()),
                new XElement("JSSJ", GetDateTimeNow()),
                new XElement("JLS", lstFP.Count),
                new XElement("ZPFS", GetZPFS()),
                new XElement("ZPJE", GetZPJE()),
                new XElement("FPFS", GetFPFS()),
                new XElement("TPFS", GetTPFS()),
                new XElement("TPJE", GetTPJE()),
                new XElement("YSFS", 0),
                new XElement("JXFS", 0)
            );
        }

        /// <summary>
        /// 计算出正票金额
        /// </summary>
        /// <returns></returns>
        private decimal GetZPJE()
        {
            return lstFP.Sum<fp>(x => (x.作废 || x.ZJE < 0) ? 0 : x.ZJE);
        }

        /// <summary>
        /// 计算出正票份数
        /// </summary>
        /// <returns></returns>
        private int GetZPFS()
        {
            return lstFP.Count<fp>(x => !x.作废 && x.ZJE > 0);
        }

        /// <summary>
        /// 计算出废票份数
        /// </summary>
        /// <returns></returns>
        private int GetFPFS()
        {
            return lstFP.Count<fp>(x => x.作废);
        }

        /// <summary>
        /// 计算出退票份数
        /// </summary>
        /// <returns></returns>
        private int GetTPFS()
        {
            return lstFP.Count<fp>(x => !x.作废 && x.ZJE < 0);
        }

        /// <summary>
        /// 计算出退票金额
        /// </summary>
        /// <returns></returns>
        private decimal GetTPJE()
        {
            return lstFP.Sum<fp>(x => (!x.作废 && x.ZJE < 0) ? x.ZJE : 0);
        }

        /// <summary>
        /// 开票
        /// </summary>
        /// <returns></returns>
        private XElement GetKP()
        {
            XElement xeKPZL = new XElement("KPZL",
                    new XAttribute("KPZLDM", _config.KPZLDM),
                    new XAttribute("DKBZ", "其他"),
                    new XAttribute("RecNum", lstFP.Count)
                );

            foreach (fp item in lstFP)
            {
                xeKPZL.Add(GetKPJL(item));
            }

            return new XElement("KP", new XAttribute("RecNum", lstFP.Count),
                xeKPZL
            );
        }

        /// <summary>
        /// 开票记录
        /// </summary>
        /// <returns></returns>
        private XElement GetKPJL(fp item)
        {
            XElement xeKPJL = new XElement("KPJL");

            xeKPJL.Add(new XElement("FPDM", _config.FPDM),
                new XElement("FPHM", item.发票编号),
                new XElement("KPLX", GetKPLX(item)),
                new XElement("KPRQ", item.开票日期.ToString("yyyyMMdd")),
                new XElement("HYFLDM", "01"),
                new XElement("JE", item.ZJE),
                new XElement("SKRMC", item.收款单位名称),
                new XElement("SKRSH", item.收款单位税号),
                new XElement("FKRMC", item.付款单位名称),
                new XElement("FKRSH", item.付款单位税号),
                new XElement("GHFQYLX", "01"),
                new XElement("KPFDZJDH", _config.KPFDZJDH),
                new XElement("KPFYHJZH", _config.KPFYHJZH),
                new XElement("SPFDZJDH", ""),
                new XElement("SPFYHJZH", ""),
                new XElement("SE", item.税额),
                new XElement("SL", item.税率),
                new XElement("BZ1", String.IsNullOrEmpty(item.备注) ? "" : item.备注 ),
                new XElement("BZ2", ""),
                new XElement("BZ3", ""),
                new XElement("BZ4", ""),
                new XElement("BZ5", ""),
                new XElement("KPRXM", _config.KPRXM),
                new XElement("FHRXM", _config.FHRXM),
                new XElement("YFPDM", (item.作废 || item.ZJE < 0) ? _config.FPDM : ""),
                new XElement("YFPHM", (item.作废 || item.ZJE < 0) ? item.发票编号 : ""),
                new XElement("TPLX", (item.作废 || item.ZJE < 0) ? "1" : ""),
                new XElement("ZFRQ", (item.作废 || item.ZJE < 0) ? item.开票日期.ToString("yyyyMMdd") : ""),
                new XElement("ZFRXM", (item.作废 || item.ZJE < 0) ? _config.KPRXM : ""),
                GetFPMX(item)
            );
            return xeKPJL;
        }

        /// <summary>
        /// 获取到开票类型：规则如下
        /// 正票 0 是发票金额大于0，且不是废票。
        /// 废票 1 是要根据表中“作废”标志。
        /// 退票 2 是发票金额小于0，且不是废票。
        /// </summary>
        /// <returns></returns>
        private int GetKPLX(fp item)
        {
            if (item.作废) return 1;

            if (item.ZJE > 0)
                return 0;
            else
                return 2;
        }

        /// <summary>
        /// 发票明细
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private XElement GetFPMX(fp item)
        {
            XElement xeFPMX = new XElement("FPMX", new XAttribute("RowNum", 4), new XAttribute("HJJE", item.ZJE));

            int rowNum = 0;
            if (item.金额 > 0)
            {
                XElement xeRow = new XElement("Row",
                    new XAttribute("XH", 1),
                    new XAttribute("HPMC", item.项目 ?? ""),
                    new XAttribute("JLDW", item.单位 ?? ""),
                    new XAttribute("SL", item.数量),
                    new XAttribute("DJ", item.单价),
                    new XAttribute("JE", item.金额),
                    new XAttribute("BZ", "")
                );
                xeFPMX.Add(xeRow);
                rowNum++;
            }
            if (item.金额1 > 0)
            {
                XElement xeRow = new XElement("Row",
                    new XAttribute("XH", 2),
                    new XAttribute("HPMC", item.项目1 ?? ""),
                    new XAttribute("JLDW", item.单位1 ?? ""),
                    new XAttribute("SL", item.数量1),
                    new XAttribute("DJ", item.单价1),
                    new XAttribute("JE", item.金额1),
                    new XAttribute("BZ", "")
                );
                xeFPMX.Add(xeRow);
                rowNum++;
            }
            if (item.金额2 > 0)
            {
                XElement xeRow = new XElement("Row",
                    new XAttribute("XH", 3),
                    new XAttribute("HPMC", item.项目2 ?? ""),
                    new XAttribute("JLDW", item.单位2 ?? ""),
                    new XAttribute("SL", item.数量2),
                    new XAttribute("DJ", item.单价2),
                    new XAttribute("JE", item.金额2),
                    new XAttribute("BZ", "")
                );
                xeFPMX.Add(xeRow);
                rowNum++;
            }
            if (item.金额3 > 0)
            {
                XElement xeRow = new XElement("Row",
                    new XAttribute("XH", 4),
                    new XAttribute("HPMC", item.项目3 ?? ""),
                    new XAttribute("JLDW", item.单位3 ?? ""),
                    new XAttribute("SL", item.数量3),
                    new XAttribute("DJ", item.单价3),
                    new XAttribute("JE", item.金额3),
                    new XAttribute("BZ", "")
                );
                xeFPMX.Add(xeRow);
                rowNum++;
            }
            xeFPMX.FirstAttribute.Value = rowNum.ToString();

            return xeFPMX;
        }
    }
}
