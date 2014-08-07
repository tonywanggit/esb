namespace XTemplate.Templating
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    internal sealed class Directive
    {
        private XTemplate.Templating.Block _Block;
        private string _Name;
        private IDictionary<string, string> _Parameters;

        public Directive(string name, IDictionary<string, string> parameters, XTemplate.Templating.Block block)
        {
            this._Name = name;
            this._Parameters = parameters;
            this._Block = block;
        }

        public string GetParameter(string name)
        {
            string str;
            if (!this.TryGetParameter(name, out str))
            {
                throw new TemplateException(this.Block, string.Format("{0}指令缺少{1}参数！", this.Name, name));
            }
            return str;
        }

        public bool TryGetParameter(string name, out string value)
        {
            value = null;
            if ((this.Parameters != null) && (this.Parameters.Count >= 1))
            {
                if (this.Parameters.TryGetValue(name, out value) || this.Parameters.TryGetValue(name.ToLower(), out value))
                {
                    return true;
                }
                foreach (string str in this.Parameters.Keys)
                {
                    if (string.Equals(str, name, StringComparison.OrdinalIgnoreCase))
                    {
                        value = this.Parameters[str];
                        return true;
                    }
                }
            }
            return false;
        }

        public XTemplate.Templating.Block Block
        {
            get
            {
                return this._Block;
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
        }

        public IDictionary<string, string> Parameters
        {
            get
            {
                return this._Parameters;
            }
        }
    }
}

