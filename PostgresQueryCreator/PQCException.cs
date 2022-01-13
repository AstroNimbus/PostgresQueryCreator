using System;
using System.Collections.Generic;
using System.Text;

namespace PostgresQueryCreator
{
    public class PqcException : Exception
    {
        public PqcException(string message, Exception innerException)
       : base(message, innerException) { }

        public PqcException(string message)
    : base(message) { }
    }
}
