namespace XTemplate.Templating
{
    using NewLife.Exceptions;
    using System;
    using System.Runtime.Serialization;

    public class TemplateExecutionException : XException
    {
        public TemplateExecutionException()
        {
        }

        public TemplateExecutionException(Exception innerException) : base((innerException != null) ? innerException.Message : null, innerException)
        {
        }

        public TemplateExecutionException(string message) : base(message)
        {
        }

        protected TemplateExecutionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TemplateExecutionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public TemplateExecutionException(string format, params object[] args) : base(format, args)
        {
        }
    }
}

