using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions.General
{
    public class BusinessException : Exception
    {
        public Enum Code { get; private set; }
        public BusinessException(Enum message)
            : base(message.GetDescription()) => this.Code = message;
    }
}
