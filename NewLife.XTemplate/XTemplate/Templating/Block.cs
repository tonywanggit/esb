namespace XTemplate.Templating
{
    using System;

    internal sealed class Block
    {
        private int _EndColumn;
        private int _EndLine;
        private string _Name;
        private int _StartColumn;
        private int _StartLine;
        private string _Text;
        private BlockType _Type;

        public Block()
        {
        }

        public Block(BlockType type, string text)
        {
            this._Type = type;
            this._Text = text;
        }

        public string ToFullString()
        {
            return string.Format("{0} {1}行 {2}列 ({3}) {4}", new object[] { this.Name, this.StartLine, this.StartColumn, this.Type, this.Text });
        }

        public override string ToString()
        {
            return this.ToFullString();
        }

        public int EndColumn
        {
            get
            {
                return this._EndColumn;
            }
            set
            {
                this._EndColumn = value;
            }
        }

        public int EndLine
        {
            get
            {
                return this._EndLine;
            }
            set
            {
                this._EndLine = value;
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

        public int StartColumn
        {
            get
            {
                return this._StartColumn;
            }
            set
            {
                this._StartColumn = value;
            }
        }

        public int StartLine
        {
            get
            {
                return this._StartLine;
            }
            set
            {
                this._StartLine = value;
            }
        }

        public string Text
        {
            get
            {
                return this._Text;
            }
            set
            {
                this._Text = value;
            }
        }

        public BlockType Type
        {
            get
            {
                return this._Type;
            }
            set
            {
                this._Type = value;
            }
        }
    }
}

