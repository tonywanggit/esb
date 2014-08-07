using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JN.FP.Entity;
using XCode;
using System.Xml.Linq;
using System.Diagnostics;
using System.Linq;
using XCode.DataAccessLayer;
using NewLife.Log;
using JN.FP.Core;
using System.IO;
using System.Collections;

namespace JN.FP
{
    public partial class FormExport : Form
    {
        #region 成员及属性
        XConfig _config = XConfig.Current;
        FormLoading _frmLoading = new FormLoading();

        #endregion

        #region UI逻辑
        public FormExport()
        {
            InitializeComponent();
        }

        private void FormExport_Load(object sender, EventArgs e)
        {
            txtNSRSBH.Text = _config.NSRSBH;
            txtNSRMC.Text = _config.NSRMC;
            txtFPDM.Text = _config.FPDM;
            txtKPRXM.Text = _config.KPRXM;
            txtFHRXM.Text = _config.FHRXM;
            txtKPFDZJDH.Text = _config.KPFDZJDH;
            txtKPFYHJZH.Text = _config.KPFYHJZH;

            txtAccess.Text = _config.AccessFile;
            txtXml.Text = _config.XmlFile;
            
            cmbKPZL.SelectedIndex = 0;
        }

        private void FormExport_FormClosing(object sender, FormClosingEventArgs e)
        {
            String kpzldm = cmbKPZL.Text.Substring(3, 5);
            _config.KPZLDM = kpzldm;
            _config.NSRSBH = txtNSRSBH.Text;
            _config.NSRMC = txtNSRMC.Text;
            _config.FPDM = txtFPDM.Text;
            _config.KPRXM = txtKPRXM.Text;
            _config.FHRXM = txtFHRXM.Text;
            _config.KPFDZJDH = txtKPFDZJDH.Text;
            _config.KPFYHJZH = txtKPFYHJZH.Text;

            _config.AccessFile = txtAccess.Text;
            _config.XmlFile = txtXml.Text;

            _config.Save();
        }

        private void cmdAccess_Click(object sender, EventArgs e)
        {
            DialogResult dr = ofdAccess.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtAccess.Text = ofdAccess.FileName;
            }
        }

        private void cmdXml_Click(object sender, EventArgs e)
        {
            DialogResult dr = sfdXml.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtXml.Text = sfdXml.FileName;
            }
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            FormExport_FormClosing(null, null);
            if (ValidateParam())
            {
                ExportXml exportXml = new ExportXml(_config, txtXml.Text, txtAccess.Text);
                bgWorker.RunWorkerAsync(exportXml);
                _frmLoading.ShowDialog();
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ExportXml exportXml = e.Argument as ExportXml;
                exportXml.Export();
            }
            catch (Exception ex)
            {
                XTrace.WriteException(ex);
                e.Result = ex;
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _frmLoading.Hide();

            if (e.Error != null)
            {
                MessageBox.Show("导出Xml文件失败，程序异常：" + e.Error.Message, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Xml文件导出成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region 验证逻辑
        /// <summary>
        /// 验证各项参数是否正确
        /// </summary>
        /// <returns></returns>
        private bool ValidateParam()
        {
            if (!ValidateTextBox(txtNSRSBH, "请填写纳税人识别号！"))
                return false;

            if (!ValidateTextBox(txtNSRMC, "请填写纳税人识名称！"))
                return false;

            if (!ValidateTextBox(txtKPRXM, "请填写开票人姓名！"))
                return false;

            if (!ValidateTextBox(txtFHRXM, "请填写复核人姓名！"))
                return false;

            if (!ValidateTextBox(txtFPDM, "请填写发票代码！"))
                return false;

            if (!ValidateTextBox(txtKPFDZJDH, "请填写开票方地址及电话！"))
                return false;

            if (!ValidateTextBox(txtKPFYHJZH, "请填写开票方银行及帐号！"))
                return false;

            if (!ValidateTextBox(txtAccess, "请选择需要导出发票的Access文档！"))
                return false;

            if (!ValidateTextBox(txtXml, "请选择导出发票的Xml文档！"))
                return false;

            if (!File.Exists(txtAccess.Text))
            {
                MessageBox.Show("指定的Access文件不存在，请重新选择！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!Directory.Exists(txtXml.Text.Substring(0, txtXml.Text.LastIndexOf('\\'))))
            {
                MessageBox.Show("指定的Xml文件目录不存在，请重新选择！", "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 验证单个TextBox的有效性
        /// </summary>
        /// <param name="txtBox"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        private bool ValidateTextBox(TextBox txtBox, String Message)
        {
            if (txtBox.Text.IsNullOrWhiteSpace())
            {
                MessageBox.Show(Message, "友情提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBox.Focus();
                return false;
            }

            return true;
        }


        #endregion

    }
}
