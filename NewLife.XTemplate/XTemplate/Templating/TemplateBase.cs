namespace XTemplate.Templating
{
    using NewLife;
    using NewLife.Reflection;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    [Serializable]
    public abstract class TemplateBase : DisposeBase
    {
        private string _CurrentIndent = "";
        private IDictionary<string, object> _Data;
        private List<int> _indentLengths;
        private StringBuilder _Output;
        private XTemplate.Templating.Template _Template;
        private XTemplate.Templating.TemplateItem _TemplateItem;
        private IDictionary<string, Type> _Vars;
        private bool endsWithNewline;

        protected TemplateBase()
        {
        }

        public void AddIndent(string indent)
        {
            if (indent == null)
            {
                throw new ArgumentNullException("indent");
            }
            this._CurrentIndent = this._CurrentIndent + indent;
            this.indentLengths.Add(indent.Length);
        }

        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this._CurrentIndent = "";
        }

        protected T GetData<T>(string name)
        {
            object data = this.GetData(name);
            if (data == null)
            {
                return default(T);
            }
            return (T) TypeX.ChangeType(data, typeof(T));
        }

        protected object GetData(string name)
        {
            object obj2 = null;
            if (!this.Data.TryGetValue(name, out obj2))
            {
                return null;
            }
            return obj2;
        }

        public virtual void Initialize()
        {
        }

        protected override void OnDispose(bool disposing)
        {
            base.OnDispose(disposing);
            if (this._Output != null)
            {
                this._Output = null;
            }
        }

        public string RemoveIndent()
        {
            string str = "";
            if (this.indentLengths.Count > 0)
            {
                int num = this.indentLengths[this.indentLengths.Count - 1];
                this.indentLengths.RemoveAt(this.indentLengths.Count - 1);
                if (num > 0)
                {
                    str = this._CurrentIndent.Substring(this._CurrentIndent.Length - num);
                    this._CurrentIndent = this._CurrentIndent.Remove(this._CurrentIndent.Length - num);
                }
            }
            return str;
        }

        public virtual string Render()
        {
            return this.Output.ToString();
        }

        public void Write(object obj)
        {
            if (obj != null)
            {
                this.Write(obj.ToString());
            }
        }

        public void Write(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if ((this.Output.Length == 0) || this.endsWithNewline)
                {
                    this.Output.Append(this._CurrentIndent);
                    this.endsWithNewline = false;
                }
                if (str.EndsWith(Environment.NewLine, StringComparison.CurrentCulture))
                {
                    this.endsWithNewline = true;
                }
                if (this._CurrentIndent.Length == 0)
                {
                    this.Output.Append(str);
                }
                else
                {
                    str = str.Replace(Environment.NewLine, Environment.NewLine + this._CurrentIndent);
                    if (this.endsWithNewline)
                    {
                        this.Output.Append(str, 0, str.Length - this._CurrentIndent.Length);
                    }
                    else
                    {
                        this.Output.Append(str);
                    }
                }
            }
        }

        public void Write(string format, params object[] args)
        {
            if (!string.IsNullOrEmpty(format))
            {
                if ((args != null) && (args.Length > 0))
                {
                    this.Write(string.Format(CultureInfo.CurrentCulture, format, args));
                }
                else
                {
                    this.Write(format);
                }
            }
        }

        public void WriteLine()
        {
            this.Output.AppendLine();
            this.endsWithNewline = true;
        }

        public void WriteLine(object obj)
        {
            if (obj != null)
            {
                this.Write(obj.ToString());
            }
            this.Output.AppendLine();
            this.endsWithNewline = true;
        }

        public void WriteLine(string str)
        {
            this.Write(str);
            this.Output.AppendLine();
            this.endsWithNewline = true;
        }

        public void WriteLine(string format, params object[] args)
        {
            if (!string.IsNullOrEmpty(format))
            {
                if ((args != null) && (args.Length > 0))
                {
                    this.Write(string.Format(CultureInfo.CurrentCulture, format, args));
                }
                else
                {
                    this.Write(format);
                }
            }
            this.Output.AppendLine();
            this.endsWithNewline = true;
        }

        public string CurrentIndent
        {
            get
            {
                return this._CurrentIndent;
            }
        }

        public IDictionary<string, object> Data
        {
            get
            {
                return (this._Data ?? (this._Data = new Dictionary<string, object>()));
            }
            set
            {
                this._Data = value;
            }
        }

        private List<int> indentLengths
        {
            get
            {
                if (this._indentLengths == null)
                {
                    this._indentLengths = new List<int>();
                }
                return this._indentLengths;
            }
        }

        protected StringBuilder Output
        {
            get
            {
                if (this._Output == null)
                {
                    this._Output = new StringBuilder();
                }
                return this._Output;
            }
            set
            {
                this._Output = value;
            }
        }

        public XTemplate.Templating.Template Template
        {
            get
            {
                return this._Template;
            }
            set
            {
                this._Template = value;
            }
        }

        public XTemplate.Templating.TemplateItem TemplateItem
        {
            get
            {
                return this._TemplateItem;
            }
            set
            {
                this._TemplateItem = value;
            }
        }

        public IDictionary<string, Type> Vars
        {
            get
            {
                return (this._Vars ?? (this._Vars = new Dictionary<string, Type>()));
            }
            set
            {
                this._Vars = value;
            }
        }
    }
}

