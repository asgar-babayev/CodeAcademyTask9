using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Utilities.Exceptions
{
    public class NotAvailableException : Exception
    {
        public NotAvailableException(string message) : base(message) { }
    }
}
