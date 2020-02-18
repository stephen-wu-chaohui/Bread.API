using System;
using System.Collections.Generic;
using System.Text;

namespace Bread.Domain.Exceptions
{
    public class BreadException : ApplicationException
    {
        public BreadExceptionCode ExceptionCode { get; set; }

        public BreadException(BreadExceptionCode code, string message = null, Exception innerException = null)
            : base(message, innerException)
        {
            ExceptionCode = code;
        }
    }
}
