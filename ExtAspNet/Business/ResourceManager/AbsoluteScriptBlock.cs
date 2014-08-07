using System;
using System.Collections.Generic;
using System.Text;

using System.Web.UI;

namespace ExtAspNet
{
    /// <summary>
    /// 脚本（不和控件关联的脚本）
    /// </summary>
    internal class AbsoluteScriptBlock
    {

        private string _script;

        /// <summary>
        /// 脚本
        /// </summary>
        public string Script
        {
            get { return _script; }
            set { _script = value; }
        }



        private int _level;

        /// <summary>
        /// 层次（层次越高，注册越靠后）（缺省100）
        /// 负值表示在所有注册脚本之前执行
        /// </summary>
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }



        public AbsoluteScriptBlock(string script)
        {
            _script = script;
            _level = 100;
        }


        public AbsoluteScriptBlock(string script, int level)
        {
            _script = script;
            _level = level;
        }

        
    }
}
