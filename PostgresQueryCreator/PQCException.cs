using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PostgresQueryCreator
{
    [Serializable]
    public class PqcException : Exception
    {
        public PqcException() { }
        public PqcException(string message, Exception innerException)
       : base(message, innerException) { }

        public PqcException(string message)
    : base(message) { }
     protected internal PqcException(SerializationInfo info, StreamingContext context) : base(info, context) { }

    }
}
