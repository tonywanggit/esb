namespace JN.FP
{
    partial class FormExport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExport));
            this.ofdAccess = new System.Windows.Forms.OpenFileDialog();
            this.sfdXml = new System.Windows.Forms.SaveFileDialog();
            this.txtAccess = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdAccess = new System.Windows.Forms.Button();
            this.txtXml = new System.Windows.Forms.TextBox();
            this.cmdXml = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdExport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKPFYHJZH = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtKPFDZJDH = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFPDM = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFHRXM = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKPRXM = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNSRMC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNSRSBH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbKPZL = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdAccess
            // 
            this.ofdAccess.Filter = "Access 文件|*.accdb";
            // 
            // sfdXml
            // 
            this.sfdXml.FileName = "通用机打发票";
            this.sfdXml.Filter = "通用机打发票 Xml文件|*.xml";
            // 
            // txtAccess
            // 
            this.txtAccess.Location = new System.Drawing.Point(103, 314);
            this.txtAccess.Name = "txtAccess";
            this.txtAccess.ReadOnly = true;
            this.txtAccess.Size = new System.Drawing.Size(440, 21);
            this.txtAccess.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "请选择Access：";
            // 
            // cmdAccess
            // 
            this.cmdAccess.Location = new System.Drawing.Point(549, 313);
            this.cmdAccess.Name = "cmdAccess";
            this.cmdAccess.Size = new System.Drawing.Size(75, 23);
            this.cmdAccess.TabIndex = 2;
            this.cmdAccess.Text = "选择";
            this.cmdAccess.UseVisualStyleBackColor = true;
            this.cmdAccess.Click += new System.EventHandler(this.cmdAccess_Click);
            // 
            // txtXml
            // 
            this.txtXml.Location = new System.Drawing.Point(103, 346);
            this.txtXml.Name = "txtXml";
            this.txtXml.ReadOnly = true;
            this.txtXml.Size = new System.Drawing.Size(440, 21);
            this.txtXml.TabIndex = 3;
            // 
            // cmdXml
            // 
            this.cmdXml.Location = new System.Drawing.Point(550, 346);
            this.cmdXml.Name = "cmdXml";
            this.cmdXml.Size = new System.Drawing.Size(75, 23);
            this.cmdXml.TabIndex = 4;
            this.cmdXml.Text = "选择";
            this.cmdXml.UseVisualStyleBackColor = true;
            this.cmdXml.Click += new System.EventHandler(this.cmdXml_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "输出Xml到：";
            // 
            // cmdExport
            // 
            this.cmdExport.Location = new System.Drawing.Point(11, 388);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(75, 23);
            this.cmdExport.TabIndex = 6;
            this.cmdExport.Text = "导出";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbKPZL);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtKPFYHJZH);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtKPFDZJDH);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtFPDM);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtFHRXM);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtKPRXM);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNSRMC);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNSRSBH);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(10, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 251);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数配置";
            // 
            // txtKPFYHJZH
            // 
            this.txtKPFYHJZH.Location = new System.Drawing.Point(133, 217);
            this.txtKPFYHJZH.Name = "txtKPFYHJZH";
            this.txtKPFYHJZH.Size = new System.Drawing.Size(456, 21);
            this.txtKPFYHJZH.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 221);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "开票方银行及帐号：";
            // 
            // txtKPFDZJDH
            // 
            this.txtKPFDZJDH.Location = new System.Drawing.Point(133, 184);
            this.txtKPFDZJDH.Name = "txtKPFDZJDH";
            this.txtKPFDZJDH.Size = new System.Drawing.Size(456, 21);
            this.txtKPFDZJDH.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "开票方地址及电话：";
            // 
            // txtFPDM
            // 
            this.txtFPDM.Location = new System.Drawing.Point(115, 144);
            this.txtFPDM.Name = "txtFPDM";
            this.txtFPDM.Size = new System.Drawing.Size(474, 21);
            this.txtFPDM.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "发票代码：";
            // 
            // txtFHRXM
            // 
            this.txtFHRXM.Location = new System.Drawing.Point(385, 106);
            this.txtFHRXM.Name = "txtFHRXM";
            this.txtFHRXM.Size = new System.Drawing.Size(204, 21);
            this.txtFHRXM.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(311, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "复核人姓名：";
            // 
            // txtKPRXM
            // 
            this.txtKPRXM.Location = new System.Drawing.Point(115, 106);
            this.txtKPRXM.Name = "txtKPRXM";
            this.txtKPRXM.Size = new System.Drawing.Size(161, 21);
            this.txtKPRXM.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "开票人姓名：";
            // 
            // txtNSRMC
            // 
            this.txtNSRMC.Location = new System.Drawing.Point(385, 65);
            this.txtNSRMC.Name = "txtNSRMC";
            this.txtNSRMC.Size = new System.Drawing.Size(204, 21);
            this.txtNSRMC.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(310, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "纳税人名称：";
            // 
            // txtNSRSBH
            // 
            this.txtNSRSBH.Location = new System.Drawing.Point(115, 65);
            this.txtNSRSBH.Name = "txtNSRSBH";
            this.txtNSRSBH.Size = new System.Drawing.Size(161, 21);
            this.txtNSRSBH.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "纳税人识别号：";
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(155, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(293, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "上海市通用机打发票 导出程序";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 14;
            this.label11.Text = "开票种类：";
            // 
            // cmbKPZL
            // 
            this.cmbKPZL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKPZL.FormattingEnabled = true;
            this.cmbKPZL.ItemHeight = 12;
            this.cmbKPZL.Items.AddRange(new object[] {
            "国税（21233）",
            "地税（22744）"});
            this.cmbKPZL.Location = new System.Drawing.Point(115, 29);
            this.cmbKPZL.Name = "cmbKPZL";
            this.cmbKPZL.Size = new System.Drawing.Size(161, 20);
            this.cmbKPZL.TabIndex = 15;
            // 
            // FormExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 425);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdXml);
            this.Controls.Add(this.txtXml);
            this.Controls.Add(this.cmdAccess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAccess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发票导出";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExport_FormClosing);
            this.Load += new System.EventHandler(this.FormExport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdAccess;
        private System.Windows.Forms.SaveFileDialog sfdXml;
        private System.Windows.Forms.TextBox txtAccess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdAccess;
        private System.Windows.Forms.TextBox txtXml;
        private System.Windows.Forms.Button cmdXml;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNSRMC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNSRSBH;
        private System.Windows.Forms.TextBox txtKPFDZJDH;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFPDM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFHRXM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKPRXM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtKPFYHJZH;
        private System.Windows.Forms.Label label9;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbKPZL;
    }
}

