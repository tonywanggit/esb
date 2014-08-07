using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI;

namespace ExtAspNet
{
    /// <summary>
    /// 控件-控件相关脚本
    /// </summary>
    internal class ScriptBlock
    {

        private Control _control;

        /// <summary>
        /// 要注册脚本的控件
        /// </summary>
        public Control Control
        {
            get { return _control; }
            set { _control = value; }
        }


        private string _script;

        /// <summary>
        /// 脚本
        /// </summary>
        public string Script
        {
            get { return _script; }
            set { _script = value; }
        }



        private string _extraScript;

        /// <summary>
        /// 额外的脚本
        /// </summary>
        public string ExtraScript
        {
            get { return _extraScript; }
            set { _extraScript = value; }
        }



        public ScriptBlock()
        {
        }


        public ScriptBlock(Control control, string script)
        {
            _control = control;
            _script = script;
            
        }

        public ScriptBlock(Control control, string script, string extraScript)
        {
            _control = control;
            _script = script;
            _extraScript = extraScript;
        }

       
    }
}
