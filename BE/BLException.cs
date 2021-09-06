using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class BLException : Exception
    {
        public BLException() { }
        public BLException(string message)
        : base("BL Exception : " + message) { }
    }
}
