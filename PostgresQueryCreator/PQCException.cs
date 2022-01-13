using System;
using System.Collections.Generic;
using System.Text;

namespace PostgresQueryCreator
{
    public class PQCException : Exception
    {
        public PQCException(string? message, Exception? innerException)
       : base(message, innerException) { }

        public PQCException(string? message)
    : base(message) { }
    }
}
