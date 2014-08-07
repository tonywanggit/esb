namespace XTemplate.Templating
{
    using System;
    using System.Collections.Generic;

    public class TemplateItem
    {
        private string _BaseClassName;
        private List<Block> _Blocks;
        private string _ClassName;
        private string _Content;
        private List<string> _Imports;
        private bool _Included;
        private string _Name;
        private bool _Processed;
        private string _Source;
        private Dictionary<string, Type> _Vars;

        public override string ToString()
        {
            return this.Name;
        }

        public string BaseClassName
        {
            get
            {
                return this._BaseClassName;
            }
            set
            {
                this._BaseClassName = value;
            }
        }

        internal List<Block> Blocks
        {
            get
            {
                return this._Blocks;
            }
            set
            {
                this._Blocks = value;
            }
        }

        public string ClassName
        {
            get
            {
                if (string.IsNullOrEmpty(this._ClassName))
                {
                    this._ClassName = Template.GetClassName(this.Name);
                }
                return this._ClassName;
            }
            set
            {
                this._ClassName = value;
            }
        }

        public string Content
        {
            get
            {
                return this._Content;
            }
            set
            {
                this._Content = value;
            }
        }

        internal List<string> Imports
        {
            get
            {
                return (this._Imports ?? (this._Imports = new List<string>()));
            }
        }

        public bool Included
        {
            get
            {
                return this._Included;
            }
            internal set
            {
                this._Included = value;
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }

        internal bool Processed
        {
            get
            {
                return this._Processed;
            }
            set
            {
                this._Processed = value;
            }
        }

        public string Source
        {
            get
            {
                return this._Source;
            }
            set
            {
                this._Source = value;
            }
        }

        public IDictionary<string, Type> Vars
        {
            get
            {
                return (this._Vars ?? (this._Vars = new Dictionary<string, Type>()));
            }
        }
    }
}

