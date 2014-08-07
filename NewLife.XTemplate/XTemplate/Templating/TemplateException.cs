namespace XTemplate.Templating
{
    using NewLife.Exceptions;
    using System;
    using System.CodeDom.Compiler;

    public class TemplateException : XException
    {
        private XTemplate.Templating.Block _Block;
        private CompilerError _Error;

        public TemplateException(string message) : base(message)
        {
        }

        internal TemplateException(XTemplate.Templating.Block block, string message) : base(message + block.ToFullString())
        {
            this.Block = block;
        }

        internal XTemplate.Templating.Block Block
        {
            get
            {
                return this._Block;
            }
            private set
            {
                this._Block = value;
            }
        }

        public CompilerError Error
        {
            get
            {
                if ((this._Error == null) && (this.Block != null))
                {
                    this._Error = new CompilerError(this.Block.Name, this.Block.StartLine, this.Block.StartColumn, null, this.Message);
                    this._Error.IsWarning = false;
                }
                return this._Error;
            }
            internal set
            {
                this._Error = value;
            }
        }
    }
}

