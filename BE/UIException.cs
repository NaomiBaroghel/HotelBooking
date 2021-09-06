using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class UIException : Exception
    {
        public UIException() { }
        public UIException(string message)
        : base("DAL Exception : " + message) {}
    }
}
