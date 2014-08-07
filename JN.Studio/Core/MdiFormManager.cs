using System;
using System.Collections.Generic;
using System.Text;
using JN.Studio.MdiForm;
using System.Windows.Forms;

namespace JN.Studio.Core
{
    /// <summary>
    /// Mdi子窗体管理器
    /// </summary>
    public class MdiFormManager
    {
        private static MdiFormManager instance;
        private Form parentForm;
        private Dictionary<String, Form> dictForm;

        private MdiFormManager(Form parentForm)
        {
            this.parentForm = parentForm;
            this.dictForm = new Dictionary<string, Form>();
        }

        public static MdiFormManager GetInstance(Form parentForm)
        {
            if (instance == null)
                instance = new MdiFormManager(parentForm);

            return instance; 
        }

        /// <summary>
        /// 显示表结构窗体
        /// </summary>
        /// <param name="formCode"></param>
        /// <param name="formName"></param>
        /// <param name="node"></param>
        public void ShowTableForm(string formCode, string formName, TreeNode node)
        {
            FormTable form = ShowMdiForm<FormTable>("Table", formCode, formName, node);
        }

        /// <summary>
        /// 显示Mdi窗体
        /// </summary>
        /// <param name="formType"></param>
        /// <param name="formCode"></param>
        /// <param name="formName"></param>
        public T ShowMdiForm<T>(string formType, string formCode, string formName, TreeNode node) 
            where T : MdiForm, new()
        {
            T f;
            if (dictForm.ContainsKey(formCode))
            {
                f = dictForm[formCode] as T;
                f.Activate();
            }
            else
            {
                if (formType == "Table")
                    f = new T();
                else
                    f = new T();

                dictForm[formCode] = f;
                f.FormCode = formCode;
                f.BindingNode = node;
                f.FormClosed += new FormClosedEventHandler(frmMid_FormClosed);
                f.Text = formName;
                f.MdiParent = parentForm;
                f.Show();
            }

            return f;
        }

        private void frmMid_FormClosed(object sender, FormClosedEventArgs e)
        {
            MdiForm form = sender as MdiForm;
            if (dictForm.ContainsKey(form.FormCode))
                dictForm.Remove(form.FormCode);
        }
    }
}
