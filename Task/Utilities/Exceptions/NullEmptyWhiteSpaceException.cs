using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Utilities.Exceptions
{
    public class NullEmptyWhiteSpaceException : Exception
    {
        public NullEmptyWhiteSpaceException(string message) : base(message) { }
    }
}
